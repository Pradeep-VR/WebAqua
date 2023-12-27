using System;
using System.Text;
using System.Data;

namespace AQUA
{
    public partial class Login : AQUABase
    {
        UserManagement uMgt = new UserManagement();
        AuthenticatedUser aUser = new AuthenticatedUser();
        //int countFail = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            Session["Email"] = null;
            Session["UserType"] = null;
            Session["LabName"] = null;
            Session["Department"] = null;
            Session["LoginLocation"] = null;
            Session["UserGroup"] = null;
            if (!IsPostBack)
            {
                Clear();
                //string username = Request.LogonUserIdentity.Name.ToString();
                //string username1 = System.Environment.UserName.ToString();
                //ValidateUsers(username1);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string username = Request.LogonUserIdentity.Name.ToString();
                //string username1 = System.Environment.UserName.ToString();
                //ValidateUsers(txtUserName.Text);
                //lblerror.Text = username1;
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


        #region Private Methods

        /// <summary>
        /// Clear the user control and focus the cursor in username field 
        /// </summary>
        private void Clear()
        {
            try
            {
                // lblerror.Text = "";
                //txtCaptcha.Text = string.Empty;
                //txtPassword.Text = string.Empty;
                //txtUserName.Text = string.Empty;
                //txtUserName.Focus();

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


        /// <summary>
        /// Given user name and passeord is valid or not
        /// </summary>
        private void ValidateUsers(string strUserName)
        {
            try
            {
                lblerror.Text = "Inside Validate Method & Before check user name";
                aUser = uMgt.IsUserValid(strUserName);
                lblerror.Text = "After Validate Method";
                if (aUser.ID != null)
                {
                    lblerror.Text = "Inside if method";
                    if (aUser.ProcessIn == "Both" || aUser.ProcessIn == "Web")
                    {
                        lblerror.Text = "Inside check the processIN";
                        base.aquaSession.UserName = aUser.UserName;
                        base.aquaSession.UserType = aUser.UserType;
                        Session["UserName"] = aUser.UserName;
                        Session["UserID"] = aUser.ID;
                        Session["Email"] = aUser.Email;
                        Session["UserType"] = aUser.UserType;
                        Session["LabName"] = aUser.LabName;
                        Session["Department"] = aUser.Department;
                        Session["LoginLocation"] = aUser.LoginLocation;
                        Session["UserGroup"] = aUser.UserType;

                        Response.Redirect("Home.aspx");



                        if (aUser.accActive == "Deactive")
                        {
                            lblerror.Text = "Your Account has been deleted!";
                            return;
                        }
                        else if (aUser.accActive == "Lock")
                        {
                            lblerror.Text = "Your Account has been blocked please contact admin!";
                            return;
                        }
                        //else
                        //{
                        //    string PassWord = Utils.EncryptPassword(txtPassword.Text.Trim());
                        //    if (aUser.EnPassword == PassWord)
                        //    {
                        //        //bool b = uMgt.updateFailedCount(0, aUser.ID);
                        //        DateTime eDate = DateTime.Parse(Convert.ToDateTime(aUser.LastLoggedIN).ToShortDateString());
                        //        DateTime cdate = DateTime.Parse(Convert.ToDateTime(DateTime.Now).ToShortDateString());
                        //        TimeSpan DayDiifCount = (cdate - eDate);
                        //        double TotDays = DayDiifCount.TotalDays;
                        //        if (TotDays > 90)
                        //        {
                        //            bool c = uMgt.AccountLocked(aUser.ID);
                        //            //Session["Remainder"] = "Remainder : Your Password will Expire in '" + Convert.ToInt32(TotDays) + "' day(s) you need update your password";
                        //            lblerror.Text = "Your Account has been blocked please contact admin!";
                        //            return;
                        //        }
                        //        else
                        //        {
                        //            bool c = uMgt.updateLoggedIN(aUser.ID);
                        //            lblerror.Text = "Login successed!";
                        //            Response.Redirect("Home.aspx");
                        //        }


                        //        // Create Cookie and Store the Login Detail in it if check box is checked                              

                        //    }
                        //    else
                        //    {
                        //        Session["Remainder"] = "Remainder : Your Password  Expired,  please contact admin!";
                        //        //Response.Redirect("ResetPassword.aspx");
                        //        lblerror.Text = "Remainder : Your Password  Expired,  please contact admin!";
                        //    }
                        //}
                        //        else
                        //        {
                        //    txtPassword.Text = "";
                        //    ViewState["Tries"] = System.Convert.ToInt32(ViewState["Tries"]) + 1;
                        //    countFail = Convert.ToInt32(ViewState["Tries"]);
                        //    if (countFail > 4)
                        //    {
                        //        bool b = uMgt.updateFailedCount(countFail, txtUserName.Text);
                        //        bool c = uMgt.AccountLocked(txtUserName.Text);
                        //        lblerror.Text = "Your Account has been blocked please contact admin";
                        //    }
                        //    else
                        //    {
                        //        bool b = uMgt.updateFailedCount(countFail, txtUserName.Text);
                        //        lblerror.Text = "Please enter correct Password";
                        //    }
                        //}
                    }
                    //}
                    else
                    {
                        lblerror.Text = "Invalid web user. Please check....";
                    }
                }
                else
                {
                    lblerror.Text = "The given user name  does not exists. Please contact Admin";
                    Clear();
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.ToString();
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }
        }

        #endregion



        protected void LgnBtn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            try
            {
                DataTable dt = uMgt.GetUserValid(username, password);
                if (dt.Rows.Count > 0)
                {
                    lblerror.Text = "Inside Validate Method & Before check user name";
                    aUser = uMgt.IsUserValid(username);
                    lblerror.Text = "After Validate Method";
                    if (aUser.ID != null)
                    {
                        lblerror.Text = "Inside if method";
                        if (aUser.ProcessIn == "Both" || aUser.ProcessIn == "Web")
                        {
                            lblerror.Text = "Inside check the processIN";
                            base.aquaSession.UserName = aUser.UserName;
                            base.aquaSession.UserType = aUser.UserType;
                            Session["UserName"] = aUser.UserName;
                            Session["UserID"] = aUser.ID;
                            Session["Email"] = aUser.Email;
                            Session["UserType"] = aUser.UserType;
                            Session["LabName"] = aUser.LabName;
                            Session["Department"] = aUser.Department;
                            Session["LoginLocation"] = aUser.LoginLocation;
                            Session["UserGroup"] = aUser.UserType;

                            Response.Redirect("Home.aspx");

                            if (aUser.accActive == "Deactive")
                            {
                                lblerror.Text = "Your Account has been deleted!";
                                return;
                            }
                            else if (aUser.accActive == "Lock")
                            {
                                lblerror.Text = "Your Account has been blocked please contact admin!";
                                return;
                            }

                        }
                    }
                }
                else
                {
                    lblerror.Text = "The given user name  does not exists. Please contact Admin";

                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    return;
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



    }
}