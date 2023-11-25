<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PeelingBatchwise.aspx.cs" Inherits="AQUA.PeelingBatchwise" %>

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

    <%-- divEntry --%>
    <div class="main-content-inner" id="divEntry" runat="server">
        <div class="page-content">
            <asp:UpdatePanel ID="upQualityEntry" runat="server">
                <ContentTemplate>
                    <h4 class="header green">Peeling BatchWise - Report</h4>

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
                                        <label class="control-label" >Type Of Purchase</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" CssClass="form-control border border-success" ID="ddlPurchaseType" AutoPostBack ="true" OnSelectedIndexChanged="ddlPurchaseType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label" id="txtbatno">Batch No</label>
                                        <div class="form-control-sm">
                                            <%--<asp:DropDownList runat="server" CssClass="form-control" ID="ddlBatchNumber" AutoPostBack ="true">                                             
                                            </asp:DropDownList>--%>
                                            <div id="cjklstbx" style="width:130px; height:100px; overflow:scroll;">
                                                <asp:CheckBoxList  runat="server" CssClass="form-control border border-success" ID="ddlBatchNumber" AutoPostBack ="true"></asp:CheckBoxList>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label" id="txtprotyp">ProductType</label>
                                        <div class="form-control-sm">
                                            <%--<asp:DropDownList runat="server" CssClass="form-control" ID="ddlProduct" AutoPostBack ="true">
                                            </asp:DropDownList>   --%>    
                                            <div id="cjklstbx1" style="width:130px; height:100px; overflow:scroll;">
                                                <asp:CheckBoxList runat="server"  CssClass="form-control border border-success" ID="ddlProduct" AutoPostBack ="true"></asp:CheckBoxList>
                                            </div>                                                                             
                                        </div>
                                    </div>
                                </div>
                             <div class="row mb-1">
                                <div class="col-sm-1">
                                    <div class="mb-2 row">
                                        <%--<label class="control-label">view</label>--%>
                                        <asp:Button ID="btnView" runat="server" Visible="true" Text="View" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnView_Click" />
                                    </div>
                                </div>
                            
                                <div class="col-sm-1">
                                    <div class="mb-2 row" style="padding-left:10px;">
                                        <%--<label class="control-label">view</label>--%>
                                        <asp:Button ID="btnexport" runat="server" Visible="true" Text="Export" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnexport_Click" />
                                    </div>
                                </div>
                            </div>
                                <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                                            <table id="file_export" class="table table-bordered nowrap display">
                                                                <asp:GridView ID="GVPeelingBthwise" runat="server" class="table table-success table-bordered" GridLines="Both"  Width="100%" AllowSorting="True"  EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False" OnRowEditing="PelingFinalData_RowEditing">
                                                                    <AlternatingRowStyle />
                                                                    <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                                                    <Columns>                                                                        
                                                                         <asp:templatefield headertext="batchno" sortexpression="batchno">
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
                                                                        <asp:TemplateField HeaderText="ProductType" SortExpression="Head On Count/kg">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("prdType") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="HL Qty Issued for peeling" SortExpression="Head On Count/kg">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("HL") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Tot Peeled Qty" SortExpression="HeadLessWeight">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("pelled_qty") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Yield(%)" SortExpression="Gradewiseyeild">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("YieldPercentage") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                    </Columns>
                                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                    <FooterStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                    <%-- <HeaderStyle BackColor="#FE5419" ForeColor="White" BorderWidth="1px" Height="50px" BorderStyle="Double" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <RowStyle BackColor="#3699FF" ForeColor="White" BorderWidth="1px" Height="35px" BorderStyle="Double" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <AlternatingRowStyle BackColor="#61cdf4" ForeColor="White" BorderWidth="1px" Height="35px" BorderStyle="Double" HorizontalAlign="Center" VerticalAlign="Middle" />--%>
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
