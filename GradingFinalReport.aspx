<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="GradingFinalReport.aspx.cs" Inherits="AQUA.GradingFinalReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>

     tbody tr:first-child
     {         
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
                    <h4 class="header green" style="font-weight: bold; color: brown">Grading Final - Report</h4>

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
                                        <label for="fname">Batch No</label>
                                       <%--<asp:CheckBoxList  runat="server" CssClass="form-control" ID="ddlBatchNumber"></asp:CheckBoxList>--%>
                                       <div class="form-control-sm">
                                           <asp:DropDownList runat="server" CssClass="form-control border border-success" ID="ddlBatchNumber" ></asp:DropDownList>
                                           </div>
                                    </div>
                                </div>         
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label for="fname" style="color:transparent">.</label>
                                        <div class="form-control-sm">
                                        <asp:Button ID="btnView" runat="server" Visible="true" Text="View" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnView_Click" />
                                            </div>
                                    </div>                     
                            </div>

                            <div class="row mb-1">
                                <h5>
                                    <label for="fname" style="font-weight: bold; color: brown"> Supplier Details </label>
                                </h5>
                                <div class="col-md-2">
                                        <div class="mb-3 row">
                                            <label for="fname">Suplier Name</label>
                                            <asp:TextBox ID="txtsupliername" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Head On Count</label>
                                            <asp:TextBox ID="txtheadoncnt" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Head On Qty</label>
                                            <asp:TextBox ID="txtheadonqty" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Tot HL Qty</label>
                                            <asp:TextBox ID="txttthlqty" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Tot Yield%</label>
                                            <asp:TextBox ID="txttotyield" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Smpl Beheading Yld%</label>
                                            <asp:TextBox ID="txtbeheadyield" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                            </div>
                            <div class="row mb-2">
                                <h5>
                                    <label for="fname" style="font-weight: bold; color: brown"> Quality Details </label>
                                </h5>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Soft%</label>
                                            <asp:TextBox ID="txtsoftper" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Black Spot%</label>
                                            <asp:TextBox ID="txtblackspotper" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Necrosis%</label>
                                            <asp:TextBox ID="txtnecrosisper" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Discoloration%</label>
                                            <asp:TextBox ID="txtdiscolorper" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Broken%</label>
                                            <asp:TextBox ID="txtbrokenper" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-1">
                                        <div class="mb-2 row">
                                            <label for="fname">Shrimp_Clr</label>
                                            <asp:TextBox ID="txtcolor" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                <div class="col-md-1">
                                        <div class="mb-2 row">
                                            <label for="fname">BS Ratio</label>
                                            <asp:TextBox ID="txtbsvlu" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                
                                    <div class="mb-2 row">
                                        <label for="fname" style="color:transparent">.</label>
                                        <asp:Button ID="btnexpexcel" runat="server" Visible="true" Text="Export as Exl" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnexpexcel_Click" />                                    
                                      </div>      
                                    <div class="mb-1 row">
                                        <label for="fname" style="color:transparent">.</label>
                                        <asp:Button ID="btnexportWord" runat="server" Visible="false" Text="Export as Word" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnexportWord_Click" />
                                    </div>
                                
                            </div>
                            </div>
                            <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px" runat="server">
                                                            <table id="file_export" class="table table-bordered nowrap display">
                                                                <asp:GridView ID="GradingFinalData" runat="server" class="table table-success table-bordered" GridLines="Both"  Width="100%" AllowPaging="True"  EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False" OnRowEditing="GradingFinalData_RowEditing">
                                                                    <AlternatingRowStyle />
                                                                    <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                                                    <Columns>
                                                                         <asp:TemplateField HeaderText="BatchNo" SortExpression="BatchNo" ItemStyle-Height="50px">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("batchNo") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Grade" SortExpression="Grade">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("grade") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Product Type" SortExpression="Product Type">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lLabName" runat="server" Text='<%# Eval("productType") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                                                                                                
                                                                        <asp:TemplateField HeaderText="HeadLessWeight" SortExpression="HeadLessWeight">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("sampleHeadlessWeight") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="GradewiseYeild%" SortExpression="Gradewiseyeild">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("YieldPercentage") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--<asp:TemplateField HeaderText="Average Yield%" SortExpression="HeadLessWeight">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("AvgYieldper") %>' />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                                        </asp:TemplateField>--%>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

