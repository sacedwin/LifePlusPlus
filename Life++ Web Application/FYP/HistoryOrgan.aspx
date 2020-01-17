<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistoryOrgan.aspx.cs" Inherits="HistoryOrgan" %>

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
							<asp:Label ID="lblHeading" runat="server" Text="Current Donation"></asp:Label>

						</h4>
						<div class="basic-login">
							<h5>
								<asp:Label ID="Label1" runat="server" Text="Congratulations! You are one of the members of Live Organ donations. Below is your current donation.">
								</asp:Label></h5>
							<br />
							<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
								<asp:Panel ID="PanelFinishRegister" runat="server" Visible="false">

									<tr>
										<th>Organs:</th>
										<td class="auto-style1">
											<asp:Label ID="lblOrgan" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Doctor's Name:</th>
										<td class="auto-style1">
											<asp:Label ID="lblDoctor" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Doctor's Email:</th>
										<td class="auto-style1">
											<asp:Label ID="lblDEmail" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Doctor's Phone Number: &nbsp;&nbsp;&nbsp;</th>
										<td class="auto-style1">
											<asp:Label ID="lblDPhone" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Doctor's Address:</th>
										<td class="auto-style1">
											<asp:Label ID="lblDAddress" runat="server" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Comments:</th>
										<td class="auto-style1">
											<asp:Label ID="lblComment" runat="server" Style="word-wrap: normal; word-break: break-all;" Text=""></asp:Label>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Status:</th>
										<td class="auto-style1">
											<asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label>
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
											<asp:Label ID="lblDOutput" runat="server" ForeColor="Red"></asp:Label>
										</td>
										<td></td>
									</tr>
								</asp:Panel>
							</table>
						</div>

						<br />
						<br />
						<br />

						<h4>
							<asp:Label ID="Label2" runat="server" Text="Your Organ Matching"></asp:Label>

						</h4>
						<div class="basic-login">
							<h5>
								<asp:Label ID="lblmatchingF" runat="server" Text="">
								</asp:Label></h5>
							<br />
							
								<asp:Panel ID="panelmatching" runat="server" Visible="false">
									<asp:GridView ID="gvMatch" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="5" OnSelectedIndexChanged="gvMatch_SelectedIndexChanged" >
									<Columns>
										<asp:BoundField DataField="ID" HeaderText="ID" />
										<asp:BoundField DataField="LiveDonor.userid.name" HeaderText="Donor's name" />
										<asp:BoundField DataField="Recipient.Establishment.name" HeaderText="Recipient" />
										<asp:BoundField DataField="MatchScore" HeaderText="Match Score" />
										<asp:BoundField DataField="Comments" HeaderText="Comments" />
										<asp:BoundField DataField="Status"  HeaderText="Status" />
										<asp:BoundField DataField="Distance" HeaderText="Travel Time(mins)" />
										<asp:CommandField SelectText="Chat" ShowSelectButton="True" />
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
						<br /><br /><br /><br />
					</div>
					<br />
						<br />
						<br />
						
				</div>
			</div>
		</div>
	</section>
</asp:Content>

