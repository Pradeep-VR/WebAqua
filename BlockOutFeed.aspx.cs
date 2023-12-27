using System;
using System.Data;
using System.Web.UI.WebControls;


namespace AQUA
{
    public partial class BlockOutFeed : AQUABase
    {
        CommonManagement cMgt = new CommonManagement();
        PackingManagement pMgt = new PackingManagement();
        IQFOutFeedManagement oMgt = new IQFOutFeedManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindDropDown();
                txtUnloadingTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:ss:mm");
                txtUnloadingTime.Enabled = false;
                txtNoOfSlabsLoaded.Enabled = false;
                txtBatchNumber.Enabled = false;

            }
        }


        private void BindDropDown()
        {

            try
            {

                ddlAntibioticStatus.DataSource = cMgt.BindDropDown("Antibiotic");
                ddlAntibioticStatus.DataTextField = "TextField";
                ddlAntibioticStatus.DataValueField = "ValueField";
                ddlAntibioticStatus.DataBind();
                ddlAntibioticStatus.Items.Insert(0, "-Select-");

                ddlFreezerNo.DataSource = pMgt.GetFrezzerNo("1");
                ddlFreezerNo.DataTextField = "MachineNo";
                ddlFreezerNo.DataValueField = "MachineNo";
                ddlFreezerNo.DataBind();
                ddlFreezerNo.Items.Insert(0, "-Select-");

                ddlGrade.Items.Clear();
                ddlGrade.DataSource = null;
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, "-Select-");
            }
            catch (Exception ex) { throw ex; }
        }


        protected void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            lblMessage.Text = "";
            try
            {
                ddlGrade.DataSource = pMgt.GetGradeProductType(ddlFreezerNo.SelectedItem.Value);
                ddlGrade.DataTextField = "GradePT";
                ddlGrade.DataValueField = "GradePT";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, "-Select-");

                bindGrid();
            }
            catch (Exception ex)
            { throw ex; }
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strGrade = "";
            string strProdType = "";
            lblMessage.Text = "";
            try
            {
                string strPackStyleGP = ddlGrade.SelectedItem.Value;
                // Split authors separated by a comma followed by space  
                string[] strGPList = strPackStyleGP.Split('&');
                int a1 = 1;
                foreach (string strGP in strGPList)
                {
                    if (a1 == 1)
                    {
                        a1 = a1 + 1;
                        strGrade = strGP;
                    }
                    else
                    {
                        strProdType = strGP;

                    }
                }

                dt = pMgt.GetblockDetails(ddlFreezerNo.SelectedItem.Value, strGrade.Trim(), strProdType.Trim());
                if (dt.Rows.Count > 0)
                {
                    txtBatchNumber.Text = dt.Rows[0]["Batch"].ToString();
                    txtNoOfSlabsLoaded.Text = dt.Rows[0]["noOfSlabsKeptInFreezer"].ToString();

                }
            }
            catch (Exception ex)
            { throw ex; }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            BlackOFeed block = new BlackOFeed();
            DataTable dt = new DataTable();
            bool b = false;            
            try
            {
                block.freezerNo = ddlFreezerNo.SelectedItem.Value;
                block.OutFeedDate = txtUnloadingTime.Text.Trim();
                block.gradeProductType = ddlGrade.SelectedItem.Value;
                block.batchNumber = txtBatchNumber.Text.Trim();
                block.noofSlabLoaded = txtNoOfSlabsLoaded.Text.Trim();
                block.noofSlabUnLoaded = txtNoOfSlabsUnloaded.Text.Trim();
                block.noofSlabReFre = txtNoOfSlabsgivenForReFreezing.Text.Trim();
                block.noofSlabRej = txtNoOfSlabsRejected.Text.Trim();
                block.noofSlabGoodPack = txtNetGoodSlabsForPacking.Text.Trim();
                block.ActualCount = txtActualCount.Text.Trim();
                block.totQty = txtTotalQuantityGivenForBF.Text.Trim();
                block.AntibioticStatus = ddlAntibioticStatus.SelectedItem.Value;
                block.CreatedBy = "123";
                b = oMgt.BlockOutFeedInsertUpdate(block);
                if (b)
                {
                    lblMessage.Text = "Block Out Feed inserted sucessfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    bindGrid();
                    clear();
                }
                else
                {
                    lblMessage.Text = "Block Out Feed not inserted sucessfully. Please check...";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void bindGrid()
        {            
            DataTable dt = new DataTable();
            try
            {
                dt = oMgt.GetOutFeed(ddlFreezerNo.SelectedItem.Value);
                gvPackSpecDetails.DataSource = dt;
                gvPackSpecDetails.DataBind();

                if (dt.Rows.Count > 0)
                {
                    btnComplete.Visible = true;
                }
                else
                {
                    btnComplete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void clear()
        {

            txtUnloadingTime.Text = "";
            txtBatchNumber.Text = "";
            txtNoOfSlabsLoaded.Text = "";
            txtNoOfSlabsUnloaded.Text = "";
            txtNoOfSlabsgivenForReFreezing.Text = "";
            txtNoOfSlabsRejected.Text = "";
            txtNetGoodSlabsForPacking.Text = "";
            txtActualCount.Text = "";
            txtTotalQuantityGivenForBF.Text = "";
            BindDropDown();

        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            bool b1 = false;
            int count = 0;
            count = gvPackSpecDetails.Rows.Count;
            if (count > 0)
            {
                try
                {

                    for (int i = 0; i < count; i++)
                    {
                        Label lbl = (Label)gvPackSpecDetails.Rows[i].Cells[1].FindControl("lGrade");
                        Label lbl1 = (Label)gvPackSpecDetails.Rows[i].Cells[0].FindControl("lFN");  ///.Cells[1].ToString();   //.FindControl("lGrade").ToString();
                        string strGradePT = lbl.Text;
                        string strFreezerNumber = lbl1.Text;  //gvPackSpecDetails.Rows[i].FindControl("lFN").ToString();
                        b1 = oMgt.BlockOutFeedUpdate(strFreezerNumber, strGradePT);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            gvPackSpecDetails.DataSource = null;
            gvPackSpecDetails.DataBind();

            clear();



        }


        protected void txtNetGoodSlabsForPacking_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNoOfSlabsRejected_TextChanged(object sender, EventArgs e)
        {
            
               
            if (txtNoOfSlabsUnloaded.Text == "")
            {
                txtNoOfSlabsUnloaded.Text = "0";
            }

            if (txtNoOfSlabsgivenForReFreezing.Text == "")
            {
                txtNoOfSlabsgivenForReFreezing.Text = "0";
            }
                
            if (txtNoOfSlabsRejected.Text == "")
            {
                txtNoOfSlabsRejected.Text = "0";
            }
                

            int a = Convert.ToInt32(txtNoOfSlabsUnloaded.Text);
            int b = Convert.ToInt32(txtNoOfSlabsgivenForReFreezing.Text);
            int c = Convert.ToInt32(txtNoOfSlabsRejected.Text);

            int d = a - b;
            d = d - c;
            txtNetGoodSlabsForPacking.Text = d.ToString();

           
        }
    }
}
