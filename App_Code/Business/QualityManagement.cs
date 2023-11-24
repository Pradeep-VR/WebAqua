using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using AQUA;
using System.Text;

/// <summary>
/// Summary description for QualityManagement   
/// </summary>
public class QualityManagement : AQUAObject
{
    public QualityManagement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool QualityInsertUpdate(Quality QTY, string strInsertUpdate)
    {
        bool b = false;
        try
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Action", strInsertUpdate));
            parameters.Add(new SqlParameter("TypeOfTesting", QTY.TestingType));
            parameters.Add(new SqlParameter("labName", QTY.LabName));
            parameters.Add(new SqlParameter("ShipmentPONo", QTY.ShipmentPONumber));
            parameters.Add(new SqlParameter("BatchNo", QTY.BatchNumber));
            parameters.Add(new SqlParameter("NoOfSampleTested", QTY.NoOfSamplesTested));
            parameters.Add(new SqlParameter("TestingDate", QTY.TestingDate));
            parameters.Add(new SqlParameter("Index", QTY.Index));
            parameters.Add(new SqlParameter("AOZ", QTY.AOZ));
            parameters.Add(new SqlParameter("AHD", QTY.AHD));
            parameters.Add(new SqlParameter("SEM", QTY.SEM));
            parameters.Add(new SqlParameter("AMOZ", QTY.AMOZ));
            parameters.Add(new SqlParameter("CAP", QTY.CAP));
            parameters.Add(new SqlParameter("MalachiteGreen", QTY.MalachiteGreen));
            parameters.Add(new SqlParameter("CrystalViolet", QTY.CrystalViolet));
            parameters.Add(new SqlParameter("LeucoMalachiteGreen", QTY.LeucoMalachiteGreen));
            parameters.Add(new SqlParameter("LeucoCrystalVoilet", QTY.LeucoCrystalViolet));
            parameters.Add(new SqlParameter("SO2", QTY.SO2));
            parameters.Add(new SqlParameter("TPC", QTY.TPC));
            parameters.Add(new SqlParameter("ECoil", QTY.ECoil));
            parameters.Add(new SqlParameter("Vibrio", QTY.Vibrio));
            parameters.Add(new SqlParameter("Salmonilla", QTY.Salmonella));
            parameters.Add(new SqlParameter("Staphylococcus", QTY.StaphyLococcus));
            parameters.Add(new SqlParameter("FilthStatus", QTY.FilthStatus));
            parameters.Add(new SqlParameter("MicroFailureReason1", QTY.Reason1));
            parameters.Add(new SqlParameter("MicroFailureReason2", QTY.Reason2));
            parameters.Add(new SqlParameter("SampleResult", QTY.SampleResult));
            parameters.Add(new SqlParameter("TestPerformedBy", QTY.PerformedBy));
            parameters.Add(new SqlParameter("EntryDoneBy", QTY.EntryBy));
            parameters.Add(new SqlParameter("OverallFailureReason", QTY.ResultFailure));
            parameters.Add(new SqlParameter("Remarks1", QTY.Remarks));
            parameters.Add(new SqlParameter("Remarks2", QTY.Remarks1));
            parameters.Add(new SqlParameter("CreatedBy", QTY.CreatedBy));
            parameters.Add(new SqlParameter("UpdatedBy", QTY.UpdatedBy));
            parameters.Add(new SqlParameter("ID", QTY.QualityID));            
            b = base.ODataServer.ExecuteSP(parameters, "SP_QualityInsert", SPCommand.Insert);
        }
        catch (Exception ex)
        {
            ex.ToString();
            b = false;
        }
        return b;
    }



    public bool DeleteQuality(string strQtyID,string strUserID)
    {
        bool res = false;
        try
        {
            string qry = "update QUALITYDETAILS set flag=0 , updatedby ='"+strUserID+"', updatedDate = getdate() where id= "+ strQtyID + " ";
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



    public DataTable GetQualityDetails(string strAction,string strQtyID,string strShipmentNumber,string strBatchNo,string strLabName)
    {
        DataTable dt = new DataTable();
        try
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Action", strAction));
            parameters.Add(new SqlParameter("ShipmentPONo", strShipmentNumber.Trim()));
            parameters.Add(new SqlParameter("BatchNo", strBatchNo.Trim()));
            parameters.Add(new SqlParameter("QualityID", strQtyID.Trim()));
            parameters.Add(new SqlParameter("LabName", strLabName.Trim()));
            dt = base.ODataServer.ExecuteSP(parameters, "SP_QualityDetails");
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


    public DataSet GetQualityExport(string strAction, string strQtyID, string strShipmentNumber, string strBatchNo, string strLabName)
    {
        DataSet dt = new DataSet();
        try
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Action", strAction));
            parameters.Add(new SqlParameter("ShipmentPONo", strShipmentNumber.Trim()));
            parameters.Add(new SqlParameter("BatchNo", strBatchNo.Trim()));
            parameters.Add(new SqlParameter("QualityID", strQtyID.Trim()));
            parameters.Add(new SqlParameter("LabName", strLabName.Trim()));
            dt = base.ODataServer.ExecuteSP1(parameters, "SP_QualityDetails","Quality");
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
}

