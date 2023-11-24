using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{

    public partial class QualityEntry : AQUABase
    {
        QualityManagement qMgt = new QualityManagement();
        Quality quality = new Quality();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                bindDropdown();
                bindQualityDetails();
                txtTestingDate.TextMode = TextBoxMode.Date;
                if (Session["UserType"].ToString() == "admin")
                {
                    divGridView.Visible = true;
                    divEntry.Visible = false;
                    btnSave.Text = "Save";
                }
                else
                {
                    divGridView.Visible = false;
                    divEntry.Visible = true;
                    btnSave.Text = "Save";
                }
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
                ddlFilthStatus.Items.Insert(0, "-Select-");
                ddlVibrio.DataSource = cMgt.BindDropDown("StatusPA");
                ddlVibrio.DataTextField = "TextField";
                ddlVibrio.DataValueField = "ValueField";
                ddlVibrio.DataBind();
                ddlVibrio.Items.Insert(0, "-Select-");
                ddlSalmonella.DataSource = cMgt.BindDropDown("StatusPA");
                ddlSalmonella.DataTextField = "TextField";
                ddlSalmonella.DataValueField = "ValueField";
                ddlSalmonella.DataBind();
                ddlSalmonella.Items.Insert(0, "-Select-");
                ddlSO2.DataSource = cMgt.BindDropDown("StatusPA");
                ddlSO2.DataTextField = "TextField";
                ddlSO2.DataValueField = "ValueField";
                ddlSO2.DataBind();
                ddlSO2.Items.Insert(0, "-Select-");


                ddlSampleResult.DataSource = cMgt.BindDropDown("FilthStatus");
                ddlSampleResult.DataTextField = "TextField";
                ddlSampleResult.DataValueField = "ValueField";
                ddlSampleResult.DataBind();
                ddlSampleResult.Items.Insert(0, "-Select-");
                txtEntryDoneBy.Text = Session["UserName"].ToString();
                txtEntryDoneBy.Enabled = false;
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddl_PageSize.SelectedValue != "--")
            //{
            //    GridView1.PageSize = Convert.ToInt32(ddl_PageSize.SelectedValue);
            //    GridView1.DataBind();
            //}
        }


        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            //--- For Paging ---------
            GridViewRow row = gvQualityDetails.BottomPagerRow;

            if (row == null)
            {
                return;
            }

            DropDownList DDLPage = (DropDownList)row.Cells[0].FindControl("DDLPage");
            Label lblPages = (Label)row.Cells[0].FindControl("lblPages");
            Label lblCurrent = (Label)row.Cells[0].FindControl("lblCurrent");

            //if (lblPages != null)
            //{
            lblPages.Text = gvQualityDetails.PageCount.ToString();
            //}

            //if (lblCurrent != null)
            //{
            int currentPage = gvQualityDetails.PageIndex + 1;
            lblCurrent.Text = currentPage.ToString();
            //}

            if (DDLPage != null)
            {
                for (int i = 0; i < gvQualityDetails.PageCount; i++)
                {
                    int pageNumber = i + 1;
                    ListItem item = new ListItem(pageNumber.ToString());
                    if (i == gvQualityDetails.PageIndex)
                    {
                        item.Selected = true;
                    }
                    DDLPage.Items.Add(item);
                }
            }

            //-- For First and Previous ImageButton
            if (gvQualityDetails.PageIndex == 0)
            {
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnFirst")).Enabled = false;
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnFirst")).Visible = false;

                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnPrev")).Enabled = false;
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnPrev")).Visible = false;

                //--- OR ---\\
                //ImageButton btnFirst = (ImageButton)row.Cells[0].FindControl("btnFirst");
                //ImageButton btnPrev = (ImageButton)row.Cells[0].FindControl("btnPrev");
                //btnFirst.Visible = false;
                //btnPrev.Visible = false;

            }

            //-- For Last and Next ImageButton
            if (gvQualityDetails.PageIndex + 1 == gvQualityDetails.PageCount)
            {
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnLast")).Enabled = false;
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnLast")).Visible = false;

                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnNext")).Enabled = false;
                ((ImageButton)gvQualityDetails.BottomPagerRow.FindControl("btnNext")).Visible = false;

                //--- OR ---\\
                //ImageButton btnLast = (ImageButton)row.Cells[0].FindControl("btnLast");
                //ImageButton btnNext = (ImageButton)row.Cells[0].FindControl("btnNext");
                //btnLast.Visible = false;
                //btnNext.Visible = false;
            }
        }

        protected void DDLPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvQualityDetails.BottomPagerRow;
            DropDownList DDLPage = (DropDownList)row.Cells[0].FindControl("DDLPage");

            gvQualityDetails.PageIndex = DDLPage.SelectedIndex;
            gvQualityDetails.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (Convert.ToDecimal(txtAOZ.Text) > 20)
                    {
                        lblMessage.Text = "AOZ allow  either less than or equal to 20 or <b>BDL </b> only";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (txtAOZ.Text != "BDL")
                    {
                        lblMessage.Text = "AOZ allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                try
                {
                    if (Convert.ToDecimal(txtAMOZ.Text) > 20)
                    {
                        lblMessage.Text = "AMOZ allow either less than or equal to 20 or <b>BDL </b> only";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (txtAMOZ.Text != "BDL")
                    {
                        lblMessage.Text = "AMOZ allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                try
                {
                    if (Convert.ToDecimal(txtAHD.Text) > 20)
                    {
                        lblMessage.Text = "AHD allow either less than or equal to 20 or <b>BDL </b> only";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (txtAHD.Text != "BDL")
                    {
                        lblMessage.Text = "AHD allow  either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                try
                {
                    if (Convert.ToDecimal(txtSEM.Text) > 20)
                    {
                        lblMessage.Text = "SEM allow either less than or equal to 20 or <b>BDL </b> only";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (txtSEM.Text != "BDL")
                    {
                        lblMessage.Text = "SEM allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                try
                {
                    if (Convert.ToDecimal(txtCap.Text) > 20)
                    {
                        lblMessage.Text = "CAP alow either less than or equal to 20 or <b>BDL </b> only";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (txtCap.Text != "BDL")
                    {
                        lblMessage.Text = "CAP allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }
                //try
                //{
                //    if (txtTPC.Text != "")
                //    {
                //        if (Convert.ToDecimal(txtTPC.Text) > 20)
                //        {
                //            lblMessage.Text = "TPC allow either less than or equal to 20 or <b>BDL </b> only";
                //            return;
                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    if (txtTPC.Text != "BDL")
                //    {
                //        lblMessage.Text = "TPC allow either less than or equal to 20 or <b>BDL </b> only ";
                //        return;
                //    }
                //}
                try
                {
                    if (txtEColi.Text != "")
                    {
                        if (Convert.ToDecimal(txtEColi.Text) > 20)
                        {
                            lblMessage.Text = "EColi allow either less than or equal to 20 or <b>NIL </b> only";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (txtEColi.Text.ToUpper() != "NIL")
                    {
                        lblMessage.Text = "EColi allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                //try
                //{
                //    if (Convert.ToInt32(txtVibrio.Text) > 20)
                //    {
                //        lblMessage.Text = "Vibrio allow either less than or equal to 20 or <b>BDL </b> only";
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    if (txtVibrio.Text != "BDL")
                //    {
                //        lblMessage.Text = "Vibrio allow either less than or equal to 20 or <b>BDL </b> only ";
                //        return;
                //    }
                //}

                //try
                //{
                //    if (Convert.ToInt32(txtSalmonella.Text) > 20)
                //    {
                //        lblMessage.Text = "Salmonella allow either less than or equal to 20 or <b>BDL </b> only";
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    if (txtSalmonella.Text != "BDL")
                //    {
                //        lblMessage.Text = "Salmonella allow either less than or equal to 20 or <b>BDL </b> only ";
                //        return;
                //    }
                //}

                try
                {
                    if (txtStaphylococcus.Text != "")
                    {
                        if (Convert.ToDecimal(txtStaphylococcus.Text) > 100)
                        {
                            lblMessage.Text = "Staphylococcus allow either less than or equal to 100 or <b>NIL </b> only";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (txtStaphylococcus.Text.ToUpper() != "NIL")
                    {
                        lblMessage.Text = "Staphylococcus allow either less than or equal to 20 or <b>NIL </b> only ";
                        return;
                    }
                }




                try
                {
                    if (txtMalachiteGreen.Text != "")
                    {
                        if (Convert.ToDecimal(txtMalachiteGreen.Text) > 20)
                        {
                            lblMessage.Text = "MalachiteGreen allow either less than or equal to 20 or <b>BDL </b> only";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (txtMalachiteGreen.Text != "BDL")
                    {
                        lblMessage.Text = "MalachiteGreen allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }

                try
                {
                    if (txtCrystalViolet.Text != "")
                    {
                        if (Convert.ToDecimal(txtCrystalViolet.Text) > 20)
                        {
                            lblMessage.Text = "CrystalViolet allow either less than or equal to 20 or <b>BDL </b> only";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (txtCrystalViolet.Text != "BDL")
                    {
                        lblMessage.Text = "CrystalViolet allow either less than or equal to 20 or <b>BDL </b> only ";
                        return;
                    }
                }


                //try
                //{
                //    if (Convert.ToInt32(txtSO2.Text) > 20)
                //    {
                //        lblMessage.Text = "SO2 allow either less than or equal to 20 or <b>BDL </b> only";
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    if (txtSO2.Text != "BDL")
                //    {
                //        lblMessage.Text = "SO2 allow either less than or equal to 20 or <b>BDL </b> only ";
                //        return;
                //    }
                //}
                quality.TestingType = ddlTestingType.SelectedValue.ToString();
                quality.LabName = ddlLabName.SelectedItem.Text;
                quality.ShipmentPONumber = txtShipmentNo.Text;
                quality.BatchNumber = txtBatchNo.Text;
                quality.NoOfSamplesTested = txtNoofSampleTest.Text;
                quality.TestingDate = txtTestingDate.Text;
                quality.Index = ddlIndex.SelectedItem.Text;
                quality.AOZ = txtAOZ.Text;
                quality.AHD = txtAHD.Text;
                quality.SEM = txtSEM.Text;
                quality.AMOZ = txtAMOZ.Text;
                quality.CAP = txtCap.Text;
                quality.MalachiteGreen = txtMalachiteGreen.Text;
                quality.CrystalViolet = txtCrystalViolet.Text;
                quality.SO2 = ddlSO2.SelectedItem.Text;
                quality.TPC = txtTPC.Text;
                quality.ECoil = txtEColi.Text;
                quality.Vibrio = ddlVibrio.SelectedItem.Text;// txtVibrio.Text;
                quality.Salmonella = ddlSalmonella.SelectedItem.Text;// txtSalmonella.Text;
                quality.StaphyLococcus = txtStaphylococcus.Text;
                quality.FilthStatus = ddlFilthStatus.SelectedItem.Text;
                quality.Reason1 = txtFReason1.Text;
                quality.Reason2 = txtFReason2.Text;
                quality.SampleResult = ddlSampleResult.SelectedItem.Text;
                quality.PerformedBy = txtPerformedBy.Text;
                quality.EntryBy = txtEntryDoneBy.Text;
                quality.ResultFailure = txtRemarks.Text;
                quality.Remarks = txtRemarks1.Text;
                quality.Remarks1 = txtRemarks2.Text;
                quality.CreatedBy = Session["UserID"].ToString();
                quality.UpdatedBy = Session["UserID"].ToString();
                quality.LeucoCrystalViolet = txtLeucoCrystalViolet.Text;
                quality.LeucoMalachiteGreen = txtLeucoMalachiteGreen.Text;

                if (btnSave.Text == "Save")
                {
                    if (qMgt.QualityInsertUpdate(quality, "1"))
                    {
                        lblMessage.Text = "Quality inserted sucessfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        clear();
                        // AQUA.Utils.SendEmail(txtBatchNo.Text, ddlSampleResult.SelectedItem.Text);
                    }
                    else
                    {
                        lblMessage.Text = "Quality not inserted sucessfully. Please check...";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        //clear();
                    }
                }
                else if (btnSave.Text == "Update")
                {
                    quality.QualityID = hdnQtyID.Value;
                    if (qMgt.QualityInsertUpdate(quality, "2"))
                    {
                        lblStatus.Text = "Quality updated sucessfully.";
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        // EmailSend();
                    }
                    else
                    {
                        lblStatus.Text = "Quality not updated sucessfully. Please check...";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
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

        private void EmailSend()
        {
            string to = "anandaraj@teamliftss.com"; //To address    
            string from = "anandaraj@teamliftss.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Quality Module Testing Result - Body";
            message.Subject = "Quality Module Testing Result";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("mail.teamliftss.com", 465); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("anandaraj@teamliftss.com", "Welcome@123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }





        private void bindQualityDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Session["LabName"].ToString() == "ITC GUNTUR")
                    dt = qMgt.GetQualityDetails("0", "", "", "", "");
                else
                    dt = qMgt.GetQualityDetails("0", "", "", "", Session["LabName"].ToString());

                gvQualityDetails.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    if (Session["UserType"].ToString() == "admin")
                    {
                        ((TemplateField)gvQualityDetails.Columns[11]).Visible = true;
                        ((TemplateField)gvQualityDetails.Columns[12]).Visible = true;
                    }
                    else
                    {
                        ((TemplateField)gvQualityDetails.Columns[11]).Visible = false;
                        ((TemplateField)gvQualityDetails.Columns[12]).Visible = false;
                    }

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
            divGridView.Visible = false;
            divEntry.Visible = true;
            btnSave.Text = "Save";
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
                    ddlTestingType.SelectedItem.Text  = dt.Rows[0]["TypeOfTesting"].ToString();
                    ddlLabName.SelectedItem.Text = dt.Rows[0]["LabName"].ToString();
                    txtShipmentNo.Text = dt.Rows[0]["ShipmentPONo"].ToString();
                    txtBatchNo.Text = dt.Rows[0]["BatchNo"].ToString();
                    txtNoofSampleTest.Text = dt.Rows[0]["NoOfSampleTested"].ToString();
                    txtTestingDate.TextMode = TextBoxMode.SingleLine;
                    DateTime date = Convert.ToDateTime(dt.Rows[0]["TestingDate"].ToString());
                    txtTestingDate.Text = date.ToString("dd/MM/yyyy");
                    txtTestingDate.Enabled = false;
                    txtAOZ.Text = dt.Rows[0]["AOZ"].ToString();
                    txtAHD.Text = dt.Rows[0]["AHD"].ToString();
                    txtAMOZ.Text = dt.Rows[0]["AMOZ"].ToString();
                    txtCap.Text = dt.Rows[0]["CAP"].ToString();
                    txtCrystalViolet.Text = dt.Rows[0]["CrystalViolet"].ToString();
                    txtMalachiteGreen.Text = dt.Rows[0]["MalachiteGreen"].ToString();
                    txtLeucoCrystalViolet.Text = dt.Rows[0]["LeucoCrystalVoilet"].ToString();
                    txtLeucoMalachiteGreen.Text = dt.Rows[0]["LeucoMalachiteGreen"].ToString();
                    txtEColi.Text = dt.Rows[0]["ECoil"].ToString();
                    txtEntryDoneBy.Text = dt.Rows[0]["EntryDoneBy"].ToString();
                    txtFReason1.Text = dt.Rows[0]["MicroFailureReason1"].ToString();
                    txtFReason2.Text = dt.Rows[0]["MicroFailureReason2"].ToString();
                    txtPerformedBy.Text = dt.Rows[0]["TestPerformedBy"].ToString();
                    txtRemarks.Text = dt.Rows[0]["OverallFailureReason"].ToString();
                    txtRemarks1.Text = dt.Rows[0]["Remarks1"].ToString();
                    txtRemarks2.Text = dt.Rows[0]["Remarks2"].ToString();
                    ddlSalmonella.SelectedItem.Text = dt.Rows[0]["Salmonilla"].ToString();
                    txtSEM.Text = dt.Rows[0]["SEM"].ToString();
                    ddlSO2.SelectedItem.Text = dt.Rows[0]["SO2"].ToString();
                    txtStaphylococcus.Text = dt.Rows[0]["Staphylococcus"].ToString();
                    txtTPC.Text = dt.Rows[0]["TPC"].ToString();
                    ddlVibrio.SelectedItem.Text = dt.Rows[0]["Vibrio"].ToString();
                    ddlFilthStatus.SelectedItem.Text = dt.Rows[0]["FilthStatus"].ToString();
                    ddlIndex.SelectedItem.Text = dt.Rows[0]["Indexvalue"].ToString();
                    ddlSampleResult.SelectedItem.Text = dt.Rows[0]["SampleResult"].ToString();
                    divGridView.Visible = false;
                    divEntry.Visible = true;
                    btnSave.Text = "Update";
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
            txtEColi.Text = "";
            txtEntryDoneBy.Text = "";
            txtFReason1.Text = "";
            txtFReason2.Text = "";
            txtMalachiteGreen.Text = "";
            txtPerformedBy.Text = "";
            txtRemarks.Text = "";
            txtRemarks1.Text = "";
            txtRemarks2.Text = "";
            txtSEM.Text = "";
            txtStaphylococcus.Text = "";
            txtTPC.Text = "";
            btnSave.Text = "Save";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            if (Session["UserType"].ToString() == "admin")
            {
                divEntry.Visible = false;
                divGridView.Visible = true;
            }
            else
            {
                divEntry.Visible = true;
                divGridView.Visible = false;
            }
        }

        protected void gvQualityDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            HiddenField lblUName = (HiddenField)gvQualityDetails.Rows[e.RowIndex].FindControl("hdnID") as HiddenField;
            string strQtyID = lblUName.Value;
            Users u = new Users();
            u.UserID = strQtyID;
            bool b = qMgt.DeleteQuality(strQtyID, Session["UserID"].ToString());
            if (b)
            {
                lblStatus.Text = "The Quality record deleted successfully ";
                lblStatus.Text = "";
                bindQualityDetails();
                btnSave.Text = "Save";
                divGridView.Visible = true;
                divEntry.Visible = false;
            }
        }

        protected void gvQualityDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRow row = gvQualityDetails.BottomPagerRow;
            DropDownList DDLPage = (DropDownList)row.Cells[0].FindControl("DDLPage");
            gvQualityDetails.PageIndex = DDLPage.SelectedIndex;
            gvQualityDetails.DataBind();
        }

        protected void ddlTestingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTestingType.SelectedItem.Text == "RAW Material Testing")
            {
                txtBatchNo.Enabled = true;
                txtShipmentNo.Enabled = false;
                rfvBatchNo.Enabled = true;
                rfvShipmentNo.Enabled = false;
            }
            else if (ddlTestingType.SelectedItem.Text == "FG Testing")
            {
                txtBatchNo.Enabled = true;
                txtShipmentNo.Enabled = true;
                rfvBatchNo.Enabled = false;
                rfvShipmentNo.Enabled = true;
            }
        }
    }
}
