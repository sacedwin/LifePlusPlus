<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="IncomingRequests.aspx.cs" Inherits="IncomingRequests" %>

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
				<h1 class="page-header">Incoming requests
				</h1>
				<asp:Label ID="lblOutput" Text="" runat="server"></asp:Label>

				<div class="form-action">
					<br />
				</div>
			</div>

		</div>
		<div class="row">
			<div class="">
				<div class="panel panel-red">

					<div class="panel-body">

						<asp:Panel ID="pnlEstabRequests" CssClass="panel-red" runat="server">
							<div class="panel-heading">
								Requests From Establishments
							</div>
							<div class="panel-body">
								<asp:GridView ID="gvEstabRequests" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvEstabRequests_PageIndexChanging" OnRowDeleting="gvEstabRequests_RowDeleting" OnSelectedIndexChanged="gvEstabRequests_SelectedIndexChanged">
									<Columns>
										<asp:BoundField DataField="Request.ID" HeaderText="Request ID" />
										<asp:BoundField DataField="Request.Establishment.Name" HeaderText="Requesting Establishment" ReadOnly="True" />
										<asp:BoundField DataField="Request.BloodGroup" HeaderText="Blood Type" ReadOnly="True" />
										<asp:BoundField DataField="Request.Units" HeaderText="Units Required" ReadOnly="True" />
										<asp:BoundField DataField="Request.MatchedUnits" HeaderText="Units Matched" ReadOnly="True" />
										<asp:BoundField DataField="Request.Type" HeaderText="Request Type" ReadOnly="True" />
										<asp:BoundField DataField="Distance" HeaderText="Travel Time" ReadOnly="True" />
										<asp:CommandField SelectText="Accept" ShowSelectButton="True" />
										<asp:CommandField DeleteText="Decline" ShowDeleteButton="True" />
										<asp:TemplateField>
											<ItemTemplate>
												<asp:LinkButton ID="lbtnContact" runat="server" OnClick="lbtnContact_Click">Contact</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</asp:Panel>
						<asp:Panel ID="pnlUserRequests" CssClass="panel-red" runat="server">
							<div class="panel-heading">
								Requests From Users
							</div>
							<div class="panel-body">
								<asp:GridView ID="gvUserRequests" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" OnPageIndexChanging="gvUserRequests_PageIndexChanging" OnRowDeleting="gvUserRequests_RowDeleting" OnSelectedIndexChanged="gvUserRequests_SelectedIndexChanged" AutoGenerateColumns="False">
									<Columns>
										<asp:BoundField DataField="bpRequestID.bplUserRequestID" HeaderText="Request ID" />
										<asp:BoundField DataField="bpRequestID.requestorID.name" HeaderText="Requesting User" ReadOnly="True" />
										<asp:BoundField DataField="bpRequestID.Establishment.Name" HeaderText="Place of Donation" ReadOnly="True" />
										<asp:BoundField DataField="bpRequestID.Type" HeaderText="Blood Type" ReadOnly="True" />
										<asp:BoundField DataField="bpRequestID.Units" HeaderText="Units Required" ReadOnly="True" />
										<asp:BoundField DataField="bpRequestID.unitMatched" HeaderText="Units Matched" ReadOnly="True" />
										<asp:BoundField DataField="bpRequestID.bloodOrPlatelet" HeaderText="Request Type" ReadOnly="True" />
										<asp:BoundField DataField="distance" HeaderText="Travel Time" ReadOnly="True" />
										<asp:CommandField SelectText="Accept" ShowSelectButton="True" />
										<asp:CommandField DeleteText="Decline" ShowDeleteButton="True" />
										<asp:TemplateField>
											<ItemTemplate>
												<asp:LinkButton ID="lbtnContact1" runat="server" OnClick="lbtnContact1_Click">Contact</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</div>
						</asp:Panel>
						<asp:Panel ID="pnlAcceptEstab" runat="server" CssClass="panel-red" Visible="false">
							Enter number of units you want to donate:
                            <asp:TextBox ID="tbxEstabUnits" runat="server" TextMode="Number">
							</asp:TextBox>
							<asp:Label ID="lblEstabOutput" runat="server"></asp:Label>
							<br />
							<asp:Button ID="btnEstabSubmit" runat="server" Text="Submit" CssClass="btn btn-danger" OnClick="btnEstabSubmit_Click" />
						</asp:Panel>
						<asp:Panel ID="pnlAcceptUser" runat="server" CssClass="panel-red" Visible="false">
							Enter number of units you want to donate:
                            <asp:TextBox ID="tbxUserUnits" runat="server"></asp:TextBox>
							<asp:Label ID="lblUserOutput" runat="server"></asp:Label>
							<br />
							<asp:Button ID="btnUserSubmit" runat="server" Text="Submit" CssClass="btn btn-danger" OnClick="btnUserSubmit_Click" />
						</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

