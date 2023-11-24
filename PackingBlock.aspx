  <%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PackingBlock.aspx.cs" Inherits="AQUA.PackingBlock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- divEntry--%>
    <div class="main-content-inner" id="divEntry" runat="server">
        <div class="page-content">

            <asp:UpdatePanel ID="upQualityEntry" runat="server">
                <ContentTemplate>

                    <h4 class="header green">Packing Module - BLOCK</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Outfeed Entry</h5>
                                <div class="row mb-0">
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Barcode ID</label>
                                            <asp:TextBox ID="txtBarcodeID" runat="server" MaxLength="10" CssClass="form-control border border-success" />
                                            <asp:RequiredFieldValidator ID="rfvBuyerName" Display="Dynamic" runat="server" ErrorMessage=" Please enter Barcode ID" ControlToValidate="txtBarcodeID" ForeColor="Red" ValidationGroup="id1" InitialValue="0" Font-Size="10pt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-md-1">
                                        <div class="mb-2 row">
                                            <label for="fname">.</label>
                                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="form-control btn-primary"  ForeColor="White" OnClick="btnView_Click" />
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">MachineNo</label>
                                             <asp:DropDownList ID="ddlmchno" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlmchno_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Total Infeed Quantity</label>
                                            <asp:TextBox ID="txtQuantity" runat="server" MaxLength="10" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">SoakingTankGrade</label>
                                            <asp:TextBox ID="txtsoakingtankgrade" runat="server" MaxLength="6" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Glaze %</label>
                                            <asp:TextBox ID="txtGlaze" runat="server" MaxLength="10" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Antibiotic Status</label>
                                            <asp:TextBox ID="txtResult" runat="server" MaxLength="10" Enabled="false" CssClass="form-control border border-success" />
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="mb-2 row">
                                            <label for="fname"></label>
                                            <asp:Label ID="lblMessage1" runat="server" Font-Size="15px" ForeColor="Green"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--</div>
                            </div>--%>
                        </div>
                    </div>
                    <div class="row" id="divPack" runat="server">
                        <div class="col-sm-12">
                            <%-- <div class="widget-box">
                                <div class="widget-header" style="border: 1px; border-style: solid">
                                    <h5 class="widget-title">Packing</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">--%>
                            <div class="card-body" style="border: groove">
                                <h5 class="card-title" style="font-weight: bold; color: brown">Outfeed Entry</h5>
                                <div class="row mb-0">
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Type of Slab Packing </label>
                                            <asp:DropDownList ID="ddlSlabPack" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSlabPack_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Customer Order No.</label>
                                            <asp:DropDownList ID="ddlCustOrderNo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCustOrderNo_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Brand</label>
                                            <%--<asp:TextBox ID="txtBrand" runat="server" CssClass="form-control border border-success" />--%>
                                            <asp:DropDownList ID="ddlBrand" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                              <label for="fname">Packing Style</label>
                                            <%--  <asp:TextBox ID="txtPackingStyle" runat="server" CssClass="form-control border border-success" />--%>
                                            <asp:DropDownList ID="ddlPackingStyle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPackingStyle_SelectedIndexChanged" CssClass="form-control border border-success" />
                                            <div class="col-xs-12 col-sm-12" id="divPS" runat="server" visible="false">
                                                <div class="input-xxlarge input-group ">
                                                    <asp:TextBox ID="txtPackingStyle" runat="server" CssClass="form-control border border-success" onkeypress="return isNumber(event)" MaxLength="8" />
                                                    <%--<asp:RequiredFieldValidator ID="rfvPackingStyle" Display="Dynamic" runat="server" ErrorMessage=" * Select" ControlToValidate="txtPackingStyle" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-asterisk"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtPackingStyle1" runat="server" CssClass="form-control border border-success" onkeypress="return isNumberKey(event)" MaxLength="8" />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="* Select" ControlToValidate="txtPackingStyle1" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Grade</label>
                                            <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                    <label for="fname">Order Glaze%</label>
                                            <asp:TextBox ID="txtorderglaze" runat="server" Enabled="false" CssClass="form-control border border-success" />
                                            </div>
                                        </div>                                    
                                </div>
                                <div class="row mb-0">
                                    <div class="col-md-1">
                                        <div class="mb-2 row">
                                            <label for="fname">ProductType</label>
                                            <asp:DropDownList ID="ddlVariety" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVariety_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                     <div class="col-md-1">
                                        <div class="mb-2 row">
                                            <label for="fname">GlazaSpec</label>
                                            <asp:DropDownList ID="ddlGlazeSpec" runat="server" AutoPostBack="true" EnableViewState="true" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Balance Slab</label>
                                            <asp:TextBox ID="txtBalSlab" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Balance Cartons</label>
                                            <asp:TextBox ID="txtBalCartonPack" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Bal Qty</label>
                                            <asp:TextBox ID="txtBalQtyPacked" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Storage Type</label>
                                            <asp:DropDownList ID="ddlStorage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStorage_SelectedIndexChanged" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Production Code </label>
                                            <asp:TextBox ID="txtProductionCode" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    
                                </div>
                                <div class="row mb-0">
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Export Code </label>
                                            <asp:TextBox ID="txtExportCode" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">No. of Slabs in Carton</label>
                                            <asp:TextBox ID="txtNoOfSlab1Carton" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Batch No</label>
                                            <asp:TextBox ID="txtBatchNo" Enabled="false" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">No. of Label Print</label>
                                            <asp:TextBox ID="txtNoLabelPrint" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Barcode Number</label>
                                            <asp:TextBox ID="txtBarcodeNumber" runat="server" Enabled="false" CssClass="form-control border border-success" />

                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">Next Process</label>
                                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlNextProcess_SelectedIndexChanged" ID="ddlNextProcess" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>   
                                    
                                    <div class="col-md-2">
                                        <div class="mb-2 row">
                                            <label for="fname">WeightUnits</label>
                                            <asp:DropDownList ID="ddlweightunits"  runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>

                                     <div class="col-md-2">
                                            <label>Act Packing Style</label>
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="input-xxlarge input-group ">
                                                    <asp:TextBox ID="txtactpacstyl1" runat="server" CssClass="form-control border border-success" onkeypress="return isNumber(event)" MaxLength="8" />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage=" * Select" ControlToValidate="txtPackingStyle" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-asterisk"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtactpacstyl2" runat="server" CssClass="form-control border border-success" onkeypress="return isNumberKey(event)" MaxLength="8" />
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="* Select" ControlToValidate="txtPackingStyle1" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-3">
                                        <div class="mb-2 row" >
                                            <label for="fname">Remarks</label>
                                            <%--<asp:dropdownlist id="dropdown" runat="server" cssclass="form-control border border-success" />--%>
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control border border-success" TextMode="MultiLine" Height="75"/>
                                        </div>
                                    </div>
                                      <div class="col-md-3 mt-4" style="padding-left:30px">
                                        <div class="mb-5 row" >
                               <%-- <asp:Button ID="Button1" runat="server" CssClass="form-control btn-primary" Width="125px" ForeColor="White" Text="Label Print" ValidationGroup="id1" OnClick="btnPrint_Click" />
                                <asp:Label ID="Label1" runat="server" Font-Size="15px" ForeColor="Green"></asp:Label>--%>
                                             <asp:Button ID="btnPrint" runat="server" CssClass="form-control btn-primary" Width="125px" ForeColor="White" Text="Label Print" ValidationGroup="id1" OnClick="btnPrint_Click" />
                                             <asp:Label ID="Label1" runat="server" Font-Size="15px" ForeColor="Green"></asp:Label>
                                            </div>
                                        </div>
                                    <%-- <div class="col-md-3" style="padding-left:110px">
                                        <div class="mb-5 row" >                         
                                            <label for="fname">Selection of printer</label>                
                                            <asp:DropDownList ID="ddlprinting" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStorage_SelectedIndexChanged" CssClass="form-control border border-success"  />
                                        </div>--%>

                                    </div>
                                  
                                 <%--------------------TEST_PRINT_BTN---------------------%>
                                        <div class="col-md-5 mt-6" style="padding-left:30px">
                                            <div class="mb-5 row" >
                                                <asp:Button ID="btntest" runat="server" CssClass="form-control btn-primary" Width="125px" ForeColor="White" Text="Test Print" ValidationGroup="id1"  OnClick="btntest_Click" />
                                            </div>
                                        </div>
                                <div class="col-md-3 mt-4" style="padding-left:35px">
                                       <div class="mb-5 row" >
                                           <label for="fname">Select Printer</label>
                                           <select id="selected_device" style="width: 200px; height: 30px;" onchange="onDeviceSelected(this)"></select>
                                           <%--<asp:DropDownList ID="ddlPrinting" runat="server"></asp:DropDownList>--%>
                                       </div>
                                   </div>
                                     <%---------------------------------------------------------%>
                               
                                    <div class="col-md-2" visible="false">
                                        <div class="mb-2 row">
                                            <label for="fname"></label>
                                            <asp:CheckBox ID="chkLooseCarton" Visible="false" runat="server" CssClass="form-control border border-success" AutoPostBack="true" OnCheckedChanged="chkLooseCarton_CheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="col-md-2" id="divSlab" runat="server" visible="false">
                                        <div class="mb-2 row">
                                            <label for="fname">Loose slab </label>
                                            <asp:TextBox ID="txtLooseCotton" runat="server" CssClass="form-control border border-success" />
                                        </div>
                                    </div>                                    
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </ContentTemplate>
                 <%-- <Triggers>
                    <asp:PostBackTrigger ControlID="ddlVariety" />
                    <asp:PostBackTrigger ControlID ="ddlGrade" />
                </Triggers>--%>
            </asp:UpdatePanel>
            <div class="row mb-0">
                <div class="col-md-6">
                    <div class="text-lg-end">
                        <div class="widget-body">
                            <div class="widget-main">
                               <%-- <asp:Button ID="btnPrint" runat="server" CssClass="form-control btn-primary" Width="125px" ForeColor="White" Text="Label Print" ValidationGroup="id1" OnClick="btnPrint_Click" />--%>
                                <asp:Label ID="lblMessagePrint" runat="server" Font-Size="15px" ForeColor="Green"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

      <!---------------------------------------------------------------------------------------------------------------------------------------------->
                    
                      <script src="Content/BrowserPrint-3.1.250.min.js"></script>    
     <script type="text/javascript">
         var selected_device;
         var devices = [];
         //window.onload = setup_we;
         //window.onload = setup;

         function pageLoad(sender, args) {
             $(document).ready(function () {

                 setup();
                 //setup_we();

             });
         }

         function setup() {
             //Get the default device from the application as a first step. Discovery takes longer to complete.
             BrowserPrint.getDefaultDevice("printer", function (device) {

                 //Add device to list of devices and to html select element
                 selected_device = device;
                 devices.push(device);
                 var html_select = document.getElementById("selected_device");
                 var option = document.createElement("option");
                 option.text = device.name;
                 html_select.add(option);
                 ddlprinting.add(option);


                 //Discover any other devices available to the application
                 BrowserPrint.getLocalDevices(function (device_list) {
                     for (var i = 0; i < device_list.length; i++) {
                         //Add device to list of devices and to html select element
                         var device = device_list[i];
                         if (!selected_device || device.uid != selected_device.uid) {
                             devices.push(device);
                             var option = document.createElement("option");
                             option.text = device.name;
                             option.value = device.uid;
                             html_select.add(option);

                         }
                     }

                 }, function () { alert("Error getting local devices") }, "printer");

             }, function (error) {
                 alert(error);
             })
         }
         function getConfig() {
             BrowserPrint.getApplicationConfiguration(function (config) {
                 alert(JSON.stringify(config))
             }, function (error) {
                 alert(JSON.stringify(new BrowserPrint.ApplicationConfiguration()));
             })
         }
         function writeToSelectedPrinter(dataToWrite) {
             getDeviceCallback(selected_device);
             selected_device.send(dataToWrite, undefined, errorCallback);
         }
         var readCallback = function (readData) {
             if (readData === undefined || readData === null || readData === "") {
                 alert("No Response from Device");
             }
             else {
                 alert(readData);
             }

         }
         var errorCallback = function (errorMessage) {
             alert("Error: " + errorMessage);
         }
         function readFromSelectedPrinter() {

             selected_device.read(readCallback, errorCallback);

         }
         function getDeviceCallback(deviceList) {
             alert("Devices: \n" + JSON.stringify(deviceList, null, 4))
         }

         //function sendImage(imageUrl)
         //{
         //    url = window.location.href.substring(0, window.location.href.lastIndexOf("/"));
         //    url = url + "/" + imageUrl;
         //    selected_device.convertAndSendFile(url, undefined, errorCallback)
         //}
         //function sendFile(fileUrl){
         //    url = window.location.href.substring(0, window.location.href.lastIndexOf("/"));
         //    url = url + "/" + fileUrl;
         //    selected_device.sendFile(url, undefined, errorCallback)
         //}
         function onDeviceSelected(selected) {
             for (var i = 0; i < devices.length; ++i) {
                 if (selected.value == devices[i].uid) {
                     selected_device = devices[i];
                     getDeviceCallback(selected_device);
                     return;
                 }
             }
         }


         //--------------------------------------------------------------------------------------------//
         function setup_we() {
             BrowserPrint.getDefaultDevices("printer", function (device) {

                 //Add device to list of devices and to html select element
                 selected_device = device;
                 devices.push(device);
                 var html_select = document.getElementById("selected_device");
                 var option = document.createElement("option");

                 var selectOption = document.createElement("option");
                 selectOption.text = "-select-";
                 html_select.appendChild(selectOption);

                 option.text = device.name;
                 html_select.add(option);


                 //Discover any other devices available to the application
                 BrowserPrint.getLocalDevices(function (device_list) {
                     for (var i = 0; i < device_list.length; i++) {
                         //Add device to list of devices and to html select element
                         var device = device_list[i];
                         if (!selected_device || device.uid != selected_device.uid) {
                             devices.push(device);
                             var option = document.createElement("option");
                             option.text = device.name;
                             option.value = device.uid;
                             html_select.add(option);

                         }
                     }

                 }, function () { alert("Error getting local devices") }, "printer");

             }, function (error) {
                 alert(error);
             })
         }

     </script>                      
                    <%-- <body>
                        <span style="padding-right:50px; font-size:200%">Zebra Browser Print Test Page</span><br />
                        <span style="font-size:75%">This page must be loaded from a web server to function properly.</span><br><br>
                        Selected Device: <select id="selected_device" onchange=onDeviceSelected(this);></select> <!--  <input type="button" value="Change" onclick="changeDevice();">--> <br /><br />
                        <input type="button" value="Get Application Configuration" onclick="getConfig()"><br /><br />
                        <input type="button" value="Send Config Label" onclick="writeToSelectedPrinter('~wc')"><br /><br />
                        <input type="button" value="Send ZPL Label" onclick="writeToSelectedPrinter('^XA^FO200,200^A0N36,36^FDTest Label^FS^XZ')"><br /><br />
                        <input type="button" value="Get Status" onclick="writeToSelectedPrinter('~hs'); readFromSelectedPrinter()"><br /><br />
                        <input type="button" value="Get Local Devices" onclick="BrowserPrint.getLocalDevices(getDeviceCallback, errorCallback);"><br /><br />
                        <input type="text" name="write_text" id="write_text"><input type="button" value="Write" onclick="writeToSelectedPrinter(document.getElementById('write_text').value)"><br /><br />
                        <input type="button" value="Read" onclick="readFromSelectedPrinter()"><br /><br />
                        <input type="button" value="Send BMP" onclick="sendImage('Zebra_logobox.bmp');"><br /><br />
                        <input type="button" value="Send JPG" onclick="sendImage('ZebraGray.jpg');"><br /><br />
                        <input type="button" value="Send File" onclick="sendFile('wc.zpl');"><br /><br />
                    </body>--%>


</asp:Content>

