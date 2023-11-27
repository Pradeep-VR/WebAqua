using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;

namespace AQUA
{
    public partial class PackingReport : Page
    {
        CommonManagement cMgt = new CommonManagement();
        ReportManagement rMgt = new ReportManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnexport);

            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindDropDown();

            }
        }

        private void BindDropDown()
        {

            ddlVariety.DataSource = cMgt.BindDropDown("VarietyRpt");
            ddlVariety.DataTextField = "TextField";
            ddlVariety.DataValueField = "ValueField";
            ddlVariety.DataBind();
            ddlVariety.Items.Insert(0, "-Select-");
            //ddlPurchaseType.Items.Insert(1, "SelectAll");

        }

        protected void ddlVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlBatchNumber.DataSource = rMgt.getbatchpackingrpt(ddlVariety.SelectedItem.Value);
            ddlBatchNumber.DataTextField = "BatchNumber";
            ddlBatchNumber.DataValueField = "BatchNumber";
            ddlBatchNumber.DataBind();
            ddlBatchNumber.Items.Insert(0, "-Select-");

        }

        public static List<string> ChmStsLst = new List<string>();
        public static List<string> PrdTypLst = new List<string>();

        protected void ddlBatchNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            int cnt1 = 0;
            int cnt = 0;

            try
            {
                dt = rMgt.GetHOCpackingrpt(ddlBatchNumber.SelectedItem.Text);
                cnt = dt.Rows.Count;
                if (cnt > 0)
                {
                    decimal HOC = Convert.ToDecimal(dt.Rows[0]["Headoncnt"].ToString());
                    txtheadoncnt.Text = HOC.ToString("0.00");

                }
                else { }

                dt1 = rMgt.GetHeadOnWight(ddlBatchNumber.SelectedItem.Text);
                cnt1 = dt1.Rows.Count;
                if (cnt1 > 0)
                {
                    decimal hocweight = Convert.ToDecimal(dt1.Rows[0]["HeadOnQty"].ToString());
                    txttotrmqty.Text = hocweight.ToString("0.00");

                }
                else { }

                PrdTypLst.Clear();//Adding Productypes aginst the BatchNo
                DataTable prdt = rMgt.GetProdTypes(ddlBatchNumber.SelectedItem.Text, "Scanned");
                if (prdt.Rows.Count > 0)
                {
                    for (int p = 0; p < prdt.Rows.Count; p++)
                    {
                        string Data = prdt.Rows[p]["ProductType"].ToString();
                        PrdTypLst.Add(Data);
                    }
                }

                ChmStsLst.Clear();//Adding Chemicalstatus aginst the BatchNo
                DataTable chmdt = rMgt.GetChemSts(ddlBatchNumber.SelectedItem.Text, "Scanned");
                if (chmdt.Rows.Count > 0)
                {
                    for (int c = 0; c < chmdt.Rows.Count; c++)
                    {
                        string Data = chmdt.Rows[c]["ChemicalSts"].ToString();
                        ChmStsLst.Add(Data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal CntCalculation(string Pdtype, decimal count, decimal total, string chemsts)
        {
            decimal result = 0;
            string clname = Pdtype.ToString();
            DataTable dt = new DataTable();
            try
            {
                dt = rMgt.GetCountdtls(count, Pdtype, chemsts);
                if (dt.Rows.Count > 0)
                {
                    decimal PackingYield = Convert.ToDecimal(dt.Rows[0][clname].ToString());
                    result = total / PackingYield * 100;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public decimal Typeconvertion(string Type, string ActPckStyl, decimal slbCnt)
        {
            decimal result = 0;
            decimal wghtofOneSlab = 0;
            decimal NoofSlab = 0;
            string[] vlus = ActPckStyl.Split('*');

            wghtofOneSlab = Convert.ToDecimal(vlus[1]);
            NoofSlab = slbCnt;

            if (Type == "Lbs")
            {
                string lb = "0.454";
                decimal v = Convert.ToDecimal(lb.ToString());

                result = wghtofOneSlab * NoofSlab * v;
            }
            else if (Type == "Grms")
            {
                string grm = "0.001";
                decimal v = Convert.ToDecimal(grm.ToString());
                result = wghtofOneSlab * NoofSlab * v;
            }
            else//For Kg Type
            {
                result = wghtofOneSlab * NoofSlab;
            }
            return result;
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            DataTable FinalPackingrpt = new DataTable();

            FinalPackingrpt.Columns.Add("gvPoNum");
            FinalPackingrpt.Columns.Add("gvPrdType");
            FinalPackingrpt.Columns.Add("gvGrade");
            FinalPackingrpt.Columns.Add("gvSoakType");
            FinalPackingrpt.Columns.Add("gvTypeOfFreezing");
            FinalPackingrpt.Columns.Add("gvPackStyle");
            FinalPackingrpt.Columns.Add("gvWeightUnit");
            FinalPackingrpt.Columns.Add("gvSlabPacked");
            FinalPackingrpt.Columns.Add("gvQuantity");
            FinalPackingrpt.Columns.Add("gvTotal");
            FinalPackingrpt.Columns.Add("gvHOCConv");



            DataTable pdtyp = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtsok = new DataTable();
            DataTable dtnoslabcnt = new DataTable();
            string PoNo = ""; string Grade = ""; string SoakingTyp = ""; string PrdTyp = ""; string Frztyp = ""; string PckStyl = ""; string WgtUnt = ""; string BatchNo;
            string SoakingTblId = ""; string ChmSts = ""; string FreezTyp = "";
            decimal NoSlabPacked = 0; decimal QtyinKg = 0; decimal Total = 0; decimal FHOCcnv = 0;
            int cnt; int cnt1;
            try
            {
                BatchNo = ddlBatchNumber.SelectedItem.Text;

                for (int CS = 0; CS < ChmStsLst.Count; CS++)//chemical sts loop 
                {
                    ChmSts = ChmStsLst[CS];
                    SoakingTyp = ChmSts.ToString();

                    for (int PD = 0; PD < PrdTypLst.Count; PD++)//product type loop
                    {
                        PrdTyp = PrdTypLst[PD];
                        List<decimal> totlst = new List<decimal>();
                        Total = 0;

                        dt = rMgt.GetIQFscanedData(BatchNo, "Scanned", PrdTyp);//Get batch no details from iqfbarcodeprinting
                        cnt = dt.Rows.Count;
                        if (cnt > 0)
                        {

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                SoakingTblId = dt.Rows[i]["SoakingBarcode"].ToString();

                                PoNo = dt.Rows[i]["POnumber"].ToString();
                                if (PoNo == "")
                                {
                                    PoNo = dt.Rows[i]["SlabPacking"].ToString();
                                }

                                Grade = dt.Rows[i]["Grade"].ToString();
                                PckStyl = dt.Rows[i]["Actpackingstyle"].ToString();
                                WgtUnt = dt.Rows[i]["WeightUnits"].ToString();
                                FreezTyp = dt.Rows[i]["FreezingType"].ToString();

                                dtsok = rMgt.ChkSoakingFD(SoakingTblId);//Get chemical sts , using soaking id or barcode id
                                int cnt2 = dtsok.Rows.Count;
                                if (cnt2 > 0)
                                {
                                    if (ChmSts == dtsok.Rows[0]["chemicalStatus"].ToString())
                                    {
                                        if (PckStyl != "")
                                        {
                                            dtnoslabcnt = rMgt.GetNoOfSlabPacked(BatchNo, PrdTyp, Grade, PckStyl);//Get total number of slabs packed
                                            int cnt5 = dtnoslabcnt.Rows.Count;
                                            if (cnt5 > 0)
                                            {
                                                NoSlabPacked = Convert.ToDecimal(dtnoslabcnt.Rows[0]["PackedSlabCnt"].ToString());
                                            }
                                            else { }

                                            decimal rev = Typeconvertion(WgtUnt, PckStyl, NoSlabPacked);//Kgs,Lbs,Grms are convert to kgs 
                                            QtyinKg = rev;
                                            totlst.Add(QtyinKg);


                                        }
                                        else
                                        {

                                        }

                                        FinalPackingrpt.Rows.Add(PoNo, PrdTyp, Grade, SoakingTyp, FreezTyp, PckStyl, WgtUnt, NoSlabPacked, QtyinKg);
                                    }
                                    else
                                    {

                                    }
                                }

                                //FinalPackingrpt.Rows.Add(PoNo, PrdTyp, Grade, SoakingTyp, FreezTyp, PckStyl, WgtUnt, NoSlabPacked, QtyinKg);
                            }//Dtsl Loop End Here after Nxt Pd Type comes

                            foreach (decimal res in totlst)
                            {
                                if (Total == 0)
                                {
                                    Total = res;
                                }
                                else
                                {
                                    Total = Total + res;
                                }

                            }
                            FinalPackingrpt.Rows.Add("", "", "", "", "", "", "", "Total", Total);

                        }

                        decimal HonCnt = Convert.ToDecimal(txtheadoncnt.Text);
                        FHOCcnv = CntCalculation(PrdTyp, HonCnt, Total, ChmSts);//final hed on count was calculated here

                        string vlu = FHOCcnv.ToString("0.00");

                        FinalPackingrpt.Rows.Add("", "", "", "", "", "", "", "Final to HON", vlu);

                    }//Pdtype Loop End Here after Nxt chml sts comes

                }//Chml sts Loop End Here after Binding Process

                GVPackingRpt.DataSource = FinalPackingrpt;
                GVPackingRpt.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = PackingReport" + DateTime.Now.ToString("yyyy-MM-dd_hhmm") + ".xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GVPackingRpt.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

    }
}
