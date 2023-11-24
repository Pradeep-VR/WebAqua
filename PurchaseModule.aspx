<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PurchaseModule.aspx.cs" EnableViewState="true" Inherits="AQUA.PurchaseModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>
            <%-- divEntry--%>
            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <h4 class="header green">Purchase Module</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <%-- <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Purchase Information</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Purchase Information</h5>

                                <div class="row mb-0">
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <asp:HiddenField ID="PurchaseID" runat="server" />
                                            <asp:HiddenField ID="LotNo" runat="server" />
                                            <label for="fname">Sauda Number</label>
                                            <asp:TextBox ID="txtSaudaNumber" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="rfvSaudaNumber" Display="Dynamic" runat="server" ErrorMessage=" Please enter Sauda Number" ControlToValidate="txtSaudaNumber" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Purchase Date</label>
                                            <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="rfvPurchaseDate" Display="Dynamic" runat="server" ErrorMessage=" Please select Purchase Date" ControlToValidate="txtPurchaseDate" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Purchase Type</label>
                                            <asp:DropDownList ID="ddlPurchaseType" runat="server" CssClass="form-control border border-success">
                                                <%--      <asp:ListItem Text="select Purchase Type Here" Value="0" />
                                                        <asp:ListItem Text="Pond" Value="Pond" />
                                                        <asp:ListItem Text="Factory" Value="Factory" />--%>
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="rfvPurchaseType" Display="Dynamic" runat="server" ErrorMessage=" Please select the Purchase Number" ControlToValidate="ddlPurchaseType" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Agent / Supplier Name</label>
                                            <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control border border-success" />


                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage=" Please select the Agent Name" ControlToValidate="txtSupplierName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="space-6"></div>
                                <div class="row mb-0">

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Farmer Name</label>
                                            <asp:TextBox ID="txtFarmerName" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Farmer Name" ControlToValidate="txtFarmerName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Pond Registration Number</label>
                                            <asp:TextBox ID="txtPondNumber" runat="server" CssClass="form-control border border-success" />


                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Village Name</label>
                                            <asp:TextBox ID="txtVillageName" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="rfvVillageName" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Village Name" ControlToValidate="txtVillageName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Mandal Name</label>
                                            <asp:TextBox ID="txtMandalName" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="rfvMandal" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Mandal Name" ControlToValidate="txtMandalName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="space-6"></div>
                                <div class="row mb-0">

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Distict Name</label>
                                            <asp:TextBox ID="txtDistictName" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="rfvDistict" Display="Dynamic" runat="server" ErrorMessage=" Please select the distict" ControlToValidate="txtDistictName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Batch Number</label>
                                            <asp:TextBox ID="txtBatchNumber" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ErrorMessage=" Please enter the batch number" ControlToValidate="txtBatchNumber" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Harvest Start Date</label>
                                            <asp:TextBox ID="txtHarvestStartDate" runat="server" TextMode="DateTimeLocal" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Harvest Start Date" ControlToValidate="txtHarvestStartDate" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Harvest End Date</label>
                                            <asp:TextBox ID="txtHarvestEndDate" runat="server" TextMode="DateTimeLocal" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ErrorMessage=" Please select Harvest End Date" ControlToValidate="txtHarvestEndDate" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>

                                <div class="space-6"></div>

                                <div class="row mb-0">
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Serial No</label>
                                            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage=" Please enter the serial number" ControlToValidate="txtSerialNo" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Driver Name</label>
                                            <asp:TextBox ID="txtDriverName" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Driver Name" ControlToValidate="txtDriverName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Vechicle Number</label>
                                            <asp:TextBox ID="txtVechicleNumber" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Vechicle number" ControlToValidate="txtVechicleNumber" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Dispatch Date</label>
                                            <asp:TextBox ID="txtDispatchDate" runat="server" TextMode="DateTimeLocal" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage=" Please select the dispatch date" ControlToValidate="txtDispatchDate" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="row mb-0">
                                    <div class="space-6"></div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Chemical Usage</label>
                                            <%--<asp:TextBox ID="txtChemicalUsage" runat="server" CssClass="form-control border border-success" placeholder="Purchase Date" />--%>
                                            <asp:DropDownList ID="ddlChemicalUsage" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage=" Please select the chemical useage" ControlToValidate="ddlChemicalUsage" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Chemical Usage %</label>
                                            <asp:TextBox ID="txtChemicalPercentage" runat="server" CssClass="form-control border border-success" placeholder="Chemical Usage %" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" InitialValue="0" ErrorMessage=" Please enter the chemical usage %" ControlToValidate="txtChemicalPercentage" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Weighing Scale Carlibration</label>
                                            <%--<asp:TextBox ID="txtChemicalUsage" runat="server" CssClass="form-control border border-success" placeholder="Purchase Date" />--%>
                                            <asp:DropDownList ID="ddlWeighCellebration" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage=" Please select the Weighing Scale Carlibration" ControlToValidate="ddlWeighCellebration" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Purchase rate per kg</label>
                                            <asp:TextBox ID="txtRateperkg" runat="server" CssClass="form-control border border-success" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Display="Dynamic" runat="server" InitialValue="0" ErrorMessage=" Please enter the rate per kg" ControlToValidate="txtRateperkg" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                </div>
                            </div>
                            <%--</div>
                        </div>--%>
                        </div>
                    </div>
                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="widget-box">
                            <div class="widget-header" style="border: 1px; border-style: solid">
                                <h5 class="widget-title">Weighment</h5>
                            </div>--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Weighment</h5>

                                <asp:Label ID="lblTotalWt" runat="server" ForeColor="#eef5f9"></asp:Label>
                                <asp:Label ID="lblNets" runat="server" ForeColor="#eef5f9"></asp:Label>
                                <asp:Label ID="lblGross" runat="server" ForeColor="#eef5f9"></asp:Label>
                                <%--<div class="widget-body">
                                <div class="widget-main">--%>
                                <div class="table-responsive">
                                    <table id="file_export" class="table table-bordered nowrap display">
                                        <asp:GridView ID="gvQualityDetails" class="table table-success table-bordered" Width="100%" BorderWidth="1px" BorderStyle="Double" runat="server" AllowPaging="True" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" PageSize="3" AutoGenerateColumns="False">
                                            <AlternatingRowStyle />
                                            <%-- <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" SortExpression="NO.">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("PlantID") %>' />
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="PlantID" SortExpression="PlantID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lPlantID" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("PlantID") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="NETS" SortExpression="SampleWeight">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lSampleWeight" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("NETS") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gross Weight" SortExpression="GrossWeight">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lReason1" runat="server" Text='<%# Eval("GrossWeight") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Weight" SortExpression="TotalWeight">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lReason2" runat="server" Text='<%# Eval("TotalWeight") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <%--   <asp:TemplateField HeaderText="No of Normal Pieces" SortExpression="No_of_Normal_Pieces">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lNoofNormalPieces" runat="server" Text='<%# Eval("No_of_Normal_Pieces") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No of Small Pieces" SortExpression="No_of_small_pieces">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lUserType" ForeColor="#990000" runat="server" Text='<%# Eval("No_of_small_pieces") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No. of Small Accounted_One" SortExpression="No_of_small_Accounted_One">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDesignation" runat="server" Text='<%# Eval("No_of_small_Accounted_One") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Number of Pieces" SortExpression="Total_Number_of_Pieces">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDepartment" ForeColor="#006666" runat="server" Text='<%# Eval("Total_Number_of_Pieces") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="WeightDeduction" SortExpression="WeightDeduction">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lWeightDeduction" runat="server" ItemStyle-ForeColor="#ff0000" Text='<%# Eval("WeightDeduction") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Count Adjustment" SortExpression="CountAdjustment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lEmailAddressasas" ForeColor="#000066" runat="server" Text='<%# Eval("CountAdjustment") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Purchase Count Per KG" SortExpression="PurchaseCountPerKG">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lPErformedBy" runat="server" Text='<%# Eval("PurchaseCountPerKG") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="No.Of Nets" SortExpression="No_Of_Nets">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lEntryDone" runat="server" Text='<%# Eval("No_Of_Nets") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tare Weight" SortExpression="Tare_Weight_Per_Net">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lReason" runat="server" Text='<%# Eval("Tare_Weight_Per_Net") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>--%>





                                                <%--   <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lActive" ForeColor="#006600" runat="server" Text='<%# Eval("Active") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgEdit" ImageUrl="~/images/Edit.png" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDelete" ImageUrl="~/images/Delete.png" runat="server" Width="20" Height="20" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?')" ToolTip="Delete" />

                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#ffffff" BorderWidth="1px" />

                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField HeaderText="View" SortExpression="View">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgView" ImageUrl="~/images/View.jfif" runat="server" Width="20" Height="20" CommandName="View" CausesValidation="false" ToolTip="View" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>

                                        </asp:GridView>

                                    </table>
                                </div>
                                <%--</div>
                            </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="widget-box">
                                <%--<div class="widget-header" style="border: 1px; border-style: solid">
                                <h5 class="widget-title">Quality Check</h5>
                            </div>

                            <div class="widget-body">
                                <div class="widget-main">--%>
                                <div class="card-body" style="border: groove">
                                    <h5 class="card-title" style="font-weight: bold; color: brown">Quality Check</h5>
                                    <div class="row mb-0">
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">No. of Soft Pieces</label>
                                                <asp:TextBox ID="txtSoftPieces" runat="server" CssClass="form-control border border-success" placeholder="No. of Soft Pieces" AutoPostBack="true" OnTextChanged="txtSoftPieces_TextChanged" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Soft Percentage</label>
                                                <asp:TextBox ID="txtSoftPercentage" runat="server" CssClass="form-control border border-success" placeholder="Soft Percentage" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">No. of Pieces with Black Spot</label>
                                                <asp:TextBox ID="txtBlackSpot" runat="server" CssClass="form-control border border-success" placeholder="No. of Pieces with Black Spot" AutoPostBack="true" OnTextChanged="txtBlackSpot_TextChanged" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Percentage of black spot</label>
                                                <asp:TextBox ID="txtBlackPer" runat="server" CssClass="form-control border border-success" placeholder="Percentage of black spot" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">No. of pieces in Necrosis</label>
                                                <asp:TextBox ID="txtNoNecrosis" runat="server" CssClass="form-control border border-success" placeholder="No. of pieces in Necrosis" AutoPostBack="true" OnTextChanged="txtNoNecrosis_TextChanged" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Necrosis %</label>
                                                <asp:TextBox ID="txtNecrosisPer" runat="server" CssClass="form-control border border-success" placeholder="Necrosis %" />


                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Discolouration</label>
                                                <asp:TextBox ID="txtDiscolouration" runat="server" CssClass="form-control border border-success" placeholder="Discolouration" AutoPostBack="true" OnTextChanged="txtDiscolouration_TextChanged" />


                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Discolouration Percentage</label>
                                                <asp:TextBox ID="txtDiscolorationPer" runat="server" CssClass="form-control border border-success" placeholder="Discolouration Percentage" />


                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Colour of the Shrimp</label>
                                                <asp:DropDownList ID="ddllColorShrimp" runat="server" CssClass="form-control border border-success" placeholder="Colour of the Shrimp" />

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Gills</label>
                                                <asp:DropDownList ID="ddlGills" runat="server" CssClass="form-control border border-success" placeholder="Gills" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Freshness/Texture</label>
                                                <asp:TextBox ID="txtFreshness" runat="server" CssClass="form-control border border-success" placeholder="Freshness/Texture" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Muddy Smell</label>
                                                <asp:TextBox ID="txtMuddySmell" runat="server" CssClass="form-control border border-success" placeholder="Muddy Smell" />

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">RM Temerature</label>
                                                <asp:TextBox ID="txtTemerature" runat="server" CssClass="form-control border border-success" placeholder="RM Temerature" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Cleanliness of Vehicle</label>
                                                <asp:DropDownList ID="ddlCleanlines" runat="server" CssClass="form-control border border-success" placeholder="Cleanliness of Vehicle" />

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Cleanliness of Boxes(Crates)</label>
                                                <asp:DropDownList ID="ddlCleanliness" runat="server" CssClass="form-control border border-success" placeholder="Cleanliness of Boxes(Crates)" />

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">ICE Condition</label>
                                                <asp:DropDownList ID="ddlIceCondition" runat="server" CssClass="form-control border border-success" placeholder="ICE Condition" />

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">No. of Broken Pieces</label>
                                                <asp:TextBox ID="txtBrokenPieces" runat="server" CssClass="form-control border border-success" AutoPostBack="true" OnTextChanged="txtBrokenPieces_TextChanged" placeholder="No. of Broken Pieces" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Broken Percentage</label>
                                                <asp:TextBox ID="txtBrokenPercentage" runat="server" CssClass="form-control border border-success" placeholder="Broken Percentage" />

                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <%--</div>
                        </div>--%>
                            </div>
                        </div>
                        <div class="space-6"></div>

                        <div class="row">
                            <div class="col-sm-12">
                                <%--<div class="widget-box">
                                    <div class="widget-header" style="border: 1px; border-style: solid">
                                        <h5 class="widget-title">Details</h5>
                                    </div>

                                    <div class="widget-body">
                                        <div class="widget-main">--%>
                                <div class="card-body" style="border: groove">
                                    <h5 class="card-title" style="font-weight: bold; color: brown">Details</h5>
                                    <div class="row mb-0">
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Remarks</label>
                                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control border border-success" placeholder="No. of Soft Pieces" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Supervised By</label>
                                                <%--  <asp:TextBox ID="txtSupervisor" runat="server" CssClass="form-control border border-success" placeholder="Soft Percentage" />--%>
                                                <asp:DropDownList ID="ddSupervisor" runat="server" CssClass="form-control border border-success" placeholder="Supervised By" />
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Entry By</label>
                                                <asp:TextBox ID="txtEntryBy" runat="server" CssClass="form-control border border-success" placeholder="No. of Pieces with Black Spot" />

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-2 row">
                                                <label for="fname">Approved By</label>
                                                <%--  <asp:TextBox ID="txtApprovedBy" runat="server" CssClass="form-control border border-success" placeholder="Percentage of black spot" />--%>
                                                <asp:DropDownList ID="ddlApprovedBy" runat="server" CssClass="form-control border border-success" placeholder="ApprovedBy" />
                                            </div>
                                        </div>

                                    </div>
                                </div>




                                <%--</div>
                                </div>--%>
                            </div>
                        </div>







                        <div class="p-3 border-top">
                            <div class="text-end">

                                <%-- <div class="text-lg-end">--%>
                                <asp:Label ID="lblMessage" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                                <asp:Button ID="btnSave" runat="server" Class="btn btn-info btn-lg px-" Text="Save" ValidationGroup="id1" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info btn-lg px-" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="space-6"></div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divGridView" runat="server">
                <div class="page-content">

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">

                                <div>
                                    <div class="card-body">
                                        <h4 class="header green">Purchase Details</h4>

                                        <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                            <%--  <table id="file_export1" class="table table-bordered nowrap display">--%>
                                            <asp:GridView ID="gvPurchaseDetails" class="table table-success table-bordered" Width="100%" BorderWidth="1px" BorderStyle="Double" OnRowEditing="gvPurchaseDetails_RowEditing" runat="server" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" AutoGenerateColumns="False" OnPageIndexChanging="gvPurchaseDetails_PageIndexChanging" OnRowDeleting="gvPurchaseDetails_RowDeleting">
                                                <AlternatingRowStyle BackColor="#F0F0F0" />
                                                <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("SaudaNumberCode") %>' />
                                                            <asp:HiddenField ID="hdnLot" runat="server" Value='<%# Eval("LotNumber") %>' />
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Sauda No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lSNumber" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("SaudaNumberCode") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Purchase Count">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Pcount" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("PurchaseCount") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lot Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lTeype1" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("LotNumber") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Purchase Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lTestingType" ForeColor="#006666" runat="server" Text='<%# Eval("PurchaseDate") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PurchaseType">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lLabName" runat="server" ForeColor="#006666" Text='<%# Eval("PurchaseType") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agent Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("SupplierName") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Farmer Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDesignation" ForeColor="#006666" runat="server" Text='<%# Eval("FarmerName") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="District Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDistrict" ForeColor="#006666" runat="server" Text='<%# Eval("District") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mandal Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDepartment" ForeColor="#006666" runat="server" Text='<%# Eval("Mandal") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Village Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDepartment1" ForeColor="#006666" runat="server" Text='<%# Eval("Village") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Gross Weight" SortExpression="Gross Weight">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lMobileNumber" runat="server" ItemStyle-ForeColor="#ff0000" Text='<%# Eval("GrossWeight") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tare Weight">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lEmailAddress" ForeColor="#000066" runat="server" Text='<%# Eval("TareWeight") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Weight" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lPErformedBy" runat="server" Text='<%# Eval("TotalWeight") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#ffffff" BorderWidth="1px" />
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgEdit" ImageUrl="~/images/Edit.png" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />
                                                            <%-- <asp:LinkButton ID="btnlEdit" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDelete" ImageUrl="~/images/Delete.png" runat="server" Width="20" Height="20" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?')" ToolTip="Delete" />

                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />

                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>
                                            <%--  </table>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

