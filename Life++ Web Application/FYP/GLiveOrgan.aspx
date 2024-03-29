﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GovernmentMaster.master" AutoEventWireup="true" CodeFile="GLiveOrgan.aspx.cs" Inherits="GLiveOrgan" %>

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
			width: 292px;
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
			padding-left: 320px;
		}

		.navba-fixed-left .navba-nav > li {
			width: 290px;
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
				<h4>Current Live Organ Donation</h4>
				<div class="basic-login">

					<br />
					<asp:Label ID="lblSorry" runat="server" Text="Sorry there are no Live Organ Donation right now." Visible="false"></asp:Label>
					<asp:Panel ID="Panel1" runat="server" Visible="false">
						<asp:GridView ID="gvRequest" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvRequest_PageIndexChanging">
							<Columns>
								<asp:BoundField DataField="ldonorID" HeaderText="Donation ID" />
								<asp:BoundField DataField="userID.name" HeaderText="Donor" />
								<asp:BoundField DataField="organType" HeaderText="Organ Type" />
								<asp:BoundField DataField="doctorName" HeaderText="Doctor's Name" />
								<asp:BoundField DataField="doctorNumber" HeaderText="Doctor's Phone" />
								<asp:BoundField DataField="doctorEmail" HeaderText="Doctor's Email" />
								<asp:BoundField DataField="comments" HeaderText="Comments" />
								<asp:BoundField DataField="status" HeaderText="Status" />
								
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
				<br />
				<br />
				<br />

				<h4>Past Live Organ Donation</h4>
				<div class="basic-login">

					<br />
					<asp:Label ID="lblsorry2" runat="server" Text="Sorry there are no Live Organ Donation history right now." Visible="false"></asp:Label>
					<asp:Panel ID="Panel2" runat="server" Visible="false">
						<asp:GridView ID="gvDHistory" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvDHistory_PageIndexChanging">
							<Columns>
								<asp:BoundField DataField="ldonorID" HeaderText="Donation ID" />
								<asp:BoundField DataField="userID.name" HeaderText="Donor" />
								<asp:BoundField DataField="organType" HeaderText="Organ Type" />
								<asp:BoundField DataField="doctorName" HeaderText="Doctor's Name" />
								<asp:BoundField DataField="doctorNumber" HeaderText="Doctor's Phone" />
								<asp:BoundField DataField="doctorEmail" HeaderText="Doctor's Email" />
								<asp:BoundField DataField="comments" HeaderText="Comments" />
								<asp:BoundField DataField="status" HeaderText="Status" />	
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
	</section>
</asp:Content>

