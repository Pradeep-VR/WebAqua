using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SoakingWorkEfficiency
/// </summary>
public class PeelingWorkEff
{
    public PeelingWorkEff()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string m_peeledDate = null;
    private string m_s1NoofWorker = null;
    private string m_s2NoofWorker = null;
    private string m_s1NoofHours = null;
    private string m_s2NoofHours = null;
    private string m_s1PeeledQty = null;
    private string m_s2PeeledQty = null;
    private string m_s1WorkEff = null;
    private string m_s2WorkEff = null;
    private string m_createdBy = null;
    private string m_updatedBy = null;  
    private string m_remarks = null;
    private string m_avgHR = null;


    public string AvgHr
    {
        get { return m_avgHR; }
        set { m_avgHR = value; }
    }

    public string PeeledDate
    {
        get { return m_peeledDate; }
        set { m_peeledDate = value; }
    }

    public string S1NoofWorker
    {
        get { return m_s1NoofWorker; }
        set { m_s1NoofWorker = value; }
    }
    public string S2NoofWorker
    {
        get { return m_s2NoofWorker; }
        set { m_s2NoofWorker = value; }
    }
    public string S1NoofHours
    {
        get { return m_s1NoofHours; }
        set { m_s1NoofHours = value; }
    }
    public string S2NoofHours
    {
        get { return m_s2NoofHours; }
        set { m_s2NoofHours = value; }
    }
    public string S1PeeledQty
    {
        get { return m_s1PeeledQty; }
        set { m_s1PeeledQty = value; }
    }
    public string S2PeeledQty
    {
        get { return m_s2PeeledQty; }
        set { m_s2PeeledQty = value; }
    }
    public string S1WorkEfficiency
    {
        get { return m_s1WorkEff; }
        set { m_s1WorkEff = value; }
    }
    public string S2WorkEfficiency
    {
        get { return m_s2WorkEff; }
        set { m_s2WorkEff = value; }
    }
    public string Remarks
    {
        get { return m_remarks; }
        set { m_remarks = value; }
    }
    public string CreatedBy
    {
        get { return m_createdBy; }
        set { m_createdBy = value; }
    }
    public string UpdatedBy
    {
        get { return m_updatedBy; }
        set { m_updatedBy = value; }
    }
}