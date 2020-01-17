<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Life++ Donation</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            background: #fff;
            color: #fff;
            font-family: Arial;
            font-size: 12px;
        }

        .body {
            position: absolute;
            top: -20px;
            left: -20px;
            right: -40px;
            bottom: -40px;
            width: auto;
            height: auto;
            background-image: url(img/1.jpeg);
            background-size: cover;
            -webkit-filter: blur(5px);
            z-index: 0;
        }

        .grad {
            position: absolute;
            top: -20px;
            left: -20px;
            right: -40px;
            bottom: -40px;
            width: auto;
            height: auto;
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(0,0,0,0)), color-stop(100%,rgba(0,0,0,0.65))); /* Chrome,Safari4+ */
            z-index: 1;
            opacity: 0.7;
        }

        .header {
            position: absolute;
            top: calc(50% - 30px);
            left: calc(50% - 230px);
            z-index: 2;
        }

            .header div {
                float: left;
                color: #fff;
                font-family: 'Exo', sans-serif;
                font-size: 35px;
                font-weight: 200;
            }

                .header div span {
                    color: 	#ff0000 !important;
                }

        .login {
            position: absolute;
            top: calc(50% - 90px);
            left: calc(50% - 120px);
            height: 150px;
            width: 350px;
            padding: 10px;
            z-index: 2;
        }

            .login input[type=text] {
                width: 250px;
                height: 30px;
                background: transparent;
                border: 1px solid rgba(255,255,255,0.6);
                border-radius: 2px;
                color: #fff;
                font-family: 'Exo', sans-serif;
                font-size: 16px;
                font-weight: 400;
                padding: 4px;
            }

        .password {
            width: 250px;
            height: 30px;
            background: transparent;
            border: 1px solid rgba(255,255,255,0.6);
            border-radius: 2px;
            color: #fff;
            font-family: 'Exo', sans-serif;
            font-size: 16px;
            font-weight: 400;
            padding: 4px;
            margin-top: 10px;
        }

        .nLogin {
            width: 260px;
            height: 35px;
            background: #fff;
            border: 1px solid #fff;
            cursor: pointer;
            border-radius: 2px;
            color: #8B0000;
            font-family: 'Exo', sans-serif;
            font-size: 16px;
            font-weight: 400;
            padding: 6px;
            margin-top: 10px;
        }

            .nLogin:hover {
                opacity: 0.8;
            }

            .nLogin:active {
                opacity: 0.6;
            }

        .login input[type=text]:focus {
            outline: none;
            border: 1px solid rgba(255,255,255,0.9);
        }

        .password:focus {
            outline: none;
            border: 1px solid rgba(255,255,255,0.9);
        }

        .nLogin:focus {
            outline: none;
        }

        ::-webkit-input-placeholder {
            color: rgba(255,255,255,0.6);
        }

        ::-moz-input-placeholder {
            color: rgba(255,255,255,0.6);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="body"></div>
        <div class="grad"></div>
        <div class="header">
            <div>Life<span>++</span></div>
        </div>
        <br />
        <div class="login">
            <asp:Panel ID="Panel1" runat="server">
                <asp:Label ID="lblLogin" runat="server" Text="Login" Font-Size="Large"></asp:Label><br />
                <br />
                <asp:TextBox ID="tbxemail" class="email" placeholder="Email Address" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="tbxpassword" class="password" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" class="nLogin" OnClick="btnLogin_Click" /><br />
                <br />
                <asp:LinkButton ID="linkFGPassword" runat="server" Font-Size="Medium" ForeColor="White" OnClick="linkFGPassword_Click">Forget Password?</asp:LinkButton><br /><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblOutput" runat="server" Text="" Font-Size="Medium"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Reset Password" Font-Size="Large"></asp:Label><br />
                <br />
                <asp:TextBox ID="tbxFgEmail" class="email" placeholder="Email Address" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnFgSubmit" runat="server" Text="Submit" class="nLogin" OnClick="btnFgSubmit_Click"  /><br /><br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="linkBack" runat="server" Font-Size="Medium" ForeColor="White" OnClick="linkBack_Click">Back to Login Page</asp:LinkButton>
                <br /><br />
                <asp:Label ID="lblOutput2" runat="server" Text="" Font-Size="Medium"></asp:Label>
            </asp:Panel>
        </div>
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    </form>
</body>
</html>
