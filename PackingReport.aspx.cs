using System;
using System.Data;
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
                    txtheadoncnt.Text = dt.Rows[0]["Headoncnt"].ToString();

                }
                else { }

                dt1 = rMgt.GetHeadOnWight(ddlBatchNumber.SelectedItem.Text);
                cnt1 = dt1.Rows.Count;
                if (cnt1 > 0)
                {
                    txttotrmqty.Text = dt1.Rows[0]["HeadOnQty"].ToString();

                }
                else { }
            }
            catch (Exception ex)
            {

            }
        }


        public decimal Typeconvertion(string Type, string ActPckStyl, decimal slbCnt)
        {
            decimal ret = 0;
            decimal wghtofOneSlab = 0;
            decimal NoofSlab = 0;
            string[] vlus = ActPckStyl.Split('*');

            try
            {
                wghtofOneSlab = Convert.ToDecimal(vlus[1]);
                NoofSlab = slbCnt;

                if (Type == "Lbs")
                {
                    string lb = "0.454";
                    decimal v = Convert.ToDecimal(lb.ToString());

                    ret = wghtofOneSlab * NoofSlab * v;
                }
                else if (Type == "Grms")
                {
                    string grm = "0.001";
                    decimal v = Convert.ToDecimal(grm.ToString());
                    ret = wghtofOneSlab * NoofSlab * v;
                }
                else//For Kg Type
                {
                    ret = wghtofOneSlab * NoofSlab;
                }
                
            }
            catch(Exception ex)
            {

            }
            return ret;
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            DataTable pdtyp = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dtsok = new DataTable();
            string PoNo = ""; string Grade = ""; string SoakingTyp = ""; string PrdTyp = ""; string Frztyp = ""; string PckStyl = ""; string WgtUnt = "";string SoakingTblId = "";
            decimal SlabPack = 0; decimal QtyinKg = 0; decimal Total = 0; decimal FHOCcnv = 0;
            int cnt; int cnt1;
            try
            {
                //pdtyp = rMgt.GetPdtyp(ddlBatchNumber.SelectedItem.Text);
                //if (pdtyp.Rows.Count > 0)
                //{
                for (int j = 0; j < pdtyp.Rows.Count; j++)
                {
                    dt = rMgt.GetIQFscanedData(ddlBatchNumber.SelectedItem.Text, "Scanned");
                    cnt = dt.Rows.Count;
                    if (cnt > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            SoakingTblId = dt.Rows[i]["SoakingBarcode"].ToString();
                            PoNo = dt.Rows[i]["POnumber"].ToString();
                            Grade = dt.Rows[i]["Grade"].ToString();
                            PckStyl = dt.Rows[i]["Actpackingstyle"].ToString();
                            WgtUnt = dt.Rows[i]["WeightUnits"].ToString();

                            dtsok = rMgt.ChkSoakingFD(SoakingTblId);
                            int cnt2 = dtsok.Rows.Count;
                            if(cnt2 > 0)
                            {

                            }
                            //dt1 = rMgt.GetPackSpecData(PoNo.ToString(), Grade.ToString());
                            //cnt1 = dt1.Rows.Count;
                            //if (cnt1 > 0)
                            //{
                            //    string chemicalSts = dt1.Rows[0]["ChemicalTreatment"].ToString();
                            //    dt2 = rMgt.GetSoakingType("SoakingType", chemicalSts.ToString());
                            //    if (dt2.Rows.Count > 0)
                            //    {
                            //        SoakingTyp = dt2.Rows[0]["soakingType"].ToString();
                            //        if (SoakingTyp == "PHOSPHATE")
                            //        {
                            //            if (WgtUnt != "")
                            //            {
                            //                decimal Data = Typeconvertion(WgtUnt, PckStyl, 0);
                            //            }

                            //        }
                            //        else { /*Donothing*/ }
                            //    }
                            //}
                            //else
                            //{ /*Donothing*/ }
                        }

                    }
                }
                //}


            }
            catch(Exception ex)
            {

            }
        }



    }
}
