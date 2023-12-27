<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AQUA.Login" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="ks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />
    <title>Login Page - Barcode Digitization</title>

    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />
      
    <!-- text fonts -->
    <link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />

    <!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

    <style type="text/css">
        .form-control {
            margin-left: 14px;
        }
    </style>

</head>
<body class="login-layout">
    <form id="form1" runat="server">
        <div>
            <div class="main-container">
                <div class="main-content">
                    <div class="row">
                        <div class="col-sm-10 col-sm-offset-1">
                            <div class="login-container">
                                <div class="center">
                                    <h1>
                                        <asp:Image ID="imgLog" runat="server" ImageUrl="~/images/ITC-Ltd.png" Height="10%" Width="10%" />
                                        <span class="white" id="id-text2">Barcode Digitization</span>
                                        <span class="red"></span>
                                    </h1>
                                    <%--<h1>
                                        <asp:Image ID="imgLog" runat="server" ImageUrl="~/images/ITC_Limited-Logo.png" Height="15%" Width="15%" />                                        
                                        <i class="ace-icon fa fa-leaf green"></i>
                                    </h1>--%>
                                    <h4 class="blue" id="id-company-text">&copy; ITC Limited</h4>
                                </div>

                                <div class="space-6"></div>

                                <div class="position-relative">
                                    <div id="login-box" class="login-box visible widget-box no-border">
                                        <div class="widget-body">
                                            <div class="widget-main">
                                               <%-- <h4 class="header blue lighter bigger">
                                                    <i class="ace-icon fa fa-coffee green"></i>
                                                    Please Enter Your Information
                                                </h4>--%>
                                                <div class="space-6"></div>
                                                <%-- <form>--%>
                                                <fieldset>
                                                  <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" type="text" placeholder="User Name" />
                                                          <i class="ace-icon fa fa-user"></i>                                                            
                                                        </span>
                                                    </label>

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="Password" placeholder="Password" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        <asp:Button ID="LoginButton" runat="server" OnClick="LgnBtn_Click" Text="Login" style="margin-left: 19px" Width="151px" />
                                                        </span>
                                                    </label>

                                                    <div class="space"></div>

                                                    <%-- <div class="clearfix">--%>                                              
                                                   <%-- <ks:CaptchaControl ID="cptCaptcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                                        CaptchaHeight="40" CaptchaWidth="220" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                                        FontColor="#0066FF" NoiseColor="#B1B1B1" CaptchaChars="1234567890" />--%>

                                                    <div class="space-4"></div>
                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <asp:Label ID="lblerror" runat="server" Font-Size="28px" ForeColor="Red" Text="" />
                                                           
                                                        </span>
                                                    </label>

                                                </fieldset>
                                                <%-- </form>--%>

                                                <div class="social-or-login center">
                                                    <span class="bigger-110"></span>
                                                </div>
                                                <div class="space-6"></div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.main-content -->
            </div>
            <!-- /.main-container -->

            <!-- basic scripts -->

            <!--[if !IE]> -->
            <script src="assets/js/jquery-2.1.4.min.js"></script>
            <!-- <![endif]-->
            <!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
            <script type="text/javascript">
                if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
            </script>
            <!-- inline scripts related to this page -->
            <script type="text/javascript">
                jQuery(function ($) {
                    $(document).on('click', '.toolbar a[data-target]', function (e) {
                        e.preventDefault();
                        var target = $(this).data('target');
                        $('.widget-box.visible').removeClass('visible');//hide others
                        $(target).addClass('visible');//show target
                    });
                });

                //you don't need this, just used for changing background
                jQuery(function ($) {
                    $('#btn-login-dark').on('click', function (e) {
                        $('body').attr('class', 'login-layout');
                        $('#id-text2').attr('class', 'white');
                        $('#id-company-text').attr('class', 'blue');

                        e.preventDefault();
                    });
                    $('#btn-login-light').on('click', function (e) {
                        $('body').attr('class', 'login-layout light-login');
                        $('#id-text2').attr('class', 'grey');
                        $('#id-company-text').attr('class', 'blue');

                        e.preventDefault();
                    });
                    $('#btn-login-blur').on('click', function (e) {
                        $('body').attr('class', 'login-layout blur-login');
                        $('#id-text2').attr('class', 'white');
                        $('#id-company-text').attr('class', 'light-blue');

                        e.preventDefault();
                    });

                });
            </script>
        </div>
    </form>
</body>
</html>

