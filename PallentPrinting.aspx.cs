using System;
using System.Web.UI;
using System.Data;
namespace AQUA
{

    public partial class PallentPrinting : System.Web.UI.Page
    {       
        CommonManagement cMgt = new CommonManagement();
        PackingManagement pMgt = new PackingManagement();        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindDropDown();

            }
            
        }
        private void BindDropDown()
        {
            ddlpallet_new.DataSource = cMgt.BindDropDown("CartonStorage");
            ddlpallet_new.DataTextField = "TextField";
            ddlpallet_new.DataValueField = "ValueField";
            ddlpallet_new.DataBind();
            ddlpallet_new.Items.Insert(0, "-Select-");
                                                      
        }
        protected void btnNEW_Click(object sender, EventArgs e)
        {
            divnew.Visible = true;
            divexisting.Visible = false;

        }
        
        protected void btnExisting_Click(object sender, EventArgs e)
        {           
            divnew.Visible = false;
            divexisting.Visible = true;
            ddlpallettyp_ext.Enabled = false;

        }

        protected void ddlpallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPalletid_new.Enabled = false;

            string vludata = pMgt.GetlastPalletid(ddlpallet_new.SelectedItem.Text);
            txtPalletid_new.Text = vludata.ToString();
        }

        protected void btnsave_print_Click(object sender, EventArgs e)
        {
            string zplcmd = "";
            string zplcmd2 = "";
            string cnt = "";
            try
            {
                btnSave_new_Click(sender, e);
                string type = ddlpallet_new.SelectedItem.ToString();
                for (int i = 1; i <= Convert.ToInt32(txtlabels_new.Text); i++)
                {
                    cnt = Convert.ToString(i);
                    if(type.ToUpper() == "FINAL")
                    {
                        zplcmd = "^XA" +
                                "~TA000" +
                                "~JSN" +
                                "^LT0" +
                                "^MNW" +
                                "^MTT" +
                                "^PON" +
                                "^PMN" +
                                "^LH0,0" +
                                "^JMA" +
                                "^PR6,6" +
                                "~SD25" +
                                "^JUS" +
                                "^LRN" +
                                "^CI27" +
                                "^PA0,1,1,0" +
                                "^XZ" +
                                "^XA" +
                                "^MMT" +
                                "^PW831" +
                                "^LL574" +
                                "^LS0" +
                                "^FO46,27^GB728,513,4,,0^FS" +
                                "^BY2,3,119^FT203,307^BCN,,Y,N" +
                                "^FH\\^FD>:" + txtPalletid_new.Text + "^FS" +
                                "^FO112,408^GB62,61,53^FS" +
                                "^PQ1,0,1,Y" +
                                "^XZ";

                    }
                    else if(type.ToUpper() == "DUMMY")
                    {
                        zplcmd = "^XA" +
                                "~TA000" +
                                "~JSN" +
                                "^LT0" +
                                "^MNW" +
                                "^MTT" +
                                "^PON" +
                                "^PMN" +
                                "^LH0,0" +
                                "^JMA" +
                                "^PR6,6" +
                                "~SD15" +
                                "^JUS" +
                                "^LRN" +
                                "^CI27" +
                                "^PA0,1,1,0" +
                                "^XZ" +
                                "^XA" +
                                "^MMT" +
                                "^PW831" +
                                "^LL574" +
                                "^LS0" +
                                "^FO35,21^GB770,531,4,,0^FS" +
                                "^FO115,399^GE79,77,39^FS" +
                                "^BY2,3,119^FT207,321^BCN,,Y,N" +
                                "^FH\\^FD>:" + txtPalletid_new.Text + "^FS" +
                                "^PQ1,0,1,Y" +
                                "^XZ";
                    }
                     
                    if (zplcmd2 == "")
                    {
                        zplcmd2 = zplcmd;
                    }
                    else
                    {
                        zplcmd2 = zplcmd2 + zplcmd;
                    }
                    if(txtlabels_new.Text == cnt)
                    {
                        if (ScriptManager.GetCurrent(this) != null)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "writeToSelectedPrinter('" + zplcmd2 + "');", true);
                            zplcmd2 = "";
                        }
                        else
                        {
                            string script = "<script type='text/javascript'>writeToSelectedPrinter('" + zplcmd2 + "');</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
                            zplcmd2 = "";
                        }
                    }
                    else { }
                    zplcmd = "";
                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnSave_new_Click(object sender, EventArgs e)
        {
            string username = Session["UserName"].ToString();
            string palletId = txtPalletid_new.Text;
            string palletType = ddlpallet_new.SelectedValue;
            int numberOfLabels = 0;
            if (txtlabels_new.Text == null || txtlabels_new.Text == "")
            {
                numberOfLabels = 0;
            }
            else
            {
                 numberOfLabels = int.Parse(txtlabels_new.Text);
            }            
            try
            {
                bool k = pMgt.insertPalletId(username, palletId, palletType, numberOfLabels);
                if (k != true)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Pallet Id Inserting Failed.!!";
                }
                else { lblMessage.Text = "Pallet Id Added Success.";
                    lblMessage.Visible = true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        protected void btnClear_new_Click(object sender, EventArgs e)
        {
            txtPalletid_new.Text = "";
            txtlabels_new.Text = "";
            ddlpallet_new.SelectedIndex = 0;
        }

        protected void btnclear_ext_Click(object sender, EventArgs e)
        {
            txtpalletid_ext.Text = "";
            ddlpallettyp_ext.Text = "";
            Nooflbl_ext.Text = "";
            
        }

        protected void btnprint_ext_Click(object sender, EventArgs e)
        {
            string zplcmd3 = "";
            string zplcmd4 = "";
            string cnt1 = "";

            string username = Session["UserName"].ToString();
            string palletId = txtpalletid_ext.Text;
            string palletType = ddlpallettyp_ext.Text;
            int numberOfLabels = 0;
            if (txtlabels_new.Text == null || txtlabels_new.Text == "")
            {
                lblMessage.Text = "Please Enter Label Quantity";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            else
            {
                numberOfLabels = int.Parse(txtlabels_new.Text);
            }
            try
            {
                bool k = pMgt.updatePalletId(username, palletId, palletType, numberOfLabels);
                if (k != true)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Pallet Id Inserting Failed.!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMessage.Text = "Pallet Id Added Success.";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }

                for (int i = 1; i <= Convert.ToInt32(Nooflbl_ext.Text); i++)
                {
                    cnt1 = Convert.ToString(i);
                    if (ddlpallettyp_ext.Text.ToUpper() == "FINAL")
                    {
                        zplcmd3 = "^XA" +
                                "~TA000" +
                                "~JSN" +
                                "^LT0" +
                                "^MNW" +
                                "^MTT" +
                                "^PON" +
                                "^PMN" +
                                "^LH0,0" +
                                "^JMA" +
                                "^PR6,6" +
                                "~SD25" +
                                "^JUS" +
                                "^LRN" +
                                "^CI27" +
                                "^PA0,1,1,0" +
                                "^XZ" +
                                "^XA" +
                                "^MMT" +
                                "^PW831" +
                                "^LL574" +
                                "^LS0" +
                                "^FO46,27^GB728,513,4,,0^FS" +
                                "^BY2,3,119^FT203,307^BCN,,Y,N" +
                                "^FH\\^FD>:" + txtpalletid_ext.Text + "^FS" +
                                "^FO112,408^GB62,61,53^FS" +
                                "^PQ1,0,1,Y" +
                                "^XZ";

                    }
                    else if (ddlpallettyp_ext.Text.ToUpper() == "DUMMY")
                    {
                        zplcmd3 = "^XA" +
                                "~TA000" +
                                "~JSN" +
                                "^LT0" +
                                "^MNW" +
                                "^MTT" +
                                "^PON" +
                                "^PMN" +
                                "^LH0,0" +
                                "^JMA" +
                                "^PR6,6" +
                                "~SD25" +
                                "^JUS" +
                                "^LRN" +
                                "^CI27" +
                                "^PA0,1,1,0" +
                                "^XZ" +
                                "^XA" +
                                "^MMT" +
                                "^PW831" +
                                "^LL574" +
                                "^LS0" +
                                "^FO35,21^GB770,531,4,,0^FS" +
                                "^FO115,399^GE79,77,39^FS" +
                                "^BY2,3,119^FT207,321^BCN,,Y,N" +
                                "^FH\\^FD>:" + txtpalletid_ext.Text + "^FS" +
                                "^PQ1,0,1,Y" +
                                "^XZ";
                    }
                    if (zplcmd4 == "")
                    {
                        zplcmd4 = zplcmd3;
                    }
                    else
                    {
                        zplcmd4 = zplcmd4 + zplcmd3;
                    }
                    if (Nooflbl_ext.Text == cnt1)
                    {
                        if (ScriptManager.GetCurrent(this) != null)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "writeToSelectedPrinter('" + zplcmd4 + "');", true);
                            zplcmd4 = "";
                        }
                        else
                        {
                            string script = "<script type='text/javascript'>writeToSelectedPrinter('" + zplcmd4 + "');</script>";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
                            zplcmd4 = "";
                        }
                    }
                    else { }
                    zplcmd3 = "";
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btn_view_ext_Click(object sender, EventArgs e)
        {
            
            try
            {
                string pltTyp = pMgt.getpalletid(txtpalletid_ext.Text);
                if(pltTyp != ""){
                    ddlpallettyp_ext.Text = pltTyp.ToString();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Brown;
                    lblMessage.Text = "Pallet Id Not Exixt...";
                    
                }
            }
            catch(Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Brown;
                lblMessage.Text = "Pallet Id Not Exixt..." + ex.ToString();
                
            }
        }
    }
}
