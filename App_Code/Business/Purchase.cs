using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Purchase
/// </summary>
public class Purchase
{
    public Purchase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Purchase
    private string m_SaudaNumberCode = null;
    private DateTime  m_PurchaseDate ;
    private string m_PurchaseType = null;
    private string m_SupplierName = null;
    private string m_FarmerName = null;
    private string m_PondNumber = null;
    private string m_villageName = null;
    private string m_mandalName = null;
    private string m_district = null;
    private string m_batchNumber = null;
    private DateTime m_harvestStartDate;
    private DateTime m_HarvestEndDate;
    //Weightment
    private string m_SampleWeight = null;
    private string m_No_of_Normal_Pieces = null;
    private string m_No_of_small_pieces = null;
    private string m_No_of_small_Accounted_One = null;
    private string m_Total_Number_of_Pieces = null;
    private string m_WeightDeduction = null;
    private string m_CountAdjustment = null;
    private string m_PurchaseCountPerKG = null;
    private string m_No_Of_Nets = null;
    private string m_Tare_Weight_Per_Net = null;
    private string m_GrossWeight = null;
    private string m_TotalWeight = null;
    //QualityCheck
    private string m_noOfSoftPieces = null;
    private string m_softPer = null;
    private string m_blackSpot = null;
    private string m_blackPer = null;
    private string m_necrosis = null;
    private string m_necrosisPer = null;
    private string m_discolouration = null;
    private string m_discolourationPer = null;
    private string m_colorofShirmp = null;
    private string m_gills = null;
    private string m_freshness = null;
    private string m_muddy = null;
    private string m_rmTemp = null;
    private string m_cleannessOfVechicle = null;
    private string m_cleannessOfBoxes = null;
    private string m_ICE = null;
    private string m_BrokenPieces = null;
    private string m_brokenPer = null;
    //
    private string m_remarks = null;
    private string m_supervisedBy = null;
    private string m_entryBy = null;
    private string m_approvedBy = null;

    private string m_createdBy = null;
    private DateTime m_createdDate;
    private string m_status = null;

    private string m_lotNumber = null;





    //Purchase Properties
    public string saudaNumberCode
    {
        get { return m_SaudaNumberCode; }
        set { m_SaudaNumberCode = value; }
    }


    public string lotNumber
    {
        get { return m_lotNumber; }
        set { m_lotNumber = value; }
    }
    public DateTime purchaseDate
    {
        get { return m_PurchaseDate; }
        set { m_PurchaseDate = value; }
    }
    public string purchaseType
    {
        get { return m_PurchaseType; }
        set { m_PurchaseType = value; }
    }
    public string supplierName
    {
        get { return m_SupplierName; }
        set { m_SupplierName = value; }
    }
    public string farmerName
    {
        get { return m_FarmerName; }
        set { m_FarmerName = value; }
    }
    public string pondNumber
    {
        get { return m_PondNumber; }
        set { m_PondNumber = value; }
    }
    public string villageName
    {
        get { return m_villageName; }
        set { m_villageName = value; }
    }
    public string mandalName
    {
        get { return m_mandalName; }
        set { m_mandalName = value; }
    }
    public string district
    {
        get { return m_district; }
        set { m_district = value; }
    }
    public string batchNumber
    {
        get { return m_batchNumber; }
        set { m_batchNumber = value; }
    }
    public DateTime harvestStartDate
    {
        get { return m_harvestStartDate; }
        set { m_harvestStartDate = value; }
    }
    public DateTime harvestEndDate
    {
        get { return m_HarvestEndDate; }
        set { m_HarvestEndDate = value; }
    }
    //Weightment Properties
    public string sampleWeight
    {
        get { return m_SampleWeight; }
        set { m_SampleWeight = value; }
    }
    public string noofNormalPieces
    {
        get { return m_No_of_Normal_Pieces; }
        set { m_No_of_Normal_Pieces = value; }
    }
    public string noofSmallPieces
    {
        get { return m_No_of_small_pieces; }
        set { m_No_of_small_pieces = value; }
    }
    public string noofsmallAccountedOne
    {
        get { return m_No_of_small_Accounted_One; }
        set { m_No_of_small_Accounted_One = value; }
    }
    public string totalNumberofPieces
    {
        get { return m_Total_Number_of_Pieces; }
        set { m_Total_Number_of_Pieces = value; }
    }
    public string weightDeduction
    {
        get { return m_WeightDeduction; }
        set { m_WeightDeduction = value; }
    }
    public string countAdjustment
    {
        get { return m_CountAdjustment; }
        set { m_CountAdjustment = value; }
    }
    public string purchaseCountPerKG
    {
        get { return m_PurchaseCountPerKG; }
        set { m_PurchaseCountPerKG = value; }
    }
    public string noOfNets
    {
        get { return m_No_Of_Nets; }
        set { m_No_Of_Nets = value; }
    }
    public string tareWeightPerNet
    {
        get { return m_Tare_Weight_Per_Net; }
        set { m_Tare_Weight_Per_Net = value; }
    }
    public string grossWeight
    {
        get { return m_GrossWeight; }
        set { m_GrossWeight = value; }
    }
    public string totalWeight
    {
        get { return m_TotalWeight; }
        set { m_TotalWeight = value; }
    }
    //QualityCheck Properties

