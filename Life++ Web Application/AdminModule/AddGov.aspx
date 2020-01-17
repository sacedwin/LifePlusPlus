<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModuleMasterPage.master" AutoEventWireup="true" CodeFile="AddGov.aspx.cs" Inherits="AddGov" %>

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
								<h1>Add Government</h1>
							</div>
						</div>
					</div>
				</div>

				<div class="section">
					<div class="container">
						<div class="row">
							<div class="space"></div>
							<div class="col-md-12">
								<table border="0" cellpadding="0" cellspacing="0" id="id-form">
									<tr>
										<th>Email:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxAEmail" Width="250" runat="server" TextMode="Email"></asp:TextBox>
										</td>
										<td>
											<asp:Label ID="lblEmail" runat="server" Text="Please enter email" Visible="false"></asp:Label>
										</td>
									</tr>
									<tr>
										<th>Name:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxName" Width="250" runat="server"></asp:TextBox>
										</td>
										<td>
											<asp:Label ID="lblName" runat="server" Text="Please enter name" Visible="false"></asp:Label>
										</td>
									</tr>
									<tr>
										<th>Password:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxPassword" Width="250" runat="server" TextMode="Password"></asp:TextBox>
										</td>
										<td>
											<asp:Label ID="lblPassword" runat="server" Text="Please enter password" Visible="false"></asp:Label>
										</td>
									</tr>

									<tr>
										<th>Phone Number:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxPhone" Width="250" runat="server"></asp:TextBox>
										</td>
										<td>
											<asp:Label ID="lblPhone" runat="server" Text="Please enter phone" Visible="false"></asp:Label>
										</td>
									</tr>

									<tr>
										<th>Address:</th>
										<td class="auto-style1">
											<asp:TextBox ID="tbxAAddress" Width="250" runat="server"  TextMode="MultiLine"></asp:TextBox>
										</td>
										<td>
											<asp:Label ID="lblAddress" runat="server" Text="Please enter address" Visible="false"></asp:Label>
										</td>
									</tr>

									<tr>
										<th>&nbsp;</th>
										<td class="auto-style1">
											<asp:Button ID="btnSubmit" runat="server" Text="Enter" OnClick="btnSubmit_Click" />
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
							</div>
						</div>
					</div>
				</div>
				<br />



			</section>
		</div>
	</div>



</asp:Content>

