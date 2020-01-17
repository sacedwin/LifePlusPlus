<%@ Page Title="" Language="C#" MasterPageFile="~/GovernmentMaster.master" AutoEventWireup="true" CodeFile="GChatRoom.aspx.cs" Inherits="GChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<script type="text/javascript">

		window.onload = function () {
			var textarea = document.getElementById('<%=tbxChat.ClientID %>');
			textarea.scrollTop = textarea.scrollHeight;
		}

	</script>

	<script>

		//On UpdatePanel Refresh
		var prm = Sys.WebForms.PageRequestManager.getInstance();
		if (prm != null) {
			prm.add_endRequest(function (sender, e) {
				if (sender._postBackSettings.panelsToUpdate != null) {
					var textarea = document.getElementById('<%=tbxChat.ClientID %>');
					textarea.scrollTop = textarea.scrollHeight;
				}
			});
		};
	</script>

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

		.social-login p {
			text-align: center;
			font-size: 1.2em;
			font-style: italic;
			padding: 20px 0;
		}

		p {
			margin: 0 0 10px;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		p {
			display: block;
			-webkit-margin-before: 1em;
			-webkit-margin-after: 1em;
			-webkit-margin-start: 0px;
			-webkit-margin-end: 0px;
		}

		element.style {
		}


		.section {
			padding: 11.8px 0;
			-webkit-transform: translateZ(0);
			-moz-transform: translateZ(0);
			-o-transform: translateZ(0);
			-ms-transform: translateZ(0);
			transform: translateZ(0);
		}

		.form-group {
			margin-bottom: 15px;
		}


		div {
			display: block;
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

		:before, :after {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		:before, :after {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		
	</style>

	<br />

	<section id="cta-1" class="section-padding">
		<div class="section section-breadcrumbs">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<h1>Forum</h1>
					</div>
				</div>
			</div>
		</div>

		<div class="basic-login">
			<div class="section">
				<div class="container">
					<div class="row">

						<div class="col-sm-12">


							<div class="form-group">
								<center>
                                            <asp:Label ID="label1" runat="server" Font-Bold="true" Font-Size="Large" Text="Common Chatroom for Everyone!"></asp:Label>
                                    </center>
								<br />
								<asp:ScriptManager runat="server" ID="ScriptManager1">
								</asp:ScriptManager>

								<asp:UpdatePanel runat="server" ID="UpdatePanel1" ReadOnly="true" UpdateMode="Conditional">
									<ContentTemplate>
										<asp:Timer runat="server" ID="Timer1" Interval="5000" OnTick="Timer1_Tick1"></asp:Timer>
										<asp:TextBox ID="tbxChat" runat="server" class="form-control" Height="400" TextMode="MultiLine"></asp:TextBox>&nbsp;
									</ContentTemplate>

								</asp:UpdatePanel>

							</div>
						</div>
					</div>

				</div>

			</div>
			<div class="space"></div>
		</div>
		<div class="space"></div>
	</section>

</asp:Content>

