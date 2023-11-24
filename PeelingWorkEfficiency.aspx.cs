using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AQUA
{
    public partial class PeelingWorkEfficiency : System.Web.UI.Page
    {
        PeelingManagement pMgt = new PeelingManagement();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divDetails.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PeelingWorkEff pwf = new PeelingWorkEff();
            PeelingManagement pMgt = new PeelingManagement();
            bool b = false;
            try
            {

                pwf.PeeledDate = txtDate.Text;
                pwf.S1NoofWorker = txtShift1Workers.Text.Trim();
                pwf.S1NoofHours = txtShift1Hrs.Text.Trim();
                pwf.S1PeeledQty = txtShift1Qty.Text.Trim();
                pwf.S1WorkEfficiency = txtShift1Efficency.Text.Trim();
                pwf.S2NoofWorker = txtShift2Workers.Text.Trim();
                pwf.S2NoofHours = txtShift2Hrs.Text.Trim();
                pwf.S2PeeledQty = txtShift2Qty.Text.Trim();
                pwf.S2WorkEfficiency = txtShift2Efficency.Text.Trim();
                pwf.CreatedBy = Session["UserId"].ToString();
                pwf.UpdatedBy = Session["UserId"].ToString();
                pwf.Remarks = txtRemarks.Text.Trim();
                pwf.AvgHr = txtAvgEff.Text.Trim();

                if (btnSave.Text == "Save")
                { b = pMgt.PeelWorkerEfficiencyInsert(pwf, "1"); }
                else { b = pMgt.PeelWorkerEfficiencyInsert(pwf, "2"); }
                if (b)
                {
                    lblMessage.Text = "Peeling worker efficiency inserted successfully";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtDate.Text = "";
                    clear();
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            txtDate.Text = "";
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }

        private void clear()
        {
            // txtDate.Text = "";
            txtRemarks.Text = "";
            txtShift1Efficency.Text = "";
            txtShift1Hrs.Text = "";
            txtShift1Qty.Text = "";
            txtShift1Workers.Text = "";
            txtShift2Efficency.Text = "";
            txtShift2Hrs.Text = "";
            txtShift2Qty.Text = "";
            txtShift2Workers.Text = "";
            txtAvgEff.Text = "";
            divDetails.Visible = false;
            txtDate.Enabled = true;
            btnView.Enabled = true;

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string s = txtDate.Text;
            try
            {
                DataTable dt = new DataTable();
                dt = pMgt.getWorkEfficiency(s);
                if (dt.Rows.Count > 0)
                {
                    txtShift1Workers.Text = dt.Rows[0]["S1NoOfWorkers"].ToString();
                    txtShift1Hrs.Text = dt.Rows[0]["S1NoOfHours"].ToString();
                    txtShift1Qty.Text = dt.Rows[0]["S1PeeledQty"].ToString();
                    txtShift1Efficency.Text = dt.Rows[0]["S1Eff"].ToString();
                    txtShift2Workers.Text = dt.Rows[0]["S2NoofWorkers"].ToString();
                    txtShift2Hrs.Text = dt.Rows[0]["S2NoOfHours"].ToString();
                    txtShift2Qty.Text = dt.Rows[0]["S2PeeledQty"].ToString();
                    txtShift2Efficency.Text = dt.Rows[0]["S2Eff"].ToString();
                    txtAvgEff.Text = dt.Rows[0]["AvgHr"].ToString();      
                                  
                    txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                    btnSave.Text = "Update";
                }
                else
                {
                    btnSave.Text = "Save";
                }
                divDetails.Visible = true;
                txtDate.Enabled = false;
                btnView.Enabled = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;

            }
            catch (Exception ex)
            { }

        }

        protected void txtShift1Qty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double d = (Convert.ToDouble(txtShift1Workers.Text) * Convert.ToDouble(txtShift1Hrs.Text));
                double d1 = (Convert.ToDouble(txtShift1Qty.Text)) / d;
                txtShift1Efficency.Text = d1.ToString();

                if (txtShift2Efficency.Text != "" && txtShift1Efficency.Text != "")
                    txtAvgEff.Text = ((Convert.ToDouble(txtShift2Efficency.Text) + Convert.ToDouble(txtShift1Efficency.Text)) / 2).ToString();
                else if (txtShift1Efficency.Text != "" && txtShift2Efficency.Text == "")
                    txtAvgEff.Text = txtShift1Efficency.Text;
                else if (txtShift1Efficency.Text == "" && txtShift2Efficency.Text != "")
                    txtAvgEff.Text = txtShift2Efficency.Text;
                else if (txtShift1Efficency.Text == "" && txtShift2Efficency.Text == "")
                    txtAvgEff.Text = "0";
            }
            catch (Exception ex)
            {

            }
        }

        protected void txtShift2Qty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double d = (Convert.ToDouble(txtShift2Workers.Text) * Convert.ToDouble(txtShift2Hrs.Text));
                double d1 = (Convert.ToDouble(txtShift2Qty.Text)) / d;
                txtShift2Efficency.Text = d1.ToString();

                if (txtShift2Efficency.Text != "" && txtShift1Efficency.Text != "")
                    txtAvgEff.Text = ((Convert.ToDouble(txtShift2Efficency.Text) + Convert.ToDouble(txtShift1Efficency.Text)) / 2).ToString();
                else if (txtShift1Efficency.Text != "" && txtShift2Efficency.Text == "")
                    txtAvgEff.Text = txtShift1Efficency.Text;
                else if (txtShift1Efficency.Text == "" && txtShift2Efficency.Text != "")
                    txtAvgEff.Text = txtShift2Efficency.Text;
                else if (txtShift1Efficency.Text == "" && txtShift2Efficency.Text == "")
                    txtAvgEff.Text = "0";

            }
            catch (Exception ex)
            {

            }
        }
    }
}