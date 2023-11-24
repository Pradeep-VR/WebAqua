using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AuthenticatedUser
{
    public AuthenticatedUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_id = null;
    private string m_loginName = null;
    private string m_userType = null;
    private Boolean m_active = true;
    private string m_expiryDate = null;
    private string m_Password = null;
    private string m_Accactive = null;
    private string m_location = null;
    private string m_labName = null;
    private string m_mail = null;
    private string m_department = null;

    private string m_processIn = null;

    private string m_lastLogIn = null;


    public string ID
    {
        get { return m_id; }
        set { m_id = value; }
    }


    public string LastLoggedIN
    {
        get { return m_lastLogIn; }
        set { m_lastLogIn = value; }
    }

    public string ProcessIn
    {
        get { return m_processIn; }
        set { m_processIn = value; }
    }
    public string Department
    {
        get { return m_department; }
        set { m_department = value; }
    }
    public string UserName
    {
        get { return m_loginName; }
        set { m_loginName = value; }
    }
    public string LoginLocation
    {
        get { return m_location; }
        set { m_location= value; }
    }

    public string LabName
    {
        get { return m_labName; }
        set { m_labName = value; }
    }

    public string UserType
    {
        get { return m_userType; }
        set { m_userType = value; }
    }
    public Boolean Active
    {
        get { return m_active; }
        set { m_active = value; }
    }
    public string EnPassword
    {
        get { return m_Password; }
        set { m_Password = value; }
    }
    public string ExpiryDate
    {
        get { return m_expiryDate; }
        set { m_expiryDate = value; }
    }
    public string accActive
    {
        get { return m_Accactive; }
        set { m_Accactive = value; }
    }
    public string Email
    {
        get { return m_mail; }
        set { m_mail = value; }
    }


}
