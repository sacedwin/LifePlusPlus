<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TranscationHistory.aspx.cs" Inherits="TranscationHistory" %>

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

        #footer {
            background-color: #8B0000;
            bottom: 0;
            width: 100%;
            position: absolute;
            z-index: 1;
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



        .navba-fixed-left {
            width: 197px;
            position: fixed;
            border-radius: 0;
            height: 163px;
        }

        td {
            border: 0px solid #ededed;
            border-top: 1px solid rgba(216, 216, 216, 0.0);
            padding: 6px 10px 6px 0;
        }

        .navba {
            min-height: 50px;
            margin-bottom: 20px;
            border: 1px solid transparent;
            margin-top: 55px;
        }



        .navba-fixed-left + .container {
            padding-left: 230px;
        }

        .navba-fixed-left .navba-nav > li {
            width: 195px;
        }

        .navba-inverse {
            background-color: rgba(0,0,0,0);
            border-color: #222;
        }

        .navba {
            border-radius: 4px;
        }

        a {
            color: #222;
            text-decoration: none;
        }
    </style>

    <br />
    <br />
    <br />

    <section id="cta-1" class="section-padding">
        <div class="container">
            <div class="row">

                <div class="navba navba-inverse navba-fixed-left">

                    <ul class="nav navba-nav">
                        <li><a href="DonateAndRequest.aspx">- Request Blood/Plateles</a></li>
                        <li><a href="DonateOrgan.aspx">- Sign Up Donate Organ</a></li>
                        <li><a href="HistoryOrgan.aspx">- Current Organ Donations</a></li>
                        <li><a href="TranscationHistory.aspx">- History of transcation</a></li>
                    </ul>
                </div>
                <div class="container">
                    <div class="row">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Donation history"></asp:Label>

                        </h4>
                        <div class="basic-login">
                            <h5>
                                <asp:Label ID="Label1" runat="server" Text="">
                                </asp:Label></h5>

                            <table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvDHistory" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvDHistory_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="ldonorID" HeaderText="Donation ID" />
                                                <asp:BoundField DataField="organType" HeaderText="Organ Type" />
                                                <asp:BoundField DataField="doctorName" HeaderText="Doctor's Name" />
                                                <asp:BoundField DataField="doctorNumber" HeaderText="Doctor's Phone" />
                                                <asp:BoundField DataField="doctorEmail" HeaderText="Doctor's Email" />
                                                <asp:BoundField DataField="comments" HeaderText="Comments" />
                                                <asp:BoundField DataField="status" HeaderText="Status" />
                                                <asp:BoundField DataField="userID.name" HeaderText="Donor" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#8b0000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="#8b0000" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="White" ForeColor="#222" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />

                                        </asp:GridView>
                                    </td>
                                </tr>


                            </table>
                            <br />

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

