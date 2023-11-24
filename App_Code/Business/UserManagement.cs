using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Globalization;

namespace AQUA
{
    public class UserManagement : AQUAObject
    {
        #region Authenticated User
        /// <summary>
        /// Need to check the given UserName and Password valid or not. 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthenticatedUser IsUserValid(string userName)
        {
            AuthenticatedUser aUser = new AuthenticatedUser();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("UserName", userName));
                parameters.Add(new SqlParameter("Action", "0"));

                DataTable dt = base.ODataServer.ExecuteSP(parameters, "SP_UserValidation");
                if (dt.Rows.Count > 0)
                {
                    aUser.UserType = dt.Rows[0]["UserType"].ToString(); 
                    aUser.ID = dt.Rows[0]["ID"].ToString();
                    aUser.UserName = dt.Rows[0]["UserName"].ToString();
                    // aUser.fu = dt.Rows[0]["FullName"].ToString();
                    aUser.ExpiryDate = dt.Rows[0]["ExpiryDate"].ToString();
                    aUser.EnPassword = dt.Rows[0]["Password"].ToString();
                    aUser.LoginLocation = dt.Rows[0]["Location"].ToString();
                    aUser.accActive = dt.Rows[0]["Active"].ToString();
                    aUser.LabName = dt.Rows[0]["LabName"].ToString();
                    aUser.Email = dt.Rows[0]["EmailAddress"].ToString();
                    aUser.Department = dt.Rows[0]["Department"].ToString();
                    aUser.ProcessIn = dt.Rows[0]["ProcessIn"].ToString();
                    aUser.LastLoggedIN = dt.Rows[0]["LastLoggedIN"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return aUser = null;
            }
            return aUser;
        }



        public string IsUserAvailable(string userName)
        {
            string UserStatus = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("UserName", userName));
                parameters.Add(new SqlParameter("Action", "0"));