    public string noOfSoftPieces
    {
        get { return m_noOfSoftPieces; }
        set { m_noOfSoftPieces = value; }
    }
    public string softPer
    {
        get { return m_softPer; }
        set { m_softPer = value; }
    }
    public string blackSpot
    {
        get { return m_blackSpot; }
        set { m_blackSpot = value; }
    }
    public string blackPer
    {
        get { return m_blackPer; }
        set { m_blackPer = value; }
    }
    public string necrosis
    {
        get { return m_necrosis; }
        set { m_necrosis = value; }
    }
    public string necrosisPer
    {
        get { return m_necrosisPer; }
        set { m_necrosisPer = value; }
    }
    public string discolouration
    {
        get { return m_discolouration; }
        set { m_discolouration = value; }
    }
    public string discolourationPer
    {
        get { return m_discolourationPer; }
        set { m_discolourationPer = value; }
    }
    public string colorofShirmp
    {
        get { return m_colorofShirmp; }
        set { m_colorofShirmp = value; }
    }
    public string gills
    {
        get { return m_gills; }
        set { m_gills = value; }
    }
    public string freshness
    {
        get { return m_freshness; }
        set { m_freshness = value; }
    }
    public string muddy
    {
        get { return m_muddy; }
        set { m_muddy = value; }
    }
    public string rmTemp
    {
        get { return m_rmTemp; }
        set { m_rmTemp = value; }
    }
    public string cleannessOfVechicle
    {
        get { return m_cleannessOfVechicle; }
        set { m_cleannessOfVechicle = value; }
    }
    public string cleannessOfBoxes
    {
        get { return m_cleannessOfBoxes; }
        set { m_cleannessOfBoxes = value; }
    }
    public string ice
    {
        get { return m_ICE; }
        set { m_ICE = value; }
    }
    public string brokenPieces
    {
        get { return m_BrokenPieces; }
        set { m_BrokenPieces = value; }
    }
    public string brokenPer
    {
        get { return m_brokenPer; }
        set { m_brokenPer = value; }
    }
    //Details Properties
    public string remarks
    {
        get { return m_remarks; }
        set { m_remarks = value; }
    }
    public string supervisedBy
    {
        get { return m_supervisedBy; }
        set { m_supervisedBy = value; }
    }
    public string entryBy
    {
        get { return m_entryBy; }
        set { m_entryBy = value; }
    }
    public string approvedBy
    {
        get { return m_approvedBy; }
        set { m_approvedBy = value; }
    }


    public string createdBy
    {
        get { return m_createdBy; }
        set { m_createdBy = value; }
    }
    public DateTime createdDate
    {
        get { return m_createdDate; }
        set { m_createdDate = value; }
    }
    public string status
    {
        get { return m_status; }
        set { m_status = value; }
    }
}