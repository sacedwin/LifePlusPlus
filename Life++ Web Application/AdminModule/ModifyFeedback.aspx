<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModuleMasterPage.master" AutoEventWireup="true" CodeFile="ModifyFeedback.aspx.cs" EnableEventValidation="false" Inherits="ModifyFeedback" %>

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

        .btn:hover {
            text-shadow: 1px 1px rgba(0, 0, 0, 0.2);
            border-color: #000;
            border-color: rgba(0, 0, 0, 0.2);
            background: #8b0000;
            color: #fff;
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

        #sticktop {
            background: #8b0000 none repeat scroll 0 0;
            width: 100%;
            z-index: 999;
            position: relative;
            border-bottom: 5px solid #222;
        }

        .btn {
            border: none;
            border-radius: 0px;
            font-weight: 400;
            text-transform: inherit;
            font-size: 14px;
            background-color: #8b0000;
            color: #fff;
            padding: 8px 18px;
        }

        td {
            border: 0px solid #ededed;
            border-top: 1px solid rgba(216, 216, 216, 0.0);
            padding: 6px 10px 6px 0;
            height: 40px;
        }

        td, th {
            padding: 0;
        }
    </style>
    <div class="offsetWrap">

        <div class="offsetMaker">
            <section id="cta-1" class="section-padding">
                <div class="section section-breadcrumbs">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <h1>View/Modify Feedback</h1>
                            </div>
                        </div>
                    </div>
                </div>




                <div class="container">
                    <div class="row">
                        <div class="space"></div>
                        <div class="col-sm-6 col-sm-offset-3">
                            <div class="basic-login">
                                <form>
                                    <div class="form-group">
                                        <label for="restore-email">
                                            <asp:Label ID="Label1" runat="server" Text="Please choose to see answer or unanswered Feedback/Enquiry"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlFBChoose" class="btn pull-left" AutoPostBack="true" ForeColor="White" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                            <asp:ListItem Value="all">All</asp:ListItem>
                                            <asp:ListItem Value="answered">Answered</asp:ListItem>
                                            <asp:ListItem Value="unanswered">Unanswered</asp:ListItem>
                                            <asp:ListItem Value="reported">Reported</asp:ListItem>
                                        </asp:DropDownList>
                                        <div class="clearfix"></div>
                                        <asp:Label ID="lblSelectError" ForeColor="Red" Font-Size="Medium" runat="server" Text=""></asp:Label>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>

                <br />


                <div class="section">
                    <div class="container">
                        <div class="row">
                            <div class="space"></div>
                            <div class="col-md-12">


                                <asp:Panel ID="PanelFBAll" runat="server">
                                    <table border="0" cellpadding="0" cellspacing="0" id="id-form">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvFB" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvFB_PageIndexChanging" OnSelectedIndexChanged="gvFB_SelectedIndexChanged" >
                                                    <Columns>
                                                        <asp:BoundField DataField="feedbackID" HeaderText="FeedbackID" />
                                                        <asp:BoundField DataField="name" HeaderText="Name" />
                                                        <asp:BoundField DataField="email" HeaderText="Email" />
                                                        <asp:BoundField DataField="subject" HeaderText="Subject" />
                                                        <asp:BoundField DataField="question" HeaderText="Question" />
                                                        <asp:BoundField DataField="answer" HeaderText="Answer" />
                                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                                        <asp:CommandField HeaderText="Update/Delete" ShowSelectButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                    <SortedDescendingHeaderStyle BackColor="#242121" />

                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>



                            </div>
                        </div>
                    </div>
                </div>
                <br />


                <div class="section">
                    <div class="container">
                        <div class="row">
                            <div class="space"></div>
                            <div class="col-md-12">


                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                    <table border="0" cellpadding="0" cellspacing="0" id="id-form">


                                        <tr>
                                            <th>FeedbackID:</th>
                                            <td>
                                                <asp:TextBox ID="tbxfeedbackID" class="form-control" Width="200" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <th>Name:</th>
                                            <td>
                                                <asp:TextBox ID="tbxName" class="form-control" Width="200" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <th>Email:</th>
                                            <td>
                                                <asp:TextBox ID="tbxEmail" class="form-control" Width="200" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <th>Subject:</th>
                                            <td>
                                                <asp:TextBox ID="tbxsubject" class="form-control" Width="200" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                        </tr>

                                        <tr>
                                            <th>Question:</th>
                                            <td>
                                                <asp:TextBox ID="tbxQuestion" class="form-control" Width="250" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <th>Answer:</th>
                                            <td>
                                                <asp:TextBox ID="tbxAnswer" class="form-control" Width="250" runat="server" ></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <th>Status:</th>
                                            <td>
                                                <asp:DropDownList ID="ddlStatus" class="form-control" Width="130" runat="server" >
                                                    <asp:ListItem Value="unanswered">Unanswered</asp:ListItem>
                                                    <asp:ListItem Value="answered">Answered</asp:ListItem>
                                                    <asp:ListItem Value="reported">Report</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td></td>
                                        </tr>


                                        <tr>
                                            <th>&nbsp;</th>
                                            <td>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                            </td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <th>&nbsp;</th>
                                            <td>
                                                <asp:Label ID="lblOutput" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </asp:Panel>



                            </div>
                        </div>
                    </div>
                </div>
                <br />



            </section>
        </div>
    </div>
</asp:Content>

