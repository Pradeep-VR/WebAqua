using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IQFOutFeed
/// </summary>
public class IQFOFeed
{
    public IQFOFeed()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_barcode = null;
    private string m_actualCount = null;
    private string m_glaze = null;
    private string m_antibioticStatus = null;
    private string m_degiazedWt = null;
    private string m_uniformity = null;
    private string m_brokenPieces = null;
    private string m_brokenTail = null;
    private string m_discolouration = null;
    private string m_blackSpot = null;
    private string m_neckMeat = null;
    private string m_outFeedDate = null;
    private string m_createdBy = null;
    private string m_createdDate = null;
    private string m_status = null;
    private string m_remarks = null;

    public string Barcode
    {
        get { return m_barcode; }
        set { m_barcode = value; }
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

    public string Glaze
    {
        get { return m_glaze; }
        set { m_glaze = value; }
    }


    public string AntibioticStatus
    {
        get { return m_antibioticStatus; }
        set { m_antibioticStatus = value; }
    }


    public string DegiazedWt
    {
        get { return m_degiazedWt; }
        set { m_degiazedWt = value; }
    }



    public string Uniformity
    {
        get { return m_uniformity; }
        set { m_uniformity = value; }
    }

    public string BrokenPieces
    {
        get { return m_brokenPieces; }
        set { m_brokenPieces = value; }
    }

    public string BrokenTail
    {
        get { return m_brokenTail; }
        set { m_brokenTail = value; }
    }

    public string Discolouration
    {
        get { return m_discolouration; }
        set { m_discolouration = value; }
    }

    public string BlackSpot
    {
        get { return m_blackSpot; }
        set { m_blackSpot = value; }
    }


    public string NeckMeat
    {
        get { return m_neckMeat; }
        set { m_neckMeat = value; }
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