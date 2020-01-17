<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="BPHistorysToU.aspx.cs" Inherits="BPHistorysToU" %>

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
			height: 200px;
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
						<li><a href="BPHistorys.aspx">- To Establishments</a></li>
						<li><a href="BPHistoryFromE.aspx">- From Establishments</a></li>
						<li><a href="BPHistorysToU.aspx">- To Users</a></li>
						<li><a href="BPHistorysFromU.aspx">- From Users</a></li>
						<li><a href="BPHistorysThroughUs.aspx">- Through Us</a></li>
					</ul>
				</div>
				<div class="container">
					<div class="row">
						<br />
						<h4>
							<asp:Label ID="lblHeading" runat="server" Text="Complete Blood/Plateles Transaction To Users"></asp:Label>


						</h4>
						<div class="basic-login">
							<h5>
								<asp:Label ID="lblSorry" runat="server" Text="There are no complete transaction to Users right now" Visible="false">
								</asp:Label>
							</h5>
							<br />
							<asp:Panel ID="Panel1" runat="server" Visible="false">
								<asp:GridView ID="GridView1" runat="server" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
										<Columns>
											<asp:BoundField DataField="ID" HeaderText="ID" />
											<asp:BoundField DataField="Requestor" HeaderText="Requestor" />
											<asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
											<asp:BoundField DataField="BloodOrPlatelet" HeaderText="Donation Type" />
											<asp:BoundField DataField="UnitRequire" HeaderText="Unit Require" />
											<asp:BoundField DataField="Giver" HeaderText="Donor" />
											<asp:BoundField DataField="GivenUnit" HeaderText="Unit Given" />
											<asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Transaction Date" />
											<asp:BoundField DataField="Status" HeaderText="Status" />
										</Columns>
										<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
										<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
										<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
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

