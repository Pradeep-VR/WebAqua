using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AQUA
{

    public partial class IQFOutFeed : System.Web.UI.Page
    {
        PackingManagement pMgt = new PackingManagement();
        IQFOFeed iqf = new IQFOFeed();
        IQFOutFeedManagement iofMgt = new IQFOutFeedManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                BindDropDown();
                txtOutFeedDateTime.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:ss:mm");
            }
        }
        private void BindDropDown()
        {

            try
            {
                CommonManagement cMgt = new CommonManagement();
                ddlAntibioticStatus.DataSource = cMgt.BindDropDown("Antibiotic");
                ddlAntibioticStatus.DataTextField = "TextField";
                ddlAntibioticStatus.DataValueField = "ValueField";
                ddlAntibioticStatus.DataBind();
                ddlAntibioticStatus.Items.Insert(0, "-Select-");
            }
            catch (Exception ex) { }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            lblMessage.Text = "";
            try
            {
                bindIQFData(txtBarcodeID.Text);
                txtOutFeedDateTime.Enabled = false;
                dt = iofMgt.GetOutFeedDetails(txtBarcodeID.Text.Trim());

                if(dt.Rows.Count >0)
                {
                    txtActualCount.Text = dt.Rows[0]["ActualCount"].ToString();
                    txtBlackSpot.Text = dt.Rows[0]["BlackSpot"].ToString();
                    txtBrokenPieces.Text = dt.Rows[0]["BrokenPieces"].ToString();
                    txtBrokenTail.Text = dt.Rows[0]["BrokenTail"].ToString();
                    txtDegWt.Text = dt.Rows[0]["DegiazedWt"].ToString();
                    txtDis.Text = dt.Rows[0]["Discolouration"].ToString();
                    txtGlaze.Text = dt.Rows[0]["Glaze"].ToString();
                    txtNeckMeat.Text = dt.Rows[0]["NeckMeat"].ToString();
                    txtUnifor.Text = dt.Rows[0]["Uniformity"].ToString();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    ddlAntibioticStatus.SelectedValue  = dt.Rows[0]["AntibioticStatus"].ToString(); 
                }

               

            }
            catch (Exception ex)
            { }
        }



        private void bindIQFData(string strBarcode)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = pMgt.GetIQFDetails(strBarcode);
                if (dt.Rows.Count > 0)
                {

                    txtMachineNumber.Text = dt.Rows[0]["MachineNo"].ToString();
                    txtOperationType.Text = dt.Rows[0]["Operation"].ToString();
                    txtGrade.Text = dt.Rows[0]["Grade"].ToString();
                    txtProductType.Text = dt.Rows[0]["ProductType"].ToString();
                    txtBatchNumber.Text = dt.Rows[0]["Batch"].ToString();
                    txtChemicalTreat.Text = "";
                    txtFlatCount.Text = dt.Rows[0]["CheckOfFlatCount"].ToString();
                    txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    txtMachineNumber.Enabled = false;
                    txtOperationType.Enabled = false;
                    txtGrade.Enabled = false;
                    txtProductType.Enabled = false;
                    txtBatchNumber.Enabled = false;
                    txtChemicalTreat.Enabled = false;
                    txtFlatCount.Enabled = false;
                    txtQuantity.Enabled = false;
                }
                else
                {
                    clear();
                    lblMessage.Text = "Invalid Barcode";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            
            DataTable dt = new DataTable();

            try
            {

                if (txtBarcodeID.Text == "")
                {
                    lblMessage.Text = "Please scan / enter the barcode ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;// color.red;

                }
                else
                {
                    iqf.Barcode = txtBarcodeID.Text.Trim();
                    iqf.ActualCount = txtActualCount.Text.Trim();
                    iqf.AntibioticStatus = ddlAntibioticStatus.SelectedItem.Value;
                    iqf.BlackSpot = txtBlackSpot.Text.Trim();
                    iqf.BrokenPieces = txtBrokenPieces.Text.Trim();
                    iqf.BrokenTail = txtBrokenTail.Text;
                    iqf.DegiazedWt = txtDegWt.Text;
                    iqf.Discolouration = txtDis.Text;
                    iqf.Glaze = txtGlaze.Text;
                    iqf.NeckMeat = txtNeckMeat.Text;
                    iqf.OutFeedDate = txtOutFeedDateTime.Text;
                    iqf.Uniformity = txtUnifor.Text;
                    iqf.Remarks = txtRemarks.Text;
                    iqf.CreatedBy = Session["UserName"].ToString();

                    dt = iofMgt.GetOutFeedDetails(txtBarcodeID.Text.Trim());

                    if (dt.Rows.Count == 0)
                    {

                        if (iofMgt.IQFOutFeedInsertUpdate(iqf, "1"))//     .i.QualityInsertUpdate(quality, "1"))
                        {
                            lblMessage.Text = "IQF Out Feed inserted sucessfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            clear();
                        }
                        else
                        {
                            lblMessage.Text = "Out Feed not inserted sucessfully. Please check...";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        if (iofMgt.IQFOutFeedInsertUpdate(iqf, "2"))//     .i.QualityInsertUpdate(quality, "1"))
                        {
                            lblMessage.Text = "IQF Out Feed updated sucessfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            clear();
                        }
                        else
                        {
                            lblMessage.Text = "Out Feed not updated sucessfully. Please check...";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }


                }
            }
            catch (Exception ex)
            { }

        }


        private void clear()
        {
            txtBarcodeID.Text = "";
            txtActualCount.Text = "";
            txtBlackSpot.Text = "";
            txtBrokenPieces.Text = "";
            txtBrokenTail.Text = "";
            txtDegWt.Text = "";
            txtDis.Text = "";
            txtGlaze.Text = "";
            txtNeckMeat.Text = "";          
            txtUnifor.Text = "";
            BindDropDown();
            txtBatchNumber.Text = "";
            txtMachineNumber.Text = "";
            txtOperationType.Text = "";
            txtGrade.Text = "";
            txtProductType.Text = "";
            txtChemicalTreat.Text = "";
            txtBatchNumber.Text = "";
            txtFlatCount.Text = "";
            txtQuantity.Text = "";
            txtRemarks.Text = "";
            txtBarcodeID.Focus();
        }





        protected void btnClose_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}