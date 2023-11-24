using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PeelingManagement
/// </summary>
/// 
namespace AQUA
{
    public class PeelingManagement : AQUAObject
    {
        public PeelingManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataTable getWorkEfficiency(string strDate)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = "select * from [dbo].[PeelingWorkerEfficiency] where convert(varchar(10),PeelingDate,121) = '" + strDate + "' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;

        }


        public bool PeelWorkerEfficiencyInsert(PeelingWorkEff pwe, string strAction)
        {
            bool b = false;
            string strQuery = "";
            try
            {
                if (strAction == "1")
                {
                    strQuery = "INSERT INTO PeelingWorkerEfficiency (PeelingDate,S1NoOfWorkers,S2NoofWorkers,S1NoOfHours ";
                    strQuery = strQuery + " ,S2NoOfHours ,S1PeeledQty,S2PeeledQty,S1Eff,S2Eff,Remarks,CreatedDate,CreatedBy,Flag,AvgHr) ";
                    strQuery = strQuery + " VALUES ('" + pwe.PeeledDate + "', '" + pwe.S1NoofWorker + "','" + pwe.S2NoofWorker  + "', ";
                    strQuery = strQuery + " '" + pwe.S1NoofHours + "','" + pwe.S2NoofHours + "',  ";
                    strQuery = strQuery + " '" + pwe.S1PeeledQty + "', '" + pwe.S2PeeledQty + "', '" + pwe.S1WorkEfficiency + "', '" + pwe.S2WorkEfficiency + " ', ";
                    strQuery = strQuery + " '" + pwe.Remarks + "' , getdate(), '" + pwe.CreatedBy + "',1 ,'"+pwe.AvgHr+"' )  ";
                }
                else
                {
                    strQuery = " UPDATE[dbo].[PeelingWorkerEfficiency]  SET [S1NoOfWorkers] = '" + pwe.S1NoofWorker + "' , ";
                    strQuery = strQuery + " [S2NoofWorkers] = '" + pwe.S2NoofWorker + "' ,[S1NoOfHours] = '" + pwe.S1NoofHours + "' ";
                    strQuery = strQuery + " ,[S2NoOfHours] = '" + pwe.S2NoofHours + "' ,[S1PeeledQty] = '" + pwe.S1PeeledQty + "' ";
                    strQuery = strQuery + " ,[S2PeeledQty] = '" + pwe.S2PeeledQty + "' ,[S1Eff] = '" + pwe.S1WorkEfficiency + "' ";
                    strQuery = strQuery + " ,[S2Eff] = '" + pwe.S2WorkEfficiency + " ' , [UpdatedBy] = '" + pwe.UpdatedBy + "' ";
                    strQuery = strQuery + " ,[UpdatedDate] = getdate() ,[Remarks] = '" + pwe.Remarks + "' ,AvgHr='"+pwe.AvgHr+"' ";
                    strQuery = strQuery + " WHERE convert(varchar(10),PeelingDate,121) = '" + pwe.PeeledDate + "' ";
                }
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