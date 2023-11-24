using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PurchaseManagement
/// </summary>
/// 
namespace AQUA
{
    public class PurchaseManagement : AQUAObject
    {
        public PurchaseManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool PurchaseInsertUpdate(Purchase PR, string strInsertUpdate)
        {
            bool b = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", strInsertUpdate));
                parameters.Add(new SqlParameter("SaudaNumberCode", PR.saudaNumberCode));
                parameters.Add(new SqlParameter("PurchaseDate", PR.purchaseDate));
                parameters.Add(new SqlParameter("PurchaseType", PR.purchaseType));
                parameters.Add(new SqlParameter("SupplierName", PR.supplierName));
                parameters.Add(new SqlParameter("FarmerName", PR.farmerName));
                parameters.Add(new SqlParameter("PondNumber", PR.pondNumber));
                parameters.Add(new SqlParameter("Village", PR.villageName));
                parameters.Add(new SqlParameter("Mandal", PR.mandalName));
                parameters.Add(new SqlParameter("District", PR.district));
                parameters.Add(new SqlParameter("BatchNumber", PR.batchNumber));
                parameters.Add(new SqlParameter("HarvestStartTime", PR.harvestStartDate));
                parameters.Add(new SqlParameter("HarvestEndTime", PR.harvestEndDate));
                parameters.Add(new SqlParameter("LotNumber", PR.lotNumber));

                parameters.Add(new SqlParameter("Remarks", PR.remarks));
                parameters.Add(new SqlParameter("SupervisedBy", PR.supervisedBy));
                parameters.Add(new SqlParameter("ApprovedBy", PR.approvedBy));
                parameters.Add(new SqlParameter("CreatedDate", PR.createdDate));
                parameters.Add(new SqlParameter("CreatedBy", PR.createdBy));
                parameters.Add(new SqlParameter("Status", PR.status));

                parameters.Add(new SqlParameter("SampleWeight", PR.sampleWeight));
                parameters.Add(new SqlParameter("No_of_Normal_Pieces", PR.noofNormalPieces));
                parameters.Add(new SqlParameter("No_of_small_pieces", PR.noofSmallPieces));
                parameters.Add(new SqlParameter("No_of_small_Accounted_One", PR.noofsmallAccountedOne));
                parameters.Add(new SqlParameter("Total_Number_of_Pieces", PR.totalNumberofPieces));
                parameters.Add(new SqlParameter("WeightDeduction", PR.weightDeduction));
                parameters.Add(new SqlParameter("CountAdjustment", PR.countAdjustment));
                parameters.Add(new SqlParameter("PurchaseCountPerKG", PR.purchaseCountPerKG));


                parameters.Add(new SqlParameter("No_Of_Nets", PR.noOfNets));
                parameters.Add(new SqlParameter("Tare_Weight_Per_Net", PR.tareWeightPerNet));
                parameters.Add(new SqlParameter("GrossWeight", PR.grossWeight));
                parameters.Add(new SqlParameter("TotalWeight", PR.totalWeight));


                parameters.Add(new SqlParameter("NO_SoftPieces", PR.noOfSoftPieces));
                parameters.Add(new SqlParameter("SoftPercentage", PR.softPer));
                parameters.Add(new SqlParameter("No_PiecesWithBlackSpot", PR.blackSpot));
                parameters.Add(new SqlParameter("PercentageOfBlackSpot", PR.blackPer));
                parameters.Add(new SqlParameter("No_PiecesNecrosis", PR.necrosis));
                parameters.Add(new SqlParameter("NecrosisPercentage", PR.necrosisPer));
                parameters.Add(new SqlParameter("Discoloration", PR.discolouration));
                parameters.Add(new SqlParameter("DiscolorationPercentage", PR.discolourationPer));
                parameters.Add(new SqlParameter("ColorOfShrimp", PR.colorofShirmp));
                parameters.Add(new SqlParameter("GILLS", PR.gills));
                parameters.Add(new SqlParameter("Texture", PR.freshness));
                parameters.Add(new SqlParameter("MuddySmell", PR.muddy));
                parameters.Add(new SqlParameter("RMTemp", PR.rmTemp));
                parameters.Add(new SqlParameter("CleanlinessOfVehicle", PR.cleannessOfVechicle));
                parameters.Add(new SqlParameter("CleanlinessOfBoxes", PR.cleannessOfBoxes));
                parameters.Add(new SqlParameter("IceCondition", PR.ice));
                parameters.Add(new SqlParameter("NO_BrokenPieces", PR.brokenPieces));
                parameters.Add(new SqlParameter("BrokenPercentage", PR.brokenPer));



                b = base.ODataServer.ExecuteSP(parameters, "SP_PurchaseInsert", SPCommand.Insert);
            }
            catch (Exception ex)
            {
                ex.ToString();
                b = false;
            }
            return b;
        }


        public DataSet SupplierDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string strqry = "select SupplierID, SupplierName from [dbo].[SupplierMaster]";
                ds = base.ODataServer.GetDataset(strqry);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet VillageDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string strqry = "select ID, VillageName from [dbo].[Village]";
                ds = base.ODataServer.GetDataset(strqry);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet getTotalPieces(string sCode,string sLot)
        {
            DataSet ds = new DataSet();
            try
            {
                string strqry = "select Total_Number_of_pieces from[dbo].[RMPWeighmentNetSampling] where SaudaNumberCode = '"+ sCode + "' and LotNumber = '"+ sLot + "' ";
                ds = base.ODataServer.GetDataset(strqry);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        
        




        public DataSet MandalDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string strqry = "select ID, MandalName from [dbo].[Mandal]";
                ds = base.ODataServer.GetDataset(strqry);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet DistrictDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                string strqry = "	select Id,DistrictName from District  where status =1";
                ds = base.ODataServer.GetDataset(strqry);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }


        public DataTable GetWeightmentDetails(string strsupplierName, string strFarmerName)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("SupplierName", strsupplierName.Trim()));
                parameters.Add(new SqlParameter("FarmerName", strFarmerName.Trim()));
                dt = base.ODataServer.ExecuteSP(parameters, "GetWeightmentDetail");
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
        public DataTable GetWeightmentDetail(string strsupplierName, string strFarmerName)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("SupplierName", strsupplierName.Trim()));
                parameters.Add(new SqlParameter("FarmerName", strFarmerName.Trim()));
                dt = base.ODataServer.ExecuteSP(parameters, "GetWeightmentDetails");
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



        public DataTable GetPurchaseDetails(string strAction, string strStatus, string strSaudoNo,string strLotNo)
        {
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", strAction));
                parameters.Add(new SqlParameter("ProcessStatus", strStatus));
                parameters.Add(new SqlParameter("SaudaNumberCode", strSaudoNo));
                parameters.Add(new SqlParameter("LotNumber", strLotNo));

                dt = base.ODataServer.ExecuteSP(parameters, "[SP_PurchaseDetails]");
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


}