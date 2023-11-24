using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QualityMaster
/// </summary>
public class Quality
{
    public Quality()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_id = null;
    private string m_testingType = null;
    private string m_labName = null;
    private string m_shipmentPONumber = null;
    private string m_batchNumber = null;
    private string m_index = null;
    private string m_noOfSamplesTested = null;
    private string m_testingDate = null;
    private string m_aoz = null;
    private string m_ahd = null;
    private string m_sem = null;
    private string m_amoz = null;
    private string m_cap = null;
    private string m_MalachiteGreen = null;
    private string m_CrystalViolet = null;
    private string m_SOZ = null;
    private string m_TPC = null;
    private string m_eCOIL = null;
    private string m_vibrio = null;
    private string m_salmonella = null;
    private string m_staphylococcus = null;
    private string m_filthStatus = null;
    private string m_reason1 = null;
    private string m_reason2 = null;
    private string m_sampleResult = null;
    private string m_performedBy = null;
    private string m_entryBy = null;
    private string m_resultFailure = null;
    private string m_remarks = null;
    private string m_remarks1 = null;
    private string m_createdBy = null;
    private string m_createdDate = null;
    private string m_updatedBy = null;
    private string m_updatedDate = null;
    private string m_status = null;
    private string m_flag = null;

    private string m_leucoMalachiteGreen = null;
    private string m_leucoCrystalViolet = null;


    public string LeucoMalachiteGreen
    {
        get { return m_leucoMalachiteGreen; }
        set { m_leucoMalachiteGreen = value; }
    }

    public string LeucoCrystalViolet
    {
        get { return m_leucoCrystalViolet; }
        set { m_leucoCrystalViolet = value; }
    }
    public string QualityID
    {
        get { return m_id; }
        set { m_id = value; }
    }

    public string TestingType
    {
        get { return m_testingType; }
        set { m_testingType = value; }
    }

    public string LabName
    {
        get { return m_labName; }
        set { m_labName = value; }
    }
    public string ShipmentPONumber
    {
        get { return m_shipmentPONumber; }
        set { m_shipmentPONumber = value; }
    }
    public string BatchNumber
    {
        get { return m_batchNumber; }
        set { m_batchNumber = value; }
    }
    public string Index
    {
        get { return m_index; }
        set { m_index = value; }
    }
    public string NoOfSamplesTested
    {
        get { return m_noOfSamplesTested; }
        set { m_noOfSamplesTested = value; }
    }
    public string TestingDate
    {
        get { return m_testingDate; }
        set { m_testingDate = value; }
    }
    public string AOZ
    {
        get { return m_aoz; }
        set { m_aoz = value; }
    }
    public string AHD
    {
        get { return m_ahd; }
        set { m_ahd = value; }
    }
    public string SEM
    {
        get { return m_sem; }
        set { m_sem = value; }
    }
    public string AMOZ
    {
        get { return m_amoz; }
        set { m_amoz = value; }
    }
    public string CAP
    {
        get { return m_cap; }
        set { m_cap = value; }
    }
    public string MalachiteGreen
    {
        get { return m_MalachiteGreen; }
        set { m_MalachiteGreen = value; }
    }
    public string CrystalViolet
    {
        get { return m_CrystalViolet; }
        set { m_CrystalViolet = value; }
    }
    public string SO2
    {
        get { return m_SOZ; }
        set { m_SOZ = value; }
    }
    public string TPC
    {
        get { return m_TPC; }
        set { m_TPC = value; }
    }
    public string ECoil
    {
        get { return m_eCOIL; }
        set { m_eCOIL = value; }
    }
    public string Vibrio
    {
        get { return m_vibrio; }
        set { m_vibrio = value; }
    }
    public string Salmonella
    {
        get { return m_salmonella; }
        set { m_salmonella = value; }
    }
    public string StaphyLococcus
    {
        get { return m_staphylococcus; }
        set { m_staphylococcus = value; }
    }
    public string FilthStatus
    {
        get { return m_filthStatus; }
        set { m_filthStatus = value; }
    }
    public string Reason1
    {
        get { return m_reason1; }
        set { m_reason1 = value; }
    }
    public string Reason2
    {
        get { return m_reason2; }
        set { m_reason2 = value; }
    }
    public string SampleResult
    {
        get { return m_sampleResult; }
        set { m_sampleResult = value; }
    }
    public string PerformedBy
    {
        get { return m_performedBy; }
        set { m_performedBy = value; }
    }
    public string EntryBy
    {
        get { return m_entryBy; }
        set { m_entryBy = value; }
    }
    public string ResultFailure
    {
        get { return m_resultFailure; }
        set { m_resultFailure = value; }
    }
    public string Remarks
    {
        get { return m_remarks; }
        set { m_remarks = value; }
    }
    public string Remarks1
    {
        get { return m_remarks1; }
        set { m_remarks1 = value; }
    }
    public string CreatedBy
    {
        get { return m_createdBy; }
        set { m_createdBy = value; }
    }
    public string CreatedDate
    {
        get { return m_createdDate; }
        set { m_createdDate = value; }
    }
    public string UpdatedBy
    {
        get { return m_updatedBy; }
        set { m_updatedBy = value; }
    }
    public string UpdatedDate
    {
        get { return m_updatedDate; }
        set { m_updatedDate = value; }
    }
    public string Status
    {
        get { return m_status; }
        set { m_status = value; }
    }
    public string Flag
    {
        get { return m_flag; }
        set { m_flag = value; }
    }

}