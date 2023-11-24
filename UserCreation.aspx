<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="UserCreation.aspx.cs" Inherits="AQUA.UserCreation" %>

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

        function isalNum(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if ((cc > 47 && cc < 58) || (cc > 64 && cc < 91) || (cc > 96 && cc < 123)) {
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
                    <div class="row">
                        <div class="col-sm-12">

                            <div class="card">

                                <h4 class="card-title">User Creation</h4>

                                <hr>



                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">First Name</label>
                                            <div class="col-sm-9">

                                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="15" placeholder="Enter First Name Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Last Name</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="15" placeholder="Enter Last Name Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="* Required" ControlToValidate="txtLastName" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">User ID</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtUserName" runat="server" onkeypress="return isalNum(event)" CssClass="form-control" MaxLength="10" placeholder="Enter User Name Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="* Required" ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">User Role</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlUserType" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvUserType" runat="server" InitialValue="-Select-" Display="Dynamic" ValidationGroup="id1" ControlToValidate="ddlUserType" ForeColor="Red" Text="* Required" ErrorMessage="ErrorMessage"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Action Type</label>
                                            <div class="col-sm-9">
                                                <asp:RadioButtonList ID="rblProcessIn" runat="server" OnTextChanged="rblProcessIn_TextChanged" RepeatLayout="Flow" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="rblProcessIn_SelectedIndexChanged">
                                                    <asp:ListItem Text="Web" Value="Web" />
                                                    <asp:ListItem Text="Android" Value="Android" />
                                                    <asp:ListItem Text="Both" Value="Both" Selected="True" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Password</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="Enter Password Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="* Required" ControlToValidate="txtpassword" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtpassword" ID="revPasswordLen" ValidationExpression="^[\s\S]{8,15}$" runat="server" ErrorMessage="Password must be between 3 and 15 characters long." ForeColor="Red" ValidationGroup="id1" Font-Size="7pt"></asp:RegularExpressionValidator>
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtpassword" ID="revPassword" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$" runat="server" ForeColor="Red" ValidationGroup="id1" Font-Size="7pt" ErrorMessage="Must contain at least one uppercase letter, one lowercase letter, one number, and one special character."></asp:RegularExpressionValidator>


                                            </div>
                                        </div>
                                    </div>
                                </div>




                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Confirm Pass.</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtConfirmpassword" runat="server" MaxLength="20" name="password2" CssClass="form-control" TextMode="Password" placeholder="Enter confirm Password Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="* Required" ControlToValidate="txtConfirmpassword" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Mis-matched!" ControlToCompare="txtpassword" Display="Dynamic" ControlToValidate="txtConfirmpassword" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:CompareValidator>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Department</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlDeparment" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Required" ControlToValidate="ddlDeparment" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="rgfDepartment" runat="server" InitialValue="-Select-" Display="Dynamic" ValidationGroup="id1" ControlToValidate="ddlDeparment" ForeColor="Red" Text="* Required" ErrorMessage="ErrorMessage"></asp:RequiredFieldValidator>


                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Designation</label>
                                            <div class="col-sm-9">
                                                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rgfdesignation" runat="server" InitialValue="-Select-" Display="Dynamic" ValidationGroup="id1" ControlToValidate="ddlDesignation" ForeColor="Red" Text="* Required" ErrorMessage="ErrorMessage"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Email Address</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Email Address Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="regEmail" Display="Dynamic" runat="server" ErrorMessage="* Required" Text="* Required" ControlToValidate="txtEmailAddress" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="Invalid" Text="* Invalid format" ControlToValidate="txtEmailAddress" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Mobile Number</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtMobileNumber" runat="server" onkeypress="return isNumber(event)" CssClass="form-control" MaxLength="10" placeholder="Enter Mobile Number Here"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMobileNumber" Display="Dynamic" runat="server" ErrorMessage="* Required" Text="* Required" ControlToValidate="txtMobileNumber" ForeColor="Red" ValidationGroup="id1" Font-Size="10pt"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMobileNumber" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{10,}$" runat="server" ForeColor="Red" ValidationGroup="id1" ErrorMessage="Invalid mobile number."></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6" id="divLabelName" runat="server">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Lab Name</label>
                                            <div class="col-sm-8">
                                                <asp:DropDownList ID="ddlLabName" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Required" ControlToValidate="ddlLabName" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="10pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue="-Select-" Display="Dynamic" ValidationGroup="id1" ControlToValidate="ddlLabName" ForeColor="Red" Text="* Required" ErrorMessage="ErrorMessage"></asp:RequiredFieldValidator>


                                            </div>
                                        </div>
                                    </div>
                                </div>


















                                <hr>

                                <div class="p-3 border-top">
                                    <div class="text-end">
                                        <asp:Button ID="btnSave" runat="server" type="submit" Text="Save" class="btn btn-dark rounded-pill px-4 waves-effect waves-light" OnClick="btnSave_Click" ValidationGroup="id1" />
                                        <asp:Button ID="btnClose" runat="server" Text="Cancel" type="button" class="btn btn-dark rounded-pill px-4 waves-effect waves-light" OnClick="btnClose_Click" /><%----%>
                                    </div>
                                </div>

                            </div>
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



                    <div class="row">
                        <div class="col-lg-12">
                            <h3>USER CREATION</h3>

                            <div>
                                <asp:Button ID="btnCreateNew" runat="server" Text="Create New " type="button" OnClick="btnCreateNew_Click" class="btn btn-primary rounded-pill px-4" /><%----%>
                                <div class="row" id="statusID" runat="server" visible="false">
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:Label ID="lblStatus" runat="server" Font-Size="15px" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <!-- ---------------------
                            start Primary border Table
                        ---------------- -->
                            <div class="card">
                                <div class="d-flex border-bottom title-part-padding align-items-center">
                                    <div>
                                        <h4 class="card-title mb-0">User Details</h4>
                                    </div>

                                </div>
                                <div class="card-body">

                                    <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 350px">
                                        <table class="table customize-table table-bordered mb-0 v-middle">
                                            <asp:GridView ID="gvUsers" runat="server" AllowPaging="True" class="table customize-table table-bordered mb-0 v-middle" AllowSorting="True" ShowFooter="True" EmptyDataText="No Data Found" PageSize="100" AutoGenerateColumns="False" OnRowDeleting="gvUsers_RowDeleting" OnRowEditing="gvUsers_RowEditing">
                                                <%-- <AlternatingRowStyle BackColor="#F0F0F0" />
                                            <RowStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" SortExpression="NO.">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID") %>' />
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User Name" SortExpression="FullName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lFullName" runat="server" Text='<%# Eval("FullName") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User ID" SortExpression="UserName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lUserName" runat="server" Text='<%# Eval("UserName") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User Role" SortExpression="UserType">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lUserType" runat="server" Text='<%# Eval("UserType") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDesignation" runat="server" Text='<%# Eval("Designation") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Department" SortExpression="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lDepartment" runat="server" Text='<%# Eval("Department") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="White" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile Number" SortExpression="MobileNumber">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lMobileNumber" runat="server" Text='<%# Eval("MobileNumber") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="White" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email Address" SortExpression="EmailAddress">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lEmailAddress" runat="server" Text='<%# Eval("EmailAddress") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="White" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Access Type" SortExpression="ProcessIn">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lCreatedDate" runat="server" Text='<%# Eval("ProcessIn") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="White" />
                                                    </asp:TemplateField>
                                                    <%--   <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lActive" ForeColor="#006600" runat="server" Text='<%# Eval("Active") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Edit" SortExpression="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgEdit" ImageUrl="~/images/blueEdit.png" runat="server" ToolTip="Edit" Width="20" Height="20" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="White" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDelete" ImageUrl="~/images/blueDelete1.png" runat="server" Width="20" Height="20" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this record?')" ToolTip="Delete" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="bg-primary text-white" ForeColor="White" HorizontalAlign="Center" BorderWidth="1" BorderColor="Blue" />
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
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

