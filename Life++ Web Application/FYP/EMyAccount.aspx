<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="EMyAccount.aspx.cs" Inherits="EMyAccount" %>

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

		td {
			border: 0px solid #ededed;
			border-top: 1px solid rgba(216, 216, 216, 0.0);
			padding: 6px 10px 6px 0;
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
						<h1>My Account</h1>
					</div>
				</div>
			</div>
		</div>

		<div class="col-md-12">
		</div>

		<div class="basic-login">
			<div class="section">
				<div class="container">
					<div class="row">
						<div class="col-md-12">
							<!-- start id-form -->
							<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
								<tr>
									<th>Email:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxAEmail" ReadOnly="true" Width="250" runat="server" TextMode="Email"></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lblEmail" runat="server" Text="Please enter email" Visible="false"></asp:Label>
									</td>
								</tr>
								<tr>
									<th>Name:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxName" Width="250" runat="server" required></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lblName" runat="server" Text="Please enter name" Visible="false"></asp:Label>
									</td>
								</tr>
								<tr>
									<th>Password:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxPassword" ReadOnly="true" Width="250" runat="server" Text="**********"></asp:TextBox>
									</td>
									<td>
										<asp:Button ID="btnPasswordChange" runat="server" Text="Change Password" OnClick="btnPasswordChange_Click" />

									</td>
								</tr>
								<tr>
									<th></th>
									<td class="auto-style1"></td>
									<asp:Label ID="lblPassword" runat="server"  Text="Please enter password" Visible="false"></asp:Label>
									<td></td>
								</tr>

								<tr>
									<th>Phone Number:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxPhone" Width="250" runat="server" required></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lblPhone" runat="server" Text="Please enter phone" Visible="false"></asp:Label>
									</td>
								</tr>

								<tr>
									<th>Address:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxAAddress" Width="250" runat="server" TextMode="MultiLine" required></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lblAddress" runat="server" Text="Please enter address" Visible="false"></asp:Label>
									</td>
								</tr>

								<tr>
									<th>&nbsp;</th>
									<td class="auto-style1">
										<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
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

