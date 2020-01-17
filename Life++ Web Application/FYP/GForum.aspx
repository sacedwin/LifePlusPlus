<%@ Page Title="" Language="C#" MasterPageFile="~/GovernmentMaster.master" AutoEventWireup="true" CodeFile="GForum.aspx.cs" EnableEventValidation="false" Inherits="GForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
								<br /><br />
                                <h1>View Forum</h1>
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
                                            <asp:Label ID="Label1" runat="server" Text="Please choose to see Forum posted by User or Establishment"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlFBChoose" class="btn pull-left" AutoPostBack="true" ForeColor="White" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                            <asp:ListItem Value="userforum">User's Forum</asp:ListItem>
                                            <asp:ListItem Value="estforum">Establishmen's Forum</asp:ListItem>
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


                                <asp:Panel ID="panelUser" runat="server" Visible="false">
                                    <h5>Forum posted by Users</h5>
                                    <asp:GridView ID="gvUser" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvUser_PageIndexChanging" OnSelectedIndexChanged="gvUser_SelectedIndexChanged1" >
                                        <Columns>
                                            <asp:BoundField DataField="forumID" HeaderText="forumID">
                                                <HeaderStyle Width="10%" Wrap="False" />
                                                <ItemStyle Width="10%" Wrap="False" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Title">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# Eval("title") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="40%" />
                                                <ItemStyle Width="40%" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="UserID.username" HeaderText="Posted By">
                                                <HeaderStyle Width="15%" Wrap="False" />
                                                <ItemStyle Width="15%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Posted On">
                                                <HeaderStyle Width="15%" Wrap="False" />
                                                <ItemStyle Width="15%" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>

                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#8b0000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                                    </asp:GridView>
                                </asp:Panel>
                                <br />
                                <asp:Label ID="lblGVOutput" runat="server" Text=""></asp:Label>
                                <br />
                                <br />

                                <asp:Panel ID="panelEst" runat="server" Visible="false">
                                    <h5>Forum posted by Establishment</h5>
                                    <asp:GridView ID="gvEst" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvEst_PageIndexChanging" OnSelectedIndexChanged="gvEst_SelectedIndexChanged1" >
                                        <Columns>
                                            <asp:BoundField DataField="forumID" HeaderText="forumID">
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Title">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# Eval("title") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="40%" />
                                                <ItemStyle Width="40%" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="estID.name" HeaderText="Posted By">
                                                <HeaderStyle Width="15%" />
                                                <ItemStyle Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Posted On">
                                                <HeaderStyle Width="15%" />
                                                <ItemStyle Width="15%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                        </Columns>

                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#8b0000" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                                    </asp:GridView>
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
                                    <table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
                                        <tr>
                                            <th>Comment ID:</th>
                                            <td class="auto-style1">
                                                <asp:Label ID="lblID" runat="server" Font-Size="Medium" Text=""></asp:Label>
                                            </td>

                                        </tr>
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
                                    <br /><br />
                                    <asp:GridView ID="GridView1" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" Width="100%" runat="server" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="comentID" HeaderText="Forum CommentID">
                                                <ControlStyle Width="10%" />
                                                <FooterStyle Width="10%" />
                                                <HeaderStyle Width="10%" />
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comment" HeaderText="Comments">


                                                <ControlStyle Width="40%" />
                                                <FooterStyle Width="40%" />
                                                <HeaderStyle Width="40%" />
                                                <ItemStyle Width="40%" />


                                            </asp:BoundField>
                                            <asp:BoundField DataField="commentby" HeaderText="By">


                                                <ControlStyle Width="10%" />
                                                <FooterStyle Width="10%" Wrap="False" />
                                                <HeaderStyle Width="10%" Wrap="False" />
                                                <ItemStyle Width="10%" Wrap="False" />


                                            </asp:BoundField>
                                            <asp:BoundField DataField="timeshow" HeaderText="Time">


                                                <ControlStyle Width="10%" />
                                                <FooterStyle Width="10%" Wrap="False" />
                                                <HeaderStyle Width="10%" Wrap="False" />
                                                <ItemStyle Width="10%" Wrap="False" />


                                            </asp:BoundField>
                                            <asp:BoundField DataField="status" HeaderText="Status">


                                                <ControlStyle Width="10%" />
                                                <FooterStyle Width="10%" Wrap="False" />
                                                <HeaderStyle Width="10%" Wrap="False" />
                                                <ItemStyle Width="10%" Wrap="False" />


                                            </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" />
                                        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <asp:Label ID="lblNotFound" runat="server" Text="Sorry there is no comment right now!" Visible="false"></asp:Label><br />
                                </asp:Panel>



                            </div>
                        </div>
                    </div>
                </div>
                <br /> <br /> <br />



            </section>
        </div>
    </div>
</asp:Content>

