<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="IQFOutFeed.aspx.cs" Inherits="AQUA.IQFOutFeed" %>

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
        function isNumberKey(evt, obj) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            var value = obj.value;
            var dotcontains = value.indexOf(".") != -1;
            if (dotcontains)
                if (charCode == 46) return false;
            if (charCode == 46) return true;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>
            <div class="main-content-inner">
                <div class="page-content">
                    <h4 class="header green">Outfeed - IQF</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Outfeed IQF -Search</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>
                              <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Outfeed IQF -Search</h5>
                                        <div class="row mb-0">
                                           
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Barcode ID</label>
                                                    <asp:TextBox ID="txtBarcodeID" runat="server" CssClass="form-control border border-success" />
                                                    <asp:RequiredFieldValidator ID="rfvBuyerName" Display="Dynamic" runat="server" ErrorMessage=" Please enter Barcode ID" ControlToValidate="txtBarcodeID" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="col-md-1">
                                                 <div class="mb-2 row">
                                                    <label for="fname">.</label>
                                                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="form-control btn-primary" Width="75px" ForeColor="White" OnClick="btnView_Click" />
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                             <div class="mb-2 row">
                                                    <label for="fname">Date & Time of Out Feed</label>
                                                    <asp:TextBox ID="txtOutFeedDateTime" Enabled="false" runat="server" CssClass="form-control border border-success" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage=" Please enter Barcode ID" ControlToValidate="txtOutFeedDateTime" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                               <%-- </div>

                            </div>--%>



                           <%-- <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Outfeed IQF - Entry</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>

                             <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Outfeed IQF - Entry</h5>


                                        <div class="row mb-0">
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Machine Number</label>
                                                    <asp:TextBox ID="txtMachineNumber" Enabled="false" runat="server" CssClass="form-control border border-success" />

                                                </div>

                                            </div>


                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Operation Type</label>
                                                    <asp:TextBox ID="txtOperationType" runat="server" Enabled="false" CssClass="form-control border border-success" />

                                                </div>
                                            </div>





                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Grade</label>
                                                    <asp:TextBox ID="txtGrade" Enabled="false" runat="server" CssClass="form-control border border-success" />

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Product Type</label>
                                                    <asp:TextBox ID="txtProductType" runat="server" Enabled="false" CssClass="form-control border border-success" />

                                                </div>
                                            </div>
                                        </div>

                                        <div class="row mb-0">



                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Chemical Treated</label>
                                                    <asp:TextBox ID="txtChemicalTreat" Enabled="false" runat="server" CssClass="form-control border border-success" />

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="fname">Batch Number</label>
                                                    <asp:TextBox Enabled="false" ID="txtBatchNumber" runat="server" CssClass="form-control border border-success" />

                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Flat Count</label>
                                                    <asp:TextBox ID="txtFlatCount" runat="server" Enabled="false" CssClass="form-control border border-success" />

                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Quantity (Wt.)</label>
                                                    <asp:TextBox ID="txtQuantity" runat="server" Enabled="false" CssClass="form-control border border-success" />

                                                </div>
                                            </div>
                                        </div>

                                    </div>
                              <%--  </div>
                            </div>--%>
                           <%-- <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Outfeed IQF - Quality</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            
                             <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Outfeed IQF - Quality</h5>
                                        <div class="row mb-0">

                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Actual Count</label>
                                                    <asp:TextBox ID="txtActualCount" onkeypress="return isNumber(event)" MaxLength="6" runat="server" CssClass="form-control border border-success" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage=" Please enter buyer name" ControlToValidate="txtActualCount" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                  <div class="mb-2 row">
                                                    <label for="fname">Glaze %</label>
                                                    <%--<asp:TextBox ID="txtGlaze" runat="server" onkeypress="return isNumber(event)" MaxLength="5" CssClass="form-control border border-success" />--%>
                                                      <asp:TextBox ID="txtGlaze" runat="server" 1 MaxLength="5" CssClass="form-control border border-success" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage=" Please enter buyer name" ControlToValidate="txtGlaze" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>



                                            <div class="col-md-2">
                                                  <div class="mb-2 row">
                                                    <label for="fname">Antibiotic Status </label>
                                                    <asp:DropDownList ID="ddlAntibioticStatus" runat="server" CssClass="form-control border border-success" />
                                                </div>
                                            </div>

                                            <div class="col-md-2">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Deglazed Wt.</label>
                                                    <asp:TextBox ID="txtDegWt" runat="server" onkeypress="return isNumber(event)" MaxLength="6" CssClass="form-control border border-success" />
                                                </div>
                                            </div>


                                            <div class="col-md-2">
                                                  <div class="mb-2 row">
                                                    <label for="fname">Uniformity / BS Ratio</label>
                                                    <asp:TextBox ID="txtUnifor" runat="server" onkeypress="return isNumberKey(event)" MaxLength="6" CssClass="form-control border border-success" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-0">

                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Broken Pieces</label>
                                                    <asp:TextBox ID="txtBrokenPieces" runat="server" onkeypress="return isNumber(event)" MaxLength="6" CssClass="form-control border border-success" />
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="fname">Broken Tail</label>
                                                    <asp:TextBox ID="txtBrokenTail" runat="server" MaxLength="6" CssClass="form-control border border-success" />

                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                  <div class="mb-2 row">
                                                    <label for="fname">Discolouration</label>
                                                    <asp:TextBox ID="txtDis" runat="server" MaxLength="6" onkeypress="return isNumber(event)" CssClass="form-control border border-success" />
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="mb-2 row">
                                                    <label for="fname">Black Spot / Black Tail</label>
                                                    <asp:TextBox ID="txtBlackSpot" runat="server" MaxLength="6" onkeypress="return isNumber(event)" CssClass="form-control border border-success" />
                                                </div>
                                            </div>

                                            <div class="col-md-2">
                                                <div class="mb-2 row">
                                                    <label for="fname">Neck Meat</label>
                                                    <asp:TextBox ID="txtNeckMeat" runat="server" MaxLength="6" onkeypress="return isNumber(event)" CssClass="form-control border border-success" />
                                                </div>
                                            </div>
                                        </div>



                                        <div class="row mb-0">

                                            <div class="col-md-12">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Remarks</label>
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control border border-success" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                <%--</div>
                            </div>--%>



                        </div>
                    </div>


                    <div>
                        <div class="card-body border-top">
                            <asp:Button ID="btnSave" runat="server" type="submit" Text="Save" OnClick="btnSave_Click" class="btn-primary" ValidationGroup="id1" />
                            <asp:Button ID="btnClose" runat="server" Text="Cancel" type="button" OnClick="btnClose_Click" class="btn-primary" /><%----%>
                            <asp:Label ID="lblMessage" runat="server" Font-Size="15px"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

