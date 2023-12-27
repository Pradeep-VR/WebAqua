using AQUA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IQFOutFeedManagement
/// </summary>
public class IQFOutFeedManagement : AQUAObject
{
    public IQFOutFeedManagement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetOutFeedDetails(string strBarcode)
    {
        DataTable dt = new DataTable();
        try
        {
            string s = "select * from IQFOutFeed where barcode='" + strBarcode + "' ";
            dt = base.ODataServer.GetDataTable(s);
        }
        catch (Exception ex)
        {
            dt = null;
        }
        return dt;
    }


    



    public DataTable GetOutFeedFinalDta(string Barcodeid)
    {
        DataTable dt = new DataTable();
        try
        {
            string s = "select * from IQFFinalData where barcodeId='"+ Barcodeid + "'";
            dt = base.ODataServer.GetDataTable(s);
        }
        catch (Exception ex)
        {
            dt = null;
        }
        return dt;
    }

    public bool IQFOutFeedInsertUpdate(IQFOFeed OFeed, string strInsertUpdate)
    {
        bool b = false;
        try
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Action", strInsertUpdate));
            parameters.Add(new SqlParameter("Barcode", OFeed.Barcode));
            parameters.Add(new SqlParameter("ActualCount", OFeed.ActualCount));
            parameters.Add(new SqlParameter("Glaze", OFeed.Glaze));
            parameters.Add(new SqlParameter("AntibioticStatus", OFeed.AntibioticStatus));
            parameters.Add(new SqlParameter("DegiazedWt", OFeed.DegiazedWt));
            parameters.Add(new SqlParameter("Uniformity", OFeed.Uniformity));
            parameters.Add(new SqlParameter("BrokenPieces", OFeed.BrokenPieces));
            parameters.Add(new SqlParameter("BrokenTail", OFeed.BrokenTail));
            parameters.Add(new SqlParameter("Discolouration", OFeed.Discolouration));
            parameters.Add(new SqlParameter("BlackSpot", OFeed.BlackSpot));
            parameters.Add(new SqlParameter("NeckMeat", OFeed.NeckMeat));
            parameters.Add(new SqlParameter("OutFeedDate", OFeed.OutFeedDate));
            parameters.Add(new SqlParameter("CreatedBy", OFeed.CreatedBy));
            parameters.Add(new SqlParameter("Remarks", OFeed.Remarks));

            b = base.ODataServer.ExecuteSP(parameters, "InsertIQFOutFeed", SPCommand.Insert);
        }
        catch (Exception ex)
        {
            ex.ToString();
            b = false;
        }
        return b;
    }



    public bool BlockOutFeedInsertUpdate(BlackOFeed OFeed)
    {
        bool b = false;
        string strQry = "";
        try
        {
            strQry = "INSERT INTO [dbo].[BlockFOutFeed]([FreezerNumber] ,[GradeAndProdType] ,";
            strQry = strQry + "[BatchNumber],[noofSlabLoaded],[noofSlabUnLoaded],[noofSlabReFerze],[noofSlabReject],";
            strQry = strQry + "[noofSlabNetPack],[FrezeUnloadDate],[ActualFlatCount],[TotalQtyBF],[Antibotic],[CreatedBy],";
            strQry = strQry + " [CreatedDate],[status] ,[Remarks]) VALUES( ";
            strQry = strQry + " '" + OFeed.freezerNo + "', '" + OFeed.gradeProductType + "','" + OFeed.batchNumber + "' , ";
            strQry = strQry + " '" + OFeed.noofSlabLoaded + "', '" + OFeed.noofSlabUnLoaded + "','" + OFeed.noofSlabReFre + "',  ";
            strQry = strQry + " '" + OFeed.noofSlabRej + "', '" + OFeed.noofSlabGoodPack + "','" + OFeed.OutFeedDate + "',  ";
            strQry = strQry + " '" + OFeed.ActualCount + "', '" + OFeed.totQty + "','" + OFeed.AntibioticStatus + "',  ";
            strQry = strQry + " '" + OFeed.CreatedBy + "',getdate(),1,'Testing') ";
           
            b = base.ODataServer.ExecuteNonQuery(strQry);

            // GradeAndProdType

            string strPackStyleGP = OFeed.gradeProductType;
            string strGrade = "";
            string strProdType = "";
            // Split authors separated by a comma followed by space  
            string[] strGPList = strPackStyleGP.Split('&');
            int a1 = 1;
            foreach (string strGP in strGPList)
            {
                if (a1 == 1)
                {
                    a1 = a1 + 1;
                    strGrade = strGP;
                }
                else
                {
                    strProdType = strGP;

                }
            }
            strQry = "";
            strQry = strQry + "Update IQFFinalData set Status='Added' where Grade='" + strGrade.Trim() + "' and ProductType ='" + strProdType.Trim() + "' and  freezingType = 'BLOCK' and status = 'Pending' and MachineNo = '" + OFeed.freezerNo.Trim() + " '  ";
            b = base.ODataServer.ExecuteNonQuery(strQry);

        }
        catch (Exception ex)
        {
            ex.ToString();
            b = false;
        }
        return b;
    }



    public DataTable GetOutFeed(string strFreezerNo)
    {
        DataTable dt = new DataTable();
        try
        {
            string s = "select distinct FreezerNumber,GradeAndProdType,BatchNumber,NoofSlabLoaded,NoOfSlabUnLoaded, ";
            s = s + " NoOfSlabReFerze,NoOfSlabReject,NoOfSlabNetPAck from BlockFOutFeed B Join IQFFinalData I ";
            s = s + "  on B.FreezerNumber = I.machineNo where B.status = 1 and I.Status = 'Added'  ";
           // s = s + "  B.freezernumber ='"+ strFreezerNo + "' ";
            dt = base.ODataServer.GetDataTable(s);
        }
        catch (Exception ex)
        {
            dt = null;
        }
        return dt;
    }
    

    public bool BlockOutFeedUpdate(string strFreezerNo,string strGradePT)
    {
        bool b = false;
        string strQry = "";
        try
        {
            string strPackStyleGP = strGradePT;
            string strGrade = "";
            string strProdType = "";
            // Split authors separated by a comma followed by space  
            string[] strGPList = strPackStyleGP.Split('&');
            int a1 = 1;
            foreach (string strGP in strGPList)
            {
                if (a1 == 1)
                {
                    a1 = a1 + 1;
                    strGrade = strGP;
                }
                else
                {
                    strProdType = strGP;
                }
            }
            strQry = "";
            strQry = strQry + "Update IQFFinalData set Status='Finished' where Grade='" + strGrade.Trim() + "' and ProductType ='" + strProdType.Trim() + "' and  freezingType = 'BLOCK' and status = 'Added' and MachineNo = '" + strFreezerNo + " '  ";
            b = base.ODataServer.ExecuteNonQuery(strQry);
        }
        catch (Exception ex)
        {
            ex.ToString();
            b = false;
        }
        return b;
    }
    
}