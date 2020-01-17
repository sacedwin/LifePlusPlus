<%@ Page Title="" Language="C#" MasterPageFile="~/GovernmentMaster.master" AutoEventWireup="true" CodeFile="GReport.aspx.cs" Inherits="GReport" %>

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

		#footer {
			background-color: #8B0000;
			bottom: 0;
			width: 100%;
			position: static;
			z-index: 1;
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
						<h1>Search the successful Blood Donations</h1>
					</div>
				</div>
			</div>
		</div>

		<div class="basic-login">
			<div class="section">
				<div class="container">
					<div class="row">
						<div class="col-md-12">

							<table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
								<tr>
									<td>From:</td>
									<td class="auto-style1">
										<asp:TextBox ID="tbxFrom" Width="250" runat="server" TextMode="Date"></asp:TextBox>
									</td>
									<td>To:
									</td>
									<td>
										<asp:TextBox ID="tbxTo" Width="250" runat="server" TextMode="Date"></asp:TextBox>
									</td>
									<td>
										<asp:Button ID="btnSearch" class="btn btn-danger" runat="server" Text="Search" OnClick="btnSearch_Click" />
									</td>
									<td>
										<asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
									</td>
								</tr>
							</table>
							<br />
							<asp:Label ID="lblResult" runat="server" Text="" Visible="false"></asp:Label>

							<br />
							<br />
							<br />
							<h4><asp:Label ID="lblheading" runat="server" Text="Blood Donation By User To Users" Visible="false"></asp:Label></h4>
							<div class="basic-login">
								<br />
								<asp:Label ID="lblSorry1" runat="server" Text="Sorry there are no blood donation by User To Users during that time." Visible="false"></asp:Label>
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
							<h4><asp:Label ID="lblHeading2" runat="server" Text="Blood Donation By Establishment to Users" Visible="false"></asp:Label></h4>
							<div class="basic-login">
								<br />
								<asp:Label ID="lblSorry2" runat="server" Text="Sorry there are no blood donation by Establishment to Users during that time." Visible="false"></asp:Label>
								<asp:Panel ID="Panel2" runat="server" Visible="false">
									<asp:GridView ID="GridView2" runat="server" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
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
							<h4><asp:Label ID="lblHeading3" runat="server" Text="Blood Donation By Establishment to Establishments" Visible="false"></asp:Label></h4>
							<div class="basic-login">
								<br />
								<asp:Label ID="lblSorry3" runat="server" Text="Sorry there are no blood donation by Establishment to Establishments during that time." Visible="false"></asp:Label>
								<asp:Panel ID="Panel3" runat="server" Visible="false">
									<asp:GridView ID="GridView3" runat="server" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
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
							<h4><asp:Label ID="lblHeading4" runat="server" Text="Blood Donation By User to Establishments" Visible="false"></asp:Label></h4>
							<div class="basic-login">
								<br />
								<asp:Label ID="lblSorry4" runat="server" Text="Sorry there are no blood donation by User to Establishments during that time." Visible="false"></asp:Label>
								<asp:Panel ID="Panel4" runat="server" Visible="false">
									<asp:GridView ID="GridView4" runat="server" CssClass="table table-nonfluid .table-striped .table-condensed table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
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
						</div>
					</div>
				</div>
			</div>
		</div>
		<br />
		<br />
		<br />
		
	</section>

</asp:Content>

