<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PackingSpecification.aspx.cs" Inherits="AQUA.PackingSpecification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>
            <%-- divEntry--%>

            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <h4 class="header green">Packing Specification</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Packing Specification</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Packing Specification</h5>

                                <div class="row mb-0">

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">PO Number</label>
                                            <asp:TextBox ID="txtPONumber" runat="server" AutoPostBack="true" OnTextChanged="txtPONumber_TextChanged" CssClass="form-control border border-success" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPONumber" Display="Dynamic" runat="server" ErrorMessage=" Please enter PO number" ControlToValidate="txtPONumber" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                         <div class="mb-2 row">
                                            <label for="fname">Buyer Name</label>
                                            <asp:HiddenField ID="hdnPackID" runat="server" />
                                            <asp:TextBox ID="txtBuyerName" runat="server" CssClass="form-control border border-success" />
                                            <asp:RequiredFieldValidator ID="rfvBuyerName" Display="Dynamic" runat="server" ErrorMessage=" Please enter buyer name" ControlToValidate="txtBuyerName" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                         <div class="mb-2 row">
                                            <label for="fname">Cargo No</label>
                                            <asp:TextBox ID="txtCargoNo" runat="server" CssClass="form-control border border-success" />
                                            <asp:RequiredFieldValidator ID="rfvCargoNo" Display="Dynamic" runat="server" ErrorMessage=" Please select the Cargo Number" ControlToValidate="txtCargoNo" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">Brand</label>
                                            <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control border border-success" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage=" Please enter the brand" ControlToValidate="txtBrand" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-6"></div>
                                <%--   <div class="widget-box"></div>--%>

                                <div class="card-body" style="border: groove">

                                    <div class="row mb-0">
                                        <%--  <div class="col-md-2">
                                                            <div class="form-floating mb-0">
                                                                <label for="fname">Packing Style</label>
                                                                <asp:TextBox ID="txtPackingStyle" runat="server" CssClass="form-control border border-success" onkeypress="return isNumber(event)" MaxLength="8" />
                                                                <asp:RequiredFieldValidator ID="rfvPackingStyle" Display="Dynamic" runat="server" ErrorMessage=" Please select the Packing Style" ControlToValidate="txtPackingStyle" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <div class="form-floating mb-0">
                                                                <label for="fname"> </label>
                                                                <asp:TextBox ID="txtSym" runat="server" Text="*" CssClass="form-control border border-success" Enabled="true" MaxLength="8" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ErrorMessage=" Please select the Packing Style" ControlToValidate="txtPackingStyle" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <div class="form-floating mb-0">
                                                                <label for="fname"> </label>
                                                                <asp:TextBox ID="txtPackingStyle1" runat="server" CssClass="form-control border border-success" onkeypress="return isNumberKey(event)" MaxLength="8" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage=" Please select the Packing Style" ControlToValidate="txtPackingStyle1" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>--%>
                                        <div class="col-md-4">
                                            <label>Packing Style</label>
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="input-xxlarge input-group ">
                                                    <asp:TextBox ID="txtPackingStyle" runat="server" CssClass="form-control border border-success" onkeypress="return isNumber(event)" MaxLength="8" />
                                                    <asp:RequiredFieldValidator ID="rfvPackingStyle" Display="Dynamic" runat="server" ErrorMessage=" * Select" ControlToValidate="txtPackingStyle" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-asterisk"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtPackingStyle1" runat="server" CssClass="form-control border border-success" onkeypress="return isNumberKey(event)" MaxLength="8" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="* Select" ControlToValidate="txtPackingStyle1" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                             <div class="mb-2 row">
                                                <label for="fname">Unit of  Wt. measurement</label>
                                                <asp:DropDownList ID="ddlUnitMeasurement" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage=" Please enter the brand" ControlToValidate="ddlUnitMeasurement" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
 
                                        <div class="col-md-2">
                                            <div class="mb-2 row">
                                                <label for="fname">Packing Type</label>
                                                <asp:DropDownList ID="ddlPackingType" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage=" Please select the Packing Type" ControlToValidate="ddlPackingType" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                             <div class="mb-2 row">
                                                <label for="fname">Order Glaze %</label>
                                                <asp:TextBox ID="txtGlaze" runat="server" CssClass="form-control border border-success" MaxLength="3" onkeypress="return allowOnlyDigits(event,this);" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ErrorMessage=" Please select the Cargo Number" ControlToValidate="txtGlaze" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="space-6"></div>
                                    <div class="row mb-0">
                                        <div class="col-md-2">
                                           <div class="mb-2 row">
                                                <label for="fname">Grade</label>
                                                <asp:DropDownList ID="ddlGrade" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage="  Please select the grade" ControlToValidate="ddlGrade" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="mb-2 row">
                                                <label for="fname">Product Type</label>
                                                <asp:DropDownList ID="ddlVariety" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage=" Please select the variety" ControlToValidate="ddlVariety" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="mb-2 row">
                                                <label for="fname">Order Quantity (Master Cartons)</label>
                                                <asp:TextBox ID="txtOrderQty" runat="server" AutoPostBack="true" MaxLength="6" onkeypress="return isNumber(event)" OnTextChanged="txtOrderQty_TextChanged" CssClass="form-control border border-success" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage=" Please enter the order quantity" ControlToValidate="txtOrderQty" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                         <div class="col-md-2">
                                           <div class="mb-2 row">
                                                <label for="fname">Glaze Spec</label>
                                                 <asp:DropDownList ID="ddlGlaceSpec" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage=" Please select the variety" ControlToValidate="ddlGlaceSpec" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                           <div class="mb-2 row">
                                                <label for="fname">Target Count</label>
                                                <asp:TextBox ID="txtTargetCount" runat="server" MaxLength="6" CssClass="form-control border border-success" onkeypress="return isNumber(event)" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage=" Please enter the target count" ControlToValidate="txtTargetCount" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="space-6"></div>
                                    <div class="row mb-0">
                                         <div class="col-md-2">
                                            <div class="mb-2 row">
                                                <label for="fname">No. of Slabs</label>
                                                <asp:TextBox ID="txtNoOfSlabs" runat="server" MaxLength="6" onkeypress="return isNumber(event)" CssClass="form-control border border-success" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage="Please enter the No of Slabs" ControlToValidate="txtNoOfSlabs" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                        <div class="mb-2 row">
                                                <label for="fname">Matched from Open(No. of Slabs)</label>
                                                <asp:TextBox ID="txtMatchedFromOpen" runat="server" MaxLength="6" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtMatchedFromOpen_TextChanged" CssClass="form-control border border-success" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage=" Please enter the Matched from Open(No. of Slabs)" ControlToValidate="ddlVariety" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                           <div class="mb-2 row">
                                                <label for="fname">Chemical Treatment</label>
                                                <asp:DropDownList ID="ddlChemical" runat="server" CssClass="form-control border border-success">
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server" InitialValue="-Select-" ErrorMessage=" Please enter the chemical Treatment" ControlToValidate="ddlChemical" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                         <div class="mb-2 row">
                                                <label for="fname">Remarks </label>
                                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="space-6"></div>
                                    <div class="row mb-0">
                                         
                                        </div>
                                </div>
                                <%--  </div>--%>
                            </div>
                            <div class="space-6"></div>
                            <div class="space-6"></div>

                            <div class="card-body" style="border: groove">
                                <%-- <h5 class="card-title" style="font-weight: bold; color: brown">Packing Specification</h5>--%>
                                <div class="row mb-0">
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">No. of Slabs - till yesterday</label>
                                            <asp:TextBox ID="txtSlabsYes" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">No. of Slabs - today's production</label>
                                            <asp:TextBox ID="txtSlabsToday" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                     <div class="mb-2 row">
                                            <label for="fname">Balance Slabs</label>
                                            <asp:TextBox ID="txtBalanceSlab" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Balance Cartons</label>
                                            <asp:TextBox ID="txtBalanceCartons" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-6"></div>
                                <div class="row mb-0">

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">Balance Quantity</label>
                                            <asp:TextBox ID="txtBalQty" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                         <div class="mb-2 row">
                                            <label for="fname">Cartons Packed in Final </label>
                                            <asp:TextBox ID="txtFinalProduction" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">Cartons RePacked in Final</label>
                                            <asp:TextBox ID="txtRepack" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">Balanced Cartons  to be RePacked </label>
                                            <asp:TextBox ID="txtBalRepack" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>

                                </div>
                                <div class="space-6"></div>
                                <div class="row mb-0">
                                </div>
                            </div>

                            <div class="card-body" style="border: groove">

                                <div class="text-lg-end">
                                    <asp:Label ID="lblMessage" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                                    <asp:Button ID="btnSave" runat="server" Class="btn-primary" Text="Save" ValidationGroup="id1" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn-primary" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
                                    <asp:Label ID="lblStatus" runat="server" Text="" />

                                </div>
                            </div>

                            <div class="space-6"></div>

                            <%--<div class="widget-box">
                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Packing Specification</h5>
                                <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 150px">
                                    <asp:GridView ID="gvPackSpecDetails" class="table table-success table-bordered" OnRowEditing="gvPackSpecDetails_RowEditing" BorderWidth="1px" BorderStyle="Double" runat="server" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="#F0F0F0" />
                                        <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                        <Columns>
                                            <%-- <asp:TemplateField HeaderText="Buye rName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("BuyerName") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                </asp:TemplateField>--%>
                                            <%-- <asp:TemplateField HeaderText="PO Number">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lLabName" runat="server" Text='<%# Eval("PONumber") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                </asp:TemplateField>--%>
                                            <%--<asp:TemplateField HeaderText="Cargo Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lUserType" ForeColor="#990000" runat="server" Text='<%# Eval("CargoNumber") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="S.No" SortExpression="NO.">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("PackID") %>' />
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Brand">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbrand" runat="server" Text='<%# Eval("Brand") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Packing Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDesignation" runat="server" Text='<%# Eval("PackingType") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Packing Style">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDistrict" ForeColor="#006666" runat="server" Text='<%# Eval("PackingStyle") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Grade">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment" ForeColor="#006666" runat="server" Text='<%# Eval("Grade") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment1" ForeColor="#006666" runat="server" Text='<%# Eval("Variety") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="ldPro" ForeColor="#006666" runat="server" Text='<%# Eval("unit") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Target Count">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment11" ForeColor="#006666" runat="server" Text='<%# Eval("TargetCount") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment12" ForeColor="#006666" runat="server" Text='<%# Eval("OrderQty") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of slabs">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment13" ForeColor="#006666" runat="server" Text='<%# Eval("NoofSlabs") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Matched from Open">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment14" ForeColor="#006666" runat="server" Text='<%# Eval("MatchedfromOpen") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Slabs - Yesterday">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartnt145" ForeColor="#006666" runat="server" Text='<%# Eval("NoofSlabsYesterday") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Slabs - Today">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepar4tment1" ForeColor="#006666" runat="server" Text='<%# Eval("NoofSlabsToday") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Balance Slabs">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment51" ForeColor="#006666" runat="server" Text='<%# Eval("BalanceSlabs") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Balance Cartons">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment61" ForeColor="#006666" runat="server" Text='<%# Eval("BalanceCartons") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Balance Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartment541" ForeColor="#006666" runat="server" Text='<%# Eval("BalanceQty") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Final from Production">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartmewnt031" ForeColor="#006666" runat="server" Text='<%# Eval("CartonPacked") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cartons RePacked in Final">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepsartment031" ForeColor="#006666" runat="server" Text='<%# Eval("CartonRepack") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Balanced Cartons - RePacked ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartxment031" ForeColor="#006666" runat="server" Text='<%# Eval("CartonBalRepack") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Packing Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDepartxment091" ForeColor="#006666" runat="server" Text='<%# Eval("Packingstatus") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEdit" ImageUrl="~/images/blueEdit.png" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>
            <%-- </div>
                </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function GetPODetail() {
    var txtponumber = $('#txtPONumber').val();
    
    $.ajax({
        type: "POST",
        url: "PackingSpecification.aspx/getPonumberDetails", // Replace YourPage with the actual page name
        data: JSON.stringify({
            poNumber: txtponumber,
            
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle the response from the server
            // For example, update a <div> with the returned data
            $('#resultDiv').text(response.d); // Assuming you have a <div> with the id "resultDiv"
        },
        error: function (error) {
            // Handle error if needed
        }
    });
}

    </script>


</asp:Content>

