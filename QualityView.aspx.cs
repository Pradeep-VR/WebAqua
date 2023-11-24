using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class QualityView : AQUABase
    {
        QualityManagement qMgt = new QualityManagement();
        Quality quality = new Quality();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExcel);

            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ControlEnable();
                bindDropdown();
                bindQualityDetails();
                divGridView.Visible = true;
                divEntry.Visible = false;
            }

        }

        private void bindDropdown()
        {
            try
            {
                CommonManagement cMgt = new CommonManagement();
                ddlTestingType.DataSource = cMgt.BindDropDown("TestingType");
                ddlTestingType.DataTextField = "TextField";
                ddlTestingType.DataValueField = "ValueField";
                ddlTestingType.DataBind();
                ddlTestingType.Items.Insert(0, "-Select-");
                ddlLabName.DataSource = cMgt.BindDropDown("LabName");
                ddlLabName.DataTextField = "TextField";
                ddlLabName.DataValueField = "ValueField";
                ddlLabName.DataBind();
                ddlLabName.Items.Insert(0, "-Select-");
                ddlIndex.DataSource = cMgt.BindDropDown("Index");
                ddlIndex.DataTextField = "TextField";
                ddlIndex.DataValueField = "ValueField";
                ddlIndex.DataBind();
                ddlIndex.Items.Insert(0, "-Select-");

                ddlFilthStatus.DataSource = cMgt.BindDropDown("FilthStatus");
                ddlFilthStatus.DataTextField = "TextField";
                ddlFilthStatus.DataValueField = "ValueField";
                ddlFilthStatus.DataBind();
                ddlFilthStatus.Items.Insert(0, "-select-");

            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }
        }


        private void bindQualityDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Session["LabName"].ToString() == "ITC GUNTUR")
                { dt = qMgt.GetQualityDetails("0", "", "", "", ""); }
                else
                { dt = qMgt.GetQualityDetails("0", "", "", "", Session["LabName"].ToString()); }

                gvQualityDetails.DataSource = dt;

                if (dt.Rows.Count > 0)
                {


                    gvQualityDetails.DataBind();
                    divGridView.Visible = true;
                    divEntry.Visible = false;
                }
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }
        }
        protected void btnQualityEntry_Click(object sender, EventArgs e)
        {
            //divGridView.Visible = false;
            //divEntry.Visible = true;
            //btnSave.Text = "Save";
        }

        protected void gvQualityDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                HiddenField lblUName = (HiddenField)gvQualityDetails.Rows[e.NewEditIndex].FindControl("hdnID") as HiddenField;
                int a = e.NewEditIndex;
                DataTable dt = new DataTable();
                string strQtyID = lblUName.Value;
                hdnQtyID.Value = strQtyID;
                dt = qMgt.GetQualityDetails("1", strQtyID, "", "", "");
                if (dt.Rows.Count > 0)
                {
                    bindDropdown();
                    ddlTestingType.SelectedItem.Text = dt.Rows[0]["TypeOfTesting"].ToString();
                    ddlLabName.SelectedItem.Text = dt.Rows[0]["LabName"].ToString();
                    txtShipmentNo.Text = dt.Rows[0]["ShipmentPONo"].ToString();
                    txtBatchNo.Text = dt.Rows[0]["BatchNo"].ToString();
                    txtNoofSampleTest.Text = dt.Rows[0]["NoOfSampleTested"].ToString();
                   // txtTestingDate.TextMode = TextBoxMode.Date;
                    DateTime date = Convert.ToDateTime(dt.Rows[0]["TestingDate"].ToString());
                    txtTestingDate.Text = date.ToString("dd/MM/yyyy");
                    txtAOZ.Text = dt.Rows[0]["AOZ"].ToString();
                    txtAHD.Text = dt.Rows[0]["AHD"].ToString();
                    txtAMOZ.Text = dt.Rows[0]["AMOZ"].ToString();
                    txtCap.Text = dt.Rows[0]["CAP"].ToString();
                    txtCrystalViolet.Text = dt.Rows[0]["CrystalViolet"].ToString();
                    txtLeucoCrystalViolet.Text = dt.Rows[0]["LeucoCrystalVoilet"].ToString();
                    
                    txtECoil.Text = dt.Rows[0]["ECoil"].ToString();
                    txtEntryDoneBy.Text = dt.Rows[0]["EntryDoneBy"].ToString();
                    txtFReason1.Text = dt.Rows[0]["MicroFailureReason1"].ToString();
                    txtFReason2.Text = dt.Rows[0]["MicroFailureReason2"].ToString();
                    txtMalachiteGreen.Text = dt.Rows[0]["MalachiteGreen"].ToString();
                    txtLeucoMalachiteGreen.Text = dt.Rows[0]["LeucoMalachiteGreen"].ToString();
                    

                    txtPerformedBy.Text = dt.Rows[0]["TestPerformedBy"].ToString();
                    txtRemarks.Text = dt.Rows[0]["OverallFailureReason"].ToString();
                    txtRemarks1.Text = dt.Rows[0]["Remarks1"].ToString();
                    txtRemarks2.Text = dt.Rows[0]["Remarks2"].ToString();
                    txtSalmonella.Text = dt.Rows[0]["Salmonilla"].ToString();
                    txtSEM.Text = dt.Rows[0]["SEM"].ToString();
                    txtSO2.Text = dt.Rows[0]["SO2"].ToString();
                    txtStaphylococcus.Text = dt.Rows[0]["Staphylococcus"].ToString();
                    txtTPC.Text = dt.Rows[0]["TPC"].ToString();
                    txtVibrio.Text = dt.Rows[0]["Vibrio"].ToString();
                    ddlFilthStatus.SelectedItem.Text  = dt.Rows[0]["FilthStatus"].ToString();
                    ddlIndex.SelectedItem.Text = dt.Rows[0]["Indexvalue"].ToString();
                    ddlSampleResult.SelectedItem.Text = dt.Rows[0]["SampleResult"].ToString();
                    divGridView.Visible = false;
                    divEntry.Visible = true;
                    //btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }
        }

        private void clear()
        {
            bindDropdown();
            txtShipmentNo.Text = "";
            txtBatchNo.Text = "";
            txtNoofSampleTest.Text = "";
            txtTestingDate.Text = "";
            txtAOZ.Text = "";
            txtAHD.Text = "";
            txtAMOZ.Text = "";
            txtCap.Text = "";
            txtCrystalViolet.Text = "";
            txtECoil.Text = "";
            txtEntryDoneBy.Text = "";
            txtFReason1.Text = "";
            txtFReason2.Text = "";
            txtMalachiteGreen.Text = "";
            txtPerformedBy.Text = "";
            txtRemarks.Text = "";
            txtRemarks1.Text = "";
            txtRemarks2.Text = "";
            txtSalmonella.Text = "";
            txtSEM.Text = "";
            txtSO2.Text = "";
            txtStaphylococcus.Text = "";
            txtTPC.Text = "";
            txtVibrio.Text = "";
            // btnSave.Text = "Back";
        }

        private void ControlEnable()
        {
            bindDropdown();
            txtShipmentNo.ReadOnly = true;
            txtBatchNo.ReadOnly = true;
            txtNoofSampleTest.ReadOnly = true;
            txtTestingDate.ReadOnly = true;
            txtAOZ.ReadOnly = true;
            txtAHD.ReadOnly = true;
            txtAMOZ.ReadOnly = true;
            txtCap.ReadOnly = true;
            //txtCrystalViolet.Enabled = false;
            txtCrystalViolet.ReadOnly = true;
            txtLeucoMalachiteGreen.ReadOnly = true;
            txtLeucoCrystalViolet.ReadOnly = true;

            txtECoil.ReadOnly = true;
            txtEntryDoneBy.ReadOnly = true;
            txtFReason1.ReadOnly = true;
            txtFReason2.ReadOnly = true;
            txtMalachiteGreen.ReadOnly = true;
            txtPerformedBy.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            txtRemarks1.ReadOnly = true;
            txtRemarks2.ReadOnly = true;
            txtSalmonella.ReadOnly = true;
            txtSEM.ReadOnly = true;
            txtSO2.ReadOnly = true;
            txtStaphylococcus.ReadOnly = true;
            txtTPC.ReadOnly = true;
            txtVibrio.ReadOnly = true;
            ddlFilthStatus.Enabled = false;
            ddlIndex.Enabled = false;
            ddlLabName.Enabled = false;
            ddlSampleResult.Enabled = false;
            ddlTestingType.Enabled = false;
            // btnSave.Text = "Back";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            divEntry.Visible = false;
            divGridView.Visible = true;
            bindQualityDetails();
        }


        private DataSet bindQualityExport()
        {
            DataSet ds = new DataSet();
            try
            {
                
                if (Session["LabName"].ToString() == "ITC GUNTUR")
                {
                    ds = qMgt.GetQualityExport("0", "", "", "", "");
                }
                else
                {
                    ds = qMgt.GetQualityExport("0", "", "", "", Session["LabName"].ToString());
                }

               

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
                ds = null;
            }
            return ds;
        }

        public void excelexport()
        {
            DataSet dsRpt = new DataSet();
            dsRpt = bindQualityExport();
            try
            {
                //DataGrid dgGrid = new DataGrid();
                //dgGrid.DataSource = dsRpt;
                //dgGrid.DataBind();

                string filename = "Quality.xls";
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dsRpt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();


            }
            catch (Exception ex)
            {

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename = QualityDtls -" + DateTime.Now.ToString("yyyy-MM-dd hhmm") + ".xls");
            Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvQualityDetails.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }

        

    }
}
