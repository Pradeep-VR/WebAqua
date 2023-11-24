<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PackingReport.aspx.cs" Inherits="AQUA.PackingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content-inner" id="divEntry" runat="server">
        <div class="page-content">
            <asp:UpdatePanel ID="upQualityEntry" runat="server">
                <contenttemplate>
                    <h4 class="header green" style="font-weight: bold; color: brown">Packing - Report</h4>

                    <div class="col-sm-12">

                        <div class="card-body" style="border: groove">

                            <div class="row mb-1">
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">From Date</label>
                                        <div class="form-control-sm">
                                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control border border-success" TextMode="Date">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="mb-1 row">
                                        <label class="control-label">To Date</label>
                                        <div class="form-control-sm">
                                            <asp:TextBox ID="txtToDate" runat="server" class="form-control border border-success" TextMode="Date">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">Variety</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" OnSelectedIndexChanged="ddlVariety_SelectedIndexChanged" CssClass="form-control border border-success" ID="ddlVariety" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label" id="txtbatno">Batch No</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" OnSelectedIndexChanged="ddlBatchNumber_SelectedIndexChanged" CssClass="form-control border border-success" ID="ddlBatchNumber" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>



                            </div>
                            <div class="row mb-1">
                                <h5>
                                    <label for="fname" style="font-weight: bold; color: brown">Batch Details </label>
                                </h5>

                                <div class="col-sm-2">
                                    <div class="mb-1 row">
                                        <label class="control-label">Total RM Qty</label>
                                        <div class="form-control-sm">
                                            <asp:TextBox ID="txttotrmqty" runat="server" Enabled="false" CssClass="form-control border border-success">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-2">
                                    <div class="mb-1 row">
                                        <label class="control-label">Head On Count</label>
                                        <div class="form-control-sm">
                                            <asp:TextBox ID="txtheadoncnt" runat="server" Enabled="false" CssClass="form-control border border-success">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-1">
                                    <div class="mb-2 row" style="padding-left: 10px; margin-top: 25px">
                                        <asp:Button ID="btnView" OnClick="btnView_Click" runat="server" Visible="true" Text="View" CssClass="form-control btn-primary" ForeColor="White" />
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <div class="mb-2 row" style="padding-left: 10px; margin-top: 25px">
                                        <asp:Button ID="btnexport" runat="server" Visible="true" Text="Export" CssClass="form-control btn-primary" ForeColor="White" />
                                    </div>
                                </div>
                            </div>
                            <!-- Design textBox,Labels,Dropdowns-->
                            <div class="card-body" style="border: groove">
                                <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px" runat="server">
                                    <table id="file_export" class="table table-bordered nowrap display">
                                        <asp:GridView ID="GVPackingRpt" runat="server" class="table table-success table-bordered" GridLines="Both" Width="100%" AllowPaging="True" EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False">
                                            <rowstyle font-bold="True" font-names="Calibri" font-size="10pt" />
                                            <columns>
                                                <asp:TemplateField HeaderText="PO Number" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdPoNum") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product Type" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdPrdType") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Grade" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdGrade") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SoakingType" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdSoakType") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type Of Freezing" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdTypeOfFreezing") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Packing Style" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdPackStyle") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Weight Unit" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdWeightUnit") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No Of Slab Packed" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdSlabPacked") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty In Kg" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdQuantity") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdTotal") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Final HOC Cov" ItemStyle-Height="50px">
                                                    <itemtemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grdHOCConv") %>' />
                                                    </itemtemplate>
                                                    <headerstyle bordercolor="#3699FF" borderwidth="1px" />
                                                    <itemstyle bordercolor="#3699FF" borderwidth="1px" />
                                                </asp:TemplateField>

                                            </columns>
                                        </asp:GridView>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
        </div>
        </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
