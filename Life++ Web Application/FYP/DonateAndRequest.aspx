<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DonateAndRequest.aspx.cs" Inherits="DonateAndRequest" %>

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
			position: static;
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
						<h3>Request Blood</h3>
						<div class="basic-login">
							<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">

								<tr>
									<th>Donation Type:*</th>
									<td class="auto-style1">
										<asp:RadioButton ID="RadioBlood" GroupName="RadioGroup" runat="server" Text="&nbsp;Blood" Checked="True" />
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:RadioButton ID="RadioPlateles" GroupName="RadioGroup" runat="server" Text="&nbsp;Plateles" />
									</td>

								</tr>

								<tr>
									<th>Select Blood Type:</th>
									<td class="auto-style1">
										<asp:DropDownList ID="ddlBloodType" class="form-control" Width="130" runat="server">
											<asp:ListItem Value="0">--Select--</asp:ListItem>
											<asp:ListItem Value="A+">A+</asp:ListItem>
											<asp:ListItem Value="O+">O+</asp:ListItem>
											<asp:ListItem Value="B+">B+</asp:ListItem>
											<asp:ListItem Value="AB+">AB+</asp:ListItem>
											<asp:ListItem Value="A-">A-</asp:ListItem>
											<asp:ListItem Value="O-">O-</asp:ListItem>
											<asp:ListItem Value="B-">B-</asp:ListItem>
											<asp:ListItem Value="AB-">AB-</asp:ListItem>
										</asp:DropDownList>
									</td>
									<td></td>
								</tr>

								<tr>
									<th>Amount:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxAmount" class="form-control" placeholder="No. Of Units" Width="130" runat="server"></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lblAmount" runat="server" Text="Please enter the unit you want to request" Visible="False"></asp:Label>
									</td>
								</tr>

								<tr>
									<th>Which establishment you want to collect:</th>
									<td class="auto-style1">
										<asp:DropDownList ID="ddlEstablish" class="form-control" Width="130" runat="server">
										</asp:DropDownList>
									</td>
									<td></td>
								</tr>


								<tr>
									<th>&nbsp;</th>
									<td class="auto-style1">
										<asp:Button ID="btnRequest" runat="server" Text="Request" OnClick="btnRequest_Click" />
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
							<br />
							<asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Bold="true" Text="Your Current Blood Request"></asp:Label>
							<br />
							<asp:Label ID="lblSorry" runat="server" Text="Sorry there are no blood request right now." Visible="true"></asp:Label>
							<asp:Panel ID="Panel1" runat="server" Visible="false">
								<asp:GridView ID="gvUser" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvUser_PageIndexChanging" OnSelectedIndexChanged="gvUser_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="bplUserRequestID" HeaderText="RequestID" />
										<asp:BoundField DataField="Type" HeaderText="Blood Type" />
										<asp:BoundField DataField="bloodOrPlatelet" HeaderText="Request Type" />
										<asp:BoundField DataField="Units" HeaderText="Units" />
										<asp:BoundField DataField="Establishment.name" HeaderText="Establishment" />
										<asp:BoundField DataField="Time" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Request Date" />
										<asp:BoundField DataField="status" HeaderText="Status" />
										<asp:CommandField ShowSelectButton="True" />
									</Columns>
									<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
									<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
									<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
									<SortedAscendingCellStyle BackColor="#F7F7F7" />
									<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
									<SortedDescendingCellStyle BackColor="#E5E5E5" />
									<SortedDescendingHeaderStyle BackColor="#242121" />

								</asp:GridView>

							</asp:Panel>

							<asp:Panel ID="Panel2" runat="server">
								<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
									<tr>
										<th>RequestID:</th>
										<td class="auto-style1">
											<asp:Label ID="lblRID" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Donation Type:*</th>
										<td class="auto-style1">
											<asp:Label ID="lblDT" runat="server" Text=""></asp:Label>
										</td>

									</tr>

									<tr>
										<th>Select Blood Type:</th>
										<td class="auto-style1">
											<asp:Label ID="lblBT" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Amount:</th>
										<td class="auto-style1">
											<asp:Label ID="lblAmountshow" runat="server"></asp:Label>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Establishment you want to collect: &nbsp;&nbsp;</th>
										<td class="auto-style1">
											<asp:Label ID="lblEst" runat="server"></asp:Label>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Request Date:</th>
										<td class="auto-style1">
											<asp:Label ID="lblRD" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>


									<tr>
										<th>&nbsp;</th>
										<td class="auto-style1">
											<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
										</td>
										<td></td>
									</tr>



									<tr>
										<th>&nbsp;</th>
										<td class="auto-style1">
											<asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
										</td>
										<td></td>
									</tr>
								</table>

							</asp:Panel>
							<br /><br /><br /><br />
							<asp:Label ID="lbleuh" runat="server" Font-Size="Medium" Font-Bold="true" Text="Matches from Donors"></asp:Label>
							<br />
							<asp:Label ID="lbleu" runat="server" Text="Sorry there are no matches from donors now." Visible="true"></asp:Label>
							<asp:Panel ID="Panelusertrans" runat="server" Visible="false">
								<asp:GridView ID="GridView1" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="bplUserTrasactionID" HeaderText="bplUserTrasactionID" />
										<asp:BoundField DataField="bpMatchUsrUsr.matchID.name" HeaderText="bpMatchUsrUsr" />
										<asp:BoundField DataField="unitsPossible" HeaderText="Units" />

										<asp:CommandField DeleteText="Cancel" ShowDeleteButton="True" />
										<asp:CommandField HeaderText="Chat With User" SelectText="Chat" ShowSelectButton="True" />
									</Columns>
									<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
									<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
									<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
									<SortedAscendingCellStyle BackColor="#F7F7F7" />
									<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
									<SortedDescendingCellStyle BackColor="#E5E5E5" />
									<SortedDescendingHeaderStyle BackColor="#242121" />

								</asp:GridView>

							</asp:Panel>
							<br />
							<br />
							<br />
							<br />
							<asp:Label ID="lbleeh" runat="server" Font-Size="Medium" Font-Bold="true" Text="Matches from Establishment"></asp:Label>
							<br />
							<asp:Label ID="lblee" runat="server" Text="Sorry there are no matches from establishment now." Visible="true"></asp:Label>
							<asp:Panel ID="Panelesttrans" runat="server" Visible="false">
								<asp:GridView ID="GridView2" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="bplUserToEstabTrasactionID" HeaderText="bplUserTrasactionID" />
										<asp:BoundField DataField="bpMatchUsrEstID.matchID.name" HeaderText="bpMatchUsrUsr" />
										<asp:BoundField DataField="unit" HeaderText="Units" />

										<asp:CommandField DeleteText="Cancel" ShowDeleteButton="True" />
										<asp:CommandField HeaderText="Chat With Establishment" SelectText="Chat" ShowSelectButton="True" />
									</Columns>
									<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
									<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
									<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
									<SortedAscendingCellStyle BackColor="#F7F7F7" />
									<SortedAscendingHeaderStyle BackColor="#4B4B4B" />
									<SortedDescendingCellStyle BackColor="#E5E5E5" />
									<SortedDescendingHeaderStyle BackColor="#242121" />

								</asp:GridView>

							</asp:Panel>







						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
</asp:Content>

