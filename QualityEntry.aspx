<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="QualityEntry.aspx.cs" Inherits="AQUA.QualityEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


     <style>

    tbody tr:first-child{
      
    position: sticky;
    top: 0;    
}

</style>

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

                    <h4 class="header green">Quality Entry</h4>

                    <div class="row">
                        <div class="col-sm-12">
                            <%-- <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Quality Information</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Quality Information</h5>
                                <div class="row mb-0">
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <asp:HiddenField ID="hdnQtyID" runat="server" />
                                            <label for="fname">Type of Testing</label>
                                            <asp:DropDownList ID="ddlTestingType" runat="server" CssClass="form-control has-success" AutoPostBack="true" OnSelectedIndexChanged="ddlTestingType_SelectedIndexChanged">
                                                <%--  <asp:ListItem Text="--Select--" Value="0" />
                                                <asp:ListItem Text="Purchase Testing" Value="PurchaseTesting" />
                                                <asp:ListItem Text="FG Testing" Value="FGTesting" />--%>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage=" Please select Testing Type" ControlToValidate="ddlTestingType" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="fname" style="font-size: 14px">Lab Name</label>
                                            <asp:DropDownList ID="ddlLabName" runat="server" CssClass="form-control border border-primary">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage=" Please select Lab Name" ControlToValidate="ddlLabName" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Shipment PO No.</label>
                                            <asp:TextBox ID="txtShipmentNo" runat="server" onkeypress="return allowOnlyDigitLetters(event,this);" MaxLength="15" CssClass="form-control border border-success" placeholder="Shipment No." />
                                            <asp:RequiredFieldValidator ID="rfvShipmentNo" runat="server" Display="Dynamic" ErrorMessage=" Please enter Shipment Number" ControlToValidate="txtShipmentNo" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Batch No.</label>
                                            <asp:TextBox ID="txtBatchNo" runat="server" onkeypress="return allowOnlyDigits(event,this);" MaxLength="15" CssClass="width-100" placeholder="Batch No." />
                                            <asp:RequiredFieldValidator ID="rfvBatchNo" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>


                                <div class="row mb-0">
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">No. of Samples tested </label>
                                            <asp:TextBox ID="txtNoofSampleTest" runat="server" CssClass="form-control border border-success" onkeypress="return allowOnlyDigitLetters(event,this);" MaxLength="15" placeholder="Samples tested" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ErrorMessage=" Please enter No. of Sample" ControlToValidate="txtNoofSampleTest" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Testing Date </label>
                                            <asp:TextBox ID="txtTestingDate" runat="server" TextMode="Date" CssClass="form-control border border-success" placeholder="Enter Harvest End Time Here" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage=" Please select Testing Date" ControlToValidate="txtTestingDate" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-3 row">
                                            <label for="lname">Index </label>
                                            <asp:DropDownList ID="ddlIndex" runat="server" CssClass="form-control border border-success">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="ddlIndex" InitialValue="0" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--</div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="space-6"></div>
                    <div class="row">
                        <div class="col-sm-6">
                            <%-- <div class="widget-box">
                                <div class="widget-header">
                                    <h5 class="widget-title">Antibiotic Test Results</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Antibiotic Test Results</h5>

                                <fieldset>
                                    <div class="row mb-3">
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <label for="lname">AOZ </label>
                                                <asp:TextBox ID="txtAOZ" runat="server" CssClass="form-control border border-success" placeholder="Enter AOZ" MaxLength="6" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage=" Please enter AOZ" ControlToValidate="txtAOZ" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <label for="lname">AHD </label>
                                                <asp:TextBox ID="txtAHD" runat="server" MaxLength="6" CssClass="form-control border border-success" placeholder="Enter AHD" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic" ErrorMessage=" Please enter AHD" ControlToValidate="txtAHD" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                            <label for="lname">SEM </label>
                                            <div class="mb-3 row">
                                                <asp:TextBox ID="txtSEM" runat="server" MaxLength="6" CssClass="form-control border border-success" placeholder="Enter SEM" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic" ErrorMessage=" Please enter SEM" ControlToValidate="txtSEM" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <label for="lname">AMOZ </label>
                                                <asp:TextBox ID="txtAMOZ" runat="server" MaxLength="6" CssClass="form-control border border-success" placeholder="Enter AMOZ" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage=" Please enter AMOZ" ControlToValidate="txtAMOZ" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-md-12">
                                            <div class="mb-3 row">
                                                <label for="lname">CAP </label>
                                                <asp:TextBox ID="txtCap" runat="server" MaxLength="6" CssClass="form-control border border-success" placeholder="Enter CAP" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage=" Please enter CAP" ControlToValidate="txtCap" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <%-- </div>
                            </div>--%>
                        </div>

                        <div class="col-sm-6">
                            <%--<div class="widget-box">
                                <div class="widget-header">
                                    <h5 class="widget-title">Microbial Test results</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Microbial Test results</h5>

                                <div class="row mb-3">
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">TPC </label>
                                            <asp:TextBox ID="txtTPC" runat="server" CssClass="form-control border border-success" MaxLength="6" onkeypress="return isNumber(event)" placeholder="Enter TPC" />

                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtTPC" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">E-Coli</label>
                                            <asp:TextBox ID="txtEColi" runat="server" CssClass="form-control border border-success" MaxLength="10" placeholder="Enter E-Coli" />

                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtECoil" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Vibrio </label>
                                            <%--   <asp:TextBox ID="txtVibrio" runat="server" CssClass="form-control border border-success" placeholder="Enter Vibrio" />--%>
                                            <asp:DropDownList ID="ddlVibrio" runat="server" CssClass="form-control border border-success">
                                                <asp:ListItem Text="select Vibrio Here" Value="0" />
                                                <asp:ListItem Text="Present" Value="Present" />
                                                <asp:ListItem Text="Absent" Value="Absent" />
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtVibrio" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Salmonella </label>
                                            <%--   <asp:TextBox ID="txtSalmonella" runat="server" CssClass="form-control border border-success" placeholder="Enter Salmonella" />--%>
                                            <asp:DropDownList ID="ddlSalmonella" runat="server" CssClass="form-control border border-success">
                                                <asp:ListItem Text="select Salmonella Here" Value="0" />
                                                <asp:ListItem Text="Present" Value="Present" />
                                                <asp:ListItem Text="Absent" Value="Absent" />
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtSalmonella" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                </div>

                                <div class="row mb-3">
                                    <div class="col-md-12">
                                        <div class="mb-3 row">
                                            <label for="lname">Staphylococcus </label>
                                            <asp:TextBox ID="txtStaphylococcus" runat="server" CssClass="form-control border border-success" MaxLength="10" placeholder="Enter Staphylococcus" />

                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtStaphylococcus" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <%-- </div>
                            </div>--%>
                        </div>

                    </div>

                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-6">
                            <%--<div class="widget-box">
                                <div class="widget-header">
                                    <h5 class="widget-title">Illegal Dyes test result</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Illegal Dyes test result</h5>

                                <fieldset>

                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <label for="lname">Malachite Green </label>
                                                <asp:TextBox ID="txtMalachiteGreen" runat="server" CssClass="form-control border border-success" placeholder="Enter Malachite Green" />

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <label for="lname">Crystal Violet </label>
                                                <asp:TextBox ID="txtCrystalViolet" runat="server" CssClass="form-control border border-success" placeholder="Enter Crystal Violet" />
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <label for="lname">Leuco Malachite Green </label>
                                                <asp:TextBox ID="txtLeucoMalachiteGreen" runat="server" CssClass="form-control border border-success" placeholder="Enter Leuco Malachite Green" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <label for="lname">Leuco Crystal Voilet </label>
                                                <asp:TextBox ID="txtLeucoCrystalViolet" runat="server" CssClass="form-control border border-success" placeholder="Enter Leuco Crystal Violet" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <%-- </div>
                            </div>--%>
                        </div>

                        <div class="col-sm-6">
                            <%-- <div class="widget-box">
                                <div class="widget-header">
                                    <h5 class="widget-title">Sulphite Test Results</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Sulphite Test Results</h5>

                                <div class="mb-3 row">
                                    <label for="lname">SO2 </label>
                                    <%--<asp:TextBox ID="txtSO2" runat="server" CssClass="form-control border border-success" placeholder="Enter SO2" />--%>
                                    <asp:DropDownList ID="ddlSO2" runat="server" CssClass="form-control border border-success">
                                        <asp:ListItem Text="select SO2 Here" Value="0" />
                                        <asp:ListItem Text="Present" Value="Present" />
                                        <asp:ListItem Text="Absent" Value="Absent" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%-- </div>
                            </div>--%>
                        </div>

                    </div>

                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-12">
                            <%-- <div class="widget-box">
                                <div class="widget-header widget-header-small">
                                    <h5 class="widget-title lighter">Micro Sanitary Test</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Micro Sanitary Test</h5>

                                <div class="row mb-3">
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">FILTH Status </label>
                                            <asp:DropDownList ID="ddlFilthStatus" runat="server" CssClass="form-control border border-success">
                                                <asp:ListItem Text="select FILTH Status Here" Value="0" />
                                                <asp:ListItem Text="Pass" Value="Pass" />
                                                <asp:ListItem Text="Fail" Value="Fail" />
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Failure Reason</label>
                                            <asp:TextBox ID="txtFReason1" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-3 row">
                                            <label for="lname">Failure Reason </label>
                                            <asp:TextBox ID="txtFReason2" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <%-- </div>
                            </div>--%>
                        </div>
                    </div>


                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-12">
                            <%-- <div class="widget-box">
                                <div class="widget-header widget-header-small">
                                    <h5 class="widget-title lighter">Final Result Details</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>

                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Final Result Details</h5>

                                <div class="row mb-3">
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Sample Result</label>
                                            <asp:DropDownList ID="ddlSampleResult" runat="server" CssClass="form-control border border-success">
                                                <%--   <asp:ListItem Text="-select-" Value="0" />
                                                        <asp:ListItem Text="Pass" Value="Pass" />
                                                        <asp:ListItem Text="Fail" Value="Fail" />--%>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ErrorMessage=" Please select sample result" ControlToValidate="ddlSampleResult" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="fname">Test Performed By</label>
                                            <asp:TextBox ID="txtPerformedBy" runat="server" CssClass="form-control border border-success" placeholder="Enter Test Performed By " />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="fname">Entry Done By</label>
                                            <asp:TextBox ID="txtEntryDoneBy" runat="server" CssClass="form-control border border-success" placeholder="Enter entry done by " />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="mb-3 row">
                                            <label for="lname">Remarks </label>
                                            <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />


                                        </div>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <div class="mb-3 row">
                                            <label for="lname">Failure Reason</label>
                                            <asp:TextBox ID="txtRemarks1" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="mb-3 row">
                                            <label for="lname">Test Report No. </label>
                                            <asp:TextBox ID="txtRemarks2" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />
                                        </div>
                                    </div>
                                </div>
                                <%-- </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>

                    <div class="space-6"></div>
                    <div class="p-3 border-top">
                        <div class="text-lg-end">
                            <asp:Button ID="btnSave" runat="server" Class="btn btn-info btn-lg px-" Text="Save" ValidationGroup="id1" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info btn-lg px-" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />
                            <asp:Label ID="lblMessage" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divGridView" runat="server">
                <div class="page-content">
                    <h4 class="header green">Quality Details</h4>
                    <div class="row">
                        <%-- <div class="col-lg-12">
                            <div class="card">
                               
                                <div>
                                    <div class="card-body">
                                        <div class="table-responsive">--%>





                        <div class="col-xs-12">
                            <%--  <h3 class="header smaller lighter blue">Quality Entry</h3>--%>

                            <div class="card-body border-top">
                                <asp:Button ID="btnQualityEntry" runat="server" Text="Quality Entry" type="button" OnClick="btnQualityEntry_Click" class="btn btn-secondary rounded-pill px-4 ms-2 text-white" /><%----%>
                                <div class="row" id="statusID" runat="server" visible="false">
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="lblStatus" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="clearfix">
                                <div class="pull-right tableTools-container"></div>
                            </div>
                            <div class="table-header">
                                Results for "QUALITY DETAILS"
                            </div>
                            <div class="form-horizondal" id="frmdetl" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                <table id="dynamic-tabl" class="table table-striped table-bordered table-hover alert-dark table-condensed">

                                    <table id="file_export" class="table table-bordered nowrap display">
                                        <asp:GridView ID="gvQualityDetails" class="table table-success table-bordered" Width="100%" BorderWidth="1px" BorderStyle="Double" runat="server" AllowSorting="True" EmptyDataText="No Data Found" PageSize="3" AutoGenerateColumns="False" OnRowEditing="gvQualityDetails_RowEditing" OnPageIndexChanging="gvQualityDetails_PageIndexChanging" OnRowDeleting="gvQualityDetails_RowDeleting">
                                            <AlternatingRowStyle />
                                            <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" SortExpression="NO.">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID") %>' />
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TypeofTesting" SortExpression="TypeofTesting">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lTestingType" ItemStyle-ForeColor="#ff0000" runat="server" Text='<%# Eval("TypeofTesting") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lab Name" SortExpression="LabName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lLabName" runat="server" Text='<%# Eval("LabName") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Shipment Number" SortExpression="ShipmentPONo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lUserType" ForeColor="#990000" runat="server" Text='<%# Eval("ShipmentPONo") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Batch Number" SortExpression="BatchNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lDesignation" runat="server" Text='<%# Eval("BatchNo") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Testing Date" SortExpression="TestingDate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lDepartment" ForeColor="#006666" runat="server" Text='<%# Eval("TestingDate") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Index" SortExpression="IndexValue">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lMobileNumber" runat="server" ItemStyle-ForeColor="#ff0000" Text='<%# Eval("IndexValue") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sample Result" SortExpression="SampleResult">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lEmailAddress" ForeColor="#000066" runat="server" Text='<%# Eval("SampleResult") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Performed By" SortExpression="PerformedBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lPErformedBy" runat="server" Text='<%# Eval("TestPerformedBy") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entered By" SortExpression="EntryDoneBy">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lEntryDone" runat="server" Text='<%# Eval("EntryDoneBy") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Failure Reason" SortExpression="OverallFailureReason">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lReason" runat="server" Text='<%# Eval("OverallFailureReason") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEdit" ImageUrl="~/images/Edit.png" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgDelete" ImageUrl="~/images/Delete.png" runat="server" Width="20" Height="20" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?')" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                    <ItemStyle BorderColor="#3699FF" BorderWidth="1px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BorderColor="#3699FF" BorderWidth="1px" />
                                            <FooterStyle BorderColor="#3699FF" BorderWidth="1px" />
                                        </asp:GridView>
                                    </table>

                                </table>
                            </div>
                        </div>




                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

