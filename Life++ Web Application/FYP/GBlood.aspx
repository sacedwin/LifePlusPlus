﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GovernmentMaster.master" AutoEventWireup="true" CodeFile="GBlood.aspx.cs" Inherits="GBlood" %>

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

				<div class="navba navba-inverse navba-fixed-left">

					<ul class="nav navba-nav">
						<li><a href="GBlood.aspx">- Blood/Plateles Request (User) </a></li>
						<li><a href="GBloodE.aspx">- Blood/Plateles Request (Establishment)</a></li>

					</ul>
				</div>
				<div class="container">
					<div class="row">
						<h4>Current Request Blood/Plateles By User</h4>
						<div class="basic-login">

							<br />
							<asp:Label ID="lblSorry" runat="server" Text="Sorry there are no blood request right now." Visible="true"></asp:Label>
							<asp:Panel ID="Panel1" runat="server" Visible="false">
								<asp:GridView ID="gvRequest" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="20" OnPageIndexChanging="gvRequest_PageIndexChanging" >
									<Columns>
										<asp:BoundField DataField="bplUserRequestID" HeaderText="RequestID" />
										<asp:BoundField DataField="Type" HeaderText="Blood Type" />
										<asp:BoundField DataField="bloodOrPlatelet" HeaderText="Request Type" />
										<asp:BoundField DataField="Units" HeaderText="Units Require" />
										<asp:BoundField DataField="unitMatched" HeaderText="Units Match" />
										<asp:BoundField DataField="Establishment.name" HeaderText="Establishment" />
										<asp:BoundField DataField="Time" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Request Date" />
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
						<br /><br /><br />
						<h4>Complete & Cancelled/Expired Blood/Plateles Request By User</h4>
						<div class="basic-login">

							<br />
							<asp:Label ID="lblsorry2" runat="server" Text="Sorry there are no expired or cancelled blood request right now." Visible="true"></asp:Label>
							<asp:Panel ID="Panel2" runat="server" Visible="false">
								<asp:GridView ID="GridView1" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
									<Columns>
										<asp:BoundField DataField="bplUserRequestID" HeaderText="RequestID" />
										<asp:BoundField DataField="Type" HeaderText="Blood Type" />
										<asp:BoundField DataField="bloodOrPlatelet" HeaderText="Request Type" />
										<asp:BoundField DataField="Units" HeaderText="Units Require" />
										<asp:BoundField DataField="unitMatched" HeaderText="Units Match" />
										<asp:BoundField DataField="Establishment.name" HeaderText="Establishment" />
										<asp:BoundField DataField="Time" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Request Date" />
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
			</div>
		</div>
	</section>
</asp:Content>

