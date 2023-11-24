using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IQFOutFeed
/// </summary>
public class BlackOFeed
{
    public BlackOFeed()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_freezerNo = null;
    private string m_actualCount = null;
    private string m_gradeProductType = null;
    private string m_antibioticStatus = null;
    private string m_batchNumber = null;
    private string m_noofSlabLoaded = null;
    private string m_noofSlabUnLoaded = null;
    private string m_noofSlabReFre = null;
    private string m_noofSlabRej = null;
    private string m_noofSlabGoodPack = null;
    private string m_totQty = null;
    private string m_outFeedDate = null;
    private string m_createdBy = null;
    private string m_createdDate = null;
    private string m_status = null;
    private string m_remarks = null;

    public string freezerNo
    {
        get { return m_freezerNo; }
        set { m_freezerNo = value; }
    }

    public string Remarks
    {
        get { return m_remarks; }
        set { m_remarks = value; }
    }


    public string ActualCount
    {
        get { return m_actualCount; }
        set { m_actualCount = value; }
    }

    public string gradeProductType
    {
        get { return m_gradeProductType; }
        set { m_gradeProductType = value; }
    }


    public string AntibioticStatus
    {
        get { return m_antibioticStatus; }
        set { m_antibioticStatus = value; }
    }


    public string batchNumber
    {
        get { return m_batchNumber; }
        set { m_batchNumber = value; }
    }



    public string noofSlabLoaded
    {
        get { return m_noofSlabLoaded; }
        set { m_noofSlabLoaded = value; }
    }

    public string noofSlabUnLoaded
    {
        get { return m_noofSlabUnLoaded; }
        set { m_noofSlabUnLoaded = value; }
    }

    public string noofSlabReFre
    {
        get { return m_noofSlabReFre; }
        set { m_noofSlabReFre = value; }
    }

    public string noofSlabRej
    {
        get { return m_noofSlabRej; }
        set { m_noofSlabRej = value; }
    }

    public string noofSlabGoodPack
    {
        get { return m_noofSlabGoodPack; }
        set { m_noofSlabGoodPack = value; }
    }


    public string totQty
    {
        get { return m_totQty; }
        set { m_totQty = value; }
    }

    public string OutFeedDate
    {
        get { return m_outFeedDate; }
        set { m_outFeedDate = value; }
    }

    public string CreatedBy
    {
        get { return m_createdBy; }
        set { m_createdBy = value; }
    }
    public string Status
    {
        get { return m_status; }
        set { m_status = value; }
    }


}