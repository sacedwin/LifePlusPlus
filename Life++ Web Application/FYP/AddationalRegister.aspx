<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddationalRegister.aspx.cs" Inherits="AddationalRegister" %>

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

        #footer {
            background-color: #8B0000;
            bottom: 0;
            width: 100%;
            position: absolute;
            z-index: 1;
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
        td {
            border: 0px solid #ededed;
            border-top: 1px solid rgba(216, 216, 216, 0.0);
            padding: 6px 10px 6px 0;
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
                        <h1>Additional Register Form</h1>
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
                                    <th>Emergency Contact Person Name:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxEName" class="form-control" Width="200" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxEName" ErrorMessage="Name cannot be blank"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Phone Number:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxEPhone" class="form-control" Width="180" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter his/her phone number" ControlToValidate="tbxEPhone"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Relationship:*</th>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlRelation" class="form-control" Width="130" runat="server">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="Parent/Guardian">Parent/Guardian</asp:ListItem>
                                            <asp:ListItem Value="Child">Child</asp:ListItem>
                                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                            <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="relationVali" runat="server" ErrorMessage="Please select relationship" ControlToValidate="ddlRelation" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Add Emergency Contact" OnClick="btnSubmit_Click" />
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblOutput" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                            <!-- end id-form  -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

