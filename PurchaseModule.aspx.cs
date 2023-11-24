using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class PurchaseModule : AQUABase
    {
        PurchaseManagement pMgt = new PurchaseManagement();
        UserManagement uMgt = new UserManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                // bindDropdown();
                bindPurchaseGrid();
                //if (Session["UserType"].ToString() == "admin")
                //{
                divGridView.Visible = true;
                divEntry.Visible = false;
                btnSave.Text = "Save";
                txtEntryBy.Text = Session["UserName"].ToString();
                //}
                //else
                //{
                //    divGridView.Visible = false;
                //    divEntry.Visible = true;
                //    btnSave.Text = "Save";
                //}

            }


            //bindWeightment("ABC00112233");
        }


        private void bindPurchaseGrid()
        {
            DataTable dt = new DataTable();
            dt = pMgt.GetPurchaseDetails("1", "PENDING", "", "");
            gvPurchaseDetails.DataSource = dt;
            gvPurchaseDetails.DataBind();
        }

        private void bindWeightment(string striSupplierName, string strFarmerName)
        {
            DataTable dt = new DataTable();
            dt = pMgt.GetWeightmentDetails(striSupplierName, strFarmerName);
            gvQualityDetails.DataSource = dt;
            gvQualityDetails.DataBind();
            Calculation();
        }

        private void bindDropDownDetails()
        {
            CommonManagement cMgt = new CommonManagement();
            DataTable dt = new DataTable();

            dt = cMgt.BindDropDown("ChemicalUsage");
            ddlChemicalUsage.DataSource = dt;
            ddlChemicalUsage.DataTextField = "TextField";
            ddlChemicalUsage.DataValueField = "ValueField";
            ddlChemicalUsage.DataBind();
            ddlChemicalUsage.Items.Insert(0, "-Select-");


            dt = cMgt.BindDropDown("Weighing");
            ddlWeighCellebration.DataSource = dt;
            ddlWeighCellebration.DataTextField = "TextField";
            ddlWeighCellebration.DataValueField = "ValueField";
            ddlWeighCellebration.DataBind();
            ddlWeighCellebration.Items.Insert(0, "-Select-");

            dt = cMgt.BindDropDown("Cleanliness");
            ddlCleanlines.DataSource = dt;
            ddlCleanlines.DataTextField = "TextField";
            ddlCleanlines.DataValueField = "ValueField";
            ddlCleanlines.DataBind();
            ddlCleanlines.Items.Insert(0, "-Select-");

            dt = cMgt.BindDropDown("Cleanliness");
            ddlCleanliness.DataSource = dt;
            ddlCleanliness.DataTextField = "TextField";
            ddlCleanliness.DataValueField = "ValueField";
            ddlCleanliness.DataBind();
            ddlCleanliness.Items.Insert(0, "-Select-");


            dt = cMgt.BindDropDown("Cleanliness");
            ddlIceCondition.DataSource = dt;
            ddlIceCondition.DataTextField = "TextField";
            ddlIceCondition.DataValueField = "ValueField";
            ddlIceCondition.DataBind();
            ddlIceCondition.Items.Insert(0, "-Select-");



            dt = cMgt.BindDropDown("Gills");
            ddlGills.DataSource = dt;
            ddlGills.DataTextField = "TextField";
            ddlGills.DataValueField = "ValueField";
            ddlGills.DataBind();
            ddlGills.Items.Insert(0, "-Select-");


            dt = cMgt.BindDropDown("ColourShrimp");
            ddllColorShrimp.DataSource = dt;
            ddllColorShrimp.DataTextField = "TextField";
            ddllColorShrimp.DataValueField = "ValueField";
            ddllColorShrimp.DataBind();
            ddllColorShrimp.Items.Insert(0, "-Select-");


            dt = cMgt.BindDropDown("PurchaseType");
            ddlPurchaseType.DataSource = dt;
            ddlPurchaseType.DataTextField = "TextField";
            ddlPurchaseType.DataValueField = "ValueField";
            ddlPurchaseType.DataBind();
            ddlPurchaseType.Items.Insert(0, "-Select-");


            dt = uMgt.BindUserName();
            ddSupervisor.DataSource = dt;
            ddSupervisor.DataTextField = "UserName";
            ddSupervisor.DataValueField = "UserName";
            ddSupervisor.DataBind();
            ddSupervisor.Items.Insert(0, "-Select-");

            //dt = uMgt.BindUserName();
            ddlApprovedBy.DataSource = dt;
            ddlApprovedBy.DataTextField = "UserName";
            ddlApprovedBy.DataValueField = "UserName";
            ddlApprovedBy.DataBind();
            ddlApprovedBy.Items.Insert(0, "-Select-");

            //dt = uMgt.BindUserName();
            ddlApprovedBy.DataSource = dt;
            ddlApprovedBy.DataTextField = "UserName";
            ddlApprovedBy.DataValueField = "UserName";
            ddlApprovedBy.DataBind();
            ddlApprovedBy.Items.Insert(0, "-Select-");


            //DataSet ds = new DataSet();
            //ds = pMgt.SupplierDetails();
            //ddlAgentName.DataSource = ds;
            //ddlAgentName.DataTextField = "SupplierName";
            //ddlAgentName.DataValueField = "SupplierID";
            //ddlAgentName.Items.Insert(0, "-Select-");
            //ddlAgentName.DataBind();

            //ds = pMgt.VillageDetails();
            //ddlVillageName.DataSource = ds;
            //ddlVillageName.DataTextField = "VillageName";
            //ddlVillageName.DataValueField = "ID";
            //ddlVillageName.Items.Insert(0, "-Select-");
            //ddlVillageName.DataBind();

            //ds = pMgt.MandalDetails();
            //ddlMandal.DataSource = ds;
            //ddlMandal.DataTextField = "MandalName";
            //ddlMandal.DataValueField = "ID";
            //ddlMandal.Items.Insert(0, "-Select-");
            //ddlMandal.DataBind();

            //ds = pMgt.DistrictDetails();
            //ddlDistict.DataSource = ds;
            //ddlDistict.DataTextField = "DistrictName";
            //ddlDistict.DataValueField = "ID";
            //ddlDistict.Items.Insert(0, "-Select-");
            //ddlDistict.DataBind();
        }

        protected void gvPurchaseDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvPurchaseDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvPurchaseDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {

            try
            {
                HiddenField lblUName = (HiddenField)gvPurchaseDetails.Rows[e.NewEditIndex].FindControl("hdnID") as HiddenField;
                HiddenField lblLot = (HiddenField)gvPurchaseDetails.Rows[e.NewEditIndex].FindControl("hdnLot") as HiddenField;
                int a = e.NewEditIndex;
                DataTable dt = new DataTable();
                string strPurID = lblUName.Value;
                string strLNo = lblLot.Value;

                PurchaseID.Value = strPurID;
                LotNo.Value = strLNo;
                dt = pMgt.GetPurchaseDetails("2", "PENDING", strPurID, strLNo);
                if (dt.Rows.Count > 0)
                {
                    bindDropDownDetails();
                    txtSaudaNumber.Text = dt.Rows[0]["SaudaNumberCode"].ToString();
                    txtPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
                    ddlPurchaseType.SelectedItem.Text = dt.Rows[0]["PurchaseType"].ToString();
                    txtSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
                    txtVillageName.Text = dt.Rows[0]["Village"].ToString();
                    txtMandalName.Text = dt.Rows[0]["Mandal"].ToString();
                    txtDistictName.Text = dt.Rows[0]["District"].ToString();
                    txtFarmerName.Text = dt.Rows[0]["FarmerName"].ToString();

                    txtBatchNumber.Text = dt.Rows[0]["BatchNumber"].ToString();
                    txtSoftPieces.Text = dt.Rows[0]["noOfSoftPieces"].ToString();
                    txtBlackSpot.Text = dt.Rows[0]["noofPieceswithBlackSpot"].ToString();
                    txtNoNecrosis.Text = dt.Rows[0]["noofpiecesinnecrosis"].ToString();
                    txtDiscolouration.Text = dt.Rows[0]["discoloration"].ToString();
                    txtBrokenPieces.Text = dt.Rows[0]["noOfBrokenPieces"].ToString();


                    txtPurchaseDate.Enabled = false;
                    ddlPurchaseType.Enabled = false;
                    txtSupplierName.Enabled = false;
                    txtVillageName.Enabled = false;
                    txtMandalName.Enabled = false;
                    txtDistictName.Enabled = false;
                    txtFarmerName.Enabled = false;

                    txtSoftPercentage.Enabled = false;
                    txtBrokenPercentage.Enabled = false;
                    txtBlackPer.Enabled = false;
                    txtNecrosisPer.Enabled = false;
                    txtDiscolorationPer.Enabled = false;

                    try
                    {
                        DataSet  dtn = new DataSet();
                        string strNoofPieces = "";
                       dtn =  pMgt.getTotalPieces(strPurID, strLNo);
                        if(dtn.Tables[0].Rows.Count>0)
                        {
                            strNoofPieces = dtn.Tables[0].Rows[0]["Total_Number_of_pieces"].ToString();
                        }


                if (txtSoftPieces.Text == "")
                            txtSoftPieces.Text = "0";
                        if (txtBlackSpot.Text == "")
                            txtBlackSpot.Text = "0";
                        if (txtNoNecrosis.Text == "")
                            txtNoNecrosis.Text = "0";
                        if (txtBrokenPieces.Text == "")
                            txtBrokenPieces.Text = "0";
                        if (txtDiscolouration.Text == "")
                            txtDiscolouration.Text = "0";
                        txtSoftPercentage.Text = Convert.ToString((Convert.ToDouble(txtSoftPieces.Text) / Convert.ToDouble(strNoofPieces)).ToString("0.00"));
                        txtSoftPercentage.Text = (Convert.ToDouble(txtSoftPercentage.Text) * 100).ToString();

                        txtBlackPer.Text = Convert.ToString((Convert.ToDouble(txtBlackSpot.Text) / Convert.ToDouble(strNoofPieces)).ToString("0.00"));
                        txtBlackPer.Text = (Convert.ToDouble(txtBlackPer.Text) * 100).ToString();
                        txtNecrosisPer.Text = Convert.ToString((Convert.ToDouble(txtNoNecrosis.Text) / Convert.ToDouble(strNoofPieces)).ToString("0.00"));
                        txtNecrosisPer.Text = (Convert.ToDouble(txtNecrosisPer.Text) * 100).ToString();
                        txtDiscolorationPer.Text = Convert.ToString((Convert.ToDouble(txtDiscolouration.Text) / Convert.ToDouble(strNoofPieces)).ToString("0.00"));
                        txtDiscolorationPer.Text = (Convert.ToDouble(txtDiscolorationPer.Text) * 100).ToString();
                        txtBrokenPercentage.Text = Convert.ToString((Convert.ToDouble(txtBrokenPieces.Text) / Convert.ToDouble(strNoofPieces)).ToString("0.00"));
                        txtBrokenPercentage.Text = (Convert.ToDouble(txtBrokenPercentage.Text) * 100).ToString();

                        if (txtSoftPercentage.Text == "" || txtSoftPercentage.Text == "∞")
                            txtSoftPercentage.Text = "0";
                        if (txtBlackPer.Text == "" || txtBlackPer.Text == "∞")
                            txtBlackPer.Text = "0";
                        if (txtNecrosisPer.Text == "" || txtNecrosisPer.Text == "∞")
                            txtNecrosisPer.Text = "0";
                        if (txtDiscolorationPer.Text == "" || txtDiscolorationPer.Text == "∞")
                            txtDiscolorationPer.Text = "0";
                        if (txtBrokenPercentage.Text == "" || txtBrokenPercentage.Text == "∞")
                            txtBrokenPercentage.Text = "0";
                    }
                    catch
                    {

                    }
                    if (ddlPurchaseType.SelectedItem.Value == "pond purchase")
                    {
                        txtHarvestStartDate.Enabled = true;
                        txtHarvestEndDate.Enabled = true;
                        txtSerialNo.Enabled = true;
                        txtDriverName.Enabled = true;
                        txtVechicleNumber.Enabled = true;
                        txtDispatchDate.Enabled = true;
                        ddlChemicalUsage.Enabled = true;
                        txtChemicalPercentage.Enabled = true;
                        ddlWeighCellebration.Enabled = true;
                    }
                    else
                    {
                        txtHarvestStartDate.Enabled = false;
                        txtHarvestEndDate.Enabled = false;
                        txtSerialNo.Enabled = false;
                        txtDriverName.Enabled = false;
                        txtVechicleNumber.Enabled = false;
                        txtDispatchDate.Enabled = false;
                        ddlChemicalUsage.Enabled = false;
                        txtChemicalPercentage.Enabled = false;
                        ddlWeighCellebration.Enabled = false;
                    }

                    //  txtFReason2.Text = dt.Rows[0]["MicroFailureReason2"].ToString();


                    dt = pMgt.GetWeightmentDetails(strPurID, strLNo);

                    gvQualityDetails.DataSource = dt;
                    gvQualityDetails.DataBind();
                    dt = pMgt.GetWeightmentDetails(strPurID, strLNo);
                    lblTotalWt.Text = dt.Rows[0]["TotalWeight"].ToString();
                    lblNets.Text = dt.Rows[0]["NETS"].ToString();
                    lblGross.Text = dt.Rows[0]["GrossWeight"].ToString();
                    divGridView.Visible = false;
                    divEntry.Visible = true;
                    btnSave.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }

        }

        private void Calculation()
        {

        }

        private void InsertORUpdte()
        {

        }


        protected void txtSoftPieces_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void txtBlackSpot_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void txtNoNecrosis_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void txtDiscolouration_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void txtBrokenPieces_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase();
            bool b = false;
            try
            {
                if (txtSoftPercentage.Text == "" || txtSoftPercentage.Text == "∞")
                    txtSoftPercentage.Text = "0";
                if (txtBlackPer.Text == "" || txtBlackPer.Text == "∞")
                    txtBlackPer.Text = "0";
                if (txtNecrosisPer.Text == "" || txtNecrosisPer.Text == "∞")
                    txtNecrosisPer.Text = "0";
                if (txtDiscolorationPer.Text == "" || txtDiscolorationPer.Text == "∞")
                    txtDiscolorationPer.Text = "0";
                if (txtBrokenPercentage.Text == "" || txtBrokenPercentage.Text == "∞")
                    txtBrokenPercentage.Text = "0";
                p.saudaNumberCode = txtSaudaNumber.Text.Trim();
                p.lotNumber = LotNo.Value;
                p.purchaseDate = Convert.ToDateTime(txtPurchaseDate.Text.Trim());
                p.purchaseType = ddlPurchaseType.Text.Trim();
                p.supplierName = txtSupplierName.Text.Trim();
                p.farmerName = txtFarmerName.Text.Trim();
                p.pondNumber = txtPondNumber.Text.Trim();
                p.villageName = txtVillageName.Text.Trim();
                p.mandalName = txtMandalName.Text.Trim();
                p.district = txtDistictName.Text.Trim();
                p.batchNumber = txtBatchNumber.Text.Trim();
                p.harvestStartDate = DateTime.Now; //txtHarvestStartDate.Text.Trim();
                p.harvestEndDate = DateTime.Now;//txtHarvestEndDate.Text.Trim();
                p.remarks = txtRemarks.Text.Trim();
                p.supervisedBy = ddSupervisor.SelectedValue.ToString();
                p.approvedBy = ddlApprovedBy.SelectedValue.ToString();
                p.createdDate = DateTime.Now;
                p.createdBy = txtEntryBy.Text.Trim();
                p.status = "1";
                p.sampleWeight = "0";
                p.noofNormalPieces = "0";
                p.noofSmallPieces = "0";
                p.noofsmallAccountedOne = "0";
                p.totalNumberofPieces = "0";
                p.weightDeduction = "0";
                p.countAdjustment = "0";
                p.purchaseCountPerKG = "0";
                p.noOfNets = lblNets.Text.Trim();
                p.tareWeightPerNet = "0";
                p.grossWeight = lblGross.Text.Trim();
                p.totalWeight = lblTotalWt.Text.Trim();
                p.noOfSoftPieces = txtSoftPieces.Text.Trim();
                p.softPer = txtSoftPercentage.Text.Trim();
                p.blackSpot = txtBlackSpot.Text.Trim();
                p.blackPer = txtBlackPer.Text.Trim();
                p.necrosis = txtNoNecrosis.Text.Trim();
                p.necrosisPer = txtNecrosisPer.Text.Trim();
                p.discolouration = txtDiscolouration.Text.Trim();
                p.discolourationPer = txtDiscolorationPer.Text.Trim();
                p.colorofShirmp = ddllColorShrimp.SelectedValue.ToString();
                p.gills = ddlGills.SelectedValue.ToString();
                p.freshness = txtFreshness.Text.Trim();
                p.muddy = txtMuddySmell.Text.Trim();
                p.rmTemp = txtTemerature.Text.Trim();
                p.cleannessOfVechicle = ddlCleanlines.SelectedValue.ToString();
                p.cleannessOfBoxes = ddlCleanliness.SelectedValue.ToString();
                p.ice = ddlIceCondition.SelectedValue.ToString();
                p.brokenPieces = txtBrokenPieces.Text.Trim();
                p.brokenPer = txtBrokenPercentage.Text.Trim();
                b = pMgt.PurchaseInsertUpdate(p, "2");
                if (b)
                {
                    bindPurchaseGrid();
                    divGridView.Visible = true;
                    divEntry.Visible = false;
                }
            }
            catch (Exception ex)
            {
                StringBuilder err = new StringBuilder();
                err.Append(" Message : " + ex.Message);
                err.AppendLine(" STACK TRACE : " + ex.StackTrace);
                err.AppendLine(" INNER EXCEPTION : " + ex.InnerException);
                err.AppendLine(" SOURCE : " + ex.Source);
                Utils.LogError(err.ToString(), Request);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bindPurchaseGrid();
            divGridView.Visible = true;
            divEntry.Visible = false;
        }
    }
}