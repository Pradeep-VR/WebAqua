using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class PeellingFloorBalance : Page
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
                pdtype.Clear();
            }
        }
        private void BindDropDown()
        {
            ddlPlant.DataSource = cMgt.BindDropDown("Plant");
            ddlPlant.DataTextField = "TextField";
            ddlPlant.DataValueField = "ValueField";
            ddlPlant.DataBind();
            ddlPlant.Items.Insert(0, "-Select-");

            ddlPurchaseType.DataSource = cMgt.BindDropDown("PurchaseType");
            ddlPurchaseType.DataTextField = "TextField";
            ddlPurchaseType.DataValueField = "ValueField";
            ddlPurchaseType.DataBind();
            ddlPurchaseType.Items.Insert(0, "-Select-");
            ddlPurchaseType.Items.Insert(1, "SelectAll");

        }

        
        protected void ddlPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string prcType;
            if (ddlPurchaseType.SelectedItem.Text == "SelectAll")
            {
                prcType = "'Factory Purchase','Pond Purchase'";
            }
            else
            {
                prcType = ddlPurchaseType.SelectedItem.Text;
            }


            DataTable dt = rMgt.GetBatcnoPFWR(txtFromDate.Text, txtToDate.Text, ddlPlant.SelectedItem.Text, prcType.ToString());
            ddlBatchNumber.DataSource = dt;
            ddlBatchNumber.DataTextField = "batchNo";
            ddlBatchNumber.DataValueField = "batchNo";
            ddlBatchNumber.DataBind();
            ddlBatchNumber.Items.Insert(0, "SelectAll");


            ddlGrade.DataSource = cMgt.BindGrade();
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "ID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, "SelectAll");

            dmychlist.DataSource = cMgt.BindVariety();
            dmychlist.DataTextField = "Variety";
            dmychlist.DataValueField = "ID";
            dmychlist.DataBind();
            foreach (ListItem dr in dmychlist.Items)
            {
                pdtype.Add(dr.Text);
            }

        }

        public static List<string> pdtype = new List<string>();
        protected void btnView_Click(object sender, EventArgs e)
        {
            List<string> selectedBatchNumbers = new List<string>();
            if (ddlBatchNumber.SelectedItem.Text == "SelectAll")
            {
                foreach (ListItem item in ddlBatchNumber.Items)
                {
                    if (item.Value == "SelectAll")
                    {  }
                    else
                    {
                        selectedBatchNumbers.Add(item.Text);
                    }
                }
            }
            else
            {
                foreach (ListItem item in ddlBatchNumber.Items)
                {
                    if (item.Selected)
                    {
                        selectedBatchNumbers.Add(item.Text);
                    }
                }
            }


             List<string> selectedGrade = new List<string>();
            if (ddlGrade.SelectedItem.Text == "SelectAll")
            {
                foreach (ListItem grade in ddlGrade.Items)
                {
                    if (grade.Value == "SelectAll")
                    {

                    }
                    else
                    {
                        selectedGrade.Add(grade.Text);
                    }
                }
            }
            else
            {
                foreach (ListItem grade in ddlGrade.Items)
                {
                    if (grade.Selected)
                    {
                        selectedGrade.Add(grade.Text);
                    }
                }
            }

            DataTable Bnodt = new DataTable();
            //int bnocnt = 0;                       
            double hlqty = 0;
            int d1 = 0;
            string d2 = "";
            DataTable dtFinalResult = new DataTable();

            dtFinalResult.Columns.Add("batchNo");
            dtFinalResult.Columns.Add("grade");
            dtFinalResult.Columns.Add("pdType");
            dtFinalResult.Columns.Add("HL_Quantity");

            try
            {
                foreach (string batchNumber in selectedBatchNumbers)
                {
                    string batchno = "";
                    batchno = batchNumber.ToString();
                    foreach(string sltgrade in selectedGrade)
                    {
                        string grade = "";
                        grade = sltgrade.ToString();
                        foreach (string lstpdtyp in pdtype)
                        {
                            string pdtypevlu = "";
                            pdtypevlu = lstpdtyp.ToString();

                            //----------//------------//----------//
                            DataTable HLQdt = new DataTable();
                            int HLQcnt = 0;
                            //HLQdt = rMgt.GetHlqtyPFWR(batchno, grade, pdtypevlu);
                            HLQdt = rMgt.BindPellingTotHLQty(batchno, grade, pdtypevlu);
                            HLQcnt = HLQdt.Rows.Count;
                            if (HLQcnt > 0)
                            {
                                hlqty = 0;
                                //if(HLQdt.Rows[0]["HL_Quanti+ty"] != null || HLQdt.Rows[0]["HL_Quantity"].ToString() != "")
                                if (HLQdt.Rows[0]["HL_Quantity"] != DBNull.Value || !string.IsNullOrEmpty(HLQdt.Rows[0]["HL_Quantity"].ToString()))
                                {
                                     
                                    hlqty = Convert.ToDouble(HLQdt.Rows[0]["HL_Quantity"].ToString());
                                    if (d1 == 0)
                                    {
                                        d1 = Convert.ToInt16(hlqty);
                                        
                                    }
                                    else
                                    {
                                        d1 += Convert.ToInt16(hlqty);
                                    }
                                }
                                else
                                {

                                }

                            }
                            else
                            {
                                string lbl = "HL Qty Was Empty For your Requested BatchNo & Grade..";
                            }
                            if (hlqty != 0)
                            {
                                dtFinalResult.Rows.Add(batchno, grade, pdtypevlu, hlqty);
                            }
                            else
                            {

                            }
                        }
                    }
                    string dft = "TOTAL :  " + d1;
                    dtFinalResult.Rows.Add(d2, d2, d2,dft);
                    d1 = 0;
                }
                GVPFloorWise.DataSource = dtFinalResult;
                GVPFloorWise.DataBind(); 
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = PeelingFloorbalance" + DateTime.Now.ToString("yyyy-MM-dd_hhmm") + ".xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GVPFloorWise.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}
