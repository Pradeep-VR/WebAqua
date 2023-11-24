using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AQUA
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        UserManagement uMgt = new UserManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bindUserName();
                }
            }
            catch (Exception ex)
            {
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            UserManagement uMgt = new UserManagement();

            string s = "";
            string s1 = "";
            DataTable dt = new DataTable();
            string strPass1 = "", strPass2 = "", strPass3 = "", strPass4 = "", strPass = "", strEnterPass = "";
            try
            {
                // s1 = "select * from usermaster where username ='" + ddlUserName.Text.Trim() + "' ";
                dt = uMgt.BindUsersPassword(ddlUserName.SelectedItem.Value);

                if (dt.Rows.Count > 0)
                {
                    strPass = dt.Rows[0]["Password"].ToString();
                    strPass1 = dt.Rows[0]["Password1"].ToString();
                    strPass2 = dt.Rows[0]["Password2"].ToString();
                    strPass3 = dt.Rows[0]["Password3"].ToString();
                    strPass4 = dt.Rows[0]["Password4"].ToString();
                    strEnterPass = Utils.EncryptPassword(txtConfirmPassword.Text.Trim());
                    //if (strPass != strEnterPass && strPass1 != strEnterPass && strPass2 != strEnterPass && strPass3 != strEnterPass && strPass4 != strEnterPass)
                    //{
                        strPass4 = strPass3;
                        strPass3 = strPass2;
                        strPass2 = strPass1;
                        strPass1 = strPass;
                        strPass = strEnterPass;
                        bool b = uMgt.UpdatePassword(ddlUserName.SelectedItem.Value, Utils.EncryptPassword(txtConfirmPassword.Text.Trim()), strPass1, strPass2, strPass3, strPass4, "Reset");
                        if (b)
                        {
                            lblMsgSuccess.Text = "Password Reseted successfully.";
                            lblMsgError.Text = "";
                            bindUserName();
                        }
                        else
                        {
                            lblMsgSuccess.Text = "";
                            lblMsgError.Text = "Password not changed. Please try again.";
                        }
                    //}
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

        private void bindUserName()
        {
            ddlUserName.DataSource = uMgt.BindUserName();
            ddlUserName.DataTextField = "UserName";
            ddlUserName.DataValueField = "UserName";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, "-Select-");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindUserName();
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            lblMsgSuccess.Text = "";
            lblMsgError.Text = "";
        }
    }

}