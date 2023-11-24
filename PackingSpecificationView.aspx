<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PackingSpecificationView.aspx.cs" Inherits="AQUA.PackingSpecificationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

<%--      // this style added start--%>

   <style>

    tbody tr:first-child{      
    position: sticky;
    top: 0;
}

    /*tbody td:first-child{      
    position: sticky;
    left:0;
}*/


</style>
    <%--      // this style added end--%>   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divGridView" runat="server">
                <div class="page-content">
                   <%-- <asp:Timer ID="timerBind" runat="server" OnTick="timerBind_Tick" Interval="5000" /> --%>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <div>
                                    <div class="card-body">
                                        <h4 class="header green">Packing Specification Details</h4>
                                        <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 500px; position:sticky; top:0;" >
                                            <%-- <table id="file_export1" class="table table-bordered nowrap display"  >--%>
                                            <table id="file_export1" class="table table-bordered nowrap display sticky-header-table">
   
                                                <asp:GridView ID="gvPackSpecDetails" class="table table-success table-bordered" BorderWidth="1px" BorderStyle="Double" runat="server" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" AutoGenerateColumns="False" Width="70%">
                                                    <AlternatingRowStyle BackColor="#F0F0F0" />
                                                    <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" BackColor="LightCyan" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Buyer Name" runat="server">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("BuyerName") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" Width="100%" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" Width="100%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PO No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lLabName" runat="server" Text='<%# Eval("PONumber") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>

                                                        <%--<asp:TemplateField HeaderText="Cargo Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lUserType" ForeColor="#990000" runat="server" Text='<%# Eval("CargoNumber") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    </asp:TemplateField>--%>

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
                                                        
                                                        <asp:TemplateField HeaderText="Odr Glaze %">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDepartment1" ForeColor="#006666" runat="server" Text='<%# Eval("Glaze") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Unit">
                                                            <ItemTemplate>
                                                                <asp:Label ID="ld2323" ForeColor="#006666" runat="server" Text='<%# Eval("Unit") %>' />
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


                                                        <asp:TemplateField HeaderText="Bal Slabs">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDepartment51" ForeColor="#006666" runat="server" Text='<%# Eval("BalanceSlabs") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Bal Cartons">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDepartment61" ForeColor="#006666" runat="server" Text='<%# Eval("BalanceCartons") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bal Qty">
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
                                                                <asp:Label ID="lDepart" ForeColor="#006666" runat="server" Text='<%# Eval("Packingstatus") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                            <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Repacking Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lDep" ForeColor="#006666" runat="server" Text='<%# Eval("RepackStatus") %>' />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

