<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PeelingWorkEfficiency.aspx.cs" Inherits="AQUA.PeelingWorkEfficiency" %>

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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <h4 class="header green">Daywise Peeling Worker Efficiency</h4>


                    <div class="row">
                        <div class="col-sm-12">
                            <div class=" card">
                                <div class="card-body" style="border: groove">
                                    <h5 class="card-title" style="font-weight: bold; color: brown"></h5>


                                               <div class="row">
                                                                <div class="col-sm-3">
                                                                    <div class="mb-3">
                                                                   
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        <h5 class="col-sm-7 widget-title bigger lighter green ">Select Date</h5>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                             <asp:TextBox ID="txtDate" runat="server" CssClass="form-control border border-success" TextMode="Date"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="* Required" ControlToValidate="txtDate" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                       <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" class="btn btn-primary rounded-pill px-4" Text="View" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-2">
                                                                    <div class="mb-3">
                                                                        
                                                                    </div>
                                                                </div>

                                                            </div>








                                   
                                </div>
                            </div>
                        </div>
                    </div>





                    <div class="row" id="divDetails" runat="server">
                        <div class="col-sm-12">

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Daywise Peeling Worker Efficiency - Details</h5>

                                <div class="row">
                                    <div class="col-xs-12">
                                        <div class="card">

                                            <div class="card-body">
                                                <div id="education_fields" class=" mt-4"></div>
                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-7 widget-title bigger lighter green ">No of Worker</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-7 widget-title bigger lighter green">No of working Hrs</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-7 widget-title bigger lighter green">Peeled Qty</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-7 widget-title bigger lighter green">Output / Person / Hour </h5>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-3 widget-title bigger lighter green" for="form-field-1">Shift I</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift1Workers" onkeypress="return isNumber(event)" runat="server" MaxLength="6" CssClass="form-control border border-success" Font-Bold="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift1Hrs" onkeypress="return isNumberKey(event)" runat="server" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift1Qty" onkeypress="return isNumberKey(event)" OnTextChanged="txtShift1Qty_TextChanged" runat="server" MaxLength="6" AutoPostBack="true" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift1Efficency" Enabled="false" onkeypress="return isNumberKey(event)" runat="server" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-3 widget-title bigger lighter green" for="form-field-1">Shift II</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift2Workers" runat="server" onkeypress="return isNumber(event)" MaxLength="6" CssClass="form-control border border-success" Font-Bold="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift2Hrs" runat="server" onkeypress="return isNumberKey(event)" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift2Qty" runat="server" onkeypress="return isNumberKey(event)" OnTextChanged="txtShift2Qty_TextChanged" AutoPostBack="true" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtShift2Efficency" runat="server" Enabled="false" onkeypress="return isNumberKey(event)" MaxLength="6" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div class="row">
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <h5 class="col-sm-7 widget-title bigger lighter green ">Avg.Output/Hour</h5>

                                                        </div>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtAvgEff" runat="server" Enabled="false" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <div class="mb-3">

                                                            <h5 class="col-sm-7 widget-title bigger lighter green ">Remarks</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="mb-3">
                                                            <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" Font-Bold="true" CssClass="form-control border border-success"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>

                                                </hr>
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
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

