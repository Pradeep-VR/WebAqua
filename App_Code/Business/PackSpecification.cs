using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackSpecification
/// </summary>
public class PackSpecification
{
    public PackSpecification()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_PackID = null;
    private string m_buyerName = null;
    private string m_pONumber = null;
    private string m_cargoNumber = null;
    private string m_brand = null;
    private string m_packingStyle = null;
    private string m_packingType = null;
    private string m_glaze = null;
    private string m_unit = null;
    private string m_grade = null;
    private string m_variety = null;
    private int m_targetCount = 0;
    private int m_orderQty = 0;
    private int m_noofSlabs = 0;
    private int m_matchedfromOpen = 0;
    private int m_noofSlabsYesterday = 0;
    private int m_noofSlabsToday = 0;
    private int m_balanceSlabs = 0;
    private double m_balanceCartons = 0.0;
    private double m_balanceQty = 0.0;
    private double m_cartonPacked = 0.0;
    private double m_cartonRepack = 0.0;
    private double m_cartonBalRepack = 0.0;
    private string m_chemicalTreatment = null;
    private string m_remarks = null;
    private string m_packingstatus = null;
    private string m_verifiedBy = null;
    private string m_repackStatus = null;
    private string m_glazespec = null;




    public string GlazeSpec
    {
        get { return m_glazespec; }
        set { m_glazespec = value; }
    }

    public string RepackStatus
    {
        get { return m_repackStatus; }
        set { m_repackStatus = value; }
    }

    public string PackID
    {
        get { return m_PackID; }
        set { m_PackID = value; }
    }

    public string BuyerName
    {
        get { return m_buyerName; }
        set { m_buyerName = value; }
    }
    public string PONumber
    {
        get { return m_pONumber; }
        set { m_pONumber = value; }
    }


    public string CargoNo
    {
        get { return m_cargoNumber; }
        set { m_cargoNumber = value; }
    }

    public string Brand
    {
        get { return m_brand; }
        set { m_brand = value; }
    }

    public string PackingStyle
    {
        get { return m_packingStyle; }
        set { m_packingStyle = value; }
    }

    public string PackingType
    {
        get { return m_packingType; }
        set { m_packingType = value; }
    }

    public string Glaze
    {
        get { return m_glaze; }
        set { m_glaze = value; }
    }

    public string Unit
    {
        get { return m_unit; }
        set { m_unit = value; }
    }


    public string Grade
    {
        get { return m_grade; }
        set { m_grade = value; }
    }

    public string Variety
    {
        get { return m_variety; }
        set { m_variety = value; }
    }

    public int OrderQty
    {
        get { return m_orderQty; }
        set { m_orderQty = value; }
    }

    public int TargetCount
    {
        get { return m_targetCount; }
        set { m_targetCount = value; }
    }

    public int NoofSlabs
    {
        get { return m_noofSlabs; }
        set { m_noofSlabs = value; }
    }

    public int MatchedfromOpen
    {
        get { return m_matchedfromOpen; }
        set { m_matchedfromOpen = value; }
    }

    public int NoofSlabsYesterday
    {
        get { return m_noofSlabsYesterday; }
        set { m_noofSlabsYesterday = value; }
    }
    public int NoofSlabsToday
    {
        get { return m_noofSlabsToday; }
        set { m_noofSlabsToday = value; }
    }
    public int BalanceSlabs
    {
        get { return m_balanceSlabs; }
        set { m_balanceSlabs = value; }
    }

    public Double BalanceCartons
    {
        get { return m_balanceCartons; }
        set { m_balanceCartons = value; }
    }


    public Double BalanceQty
    {
        get { return m_balanceQty; }
        set { m_balanceQty = value; }
    }

    public Double CartonPacked
    {
        get { return m_cartonPacked; }
        set { m_cartonPacked = value; }
    }

    public Double CartonRepack
    {
        get { return m_cartonRepack; }
        set { m_cartonRepack = value; }
    }
    public Double CartonBalRepack
    {
        get { return m_cartonBalRepack; }
        set { m_cartonBalRepack = value; }
    }

    public string ChemicalTreatment
    {
        get { return m_chemicalTreatment; }
        set { m_chemicalTreatment = value; }
    }

    public string Remarks
    {
        get { return m_remarks; }
        set { m_remarks = value; }
    }
    public string Packingstatus
    {
        get { return m_packingstatus; }
        set { m_packingstatus = value; }
    }
    public string VerifiedBy
    {
        get { return m_verifiedBy; }
        set { m_verifiedBy = value; }
    }


}