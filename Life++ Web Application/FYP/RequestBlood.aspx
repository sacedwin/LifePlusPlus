<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="RequestBlood.aspx.cs" Inherits="RequestBlood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div id="page-wrapper">
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header">Request Blood</h1>
			</div>
			<div class="row">
				<div class="col-lg-12">
					<div class="col-lg-4">
						<div class="panel panel-red">
							<div class="panel-heading">
								Please Enter Details
							</div>
							<div class="panel-body">
								<div class="panel-body">
									<div class="row">
										<div class="col-lg-6">
											<form role="form">
												<div class="form-group">
													<label>Select Blood Type</label>
													<asp:DropDownList ID="ddlBloodType" class="form-control" runat="server">
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
												</div>
												<div class="form-group">
													<label>Enter Amount</label>
													<asp:TextBox ID="tbxAmount" class="form-control" runat="server" required="true" placeholder="No. Of Units" TextMode="Number"></asp:TextBox>
												</div>
												<div class="form-group">
													<label>Request Type</label>
													<asp:DropDownList ID="ddlRequestType" runat="server">
														<asp:ListItem Value="blood">Blood</asp:ListItem>
														<asp:ListItem Value="platelet">Platelet</asp:ListItem>
													</asp:DropDownList>
												</div>
												<asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-danger" OnClick="btnSubmit_Click" />

												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblOutput" runat="server"></asp:Label>
										</div>
										<div class="panel-footer">
										</div>
									</div>
									<!-- /.col-lg-4 -->
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