                DataTable dt = base.ODataServer.ExecuteSP(parameters, "SP_UserValidation");
                if (dt.Rows.Count > 0)
                {
                    UserStatus = "Yes";
                }
                else
                { UserStatus = "No"; }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return UserStatus = null;
            }
            return UserStatus;
        }

        #endregion

        /// <summary>
        /// User details insert / update using stored procedure
        /// </summary>
        /// <param name="ur"></param>
        /// <param name="strInsertUpdate"></param>
        /// <returns></returns>
        public bool UserInsertUpdate(Users ur, string strInsertUpdate)
        {
            bool b = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", strInsertUpdate));
                parameters.Add(new SqlParameter("UserName", ur.UserName));
                parameters.Add(new SqlParameter("Password", ur.Password));
                parameters.Add(new SqlParameter("UserType", ur.UserType));
                parameters.Add(new SqlParameter("FullName", ur.FirstName + "  " + ur.LastName));
                parameters.Add(new SqlParameter("FirstName", ur.FirstName));
                parameters.Add(new SqlParameter("LastName", ur.LastName));
                parameters.Add(new SqlParameter("Designation", ur.Designation));
                parameters.Add(new SqlParameter("LabName", ur.LabName));
                parameters.Add(new SqlParameter("Department", ur.Department));
                parameters.Add(new SqlParameter("MobileNumber", ur.MobileNumber));
                parameters.Add(new SqlParameter("EmailAddress", ur.EmailAddress));
                parameters.Add(new SqlParameter("CreatedBy", ur.CreatedBy));
                parameters.Add(new SqlParameter("UpdatedBy", ur.UpdatedBy));
                // parameters.Add(new SqlParameter("Active", ur.Status));
                parameters.Add(new SqlParameter("UserID", ur.UserID));
                parameters.Add(new SqlParameter("ProcessIn", ur.ProcessIn));
                b = base.ODataServer.ExecuteSP(parameters, "SP_UserInsertUpdateDelete", SPCommand.Insert);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                b = false;

            }
            return b;
        }





        public DataTable GetUserDetails(string actionStatus, string ID)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", actionStatus));
                parameters.Add(new SqlParameter("ID", ID));
                dt = base.ODataServer.ExecuteSP(parameters, "SP_UserValidation");
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt = null;
            }
            return dt;
        }



        public Users GetUserDetail(string userID)
        {
            DataTable dt = new DataTable();
            Users u = new Users();
            try
            {

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("USERID", userID));
                dt = base.ODataServer.ExecuteSP(parameters, "sp_GetUserDetails");

                if (dt.Rows.Count > 0)
                {
                    u.UserID = dt.Rows[0]["UserID"].ToString();
                    u.UserName = dt.Rows[0]["UserName"].ToString();
                    u.UserType = dt.Rows[0]["UserType"].ToString();
                    u.FirstName = dt.Rows[0]["FirstName"].ToString();
                    u.LastName = dt.Rows[0]["LastName"].ToString();
                    u.FullName = dt.Rows[0]["FullName"].ToString();
                    u.EmailAddress = dt.Rows[0]["EmailAddress"].ToString();
                    u.Department = dt.Rows[0]["Department"].ToString();
                    u.Designation = dt.Rows[0]["Designation"].ToString();
                    u.MobileNumber = dt.Rows[0]["MobileNumber"].ToString();
                    u.Password = dt.Rows[0]["Password"].ToString();
                }

            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return u = null;
            }
            return u;
        }



        public bool CheckUserNameExists(string userName)
        {
            bool b = false;
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select * from UserMaster where username ='" + userName + "' and flag= 1";
                dtBind = base.ODataServer.GetDataTable(strQry);
                if (dtBind.Rows.Count == 0)
                    b = true;
                else
                    b = false;
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dtBind = null;
                b = false;
            }
            return b;
        }

        public bool CheckPassword(string userID, string password)
        {
            try
            {
                string strQry = "select * from [dbo].[UserMaster] where username ='" + userID + "' and password='" + password + "'";
                DataSet ds = new DataSet();
                ds = base.ODataServer.GetDataset(strQry);

                if (ds.Tables[0].Rows.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable BindUserName()
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select UserName from UserMaster where flag= 1";
                dtBind = base.ODataServer.GetDataTable(strQry);

            }
            catch (Exception ex)
            {
                dtBind = null;
            }
            return dtBind;
        }
        public bool UpdatePassword(string userID, string password, string password1, string password2, string password3, string password4, string strAction)
        {
            try
            {
                bool b = false;
                string strQry = "";
                if (strAction == "Change")
                    strQry = "update usermaster set password = '" + password + "',Password1= '" + password1 + "',password2= '" + password2 + "',password3= '" + password3 + "',password4= '" + password4 + "', Active ='Yes', LoginFailedCount=0, ExpiryDate =DATEADD(MONTH, +3, getdate()) where username ='" + userID + "' ";
                else if (strAction == "Reset")
                    strQry = "update usermaster set password = '" + password + "',Password1= '" + password1 + "',password2= '" + password2 + "',password3= '" + password3 + "',password4= '" + password4 + "',Active ='Yes', LoginFailedCount=0,  ExpiryDate =DATEADD(d, -1, getdate()) where username ='" + userID + "' ";

                b = base.ODataServer.ExecuteNonQuery(strQry);
                return b;
            }
            catch (Exception ex)
            {
                return false;

            }
        }


        public DataTable BindUsersPassword(string strPassword)
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select * from UserMaster where flag= 1 and UserName='"+ strPassword + "' ";
                dtBind = base.ODataServer.GetDataTable(strQry);

            }
            catch (Exception ex)
            {
                dtBind = null;
            }
            return dtBind;
        }


        





        public bool DeleteUsers(string userID, string loginUser)
        {
            bool res = false;
            try
            {
                string qry = "Update userMaster set flag =0 ,updatedBy = '" + loginUser + "', updateddate =getdate() where ID ='" + userID + "' ";
                res = base.ODataServer.ExecuteNonQuery(qry);

            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                res = false;
            }
            return res;
        }

        //public DataTable BindDropDown(string tableName)
        //{
        //    DataTable dtBind = new DataTable();
        //    try
        //    {

        //        string strQry = "Select TextField, ValueField from General where TableName ='" + tableName + "' and flag= 1";
        //        dtBind = base.ODataServer.GetDataTable(strQry);
        //    }
        //    catch (Exception ex)
        //    {
        //        dtBind = null;
        //    }
        //    return dtBind;
        //}

        public bool updateFailedCount(int countFail, string userID)
        {
            try
            {
                bool b = false;
                string strQry = "update usermaster set LoginFailedCount = '" + countFail + "'  where id ='" + userID + "' ";
                b = base.ODataServer.ExecuteNonQuery(strQry);
                return b;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool AccountLocked(string userID)
        {

            try
            {
                bool b = false;
                string strQry = "update usermaster set Active = 'No'   where id ='" + userID + "' ";
                b = base.ODataServer.ExecuteNonQuery(strQry);
                return b;
            }
            catch (Exception ex)
            {
                return false;

            }
        }



        public bool updateLoggedIN(string userID)
        {
            try
            {
                bool b = false;
                string strQry = "update usermaster set LastLoggedIN= getdate()  where id ='" + userID + "' ";
                DataSet ds = new DataSet();
                b = base.ODataServer.ExecuteNonQuery(strQry);
                return b;
            }
            catch (Exception ex)
            {
                return false;

            }
        }



        public bool updateLoginStatus(string status, string userID)
        {
            try
            {
                bool b = false;
                string strQry = "update usermaster set LogoutEnabled= " + status + "  where empid ='" + userID + "' ";
                DataSet ds = new DataSet();
                b = base.ODataServer.ExecuteNonQuery(strQry);
                return b;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}