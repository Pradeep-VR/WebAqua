using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RMConsumptionManagement
/// </summary>

namespace AQUA
{
    public class RMConsumptionManagement : AQUAObject
    {
        public RMConsumptionManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        public DataTable GetBalance()
        {
            DataTable dt = new DataTable();
            try
            {
                string strqry = "	select top(1) * from [dbo].[SoakingRMConsumption] order by  ConsumptionDate desc";
                dt = base.ODataServer.GetDataTable(strqry);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }
        public bool RMConsumptionInsert(SoakingRMConsumption rmc)
        {
            bool b = false;
            string strQuery = "";
            try
            {
                strQuery = "INSERT INTO [dbo].[SoakingRMConsumption]([ConsumptionDate],[OBChemical] ";
                strQuery = strQuery + " ,[ConChemical] ,[CloseChemical],[OBAdd],[ConAdd] ";
                strQuery = strQuery + " ,[CloseAdd] ,[OBSalt] ,[ConSalt] ,[CloseSalt],[Remarks] ";
                strQuery = strQuery + " ,[CreatedDate] ,[CreatedBy],[status],Type, QtyAddChemical,QtyAddAdd,QtyAddSalt) VALUES ";
                strQuery = strQuery + " ('" + rmc.ConsumptionDate+ "', '" + rmc.OBChemical + "','" + rmc.ConChemical + "', ";
                strQuery = strQuery + " '" + rmc.CloseChemical + "','" + rmc.OBAdd + "','" + rmc.ConAdd + "','" + rmc.CloseAdd + "', '" + rmc.OBSalt + "', ";
                strQuery = strQuery + "  '" + rmc.ConSalt + "', '" + rmc.CloseSalt + " ','"+rmc.Remarks+"', getdate(), '" + rmc.CreatedBy + "',1, '" + rmc.ConsumptionType + "',  ";
                strQuery = strQuery + " '" + rmc.QtyChemical + "' , '"+rmc.QtyAdd + "','"+rmc.QtySalt+"' )";
                b = base.ODataServer.ExecuteNonQuery(strQuery);
            }
            catch (Exception ex)
            {
                ex.ToString();
                b = false;
            }
            return b;
        }
    }
}