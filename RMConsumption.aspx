<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="RMConsumption.aspx.cs" Inherits="AQUA.RMConsumption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <h4 class="header green">Soaking - RM Consumption</h4>
                    <div class="row" id="statusID" runat="server">
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:Label ID="lblStatus" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblMsgSuccess" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="#339933" />
                                <asp:Label ID="lblMsgError" runat="server" Font-Bold="True" Font-Size="9pt" ForeColor="Red" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="input-group">
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <div class=" card">
                                <%--<div class="card-header" style="border: 1px; border-style: solid">
                                    <h5 class="card-title">RM Consumption</h5>
                                </div>
                                <div class="card-body">
                                   <%-- <div class="card-actions">--%>


                                <div class="card-body" style="border: groove">
                                    <h5 class="card-title" style="font-weight: bold; color: brown">RM Consumption</h5>

                                    <div class="row">
                                        <div class="col-xs-12">
                                            <!-- PAGE CONTENT BEGINS -->
                                            <%-- <form class="form-horizontal" role="form">--%>


                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <div class="mb-3">
                                                        
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="mb-2">
                                                        <h5 class="col-sm-7 widget-title bigger lighter green ">Select Date</h5>
                                                         </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="mb-3">
                                                     <asp:TextBox ID="txtDate" runat="server" CssClass="form-control border border-success" TextMode="Date"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="* Required" ControlToValidate="txtDate" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                   
                                                    </div>
                                                </div>
                                               

                                            </div>



                                        </div>
                                    </div>

                                </div>

                                <div class="row" id="divDetails" runat="server">
                                    <div class="col-sm-12">

                                        <div class="card-body" style="border: groove">
                                            <h5 class="card-title" style="font-weight: bold; color: brown">RM Consumption - Details</h5>

                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="card">

                                                        <div class="card-body">

                                                            <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <%--<input type="text" class="form-control" id="Schoolname" name="Schoolname" placeholder="School Name">--%>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-7 widget-title bigger lighter green ">Opening Balance</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-7 widget-title bigger lighter green">Quantity Consumed</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-7 widget-title bigger lighter green">Closing Balance</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-7 widget-title bigger lighter green">Quantity Add</h5>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-5 widget-title bigger lighter green" for="form-field-1">Chemical</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtOBChemical" OnTextChanged="txtOBChemical_TextChanged" onkeypress="return isNumber(event)" Enabled="false" runat="server" MaxLength="6" CssClass="form-control border border-success" Font-Bold="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtConChemical" onkeypress="return isNumber(event)" OnTextChanged="txtConChemical_TextChanged" runat="server" MaxLength="6" Font-Bold="true" AutoPostBack="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtCloseChemical" onkeypress="return isNumber(event)" runat="server" MaxLength="6" Enabled="false" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtQuantityChemical" onkeypress="return isNumber(event)" runat="server" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-5 widget-title bigger lighter green" for="form-field-1">Additives</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtOBAdd" runat="server" onkeypress="return isNumber(event)" Enabled="false" OnTextChanged="txtOBAdd_TextChanged" MaxLength="6" CssClass="form-control border border-success" Font-Bold="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtConAdd" runat="server" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtConAdd_TextChanged" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtCloseAdd" runat="server" onkeypress="return isNumber(event)" MaxLength="6" Font-Bold="true" Enabled="false" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtQuantityAdd" runat="server" onkeypress="return isNumber(event)" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-3 widget-title bigger lighter green">Salt</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtOBSalt" OnTextChanged="txtOBSalt_TextChanged" runat="server" MaxLength="6" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control border border-success" Font-Bold="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtConSalt" runat="server" OnTextChanged="txtConSalt_TextChanged" AutoPostBack="true" MaxLength="6" Font-Bold="true" onkeypress="return isNumber(event)" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtCloseSalt" runat="server" MaxLength="6" Font-Bold="true" onkeypress="return isNumber(event)" Enabled="false" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:TextBox ID="txtQuantitySalt" runat="server" MaxLength="6" Font-Bold="true" onkeypress="return isNumber(event)" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>


                                                            <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                        <label class="col-sm-5">Remarks</label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-5">
                                                                    <div class="mb-5">
                                                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-2">
                                                                        <label class="col-sm-5">TYPE</label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control border border-success">
                                                                            <asp:ListItem Text="Phosphate" Value="Phosphate" />
                                                                            <asp:ListItem Text="Non- Phosphate" Value="Non- Phosphate" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="card-body border-top">
                                                                <div class="text-end">
                                                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" type="submit" Text="Save" class="btn btn-primary rounded-pill px-4" ValidationGroup="id1" />
                                                                    <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel" type="button" class="btn btn-primary rounded-pill px-4 ms-2 text-white" /><%----%>
                                                                    <asp:Label ID="lblMessage" Text="" runat="server" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
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

