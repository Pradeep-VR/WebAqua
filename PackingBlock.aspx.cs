using System;
using System.Data;
using System.Web.UI;


namespace AQUA
{

    public partial class PackingBlock : Page
    {
        PackingManagement pMgt = new PackingManagement();
        CommonManagement cMgt = new CommonManagement();
        IQFOutFeedManagement iofMgt = new IQFOutFeedManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                txtBalSlab.Enabled = false;
                txtBalCartonPack.Enabled = false;
                txtBalQtyPacked.Enabled = false;                
                BindDropDown();
                lblMessagePrint.Text = "";
                lblMessage1.Text = "";                
                txtLooseCotton.Enabled = false;

            }
        }


        private void BindDropDown()
        {

            ddlStorage.DataSource = cMgt.BindDropDown("CartonStorage");
            ddlStorage.DataTextField = "TextField";
            ddlStorage.DataValueField = "ValueField";
            ddlStorage.DataBind();
            ddlStorage.Items.Insert(0, "-Select-");
            ddlSlabPack.DataSource = cMgt.BindDropDown("SlabPacking");
            ddlSlabPack.DataTextField = "TextField";
            ddlSlabPack.DataValueField = "ValueField";
            ddlSlabPack.DataBind();
            ddlSlabPack.Items.Insert(0, "-Select-");
            //ddlAntibioticStatus.DataSource = cMgt.BindDropDown("Antibiotic");
            //ddlAntibioticStatus.DataTextField = "TextField";
            //ddlAntibioticStatus.DataValueField = "ValueField";
            //ddlAntibioticStatus.DataBind();
            //ddlAntibioticStatus.Items.Insert(0, "-Select-");


            ddlNextProcess.DataSource = cMgt.BindDropDown("NextProcess");
            ddlNextProcess.DataTextField = "TextField";
            ddlNextProcess.DataValueField = "ValueField";
            ddlNextProcess.DataBind();
            ddlNextProcess.Items.Insert(0, "-Select-");
            //ddlprinting.DataTextField = "TextField";
            //ddlprinting.DataValueField = "ValueField";
            //ddlprinting.DataBind();


        }

        private void bindBlockOutData(string strBarcode)
        {
            DataTable dt;
            try
            {
                dt = pMgt.GetBlockOutFeedDetails(strBarcode);
                if (dt.Rows.Count > 0)
                {
                    txtGlaze.Text = dt.Rows[0]["Glaze"].ToString();
                    txtResult.Text = dt.Rows[0]["AntibioticStatus"].ToString();
                }
            }

            catch (Exception ex)
            {
                dt = null;
            }

        }


        private void bindBlockData(string strBarcode)
        {
            DataTable dt;
            try
            {
                dt = pMgt.GetBlockDetails(strBarcode);
                if (dt.Rows.Count > 0)
                {
                    
                    txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    txtBatchNo.Text = dt.Rows[0]["Batch"].ToString();
                    txtResult.Text = dt.Rows[0]["AntibioticStatus"].ToString();

                    lblMessage1.Text = "Valid Barcode.Please start Packing";
                    lblMessage1.ForeColor = System.Drawing.Color.Green;
                    divPack.Visible = true;
                }
                else
                {
                    lblMessage1.Text = "Invalid Barcode.Please check.";
                    lblMessage1.ForeColor = System.Drawing.Color.Red;
                    txtQuantity.Text = "";
                    txtBatchNo.Text = "";
                    txtGlaze.Text = "";
                    txtResult.Text = "";
                    divPack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }

        }


        protected void ddlSlabPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSlabPack.SelectedItem.Value.ToUpper() == "MATCHED")
            {
                ddlCustOrderNo.DataSource = pMgt.GetPONumberBlock();
                ddlCustOrderNo.DataTextField = "PoNumber";
                ddlCustOrderNo.DataValueField = "PoNumber";
                ddlCustOrderNo.DataBind();
                ddlCustOrderNo.Items.Insert(0, "-Select-");
                ddlCustOrderNo.Enabled = true;
                txtBalSlab.Text = "";
                txtBalCartonPack.Text = "";
                txtBalQtyPacked.Text = "";

                ddlBrand.Enabled = true;

                ddlPackingStyle.Items.Clear();
                ddlPackingStyle.DataBind();

                ddlVariety.Items.Clear();
                ddlVariety.DataBind();
                ddlGrade.Items.Clear();
                ddlGrade.DataBind();

                ddlCustOrderNo.Enabled = true;
                ddlPackingStyle.Enabled = true;
                ddlGrade.Enabled = true;
                ddlVariety.Enabled = true;
                ddlVariety.DataTextField = "TextField";
                ddlVariety.DataValueField = "ValueField";
                ddlVariety.DataBind();
                ddlVariety.Items.Insert(0, "-Select-");

                txtNoOfSlab1Carton.Text = "";
                txtNoOfSlab1Carton.Enabled = false;

                //txtSlabPack.Visible = true;
                //txtSlabPack.Text = "";
                divPS.Visible = false;
                txtPackingStyle.Text = "";
                txtPackingStyle1.Text = "";
                ddlPackingStyle.Visible = true;

            }
            else if (ddlSlabPack.SelectedItem.Value.ToUpper() == "OPEN")
            {
                ddlCustOrderNo.Enabled = false;
                txtBalSlab.Enabled = false;
                txtBalCartonPack.Enabled = false;
                txtBalQtyPacked.Enabled = false;
                ddlPackingStyle.Enabled = false;
                ddlGrade.Enabled = false;

                ddlVariety.Enabled = false;
                ddlBrand.Enabled = false;
                ddlCustOrderNo.Items.Clear();
                ddlPackingStyle.Items.Clear();
                ddlPackingStyle.DataBind();

                ddlVariety.Items.Clear();
                ddlVariety.DataBind();
                ddlGrade.Items.Clear();
                ddlGrade.DataBind();
                ddlBrand.Items.Clear();
                ddlBrand.DataBind();
                txtNoOfSlab1Carton.Text = "";
                txtNoOfSlab1Carton.Enabled = true;

                ddlGlazeSpec.Enabled = true;
                ddlGlazeSpec.DataSource = cMgt.BindDropDown("ddlGlaceSpec");
                ddlGlazeSpec.DataTextField = "TextField";
                ddlGlazeSpec.DataValueField = "ValueField";
                ddlGlazeSpec.DataBind();
                ddlGlazeSpec.Items.Insert(0, "-Select-");
                txtPackingStyle.Enabled = false;
                txtPackingStyle1.Enabled = false;

                divPS.Visible = true;
                txtPackingStyle.Text = "";
                txtPackingStyle1.Text = "";
                //ddlSlabPack.Visible = false;
                //txtSlabPack.Visible = true;
                //txtSlabPack.Text = "";
                ddlPackingStyle.Visible = false;

                txtBalSlab.Text = "";
                txtBalCartonPack.Text = "";
                txtBalQtyPacked.Text = "";
                // txtBrand.Text = "";

            }
        }

        private void bindSoakingTankPrdTyp(string strBarcode)
        {
            DataTable dts;
            try
            {
                dts = pMgt.GetSoakingTankPrdTyp(strBarcode);
                if (dts.Rows.Count > 0)
                {
                    txtsoakingtankPrdTyp.Text = dts.Rows[0]["ProductType"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ddlmchno.Items.Clear();
            DataTable dt = pMgt.GetMachineNumber(txtBarcodeID.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlmchno.Items.Add(dt.Rows[i]["MachineNo"].ToString());
                txtsoakingtankgrade.Text = dt.Rows[0]["Grade"].ToString();
            }
            ddlmchno.Items.Insert(0, "-Select-");
            ddlmchno.SelectedIndex = 0;

            bindSoakingTankPrdTyp(txtBarcodeID.Text);

            lblMessage1.Text = "";
        }

        /*private void bindSoakingTankGrade(string strBarcode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pMgt.GetSoakingTankGrade(strBarcode);
                if (dt.Rows.Count > 0)
                {
                    txtsoakingtankgrade.Text = dt.Rows[0]["soakingtankgrade"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblMessage1.Text = "Invalid Barcode.Please check.";
                lblMessage1.ForeColor = System.Drawing.Color.Red;
                txtQuantity.Text = "";
                txtBatchNo.Text = "";
                txtGlaze.Text = "";
                txtResult.Text = "";
                divPack.Visible = false;
            }
        }*/


        protected void ddlCustOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                //dt = pMgt.GetPackingStyle(ddlCustOrderNo.SelectedItem.Value);
                dt = pMgt.GetBrandBlock(ddlCustOrderNo.SelectedItem.Value);

                if (dt.Rows.Count > 0)
                {

                    //ddlPackingStyle.DataSource = dt;
                    //ddlPackingStyle.DataTextField = "PackingStyle";
                    //ddlPackingStyle.DataValueField = "PackingStyle";
                    //ddlPackingStyle.DataBind();
                    //ddlPackingStyle.Items.Insert(0, "-Select-");
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Brand";
                    ddlBrand.DataValueField = "Brand";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, "-Select-");

                    ddlGrade.Items.Clear();
                    ddlGrade.DataSource = null;
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, "-Select-");

                    ddlVariety.Items.Clear();
                    ddlVariety.DataSource = null;
                    ddlVariety.DataBind();
                    ddlVariety.Items.Insert(0, "-Select-");


                    txtBalSlab.Text = "";
                    txtBalCartonPack.Text = "";
                    txtBalQtyPacked.Text = "";
                    // txtBrand.Text = "";
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }

        protected void ddlStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessagePrint.Text = "";
            if (ddlStorage.SelectedItem.Value.ToUpper() == "FINAL")
            {
                if (ddlSlabPack.SelectedItem.Value.ToUpper() != "OPEN")
                {
                    txtProductionCode.Enabled = false;
                    txtExportCode.Enabled = true;
                    txtNoOfSlab1Carton.Enabled = true;
                    txtBatchNo.Enabled = true;
                    txtNoOfSlab1Carton.Enabled = false;




                    string strPackStyle = ddlPackingStyle.SelectedItem.Value;
                    // Split authors separated by a comma followed by space  
                    string[] strPackStyleList = strPackStyle.Split('*');
                    int a1 = 1;
                    foreach (string sPackStyle in strPackStyleList)
                    {
                        if (a1 == 1)
                        {
                            a1 = a1 + 1;
                            txtNoOfSlab1Carton.Text = sPackStyle;
                        }
                    }
                }
                else
                {
                    lblMessage1.Text = "Please select other storage type";

                }
            }

            if (ddlStorage.SelectedItem.Value.ToUpper() == "DUMMY")
            {
                txtProductionCode.Enabled = true;
                txtExportCode.Enabled = false;
                txtBatchNo.Enabled = false;
                txtNoOfSlab1Carton.Enabled = true;
                txtNoOfSlab1Carton.Text = "";
            }


            string barcode = pMgt.Barcode(ddlStorage.SelectedItem.Value);
            txtBarcodeNumber.Text = barcode;

        }

        protected void btntest_Click(object sender, EventArgs e)
        {
            try
            {
                string zplCommands = "^XA^FO200,200^A0N36,36^FD.^FS^XZ";

                if (ScriptManager.GetCurrent(this) != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "writeToSelectedPrinter('" + zplCommands + "');", true);
                }
                else
                {
                    string script = "<script type='text/javascript'>writeToSelectedPrinter('" + zplCommands + "');</script>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message + "Test Print";
            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string barcode = "";
            try
            {
                if (txtBarcodeID.Text == "")
                {
                    lblMessagePrint.Text = "Please enter the soaking tank Barcode";
                    return;
                }
                if (txtNoLabelPrint.Text == "")
                {
                    lblMessagePrint.Text = "Please enter the number of label Print";
                    return;
                }

                if (txtNoLabelPrint.Text != "")
                {

                    bool b = false;
                    string LooseCotton = "";
                    //int lC = 0;
                    if (txtLooseCotton.Text == "")
                    { LooseCotton = "0"; }
                    else
                    { LooseCotton = txtLooseCotton.Text; }

                    for (int i = 1; i <= Convert.ToInt32(txtNoLabelPrint.Text); i++)
                    {
                        barcode = pMgt.Barcode(ddlStorage.SelectedItem.Value);
                        string s = "";
                        int cnt = i;
                        string Actpackingstyle = txtactpacstyl1.Text + "*" + txtactpacstyl2.Text;

                        if (ddlSlabPack.SelectedItem.Value == "Matched")
                        {
                            
                            b = pMgt.InsertPackingBarcodePrint(txtBarcodeID.Text, txtProductionCode.Text, txtExportCode.Text, txtNoOfSlab1Carton.Text, LooseCotton, ddlSlabPack.SelectedItem.Value, ddlStorage.SelectedItem.Value, barcode, ddlCustOrderNo.SelectedItem.Value, ddlGrade.SelectedItem.Value, ddlVariety.SelectedItem.Value, ddlPackingStyle.SelectedItem.Value, Actpackingstyle ,txtBatchNo.Text.Trim(), Session["UserName"].ToString(), ddlBrand.SelectedItem.Value, "BLOCK" , ddlweightunits.SelectedItem.Text);
                        }
                        else
                        {
                            s = txtPackingStyle.Text + "*" + txtPackingStyle1.Text;
                            DataTable dt = new DataTable();
                            dt = pMgt.GetBLOCKDetails(txtBarcodeID.Text);   
                            string sG = "";
                            string sV = "";
                            if (dt.Rows.Count > 0)
                            {
                                sG = dt.Rows[0]["Grade"].ToString();
                                sV = dt.Rows[0]["ProductType"].ToString();
                            }

                            b = pMgt.InsertPackingBarcodePrintopen(txtBarcodeID.Text, txtProductionCode.Text, txtExportCode.Text, txtNoOfSlab1Carton.Text, LooseCotton, ddlSlabPack.SelectedItem.Value, ddlStorage.SelectedItem.Value, barcode, s, Actpackingstyle, txtBatchNo.Text.Trim(), Session["UserName"].ToString(), sG, sV, "BLOCK",  ddlweightunits.SelectedItem.Text);
                        }
                        if (b)
                        {
                            try
                            {
                                if (ddlStorage.SelectedItem.Value.ToUpper() != "FINAL")
                                {                                    
                                    PrintLabel(barcode, Convert.ToString(cnt));
                                    lblMessagePrint.Text = "Print successfully";
                                    lblMessagePrint.ForeColor = System.Drawing.Color.Green;
                                    
                                }
                                else
                                {
                                    lblMessagePrint.Text = "Print successfully";
                                    lblMessagePrint.ForeColor = System.Drawing.Color.Green;

                                }
                            }
                            catch (Exception ex)
                            {
                                lblMessagePrint.Text = "Packed Sucessfully. Label Print not successfully";
                                lblMessagePrint.ForeColor = System.Drawing.Color.Blue;
                                // lblMessage1.Text = "";
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string zplcmd2 = "";
        private void PrintLabel(string strBarcode, string c)
        {
            DataTable dt = new DataTable();
            string zplCommand;

            string strVariety = "";
            string strGrade = "";
            string strPacking = "";
            string strBrand = "";
            string strordglaze = "";            
            string vluCount = "";
            string vluGlaze = "";
            string vluBatchNo = "";
            string vluOdrGlaze = "";
            string vluGrade = "";
            string vluActPakstyl = "";
            string vluProdCode = "";
            string vluPakstyl = "";
            string vluBrand = "";
            string vluAntibiosts = "";
            string vluPONo = "";
            string vluGlazeSpec = "";
            string vluCTType = "";
            string vluBarCode = "";
            string vluProductTyp = "";

            try
            {

                if (ddlSlabPack.SelectedItem.Value.ToUpper() == "MATCHED")
                {
                    strVariety = ddlVariety.SelectedItem.Value;
                    strGrade = ddlGrade.SelectedItem.Value;
                    strPacking = ddlPackingStyle.SelectedItem.Value;
                    strBrand = ddlBrand.SelectedItem.Value;
                    vluGlazeSpec = ddlGlazeSpec.SelectedItem.ToString();
                    vluPONo = ddlCustOrderNo.SelectedItem.ToString();
                    strordglaze = txtorderglaze.Text.Trim();
                }
                else
                {
                    strVariety = "";
                    strGrade = txtsoakingtankgrade.Text;
                    strPacking = "";
                    strBrand = "";
                    txtorderglaze.Text = "";
                    vluPONo = "";
                    strordglaze = "";
                    vluGlazeSpec = ddlGlazeSpec.SelectedItem.ToString();
                }
                vluCount = "";
                vluGlaze = "";
                vluCTType = ddlStorage.SelectedItem.ToString();
                vluBatchNo = txtBatchNo.Text.Trim();
                vluGrade = strGrade;
                vluOdrGlaze = strordglaze;                
                vluActPakstyl = txtactpacstyl1.Text + "*" + txtactpacstyl2.Text;
                vluProdCode = txtProductionCode.Text.ToString();
                vluPakstyl = strPacking;
                vluBrand = strBrand;
                vluAntibiosts = txtResult.Text;
                vluBarCode = strBarcode;
                dt = iofMgt.GetOutFeedFinalDta(txtBarcodeID.Text.TrimEnd());
                if (dt.Rows.Count > 0)
                {
                    vluProductTyp = dt.Rows[0]["productType"].ToString();
                    dt.Clear();
                }
                dt = iofMgt.GetOutFeedDetails(txtBarcodeID.Text.TrimEnd());
                if (dt.Rows.Count > 0)
                {
                    vluCount = dt.Rows[0]["ActualCount"].ToString();
                    vluGlaze = dt.Rows[0]["Glaze"].ToString() + "%";

                }
                zplCommand = "^XA" +
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
                             "~SD26" +
                             "^JUS" +
                             "^LRN" +
                             "^CI27" +
                             "^PA0,1,1,0" +
                             "^XZ" +
                             "^XA" +
                             "^MMT" +
                             "^PW799" +
                             "^LL599" +
                             "^LS0" +
                             "^FO53,31^GB728,557,4^FS" +
                             "^FO390,166^GB0,421,4^FS" +
                             "^FO54,164^GFA,57,460,92,:Z64:eJz7/x8b+MFADYDVaNLAPxqajQN8wGEjOw3NJgkw4jIbAFeqD9I=:300B" +
                             "^BY2,3,87^FT216,133^BCN,,Y,N" +
                             "^FH\\^FD>:" + vluBarCode + "^FS" +
                             "^FT68,211^A0N,34,33^FH\\^CI28^FDBT No:^FS^CI27" +
                             "^FT215,211^A0N,34,33^FH\\^CI28^FD" + vluBatchNo + "^FS^CI27" +
                             "^FT68,268^A0N,34,33^FH\\^CI28^FDGrade:^FS^CI27" +
                             "^FT215,268^A0N,34,33^FH\\^CI28^FD" + vluGrade + "^FS^CI27" +
                             "^FT68,327^A0N,34,33^FH\\^CI28^FDCount:^FS^CI27" +
                             "^FT216,327^A0N,34,33^FH\\^CI28^FD" + vluCount + "^FS^CI27" +
                             "^FT68,383^A0N,34,33^FH\\^CI28^FDGlaze%:^FS^CI27" +
                             "^FT215,383^A0N,34,33^FH\\^CI28^FD" + vluGlaze + "^FS^CI27" +
                             "^FT68,446^A0N,34,33^FH\\^CI28^FDAct Pac Styl:^FS^CI27" +
                             "^FT259,446^A0N,34,33^FH\\^CI28^FD" + vluActPakstyl + "^FS^CI27" +
                             "^FT68,506^A0N,34,33^FH\\^CI28^FDPROD Code:^FS^CI27" +
                             "^FT264,506^A0N,34,33^FH\\^CI28^FD" + vluProdCode + "^FS^CI27" +
                             "^FT68,563^A0N,34,33^FH\\^CI28^FDAnt/bio Sts:^FS^CI27" +
                             "^FT264,563^A0N,34,33^FH\\^CI28^FD" + vluAntibiosts + "^FS^CI27" +
                             "^FT416,211^A0N,34,33^FH\\^CI28^FDPD Type:^FS^CI27" +
                             "^FT578,211^A0N,34,28^FH\\^CI28^FD" + vluProductTyp + "^FS^CI27" +
                             "^FT416,268^A0N,34,33^FH\\^CI28^FDPO No:^FS^CI27" +
                             "^FT578,268^A0N,34,33^FH\\^CI28^FD" + vluPONo + "^FS^CI27" +
                             "^FT416,327^A0N,34,33^FH\\^CI28^FDOdr Glaze%:^FS^CI27" +
                             "^FT609,327^A0N,34,33^FH\\^CI28^FD" + vluOdrGlaze + "^FS^CI27" +
                             "^FT416,383^A0N,34,33^FH\\^CI28^FDGlz Spc:^FS^CI27" +
                             "^FT609,383^A0N,34,33^FH\\^CI28^FD" + vluGlazeSpec + "^FS^CI27" +
                             "^FT416,446^A0N,34,33^FH\\^CI28^FDBrand:^FS^CI27" +
                             "^FT525,446^A0N,34,33^FH\\^CI28^FD" + vluBrand + "^FS^CI27" +
                             "^FT420,506^A0N,34,33^FH\\^CI28^FDCT Type:^FS^CI27" +
                             "^FT609,506^A0N,34,33^FH\\^CI28^FD" + vluCTType + "^FS^CI27" +
                             "^FT416,563^A0N,34,33^FH\\^CI28^FDPac Styl:^FS^CI27" +
                             "^FT609,563^A0N,34,33^FH\\^CI28^FD" + vluPakstyl + "^FS^CI27" +
                             "^PQ1,0,1,Y" +
                             "^XZ";

                if (zplcmd2 == "")
                {
                    zplcmd2 = zplCommand;
                }
                else
                {
                    zplcmd2 = zplcmd2 + zplCommand;
                }

                if (txtNoLabelPrint.Text == c)
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
                zplCommand = "";

            }
            catch (Exception ex)
            {
                Response.Write("Alert" + ex);
            }
        }


        protected void ddlPackingStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                // dt = pMgt.GetPONumberDetails(ddlCustOrderNo.SelectedItem.Value);
                dt = pMgt.GetGradeBlock(ddlCustOrderNo.SelectedItem.Value, ddlPackingStyle.SelectedItem.Value, ddlBrand.SelectedItem.Value);

                if (dt.Rows.Count > 0)
                {
                    ddlGrade.DataSource = dt;
                    ddlGrade.DataTextField = "Grade";
                    ddlGrade.DataValueField = "Grade";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, "-Select-");
                    ddlVariety.Items.Clear();
                    ddlVariety.DataSource = null;
                    ddlVariety.DataBind();
                    ddlVariety.Items.Insert(0, "-Select-");
                    txtBalSlab.Text = "";
                    txtBalCartonPack.Text = "";
                    txtBalQtyPacked.Text = "";
                    // txtBrand.Text = "";
                    // txtBalSlab.Text = dt.Rows[0]["BalanceSlabs"].ToString();
                    // txtBalCartonPack.Text = dt.Rows[0]["BalanceCartons"].ToString();
                    // txtBalQtyPacked.Text = dt.Rows[0]["BalanceQty"].ToString();
                    // txtPackingStyle.Text = dt.Rows[0]["PackingStyle"].ToString();
                    // txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pMgt.GetVarietyBlock(ddlCustOrderNo.SelectedItem.Value, ddlPackingStyle.SelectedItem.Value, ddlGrade.SelectedItem.Value, ddlBrand.SelectedItem.Value);

                if (dt.Rows.Count > 0)
                {
                    ddlVariety.DataSource = dt;
                    ddlVariety.DataTextField = "Variety";
                    ddlVariety.DataValueField = "Variety";
                    ddlVariety.DataBind();
                    ddlVariety.Items.Insert(0, "-Select-");
                    txtGlaze.Text = dt.Rows[0]["Glaze"].ToString();
                    txtorderglaze.Text = dt.Rows[0]["Glaze"].ToString();

                    txtBalSlab.Text = "";
                    txtBalCartonPack.Text = "";
                    txtBalQtyPacked.Text = "";

                    // txtBalSlab.Text = dt.Rows[0]["BalanceSlabs"].ToString();
                    // txtBalCartonPack.Text = dt.Rows[0]["BalanceCartons"].ToString();
                    // txtBalQtyPacked.Text = dt.Rows[0]["BalanceQty"].ToString();
                    //// txtPackingStyle.Text = dt.Rows[0]["PackingStyle"].ToString();
                    // txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }

        protected void ddlVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessagePrint.Text = "";
            DataTable dt = new DataTable();
            try
            {
                dt = pMgt.GetPONumberDetailsBlock(ddlCustOrderNo.SelectedItem.Value, ddlGrade.SelectedItem.Value, ddlVariety.SelectedItem.Value, ddlPackingStyle.SelectedItem.Value, ddlBrand.SelectedItem.Value);
                if (dt.Rows.Count > 0)
                {
                    txtBalSlab.Text = dt.Rows[0]["BalanceSlabs"].ToString();
                    txtBalCartonPack.Text = dt.Rows[0]["BalanceCartons"].ToString();
                    txtBalQtyPacked.Text = dt.Rows[0]["BalanceQty"].ToString();
                    // txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                    txtBalSlab.Enabled = false;
                    txtBalCartonPack.Enabled = false;
                    txtBalQtyPacked.Enabled = false;
                    //txtBrand.Enabled = false;

                    string strPackStyle = ddlPackingStyle.SelectedItem.Value;
                    // Split authors separated by a comma followed by space  
                    string[] strPackStyleList = strPackStyle.Split('*');
                    int a1 = 1;
                    foreach (string sPackStyle in strPackStyleList)
                    {
                        if (a1 == 1)
                        {
                            a1 = a1 + 1;
                            txtNoOfSlab1Carton.Text = sPackStyle;
                        }
                    }
                }
                ddlVariety1_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }

        protected void ddlVariety1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pMgt.GetGlaxeSpec_BF(ddlCustOrderNo.SelectedItem.ToString(), ddlPackingStyle.SelectedItem.ToString(), ddlGrade.SelectedItem.ToString(), ddlBrand.SelectedItem.ToString(), ddlVariety.SelectedItem.ToString());
                if (dt.Rows.Count > 0)
                {
                    ddlGlazeSpec.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlGlazeSpec.Items.Add(dt.Rows[i]["glazespec"].ToString());
                    }
                    ddlGlazeSpec.Items.Insert(0, "-Select-");
                    //ddlGlazeSpec.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessagePrint.Text = "Submited Sucessfully";
        }
        protected void txtScanBarcode_TextChanged(object sender, EventArgs e)
        {

        }
        protected void chkLooseCarton_CheckedChanged(object sender, EventArgs e)
        {
            lblMessagePrint.Text = "";
            if (chkLooseCarton.Checked)
            {
                divSlab.Visible = true;
                txtLooseCotton.Enabled = true;
                txtLooseCotton.Text = "0";
                txtNoLabelPrint.Text = "";
                txtNoOfSlab1Carton.Text = "0";
            }
            else
            {
                divSlab.Visible = true;
                txtLooseCotton.Enabled = false;
                txtLooseCotton.Text = "";
                txtNoLabelPrint.Text = "";
                txtNoOfSlab1Carton.Text = "0";
            }
        }

        protected void btnScaning_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //lblMessage.Text = "";
            //if (txtScanBarcode.Text.Length == 6)
            //{
            //    dt = pMgt.getDetails(txtScanBarcode.Text.Trim());
            //    if (dt.Rows.Count > 0)
            //    {
            //        string StrSoakingBarcode = "";
            //        string slabtype = dt.Rows[0]["SlabPacking"].ToString();
            //        string PoNumber = dt.Rows[0]["PoNumber"].ToString();
            //        if (slabtype == "Matched")
            //        {
            //            int s = Convert.ToInt32(dt.Rows[0]["NoOfSlabCotton"]);                      
            //            StrSoakingBarcode = dt.Rows[0]["SoakingBarcode"].ToString();
            //            string Grade = dt.Rows[0]["Grade"].ToString();
            //            string Variety = dt.Rows[0]["Variety"].ToString();
            //            string PackingStyle = dt.Rows[0]["PackingStyle"].ToString();
            //            int slab = Convert.ToInt32(dt.Rows[0]["NoofSlabCotton"]);
            //            int BalSlab = 0;
            //            int BalSlabCarton = 0;
            //            int BalQty = 0;
            //            string sta = "";
            //            int diff = 0;
            //            DataTable dt1 = new DataTable();
            //            dt1 = pMgt.GetPONumberDetails(PoNumber, Grade, Variety, PackingStyle);
            //            if (dt1.Rows.Count > 0)
            //            {
            //                BalSlab = Convert.ToInt32(dt1.Rows[0]["BalanceSlabs"].ToString());
            //                BalSlabCarton = Convert.ToInt32(dt1.Rows[0]["BalanceSlabs"].ToString());
            //                BalQty = Convert.ToInt32(dt1.Rows[0]["BalanceSlabs"].ToString());
            //                diff = BalSlab - slab;
            //                if (diff == 0)
            //                    sta = "Closed";
            //                else
            //                    sta = "Open";
            //                bool b2 = pMgt.UpdateBalance(diff.ToString(), (BalSlabCarton - 1).ToString(), "", PoNumber, Grade, Variety, PackingStyle);
            //                bool b1 = pMgt.UpdateScan(txtScanBarcode.Text);
            //                DataTable dCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, "1");
            //                DataTable dLooseCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, "2");
            //                txFullCatPack.Text = dCount.Rows[0]["CartonCount"].ToString();
            //                txtLooseCatPack.Text = dLooseCount.Rows[0]["LooseCartonCount"].ToString();
            //            }
            //        }
            //        else
            //        {
            //            bool b1 = pMgt.UpdateScan(txtScanBarcode.Text);
            //            DataTable dCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, "1");
            //            DataTable dLooseCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, "2");
            //            txFullCatPack.Text = dCount.Rows[0]["CartonCount"].ToString();
            //            txtLooseCatPack.Text = dLooseCount.Rows[0]["LooseCartonCount"].ToString();
            //        }
            //    }
            //}
            //if (txtScanBarcode.Text.Length == 11)
            ////{
            //dt = pMgt.getDetails(txtScanBarcode.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    string StrSoakingBarcode = "";
            //    string slabtype1 = dt.Rows[0]["SlabPacking"].ToString();
            //    StrSoakingBarcode = dt.Rows[0]["SoakingBarcode"].ToString();
            //    string PoNumber = dt.Rows[0]["PoNumber"].ToString();
            //    string Grade = dt.Rows[0]["Grade"].ToString();
            //    string Variety = dt.Rows[0]["Variety"].ToString();
            //    string PackingStyle = dt.Rows[0]["PackingStyle"].ToString();
            //    string LCarton = dt.Rows[0]["LooseCotton"].ToString();
            //    string StorageType = dt.Rows[0]["StorageType"].ToString();
            //    string Brand = dt.Rows[0]["Brand"].ToString();
            //    int slab = 0;
            //    if (slabtype1 == "Matched")
            //    {
            //        int s = Convert.ToInt32(dt.Rows[0]["NoOfSlabCotton"]);
            //        if (chkLooseCarton.Checked)
            //            slab = Convert.ToInt32(txtLooseCotton.Text);
            //        else
            //            slab = Convert.ToInt32(dt.Rows[0]["NoofSlabCotton"]);

            //        int BalSlab = 0;
            //        int BalSlabCarton = 0;
            //        double BalQty = 0;
            //        string sta = "";
            //        int Matched = 0;
            //        int noofslab = 0;
            //        int diff = 0;
            //        int CartonPacked = 0, CartonRepack = 0, CartonBalRepack = 0;
            //        DataTable dt1 = new DataTable();
            //        dt1 = pMgt.GetPONumberDetails(PoNumber, Grade, Variety, PackingStyle, Brand);
            //        if (dt1.Rows.Count > 0)
            //        {
            //            BalSlab = Convert.ToInt32(dt1.Rows[0]["BalanceSlabs"].ToString());
            //            noofslab = Convert.ToInt32(dt1.Rows[0]["Noofslabs"].ToString());
            //            Matched = Convert.ToInt32(dt1.Rows[0]["Matchedfromopen"].ToString());
            //            BalSlabCarton = Convert.ToInt32(dt1.Rows[0]["BalanceCartons"].ToString());
            //            BalQty = Convert.ToDouble(dt1.Rows[0]["BalanceQty"].ToString());

            //            CartonPacked = Convert.ToInt32(dt1.Rows[0]["CartonPacked"].ToString());
            //            CartonRepack = Convert.ToInt32(dt1.Rows[0]["CartonRepack"].ToString());
            //            CartonBalRepack = Convert.ToInt32(dt1.Rows[0]["CartonBalRepack"].ToString());

            //            double BalQtyCal = 0;
            //            double balstyle = 0;


            //            string[] strPackStyleList = PackingStyle.Split('*');
            //            int a1 = 1;
            //            foreach (string sPackStyle in strPackStyleList)
            //            {
            //                if (a1 == 1)
            //                {
            //                    a1 = a1 + 1;
            //                    BalQtyCal = Convert.ToDouble(sPackStyle);
            //                }
            //                else
            //                {
            //                    balstyle = Convert.ToDouble(sPackStyle);
            //                }
            //            }
            //            string k = pMgt.getDetailsFresh(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, Brand);
            //            CartonPacked = Convert.ToInt32(k) + CartonPacked;
            //            CartonRepack = 0;

            //            CartonBalRepack = Matched - CartonPacked - CartonRepack;

            //            bool b1 = pMgt.UpdateScan(txtScanBarcode.Text);
            //            string sYes = pMgt.YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "yes", Brand);
            //            string sToday = pMgt.YesterdayTodayCount(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "Scanned", "today", Brand);
            //            diff = noofslab - Matched - Convert.ToInt32(sYes) - Convert.ToInt32(sToday);
            //            double balcot = 0;
            //            if (LCarton == "0")
            //                balcot = diff / BalQtyCal;
            //            else
            //                balcot = BalSlabCarton;

            //            BalQty = (diff * balstyle);
            //            // diff = BalSlab - slab;
            //            if (diff == 0)
            //                sta = "Closed";
            //            else
            //                sta = "Open";
            //            CartonPacked = 0;

            //            bool b2 = pMgt.UpdateBalance(diff.ToString(), balcot.ToString(), BalQty.ToString(), PoNumber, Grade, Variety, PackingStyle, sta, sYes, sToday, CartonPacked.ToString(), CartonRepack.ToString(), CartonBalRepack.ToString(), Brand);
            //            DataTable dCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "1", Brand);
            //            DataTable dLooseCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "2", Brand);
            //            txFullCatPack.Text = dCount.Rows[0]["CartonCount"].ToString();
            //            txtLooseCatPack.Text = dLooseCount.Rows[0]["LooseCartonCount"].ToString();
            //        }
            //    }
            //    else
            //    {
            //        bool b1 = pMgt.UpdateScan(txtScanBarcode.Text);
            //        DataTable dCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "1", Brand);
            //        DataTable dLooseCount = pMgt.getPackingDetails(StrSoakingBarcode, PoNumber, Grade, Variety, PackingStyle, "2", Brand);
            //        txFullCatPack.Text = dCount.Rows[0]["CartonCount"].ToString();
            //        txtLooseCatPack.Text = dLooseCount.Rows[0]["LooseCartonCount"].ToString();
            //    }
            //}
            //else
            //{
            //    lblMessage.Text = "The Barcode already scanned / Invalid Barcode";
            //    lblMessage.ForeColor = System.Drawing.Color.Red;
            //}
            ////}
        }



        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = pMgt.GetPackingStyleBlock(ddlCustOrderNo.SelectedItem.Value, ddlBrand.SelectedItem.Value);

                // dt = pMgt.GetBrand(ddlCustOrderNo.SelectedItem.Value);

                if (dt.Rows.Count > 0)
                {

                    ddlPackingStyle.DataSource = dt;
                    ddlPackingStyle.DataTextField = "PackingStyle";
                    ddlPackingStyle.DataValueField = "PackingStyle";
                    ddlPackingStyle.DataBind();
                    ddlPackingStyle.Items.Insert(0, "-Select-");



                    //ddlBrand.DataSource = dt;
                    //ddlBrand.DataTextField = "Brand";
                    //ddlBrand.DataValueField = "Brand";
                    //ddlBrand.DataBind();
                    //ddlBrand.Items.Insert(0, "-Select-");
                    
                    ddlGrade.Items.Clear();
                    ddlGrade.DataSource = null;
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, "-Select-");

                    ddlVariety.Items.Clear();
                    ddlVariety.DataSource = null;
                    ddlVariety.DataBind();
                    ddlVariety.Items.Insert(0, "-Select-");


                    txtBalSlab.Text = "";
                    txtBalCartonPack.Text = "";
                    txtBalQtyPacked.Text = "";

                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
        }

        protected void ddlmchno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bindBlockData(txtBarcodeID.Text);
                bindBlockOutData(txtBarcodeID.Text);
                //bindSoakingTankGrade(txtBarcodeID.Text);
                //txtPackDateTime.Text = System.DateTime.Now.ToString();
                //txtPackDateTime.Enabled = false;
                txtBalSlab.Enabled = false;
                txtBalCartonPack.Enabled = false;
                txtBalQtyPacked.Enabled = false;
                //txtBrand.Enabled = false;
                BindDropDown();
                //txtPackDateTime.Text = System.DateTime.Now.ToString("dd/MM/yyyy HH:ss:mm");
                lblMessagePrint.Text = "";
                lblMessage1.Text = "";
                //lblMessage.Text = "";
                //txFullCatPack.Text = "0";
                //txFullCatPack.Enabled = false;
                //txtLooseCatPack.Text = "0";
                //txtLooseCatPack.Enabled = false;
            }
            catch (Exception ex)
            { }
        }

        protected void ddlNextProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlweightunits.DataSource = cMgt.BindDropDown("WeightUnit");
            ddlweightunits.DataTextField = "TextField";
            ddlweightunits.DataValueField = "ValueField";
            ddlweightunits.DataBind();
            ddlweightunits.Items.Insert(0, "-Select-");
        }
    }

}