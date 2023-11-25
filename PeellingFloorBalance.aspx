<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PeellingFloorBalance.aspx.cs" Inherits="AQUA.PeellingFloorBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>

     tbody tr:first-child{      
     position: sticky;
     top: 0;
     color:#b22222;
 }

     /*tbody td:first-child{      
     position: sticky;
     left:0;
 }*/

 </style>

    <div class="main-content-inner" id="divEntry" runat="server">
        <div class="page-content">
            <asp:UpdatePanel ID="upQualityEntry" runat="server">
                <ContentTemplate>
                    <h4 class="header green">Peeling FloorWise - Report</h4>
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
                                        <label class="control-label">Plant</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" CssClass="form-control border border-success" ID="ddlPlant">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">Type Of Purchase</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" CssClass="form-control border border-success" ID="ddlPurchaseType" AutoPostBack ="true" OnSelectedIndexChanged="ddlPurchaseType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">Batch No</label>
                                        <div class="form-control-sm">
                                            <div id="cjklstbx" style="width:130px; height:100px; overflow:scroll;">
                                                <asp:CheckBoxList  runat="server" CssClass="form-control border border-success" ID="ddlBatchNumber" AutoPostBack ="true"></asp:CheckBoxList>                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">Grade</label>
                                        <div class="form-control-sm">
                                            <div id="cjklstbx1" style="width:130px; height:100px; overflow:scroll;">
                                                <asp:CheckBoxList  runat="server" CssClass="form-control border border-success" ID="ddlGrade" AutoPostBack ="true"></asp:CheckBoxList>                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label"></label>
                                        <div class="form-control-sm">
                                            <%--<div id="cjklstbx2" style="width:130px; height:80px; overflow:scroll;">--%>
                                                <asp:CheckBoxList  runat="server" Visible="false" CssClass="form-control border border-success" ID="dmychlist" AutoPostBack ="true"></asp:CheckBoxList>                                                
                                            <%--</div>--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-1" >
                                <div class="col-sm-1" >
                                    <div class="mb-2 row" style="padding-right:10px;">
                                        <%--<label class="control-label">view</label>--%>
                                        <asp:Button  ID="btnView" runat="server" Visible="true" Text="View" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnView_Click" />
                                    </div>
                                </div>

                                    <div class="col-sm-1" >
                                    <div class="mb-2 row" style="padding-right:10px;">
                                        <%--<label class="control-label">view</label>--%>
                                        <asp:Button ID="btnexport" runat="server" Visible="true" Text="Export" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnexport_Click" />
                                    </div>
                                </div>
                            </div>
                                <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                                            <table id="file_export" class="table table-bordered nowrap display">
                                                                <asp:GridView ID="GVPFloorWise" runat="server" class="table table-success table-bordered" GridLines="Both"  Width="100%" AllowSorting="True"  EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False" >
                                                                    <AlternatingRowStyle />
                                                                    <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                                                    <Columns>                                                                        
                                                                         <asp:templatefield headertext="BatchNo" sortexpression="batchno">
                                                                            <itemtemplate>
                                                                                <asp:label id="ltestingtype" itemstyle-forecolor="#ff0000" runat="server" text='<%# Eval("batchNo") %>' />
                                                                            </itemtemplate>
                                                                            <headerstyle bordercolor="#3699ff" borderwidth="1px" />
                                                                            <itemstyle bordercolor="#3699ff" borderwidth="1px" />
                                                                        </asp:templatefield>
                                                                        <asp:TemplateField HeaderText="Grade" SortExpression="Grading">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grade") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Product Type" SortExpression="Grading">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("pdType") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="HL Quantity" SortExpression="HL Quantity">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("HL_Quantity") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="Total" SortExpression="Total">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("Total") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>--%>

                                                                    </Columns>
                                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                    <FooterStyle BorderColor="#3699FF" BorderWidth="1px" />                                                                   
                                                                </asp:GridView>
                                                            </table>
                                                        </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>