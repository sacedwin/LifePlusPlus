<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" EnableEventValidation="false" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .btnn {
            background-color: #8E8E8E;
            border: 0;
            border-radius: 3px;
            color: #FFF;
            cursor: pointer;
            box-shadow: 2px 2px 2px #111;
            width: 30%;
            height: 40px;
            text-align: left;
            position: relative;
            padding: 0;
            margin: 10px 0;
        }

        #footer {
            background-color: #8B0000;
            bottom: 0;
            width: 100%;
            position: absolute;
            z-index: 1;
        }

        .btnn span {
            font-size: 16px;
            line-height: 40px;
        }

        .btnn:active {
            top: 1px;
            box-shadow: 1px 1px 2px #000;
        }

        .btnn i {
            margin-right: 10px;
        }

        .facebook {
            background-color: #3B5998;
        }

            .facebook i {
                float: left;
                width: 44px;
                height: 40px;
                background: url("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACwAAAAoCAYAAACFFRgXAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAN1JREFUeNpi/P//P8NQAoyjDh518KiDRx086uBh62AtIOZE4r8A4qcUmwpyMJWxKxA//I8J2qlhPguVQ9UMiLcAMRutoo2Jyub10tKxtEjDb4FYCIn/C4jXA/FHIN4BZQ8qB38AYn4k/kQgLhjMSQIdfB/saXhIlMMGQDwHic2MJHcBiE8h8ZsoLYup4WAbID5MhLq/QMxLaTKhZ5K4SY00TU8HX6CKKVSulh/SojpGxkOulBh18KiDRx086uDRxg9eoIvW46BOx3O0mz/q4FEHjzp41MGjDiYXAAQYAJmVcB6iaE2HAAAAAElFTkSuQmCC") no-repeat center center;
            }

        .plus {
            padding-left: 54px;
            background-color: #393838;
        }

            .plus .i {
                border-radius: 3px;
                position: absolute;
                border-top: 8px solid #D64335;
                width: 44px;
                top: 0;
                bottom: 0;
                left: 0;
                margin-left: 0;
                border-right: 1px solid #343434;
                line-height: 26px;
            }

            .plus i:before {
                content: "g";
                font: 26px "Palatino Linotype", Georgia, serif;
                text-shadow: 1px 1px 1px #444;
                line-height: 0px;
                margin-left: 10px;
            }

            .plus i:after {
                content: "+";
                border-left: 11px solid #426AAD;
                background-color: #32A45E;
                border-right: 11px solid #F8CA32;
                width: 11px;
                font: 18px "Palatino Linotype", Georgia, serif;
                line-height: 38px;
                position: absolute;
                top: -8px;
                left: 12px;
                height: 8px;
            }

        .section-breadcrumbs {
            background: #222;
            background: rgba(255, 255, 255, 0.8);
            margin-bottom: 10px;
        }

            .section-breadcrumbs h1 {
                color: #222;
                font-size: 1.6em;
                margin-bottom: 0;
                text-transform: none;
            }

        .social-login p {
            text-align: center;
            font-size: 1.2em;
            font-style: italic;
            padding: 20px 0;
        }

        p {
            margin: 0 0 10px;
        }

        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        p {
            display: block;
            -webkit-margin-before: 1em;
            -webkit-margin-after: 1em;
            -webkit-margin-start: 0px;
            -webkit-margin-end: 0px;
        }

        element.style {
        }


        .section {
            padding: 11.8px 0;
            -webkit-transform: translateZ(0);
            -moz-transform: translateZ(0);
            -o-transform: translateZ(0);
            -ms-transform: translateZ(0);
            transform: translateZ(0);
        }



        div {
            display: block;
        }

        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            line-height: 20px;
            color: #535b60;
        }

        body {
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px;
            line-height: 1.42857143;
            color: #333;
            background-color: #fff;
        }

        html {
            font-size: 62.5%;
            -webkit-tap-highlight-color: rgba(0,0,0,0);
        }

        html {
            font-family: sans-serif;
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
        }

        :before, :after {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        :before, :after {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }

        .basic-login {
            background: rgba(255, 255, 255, 0.8);
            padding: 20px 20px 10px 20px;
            -webkit-border-radius: 5px;
            -webkit-background-clip: padding-box;
            -moz-border-radius: 5px;
            -moz-background-clip: padding;
            border-radius: 5px;
            background-clip: padding-box;
            -webkit-box-shadow: inset 0 1px #fff,0 0 4px #c8cfe6;
            -moz-box-shadow: inset 0 1px #fff,0 0 4px #c8cfe6;
            box-shadow: inset 0 1px #fff,0 0 4px #c8cfe6;
            color: inset 0 1px #fff,0 0 4px #c8cfe6;
        }



            .basic-login form {
                margin: 0;
            }

            .basic-login label {
                line-height: 30px;
                font-size: 1.2em;
            }

            .basic-login input[type="checkbox"] {
                margin-top: 4px;
            }

        .social-login p {
            text-align: center;
            font-size: 1.2em;
            font-style: italic;
            padding: 20px 0;
        }

        .social-login .social-login-buttons {
            text-align: center;
        }

            .social-login .social-login-buttons a {
                position: relative;
                display: inline-block;
                white-space: nowrap;
                height: 35px;
                line-height: 35px;
                padding-right: 15px;
                margin: 10px 5px;
                color: #fff;
                font-size: 1.1em;
                text-align: left;
                -webkit-border-radius: 3px;
                -webkit-background-clip: padding-box;
                -moz-border-radius: 3px;
                -moz-background-clip: padding;
                border-radius: 3px;
                background-clip: padding-box;
                -webkit-transition: opacity .2s linear;
                -moz-transition: opacity .2s linear;
                -o-transition: opacity .2s linear;
                -ms-transition: opacity .2s linear;
                transition: opacity .2s linear;
                -webkit-transform: translateZ(0);
                -moz-transform: translateZ(0);
                -o-transform: translateZ(0);
                -ms-transform: translateZ(0);
                transform: translateZ(0);
            }

                .social-login .social-login-buttons a:hover {
                    opacity: 0.8;
                    text-decoration: none;
                }

                .social-login .social-login-buttons a:before {
                    content: '';
                    display: block;
                    position: absolute;
                    top: 5px;
                    width: 24px;
                    height: 24px;
                    background-image: url(../img/social-login.png);
                    background-repeat: no-repeat;
                }

        .social-login .btn-facebook-login {
            padding-left: 35px;
            background-color: #6886bc;
            background-image: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/PjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iMTAwJSIgaGVpZ2h0PSIxMDAlIiB2aWV3Qm94PSIwIDAgMSAxIiBwcmVzZXJ2ZUFzcGVjdFJhdGlvPSJub25lIj48bGluZWFyR3JhZGllbnQgaWQ9ImdyYWQtdWNnZy1nZW5lcmF0ZWQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIiB4MT0iMCUiIHkxPSIwJSIgeDI9IjAlIiB5Mj0iMTAwJSI+PHN0b3Agb2Zmc2V0PSIwIiBzdG9wLWNvbG9yPSIjNjg4NmJjIiBzdG9wLW9wYWNpdHk9IjEiLz48c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiM0NjZjYTkiIHN0b3Atb3BhY2l0eT0iMSIvPjwvbGluZWFyR3JhZGllbnQ+PHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz48L3N2Zz4=);
            background-image: -moz-linear-gradient(top,#6886bc 0,#466ca9 100%);
            background-image: -webkit-linear-gradient(top,#6886bc 0,#466ca9 100%);
            background-image: -o-linear-gradient(top,#6886bc 0,#466ca9 100%);
            background-image: linear-gradient(top,#6886bc 0,#466ca9 100%);
        }

        .social-login .btn-twitter-login {
            padding-left: 45px;
            background-color: #25b6e6;
        }

        .social-login .btn-facebook-login:before {
            left: 10px;
            background-position: 0 0;
        }

        .social-login .btn-twitter-login:before {
            left: 15px;
            background-position: -48px 0;
        }

        .social-login .not-member p {
            font-size: 1.5em;
            font-weight: 600;
            font-style: normal;
            margin-top: 30px;
            border-top: 1px solid #CCC;
        }

        .section-padding {
            padding: 30px 0px;
        }
    </style>



    <section class="section-padding">
    </section>
    <section class="section-padding">
    </section>

    <section id="cta-1" class="section-padding">
        <div class="row">

            <div class="panel panel-red">

                <!-- /.panel-heading -->
                <div class="panel-body">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs">
                        <li><a href="CommonLogin.aspx" >User Login</a>
                        </li>
                        <li class="active"><a href="Login.aspx" >Establishment Login</a>
                        </li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div class="tab-pane fade " id="user">
                        </div>

                        <div class="tab-pane fade in active" id="establishment">
                            <div id="cta-1" class="section-padding">

                                <div class="not-member">
                                    <h5>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Not a member? 
                                   <asp:LinkButton ID="linkRegister2" runat="server" OnClick="linkRegister2_Click">Register here</asp:LinkButton>
                                    </h5>
                                </div>


                                <div class="basic-login">
                                    <div class="section">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-sm-5">
                                                    <div class="basic-login">
                                                        <form role="form" role="form">

                                                            <div class="form-group">
                                                                <asp:Label ID="Label3" class="icon-user" runat="server" Text="Email Address" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="tbxEmail2" class="form-control" runat="server" TextMode="Email" placeholder="example@domain.com" required="true"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Label ID="Label4" class="icon-lock" runat="server" Text="Password" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="tbxPassword2" class="form-control" runat="server" TextMode="Password" placeholder="********" required="true"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Label ID="lbl2Output" runat="server" ForeColor="Red"></asp:Label>
                                                                <br />
                                                                <asp:LinkButton ID="linkReset2" class="forgot-password" runat="server" OnClick="linkReset2_Click">Forgot password?</asp:LinkButton>
                                                                <asp:Button ID="btnSubmit2" class="btn btn-danger btn pull-right" runat="server" Text="Login" OnClick="btnSubmit2_Click" />
                                                                <div class="clearfix"></div>
                                                            </div>
                                                        </form>
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
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>

    </section>
</asp:Content>

