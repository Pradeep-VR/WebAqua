using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class PackingManagement : AQUAObject
    {
        public PackingManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetMachineNumber(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select MachineNo,grade from  ";
                s = s + " [dbo].[IQFFinalData] where barcodeid = '" + strBarcode + "' and freezingType='Block' ";
                return base.ODataServer.GetDataTable(s);
            }
            catch (Exception)
            {
                return null;
            }
        }

        

        public DataTable GetFrezzerNo(string strAction)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                if (strAction == "1")
                {
                    s = " select distinct MachineNo from [dbo].[IQFFinalData] where freezingType ='BLOCK' and status='Pending'";
                }
                else
                {
                    s = "select Grade+  ' & ' + ProductType as Grade from BFFinalDataFreezing where status='Pending'";
                }
              
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;

        }

        public DataTable GetGradeProductType(string strFreezerNo)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = "  select Grade +  ' & ' + ProductType as GradePT from [IQFFinalData] where freezingType = 'BLOCK' and status = 'Pending' and MachineNo = '"+ strFreezerNo + " '  ";
               
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }


        public DataTable GetblockDetails(string strFreezerNo,string strGrade,string strProdType)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = "select * from [IQFFinalData] where FreezingType='BLOCK' and  status='Pending' and MachineNo='" + strFreezerNo + "' and Grade='"+ strGrade + "' and ProductType='"+ strProdType + "' ";

                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public bool InsertBlockOutFeed(string strFreezerNo,string strBatchNumber)
        {
            bool b = false;
            string s = "";
            try
            {
                s = "update IQFFinalData set Status='Added' where MachineNo='" + strFreezerNo + "' and batch='"+ strBatchNumber + "' ";
                b = base.ODataServer.ExecuteNonQuery(s);
            }
            catch (Exception ex)
            {
                b = false;
            }

            return b;

        }

        public DataTable GetblockOutFeed(string strFreezerNo, string strBatchNo)
        {
            DataTable dt = new DataTable();
            string s ;
            try
            {
                s = "select * from [IQFFinalData] where status='Added' and MachineNo='" + strFreezerNo + "' and batch='"+ strBatchNo + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        
        public bool PackageInsertUpdate(PackSpecification PS, string strInsertUpdate)
        {
            bool b = false;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", strInsertUpdate));
                parameters.Add(new SqlParameter("buyerName", PS.BuyerName));
                parameters.Add(new SqlParameter("PONumber", PS.PONumber));
                parameters.Add(new SqlParameter("CargoNumber", PS.CargoNo));
                parameters.Add(new SqlParameter("Brand", PS.Brand));
                parameters.Add(new SqlParameter("PackingStyle", PS.PackingStyle));
                parameters.Add(new SqlParameter("PackingType", PS.PackingType));
                parameters.Add(new SqlParameter("Glaze", PS.Glaze));
                parameters.Add(new SqlParameter("Unit", PS.Unit));
                parameters.Add(new SqlParameter("Grade", PS.Grade));
                parameters.Add(new SqlParameter("glazespec", PS.GlazeSpec));
                parameters.Add(new SqlParameter("Variety", PS.Variety));
                parameters.Add(new SqlParameter("TargetCount", PS.TargetCount));
                parameters.Add(new SqlParameter("OrderQty", PS.OrderQty));
                parameters.Add(new SqlParameter("NoofSlabs", PS.NoofSlabs));
                parameters.Add(new SqlParameter("MatchedfromOpen", PS.MatchedfromOpen));
                parameters.Add(new SqlParameter("NoofSlabsYesterday", PS.NoofSlabsYesterday));
                parameters.Add(new SqlParameter("NoofSlabsToday", PS.NoofSlabsToday));
                parameters.Add(new SqlParameter("BalanceSlabs", PS.BalanceSlabs));
                parameters.Add(new SqlParameter("BalanceCartons", PS.BalanceCartons));
                parameters.Add(new SqlParameter("BalanceQty", PS.BalanceQty));
                parameters.Add(new SqlParameter("CartonPacked", PS.CartonPacked));
                parameters.Add(new SqlParameter("CartonRepack", PS.CartonRepack));
                parameters.Add(new SqlParameter("CartonBalRepack", PS.CartonBalRepack));
                parameters.Add(new SqlParameter("ChemicalTreatment", PS.ChemicalTreatment));
                parameters.Add(new SqlParameter("Remarks", PS.Remarks));
                parameters.Add(new SqlParameter("Packingstatus", PS.Packingstatus));
                parameters.Add(new SqlParameter("VerifiedBy", PS.VerifiedBy));
                parameters.Add(new SqlParameter("CreatedBy", PS.VerifiedBy));
                parameters.Add(new SqlParameter("PackID", PS.PackID));
                parameters.Add(new SqlParameter("RepackStatus", PS.RepackStatus));

                b = base.ODataServer.ExecuteSP(parameters, "SP_PackingSpecificationInsert", SPCommand.Insert);
            }
            catch (Exception ex)
            {
                ex.ToString();
                b = false;
            }
            return b;
        }


        public DataTable GetSoakingTankPrdTyp(string strBarcode) 
        {
            DataTable dty = new DataTable();
            string qry;
            try
            {
                qry = "select Distinct changeInProduct as ProductType from SoakingFinalData where soakingTankBarcodeId='" + strBarcode + "'";
                dty = base.ODataServer.GetDataTable(qry);
            }
            catch(Exception ex)
            {
                var rt = dty + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dty;
        }


        public DataTable GetIqfDtlsSCW(string strBarcode)
        {
            DataTable dts = new DataTable();
            string d;
            try
            {
                d = " select barcodeIdsOfCrate,batchNo as Batch,flatCountCheck as Quantity  from SoakingFinalData where barcodeIdsOfCrate='" + strBarcode + "' and soakingType='Separate Crate Wise'";
                dts = base.ODataServer.GetDataTable(d);

            }
            catch (Exception ex)
            {
                var rt = dts + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dts;
        }

        public DataTable GetIQFDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = " select BarcodeId, MachineNo, Operation, Grade, ProductType, Batch, CheckOfFlatCount,Quantity from  ";
                s = s + " [dbo].[IQFFinalData] where barcodeid = '" + strBarcode + "' and freezingType='IQF' ";

                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetSoakingTankGradeSCW(string strBarcode)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable rtdt = new DataTable();
            string stg ;
            try
            {
                stg = "select changeInGrade2 as soakingtankgrade from SoakingFinalData where barcodeIdsOfCrate='" + strBarcode + "'";
                dt = base.ODataServer.GetDataTable(stg);
                if (dt.ToString() == "" || dt.ToString() == null)
                {
                    string stg2 = "select changeInGrade as soakingtankgrade from SoakingFinalData where barcodeIdsOfCrate='" + strBarcode + "'";
                    dt1 = base.ODataServer.GetDataTable(stg2);
                    if (dt1.Rows.Count > 0)
                    {
                        rtdt = dt1;
                    }

                }
                else
                {
                    rtdt = dt;
                }

            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                var rt1 = rtdt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                rtt.Rows.Add(rt1);
                return rtt;
            }
            return rtdt;
        }

        public DataTable GetSoakingTankGrade(string strBarcode)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable rtdt = new DataTable();
            string stg = "";
            try
            {
                stg = "select changeInGrade2 as soakingtankgrade from SoakingFinalData where soakingTankBarcodeId='" + strBarcode + "'";
                dt = base.ODataServer.GetDataTable(stg);
                if(dt.ToString() == "" || dt.ToString()==null)
                {
                    string stg2 = "select changeInGrade as soakingtankgrade from SoakingFinalData where soakingTankBarcodeId='" + strBarcode + "'";
                    dt1 = base.ODataServer.GetDataTable(stg2);
                    if(dt1.Rows.Count > 0)
                    {
                        rtdt = dt1;
                    }
                    
                }
                else
                {
                    rtdt = dt;
                }
                
            }
            catch(Exception ex)
            {
               var rt = dt + ex.ToString();
                var rt1 = rtdt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                rtt.Rows.Add(rt1);
                return rtt;
            }
            return rtdt;
        }

        public DataTable GetBLOCKDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = " select BarcodeId, MachineNo, Operation, Grade, ProductType, Batch, CheckOfFlatCount,Quantity from  ";
                s = s + " [dbo].[IQFFinalData] where barcodeid = '" + strBarcode + "' and freezingType='BLOCK' ";

                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }



        public DataTable GetBlockDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = " select BarcodeId, MachineNo, Operation, Grade, ProductType, Batch, CheckOfFlatCount,Quantity,AntibioticStatus from  ";
                s = s + " [dbo].[IQFFinalData] where barcodeid = '" + strBarcode + "' and freezingType='Block' ";

                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetOutFeedDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select Glaze, AntibioticStatus from [dbo].[IQFOutFeed] where Barcode = '" + strBarcode + "' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }


        public DataTable GetBlockOutFeedDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select '' as Glaze, Antibotic from [dbo].[BlockFOutFeed] where Barcode = '" + strBarcode + "' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }






        public DataTable GetPONumber()
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = " select Distinct PoNumber  from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='IQF' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }


        public DataTable GetPONumberBlock()
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = " select Distinct PoNumber  from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='BF' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetPackingStyleBlock(string strCustomerOrderNo, string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct PackingStyle from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='BF' and Ponumber='" + strCustomerOrderNo + "' and Brand='" + strBrand + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetPackingStyle(string strCustomerOrderNo,string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct PackingStyle from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='IQF' and Ponumber='" + strCustomerOrderNo + "' and Brand='"+ strBrand + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetBrandBlock(string strCustomerOrderNo)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Brand from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='BF' and Ponumber='" + strCustomerOrderNo + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        
        public DataTable GetBrand(string strCustomerOrderNo)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Brand from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='IQF' and Ponumber='" + strCustomerOrderNo + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }
        
        public DataTable GetGrade(string strCustomerOrderNo, string strPackingStyle,string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Grade from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='IQF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "' and Brand='"+ strBrand + "'   ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }


        public DataTable GetGradeBlock(string strCustomerOrderNo, string strPackingStyle, string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Grade from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='BF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "' and Brand='" + strBrand + "'   ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                //string err = ex.ToString();
                //return dt;
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetVarietyBlock(string strCustomerOrderNo, string strPackingStyle, string strGrade, string Brand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Variety,Glaze from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='BF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "'  and Grade='" + strGrade + "' and Brand ='" + Brand + "'   ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetVariety(string strCustomerOrderNo, string strPackingStyle, string strGrade,string Brand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {

                s = "select distinct Variety,Glaze from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType='IQF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "'  and Grade='" + strGrade + "' and Brand ='"+ Brand + "'   ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }
        public DataTable GetPONumberDetails(string strPONumber, string strGrade, string strVariety, string strPackingStyle,string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select PONumber,Noofslabs,Noofslabs,Matchedfromopen, BalanceSlabs, BalanceCartons, BalanceQty,PackingStyle, Brand ,cartonPacked,CartonRepack,CartonBalRepack from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType = 'IQF' and PONumber ='" + strPONumber + "' and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "' and Brand='"+strBrand+"' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetIp(string printername)
        {
            DataTable dt = new DataTable();
            string ip = "";
            try
            {
                ip = " select IP_ADDRESS,PRINTER_PORT_NO from PRINTER_MASTER WHERE PRINTER_NAME='"+ printername +"' AND ACTIVE_STATUS=1 ";
                dt = base.ODataServer.GetDataTable(ip);
            }
            catch(Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;
        }

       

        public DataTable GetPONumberDetailsBlock(string strPONumber, string strGrade, string strVariety, string strPackingStyle, string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select PONumber,Noofslabs,Noofslabs,Matchedfromopen, BalanceSlabs, BalanceCartons, BalanceQty,PackingStyle, Brand ,cartonPacked,CartonRepack,CartonBalRepack from [dbo].[PackingSpecification]  where RepackStatus = 'OPEN' and PackingType = 'BF' and PONumber ='" + strPONumber + "' and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "' and Brand='" + strBrand + "' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }



        //public bool UpdatePackingSpec(string PoNumber,String Gr)
        //{
        //}

            
        public bool InsertPackingBarcodePrint(string SBarcode, string strProdCode, string strExportCode, string strSlabCotton, string strLooseCot, string strSlabPacking, string strStorageType, string strPackBarcode, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string strActPacStyle , string strBatchNumber, string strUName,string strBrand,string strFType,string strWeightUnit)
        {
            bool b;
            string s = "";
            try
            {


                s = "INSERT INTO [dbo].[IQFBarcodePrinting] ([SoakingBarcode],[SlabPacking],[POnumber],[Grade],[Variety],[StorageType] " +
                 " ,[ProductionCode] ,[ExportCode],[NoofSlabCotton],[LooseCotton],[BatchNumber],[CreatedBy],[CreatedDate],[Status],[PackBarcode],[LabelStatus],[PackingStyle],[Brand],[FreezingType],[Actpackingstyle],[WeightUnits]) " +
                 "VALUES ('" + SBarcode + "', '" + strSlabPacking + "' ,'" + strPONumber + "' ,'" + strGrade + "', '" + strVariety + "' " +
                 " , '" + strStorageType + "' ,'" + strProdCode + "' ,'" + strExportCode + "' , '" + strSlabCotton + "' ,'" + strLooseCot + "' " +
                 ",  '" + strBatchNumber + "','" + strUName + "' ,getdate(),1,'" + strPackBarcode + "','Label Print','" + strPackingStyle + "','" + strBrand + "','" + strFType + "','" + strActPacStyle + "' , '" + strWeightUnit + "') ";
                b = base.ODataServer.ExecuteNonQuery(s);

            }
            catch (Exception ex)
            {
                b = false;
            }
            return b;
        }

        

        public bool insertPalletId(string username, string palletId, string palletType, int noOfLbl)
        {
            bool s;
            string query = "";
            try
            {
                query = "INSERT INTO Pallet_Master (UserName, pallet_id, pallet_type, no_of_labels,created_date,updated_date)  VALUES " +
                                   "('" + username + "', '" + palletId + "', '" + palletType + "', " + noOfLbl + ",getdate(),getdate())";
                s = base.ODataServer.ExecuteNonQuery(query) ;
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                s = false ;
            }
            return s;
        }

        public bool updatePalletId(string username, string palletId, string palletType, int noOfLbl)
        {
            bool s;
            string query = "";
            string cs = ConfigurationManager.ConnectionStrings["DBCONNECTION"].ConnectionString;
            SqlConnection scon = new SqlConnection(cs);
            SqlDataReader rd ;
            DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                query = "select no_of_labels from Pallet_Master where pallet_id='" + palletId + "'";
                SqlCommand cmd = new SqlCommand(query, scon);
                scon.Open();
                rd = cmd.ExecuteReader();
                dt.Load(rd);
                if(dt.Rows.Count > 0)
                {

                }
                else
                {

                }

                query = "update Pallet_Master set updated_date = GETDATE(), no_of_labels=" + noOfLbl + "  where pallet_id='" + palletId + "' and Pallet_Type='" + palletType + "'";
                s = base.ODataServer.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                s = false;
            }
            return s;
        }


        public bool InsertPackingBarcodePrintopen(string SBarcode, string strProdCode, string strExportCode, string strSlabCotton, string strLooseCot, string strSlabPacking, string strStorageType, string strPackBarcode, string strPackingStyle,string strActPackStyl , string strBatchNumber, string strUName, string SG, string sV,string strFType,string strWghtUnit)
        {
            bool b;
            string s = "";
            try
            {
                s = "INSERT INTO [dbo].[IQFBarcodePrinting] ([SoakingBarcode],[SlabPacking],[StorageType],[Grade],[Variety] "
                 + " ,[ProductionCode] ,[ExportCode],[NoofSlabCotton],[LooseCotton],[BatchNumber],[CreatedBy],[CreatedDate],[Status],[PackBarcode],[LabelStatus],[PackingStyle],[brand],[FreezingType],[Actpackingstyle],[WeightUnits]) "
                 + "VALUES ('" + SBarcode + "', '" + strSlabPacking + "'  "
                 + " , '" + strStorageType + "' ,'" + SG + "','" + sV + "', '" + strProdCode + "' ,'" + strExportCode + "' , '" + strSlabCotton + "' ,'" + strLooseCot + "' "
                 + ",  '" + strBatchNumber + "','" + strUName + "' ,getdate(),1,'" + strPackBarcode + "','Label Print','" + strPackingStyle + "','','" + strFType + "','" + strActPackStyl + "' , '" + strWghtUnit + "') ";
                b = base.ODataServer.ExecuteNonQuery(s);

            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }
        public bool UpdateBalance(string strBalSlab, string strBalCarton, string strBalQty, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string status, string strYesSlab, string strTodaySlab,string cartonSlab,string cartonRepack , string cartonBalRepack,string strBrand)
        {
            bool b;
            string s = "";
            try
            {
                s = " Update  PackingSpecification set BalanceSlabs='" + strBalSlab + "' ,PackingStatus = '" + status + "',  "
                 + " BalanceCartons ='" + strBalCarton + "' ,BalanceQty ='" + strBalQty + "' , "
                 + " NoofSlabsYesterday ='" + strYesSlab + "',NoofSlabsToday='" + strTodaySlab + "'  , "
                 + " CartonPacked='"+ cartonSlab + "', CartonRepack='"+ cartonRepack + "' , CartonBalRepack='"+ cartonBalRepack + "' "
                 + "  where PackingStatus = 'OPEN' and PackingType = 'IQF' and PONumber ='" + strPONumber + "' "
                 + " and Grade='" + strGrade + "' and variety ='" + strVariety + "' and PackingStyle ='" + strPackingStyle + "', and Brand ='"+strBrand+"' ";
                b = base.ODataServer.ExecuteNonQuery(s);// = base.ODataServer.GetDataTable(s);
            }
            catch (Exception )
            {
                b = false;
            }
            return b;
        }


        public string getpalletid(string palletid)
        {
            DataTable dts = new DataTable();
            string qryy = "";
            string vlu = "";
            try
            {
                qryy = "select * from Pallet_Master where pallet_id='" + palletid + "' ";
                dts = base.ODataServer.GetDataTable(qryy);
                if(dts.Rows.Count > 0)
                {
                    vlu  = dts.Rows[0]["Pallet_Type"].ToString();
                }
            }
            catch(Exception ex)
            {
                vlu = "Pallet Id Not In Database..." + ex.ToString();
            }
            return vlu;
        }


        public string YesterdayTodayCount(string strSoakBCode, string strPONumber, string strGrade, string strVariety, string strPackingStyle, string status, string s1,string strBrand)
        {
            bool b;
            string s = "";
            DataTable dt = new DataTable();
            int noofslab = 0;
            int noofloose = 0;
            string Yescount = "";
            try
            {
                s = " select SUM(CAST(Noofslabcotton as int)) as SCount,SUM(CAST(LooseCotton as int)) as LCount "
                + "  from [dbo].[IQFBarcodePrinting] where soakingBarcode='" + strSoakBCode + "' and "
                + " PONumber ='" + strPONumber + "' and Grade = '" + strGrade + "' and  "
                + "  variety = '" + strVariety + "' and PackingStyle = '" + strPackingStyle + "' and Brand='"+strBrand+"' and LabelStatus='Scanned' ";
                if (s1 == "yes")
                {
                    s = s + " and convert(nvarchar(max), UpdatedDate, 112)   <= convert(nvarchar(max), GETDATE(), 112) -1  ";
                }
                if (s1 == "today")
                {
                    s = s + " and convert(nvarchar(max), UpdatedDate, 112)  = convert(nvarchar(max), GETDATE(), 112)   ";
                }
                //b = base.ODataServer.ExecuteNonQuery(s);// = base.ODataServer.GetDataTable(s);
                dt = base.ODataServer.GetDataTable(s);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SCount"].ToString() == "")
                    { noofslab = 0; }
                    else
                    { noofslab = Convert.ToInt32(dt.Rows[0]["SCount"].ToString()); }

                    if (dt.Rows[0]["LCount"].ToString() == "")
                    { noofloose = 0; }
                    else
                    { noofloose = Convert.ToInt32(dt.Rows[0]["LCount"].ToString()); }

                    Yescount = (noofloose + noofslab).ToString();
                }
            }
            catch (Exception ex)
            {
                Yescount = "" + ex.ToString();
                
            }
            return Yescount;
        }

        
        public bool UpdateQty(string strQty, string status)
        {
            bool b;
            string s = "";
            try
            {
                s = " update IQFFinalData set Quantity = '" + strQty + "' where barcodeId = '" + status + "' ";
                b = base.ODataServer.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }


        public bool UpdateScan(string barcodeid)
        {
            bool b;
            string s = "";
            try
            {
                s = " update IQFBarcodePrinting set LabelStatus = 'Scanned',UpdatedDate=getdate() where PackBarcode = '" + barcodeid + "'  ";
                b = base.ODataServer.ExecuteNonQuery(s);
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }

        public string GetlastPalletid(string strPalletType)
        {
            DataTable dtd = new DataTable();
            string sss = "";
            try
            {
                string sqry = "select max(Pallet_Id) as pallet_id from Pallet_Master where  Pallet_Type = '" + strPalletType + "' ";
                dtd = base.ODataServer.GetDataTable(sqry);
                if (dtd.Rows.Count > 0)
                {
                    if(dtd.Rows[0]["pallet_Id"].ToString().Length != 0)
                    {
                        sss = dtd.Rows[0]["pallet_Id"].ToString();
                        if(strPalletType == "Dummy")
                        {                            
                            string lastThreeDigits = sss.Substring(sss.Length - 3);
                            int lastThreeDigitsAsInt = int.Parse(lastThreeDigits) + 1;
                            string newDigits = lastThreeDigitsAsInt.ToString("D3"); 
                            sss = sss.Substring(0, sss.Length - 3) + newDigits;
                        }
                        else
                        {
                            sss = (Convert.ToInt32(sss) + 1).ToString();
                        }
                    }
                    else
                    {
                        if (strPalletType == "Dummy")
                        {
                            sss = "Dummy100001";
                        }
                        else
                        {
                            sss = "100001";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                sss = "" + ex.ToString();
            }
            return sss;
        }

        public string Barcode(string strStorageType)
        {
            DataTable dt = new DataTable();
            string s1 = "";
            try
            {
                string s = " select max(PackBarcode) as Barcode from [dbo].[IQFBarcodePrinting] where  StorageType = '" + strStorageType + "' ";
                dt = base.ODataServer.GetDataTable(s);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Barcode"].ToString().Length != 0)
                    {
                        s1 = dt.Rows[0]["Barcode"].ToString();
                        if (strStorageType == "Dummy")
                        {
                            string ss = s1.Substring(5, 6);
                            s1 = (Convert.ToInt32(ss) + 1).ToString();
                            s1 = "Dummy" + s1;
                        }
                        else
                        {
                            s1 = (Convert.ToInt32(s1) + 1).ToString();
                        }
                    }
                    else
                    {
                        if (strStorageType == "Dummy")
                        {
                            s1 = "Dummy100001";
                        }
                        else
                        {
                            s1 = "100001";
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                s1 = "" + ex.ToString();
            }
            return s1;

        }
        public DataTable GetPackingSpecificationPO(string strAction, string strPNumber)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Action", strAction.Trim()));
                parameters.Add(new SqlParameter("PoNumber", strPNumber.Trim()));
                dt = base.ODataServer.ExecuteSP(parameters, "SP_GetPackingSpecificationPO");

            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }
        
        public DataTable GetPackingSpecification()
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                dt = base.ODataServer.ExecuteSP(parameters, "SP_GetPackingSpecification");

            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;
        }
        
        public DataTable getDetails(string strBarcode)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = " select *  from [dbo].[IQFBarcodePrinting]  where  PackBarcode ='" + strBarcode + "' and LabelStatus='Label Print' ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }
        
        public string getDetailsFresh(string strSoakBCode, string strPONumber, string strGrade, string strVariety, string strPackingStyle,string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            string strFreshSlab = "";
            try
            {
                s = " select sum(CAST(NoofSlabCotton as int))  FreshSlab  from[dbo].[IQFBarcodePrinting] "; 
                s= s+ " where SlabPacking = 'Matched' and StorageType = 'Final' and LabelStatus = 'Scanned'  and soakingBarcode='" + strSoakBCode + "' and ";
                s = s + " PONumber ='" + strPONumber + "' and Grade = '" + strGrade + "' and  ";
                s = s + "  variety = '" + strVariety + "' and PackingStyle = '" + strPackingStyle + "' and Brand='"+ strBrand + "' ";
                dt = base.ODataServer.GetDataTable(s);
                if(dt.Rows.Count >0)
                {
                    strFreshSlab = dt.Rows[0]["FreshSlab"].ToString();
                    if (strFreshSlab == "")
                    {
                        strFreshSlab = "0";
                    }
                        
                }
            }
            catch (Exception ex)
            {
                strFreshSlab = "0" + ex.ToString();
            }
            return strFreshSlab;
        }

        //public DataTable getPackingSpecDetails(string PoNumber,string PackingStyle)
        //{
        //    DataTable dt = new DataTable();
        //    string s = "";
        //    try
        //    {
        //        s = " select *  from [dbo].[PackingSpecification]  where  PackBarcode ='" + strBarcode + "' ";

        //        select* from PackingSpecification where PONumber = '' and PackingStyle = '' and PackingType = 'IQF' and PackingStatus = 'Open'
        //        dt = base.ODataServer.GetDataTable(s);
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = null;
        //    }
        //    return dt;

        //}
        
        public DataTable getPackingDetails(string strBarcode, string PONumber, string strGrade, string strVariety, string strPS, string action,string strBrand)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                if (action == "1")
                {
                    s = "select count(*) as CartonCount from IQFBarcodePrinting where SoakingBarcode = '" + strBarcode + "' and  Grade ='" + strGrade + "' and Variety='" + strVariety + "' and PackingStyle='" + strPS + "' and Brand='" + strBrand + "' and  LabelStatus = 'Scanned' and LooseCotton = '0'";
                }                    
                else if (action == "2")
                {
                    s = "select count(*) as LooseCartonCount from IQFBarcodePrinting where SoakingBarcode = '" + strBarcode + "' and  Grade ='" + strGrade + "' and Variety='" + strVariety + "' and PackingStyle='" + strPS + "' and Brand='" + strBrand + "'  and LabelStatus = 'Scanned' and LooseCotton != '0' ";
                }
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;

        }

        public DataTable GetGlaxeSpec(string strCustomerOrderNo, string strPackingStyle, string strGrade, string Brand, string variety)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = "select distinct glazespec from [dbo].[PackingSpecification]  where PackingStatus = 'OPEN' and PackingType='IQF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "'  and Grade='" + strGrade + "' and Brand ='" + Brand + "' and variety='" + variety + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;
        }


        public DataTable GetGlaxeSpec_BF(string strCustomerOrderNo, string strPackingStyle, string strGrade, string Brand, string variety)
        {
            DataTable dt = new DataTable();
            string s = "";
            try
            {
                s = "select distinct glazespec from [dbo].[PackingSpecification]  where PackingStatus = 'OPEN' and PackingType='BF' and Ponumber='" + strCustomerOrderNo + "' and  PackingStyle ='" + strPackingStyle + "'  and Grade='" + strGrade + "' and Brand ='" + Brand + "' and variety='" + variety + "'  ";
                dt = base.ODataServer.GetDataTable(s);
            }
            catch (Exception ex)
            {
                var rt = dt + ex.ToString();
                DataTable rtt = new DataTable();
                rtt.Rows.Add(rt);
                return rtt;
            }
            return dt;
        }
        

    }
}