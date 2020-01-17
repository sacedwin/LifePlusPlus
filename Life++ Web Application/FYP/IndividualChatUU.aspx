<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndividualChatUU.aspx.cs" Inherits="IndividualChatUU" %>

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
		.containe .left {
			float: left;
			width: 37.6%;
			height: 100%;
			border: 1px solid #e6e6e6;
			background-color: #fff;
		}

		html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video {
			margin: 0;
			padding: 0;
			border: 0;
			font-size: 100%;
			font: inherit;
			vertical-align: baseline;
		}

		.containe {
			position: relative;
			top: 50%;
			left: 60%;
			width: 80%;
			height: 75%;
			background-color: #fff;
			-webkit-transform: translate(-50%, -50%);
			transform: translate(-50%, -50%);
		}

		.wrapper {
			position: relative;
			left: 50%;
			width: 1000px;
			height: 800px;
			-webkit-transform: translate(-50%, 0);
			transform: translate(-50%, 0);
		}

		.containe .right .chat {
			position: relative;
			display: none;
			overflow: hidden;
			padding: 0 35px 92px;
			border-width: 1px 1px 1px 0;
			border-style: solid;
			border-color: #e6e6e6;
			height: calc(100% - 48px);
			-webkit-box-pack: end;
			-ms-flex-pack: end;
			justify-content: flex-end;
			-webkit-box-orient: vertical;
			-webkit-box-direction: normal;
			-ms-flex-direction: column;
			flex-direction: column;
		}

		.containe .right .bubble.me {
			float: right;
			color: #1a1a1a;
			background-color: #eceff1;
			-ms-flex-item-align: end;
			align-self: flex-end;
			-webkit-animation-name: slideFromRight;
			animation-name: slideFromRight;
		}

		.containe .right .write {
			position: absolute;
			bottom: 29px;
			left: 30px;
			height: 42px;
			padding-left: 8px;
			border: 1px solid #e6e6e6;
			background-color: #eceff1;
			width: calc(100% - 58px);
			border-radius: 5px;
		}

			.containe .right .write .write-link.attach:before {
				display: inline-block;
				float: left;
				width: 20px;
				height: 42px;
				content: '';
				background-image: url(https://s1.postimg.org/s5gfy283f/attachemnt.png);
				background-repeat: no-repeat;
				background-position: center;
			}

			.containe .right .write .write-link.send:before {
				display: inline-block;
				float: left;
				width: 20px;
				height: 42px;
				margin-left: 11px;
				content: '';
				background-image: url(https://s30.postimg.org/nz9dho0pp/send.png);
				background-repeat: no-repeat;
				background-position: center;
			}

		.containe .right .conversation-start {
			position: relative;
			width: 100%;
			margin-bottom: 27px;
			text-align: center;
		}

		.containe .right .bubble.you {
			float: left;
			color: #fff;
			background-color: #00b0ff;
			-ms-flex-item-align: start;
			align-self: flex-start;
			-webkit-animation-name: slideFromLeft;
			animation-name: slideFromLeft;
		}



		.containe .right {
			position: relative;
			float: left;
			width: 80%;
			height: 100%;
		}



			.containe .right .top span .name {
				color: #1a1a1a;
				font-family: 'Source Sans Pro', sans-serif;
				font-weight: 600;
			}

			.containe .right .chat.active-chat {
				display: block;
				display: -webkit-box;
				display: -ms-flexbox;
				display: flex;
			}

			.containe .right .chat {
				position: relative;
				display: none;
				overflow: hidden;
				padding: 0 35px 92px;
				border-width: 1px 1px 1px 0;
				border-style: solid;
				border-color: #e6e6e6;
				height: calc(100% - 48px);
				-webkit-box-pack: end;
				-ms-flex-pack: end;
				justify-content: flex-end;
				-webkit-box-orient: vertical;
				-webkit-box-direction: normal;
				-ms-flex-direction: column;
				flex-direction: column;
			}

			.containe .right .conversation-start {
				position: relative;
				width: 100%;
				margin-bottom: 27px;
				text-align: center;
			}

				.containe .right .conversation-start span {
					font-size: 14px;
					display: inline-block;
					color: #999;
				}

					.containe .right .conversation-start span:before {
						left: 0;
					}

					.containe .right .conversation-start span:before, .containe .right .conversation-start span:after {
						position: absolute;
						top: 10px;
						display: inline-block;
						width: 30%;
						height: 1px;
						content: '';
						background-color: #e6e6e6;
					}

					.containe .right .conversation-start span:after {
						right: 0;
					}

					.containe .right .conversation-start span:before, .containe .right .conversation-start span:after {
						position: absolute;
						top: 10px;
						display: inline-block;
						width: 30%;
						height: 1px;
						content: '';
						background-color: #e6e6e6;
					}

		*, *:before, *:after {
			box-sizing: border-box;
		}

		.containe .right .conversation-start {
			position: relative;
			width: 100%;
			margin-bottom: 27px;
			text-align: center;
		}

		.containe .right .chat.active-chat .bubble:nth-of-type(2) {
			-webkit-animation-duration: 0.3s;
			animation-duration: 0.3s;
		}

		.containe .right .chat.active-chat .bubble {
			-webkit-transition-timing-function: cubic-bezier(0.4, -0.04, 1, 1);
			transition-timing-function: cubic-bezier(0.4, -0.04, 1, 1);
		}

		.containe .right .bubble.you {
			float: left;
			color: #fff;
			background-color: #00b0ff;
			-ms-flex-item-align: start;
			align-self: flex-start;
			-webkit-animation-name: slideFromLeft;
			animation-name: slideFromLeft;
		}

			.containe .right .bubble.you:before {
				left: -3px;
				background-color: #00b0ff;
			}

			.containe .right .bubble.you:before {
				left: -3px;
				background-color: #00b0ff;
			}

		.containe .right {
			position: relative;
			float: left;
			width: 72.4%;
			height: 100%;
		}

			.containe .right .top {
				width: 100%;
				height: 47px;
				padding: 15px 29px;
				background-color: #eceff1;
			}


				.containe .right .top span .name {
					color: #1a1a1a;
					font-family: 'Source Sans Pro', sans-serif;
					font-weight: 600;
				}

				.containe .right .top span {
					font-size: 15px;
					color: #222;
				}

			.containe .right .chat.active-chat {
				display: block;
				display: -webkit-box;
				display: -ms-flexbox;
				display: flex;
			}

			.containe .right .chat {
				position: relative;
				display: none;
				overflow: hidden;
				padding: 0 35px 92px;
				border-width: 1px 1px 1px 0;
				border-style: solid;
				border-color: #e6e6e6;
				height: calc(100% - 48px);
				-webkit-box-pack: end;
				-ms-flex-pack: end;
				justify-content: flex-end;
				-webkit-box-orient: vertical;
				-webkit-box-direction: normal;
				-ms-flex-direction: column;
				flex-direction: column;
			}

			.containe .right .conversation-start {
				position: relative;
				width: 100%;
				margin-bottom: 27px;
				text-align: center;
			}

				.containe .right .conversation-start span {
					font-size: 14px;
					display: inline-block;
					color: #999;
				}

					.containe .right .conversation-start span:before {
						left: 0;
					}

					.containe .right .conversation-start span:before, .containe .right .conversation-start span:after {
						position: absolute;
						top: 10px;
						display: inline-block;
						width: 30%;
						height: 1px;
						content: '';
						background-color: #e6e6e6;
					}

					.containe .right .conversation-start span:after {
						right: 0;
					}

					.containe .right .conversation-start span:before, .containe .right .conversation-start span:after {
						position: absolute;
						top: 10px;
						display: inline-block;
						width: 30%;
						height: 1px;
						content: '';
						background-color: #e6e6e6;
					}

			.containe .right .bubble.me {
				float: right;
				color: #1a1a1a;
				background-color: #eceff1;
				-ms-flex-item-align: end;
				align-self: flex-end;
				-webkit-animation-name: slideFromRight;
				animation-name: slideFromRight;
			}

			.containe .right .write input {
				font-size: 16px;
				float: left;
				width: 444px;
				height: 40px;
				color: #1a1a1a;
				border: 0;
				outline: none;
				background-color: #eceff1;
				font-family: 'Source Sans Pro', sans-serif;
				font-weight: 400;
			}

		input {
			-webkit-appearance: textfield;
			background-color: white;
			-webkit-rtl-ordering: logical;
			user-select: text;
			cursor: auto;
			padding: 1px;
			border-width: 2px;
			border-style: inset;
			border-color: initial;
			border-image: initial;
		}

		input, textarea, select, button {
			text-rendering: auto;
			color: initial;
			letter-spacing: normal;
			word-spacing: normal;
			text-transform: none;
			text-indent: 0px;
			text-shadow: none;
			display: inline-block;
			margin: 0em;
			font: 13.3333px Arial;
		}

		input, textarea, select, button, meter, progress {
			-webkit-writing-mode: horizontal-tb;
		}

		.containe .right .write .write-link.smiley:before {
			display: inline-block;
			float: left;
			width: 20px;
			height: 42px;
			content: '';
			background-image: url(https://s14.postimg.org/q2ug83h7h/smiley.png);
			background-repeat: no-repeat;
			background-position: center;
		}
	</style>




	<br />
	<br />
	<br />
	<div class="wrapper">
		<div class="containe">
			<div class="right">
				<div class="top">
					<span>To:<span class="name">
						<asp:Label ID="lblName" runat="server" Text="lblName" ForeColor="Black"></asp:Label></span></span>
				</div>
				<br />
				<div>
					<asp:ScriptManager runat="server" ID="ScriptManager1">
					</asp:ScriptManager>

					<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
						<ContentTemplate>
							<asp:Timer runat="server" ID="Timer1" Interval="5000" OnTick="Timer1_Tick1"></asp:Timer>
							<asp:TextBox ID="tbxChat" ReadOnly="true" runat="server" Text="" Width="100%" Height="430px" TextMode="MultiLine"></asp:TextBox>
						</ContentTemplate>

					</asp:UpdatePanel>

				</div>
				<div class="write">
					<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
					<asp:Button ID="BtnSentMessage" class="write-link send" runat="server" Text="Sent" ForeColor="Red" Width="40px" OnClick="BtnSentMessage_Click1" />
				</div>
			</div>
		</div>
	</div>
</asp:Content>

