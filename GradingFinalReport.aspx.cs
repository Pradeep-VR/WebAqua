using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;

namespace AQUA
{
    public partial class GradingFinalReport : Page
    {
        CommonManagement cMgt = new CommonManagement();
        ReportManagement rMgt = new ReportManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnexpexcel);           

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

        }
        protected void btnView_Click(object sender, EventArgs e)
        {            
            DataTable combinedDt = new DataTable(); // Create a DataTable to hold the combined results
            int Rcnt = 0;
            string batcno = "";
            try
            {
                try
                {
                    ddlBatchNumber_SelectedIndexChanged(sender, e);
                }
                catch(Exception ex)
                {

                }
                batcno = ddlBatchNumber.SelectedItem.Text;
                if (batcno != "")
                {                    
                        DataTable dt = rMgt.BindGridView(txtFromDate.Text, txtToDate.Text, batcno.ToString(), ddlPurchaseType.SelectedItem.Text);
                        Rcnt = dt.Rows.Count;
                        if (Rcnt > 0)
                        {
                            combinedDt = dt.Clone();
                        }
                        combinedDt.Merge(dt);

                    combinedDt.Columns.Add("sampleHeadlessWeight", typeof(decimal)).DefaultValue=0.00;
                    int i = 0;
                    foreach (DataRow row in combinedDt.Rows)
                    {
                        
                        var srtgrade = combinedDt.Rows[i]["grade"];
                        var srtpdtyp = combinedDt.Rows[i]["productType"];

                        DataTable dtt1 = rMgt.SDGetHLQTY(batcno.ToString(), srtgrade.ToString(),srtpdtyp.ToString());
                        if(dtt1.Rows.Count > 0)
                        {
                            decimal vlu = Convert.ToDecimal(dtt1.Rows[0]["grdwiseHlqty"]);
                            row["sampleHeadlessWeight"] = vlu;
                            if (i != combinedDt.Rows.Count)
                            {
                                i++;
                            }
                        }
                        else
                        {

                        }
                    }
                    combinedDt.Merge(combinedDt);

                    combinedDt.Columns.Add("YieldPercentage", typeof(int));
                    //combinedDt.Columns.Add("AvgYieldper", typeof(int));

                    decimal HLwig = Convert.ToDecimal(combinedDt.Rows[0]["sampleHeadlessWeight"]);
                    decimal totHLwig = HLwig * Rcnt;

                    foreach (DataRow row in combinedDt.Rows)
                    {
                        decimal headlessWeight = Convert.ToDecimal(row["sampleHeadlessWeight"]);
                        decimal totheadlessqty = Convert.ToDecimal(txttthlqty.Text);
                        
                        if (totheadlessqty != 0)
                        {
                            decimal yieldPercentage = (headlessWeight / totheadlessqty) * 100;
                            row["YieldPercentage"] = yieldPercentage;

                            //decimal AveYieldper = (totHLwig / headonquantity) * 100;
                            //row["AvgYieldper"] = AveYieldper;

                        }
                        else
                        {
                            row["YieldPercentage"] = DBNull.Value;
                        }
                        
                    }
                    GradingFinalData.DataSource = combinedDt;
                    GradingFinalData.DataBind();
                }
                else
                {
                    //lblMessage.Text = "Please select at least one batch number.";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
                // You can display or log this errorMessage as needed.
            }
        }

        

        protected void ddlPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataTable dt = rMgt.BindBatchNoGrade(txtFromDate.Text, txtToDate.Text, ddlPlant.SelectedItem.Text, ddlPurchaseType.SelectedItem.Text);

            ddlBatchNumber.DataSource = dt;
            ddlBatchNumber.DataTextField = "batchnumber";
            ddlBatchNumber.DataValueField = "batchnumber";
            ddlBatchNumber.DataBind();
            ddlBatchNumber.Items.Insert(0, "-Select-");

        }

        protected void GradingFinalData_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void ddlBatchNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dty = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            int cnt3 = 0;
            int cnt2 = 0;
            int cnt1 = 0;
            int cnt = 0;
            try
            {
                dt1 = rMgt.SuplierDetails(txtFromDate.Text, txtToDate.Text, ddlBatchNumber.SelectedItem.Text, ddlPurchaseType.SelectedItem.Text);
                cnt1 = dt1.Rows.Count;
                if(cnt1 > 0)
                {
                    txtsupliername.Text = dt1.Rows[0]["supplierName"].ToString();
                    txtheadoncnt.Text = dt1.Rows[0]["Headoncnt"].ToString();
                    //txttotyield.Text = dt1.Rows[0]["Totalyield"].ToString();
                    txtbeheadyield.Text = dt1.Rows[0]["smplbeheadper"].ToString();

                    dty = rMgt.GetHeadOnWight(ddlBatchNumber.SelectedItem.Text);
                    if(dty.Rows.Count > 0)
                    {
                        txtheadonqty.Text = dty.Rows[0]["HeadOnQty"].ToString();
                        
                    }
                }
                else
                {

                }

                dt3 = rMgt.SDGetHLQTY(ddlBatchNumber.SelectedItem.Text,"","");
                cnt3 = dt3.Rows.Count;
                if(cnt3 > 0)
                {
                    txttthlqty.Text = dt3.Rows[0]["totHlQty"].ToString();
                    decimal TOTHONQTY = Convert.ToDecimal(txtheadonqty.Text);
                    decimal TOTHLQTY = Convert.ToDecimal(txttthlqty.Text);
                    decimal total = (TOTHLQTY / TOTHONQTY) * 100;

                    txttotyield.Text = total.ToString("0.00");
                }
                else
                {

                }

                dt = rMgt.QualityDeatails(ddlBatchNumber.SelectedItem.Text);
                cnt = dt.Rows.Count;
                if(cnt > 0)
                {
                    txtsoftper.Text = dt.Rows[0]["SoftPercentage"].ToString();
                    txtblackspotper.Text = dt.Rows[0]["PercentageOfBlackSpot"].ToString();
                    txtnecrosisper.Text = dt.Rows[0]["NecrosisPercentage"].ToString();
                    txtdiscolorper.Text = dt.Rows[0]["DiscolorationPercentage"].ToString();
                    txtcolor.Text = dt.Rows[0]["ColorOfShrimp"].ToString();
                    txtbrokenper.Text = dt.Rows[0]["BrokenPercentage"].ToString();
                }
                else
                {

                }
                dt2 = rMgt.getBSvalue(ddlBatchNumber.SelectedItem.Text);
                cnt2 = dt2.Rows.Count;
                if(cnt2 > 0)
                {
                    txtbsvlu.Text = dt2.Rows[0]["bsRatio"].ToString();
                }
                else
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
        
        public void exporttoexcel(string formate)
        {
            if (formate == "Excel")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename = GradingFinalData" + DateTime.Now.ToString("yyyy-MM-dd_hhmm") + ".xls");
                Response.ContentType = "application/vnd.xls";
                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                GradingFinalData.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            else
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.docx");
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; // Use "application/vnd.openxmlformats-officedocument.wordprocessingml.document" for Word 2007 and later (.docx) files.

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    // Set AllowPaging to false if you want to export the entire GridView.
                    GradingFinalData.AllowPaging = false;
                    GradingFinalData.RenderControl(hw);

                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
                
        protected void btnexpexcel_Click(object sender, EventArgs e)
        {
             exporttoexcel("Excel");
        }

        protected void btnexportWord_Click(object sender, EventArgs e)
        {
            //exporttoexcel("Word");
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.doc";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages.
                GradingFinalData.AllowPaging = false;
                GradingFinalData.DataBind();
                GradingFinalData.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GradingFinalData.HeaderRow.Cells)
                {
                    cell.BackColor = GradingFinalData.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GradingFinalData.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GradingFinalData.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GradingFinalData.RowStyle.BackColor;
                        }
                    }
                }

                GradingFinalData.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}













