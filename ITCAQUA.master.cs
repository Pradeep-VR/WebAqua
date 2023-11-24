using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ITCAQUA : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    //if (Session["UserName"] == null)
    //    {
    //        Response.Redirect("Login.aspx");
    //    }
        //////////else {
        //////////    if (!Request.FilePath.Contains("Login"))
        //////////    {
        //////////        string strPreviousPage = "";
        //////////        if (Request.UrlReferrer != null)
        //////////        {
        //////////            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        //////////        }
        //////////        if (strPreviousPage == "")
        //////////        {
        //////////            Response.Redirect("Login.aspx");
        //////////        }
        //////////    }
        //////////}
        //if (!IsPostBack)
        //{
        //    lblLoggedIn.Text = Session["UserName"].ToString();
        //    lblLoggedIn1.Text = Session["UserName"].ToString();

        //    lblUserType.Text = Session["UserType"].ToString();
        //    lblUserType1.Text = Session["UserType"].ToString();

        //    if (Session["Department"] != null)
        //    {
        //        if (Session["Department"].ToString().ToUpper() == "ADMINISTRATIVE")
        //        {
        //           liMasters.Visible = true;
        //            //liQuality.Visible = true;
        //            //liPurchase.Visible = true;
        //            //divSoaking.Visible = true;
        //        }
        //        else if (Session["Department"].ToString().ToUpper() == "QUALITY")
        //        {
        //            liMasters.Visible = false;
        //            //liQuality.Visible = true;
        //            //liPurchase.Visible = false;
        //            //divSoaking.Visible = false;
        //        }
        //        else if (Session["Department"].ToString().ToUpper() == "PURCHASE")
        //        {
        //           liMasters.Visible = false;
        //            //liQuality.Visible = false;
        //            //liPurchase.Visible = true;
        //            //divSoaking.Visible = false;
        //        }
        //        else if (Session["Department"].ToString().ToUpper() == "SOAKING")
        //        {
        //            liMasters.Visible = false;
        //            //liQuality.Visible = false;
        //            //liPurchase.Visible = true;
        //            //divSoaking.Visible = false;
        //        }

        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
    }

}
    