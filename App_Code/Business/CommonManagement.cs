using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CommonManagement
/// </summary>
namespace AQUA
{
    public class CommonManagement : AQUAObject
    {
        public CommonManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // <summary>
        // Need to bind the dropdown using table name
        // </summary>
        // <param name="tableName"></param>
        // <returns></returns>
        public DataTable BindDropDown(string tableName)
        {
            DataTable dtBind = new DataTable();
            try
            {

                string strQry = "Select TextField, ValueField from General where TableName ='" + tableName + "' and flag= 1"; 
                 dtBind = base.ODataServer.GetDataTable(strQry);
               

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
            }
            return dtBind;
        }

       
        
        public DataTable BindGrade()
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select ID, GradeName from Grade where flag= 1";
                dtBind = base.ODataServer.GetDataTable(strQry);
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
            }
            return dtBind;
        }

        public DataTable BindpdType()
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select distinct ProductTypeName as Variety from producttype where flag= 1";
                dtBind = base.ODataServer.GetDataTable(strQry);
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
            }
            return dtBind;
        }
        public DataTable BindVariety()
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select ProductTypeID as ID, ProductTypeName as Variety from producttype where flag= 1";
                dtBind = base.ODataServer.GetDataTable(strQry);
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
            }
            return dtBind;
        }
        /// <summary>
        /// Check the dropdown value using table name and values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool CheckDropDownFields(string value, string tableName)
        {
            bool b = false;
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "Select * from General where TableName ='" + tableName + "' and TextField ='" + value + "' and flag= 1   ";
                dtBind = base.ODataServer.GetDataTable(strQry);
                if (dtBind.Rows.Count == 0)
                { b = true; }
                else
                { b = false; }
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

    }
}