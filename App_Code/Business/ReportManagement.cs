using Org.BouncyCastle.Asn1.X509;
using System;
using System.Activities.Expressions;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;


namespace AQUA
{
    public class ReportManagement : AQUAObject
    {
        public ReportManagement()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public DataTable GetVarietyRpt()
        //{
        //    DataTable dtg = new DataTable();
        //    try
        //    {
        //        string Query = "select TextField,ValueField from general where TableName='VarietyRpt' and Flag=1";
        //        dtg = base.ODataServer.GetDataTable(Query);
        //    }
        //    catch(Exception ex)
        //    {
        //        StringBuilder err = new StringBuilder();
        //        err.Append(" Message : " + ex.Message);
        //        err.AppendLine(" STACK TRACE : " + ex.StackTrace);
        //        err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
        //        err.AppendLine(" SOURCE : " + ex.Source);
        //        Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
        //        dtg = null;
        //    }
        //    return dtg;
        //}

        public DataTable BindBatchNoGrade(string strFromDate, string strTodate, string strPlantNAme, string strPurchaseType)
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "SELECT DISTINCT batchnumber FROM BeheadingFinalData bfd WHERE bfd.batchnumber IN ( " +
                 " SELECT gp.batchNumber  FROM GradingProcess gp  WHERE  convert(varchar,gp.gradingDateTime,23)  BETWEEN '" + strFromDate + "' AND '" + strTodate + "' " +
                 " and bfd.Purchasetype = '" + strPurchaseType + "') ";
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

        public DataTable BindBatchNumber(string strFromDate, string strTodate, string strPlantNAme, string strPurchaseType)
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "SELECT DISTINCT batchnumber FROM BeheadingFinalData bfd WHERE bfd.batchnumber IN ( " +
                 " SELECT gp.batchNumber  FROM GradingProcess gp  WHERE  convert(varchar,gp.gradingDateTime,23)  BETWEEN '" + strFromDate + "' AND '" + strTodate + "' " +
                 " and bfd.Purchasetype in (" + strPurchaseType + ")) ";
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

