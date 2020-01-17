<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="UserDonations.aspx.cs" Inherits="UserDonations" %>

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
				<h1 class="page-header">User donation requests
				</h1>
				<div class="form-action">
					<br />
				</div>
			</div>

		</div>
		<div class="row">
			<div class="">
				<div class="panel panel-red">

					<div class="panel-body">
						<p>This page lists requests that list our establishment as their place of donation.</p>
						<p>
							<asp:Label ID="lblOutput" Font-Bold="true" runat="server"></asp:Label>
						</p>
						<asp:Panel ID="pnlRequestInfo" CssClass="panel-red" runat="server" Visible="false">
							<div class="panel-heading">
								Requests From Users
							</div>
							<div class="panel-body">
								<asp:GridView ID="gvRequestInfo" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvRequestInfo_PageIndexChanging" OnSelectedIndexChanged="gvRequestInfo_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="bplUserRequestID" HeaderText="Request ID" ReadOnly="True" />
										<asp:BoundField DataField="requestorID.name" HeaderText="Requesting User" ReadOnly="True" />
										<asp:BoundField DataField="Units" HeaderText="Total Units" ReadOnly="True" />
										<asp:BoundField DataField="unitMatched" HeaderText="Units Matched" ReadOnly="True" />
										<asp:BoundField DataField="Type" HeaderText="Blood Type" ReadOnly="True" />
										<asp:BoundField DataField="bloodOrPlatelet" HeaderText="RequestType" ReadOnly="True" />
										<asp:BoundField DataField="Time" HeaderText="Request Date" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" />
										<asp:CommandField SelectText="View Matches" ShowSelectButton="True" />
									</Columns>
								</asp:GridView>
							</div>
						</asp:Panel>
						<asp:Panel ID="panelMatches" runat="server" Visible="false">
							<br />
							<br />
							<asp:Panel ID="pnlAcceptedUserRequests" CssClass="panel-red" runat="server">
								<div class="panel-heading">
									Accepted User Matches 
								</div>
								<div class="panel-body">
									<asp:GridView ID="gvAcceptedUserRequests" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAcceptedUserRequests_SelectedIndexChanged" OnPageIndexChanging="gvAcceptedUserRequests_PageIndexChanging">
										<Columns>
											<asp:BoundField DataField="bpMatchUsrUsr.matchID.name" HeaderText="Accepting User" ReadOnly="True" />
											<asp:BoundField DataField="unitsPossible" HeaderText="Units" ReadOnly="True" />
											<asp:BoundField DataField="bpMatchUsrUsr.distance" HeaderText="Travel Time" ReadOnly="True" />
											<asp:CommandField SelectText="Complete" ShowSelectButton="True" />
											<asp:TemplateField>
												<ItemTemplate>
													<asp:LinkButton ID="lbtnReport" runat="server" OnClick="lbtnReport_Click">Unfit to Donate</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</asp:Panel>
							<asp:Panel ID="pnlAcceptedEstabRequests" CssClass="panel-red" runat="server">
								<div class="panel-heading">
									Accepted Estab Matches 
								</div>
								<div class="panel-body">
									<asp:GridView ID="gvAcceptedEstabRequests" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAcceptedEstabRequests_SelectedIndexChanged" OnPageIndexChanging="gvAcceptedEstabRequests_PageIndexChanging">
										<Columns>
											<asp:BoundField DataField="bpMatchUsrEstID.matchID.Name" HeaderText="Accepting Establishment" ReadOnly="True" />
											<asp:BoundField DataField="unit" HeaderText="Units" ReadOnly="True" />
											<asp:BoundField DataField="bpMatchUsrEstID.distance" HeaderText="Travel Time" ReadOnly="True" />
											<asp:CommandField SelectText="Complete" ShowSelectButton="True" />
										</Columns>
									</asp:GridView>
								</div>
							</asp:Panel>
						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

