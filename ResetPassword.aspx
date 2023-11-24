<%@ Page Title="" Language="C#" MasterPageFile="~/ITCAQUA.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="AQUA.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="upQualityEntry" runat="server">
        <ContentTemplate>


            <div class="main-content-inner" id="divEntry" runat="server">
                <div class="page-content">
                    <div class="row">
                        <div class="col-sm-12">

                            <div class="card">

                                <h4 class="card-title">Reset Password</h4>

                                <hr>
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
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">User ID</label>
                                            <div class="col-sm-9">

                                                <asp:DropDownList ID="ddlUserName" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="-Select-" ErrorMessage="Please enter user name" ControlToValidate="ddlUserName" ForeColor="Red" ValidationGroup="id1" Font-Size="7pt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Password</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control border" Font-Bold="true" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ErrorMessage="Please enter the password" ControlToValidate="txtNewPassword" ForeColor="Red" ValidationGroup="id1" Font-Size="7pt"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNewPassword" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{8,15}$" runat="server" ErrorMessage="Password must be between 8 and 15 characters long." ForeColor="Red" ValidationGroup="id1" Font-Size="7pt"></asp:RegularExpressionValidator>
                                                <%--<asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtNewPassword" ID="RegularExpressionValidator2" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&?,;:_|~{}=\+\-\!\.\*\(\)\[\] ]).+$" runat="server" ForeColor="Red" ValidationGroup="id1" Font-Size="7pt" ErrorMessage="Must contain at least one uppercase letter, one lowercase letter, one number, and one special character."></asp:RegularExpressionValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12 col-lg-6">
                                        <div class="mb-3 row">
                                            <label class="col-sm-3 text-end control-label col-form-label">Confirm Password</label>
                                            <div class="col-sm-9">

                                                <asp:TextBox ID="txtConfirmPassword" runat="server" Font-Bold="true" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Enter the confirm password" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="id1" Display="Dynamic" Font-Size="7pt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ErrorMessage="Confirm password not matched!" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="id1" Font-Size="7pt"></asp:CompareValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="p-3 border-top">
                                    <div class="text-end">

                                        <asp:Button ID="btnSave" runat="server" type="submit" Text="Save" class="btn btn-primary rounded-pill px-4" OnClick="btnSave_Click" ValidationGroup="id1" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" type="button" class="btn btn-primary rounded-pill px-4 ms-2 text-white" OnClick="btnCancel_Click" /><%----%>
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