        public DataTable getBSvalue(string strbatchno)
        {
            DataTable dt = new DataTable();
            try
            {
                string strtt = "select distinct bsRatio from BeheadingFinalData where batchNumber='" + strbatchno + "'";
                dt = base.ODataServer.GetDataTable(strtt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }

        public DataTable QualityDeatails(string strbatchno)
        {
            DataTable dt = new DataTable();
            try
            {
                string strqrry = "select batchLotWise,SoftPercentage,PercentageOfBlackSpot,NecrosisPercentage,DiscolorationPercentage,ColorOfShrimp,BrokenPercentage from UnloadRMQuality " +
                                 "where batchLotWise like '%" + strbatchno + "%' and batchLotWise like '%w1%'";
                dt = base.ODataServer.GetDataTable(strqrry);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }

        public DataTable BRGetBatchnoPP(string frmdate,string todate,string strpurtype,string saudono)
        {
            DataTable dtsd = new DataTable();
            try
            {
                string qry = "select distinct  UFP.batchNo as BatchNo , PUC.SaudaNumberCode  from Purchase PUC join UnloadFinalProcess UFP on UFP.saudaNumber = PUC.SaudaNumberCode  join  BeheadingFinalData BFD on " +
                    "BFD.batchNumber = UFP.batchNo  where convert(varchar,PUC.PurchaseDate,23) between '" + frmdate + "' and '" + todate + "' and PUC.PurchaseType='" + strpurtype + "'  and PUC.SaudaNumberCode='" + saudono + "' Group BY UFP.batchNo,PUC.SaudaNumberCode";
                dtsd = base.ODataServer.GetDataTable(qry);
            }
            catch(Exception ex) 
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtsd;
            }
            return dtsd;
        }

        public DataTable BRGetSaudoNo(string frmyear, string toyear, string strpurtyp)
        {
            DataTable dty = new DataTable();
            string srtq = "";
            try
            {
                if(toyear == "")
                {
                    srtq = "select distinct PUC.SaudaNumberCode as SadoNo from Purchase PUC join UnloadFinalProcess UFP on UFP.saudaNumber = PUC.SaudaNumberCode  join  BeheadingFinalData BFD on " +
                    "BFD.batchNumber = UFP.batchNo  where " + frmyear + " and PUC.PurchaseType='" + strpurtyp + "' Group BY PUC.SaudaNumberCode";
                }
                else
                {
                    srtq = "select distinct PUC.SaudaNumberCode as SadoNo from Purchase PUC join UnloadFinalProcess UFP on UFP.saudaNumber = PUC.SaudaNumberCode  join  BeheadingFinalData BFD on " +
                    "BFD.batchNumber = UFP.batchNo  where convert(varchar,PUC.PurchaseDate,23) between '" + frmyear + "' and '" + toyear + "' and PUC.PurchaseType='" + strpurtyp + "' Group BY PUC.SaudaNumberCode";
                }
                
                dty = base.ODataServer.GetDataTable(srtq);
            }
            catch(Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dty;
            }
            return dty;
        }

        public DataTable BRgetmnthCnt(string strmnth)
        {
            DataTable dty = new DataTable();
            try
            {
                string qry = "select Distinct ValueField from general where TableName='MonthMaster' and TextField='" + strmnth + "' and Flag=1";
                dty = base.ODataServer.GetDataTable(qry);
            }
            catch(Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dty;
            }
            return dty;
        }


        public DataTable BRGetBatchNoMntwise(string stryearstt, string strpurtyp)
        {
            DataTable dt = new DataTable();
            string strqry = "";
            try
            {
                strqry = "SELECT DISTINCT UFP.batchNo AS BatchNo FROM Purchase PUC JOIN UnloadFinalProcess UFP ON UFP.saudaNumber = PUC.SaudaNumberCode JOIN " +
                    "BeheadingFinalData BFD ON BFD.batchNumber = UFP.batchNo WHERE PUC.PurchaseType = '" + strpurtyp + "' AND  " + stryearstt + "  GROUP BY UFP.batchNo";

                dt = base.ODataServer.GetDataTable(strqry);
            }
            catch (Exception ex)
            {

                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }


        public DataTable BRGetBatchNo(string frmyear, string toyear, string strpurtyp)
        {
            DataTable dt = new DataTable();
            string strqry = "";
            try
            {
                strqry = "select distinct UFP.batchNo as BatchNo from Purchase PUC join UnloadFinalProcess UFP on UFP.saudaNumber = PUC.SaudaNumberCode " +
                    " join  BeheadingFinalData BFD on BFD.batchNumber = UFP.batchNo  where convert(varchar,PUC.PurchaseDate,23) between '" + frmyear + "' and '" + toyear + "' and" +
                    " PUC.PurchaseType='" + strpurtyp + "' Group BY UFP.batchNo";
                dt = base.ODataServer.GetDataTable(strqry);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }

        public DataTable BRgetHonqty(string batchno)
        {
            DataTable dtsd = new DataTable();
            string sqry = "";
            try
            {
                sqry = "select sum(convert(float,TotalWeight)) Headonqty from UnloadWashingWeighnment where BatchNo='" + batchno + "'";
                dtsd = base.ODataServer.GetDataTable(sqry);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtsd;
            }
            return dtsd;
        }

        public DataTable BRGetCntDtls(decimal cnt)
        {
            DataTable dts = new DataTable();
            string str = "";
            try
            {
                str = "Select distinct COUNT,RANGE,BetweenRange,ADV,TARGETYIELD,SIZE FROM CountRangeMaster WITH(NOLOCK) WHERE COUNT=" + cnt + "";
                dts = base.ODataServer.GetDataTable(str);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dts;
            }
            return dts;
        }

        public DataTable BRGetPlntCnt(string strbatchno,string strsts,string w)
        {
            DataTable dtsd = new DataTable();
            string srt = "";
            try
            {
                if(strsts == "Pond Purchase" && w == "")
                {
                    //srt = "select distinct Wm.SaudaNumberCode,Ufp.batchNo,sum(convert(float,Wm.TotalWeight))as pndPlantWt from Purchase Pc join UnloadFinalProcess Ufp on Ufp.saudaNumber = Pc.SaudaNumberCode " +
                    //    "join Weighment Wm on Wm.SaudaNumberCode = Ufp.saudaNumber where Ufp.batchNo='" + strbatchno + "' group by Wm.SaudaNumberCode,Ufp.batchNo,Wm.TotalWeight";
                    srt = "select distinct Wm.SaudaNumberCode,Ufp.batchNo,Wm.TotalWeight as pndPlantWt  , Wm.LotNumber from Purchase Pc join UnloadFinalProcess Ufp on Ufp.saudaNumber = Pc.SaudaNumberCode " +
                        "join Weighment Wm on Wm.SaudaNumberCode = Ufp.saudaNumber where Ufp.batchNo='" + strbatchno + "' group by Wm.SaudaNumberCode,Ufp.batchNo,Wm.TotalWeight,Wm.LotNumber order by Wm.LotNumber asc";

                }
                else if (strsts == "Factory Purchase" && w !="" )
                {
                    //srt = "select distinct Ufp.batchNo,sum(convert(float,Uns.TotalWeight))as fctPlantWt,Uns.LotWiseBatch from Purchase Pc join UnloadFinalProcess Ufp on Ufp.saudaNumber = Pc.SaudaNumberCode " +
                    //    "join UnloadNetSampling Uns on Uns.LotWiseBatch = Ufp.BatchWiseLotNo where Ufp.batchNo='" + strbatchno + "' and Uns.LotWiseBatch like '%" + w + "%' group by Ufp.batchNo,Uns.LotWiseBatch";
                    srt = "select distinct Ufp.batchNo,Uns.TotalWeight as fctPlantWt,Uns.LotWiseBatch from Purchase Pc join UnloadFinalProcess Ufp on Ufp.saudaNumber = Pc.SaudaNumberCode " +
                        "join UnloadNetSampling Uns on Uns.LotWiseBatch = Ufp.BatchWiseLotNo where Ufp.batchNo='" + strbatchno + "' and Uns.LotWiseBatch like '%" + w + "%' group by Ufp.batchNo,Uns.TotalWeight,Uns.LotWiseBatch";

                }
                else if ( strsts == "Pond Purchase" && w !="" )
                {
                    srt = "select distinct Ufp.batchNo,Uns.TotalWeight as fctPlantWt,Uns.LotWiseBatch from Purchase Pc join UnloadFinalProcess Ufp on Ufp.saudaNumber = Pc.SaudaNumberCode " +
                        "join UnloadNetSampling Uns on Uns.LotWiseBatch = Ufp.BatchWiseLotNo where Ufp.batchNo='" + strbatchno + "' and Uns.LotWiseBatch like '%" + w + "%' group by Ufp.batchNo,Uns.LotWiseBatch,Uns.TotalWeight";
                    
                }
                dtsd = base.ODataServer.GetDataTable(srt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtsd;
            }
            return dtsd;
        }

        public DataTable BRGetCnt(string strbatchno, string strpurtype,string stats)
        {
            DataTable dtss = new DataTable();
            string strt = "";
            try
            {                
                if (strpurtype == "Factory Purchase")
                {
                    if (stats == "PC")
                    {
                        //strt = "Select distinct UNS.PlantCount as cnt, UFP.batchNo , UFP.purchaseType from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber " +
                        //"JOIN  UnloadNetSampling UNS on UNS.LotWiseBatch = UFP.BatchWiseLotNo where batchNo='" + strbatchno + "' group by UNS.PlantCount , UFP.batchNo , UFP.purchaseType";
                        strt = "Select distinct UNS.PlantCount as cnt, UFP.batchNo , UFP.purchaseType ,UNS.LotWiseBatch from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber JOIN  " +
                            "UnloadNetSampling UNS on UNS.LotWiseBatch = UFP.BatchWiseLotNo where UFP.batchNo='" + strbatchno + "' and UFP.purchaseType ='" + strpurtype + "' group by UNS.PlantCount " +
                            ", UFP.batchNo , UFP.purchaseType order by UNS.LotWiseBatch asc";
                    }
                    else
                    {
                        strt = "Select distinct UNS.PlantCount as cnt, UFP.batchNo , UFP.purchaseType ,UNS.LotWiseBatch from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber " +
                        "JOIN  UnloadNetSampling UNS on UNS.LotWiseBatch = UFP.BatchWiseLotNo where batchNo='" + strbatchno + "' group by UNS.PlantCount , UFP.batchNo , UFP.purchaseType,UNS.LotWiseBatch order by UNS.LotWiseBatch asc";
                    }
                    
                }
                else if (strpurtype == "Pond Purchase" )
                {
                    //strt = "Select distinct rmpwws.PurchaseCountPerKG as cnt, UFP.batchNo , Ps.purchaseType from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber join " +
                    //    "RMPWeighmentNetSampling rmpwws on rmpwws.SaudaNumberCode=Ps.SaudaNumberCode where batchNo='" + strbatchno + "' and Ps.purchaseType ='" + strpurtype + "' " +
                    //    "group by rmpwws.PurchaseCountPerKG , UFP.batchNo , Ps.purchaseType";
                    if(stats == "PC")
                    {
                        //strt = "Select distinct UNS.PlantCount as cnt, UFP.batchNo , UFP.purchaseType from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber " +
                        //"JOIN  UnloadNetSampling UNS on UNS.LotWiseBatch = UFP.BatchWiseLotNo where batchNo='" + strbatchno + "' group by UNS.PlantCount , UFP.batchNo , UFP.purchaseType";
                        strt = "Select distinct UNS.PlantCount as cnt, UFP.batchNo , UFP.purchaseType ,UNS.LotWiseBatch from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode = UFP.saudaNumber " +
                        "JOIN  UnloadNetSampling UNS on UNS.LotWiseBatch = UFP.BatchWiseLotNo where batchNo='" + strbatchno + "' group by UNS.PlantCount , UFP.batchNo , UFP.purchaseType,UNS.LotWiseBatch order by UNS.LotWiseBatch asc";
                    }
                    else
                    {
                        strt = "Select distinct rmpwws.PurchaseCountPerKG as cnt, UFP.batchNo , Ps.purchaseType , rmpwws.LotNumber from Purchase Ps join UnloadFinalProcess UFP on Ps.SaudaNumberCode " +
                            "= UFP.saudaNumber join RMPWeighmentNetSampling rmpwws on rmpwws.SaudaNumberCode=Ps.SaudaNumberCode where batchNo='" + strbatchno + "' and Ps.purchaseType ='" + strpurtype + "' " +
                            "group by rmpwws.PurchaseCountPerKG , UFP.batchNo , Ps.purchaseType,rmpwws.LotNumber order by rmpwws.LotNumber asc";
                    }
                    
                }
                 dtss = base.ODataServer.GetDataTable(strt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtss;
            }
            return dtss;
        }
        
        public DataTable BRGetGrader(string strbatchno)
        {
            DataTable dtq = new DataTable();
            try
            {
                string strqryy = "select distinct UFP.batchNo,Urmq.Grader from Purchase PUC join UnloadFinalProcess UFP on UFP.saudaNumber = PUC.SaudaNumberCode join BeheadingFinalData BFD " +
                    "on BFD.batchNumber = UFP.batchNo join UnloadRMQuality Urmq on Urmq.batchLotWise = UFP.BatchWiseLotNo where UFP.batchNo='" + strbatchno + "'  Group BY UFP.batchNo,Urmq.Grader";
                dtq = base.ODataServer.GetDataTable(strqryy);
            }
            catch
            {

            }
            return dtq;
        }


        public DataTable BRGetBtcDtls(string strBatchno , string stats)
        {
            DataTable dt = new DataTable();
            string strqryy = "";
            try
            {
                if(stats == "Factory Purchase")
                {
                    strqryy = "select distinct UFP.batchNo,PUC.PurchaseDate,PUC.PurchaseType,PUC.SupplierName,PUC.Mandal,PUC.Village,PUC.District from Purchase PUC join UnloadFinalProcess UFP " +
                    "on UFP.saudaNumber = PUC.SaudaNumberCode join BeheadingFinalData BFD on BFD.batchNumber = UFP.batchNo  where UFP.batchNo='" + strBatchno + "'  Group BY UFP.batchNo,PUC.PurchaseDate," +
                    "PUC.PurchaseType,PUC.SupplierName,PUC.Mandal,PUC.Village,PUC.District";
                }
                else
                {
                    strqryy = "select distinct UFP.batchNo,PUC.PurchaseDate,PUC.PurchaseType,PUC.SupplierName,PUC.Mandal,PUC.Village,PUC.District from Purchase PUC join UnloadFinalProcess UFP " +
                        "on UFP.saudaNumber = PUC.SaudaNumberCode join BeheadingFinalData BFD on BFD.batchNumber = UFP.batchNo where UFP.batchNo='" + strBatchno + "'  " +
                        "Group BY UFP.batchNo,PUC.PurchaseDate,PUC.PurchaseType,PUC.SupplierName,PUC.Mandal,PUC.Village,PUC.District ";
                }

                dt = base.ODataServer.GetDataTable(strqryy);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }

        public DataTable BRgetHLqty(string strBatchno)
        {
            DataTable dtss = new DataTable();
            try
            {
                string strqwe = "Select sum( convert(float, weighment)) as Headlesqty from GradingScanningProcess where batchNo='" + strBatchno + "'";
                dtss = base.ODataServer.GetDataTable(strqwe);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtss;
            }
            return dtss;
        }

        public DataTable SDGetHLQTY(string strbatchno, string strgrade, string strprdtype)
        {
            DataTable dtts = new DataTable();
            try
            {
                if (strgrade == "")
                {
                    string strqwe = "Select sum( convert(float, weighment)) as totHlQty from GradingScanningProcess where batchNo='" + strbatchno + "'";
                    dtts = base.ODataServer.GetDataTable(strqwe);
                }
                else if (strgrade != "")
                {
                    string strqwe = "Select sum( convert(float, weighment)) as grdwiseHlqty from GradingScanningProcess where batchNo='" + strbatchno + "' and grade='" + strgrade + "' and productType='" + strprdtype + "'";
                    dtts = base.ODataServer.GetDataTable(strqwe);
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
                return dtts;
            }
            return dtts;
        }

        public DataTable GetHeadOnWight(string strbatch)
        {
            DataTable dtg = new DataTable();
            string strrt = "";
            try
            {
                strrt = "select sum(cast(TotalWeight as float)) as HeadOnQty from UnloadWashingWeighnment where BatchNo='" + strbatch + "' ";
                dtg = base.ODataServer.GetDataTable(strrt);

            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dtg;
            }
            return dtg;
        }

        public DataTable SuplierDetails(string strFromDate, string strTodate, string strBatchNo, string strPurchaseType)
        {
            DataTable dt = new DataTable();
            try
            {
                string strqry = "SELECT GSP.batchNo,BFD.supplierName, BFD.headOnCountPerKg as Headoncnt, BFD.sampleBeheadingYieldPercentage as smplbeheadper FROM GradingScanningProcess" +
                            " GSP JOIN GradingProcess GP ON GSP.batchNo = GP.batchNumber JOIN BeheadingFinalData BFD ON BFD.batchNumber = GP.batchNumber WHERE" +
                            " CONVERT(VARCHAR, GP.gradingDateTime, 23) BETWEEN '" + strFromDate + "' AND '" + strTodate + "' AND BFD.Purchasetype = '" + strPurchaseType + "' AND GSP.batchNo = '" + strBatchNo + "'" + //--and BFD.batchNumber = 'STV752' and BFD.BatchLotNumber like '%W1%'"
                            "GROUP BY GSP.batchNo,BFD.supplierName,BFD.headOnCountPerKg,BFD.sampleBeheadingYieldPercentage";
                dt = base.ODataServer.GetDataTable(strqry);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                return dt;
            }
            return dt;
        }
        public DataTable BindGridView(string strFromDate, string strTodate, string strBatchNo, string strPurchaseType)
        {
            DataTable dtBind = new DataTable();
            string strQry = "";
            try
            {
                strQry = "SELECT GSP.batchNo, GSP.grade,Gsp.productType FROM GradingScanningProcess GSP " +
                       " JOIN GradingProcess GP ON GSP.batchNo = GP.batchNumber JOIN BeheadingFinalData BFD ON BFD.batchNumber = GP.batchNumber WHERE " +
                       " CONVERT(VARCHAR, GP.gradingDateTime, 23) BETWEEN '" + strFromDate + "' AND '" + strTodate + "' AND BFD.Purchasetype = '" + strPurchaseType + "' " +
                       " AND GSP.batchNo = '" + strBatchNo + "' GROUP BY GSP.batchNo, GSP.grade,GSP.productType";
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

        public DataTable BindPeelingTotPelledQty(string strBatchNo, string strGrade, string strprdtyp)
        {

            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "select SUM(cast(peeledMaterialWeighted as float))as pelled_qty from PeelingFinalData where batchNo='" + strBatchNo + "' and processstatus='filled' and grade='" + strGrade + "' and productType='" + strprdtyp + "'";
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
        public DataTable BindPellingTotHLQty(string strBatchNo, string strGrade, string strpdtype)
        {
            DataTable dtBind = new DataTable();
            try
            {
                string strQry = "SELECT SUM(CAST(weighment AS FLOAT)) AS HL_Quantity FROM GradingScanningProcess WHERE BatchNo = '" + strBatchNo + "' and grade='" + strGrade + "' and productType='" + strpdtype + "'  and status='pending' ";
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


        public DataTable BindGrade(string strBatchNo)
        {
            DataTable dtBind = new DataTable();
            string strQry = "";
            try
            {
                strQry = "select distinct grade from PeelingFinalData where batchNo='" + strBatchNo + "'";
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

        public DataTable GetBatcnoPFWR(string strfromdate, string strtodate, string strplant, string purchasetype)
        {
            DataTable dt = new DataTable();
            string strtt = "";
            try
            {
                strtt = "SELECT distinct PFD.batchNo FROM PeelingFinalData PFD JOIN BeheadingFinalData BFD ON BFD.batchNumber = PFD.batchNo WHERE " +
                " CONVERT(VARCHAR, PFD.dateAndTime, 23) BETWEEN '" + strfromdate + "' AND '" + strtodate + "' AND BFD.Purchasetype  in  (" + purchasetype + ") GROUP BY PFD.batchNo";
                dt = base.ODataServer.GetDataTable(strtt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dt = null;
            }
            return dt;
        }

        public DataTable GetgradePFWR(string strbatchno)
        {
            DataTable Gdt = new DataTable();
            string strtt = "";
            try
            {
                strtt = "select distinct grade from PeelingFinalData where batchNo='" + strbatchno + "' ";
                Gdt = base.ODataServer.GetDataTable(strtt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                Gdt = null;
            }
            return Gdt;
        }

        public DataTable GetHlqtyPFWR(string strbatchno, string strgrade, string strpdtype)
        {
            DataTable hldt = new DataTable();
            string strtt = "";
            try
            {
                //strtt = "select SUM(CAST(hlQtyAfterGrading as decimal)) as HL_Quantity from PeelingFinalData where batchNo='" + strbatchno + "' and grade = '" + strgrade + "' and productType='" + strpdtype + "' ";
                strtt = "select SUM(CAST(hlQtyAfterGrading as decimal)) as HL from PeelingFinalData where batchNo='" + strbatchno + "' and grade = '" + strgrade + "' and productType='" + strpdtype + "' ";
                hldt = base.ODataServer.GetDataTable(strtt);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                hldt = null;
            }
            return hldt;
        }

        public DataTable GetHOCpackingrpt(string strBatchno)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqry = "select headOnCountPerKg as Headoncnt from BeheadingFinalData where batchNumber='" + strBatchno + "'";
                dt = base.ODataServer.GetDataTable(sqry);
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dt = null;
            }
            return dt;
        }


        public DataTable getbatchpackingrpt(string strFBNo)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqry = "select Distinct BatchNumber from iqfbarcodeprinting where labelstatus='Scanned' and BatchNumber like '" + strFBNo + "%'";
                dt = base.ODataServer.GetDataTable(sqry);
            }
            catch(Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dt = null;
            }
            return dt;
        }

        public DataTable GetIQFBatchdlts(string strBatchno)
        {
            DataTable dts = new DataTable();
            try
            {
                string Qry = "SELECT DISTINCT BatchNumber,SlabPacking,POnumber,Grade,Variety,NoofSlabCotton,PackingStyle,Actpackingstyle,WeightUnits  " +
                    "FROM IQFBarcodePrinting WHERE BatchNumber='" + strBatchno + "' and LabelStatus='Scanned'";
                dts = base.ODataServer.GetDataTable(Qry);
            }
            catch(Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dts = null;
            }
            return dts;
        }

        public DataTable GetIQFscanedData(string strBatchno,string strLblSts,string strPrdType)
        {
            DataTable dts = new DataTable();
            try
            {
                string Qry = "SELECT DISTINCT BatchNumber,SoakingBarcode,SlabPacking,POnumber,Grade,Variety,NoofSlabCotton,FreezingType,Actpackingstyle,WeightUnits,LabelStatus FROM IQFBarcodePrinting " +
                    "WHERE BatchNumber='" + strBatchno + "' and Variety = '" + strPrdType + "'  and LabelStatus='" + strLblSts + "'";
                dts = base.ODataServer.GetDataTable(Qry);
            }
            catch(Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Utils.LogEntry.EXCEPTION);
                dts = null;
            }
            return dts;
        }
        

        public DataTable ChkSoakingFD(string strSoakingTankID)
        {
            DataTable dty = new DataTable();
            try
            {
                string Qry = "SELECT batchNo, chemicalStatus ,soakingTankBarcodeId,barcodeIdsOfCrate FROM SoakingFinalData WHERE soakingTankBarcodeId='" + strSoakingTankID + "' OR barcodeIdsOfCrate='" + strSoakingTankID + "'";
                dty = base.ODataServer.GetDataTable(Qry);
            }
            catch
            {

            }
            return dty;
        }


        

        public DataTable GetProdTypes(string strBatchNo,string strLblsts)
        {
            DataTable dt = new DataTable();
            string QRY = "SELECT DISTINCT IQFBP.Variety AS ProductType FROM IQFBarcodePrinting IQFBP join SoakingFinalData SKFD  ON SKFD.batchNo = IQFBP.BatchNumber " +
                            "WHERE BatchNumber='" + strBatchNo + "' AND IQFBP.Variety IS NOT NULL AND IQFBP.Variety <> '' AND LabelStatus='" + strLblsts + "'";
            dt = base.ODataServer.GetDataTable(QRY);
            return dt;
        }

        public DataTable GetChemSts(string strBatchNo, string strLblsts)
        {
            DataTable dt = new DataTable();
            string QRY = "SELECT DISTINCT SKFD.chemicalStatus AS ChemicalSts FROM IQFBarcodePrinting IQFBP JOIN SoakingFinalData SKFD  ON SKFD.batchNo = IQFBP.BatchNumber " +
                            "WHERE BatchNumber='" + strBatchNo + "' AND SKFD.chemicalStatus IS NOT NULL AND SKFD.chemicalStatus <> '' AND LabelStatus='" + strLblsts + "' ORDER BY chemicalStatus DESC;";
            dt = base.ODataServer.GetDataTable(QRY);
            return dt;
        }

        public DataTable GetNoOfSlabPacked(string strBatchno,string strPrdTyp,string strGrade,string strActPacstyl)
        {
            DataTable dth = new DataTable();

            string Qrys = "SELECT COUNT(*) AS PackedSlabCnt FROM IQFBarcodePrinting  WHERE BatchNumber='" + strBatchno + "' AND LabelStatus='Scanned' AND" +
                " Variety ='" + strPrdTyp + "' AND Grade='" + strGrade + "'  AND Actpackingstyle='" + strActPacstyl + "'";
            dth = base.ODataServer.GetDataTable(Qrys);
            return dth;
        }

        public DataTable GetCountdtls(decimal strcnt,string pdtype,string strChmSts)
        {
            DataTable dtc;

            string Qery = "SELECT " + pdtype + "  FROM PackingYieldMaster WHERE HeadOnCount = " + strcnt + " AND ChemicalStatus='" + strChmSts + "'";
            dtc = base.ODataServer.GetDataTable(Qery);

            return dtc;

        }



    }
}
