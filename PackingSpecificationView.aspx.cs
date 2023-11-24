using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace AQUA
{
    public partial class PackingSpecificationView : AQUABase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                bindPackingSpecification();
            }
        }

        private void bindPackingSpecification()
        {
            DataTable dt = new DataTable();
            try
            {
                PackingManagement pMgt = new PackingManagement();
                dt = pMgt.GetPackingSpecification();
                if(dt.Rows.Count>0)
                {
                    gvPackSpecDetails.DataSource = dt;
                    gvPackSpecDetails.DataBind();

                    
                }
                else
                {
                    gvPackSpecDetails.DataSource = null;
                    gvPackSpecDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void timerBind_Tick(object sender, EventArgs e)
        {
            bindPackingSpecification(); 
        }
    }
}