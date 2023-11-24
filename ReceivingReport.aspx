<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ReceivingReport.aspx.cs" Inherits="AQUA.ReceivingReport"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

        <div class="main-content-inner" id="divEntry" runat="server">
            <div class="page-content">
                <asp:UpdatePanel ID="upQualityEntry" runat="server">
                    <ContentTemplate>
                        <h4 class="header green">Receiving - Report</h4>
                        <div class="col-sm-12">
                            <div class="card-body" style="border: groove">
                                <div class="row mb-1">
                                    <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">From Year</label>
                                        <div class="form-control-sm">
                                              <asp:DropDownList ID="ddlfrmYear" CssClass="form-control border border-success" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlfrmYear_SelectedIndexChanged"  ></asp:DropDownList>    
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">To Year</label>
                                        <div class="form-control-sm">
                                              <asp:DropDownList ID="ddltoYear" CssClass="form-control border border-success" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddltoYear_SelectedIndexChanged" ></asp:DropDownList>    
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">Months</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control border border-success" ID="ddlMonth">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="mb-2 row">
                                        <label class="control-label">PurchaseType</label>
                                        <div class="form-control-sm">
                                            <asp:DropDownList runat="server" CssClass="form-control border border-success" ID="ddlPurchaseType" AutoPostBack="true" OnSelectedIndexChanged="ddlPurchaseType_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                            <label for="fname">.</label>
                                            <div class="form-control-sm">
                                            <asp:Button ID="btnView" runat="server" Visible="true" Text="View" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnView_Click" />
                                                </div>
                                        </div>                     
                                </div>
                                    <div class="col-sm-2">
                                        <div class="mb-2 row">
                                            <label for="fname">.</label>
                                            <div class="form-control-sm">
                                            <asp:Button ID="btnexport" runat="server" Visible="true" Text="Export" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnexport_Click" />
                                                </div>
                                        </div>                     
                                </div>
                                </div>
                                    <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px" runat="server">
                                    <table id="file_export" class="table table-bordered nowrap display">
                                        <asp:GridView ID="GVRecivingReport" runat="server" class="table table-success table-bordered" GridLines="Both"  Width="100%" AllowSorting="True"  EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False" >
                                            <AlternatingRowStyle />
                                            <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                            <Columns>
                                                <%--OnRowEditing="GradingFinalData_RowEditing"--%>
                                                 <asp:TemplateField HeaderText="Plant" SortExpression="Plant" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvPlant") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Year" SortExpression="Year" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvYear") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                 <%--<asp:TemplateField HeaderText="Month" SortExpression="Month" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvMonth") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>--%>

                                                 <%--<asp:TemplateField HeaderText="Week" SortExpression="Week" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvWeek") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>--%>

                                                 <asp:TemplateField HeaderText="Date" SortExpression="date" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvDate") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="BatchNo" SortExpression="BatchNo" ItemStyle-Height="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvBatchNo") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Party" SortExpression="Party">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("gvParty") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Range" SortExpression="range">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lLabName" runat="server" Text='<%# Eval("gvRange") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Range-2" SortExpression="range-2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lLabName" runat="server" Text='<%# Eval("gvBetweenRange") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                                                                                        
                                                <asp:TemplateField HeaderText="ADV" SortExpression="adv">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvAdv") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Count" SortExpression="Count">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvCount") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="HON QTY" SortExpression="headonqty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvHonQty") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="HLess Qty" SortExpression="HeadLessQty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvHLessQty") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="TargetYield" SortExpression="targetyield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvTargetYield") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Size" SortExpression="targetyield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvsize") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Yield" SortExpression="yield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvYield") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="PlantCount" SortExpression="plantcnt">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvPlantCount") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="PlantWt" SortExpression="plantweight">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvPlantWt") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="PlantYield" SortExpression="plantyield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvPlantYield") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Qty Diff" SortExpression="QtuDifference">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvQtyDiff") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Count Diff" SortExpression="countDifference">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvCountDiff") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Buying Type" SortExpression="byingtype">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvBuyingType") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Hon Qty IN TONS" SortExpression="HONQTYINTONS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvHONQTYTONS") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Hless Qty in Tons" SortExpression="Hlessqtyintons">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvHLessQTYTONS") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Party Loc" SortExpression="PartyLoc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvPartyLoc") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Village" SortExpression="vlg">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvVillage") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Mandal" SortExpression="mandal">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvMandal") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Distric" SortExpression="dstric">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvDistric") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Grader Name" SortExpression="Gradername">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvGradernme") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Plant Qty in Ton" SortExpression="plantqtyinton">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvPlantQtyTon") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Diff Yield" SortExpression="DiffYield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvDiffYield") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <%--<asp:TemplateField HeaderText="Sample HLV Qty" SortExpression="samplehlvqty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvSamHLVQty") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Sample HON Qty" SortExpression="sampleHonqty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvSamHonQty") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Sample Yield" SortExpression="samYield">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("gvSampleYield") %>' />
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
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>    
        </div>
</asp:Content>


            
                
                    
                    
                        
                            