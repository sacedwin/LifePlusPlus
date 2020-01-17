<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EstablishmentRegister.aspx.cs" Inherits="EstablishmentRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
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

        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            line-height: 20px;
            color: #535b60;
        }

        /*#footer {
            background-color: #8b0000;
            bottom: 0;
            width: 100%;
            position: fixed;
            z-index: 1;

        }*/

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
    </style>

    <br />
    <br />
    <br />


    <section id="cta-1" class="section-padding">
        <div class="section section-breadcrumbs">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>Establishment Registration</h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="basic-login">
            <div class="section">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- start id-form -->
                            <table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
                                <tr>
                                    <th>Email:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxEmail" runat="server" placeholder="email" required="true" class="form-control input-md" TextMode="Email"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <th>Name:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxName" runat="server" placeholder="name" required="true" class="form-control input-md"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <th>Password:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxPassword" runat="server" placeholder="password" required="true" class="form-control input-md" TextMode="Password"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <th>Establishment Type:*</th>
                                    <td class="auto-style1">
                                        <asp:RadioButtonList ID="rbtnlstType" runat="server">
                                            <asp:ListItem>Hospital</asp:ListItem>
                                            <asp:ListItem>Blood Bank</asp:ListItem>
                                            <asp:ListItem>NGO</asp:ListItem>
                                            <asp:ListItem>Emergency Responder</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>

                                </tr>
                                <tr>
                                    <th>Phone:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxPhone" runat="server" placeholder="phone" required="true" class="form-control input-md" TextMode="Phone"></asp:TextBox>

                                    </td>
                                </tr>

                                <tr>
                                    <th>Address:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxAddress" runat="server" placeholder="address" required="true" class="form-control input-md" TextMode="MultiLine"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-danger" OnClick="btnSubmit_Click" />
                                        <br />
                                                <asp:Label ID="lblOutput" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

