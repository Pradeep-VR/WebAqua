using AQUA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AQUA
{
    public partial class RMConsumption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                divDetails.Visible = true;
                bindOpenBalance();
                lblMessage.Text = "";
            }
        }

        private void bindOpenBalance()
        {
            DataTable dt = new DataTable();
            RMConsumptionManagement rmcMgt = new RMConsumptionManagement();

            try
            {
                dt = rmcMgt.GetBalance();
                if (dt.Rows.Count > 0)
                {

                    txtOBAdd.Text = (Convert.ToDouble(dt.Rows[0]["CloseAdd"]) + Convert.ToDouble(dt.Rows[0]["QtyAddAdd"])).ToString();
                    txtOBSalt.Text = (Convert.ToDouble(dt.Rows[0]["CloseSalt"]) + Convert.ToDouble(dt.Rows[0]["QtyAddSalt"])).ToString();
                    txtOBChemical.Text = (Convert.ToDouble(dt.Rows[0]["CloseChemical"]) + Convert.ToDouble(dt.Rows[0]["QtyAddChemical"])).ToString();
                }
                else
                {
                    txtOBAdd.Text = "0";
                    txtOBSalt.Text = "0";
                    txtOBChemical.Text = "0";
                }
            }
            catch (Exception ex) { dt = null; }

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            SoakingRMConsumption rmc = new SoakingRMConsumption();
            RMConsumptionManagement rmcMgt = new RMConsumptionManagement();
            try
            {









                rmc.ConsumptionDate = txtDate.Text; ;
                rmc.OBChemical = txtOBChemical.Text;
                rmc.ConChemical = txtConChemical.Text; ;
                rmc.CloseChemical = txtCloseChemical.Text;
                rmc.OBAdd = txtOBAdd.Text;
                rmc.ConAdd = txtConAdd.Text;
                rmc.CloseAdd = txtCloseAdd.Text;
                rmc.OBSalt = txtOBSalt.Text;
                rmc.ConSalt = txtConSalt.Text;
                rmc.CloseSalt = txtCloseSalt.Text;
                rmc.Remarks = txtRemarks.Text;
                rmc.CreatedBy = Session["UserID"].ToString();
                rmc.QtyChemical = txtQuantityChemical.Text.Trim();
                rmc.QtyAdd = txtQuantityAdd.Text.Trim();
                rmc.QtySalt = txtQuantitySalt.Text.Trim();
                rmc.ConsumptionType = ddlType.SelectedItem.Value;
                bool b = rmcMgt.RMConsumptionInsert(rmc);
                if (b)
                {
                    lblMessage.Text = "RM consumption inserted successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    clear();
                    bindOpenBalance();
                }
                else
                {
                    lblMessage.Text = "Please check....";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void clear()
        {
            txtDate.Text = "";
        //   txtOBChemical.Text = "";
            txtConChemical.Text = "";
            txtCloseChemical.Text = "";
          //  txtOBAdd.Text = "";
            txtConAdd.Text = "";
            txtCloseAdd.Text = "";
           // txtOBSalt.Text = "";
            txtConSalt.Text = "";
            txtCloseSalt.Text = "";
            txtRemarks.Text = "";
            txtQuantityAdd.Text = "";
            txtQuantityChemical.Text = "";
            txtQuantitySalt.Text = "";

            divDetails.Visible = true;
            bindOpenBalance();
            lblMessage.Text = "";

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();

        }

        protected void txtOBChemical_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                txtCloseChemical.Text = (Convert.ToDouble(txtOBChemical.Text) - Convert.ToDouble(txtConChemical.Text)).ToString();
            }

            catch (Exception ex)
            {

            }
        }

        protected void txtConChemical_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            try
            {

                //if ((Convert.ToDouble(txtOBChemical.Text) < Convert.ToDouble(txtConChemical.Text)))
                //{
                //    lblMessage.Text = "Please check the chemical consumption quantity";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //}
                //else
                //{
                    txtCloseChemical.Text = (Convert.ToDouble(txtOBChemical.Text) - Convert.ToDouble(txtConChemical.Text)).ToString();
                //}
            }

            catch (Exception ex)
            {

            }



        }

        protected void txtOBAdd_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                txtCloseAdd.Text = (Convert.ToDouble(txtOBAdd.Text) - Convert.ToDouble(txtConAdd.Text)).ToString();
            }

            catch (Exception ex)
            {

            }

        }

        protected void txtConAdd_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {

                //if ((Convert.ToDouble(txtOBAdd.Text) < Convert.ToDouble(txtConAdd.Text)))
                //{
                //    lblMessage.Text = "Please check the Additives consumption quantity";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //}
                //else
                //{
                    txtCloseAdd.Text = (Convert.ToDouble(txtOBAdd.Text) - Convert.ToDouble(txtConAdd.Text)).ToString();
                //}
            }

            catch (Exception ex)
            {

            }
        }

        protected void txtOBSalt_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                txtCloseSalt.Text = (Convert.ToDouble(txtOBSalt.Text) - Convert.ToDouble(txtConSalt.Text)).ToString();
            }
            catch (Exception ex)
            { }
        }

        protected void txtConSalt_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //if ((Convert.ToDouble(txtOBSalt.Text) < Convert.ToDouble(txtConSalt.Text)))
                //{
                //    lblMessage.Text = "Please check the Salt consumption quantity";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //}
                //else
                //{

                    txtCloseSalt.Text = (Convert.ToDouble(txtOBSalt.Text) - Convert.ToDouble(txtConSalt.Text)).ToString();
                //}
            }
            catch (Exception ex)
            {

            }
        }



       

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}