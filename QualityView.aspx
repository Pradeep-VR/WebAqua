<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="QualityView.aspx.cs" Inherits="AQUA.QualityView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>

            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <%-- <div class="page-header">--%>
                    <%-- <div class="hr hr-18 dotted hr-double"></div>--%>

                    <%-- <h4 class="pink">
                    <i class="ace-icon fa fa-hand-o-right green"></i>
                    <a href="#modal-form" role="button" class="blue" data-toggle="modal">Form Inside a Modal Box </a>
                </h4>--%>
                    <%-- <div class="hr hr-18 dotted hr-double"></div>--%>
                    <h4 class="header green">Quality Details</h4>

                    <div class="row">
                        <div class="col-sm-12">
                          <%--  <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Quality Information</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>

                             <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Quality Information</h5>


                                        <div class="row mb-0">
                                            <div class="col-md-3">
                                                  <div class="mb-2 row">
                                                    <asp:HiddenField ID="hdnQtyID" runat="server" />
                                                    <label for="fname">Type of Testing</label>
                                                    <asp:DropDownList ID="ddlTestingType" runat="server" CssClass="form-control border border-primary">
                                                        <%--  <asp:ListItem Text="--Select--" Value="0" />
                                                <asp:ListItem Text="Purchase Testing" Value="PurchaseTesting" />
                                                <asp:ListItem Text="FG Testing" Value="FGTesting" />--%>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage=" Please select Testing Type" ControlToValidate="ddlTestingType" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname" style="font-size: 14px">Lab Name</label>
                                                    <asp:DropDownList ID="ddlLabName" runat="server" CssClass="form-control border border-primary">
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ErrorMessage=" Please select Lab Name" ControlToValidate="ddlLabName" ForeColor="Red" ValidationGroup="id1" InitialValue="-Select-" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="lname">Shipment PO No.</label>
                                                    <asp:TextBox ID="txtShipmentNo" runat="server" onkeypress="return allowOnlyDigitLetters(event,this);" MaxLength="15" CssClass="form-control border border-success" placeholder="Shipment No." />

                                                    <asp:RequiredFieldValidator ID="rfvShipmentNo" runat="server" Display="Dynamic" ErrorMessage=" Please enter Shipment Number" ControlToValidate="txtShipmentNo" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                  <div class="mb-2 row">
                                                    <label for="lname">Batch No.</label>
                                                    <asp:TextBox ID="txtBatchNo" runat="server" onkeypress="return allowOnlyDigits(event,this);" MaxLength="15" CssClass="form-control border border-success" placeholder="Batch No." />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtBatchNo" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row mb-0">
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="lname">No. of Samples tested </label>
                                                    <asp:TextBox ID="txtNoofSampleTest" runat="server" CssClass="form-control border border-success" onkeypress="return allowOnlyDigitLetters(event,this);" MaxLength="15" placeholder="Samples tested" />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ErrorMessage=" Please enter No. of Sample" ControlToValidate="txtNoofSampleTest" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="lname">Testing Date </label>
                                                    <asp:TextBox ID="txtTestingDate" runat="server" CssClass="form-control border border-success" placeholder="Enter Harvest End Time Here" />

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage=" Please select Testing Date" ControlToValidate="txtTestingDate" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                              <div class="mb-2 row">
                                                    <label for="lname">Index </label>
                                                    <asp:DropDownList ID="ddlIndex" runat="server" CssClass="form-control border border-success">
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="ddlIndex" InitialValue="0" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>


                                    <%--</div>
                                </div>--%>
                            </div>
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
                                                   <div class="mb-2 row">
                                                        <label for="lname">AOZ </label>
                                                        <asp:TextBox ID="txtAOZ" runat="server" CssClass="form-control border border-success" placeholder="Enter AOZ" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage=" Please enter AOZ" ControlToValidate="txtAOZ" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                  <div class="mb-2 row">
                                                        <label for="lname">AHD </label>
                                                        <asp:TextBox ID="txtAHD" runat="server" CssClass="form-control border border-success" placeholder="Enter AHD" />

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic" ErrorMessage=" Please enter AHD" ControlToValidate="txtAHD" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>


                                                <div class="col-md-3">
                                                     <div class="mb-2 row">
                                                    <label for="lname">SEM </label>
                                                   
                                                        <asp:TextBox ID="txtSEM" runat="server" CssClass="form-control border border-success" placeholder="Enter SEM" />

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic" ErrorMessage=" Please enter SEM" ControlToValidate="txtSEM" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                      <div class="mb-2 row">
                                                        <label for="lname">AMOZ </label>
                                                        <asp:TextBox ID="txtAMOZ" runat="server" CssClass="form-control border border-success" placeholder="Enter AMOZ" />

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage=" Please enter AMOZ" ControlToValidate="txtAMOZ" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-md-12">
                                                      <div class="mb-2 row">
                                                        <label for="lname">CAP </label>
                                                        <asp:TextBox ID="txtCap" runat="server" CssClass="form-control border border-success" placeholder="Enter CAP" />

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage=" Please enter CAP" ControlToValidate="txtCap" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>



                                  <%--  </div>
                                </div>--%>
                            </div>
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
                                                <div class="mb-2 row">
                                                    <label for="lname">TPC </label>
                                                    <asp:TextBox ID="txtTPC" runat="server" CssClass="form-control border border-success" placeholder="Enter TPC" />

                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtTPC" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="lname">E-Coli </label>
                                                    <asp:TextBox ID="txtECoil" runat="server" CssClass="form-control border border-success" placeholder="Enter E-Coil" />

                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Display="Dynamic" runat="server" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtECoil" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="lname">Vibrio </label>
                                                    <asp:TextBox ID="txtVibrio" runat="server" CssClass="form-control border border-success" placeholder="Enter Vibrio" />

                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtVibrio" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="lname">Salmonella </label>
                                                    <asp:TextBox ID="txtSalmonella" runat="server" CssClass="form-control border border-success" placeholder="Enter Salmonella" />

                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" Display="Dynamic" runat="server" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtSalmonella" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row mb-3">
                                            <div class="col-md-12">
                                               <div class="mb-2 row">
                                                    <label for="lname">Staphylococcus </label>
                                                    <asp:TextBox ID="txtStaphylococcus" runat="server" CssClass="form-control border border-success" placeholder="Enter Staphylococcus" />

                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic" ErrorMessage=" Please enter BatchNo" ControlToValidate="txtStaphylococcus" ForeColor="Red" ValidationGroup="id1" Font-Size="15pt"></asp:RequiredFieldValidator>--%>
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
                                                    <div class="mb-2 row">
                                                        <label for="lname">Malachite Green </label>
                                                        <asp:TextBox ID="txtMalachiteGreen" runat="server" CssClass="form-control border border-success" placeholder="Enter Malachite Green" />


                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                      <div class="mb-2 row">
                                                        <label for="lname">Crystal Violet </label>
                                                        <asp:TextBox ID="txtCrystalViolet" runat="server" CssClass="form-control border border-success" placeholder="Enter Crystal Violet" />


                                                    </div>
                                                </div>

                                                 <div class="col-md-6">
                                                      <div class="mb-2 row">
                                                        <label for="lname">Leuco Malachite Green </label>
                                                        <asp:TextBox ID="txtLeucoMalachiteGreen" runat="server" CssClass="form-control border border-success" placeholder="Enter Leuco Malachite Green" />


                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                      <div class="mb-2 row">
                                                        <label for="lname">Leuco Crystal Voilet </label>
                                                        <asp:TextBox ID="txtLeucoCrystalViolet" runat="server" CssClass="form-control border border-success" placeholder="Enter Leuco Crystal Violet" />
                                                    </div>
                                                </div>
                                            </div>


                                        </fieldset>



                                   <%-- </div>
                                </div>--%>
                            </div>
                        </div>


                        <div class="col-sm-6">
                            <%--<div class="widget-box">
                                <div class="widget-header">
                                    <h5 class="widget-title">Sulphite Test Results</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>
                             <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Sulphite Test Results</h5>

                                         <div class="mb-2 row">
                                            <label for="lname">SO2 </label>
                                            <asp:TextBox ID="txtSO2" runat="server" CssClass="form-control border border-success" placeholder="Enter SO2" />

                                        </div>
                                    </div>
                                <%--</div>
                            </div>--%>


                        </div>

                    </div>

                    <div class="space-6"></div>

                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="widget-box">
                                <div class="widget-header widget-header-small">
                                    <h5 class="widget-title lighter">Micro Sanitary Test</h5>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-main">--%>
                              <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Micro Sanitary Test</h5>

                                        <div class="row mb-3">
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="lname">FILTH Status </label>
                                                    <asp:DropDownList ID="ddlFilthStatus" runat="server" CssClass="form-control border border-success">
                                                       <%-- <asp:ListItem Text="select Filth status Here" Value="0" />
                                                        <asp:ListItem Text="Pass" Value="Pass" />
                                                        <asp:ListItem Text="Fail" Value="Fail" />--%>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                  <div class="mb-2 row">
                                                    <label for="lname">Failure Reason</label>
                                                    <asp:TextBox ID="txtFReason1" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-2 row">
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
                                                <div class="mb-2 row">
                                                    <label for="lname">Sample Result</label>
                                                    <asp:DropDownList ID="ddlSampleResult" runat="server" CssClass="form-control border border-success">
                                                        <asp:ListItem Text="select Sample Result Here" Value="0" />
                                                        <asp:ListItem Text="Pass" Value="Pass" />
                                                        <asp:ListItem Text="Fail" Value="Fail" />
                                                    </asp:DropDownList>


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                 <div class="mb-2 row">
                                                    <label for="fname">Test Performed By</label>
                                                    <asp:TextBox ID="txtPerformedBy" runat="server" CssClass="form-control border border-success" placeholder="Enter Test Performed By " />


                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="fname">Entry Done By</label>
                                                    <asp:TextBox ID="txtEntryDoneBy" runat="server" CssClass="form-control border border-success" placeholder="Enter entry done by " />



                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="mb-2 row">
                                                    <label for="lname">Remarks </label>
                                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />


                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-md-6">
                                                 <div class="mb-2 row">
                                                    <label for="lname">Failure Reason</label>
                                                    <asp:TextBox ID="txtRemarks1" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />

                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="mb-2 row">
                                                    <label for="lname">Test Report No. </label>
                                                    <asp:TextBox ID="txtRemarks2" TextMode="MultiLine" runat="server" CssClass="form-control border border-success" placeholder="" />

                                                </div>
                                            </div>
                                        </div>


                                    <%--</div>
                                </div>--%>
                            </div>
                        </div>
                    </div>

                    <div class="space-6"></div>

                    <div class="text-lg-end right ">
                        <asp:Label ID="lblMessage" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>

                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info btn-lg px-" Text="Cancel" CausesValidation="False" OnClick="btnCancel_Click" />

                    </div>

                </div>
                <%--</div>--%>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-content-inner" id="divGridView" runat="server">
                <div class="page-content">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card">
                                <%--<div id="divCreate" runat="server">--%>
                            

                                <div>
                                    <div class="card-body">
                                        <h4 class="header green">Quality View</h4>

                                        <div class="table-responsive table-secondary">
                                            <%--<table id="tblTest">--%>

                                            <div class="card-body">

                                                <div class="row mb-0">
                                                    <div class="col-md-3">
                                                        <div class="form-floating mb-2">
                                                            <asp:Button ID="btnExcel" runat="server" Class="btn btn-info btn-lg px-" Text="Export to Excel" ValidationGroup="id1" OnClick="btnExcel_Click" /><%--</td>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div>
                                                   <%-- <div class="card-body">--%>
                                                        <%-- <h4 class="card-title">Quality Details</h4>--%>

                                                        <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                                            <table id="file_export" class="table table-bordered nowrap display">
                                                                <asp:GridView ID="gvQualityDetails" runat="server" class="table table-success table-bordered" GridLines="Both"  Width="100%" AllowSorting="True"  EmptyDataText="No Data Found" PageSize="11" AutoGenerateColumns="False" OnRowEditing="gvQualityDetails_RowEditing">
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
                                                                        <asp:TemplateField HeaderText="Type of Testing" SortExpression="TypeofTesting">
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
                                                                                <asp:Label ID="lUserType" ForeColor="#006666" runat="server" Text='<%# Eval("ShipmentPONo") %>' />
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
                                                                            <ItemStyle Width="150px" />
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

                                                                        <asp:TemplateField HeaderText="View" SortExpression="View">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgView" ImageUrl="~/images/file.png" Height="30px" Width="30px" runat="server" CommandName="Edit" CausesValidation="false" ToolTip="View" />
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
                                                  <%--  </div>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </div>


                                </div>
                                <%--  </table>--%>
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


