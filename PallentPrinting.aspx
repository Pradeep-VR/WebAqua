<%@ Page Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="PallentPrinting.aspx.cs" Inherits="AQUA.PallentPrinting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content-inner" id="divEntry" runat="server">
        <div class="page-content">
            <asp:UpdatePanel ID="upQualityEntry" runat="server">
                <ContentTemplate>
                    <h4 class="header green">Pallet Printing</h4>
                    <div class="row">
                        <div class="col-sm-12" id="dhn">
                            <div class="card-body" style="border: groove">
                                <div class="row mb-0">
                                    <div class="col-md-2" style="margin-left:100px">
                                        <div class="mb-2 row">
                                            <label for="fname"></label>
                                            <asp:Button ID="btnNEW" runat="server" Text="NEW" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnNEW_Click" />
                                        </div>
                                    </div> 
                                    <div class="col-md-2" style="margin-left:100px">
                                        <div class="mb-2 row">
                                            <label for="fname"></label>
                                            <asp:Button ID="btnExisting" runat="server" Text="EXISTING" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnExisting_Click"/>
                                        </div>
                                    </div>
                                    <div class="col-md-3 mt-4" style="padding-left:35px">
                                       <div class="mb-5 row" >
                                           <label for="fname">Select Printer</label>
                                           <select id="selected_device" style="width: 200px; height: 30px;" onchange="onDeviceSelected(this)"></select>
                                           <%--<asp:DropDownList ID="ddlPrinting" runat="server"></asp:DropDownList>--%>
                                       </div>
                                   </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" id="divnew" runat="server" visible="false">
                            <div class="col-sm-12" id="new">
                                <div class="card-body row" style="border: groove">
                                    <div class="col-5">                                    
                                        <h5 class="card-title" style="font-weight: bold; color: brown">NEW</h5>
                                        <div class="row">
                                            <div class="col-md-6 mb-1">                                                
                                                <label for="fname">PalletType</label>
                                                <asp:DropDownList ID="ddlpallet_new" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpallet_SelectedIndexChanged" CssClass="form-control border border-success" />
                                                                                             
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6 mb-2">
                                                <label for="fname">Pallet ID</label>   
                                                <asp:TextBox ID="txtPalletid_new" runat="server" CssClass="form-control border border-success" />
                                                                                                
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-5 mb-2">                                                
                                                <label for="fname">No Of Labels</label>
                                                <asp:TextBox ID="txtlabels_new" runat="server" CssClass="form-control border border-success" />
                                            </div>
                                             <div class="col-md-3">
                                                <label for="fname"></label>
                                                <asp:Button ID="btnSave_new" runat="server" Text="SAVE" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnSave_new_Click" />
                                            </div>
                                        </div>
                                        <div class="row">
                                           <div class="col-md-4">
                                                <label for="fname"></label>
                                                <asp:Button ID="btnsave_print" runat="server" Text="SAVE & PRINT" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnsave_print_Click" />
                                            </div>
                                            <div class="col-md-4">
                                                <label for="fname"></label>
                                                <asp:Button ID="btnClear_new" runat="server" Text="CLEAR" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnClear_new_Click" />
                                            </div>
                                        </div>
                                       <%-- <div class="row">
                                            <div class="col-md-4">
                                                <label for="fname"></label>
                                                <asp:Label ID="lblMessage1" runat="server" Font-Size="15px" ForeColor="Green"></asp:Label>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row" id="divexisting" runat="server" visible="false">
                            <div class="card-body" style="border: groove">
                            <div class="col-8">
                                <h5 class="card-title" style="font-weight: bold; color: brown">EXISTING</h5>
                                <div class="row">
                                    <div class="col-md-4 mb-2">
                                        <label for="fname">Pallet ID</label>
                                        <asp:TextBox ID="txtpalletid_ext" runat="server" CssClass="form-control border border-success" />
                                    </div>
                                    <div class="col-md-2">
                                        <label for="fname"></label>
                                        <asp:Button ID="btn_view_ext" runat="server" Text="Verify" CssClass="form-control btn-primary" ForeColor="White" OnClick="btn_view_ext_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mb-2">
                                         <label for="fname">PalletType</label>
                                        <%--<asp:DropDownList ID="ddlpallettyp_ext" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpallet_SelectedIndexChanged" CssClass="form-control border border-success" />--%>
                                        <asp:TextBox ID="ddlpallettyp_ext" runat="server" CssClass="form-control border border-success" enable="false"/>
                                    </div>                                     
                                </div>
                                <div class="row">
                                            <div class="col-md-6 mb-2">
                                                
                                                <label for="fname">No Of Labels</label>
                                                 <asp:TextBox ID="Nooflbl_ext" runat="server" CssClass="form-control border border-success" />
                                            </div>
                                        </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <label for="fname"></label>
                                        <asp:Button ID="btnprint_ext" runat="server" Text="PRINT" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnprint_ext_Click" />
                                    </div>
                                    <div class="col-md-3">
                                        <label for="fname"></label>
                                        <asp:Button ID="btnclear_ext" runat="server" Text="CLEAR" CssClass="form-control btn-primary" ForeColor="White" OnClick="btnclear_ext_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                      </div>
                    <asp:Label ID="lblMessage" runat="server" Visible="false" Text="" CssClass="text-success"></asp:Label>
    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <!------------------------------------------------------------------------------------------------------------>
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
</asp:Content>
