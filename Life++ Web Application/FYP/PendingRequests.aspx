<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="PendingRequests.aspx.cs" Inherits="PendingRequests" %>

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
		.auto-style1 {
			width: 99px;
		}
	</style>

	<div id="page-wrapper">
		<div class="row">
			<div>
				<h1 class="page-header">Our pending requests
				</h1>
				<asp:Label ID="lblOutput" runat="server"></asp:Label>
				<div class="form-action">
					<br />
				</div>
			</div>

		</div>
		<div class="row">
			<div class="">
				<div class="panel panel-red">

					<div class="panel-body">
						<div class="center-block">
							<asp:Panel ID="panelRequests" CssClass="panel-red" runat="server">
								<div class="panel-body">
									<asp:GridView ID="gvRequests" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvRequests_PageIndexChanging" OnSelectedIndexChanged="gvRequests_SelectedIndexChanged" OnRowDeleting="gvRequests_RowDeleting">
										<Columns>
											<asp:BoundField DataField="ID" HeaderText="RequestID" />
											<asp:BoundField DataField="BloodGroup" HeaderText="Blood Type" ReadOnly="True" />
											<asp:BoundField DataField="Type" HeaderText="Request Type" ReadOnly="True" />
											<asp:BoundField DataField="Units" HeaderText="Total Units" ReadOnly="True" />
											<asp:BoundField DataField="MatchedUnits" HeaderText="Matched Units" ReadOnly="True" />
											<asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
											<asp:BoundField DataField="RequestDate" HeaderText="Request Date" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" />
											<asp:CommandField ShowSelectButton="True" />
											<asp:CommandField ShowDeleteButton="True" DeleteText="Cancel" />
											<asp:TemplateField>
												<ItemTemplate>
													<asp:LinkButton ID="lbtnContact" runat="server" OnClick="lbtnContact_Click1">Contact</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
									</asp:GridView>
								</div>
							</asp:Panel>


							<asp:Panel ID="panelMatches" runat="server" Visible="false">

								<br />
								<br />
								<asp:Panel ID="pnlEstabMatches" CssClass="panel-red" runat="server">
									<div class="panel-heading">
										Matches From Establishments
									</div>
									<div class="panel-body">
										<asp:GridView ID="gvEstabMatches" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvEstabMatches_RowDeleting" OnSelectedIndexChanged="gvEstabMatches_SelectedIndexChanged">
											<Columns>
												<asp:BoundField DataField="Match.Match.Name" HeaderText="Establishment" ReadOnly="True" />
												<asp:BoundField DataField="Units" HeaderText="Units" ReadOnly="True" />
												<asp:BoundField DataField="Match.Distance" HeaderText="Travel Time" ReadOnly="True" />
												<asp:CommandField SelectText="Complete" ShowSelectButton="True" />
												<asp:CommandField DeleteText="Cancel" ShowDeleteButton="True" />
											</Columns>
										</asp:GridView>
									</div>
								</asp:Panel>
								<asp:Panel ID="pnlUserMatches" runat="server" CssClass="panel-red">
									<div class="panel-heading">
										Matches From Donors
									</div>
									<div class="panel-body">
										<asp:GridView ID="gvUserMatches" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvUserMatches_RowDeleting" OnSelectedIndexChanged="gvUserMatches_SelectedIndexChanged">
											<Columns>
												<asp:BoundField DataField="Match.Match.Name" HeaderText="Donor" ReadOnly="True" />
												<asp:BoundField DataField="Units" HeaderText="Units" ReadOnly="True" />
												<asp:BoundField DataField="Match.Distance" HeaderText="Travel Time" ReadOnly="True" />
												<asp:CommandField SelectText="Complete" ShowSelectButton="True" />
												<asp:CommandField DeleteText="Cancel" ShowDeleteButton="True" />
												<asp:TemplateField>

													<ItemTemplate>
														<table class="nav-justified">
															<tr>
																<td class="auto-style1">
																	<asp:LinkButton ID="lbtnReport" runat="server" OnClick="lbtnReport_Click">Unfit to Donate</asp:LinkButton>
																</td>
																<td>
																	<asp:LinkButton ID="lbtnContact" runat="server" OnClick="lbtnContact_Click">Contact</asp:LinkButton>
																</td>
															</tr>
														</table>
													</ItemTemplate>

												</asp:TemplateField>
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
	</div>
</asp:Content>

