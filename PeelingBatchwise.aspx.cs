using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace AQUA
{

    public partial class PeelingBatchwise : System.Web.UI.Page
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
                //ddlBatchNumber.Visible = false;
                //ddlProduct.Visible = false;

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

        protected void btnView_Click(object sender, EventArgs e)
        {
            ReportManagement rMgt = new ReportManagement();
            

            List<string> selectedBatchNumbers = new List<string>();
            if(ddlBatchNumber.SelectedItem.Text == "SelectAll")
            {
                //ddlBatchNumber.Items.Remove("SelectAll");
                foreach (ListItem item in ddlBatchNumber.Items)
                {
                    if (item.Value == "SelectAll")
                    {

                    }
                    else
                    {
                        selectedBatchNumbers.Add(item.Value);
                    }
                }
            }
            else
            {
                foreach (ListItem item in ddlBatchNumber.Items)
                {
                    if (item.Selected)
                    {
                        selectedBatchNumbers.Add(item.Value);
                    }
                }
            }
            

            List<string> selectedPDtype = new List<string>();
            if (ddlProduct.SelectedItem.Text == "SelectAll")
            {                
                foreach (ListItem pdtyps in ddlProduct.Items)
                {
                    if (pdtyps.Value == "SelectAll")
                    {

                    }
                    else
                    {
                        selectedPDtype.Add(pdtyps.Value);
                    }
                }
            }
            else
            {
                foreach (ListItem pdtyps in ddlProduct.Items)
                {
                    if (pdtyps.Selected)
                    {
                        selectedPDtype.Add(pdtyps.Value);
                    }
                }
            }
            
            
            DataTable dtFinalResult = new DataTable();
            DataTable dtFinal = new DataTable();
            DataTable dtGrades = new DataTable();

            dtFinalResult.Columns.Add("BatchNo");
            dtFinalResult.Columns.Add("Grade");
            dtFinalResult.Columns.Add("prdType");
            dtFinalResult.Columns.Add("HL");
            dtFinalResult.Columns.Add("pelled_qty");
            dtFinalResult.Columns.Add("YieldPercentage");

            try
            {
                

                
                if(selectedBatchNumbers.Count > 0)
                {
                    foreach (string batchNumber in selectedBatchNumbers)
                    {
                        dtGrades = rMgt.BindGrade(batchNumber);
                        foreach (DataRow gradeRow in dtGrades.Rows)
                        {
                            foreach(string PDTyp in selectedPDtype)
                            {
                                string grade = gradeRow["grade"].ToString();
                                //DataTable dtHLQty = rMgt.BindPellingTotHLQty(batchNumber, grade,PDTyp);
                                DataTable dtHLQty = rMgt.GetHlqtyPFWR(batchNumber, grade, PDTyp);
                                double hlQty = 0;

                                if (dtHLQty.Rows.Count > 0 && dtHLQty.Rows[0]["HL"] != DBNull.Value)
                                {
                                    hlQty = Convert.ToDouble(dtHLQty.Rows[0]["HL"]);
                                }
                                else
                                {
                                    hlQty = 0;
                                }

                                DataTable dtPelledQty = rMgt.BindPeelingTotPelledQty(batchNumber, grade, PDTyp);
                                double pelledQty = 0;

                                if (dtPelledQty.Rows.Count > 0 && dtPelledQty.Rows[0]["pelled_qty"] != DBNull.Value)
                                {
                                    pelledQty = Convert.ToDouble(dtPelledQty.Rows[0]["pelled_qty"]);
                                }
                                else
                                {
                                    pelledQty = 0;
                                }

                                decimal totissuforpeeling = Convert.ToDecimal(hlQty);
                                decimal totpeeledqty = Convert.ToDecimal(pelledQty);

                                decimal yieldPercentage = 0;

                                if (totpeeledqty != 0)
                                {
                                    yieldPercentage = (totpeeledqty / totissuforpeeling) * 100;

                                }

                                if(hlQty != 0 || pelledQty != 0)
                                {
                                    dtFinalResult.Rows.Add(batchNumber, grade, PDTyp, hlQty, pelledQty, yieldPercentage.ToString("0.00"));
                                }
                                
                            }
                        }
                            
                    }
                    GVPeelingBthwise.DataSource = dtFinalResult;
                    GVPeelingBthwise.DataBind();


                }
                
            }
            catch (Exception ex)
            {

            }
            
        }


        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

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


            DataTable dt = rMgt.BindBatchNumber(txtFromDate.Text, txtToDate.Text, ddlPlant.SelectedItem.Text, prcType.ToString());

            ddlBatchNumber.DataSource = dt;
            ddlBatchNumber.DataTextField = "batchnumber";
            ddlBatchNumber.DataValueField = "batchnumber";
            ddlBatchNumber.DataBind();
            ddlBatchNumber.Items.Insert(0, "SelectAll");

            ddlProduct.DataSource = cMgt.BindVariety();
            ddlProduct.DataTextField = "Variety";
            ddlProduct.DataValueField = "ID";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, "SelectAll");

            //ddlBatchNumber.Visible = true;           
            //ddlProduct.Visible = true;
        }

        protected void GradingFinalData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void PelingFinalData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = PeelingBatchWise-" + DateTime.Now.ToString("yyyy-MM-dd_hhmm") + ".xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GVPeelingBthwise.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}