using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class ReceivingReport : System.Web.UI.Page
    {
        ReportManagement rMgt = new ReportManagement();
        CommonManagement cMgt = new CommonManagement();

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
                int currentYear = DateTime.Now.Year;
                for (int i = currentYear - 1; i <= currentYear + 9; i++)
                {
                    ddlfrmYear.Items.Add(i.ToString());

                }
                ddlfrmYear.Items.Insert(0, "-Select-");
                for (int i = currentYear; i <= currentYear + 10; i++)
                {
                    ddltoYear.Items.Add(i.ToString());

                }
                ddltoYear.Items.Insert(0, "-Select-");
            }
        }

        public static string frmdtYear = "";
        public static string todtYear = "";
        public static string frmtoYear = "";

        public static List<string> PurchseType = new List<string>();

        protected void ddlfrmYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mntdt = "-01-01";
            try
            {
                if (ddlfrmYear.SelectedItem.Text != "")
                {
                    frmdtYear = ddlfrmYear.SelectedItem.Text + mntdt.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddltoYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string endmntdt = "-12-31";
            try
            {
                if (ddltoYear.SelectedItem.Text != "")
                {
                    todtYear = ddltoYear.SelectedItem.Text + endmntdt.ToString();
                }
                else
                {

                }

                ddlMonth.DataSource = cMgt.BindDropDown("MonthMaster");
                ddlMonth.DataTextField = "TextField";
                ddlMonth.DataValueField = "ValueField";
                ddlMonth.DataBind();
                ddlMonth.Items.Insert(0, "-Select-");
                ddlMonth.Items.Insert(1, "Select All");


            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Month = ddlMonth.SelectedItem.Text;
            DataTable dts = new DataTable();
            if(Month == "Select All")
            {
                
            }
            else
            {
                dts = rMgt.BRgetmnthCnt(Month);
                if (dts.Rows.Count > 0)
                {
                    string dtvlu1 = ddlfrmYear.SelectedItem.Text + "-" + dts.Rows[0]["ValueField"].ToString() + "%";
                    string dtvlu2 = ddltoYear.SelectedItem.Text + "-" + dts.Rows[0]["ValueField"].ToString() + "%";

                    frmtoYear = "(CONVERT(VARCHAR, PUC.PurchaseDate, 23) LIKE '" + dtvlu1 + "' or CONVERT(VARCHAR, PUC.PurchaseDate, 23) LIKE '" + dtvlu2 + "')";
                }
            }

            ddlPurchaseType.DataSource = cMgt.BindDropDown("PurchaseType");
            ddlPurchaseType.DataTextField = "TextField";
            ddlPurchaseType.DataValueField = "ValueField";
            ddlPurchaseType.DataBind();
            ddlPurchaseType.Items.Insert(0, "-Select-");
            ddlPurchaseType.Items.Insert(1, "Select All");
        }

        protected void ddlPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PurchseType.Clear();
            try
            {
                if(ddlPurchaseType.SelectedItem.Text == "Select All")
                {
                    PurchseType.Add(ddlPurchaseType.Items[2].Text);
                    PurchseType.Add(ddlPurchaseType.Items[3].Text);
                }
                else
                {
                    PurchseType.Add(ddlPurchaseType.SelectedItem.Text);
                }

                ddlPlant.DataSource = cMgt.BindDropDown("Plant");
                ddlPlant.DataTextField = "TextField";
                ddlPlant.DataValueField = "ValueField";
                ddlPlant.DataBind();
                ddlPlant.Items.Insert(0, "-Select-");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            DataTable gbatch = new DataTable();
            DataTable gbtcdtls = new DataTable();
            DataTable gcount = new DataTable();
            DataTable gplntcnt = new DataTable();
            DataTable gCntvlus = new DataTable();
            DataTable ghonqty = new DataTable();
            DataTable gPlntWt = new DataTable();
            DataTable gheadlesqty = new DataTable();
            DataTable gsaudono = new DataTable();
            int cnt1 = 0; int cnt2 = 0; int cnt3 = 0; int cnt4 = 0; int cnt5 = 0; int cnt6 = 0; int cnt7 = 0; int cnt8 = 0;
            string batchno = ""; string sltYear = ""; string saudono = ""; string Dummysaudono = ""; string Dummysaudoncnt = "";
            decimal count = 0; decimal plntcnt = 0; decimal HonQty = 0; decimal HlQty = 0; decimal Yield = 0; decimal PlantWt = 0; decimal PlantYld = 0;
            decimal HonQtyinTon = 0; decimal HlQtyinTon = 0; decimal QtyDiff = 0; decimal CntDiff = 0; decimal Plantqtyinton = 0; decimal diffYield = 0;

            string Range = ""; string Range2 = ""; string Adv = ""; string size = ""; string TGY = ""; string yieldper = ""; string PlntQtyInTon = "";
            string date = ""; string supliername = ""; string supdist = ""; string prtyloc = ""; string supmndl = ""; string supvil = ""; string grader = "";
            string prctyp = "";

            DataTable dtFinalResult = new DataTable();

            dtFinalResult.Columns.Add("gvPlant");
            dtFinalResult.Columns.Add("gvYear");
            dtFinalResult.Columns.Add("gvDate");
            dtFinalResult.Columns.Add("gvBatchNo");
            dtFinalResult.Columns.Add("gvParty");
            dtFinalResult.Columns.Add("gvRange");
            dtFinalResult.Columns.Add("gvBetweenRange");
            dtFinalResult.Columns.Add("gvAdv");
            dtFinalResult.Columns.Add("gvCount");
            dtFinalResult.Columns.Add("gvHonQty");
            dtFinalResult.Columns.Add("gvHLessQty");
            dtFinalResult.Columns.Add("gvTargetYield");
            dtFinalResult.Columns.Add("gvsize");
            dtFinalResult.Columns.Add("gvYield");
            dtFinalResult.Columns.Add("gvPlantCount");
            dtFinalResult.Columns.Add("gvPlantWt");
            dtFinalResult.Columns.Add("gvPlantYield");
            dtFinalResult.Columns.Add("gvQtyDiff");
            dtFinalResult.Columns.Add("gvCountDiff");
            dtFinalResult.Columns.Add("gvBuyingType");
            dtFinalResult.Columns.Add("gvHONQTYTONS");
            dtFinalResult.Columns.Add("gvHLessQTYTONS");
            dtFinalResult.Columns.Add("gvPartyLoc");
            dtFinalResult.Columns.Add("gvVillage");
            dtFinalResult.Columns.Add("gvMandal");
            dtFinalResult.Columns.Add("gvDistric");
            dtFinalResult.Columns.Add("gvGradernme");
            dtFinalResult.Columns.Add("gvPlantQtyTon");
            dtFinalResult.Columns.Add("gvDiffYield");


            try
            {
                sltYear = ddlfrmYear.SelectedItem.Text + "-" + ddltoYear.SelectedItem.Text;

                foreach (string prtype in PurchseType)
                {
                    prctyp = prtype.ToString();

                    if (prctyp == "Factory Purchase")
                    {
                        if (ddlMonth.SelectedItem.Text != "Select All")
                        {
                            gbatch = rMgt.BRGetBatchNoMntwise(frmtoYear, prctyp);
                        }
                        else
                        {
                            gbatch = rMgt.BRGetBatchNo(frmdtYear, todtYear, prctyp);
                        }
                        cnt1 = gbatch.Rows.Count;
                        if (cnt1 > 0)
                        {
                            for (int i = 0; i < cnt1; i++)
                            {
                                batchno = "";
                                batchno = gbatch.Rows[i]["BatchNo"].ToString();
                                gbtcdtls = rMgt.BRGetBtcDtls(batchno, prctyp);
                                cnt2 = gbtcdtls.Rows.Count;
                                if (cnt2 > 0)
                                {
                                    date = gbtcdtls.Rows[0]["PurchaseDate"].ToString();
                                    supliername = gbtcdtls.Rows[0]["SupplierName"].ToString();
                                    supdist = gbtcdtls.Rows[0]["District"].ToString();
                                    prtyloc = gbtcdtls.Rows[0]["District"].ToString();
                                    supmndl = gbtcdtls.Rows[0]["Mandal"].ToString();
                                    supvil = gbtcdtls.Rows[0]["Village"].ToString();
                                    DataTable dtst = new DataTable();
                                    dtst = rMgt.BRGetGrader(batchno);
                                    if (dtst.Rows.Count > 0)
                                    {
                                        grader = dtst.Rows[0]["Grader"].ToString();
                                        if (grader == "0" && dtst.Rows.Count > 1)
                                        {
                                            grader = dtst.Rows[1]["Grader"].ToString();
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else { grader = ""; }

                                    gcount = rMgt.BRGetCnt(batchno, prctyp, "");
                                    cnt3 = gcount.Rows.Count;
                                    if (cnt3 > 0)
                                    {
                                        count = 0;
                                        decimal ty = Convert.ToDecimal(gcount.Rows[0]["cnt"].ToString());
                                        string tyy = ty.ToString("0.0");
                                        count = Convert.ToDecimal(tyy);
                                        plntcnt = 0;
                                        plntcnt = Convert.ToDecimal(gcount.Rows[0]["cnt"]);
                                        string v23 = plntcnt.ToString("0.0");
                                        plntcnt = 0;
                                        plntcnt = Convert.ToDecimal(v23);
                                        if (count == 0 && cnt3 > 1)
                                        {
                                            count = 0;
                                            decimal ty1 = Convert.ToDecimal(gcount.Rows[1]["cnt"].ToString());
                                            string tyy1 = ty1.ToString("0.0");
                                            count = Convert.ToDecimal(tyy1);
                                            plntcnt = 0;
                                            plntcnt = Convert.ToDecimal(gcount.Rows[1]["cnt"]);
                                            string v24 = plntcnt.ToString("0.0");
                                            plntcnt = 0;
                                            plntcnt = Convert.ToDecimal(v24);
                                        }
                                        else
                                        {
                                            //plntcnt = 0;
                                            //count = 0;
                                        }

                                        gCntvlus = rMgt.BRGetCntDtls(count);
                                        cnt4 = gCntvlus.Rows.Count;
                                        if (cnt4 > 0)
                                        {
                                            Range = "";
                                            Range2 = "";
                                            Adv = "";
                                            TGY = "";
                                            size = "";
                                            Range = gCntvlus.Rows[0]["Range"].ToString();
                                            Range2 = gCntvlus.Rows[0]["BetweenRange"].ToString();
                                            Adv = gCntvlus.Rows[0]["ADV"].ToString();
                                            TGY = gCntvlus.Rows[0]["TARGETYIELD"].ToString();
                                            size = gCntvlus.Rows[0]["SIZE"].ToString();

                                        }
                                        else
                                        {
                                            Range = "";
                                            Range2 = "";
                                            Adv = "";
                                            TGY = "";
                                            size = "";
                                        }
                                        ghonqty = rMgt.BRgetHonqty(batchno);
                                        HonQty = 0;
                                        cnt5 = ghonqty.Rows.Count;
                                        if (cnt5 > 0)
                                        {
                                            HonQty = 0; HlQty = 0; Yield = 0; PlantWt = 0; PlantYld = 0; HonQtyinTon = 0; HlQtyinTon = 0; QtyDiff = 0; CntDiff = 0;
                                            var vlu1 = ghonqty.Rows[0]["Headonqty"];

                                            if (vlu1 != DBNull.Value)
                                            {
                                                HonQty = Convert.ToDecimal(ghonqty.Rows[0]["Headonqty"].ToString());
                                            }
                                            else
                                            {
                                                //HonQty = 0;
                                            }
                                            gheadlesqty = rMgt.BRgetHLqty(batchno);
                                            cnt6 = gheadlesqty.Rows.Count;
                                            if (cnt6 > 0)
                                            {
                                                var vlu2 = gheadlesqty.Rows[0]["Headlesqty"];
                                                if (vlu2 != DBNull.Value)
                                                {
                                                    HlQty = Convert.ToDecimal(gheadlesqty.Rows[0]["Headlesqty"].ToString());

                                                    if (HonQty != 0 && HlQty != 0)
                                                    {
                                                        Yield = HlQty / HonQty * 100;
                                                        yieldper = Yield.ToString("0.00");



                                                        decimal v1 = HonQty / 1000;
                                                        string v2 = v1.ToString("0.00");
                                                        HonQtyinTon = Convert.ToDecimal(v2);


                                                        decimal v3 = HlQty / 1000;
                                                        string v4 = v3.ToString("0.00");
                                                        HlQtyinTon = Convert.ToDecimal(v4);
                                                    }
                                                    else
                                                    {

                                                    }

                                                }
                                                else
                                                {

                                                }
                                            }
                                            else
                                            {

                                            }

                                            gPlntWt = rMgt.BRGetPlntCnt(batchno, prctyp, "w1");
                                            cnt7 = gPlntWt.Rows.Count;
                                            if (cnt7 > 0)
                                            {
                                                if (gPlntWt.Rows[0]["fctPlantWt"].ToString() != null || gPlntWt.Rows[0]["fctPlantWt"].ToString() == "" || cnt7 != 0)
                                                {
                                                    if (gPlntWt.Rows[0]["fctPlantWt"].ToString() == "")
                                                    {
                                                        PlantWt = 0;
                                                    }
                                                    else
                                                    {
                                                        decimal vluu = Convert.ToDecimal(gPlntWt.Rows[0]["fctPlantWt"].ToString());
                                                        string vlu2 = vluu.ToString("0.00");
                                                        PlantWt = Convert.ToDecimal(vlu2);
                                                    }

                                                    if (PlantWt != 0)
                                                    {
                                                        decimal vhj = HlQty / PlantWt * 100;
                                                        string vlu = vhj.ToString("0.00");
                                                        PlantYld = Convert.ToDecimal(vlu);
                                                    }
                                                    else if (gPlntWt.Rows.Count > 1)
                                                    {
                                                        decimal vluu = Convert.ToDecimal(gPlntWt.Rows[1]["fctPlantWt"].ToString());
                                                        string vlu2 = vluu.ToString("0.00");
                                                        PlantWt = Convert.ToDecimal(vlu2);
                                                        if (PlantWt != 0)
                                                        {
                                                            decimal vhj = HlQty / PlantWt * 100;
                                                            string vlu = vhj.ToString("0.00");
                                                            PlantYld = Convert.ToDecimal(vlu);
                                                        }
                                                        else
                                                        {
                                                            PlantYld = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        PlantYld = 0;
                                                    }

                                                }
                                                else
                                                {
                                                    gPlntWt.Rows.Clear(); cnt7 = 0;
                                                    gPlntWt = rMgt.BRGetPlntCnt(batchno, prctyp, "w2");
                                                    cnt7 = gPlntWt.Rows.Count;
                                                    if (cnt7 > 1)
                                                    {
                                                        if (gPlntWt.Rows[0]["fctPlantWt"].ToString() != null || gPlntWt.Rows[0]["fctPlantWt"].ToString() != "" || cnt7 != 0)
                                                        {


                                                            if (gPlntWt.Rows[0]["fctPlantWt"].ToString() == "")
                                                            {
                                                                PlantWt = 0;
                                                            }
                                                            else
                                                            {
                                                                decimal vlu = Convert.ToDecimal(gPlntWt.Rows[0]["fctPlantWt"].ToString());
                                                                string vlu2 = vlu.ToString("0.00");
                                                                PlantWt = Convert.ToDecimal(vlu2);
                                                            }
                                                            if (PlantWt != 0)
                                                            {
                                                                decimal vhj = HlQty / PlantWt * 100;
                                                                string vluu = vhj.ToString("0.00");
                                                                PlantYld = Convert.ToDecimal(vluu);
                                                            }
                                                            else if (gPlntWt.Rows.Count > 1)
                                                            {
                                                                decimal vluu = Convert.ToDecimal(gPlntWt.Rows[1]["fctPlantWt"].ToString());
                                                                string vlu2 = vluu.ToString("0.00");
                                                                PlantWt = Convert.ToDecimal(vlu2);
                                                                if (PlantWt != 0)
                                                                {
                                                                    decimal vhj = HlQty / PlantWt * 100;
                                                                    string vlu = vhj.ToString("0.00");
                                                                    PlantYld = Convert.ToDecimal(vlu);
                                                                }
                                                                else
                                                                {
                                                                    PlantYld = 0;

                                                                }
                                                            }
                                                            else
                                                            {
                                                                PlantYld = 0;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            PlantWt = 0;
                                                        }
                                                    }
                                                    //else { PlantWt = 0; PlantYld = 0; }
                                                }
                                            }
                                            else
                                            {
                                                PlantWt = 0; PlantYld = 0;
                                            }


                                            decimal vlue = HonQty - PlantWt;
                                            string vlues = vlue.ToString("0.00");
                                            QtyDiff = Convert.ToDecimal(vlues);

                                            decimal vlue1 = count - plntcnt;
                                            string vlues1 = vlue1.ToString("0.00");
                                            CntDiff = Convert.ToDecimal(vlues1);

                                            Plantqtyinton = PlantWt / 1000;
                                            PlntQtyInTon = Plantqtyinton.ToString("0.00");
                                            if (yieldper == "")
                                            {
                                                yieldper = "0";
                                            }
                                            else { }
                                            diffYield = Convert.ToDecimal(yieldper) - PlantYld;

                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {

                                }
                                dtFinalResult.Rows.Add(ddlPlant.SelectedItem.Text, sltYear, date, batchno, supliername, Range, Range2, Adv, count, HonQty, HlQty, TGY, size, yieldper, plntcnt, PlantWt, PlantYld,
                                  QtyDiff, CntDiff, prctyp, HonQtyinTon, HlQtyinTon, prtyloc, supvil, supmndl, supdist, grader, PlntQtyInTon, diffYield);

                                date = ""; supliername = ""; Range = ""; Range2 = ""; Adv = ""; count = 0; HonQty = 0; HlQty = 0; TGY = ""; size = ""; yieldper = ""; plntcnt = 0; PlantWt = 0; PlantYld = 0;
                                QtyDiff = 0; HonQtyinTon = 0; HlQtyinTon = 0; prtyloc = ""; supvil = ""; supdist = ""; grader = ""; PlntQtyInTon = ""; diffYield = 0;
                            }

                        }
                        else
                        {

                        }
                    }
                    else//Pond Purchase
                    {
                        if (ddlMonth.SelectedItem.Text == "Select All")
                        {
                            gsaudono = rMgt.BRGetSaudoNo(frmdtYear, todtYear, prctyp);
                        }
                        else
                        {
                            gsaudono = rMgt.BRGetSaudoNo(frmtoYear, "", prctyp);
                        }
                        cnt8 = gsaudono.Rows.Count;
                        if (cnt8 > 0)
                        {
                            for (int s = 0; s < cnt8; s++)
                            {
                                saudono = gsaudono.Rows[s]["SadoNo"].ToString();
                                gbatch = rMgt.BRGetBatchnoPP(frmdtYear, todtYear, prctyp, saudono);
                                cnt1 = gbatch.Rows.Count;
                                if (cnt1 > 0)
                                {
                                    for (int i = 0; i < cnt1; i++)
                                    {
                                        batchno = "";
                                        batchno = gbatch.Rows[i]["BatchNo"].ToString();
                                        gbtcdtls = rMgt.BRGetBtcDtls(batchno, prctyp);
                                        cnt2 = gbtcdtls.Rows.Count;
                                        if (cnt2 > 0)
                                        {
                                            date = gbtcdtls.Rows[0]["PurchaseDate"].ToString();
                                            supliername = gbtcdtls.Rows[0]["SupplierName"].ToString();
                                            supdist = gbtcdtls.Rows[0]["District"].ToString();
                                            prtyloc = gbtcdtls.Rows[0]["District"].ToString();
                                            supmndl = gbtcdtls.Rows[0]["Mandal"].ToString();
                                            supvil = gbtcdtls.Rows[0]["Village"].ToString();
                                            DataTable dtst = new DataTable();
                                            dtst = rMgt.BRGetGrader(batchno);
                                            if (dtst.Rows.Count > 0)
                                            {
                                                grader = dtst.Rows[0]["Grader"].ToString();
                                                if (grader == "0" && dtst.Rows.Count > 1)
                                                {
                                                    grader = dtst.Rows[1]["Grader"].ToString();
                                                }
                                                else { }
                                            }
                                            else { }


                                            if (prctyp == "Pond Purchase")
                                            {


                                                gPlntWt = rMgt.BRGetPlntCnt(batchno, prctyp, "");
                                                if (gPlntWt.Rows[0]["pndPlantWt"].ToString() != null || gPlntWt.Rows[0]["pndPlantWt"].ToString() != "" || cnt7 != 0)
                                                {
                                                    if (Dummysaudono == saudono)
                                                    {
                                                        if (gPlntWt.Rows.Count > 1)
                                                        {
                                                            HonQty = Convert.ToDecimal(gPlntWt.Rows[1]["pndPlantWt"].ToString());
                                                            decimal v1 = HonQty / 1000;
                                                            string v2 = v1.ToString("0.00");
                                                            HonQtyinTon = Convert.ToDecimal(v2);

                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (gPlntWt.Rows[0]["pndPlantWt"].ToString() == "")
                                                        {

                                                        }
                                                        else
                                                        {
                                                            HonQty = Convert.ToDecimal(gPlntWt.Rows[0]["pndPlantWt"].ToString());

                                                        }
                                                    }


                                                }
                                                else
                                                {
                                                    //PlantWt = 0;
                                                    //PlantYld = 0;
                                                    //PlntQtyInTon = "0";
                                                }
                                                Dummysaudono = saudono.ToString();
                                            }


                                            gcount = rMgt.BRGetCnt(batchno, prctyp, "");
                                            cnt3 = gcount.Rows.Count;
                                            if (cnt3 > 0)
                                            {
                                                if (prctyp == "Pond Purchase")
                                                {
                                                    if (Dummysaudoncnt == saudono)
                                                    {
                                                        if (cnt3 > 1)
                                                        {
                                                            count = 0;
                                                            decimal ty = Convert.ToDecimal(gcount.Rows[1]["cnt"].ToString());
                                                            string tyy = ty.ToString("0.0");
                                                            count = Convert.ToDecimal(tyy);

                                                        }
                                                        else
                                                        {
                                                            count = 0;
                                                            decimal ty = Convert.ToDecimal(gcount.Rows[0]["cnt"].ToString());
                                                            string tyy = ty.ToString("0.0");
                                                            count = Convert.ToDecimal(tyy);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        count = 0;
                                                        decimal ty = Convert.ToDecimal(gcount.Rows[0]["cnt"].ToString());
                                                        string tyy = ty.ToString("0.0");
                                                        count = Convert.ToDecimal(tyy);

                                                    }

                                                    Dummysaudoncnt = saudono;

                                                    gplntcnt = rMgt.BRGetCnt(batchno, prctyp, "PC");
                                                    if (gplntcnt.Rows.Count > 0)
                                                    {
                                                        plntcnt = 0;
                                                        plntcnt = Convert.ToDecimal(gplntcnt.Rows[0]["cnt"]);
                                                        string v23 = plntcnt.ToString("0.0");
                                                        plntcnt = 0;
                                                        plntcnt = Convert.ToDecimal(v23);
                                                        if (gplntcnt.Rows.Count > 1 && plntcnt == 0)
                                                        {
                                                            plntcnt = 0;
                                                            plntcnt = Convert.ToDecimal(gplntcnt.Rows[1]["cnt"]);
                                                            string v24 = plntcnt.ToString("0.0");
                                                            plntcnt = 0;
                                                            plntcnt = Convert.ToDecimal(v24);
                                                        }
                                                        else { }

                                                    }
                                                    else { }
                                                }

                                                gCntvlus = rMgt.BRGetCntDtls(count);
                                                cnt4 = gCntvlus.Rows.Count;
                                                if (cnt4 > 0)
                                                {
                                                    Range = "";
                                                    Range2 = "";
                                                    Adv = "";
                                                    TGY = "";
                                                    size = "";
                                                    Range = gCntvlus.Rows[0]["Range"].ToString();
                                                    Range2 = gCntvlus.Rows[0]["BetweenRange"].ToString();
                                                    Adv = gCntvlus.Rows[0]["ADV"].ToString();
                                                    TGY = gCntvlus.Rows[0]["TARGETYIELD"].ToString();
                                                    size = gCntvlus.Rows[0]["SIZE"].ToString();

                                                }
                                                else
                                                {
                                                    Range = "";
                                                    Range2 = "";
                                                    Adv = "";
                                                    TGY = "";
                                                    size = "";
                                                }
                                                ghonqty = rMgt.BRgetHonqty(batchno);
                                                //HonQty = 0;
                                                cnt5 = ghonqty.Rows.Count;
                                                if (cnt5 > 0)
                                                {
                                                    /*HonQty = 0;*/
                                                    HlQty = 0; Yield = 0; PlantWt = 0; PlantYld = 0; /*HonQtyinTon = 0;*/ HlQtyinTon = 0; QtyDiff = 0; CntDiff = 0;
                                                    var vlu1 = ghonqty.Rows[0]["Headonqty"];

                                                    if (vlu1 != DBNull.Value)
                                                    {
                                                        decimal vluu = Convert.ToDecimal(vlu1);
                                                        string vluu1 = vluu.ToString("0.00");
                                                        PlantWt = Convert.ToDecimal(vluu1);
                                                        Plantqtyinton = PlantWt / 1000;
                                                        PlntQtyInTon = Plantqtyinton.ToString("0.00");

                                                    }
                                                    else
                                                    {

                                                    }
                                                    gheadlesqty = rMgt.BRgetHLqty(batchno);
                                                    cnt6 = gheadlesqty.Rows.Count;
                                                    if (cnt6 > 0)
                                                    {
                                                        var vlu2 = gheadlesqty.Rows[0]["Headlesqty"];
                                                        if (vlu2 != DBNull.Value)
                                                        {
                                                            HlQty = Convert.ToDecimal(gheadlesqty.Rows[0]["Headlesqty"].ToString());

                                                            if (HonQty != 0 && HlQty != 0)
                                                            {
                                                                Yield = HlQty / HonQty * 100;
                                                                yieldper = Yield.ToString("0.00");

                                                                decimal v3 = HlQty / 1000;
                                                                string v4 = v3.ToString("0.00");
                                                                HlQtyinTon = Convert.ToDecimal(v4);
                                                            }
                                                            else
                                                            {
                                                                yieldper = "";
                                                                HlQtyinTon = 0;
                                                            }

                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                    else
                                                    {

                                                    }
                                                    decimal vhj = HlQty / PlantWt * 100;
                                                    string vlu = vhj.ToString("0.00");
                                                    PlantYld = Convert.ToDecimal(vlu);


                                                    decimal vlue = HonQty - PlantWt;
                                                    string vlues = vlue.ToString("0.00");
                                                    QtyDiff = Convert.ToDecimal(vlues);

                                                    decimal vlue1 = count - plntcnt;
                                                    string vlues1 = vlue1.ToString("0.00");
                                                    CntDiff = Convert.ToDecimal(vlues1);


                                                    if (yieldper == "" || yieldper == "0")
                                                    {
                                                        yieldper = "0";
                                                        diffYield = Convert.ToDecimal(yieldper) - PlantYld;
                                                    }
                                                    else
                                                    {

                                                    }

                                                }
                                                else
                                                {

                                                }
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            //error batch no details empty
                                        }
                                        dtFinalResult.Rows.Add(ddlPlant.SelectedItem.Text, sltYear, date, batchno, supliername, Range, Range2, Adv, count, HonQty, HlQty, TGY, size, yieldper, plntcnt, PlantWt, PlantYld,
                                            QtyDiff, CntDiff, prctyp, HonQtyinTon, HlQtyinTon, prtyloc, supvil, supmndl, supdist, grader, PlntQtyInTon, diffYield);

                                        date = ""; supliername = ""; Range = ""; Range2 = ""; Adv = ""; count = 0; HonQty = 0; HlQty = 0; TGY = ""; size = ""; yieldper = ""; plntcnt = 0; PlantWt = 0; PlantYld = 0;
                                        QtyDiff = 0; HonQtyinTon = 0; HlQtyinTon = 0; prtyloc = ""; supvil = ""; supdist = ""; grader = ""; PlntQtyInTon = ""; diffYield = 0;
                                    }

                                }
                                else
                                {
                                    //error no batchno
                                }

                            }
                        }
                        else { /*nosaudo no*/ }
                    }

                    GVRecivingReport.DataSource = dtFinalResult;
                    GVRecivingReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = RecivingReport" + DateTime.Now.ToString("yyyy-MM-dd_hhmm") + ".xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GVRecivingReport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        
    }
}