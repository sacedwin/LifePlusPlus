<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="RecipientWaitingList.aspx.cs" Inherits="RecipientWaitingList" %>

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

		.btn-form, .btn-form:hover, .btn-form:focus {
			background-color: #8b0000;
			color: #fff;
			border-radius: 0px;
			padding: 10px 20px;
		}
	</style>

	<div id="page-wrapper">
		<div class="row">
			<div>
				<h1 class="page-header">Recipient Waiting List&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAddRecipient" class="btn btn-form" runat="server" Text="Add Recipient" OnClick="btnAddOrgan_Click" />
				</h1>
				<div class="form-action">
					<br />
				</div>
			</div>

		</div>
		<div class="row">

			<div class="panel panel-red">
				<div class="panel-body">
					<h3>Recipient Details</h3>
					<p>This lists contains details of <strong>recipients</strong> currently waiting for organs from registered organ donors.</p>
					<p>
						<asp:Label ID="lblOutput" runat="server"></asp:Label>
					</p>
					<div class="table-responsive">
						<asp:Panel ID="pnlRecipients" CssClass="panel-red" runat="server">
							<div class="panel-heading">
								Recipients Currently Waiting
							</div>
							<div class="panel-body">
								<asp:GridView ID="gvRecipients" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvRecipients_PageIndexChanging" OnSelectedIndexChanged="gvRecipients_SelectedIndexChanged">

									<Columns>
										<asp:BoundField DataField="Refnumber" HeaderText="Patient Reference Number" />
										<asp:BoundField DataField="Bloodgroup" HeaderText="Blood Type" ReadOnly="True" />
										<asp:BoundField DataField="Organrequired" HeaderText="Organ" ReadOnly="True" />
										<asp:BoundField DataField="DOB" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date of Birth" ReadOnly="True" />
										<asp:BoundField DataField="Addedon" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date Added" ReadOnly="True" />
										<asp:BoundField DataField="Comments" HeaderText="Comments" ReadOnly="True" />
										<asp:BoundField DataField="Urgency" HeaderText="Urgency" ReadOnly="True" />
										<asp:CommandField SelectText="View Match" ShowSelectButton="True" />
									</Columns>

								</asp:GridView>
							</div>
						</asp:Panel>
						<asp:Panel ID="pnlMatch" CssClass="panel-red" runat="server" Visible="false">
							<div class="panel-heading">
								Matched Potential Donor
							</div>
							<div class="panel-body">

								<table class="nav-justified">
									<tr>
										<td id="t" class="auto-style3" style="font-weight: bolder">Medical Authority:</td>
										<td>
											<asp:Label ID="lblMedical" runat="server"></asp:Label>
										</td>
									</tr>
									<tr>
										<td id="t" class="auto-style3" style="font-weight: bolder">Medical Authority Contact:</td>
										<td>
											<asp:Label ID="lblContact" runat="server"></asp:Label>
										</td>
									</tr>
									<tr>
										<td class="auto-style3" style="font-weight: bolder">Blood Type:</td>
										<td>
											<asp:Label ID="lblBloodType" runat="server"></asp:Label>
										</td>
									</tr>

									<tr>
										<td class="auto-style3" style="font-weight: bolder">Donor Height/Weight:</td>
										<td>
											<asp:Label ID="lblHeightWeight" runat="server"></asp:Label>
										</td>
									</tr>

									<tr>
										<td class="auto-style3" style="font-weight: bolder">Comments:</td>
										<td>
											<asp:Label ID="lblComments" runat="server"></asp:Label>
										</td>
									</tr>

									<tr>
										<td class="auto-style3" style="font-weight: bolder">Match Score:</td>
										<td>
											<asp:Label ID="lblMatchScore" runat="server"></asp:Label>
										</td>
									</tr>
									<tr>
										<td class="auto-style3" style="font-weight: bolder">Comments on match:</td>
										<td>
											<asp:TextBox ID="tbxMatchComments" runat="server"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="auto-style3" style="font-weight: bolder">Distance:</td>
										<td>
											<asp:Label ID="lblDistance" runat="server"></asp:Label>
										</td>
									</tr>
								</table>
								
								<asp:Button ID="btnAccept" CssClass="btn btn-danger" runat="server" Text="Complete" OnClick="btnAccept_Click" />
								&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnDecline" CssClass="btn btn-danger" runat="server" Text="Decline" OnClick="btnDecline_Click" />
								&nbsp;&nbsp;
                                        <asp:Button ID="btnContact" CssClass="btn btn-danger" runat="server" Text="Contact" OnClick="btnContact_Click" /><br />
								<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
							</div>
							
						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>

</asp:Content>

