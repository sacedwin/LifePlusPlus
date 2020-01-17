<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="AddOrganRecipient.aspx.cs" Inherits="AddOrganRecipient" %>

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

	<section id="cta-1" class="section-padding">
		<div class="section section-breadcrumbs">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<h1>Add Organ Recipient</h1>
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
									<th>Blood Type:*</th>
									<td class="auto-style1">
										<asp:DropDownList ID="ddlBloodType" class="form-control" Width="130" runat="server" required="true">
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
								</tr>
								<tr>
									<th>Date of Birth:*</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxDate" runat="server" TextMode="Date"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<th>Height:*</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxHeight" runat="server" placeholder="height" required="true" class="form-control input-md" TextMode="Number"></asp:TextBox>

									</td>
								</tr>
								<tr>
									<th>Weight:*</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxWeight" runat="server" placeholder="weight" required="true" class="form-control input-md" TextMode="Number"></asp:TextBox>

									</td>
								</tr>
								<tr>
									<th>Organ Required:*</th>
									<td class="auto-style1">
										<asp:RadioButtonList ID="rbtnlstOrganType" runat="server">
											<asp:ListItem>Liver</asp:ListItem>
											<asp:ListItem>Kidney</asp:ListItem>

										</asp:RadioButtonList>
									</td>

								</tr>
								<tr>
									<th>Comments:</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxComments" runat="server" placeholder="comments" required="true" class="form-control input-md" TextMode="MultiLine"></asp:TextBox>

									</td>
								</tr>
								<tr>
									<th>Urgency:*</th>
									<td class="auto-style1">
										<asp:DropDownList ID="ddlUrgency" runat="server">
											<asp:ListItem>1</asp:ListItem>
											<asp:ListItem>2</asp:ListItem>
											<asp:ListItem>3</asp:ListItem>
											<asp:ListItem>4</asp:ListItem>
											<asp:ListItem>5</asp:ListItem>
										</asp:DropDownList>
									</td>
								</tr>
								<tr>
									<th>Reference Number:*</th>
									<td class="auto-style1">
										<asp:TextBox ID="tbxReference" runat="server" placeholder="reference number" required="true" class="form-control input-md"></asp:TextBox>

									</td>
								</tr>
								<tr>
									<th>&nbsp;</th>
									<td class="auto-style1">
										<asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-danger" OnClick="btnSubmit_Click" />
										<asp:Label ID="lblOutput" runat="server"></asp:Label>
									</td>
									<td></td>
								</tr>
							</table>
						</div>
					</div>
				</div>
			</div>
		</div>


	</section>
</asp:Content>

