using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Users
{
    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string m_userId = null;
    private string m_firstName = null;
    private string m_lastName = null;
    private string m_fullName = null;
    private string m_userName = null;
    private string m_userType = null;
    private string m_password = null;
    private string m_designation = null;
    private string m_department = null;
    private string m_labName = null;
    private string m_mobileNumber = null;
    private string m_emailAddress = null;  
    private string m_createdBy = null;
    private string m_updatedBy = null;
    private string m_status = null;
    private string m_expiryDate = null;
    private string m_processIn = null;
    public string UserID
    {
        get { return m_userId; }
        set { m_userId = value; }
    }

    public string ProcessIn
    {
        get { return m_processIn; }
        set { m_processIn = value; }
    }
    public string FirstName
    {
        get { return m_firstName; }
        set { m_firstName = value; }
    }

    public string LastName
    {
        get { return m_lastName; }
        set { m_lastName = value; }
    }
    public string FullName
    {
        get { return m_fullName; }
        set { m_fullName = value; }
    }
    public string UserName
    {
        get { return m_userName; }
        set { m_userName = value; }
    }
    public string UserType
    {
        get { return m_userType; }
        set { m_userType = value; }
    }
    public string Password
    {
        get { return m_password; }
        set { m_password = value; }
    }
    public string Designation
    {
        get { return m_designation; }
        set { m_designation = value; }
    }
    public string Department
    {
        get { return m_department; }
        set { m_department = value; }
    }

    public string LabName
    {
        get { return m_labName; }
        set { m_labName = value; }
    }
    public string MobileNumber
    {
        get { return m_mobileNumber; }
        set { m_mobileNumber = value; }
    }
    public string EmailAddress
    {
        get { return m_emailAddress ; }
        set { m_emailAddress = value; }
    }
    public string Status
    {
        get { return m_status; }
        set { m_status = value; }
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
    public string ExpiryDate
    {
        get { return m_expiryDate; }
        set { m_expiryDate = value; }
    }
    
}