<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="BlockOutFeed.aspx.cs" Inherits="AQUA.BlockOutFeed" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <h4 class="header green">Block Freezing - Outfeed Entry</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Block Freezing - Outfeed Entry</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown"></h5>


                                <div class="row mb-0">
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">Freezer Number :</label>
                                            <asp:DropDownList ID="ddlFreezerNo" runat="server" CssClass="form-control border border-success"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvFreezerNumber" Display="Dynamic" runat="server" ErrorMessage="* Select Freezer Number" ControlToValidate="ddlFreezerNo" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">.</label>
                                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="form-control btn-primary" Width="75px" ForeColor="White" OnClick="btnView_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname"></label>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                          <div class="mb-2 row">
                                            <label for="fname">Unloading Time :</label>
                                            <asp:TextBox ID="txtUnloadingTime" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-12">

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown"></h5>


                                <div class="row mb-0">
                                    <div class="col-md-6">
                                          <div class="mb-2 row">
                                            <label for="fname">Grade & Product Type</label>
                                            <asp:DropDownList ID="ddlGrade" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" CssClass="form-control border border-success">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvGrade" Display="Dynamic" runat="server" ErrorMessage=" Please Select Grade" ControlToValidate="ddlGrade" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                   <div class="mb-2 row">
                                            <label for="fname">Batch Number</label>
                                            <asp:TextBox ID="txtBatchNumber" runat="server" CssClass="form-control border border-success" />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage=" Please enter buyer name" ControlToValidate="txtBuyerName" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                       <div class="mb-2 row">
                                            <label for="fname">NO. Of Slabs Loaded</label>
                                            <asp:TextBox ID="txtNoOfSlabsLoaded" runat="server" CssClass="form-control border border-success" />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage=" Please enter buyer name" ControlToValidate="txtBatchNumber" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>



                                </div>

                                <div class="row mb-0">

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname">NO. Of Slabs Unloaded</label>
                                            <asp:TextBox ID="txtNoOfSlabsUnloaded" runat="server" CssClass="form-control border border-success" />
                                            <%--<asp:RequiredFieldValidator ID="rfvBuyerName" Display="Dynamic" runat="server" ErrorMessage=" Please enter Barcode ID" ControlToValidate="txtBarcodeID" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                         <div class="mb-2 row">
                                            <label for="fname">NO. Of Slabs Re-Freezing</label>
                                            <asp:TextBox ID="txtNoOfSlabsgivenForReFreezing" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                      <div class="mb-2 row">
                                            <label for="fname">NO. Of Slabs Rejected</label>
                                            <asp:TextBox ID="txtNoOfSlabsRejected" runat="server" OnTextChanged="txtNoOfSlabsRejected_TextChanged" AutoPostBack="true" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                      <div class="mb-2 row">
                                            <label for="fname">Net Good Slabs For Packing</label>
                                            <asp:TextBox ID="txtNetGoodSlabsForPacking" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>

                                </div>
                                <div class="row mb-0">
                                    <div class="col-md-2">
                                       <div class="mb-2 row">
                                            <label for="fname"></label>
                                            <asp:Button ID="btnSubmit" runat="server" type="submit" OnClick="btnSubmit_Click" Text="ADD" class="btn btn-primary rounded-pill px-4" ValidationGroup="id1" />

                                            <asp:Label ID="lblMessage" runat="server" Font-Size="15px"></asp:Label>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>



                    <div class="row">
                        <div class="col-sm-12">

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Block Freezing - Outfeed Entry Details</h5>

                                <div class="row mb-0">

                                    <div class="col-md-12">
                                        <div class="form-floating mb-2">
                                            <div class="table-responsive">
                                                <table id="file_export1" class="table table-bordered nowrap display">
                                                    <asp:GridView ID="gvPackSpecDetails" class="table table-success table-bordered" BorderWidth="1px" BorderStyle="Double" runat="server" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" AutoGenerateColumns="False">
                                                        <AlternatingRowStyle BackColor="#F0F0F0" />
                                                        <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="Freezer Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lFN" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("FreezerNumber") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Grade And Product Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lGrade" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("GradeAndProdType") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Batch Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lBatchNumber" runat="server" Text='<%# Eval("BatchNumber") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="NO. Of Slabs Loaded">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lNOOfSlabsLoaded" ForeColor="#006666" runat="server" Text='<%# Eval("NoofSlabLoaded") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="NO. Of Slabs Unloaded">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lNoOfSlabsUnloaded" ForeColor="#006666" runat="server" Text='<%# Eval("NoofSlabUnloaded") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="NO. Of Slabs Re-Freezing">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lNoOfSlabsgivenForReFreezing" ForeColor="#006666" runat="server" Text='<%# Eval("NoOfSlabReFerze") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="NO. Of Slabs Rejected">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lNoOfSlabsRejected" ForeColor="#006666" runat="server" Text='<%# Eval("NoOfSlabReject") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Net Good Slabs For Packing">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lNetGoodSlabsForPacking" ForeColor="#006666" runat="server" Text='<%# Eval("NoOfSlabNetPAck") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown"></h5>

                                <div class="row mb-0">


                                    <div class="col-md-3">
                                         <div class="mb-6 row">
                                            <label for="fname">Flat / Actual Count</label>
                                            <asp:TextBox ID="txtActualCount" runat="server" CssClass="form-control border border-success" />

                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                          <div class="mb-2 row">
                                            <label for="fname">Total Quantity Given For BF</label>
                                            <asp:TextBox ID="txtTotalQuantityGivenForBF" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>


                                    <div class="col-md-3">
                                          <div class="mb-2 row">
                                            <label for="fname">Antibiotic Status </label>
                                            <asp:DropDownList ID="ddlAntibioticStatus" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-floating mb-2">
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-0">
                                    <div class="col-md-6">
                                    </div>

                                    <div class="col-md-3">
                                         <div class="mb-2 row">
                                            <label for="fname"></label>
                                            </br>
                                                  
                                                     <asp:Button ID="btnComplete" runat="server" OnClick="btnComplete_Click" Text="Completed" type="button" class="btn btn-primary rounded-pill px-4 ms-2 text-white" />
                                            <asp:Label ID="Label1" runat="server" Font-Size="15px"></asp:Label>

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

