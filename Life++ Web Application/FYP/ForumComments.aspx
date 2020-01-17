<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForumComments.aspx.cs" Inherits="ForumComments" %>

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
            position: static;
            z-index: 1;
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

        .form-group {
            margin-bottom: 15px;
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

        td {
            border: 0px solid #ededed;
            border-top: 1px solid rgba(216, 216, 216, 0.0);
            padding: 6px 10px 6px 0;
        }
    </style>



    <br />

    <section id="cta-1" class="section-padding">
        <div class="section section-breadcrumbs">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <h1>
                            <asp:Label ID="lblheading" runat="server" Text=""></asp:Label>
                        </h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="basic-login">
            <div class="section">
                <div class="container">
                    <div class="row">

                        <div class="col-sm-12">

                            <table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">

                                <tr>
                                    <th>Title:</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lbltitle" runat="server" Font-Size="Medium" Text=""></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <th>Message:</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblmessage" runat="server" Font-Size="Medium" Text=""></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <th>Posted By: &nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblUser" runat="server" Font-Size="Medium" Text=""></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <th>Posted On:</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblDate" runat="server" Font-Size="Medium" Text=""></asp:Label>
                                    </td>

                                </tr>
                            </table>

                            <br />
                            <br />

                            <h4>Comments</h4>

                            <asp:Panel ID="PanelCMT" runat="server">
                                <asp:GridView ID="GridView1" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" Width="100%"  runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="comment"  HeaderText="Comments" FooterStyle-Wrap="false" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" >
                                            

                                        <ControlStyle Width="70%" />
                                        <FooterStyle Width="70%"  />
                                        <HeaderStyle Width="70%"  />
                                        <ItemStyle Width="70%"  />
                                            

                                        </asp:BoundField>
                                        <asp:BoundField DataField="commentby" HeaderText="By" >
                                            

                                        <ControlStyle Width="15%" />
                                        <FooterStyle Width="15%" Wrap="False"/>
                                        <HeaderStyle Width="15%" Wrap="False"/>
                                        <ItemStyle Width="15%" Wrap="False"/>
                                            

                                        </asp:BoundField>
                                        <asp:BoundField DataField="timeshow"  HeaderText="Time" >
                                           

                                        <ControlStyle Width="15%" />
                                        <FooterStyle Width="15%" Wrap="False"/>
                                        <HeaderStyle Width="15%" Wrap="False"/>
                                        <ItemStyle Width="15%" Wrap="False"/>
                                           

                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"  />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White"/>
                                    <RowStyle ForeColor="#333333" BackColor="#F7F6F3"  />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>



                            </asp:Panel>
                            <asp:Label ID="lblNotFound" runat="server" Text="Sorry there is no comment right now!" Visible="false"></asp:Label><br />
                            <br />
                            <br />
                            <br />
                            <asp:TextBox ID="tbxComment" Width="30%" Height="100px" placeholder="Type here to comment" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:Button ID="btnSumbit" class="btn-appoint" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
                            <asp:Label ID="lbloutput" runat="server" Text=""></asp:Label>
                            <br /><br /><br /><br />
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="< Back To Previous Page" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </div>
                    </div>

                </div>

            </div>
            <div class="space"></div>
        </div>
        <div class="space"></div>
    </section>
</asp:Content>

