using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class PackingSpecification : AQUABase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                btnSave.Text = "Save";
                txtBuyerName.Text = "";
                txtPONumber.Text = "";
                txtCargoNo.Text = "";
                txtBrand.Text = "";
                txtPackingStyle1.Text = "";
                bindDropdown();
                txtBalQty.Enabled = false;
                txtSlabsToday.Enabled = false;
                txtSlabsYes.Enabled = false;
                txtBalRepack.Enabled = false;
                txtFinalProduction.Enabled = false;
                txtRepack.Enabled = false;
                txtBalanceSlab.Enabled = false;
                txtBalanceCartons.Enabled = false;
                lblStatus.Text = "";
                txtBalQty.Text = "0";
                txtSlabsToday.Text = "0";
                txtSlabsYes.Text = "0";
                txtBalRepack.Text = "0";
                txtFinalProduction.Text = "0";
                txtRepack.Text = "0";
                txtBalanceSlab.Text = "0";
                txtBalanceCartons.Text = "0";
                txtMatchedFromOpen.Text = "0";

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PackSpecification PS = new PackSpecification();
            PackingManagement pMgt = new PackingManagement();

            try
            {

                PS.BuyerName = txtBuyerName.Text.Trim();
                PS.PONumber = txtPONumber.Text.Trim();
                PS.CargoNo = txtCargoNo.Text.Trim();
                PS.Brand = txtBrand.Text.Trim();
                PS.PackingStyle = txtPackingStyle.Text + "*" + txtPackingStyle1.Text;
                PS.PackingType = ddlPackingType.SelectedItem.Value;
                PS.Glaze = txtGlaze.Text.Trim() + "%";
                PS.Unit = ddlUnitMeasurement.SelectedItem.Value;
                PS.Grade = ddlGrade.SelectedItem.Text;
                PS.Variety = ddlVariety.SelectedItem.Text;
                PS.TargetCount = Convert.ToInt32(txtTargetCount.Text.Trim());
                PS.OrderQty = Convert.ToInt32(txtOrderQty.Text.Trim());
                PS.NoofSlabs = Convert.ToInt32(txtNoOfSlabs.Text.Trim());
                PS.MatchedfromOpen = Convert.ToInt32(txtMatchedFromOpen.Text.Trim());
                PS.NoofSlabsYesterday = Convert.ToInt32(txtSlabsYes.Text.Trim());
                PS.NoofSlabsToday = Convert.ToInt32(txtSlabsToday.Text.Trim());
                PS.BalanceSlabs = Convert.ToInt32(txtBalanceSlab.Text.Trim());
                PS.BalanceCartons = Convert.ToInt32(txtBalanceCartons.Text.Trim());
                PS.CartonPacked = Convert.ToInt32(txtFinalProduction.Text.Trim());
                PS.CartonRepack = Convert.ToInt32(txtRepack.Text.Trim());
                PS.CartonBalRepack = Convert.ToInt32(txtBalRepack.Text.Trim());
                PS.ChemicalTreatment = ddlChemical.SelectedItem.Value;
                PS.Remarks = txtRemarks.Text.Trim();
                PS.BalanceQty = Convert.ToDouble(txtBalQty.Text.Trim());
                PS.GlazeSpec = ddlGlaceSpec.SelectedItem.Value;

                if (txtBalQty.Text == "0")
                {
                    PS.RepackStatus = "Open";
                    PS.Packingstatus = "Closed";
                }
                else
                {
                    PS.RepackStatus = "Open";
                    PS.Packingstatus = "Open";
                }

                PS.VerifiedBy = Session["UserName"].ToString();

                if (btnSave.Text == "Save")
                {
                    if (pMgt.PackageInsertUpdate(PS, "1"))
                    {
                        lblStatus.Text = "Packing Specification inserted Sucessfully";
                        bindPackingSpecification("1", txtPONumber.Text.Trim());
                        //Clear();
                        bindGrade();
                    }
                    else
                    {
                        lblStatus.Text = "Some internal issue please check.";
                    }
                }
                else
                {
                    PS.PackID = hdnPackID.Value;
                    if (pMgt.PackageInsertUpdate(PS, "2"))
                    {
                        lblStatus.Text = "Packing Specification updated Sucessfully";
                        bindPackingSpecification("1", txtPONumber.Text.Trim());
                       Clear();
                    }
                    else
                    {
                        lblStatus.Text = "Some internal issue please check.";
                    }
                }
            }
            catch (Exception ex)
            { }
        }




        private void bindPackingSpecification(string strAction, string strPid)
        {
            DataTable dt = new DataTable();
            try
            {
                PackingManagement pMgt = new PackingManagement();

                //if (strAction == "1")
                //{
                dt = pMgt.GetPackingSpecificationPO(strAction, strPid);
                if (dt.Rows.Count > 0)
                {
                    gvPackSpecDetails.DataSource = dt;
                    gvPackSpecDetails.DataBind();

                    txtBuyerName.Text = dt.Rows[0]["BuyerName"].ToString();
                    txtCargoNo.Text = dt.Rows[0]["CargoNumber"].ToString();
                    txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                }
                else
                {
                    gvPackSpecDetails.DataSource = null;
                    gvPackSpecDetails.DataBind();
                    txtBuyerName.Text = "";
                    txtCargoNo.Text = "";
                    txtBrand.Text = "";
                }
                //}


                //if (strAction == "2")
                //{
                //    dt = pMgt.GetPackingSpecificationPO(strAction, strPid);
                //    if (dt.Rows.Count > 0)
                //    {
                //        gvPackSpecDetails.DataSource = dt;
                //        gvPackSpecDetails.DataBind();

                //        txtBuyerName.Text = dt.Rows[0]["BuyerName"].ToString();
                //        txtCargoNo.Text = dt.Rows[0]["CargoNumber"].ToString();
                //        txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                //        txtPONumber.Text = dt.Rows[0]["Brand"].ToString();
                //        txtPackingStyle.Text= dt.Rows[0]["Brand"].ToString();


                //    }

                //    else
                //    {
                //        gvPackSpecDetails.DataSource = null;
                //        gvPackSpecDetails.DataBind();
                //    }
                //}

            }
            catch (Exception ex)
            {

            }
        }

        private void bindDropdown()
        {
            try
            {
                CommonManagement cMgt = new CommonManagement();
                ddlGrade.DataSource = cMgt.BindGrade();
                ddlGrade.DataTextField = "GradeName";
                ddlGrade.DataValueField = "ID";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, "-Select-");
                ddlVariety.DataSource = cMgt.BindVariety();
                ddlVariety.DataTextField = "Variety";
                ddlVariety.DataValueField = "ID";
                ddlVariety.DataBind();
                ddlVariety.Items.Insert(0, "-Select-");


                ddlPackingType.DataSource = cMgt.BindDropDown("PackingType");
                ddlPackingType.DataTextField = "TextField";
                ddlPackingType.DataValueField = "ValueField";
                ddlPackingType.DataBind();
                ddlPackingType.Items.Insert(0, "-Select-");

                ddlChemical.DataSource = cMgt.BindDropDown("ChemicalTreat");
                ddlChemical.DataTextField = "TextField";
                ddlChemical.DataValueField = "ValueField";
                ddlChemical.DataBind();
                ddlChemical.Items.Insert(0, "-Select-");

                ddlUnitMeasurement.DataSource = cMgt.BindDropDown("Unit");
                ddlUnitMeasurement.DataTextField = "TextField";
                ddlUnitMeasurement.DataValueField = "ValueField";
                ddlUnitMeasurement.DataBind();
                ddlUnitMeasurement.Items.Insert(0, "-Select-");

                ddlGlaceSpec.DataSource = cMgt.BindDropDown("ddlGlaceSpec");
                ddlGlaceSpec.DataTextField = "TextField";
                ddlGlaceSpec.DataValueField = "ValueField";
                ddlGlaceSpec.DataBind();
                ddlGlaceSpec.Items.Insert(0, "-Select-");              


            }
            catch (Exception ex)
            {

            }

        }

        private void bindGrade()
        {
            CommonManagement cMgt = new CommonManagement();
            ddlGrade.DataSource = cMgt.BindGrade();
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "ID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, "-Select-");

            txtBalQty.Text = "0";
            txtSlabsToday.Text = "0";
            txtSlabsYes.Text = "0";
            txtBalRepack.Text = "0";
            txtFinalProduction.Text = "0";
            txtRepack.Text = "0";
            txtBalanceSlab.Text = "0";
            txtBalanceCartons.Text = "0";
            txtMatchedFromOpen.Text = "0";
            txtOrderQty.Text = "";
            
            txtNoOfSlabs.Text = "";
        }

        private void Clear()
        {

            txtPackingStyle.Text = "";
            txtGlaze.Text = "";
            txtRemarks.Text = "";
            txtTargetCount.Text = "";
            txtOrderQty.Text = "";
            txtPackingStyle1.Text = "";
            txtNoOfSlabs.Text = "";           
            bindDropdown();
            txtPONumber.Text = "";
            txtBrand.Text = "";
            txtBuyerName.Text = "";
            txtCargoNo.Text = "";
            txtBalQty.Text = "0";
            txtSlabsToday.Text = "0";
            txtSlabsYes.Text = "0";
            txtBalRepack.Text = "0";
            txtFinalProduction.Text = "0";
            txtRepack.Text = "0";
            txtBalanceSlab.Text = "0";
            txtBalanceCartons.Text = "0";
            txtMatchedFromOpen.Text = "0";
            //gvPackSpecDetails.DataSource = null;
            //gvPackSpecDetails.DataBind();
            btnSave.Text = "Save";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        [WebMethod]
        protected void getPonumberDetails(string ponumber)
        {
            try
            {
                bindPackingSpecification("1", ponumber);
            }
            catch
            {

            }
        }
        protected void txtPONumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtPONumber.Text == "") { }
                else
                {
                    bindPackingSpecification("1", txtPONumber.Text.Trim());
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        protected void txtOrderQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int noOfSlabs = Convert.ToInt32(txtPackingStyle.Text) * Convert.ToInt32(txtOrderQty.Text);
                txtNoOfSlabs.Text = noOfSlabs.ToString();
                int balanceSlab = Convert.ToInt32(txtNoOfSlabs.Text) - Convert.ToInt32(txtMatchedFromOpen.Text) - Convert.ToInt32(txtSlabsToday.Text) - Convert.ToInt32(txtSlabsYes.Text);
                txtBalanceSlab.Text = balanceSlab.ToString();
                txtBalanceCartons.Text = (balanceSlab / Convert.ToInt32(txtPackingStyle.Text)).ToString();

                txtBalQty.Text = (balanceSlab * Convert.ToDouble(txtPackingStyle1.Text)).ToString();
                txtBalRepack.Text = (Convert.ToInt32(txtNoOfSlabs.Text) / Convert.ToInt32(txtPackingStyle.Text)).ToString();

            }
            catch (Exception ex)
            {

            }
        }

        protected void txtMatchedFromOpen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int balanceSlab = Convert.ToInt32(txtNoOfSlabs.Text) - Convert.ToInt32(txtMatchedFromOpen.Text) - Convert.ToInt32(txtSlabsToday.Text) - Convert.ToInt32(txtSlabsYes.Text) ;
                txtBalanceSlab.Text = balanceSlab.ToString();
                txtBalanceCartons.Text = (balanceSlab / Convert.ToInt32(txtPackingStyle.Text)).ToString();
                txtBalQty.Text = (balanceSlab * Convert.ToDouble(txtPackingStyle1.Text)).ToString();
                txtBalRepack.Text = (Convert.ToInt32(txtNoOfSlabs.Text) / Convert.ToInt32(txtPackingStyle.Text)).ToString();
            }
            catch (Exception ex)
            {

            }
        }


        protected void gvPackSpecDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PackSpecification PS = new PackSpecification();
            PackingManagement pMgt = new PackingManagement();
            try
            {
                HiddenField lblPackID = (HiddenField)gvPackSpecDetails.Rows[e.NewEditIndex].FindControl("hdnID") as HiddenField;

                int a = e.NewEditIndex;
                DataTable dt = new DataTable();
                
                string strPackID = lblPackID.Value;
                hdnPackID.Value = strPackID;
                dt = pMgt.GetPackingSpecificationPO("2", strPackID);


                if (dt.Rows.Count > 0)
                {
                    btnSave.Text = "Update";
                    txtBuyerName.Text = dt.Rows[0]["BuyerName"].ToString();
                    txtPONumber.Text = dt.Rows[0]["PONumber"].ToString();
                    txtCargoNo.Text = dt.Rows[0]["CargoNumber"].ToString();
                    txtBrand.Text = dt.Rows[0]["Brand"].ToString();

                    string strPackStyle = dt.Rows[0]["PackingStyle"].ToString();
                    // Split authors separated by a comma followed by space  
                    string[] strPackStyleList = strPackStyle.Split('*');
                    int a1 = 1;
                    foreach (string sPackStyle in strPackStyleList)
                    {
                        if(a1 ==1)
                        {
                            a1 = a1 + 1;
                            txtPackingStyle.Text  = sPackStyle;
                        }
                        else
                        {
                            txtPackingStyle1.Text = sPackStyle;
                        }
                    }
                    //txtPackingStyle.Text = dt.Rows[0]["PackingStyle"].ToString();
                    //txtPackingStyle1.Text = dt.Rows[0]["PackingStyle"].ToString();
                    ddlPackingType.SelectedItem.Text = dt.Rows[0]["PackingType"].ToString(); ;
                    txtGlaze.Text = dt.Rows[0]["Glaze"].ToString();
                    ddlUnitMeasurement.SelectedItem.Text = dt.Rows[0]["Unit"].ToString();
                    ddlGrade.SelectedItem.Text = dt.Rows[0]["Grade"].ToString();
                    ddlVariety.SelectedItem.Text = dt.Rows[0]["Variety"].ToString();
                    txtTargetCount.Text = dt.Rows[0]["TargetCount"].ToString();
                    txtOrderQty.Text = dt.Rows[0]["OrderQty"].ToString();
                    txtNoOfSlabs.Text = dt.Rows[0]["NoofSlabs"].ToString();
                    txtMatchedFromOpen.Text = dt.Rows[0]["MatchedfromOpen"].ToString();
                    txtSlabsYes.Text = dt.Rows[0]["NoofSlabsYesterday"].ToString();
                    txtSlabsToday.Text = dt.Rows[0]["NoofSlabsToday"].ToString();
                    txtBalanceSlab.Text = dt.Rows[0]["BalanceSlabs"].ToString();
                    txtBalanceCartons.Text = dt.Rows[0]["BalanceCartons"].ToString();
                    txtBalQty.Text = dt.Rows[0]["BalanceQty"].ToString();
                    txtFinalProduction.Text = dt.Rows[0]["CartonPacked"].ToString();
                    txtRepack.Text = dt.Rows[0]["CartonRepack"].ToString();
                    txtBalRepack.Text = dt.Rows[0]["CartonBalRepack"].ToString();
                    ddlChemical.SelectedItem.Text = dt.Rows[0]["ChemicalTreatment"].ToString();
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
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
    }
}