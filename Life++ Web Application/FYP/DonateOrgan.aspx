<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DonateOrgan.aspx.cs" Inherits="DonateOrgan" %>

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
						<br />
						<h4>
							<asp:Label ID="lblHeading" runat="server" Text="Please update this datails to register as organ donor."></asp:Label>


						</h4>
						<div class="basic-login">
							<h5>
								<asp:Label ID="Label1" runat="server" Text="Well Done! You are already part of live organ donation. You doesn't need sign up again.">
								</asp:Label>
							</h5>
							<br />
							<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
								<asp:Panel ID="PanelUpdate" runat="server" Visible="false">
									<asp:Panel ID="PanelHeight" runat="server" Visible="False">
										<tr>
											<th>Height:</th>
											<td class="auto-style1">
												<asp:TextBox ID="tbxHeight" class="form-control" placeholder="height in cm" Width="200" runat="server"></asp:TextBox>
											</td>
											<td>
												<asp:Label ID="lblHeight" runat="server" Text=""></asp:Label>
											</td>
										</tr>
									</asp:Panel>

									<asp:Panel ID="PanelWeight" runat="server" Visible="False">
										<tr>
											<th>Weight:</th>
											<td class="auto-style1">
												<asp:TextBox ID="tbxWeight" class="form-control" placeholder="weight in kg" Width="200" runat="server"></asp:TextBox>
											</td>
											<td>
												<asp:Label ID="lblWeight" runat="server" Text=""></asp:Label>
											</td>
										</tr>
									</asp:Panel>

									<asp:Panel ID="PanelEmergency" runat="server" Visible="False">
										<tr>
											<th>Emergency Contact Person Name:</th>
											<td class="auto-style1">
												<asp:TextBox ID="tbxEName" class="form-control" Width="200" runat="server" required></asp:TextBox>
											</td>
											<td></td>
										</tr>

										<tr>
											<th>Emergency Phone Number:</th>
											<td class="auto-style1">
												<asp:TextBox ID="tbxEPhone" class="form-control" Width="180" runat="server" required></asp:TextBox>
											</td>
											<td></td>
										</tr>

										<tr>
											<th>Relationship:</th>
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
												<asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
											</td>
										</tr>
									</asp:Panel>

									<tr>
										<th>&nbsp;</th>
										<td class="auto-style1">
											<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSubmit_Click" />
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
								</asp:Panel>
								
								<asp:Panel ID="PanelRegisterDonor" runat="server" Visible="false">
									<tr>
										<th>What organ you want to donate?</th>
										<td class="auto-style1">
											<asp:DropDownList ID="ddlOrgan" class="form-control" Width="130" runat="server">
												<asp:ListItem Value="0">--Select--</asp:ListItem>
												<asp:ListItem Value="Kidney">Kidney</asp:ListItem>
												<asp:ListItem Value="Liver">Liver</asp:ListItem>
											</asp:DropDownList>
										</td>
										<td>
											<asp:Label ID="lblOrgan" runat="server" Visible="false" Text="Please enter the organ you want to donate."></asp:Label>
										</td>
									</tr>

									<tr>
										<th></th>
										<td class="auto-style1">
											<br />
											<h4>Please fill your doctor form</h4>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Doctor's Name:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxDoctor" runat="server" placeholder="eg. (John)" Height="40" Width="200" required></asp:TextBox>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Doctor's Email:</th>
										<td class="auto-style1">
											<asp:TextBox ID="TbxDEmail" runat="server" placeholder="doctor@domail.com" Height="40" Width="200" required></asp:TextBox>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Doctor's Phone Number:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxDPhone" runat="server" placeholder="0000 0000" Height="40" Width="200" required MaxLength="8"></asp:TextBox>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>Doctor's Address:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxDAddress" runat="server" placeholder="Doctor's Address" Height="40" Width="200" required></asp:TextBox>
										</td>
										<td></td>
									</tr>
									<tr>
										<th>Any Comments?:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxComment" runat="server" placeholder="Please write here if you want to say more about this." TextMode="MultiLine" Width="200" Height="100"></asp:TextBox>
										</td>
										<td></td>
									</tr>

									<tr>
										<th>&nbsp;</th>
										<td class="auto-style1">
											<asp:Button ID="btnDSubmit" runat="server" Text="Submit" OnClick="btnDSubmit_Click" />
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
						<br />
						<br />
						<br />
						<br />
						<br />
						
					</div>
					<br />
						<br />
						<br />
						<br />
						<br />
						<br />
						<br />
				</div>
			</div>
		</div>
	</section>
</asp:Content>

