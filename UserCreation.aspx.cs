#region File Header
/*
--------------------------------------
TeamLiftss IT Systems & solutions pvt. ltd.
Copyright (c) 2021, All rights reserved

Author      : ANANDARAJ G 


Revision History:
Rev   Date                   Who                    Description
1.0   28/July/2021          Anandaraj G            Intial version.
--------------------------------------
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

/// <summary>
/// The admin users able to creation,delete and modify the users.
/// </summary>


namespace AQUA
{
    public partial class UserCreation : System.Web.UI.Page
    {
        UserManagement uMgt = new UserManagement();
        CommonManagement cMgt = new CommonManagement();
        Users u = new Users();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();


        #region Event Handler
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["UserType"].ToString().ToUpper() != "ADMIN")
                {
                    Response.Redirect("Home.aspx");
                }

                if (!IsPostBack)
                {
                    loadBind();
                    bindDropDown();
                    txtUserName.Enabled = true;
                    txtConfirmpassword.Enabled = true;
                    txtpassword.Enabled = true;
                    rfvConfirmPassword.Enabled = true;
                    cvConfirmPassword.Enabled = true;
                    rfvPassword.Enabled = true;
                    btnSave.Text = "Save";
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInsertUpdate();
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
        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                divGridView.Visible = true;
                divEntry.Visible = false;
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                divGridView.Visible = true;
                divEntry.Visible = false;
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
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                divGridView.Visible = false;
                divEntry.Visible = true;
                loadBind();
                bindDropDown();
                txtUserName.Enabled = true;
                txtConfirmpassword.Enabled = true;
                txtpassword.Enabled = true;
                rfvConfirmPassword.Enabled = true;
                cvConfirmPassword.Enabled = true;
                rfvPassword.Enabled = true;
                btnSave.Text = "Save";
                Clear();
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
        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                HiddenField lblUName = (HiddenField)gvUsers.Rows[e.RowIndex].FindControl("hdnID") as HiddenField;
                string strUserID = lblUName.Value;
                Users u = new Users();
                u.UserID = strUserID;
                bool b = uMgt.DeleteUsers(strUserID, Session["UserID"].ToString());
                if (b)
                {
                    lblStatus.Text = "The user deleted successfully ";
                    lblStatus.Text = "";
                    loadBind();
                    btnSave.Text = "Save";
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
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                HiddenField lblUName = (HiddenField)gvUsers.Rows[e.NewEditIndex].FindControl("hdnID") as HiddenField;

                int a = e.NewEditIndex;
                DataTable dt = new DataTable();
                string strUserID = lblUName.Value;
                hdnUserID.Value = strUserID;
                dt = uMgt.GetUserDetails("2", strUserID);
                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                    bindDropDown();
                    ddlUserType.SelectedValue = dt.Rows[0]["UserType"].ToString();
                    ddlDesignation.SelectedValue = dt.Rows[0]["Designation"].ToString();
                    if (dt.Rows[0]["UserType"].ToString().ToUpper() == "ADMIN")
                    {
                        divLabelName.Visible = false;
                        ddlLabName.Visible = false;
                        RequiredFieldValidator5.Visible = false;
                        RequiredFieldValidator6.Visible = false;
                    }
                    else
                    {
                        ddlLabName.SelectedValue = dt.Rows[0]["LabName"].ToString();
                        divLabelName.Visible = true;
                        ddlLabName.Visible = true;
                        RequiredFieldValidator5.Visible = true;
                        RequiredFieldValidator6.Visible = true;
                    }
                    ddlDeparment.SelectedValue = dt.Rows[0]["Department"].ToString();
                    txtMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();
                    txtEmailAddress.Text = dt.Rows[0]["EmailAddress"].ToString();
                    rblProcessIn.SelectedValue = dt.Rows[0]["ProcessIn"].ToString();
                    txtUserName.Enabled = false;
                    txtConfirmpassword.Enabled = false;
                    txtpassword.Enabled = false;
                    rfvConfirmPassword.Enabled = false;
                    cvConfirmPassword.Enabled = false;
                    rfvPassword.Enabled = false;
                    btnSave.Text = "Update";
                    divGridView.Visible = false;
                    divEntry.Visible = true;
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

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUserType.SelectedItem.Value == "admin")
                {
                    divLabelName.Visible = false;
                    ddlLabName.Visible = false;
                    RequiredFieldValidator5.Visible = false;
                    RequiredFieldValidator6.Visible = false;

                }
                else
                {
                    divLabelName.Visible = true;
                    ddlLabName.Visible = true;
                    RequiredFieldValidator5.Visible = true;
                    RequiredFieldValidator6.Visible = true;
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


        #endregion

        #region Private Methods

        private void LoadUserDetails()
        {
            try
            {
                dt = uMgt.GetUserDetails("1", "");
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
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
        private void loadBind()
        {
            try { 
            LoadUserDetails();
                //divGridView.Visible = true;
                //divEntry.Visible = false;
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
        private void SaveInsertUpdate()
        {
            try
            {
                u.FirstName = txtFirstName.Text.Trim();
                u.LastName = txtLastName.Text.Trim();
                u.FullName = txtFirstName.Text.Trim();
                u.MobileNumber = txtMobileNumber.Text.Trim();
                u.EmailAddress = txtEmailAddress.Text.Trim();
                u.Department = ddlDeparment.SelectedValue.ToString();
                u.Designation = ddlDesignation.SelectedValue.ToString();
                u.UserType = ddlUserType.SelectedValue.ToString();
                if (ddlUserType.SelectedValue.ToString() == "admin")
                    u.LabName = "";
                else
                    u.LabName = ddlLabName.SelectedValue.ToString();
                u.UserName = txtUserName.Text.Trim();
                u.Password = Utils.EncryptPassword(txtpassword.Text.Trim());
                u.CreatedBy = Session["UserID"].ToString();
                u.UpdatedBy = Session["UserID"].ToString();
                u.ProcessIn = rblProcessIn.SelectedItem.Value;

                bool b = false;
                if (btnSave.Text == "Save")
                {
                    string result = string.Empty;
                    result = uMgt.IsUserAvailable(txtUserName.Text.Trim());
                    if (result == "Yes")
                    { lblStatus.Text = "User Name already in use"; statusID.Visible = true; }
                    else {
                        b = uMgt.UserInsertUpdate(u, "0");
                    }
                }
                else
                {
                    u.UserID = hdnUserID.Value;
                    b = uMgt.UserInsertUpdate(u, "1");
                }
                if (b == true)
                {
                    Clear();
                    loadBind();
                    lblStatus.Text = "The user transaction completed sucessfully";
                    statusID.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Green;


                    divGridView.Visible = true;
                    divEntry.Visible = false;
                    loadBind();
                    bindDropDown();
                    txtUserName.Enabled = true;
                    txtConfirmpassword.Enabled = true;
                    txtpassword.Enabled = true;
                    rfvConfirmPassword.Enabled = true;
                    cvConfirmPassword.Enabled = true;
                    rfvPassword.Enabled = true;
                    btnSave.Text = "Save";

                }
                else
                {
                    lblStatus.Text = "Something went wrong";
                    statusID.Visible = true;
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
        private void Clear()
        {
            try { 
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtConfirmpassword.Text = string.Empty;
            ddlDeparment.Text = "-Select-";
            ddlUserType.Text = "-Select-";
            ddlDesignation.Text = "-Select-";
            ddlLabName.Text = "-Select-";
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
        public string checkUserName(string IDVal)
        {
            string result = string.Empty;
            try
            {
                result = uMgt.IsUserAvailable(txtUserName.Text.Trim());
                if (result == "Yes")
                    lblStatus.Text = "ID already in use";
                else
                    lblStatus.Text = "";
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
            return result;
        }
        public void bindDropDown()
        {
            try { 
            ddlDeparment.DataSource = cMgt.BindDropDown("Department");
            ddlDeparment.DataTextField = "TextField";
            ddlDeparment.DataValueField = "ValueField";
            ddlDeparment.DataBind();
            ddlDeparment.Items.Insert(0, "-Select-");

            ddlUserType.DataSource = cMgt.BindDropDown("UserType");
            ddlUserType.DataTextField = "TextField";
            ddlUserType.DataValueField = "ValueField";
            ddlUserType.DataBind();
            ddlUserType.Items.Insert(0, "-Select-");

            ddlDesignation.DataSource = cMgt.BindDropDown("Designation");
            ddlDesignation.DataTextField = "TextField";
            ddlDesignation.DataValueField = "ValueField";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, "-Select-");

            ddlLabName.DataSource = cMgt.BindDropDown("LabName");
            ddlLabName.DataTextField = "TextField";
            ddlLabName.DataValueField = "ValueField";
            ddlLabName.DataBind();
            ddlLabName.Items.Insert(0, "-Select-");
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









        #endregion









        protected void rblProcessIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblProcessIn.SelectedItem.Value.ToUpper() == "ANDROID")
            {
                txtpassword.Enabled = true;
                txtConfirmpassword.Enabled = true;
                rfvPassword.Enabled = true;
               // revPasswordLen.Enabled = true;
                revPassword.Enabled = true;
                rfvConfirmPassword.Enabled = true;
                cvConfirmPassword.Enabled = true;
            }
            else if (rblProcessIn.SelectedItem.Value.ToUpper() == "BOTH")
            {
                txtpassword.Enabled = true;
                txtConfirmpassword.Enabled = true;
                rfvPassword.Enabled = true;
               // revPasswordLen.Enabled = true;
                revPassword.Enabled = true;
                rfvConfirmPassword.Enabled = true;
                cvConfirmPassword.Enabled = true;
            }
            else if (rblProcessIn.SelectedItem.Value.ToUpper() == "WEB")
            {
                txtpassword.Enabled = false;
                txtConfirmpassword.Enabled = false;
                rfvPassword.Enabled = false;
              //  revPasswordLen.Enabled = false;
                revPassword.Enabled = false;
                rfvConfirmPassword.Enabled = false;
                cvConfirmPassword.Enabled = false;
            }
        }

        protected void rblProcessIn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}