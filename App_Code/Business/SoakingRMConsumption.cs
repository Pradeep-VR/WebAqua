using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RMConsumption
/// </summary>
public class SoakingRMConsumption
{
    public SoakingRMConsumption()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_consumptionDate = null;
    private string m_consumptionType = null;
    private string m_obChemical = null;
    private string m_conChemical = null;
    private string m_closeChemical = null;
    private string m_qtyChemical = null;
    private string m_OBAdd = null;
    private string m_ConAdd = null;
    private string m_CloseAdd = null;
    private string m_qtyAdd = null;
    private string m_OBSalt = null;
    private string m_ConSalt = null;
    private string m_CloseSalt = null;
    private string m_qtySalt = null;
    private string m_createdBy = null;
    private string m_remarks = null;



    public string ConsumptionType
    {
        get { return m_consumptionType; }
        set { m_consumptionType = value; }
    }

    public string QtyChemical
    {
        get { return m_qtyChemical; }
        set { m_qtyChemical = value; }
    }

    public string QtyAdd
    {
        get { return m_qtyAdd; }
        set { m_qtyAdd = value; }
    }

    public string QtySalt
    {
        get { return m_qtySalt; }
        set { m_qtySalt = value; }
    }





    public string ConsumptionDate
    {
        get { return m_consumptionDate; }
        set { m_consumptionDate = value; }
    }

    public string OBChemical
    {
        get { return m_obChemical; }
        set { m_obChemical = value; }
    }

    public string ConChemical
    {
        get { return m_conChemical; }
        set { m_conChemical = value; }
    }

    public string CloseChemical
    {
        get { return m_conChemical; }
        set { m_conChemical = value; }
    }



    public string ConAdd
    {
        get { return m_ConAdd; }
        set { m_ConAdd = value; }
    }

    public string OBAdd
    {
        get { return m_OBAdd; }
        set { m_OBAdd = value; }
    }

    public string CloseAdd
    {
        get { return m_CloseAdd; }
        set { m_CloseAdd = value; }
    }



    public string ConSalt
    {
        get { return m_ConSalt; }
        set { m_ConSalt = value; }
    }

    public string OBSalt
    {
        get { return m_OBAdd; }
        set { m_OBAdd = value; }
    }

    public string CloseSalt
    {
        get { return m_CloseSalt; }
        set { m_CloseSalt = value; }
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

}