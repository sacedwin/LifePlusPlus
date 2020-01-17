<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WhoCanDonate.aspx.cs" Inherits="WhoCanDonate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



	<style>
		#accordion {
			border: solid 2px #c7c7c7;
			border-radius: 5px;
			margin: 5px 0 15px 0;
			padding: 20px 15px 0 15px;
			background-color: #fff;
		}

		body {
			font-family: 'Open Sans', sans-serif;
			line-height: 20px;
			color: #999999;
			font-size: 14px;
		}

		.accordion-toggle {
			cursor: pointer;
			margin: 0 0 15px 0;
		}



		element.style {
			width: 15px;
		}

		.pull-right {
			float: right !important;
		}

		img {
			vertical-align: middle;
		}

		img {
			border: 0;
		}

		element.style {
			overflow: hidden;
			display: none;
		}

		.accordion-content.default {
			display: block;
		}

		.accordion-content {
			display: none;
			padding: 10px 15px 10px 15px;
			border: solid 1px #ebeaea;
			border-left: solid 5px #d81e05;
			border-radius: 5px;
			background-color: #fff;
			margin: 15px 0 15px 0;
		}





		.cf:before, .pod:before, .cf:after, .pod:after {
			content: "";
			display: table;
		}

		.pod-blood-estimate .styled-select {
			background: url(/img/select-dropdown-arrow.png) no-repeat 150px #fff;
			width: 170px;
			display: inline-block;
			margin-right: 10px;
		}

		*:before, *:after {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		.pod-round-wrap {
			overflow: hidden;
			border: 1px solid #c7c7c7;
			border-radius: 5px;
			margin-top: 30px;
			margin-bottom: 30px;
		}

			.pod-round-wrap .pod {
				border: none;
				border-left: 3px solid #d81e05;
				margin-bottom: 0;
			}

		element.style {
			display: block;
		}

		.pod-blood-estimate .result {
			display: none;
		}

		.pod > .media-ob {
			display: block;
			background: #f9f9f9;
			margin: 0 -20px;
			padding: 20px 20px 0;
		}

		.media-ob {
			display: inline-block;
			text-decoration: none;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		div {
			display: block;
		}


		.pod-tint {
			background-color: #f9f9f9;
		}

		.pod {
			background-color: #fff;
			border: 1px solid #c7c7c7;
			padding: 0 20px;
			margin-bottom: 20px;
		}

		.pod-blood-estimate-weight, .pod-blood-estimate-height {
			display: inline-block;
		}

		.pod-blood-estimate label {
			font-size: 12px;
			padding-right: 10px;
			display: inline;
		}

		label {
			display: inline-block;
			max-width: 100%;
			margin-bottom: 5px;
			font-weight: bold;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		button, select {
			text-transform: none;
		}

		button, input, optgroup, select, textarea {
			color: inherit;
			font: inherit;
			margin: 0;
		}



		.pod-blood-estimate select {
			background: transparent;
			width: 170px;
			padding: 8px 7px;
			line-height: 1.4;
			border: 1px #cfcfcf solid;
			color: #3d3d3d;
			font-size: 12px;
			-webkit-appearance: none;
		}

		input, button, select, textarea {
			font-family: inherit;
			font-size: inherit;
			line-height: inherit;
		}

		option {
			font-weight: normal;
			display: block;
			white-space: pre;
			min-height: 1.2em;
			padding: 0px 2px 1px;
		}

		body {
			line-height: 1.42857;
			color: #333333;
			background-color: #fff;
		}

		ul {
			display: block;
			list-style-type: disc;
			-webkit-margin-before: 1em;
			-webkit-margin-after: 1em;
			-webkit-margin-start: 0px;
			-webkit-margin-end: 0px;
			-webkit-padding-start: 40px;
		}

		.pod-blood-estimate .btn {
			margin-bottom: 0;
		}

		.btn-red {
			background: #e51800;
			background: -moz-linear-gradient(top,#e51800 15%,#bb0400 99%);
			background: -webkit-gradient(linear,left top,left bottom,color-stop(15%,#e51800),color-stop(99%,#bb0400));
			background: -webkit-linear-gradient(top,#e51800 15%,#bb0400 99%);
			background: -o-linear-gradient(top,#e51800 15%,#bb0400 99%);
			background: -ms-linear-gradient(top,#e51800 15%,#bb0400 99%);
			background: linear-gradient(to bottom,#e51800 15%,#bb0400 99%);
			color: #fff !important;
			white-space: nowrap;
		}

		.btn {
			display: inline-block;
			margin-bottom: 0;
			font-weight: normal;
			text-align: center;
			vertical-align: middle;
			touch-action: manipulation;
			cursor: pointer;
			background-image: none;
			border: 1px solid transparent;
			white-space: nowrap;
			padding: 6px 12px;
			font-size: 17px;
			line-height: 1.42857;
			border-radius: 3px;
			-webkit-user-select: none;
			-moz-user-select: none;
			-ms-user-select: none;
			user-select: none;
		}

		a {
			cursor: pointer;
		}

		a {
			color: #D81E05;
			text-decoration: none;
			font-weight: bold;
		}

		a {
			background-color: transparent;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}



		.media-ob .media.icon {
			margin: 1px 20px 10px 0;
		}

		.media-ob .media {
			position: relative;
			float: left;
			margin: 0 5px 0 0;
		}

		.media:first-child {
			margin-top: 0;
		}

		.media-ob .media.icon {
			margin: 1px 20px 10px 0;
		}



		.icon-success-tick {
			width: 30px;
			height: 31px;
			background-position: -132px -180px;
		}


		[class^="icon-"], [class*=" icon-"] {
			font-family: 'nhsbt-icon';
			speak: none;
			font-style: normal;
			font-weight: normal;
			font-variant: normal;
			text-transform: none;
			line-height: 1;
			-webkit-font-smoothing: antialiased;
		}

		.media, .media-body {
			zoom: 1;
			overflow: hidden;
		}

		.media {
			margin-top: 15px;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		i, cite, em, var, address, dfn {
			font-style: italic;
		}


		.icon-fail-cross {
			width: 30px;
			height: 31px;
			background-position: -132px -231px;
		}

		.media, .media-body {
			zoom: 1;
			overflow: hidden;
		}

		.media {
			margin-top: 15px;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		i, cite, em, var, address, dfn {
			font-style: italic;
		}

		.icon {
			display: inline-block;
			width: 24px;
			height: 24px;
			text-indent: -9999px;
			background: url(/img/blood-icon-sprite.png);
			margin: 0 20px 0 0;
		}

		.media-ob .media-bd {
			overflow: hidden;
		}

		.pod-blood-estimate .result {
			display: none;
		}

		.pod > .media-ob {
			display: block;
			background: #fff;
			margin: 0 -20px;
			padding: 20px 20px 0;
		}


		.pod-blood-estimate select {
			background: transparent;
			width: 170px;
			padding: 8px 7px;
			line-height: 1.4;
			border: 1px #cfcfcf solid;
			color: #3d3d3d;
			font-size: 12px;
			-webkit-appearance: none;
		}

		*:before, *:after {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		*:before, *:after {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}

		input, button, select, textarea {
			font-family: inherit;
			font-size: inherit;
			line-height: inherit;
		}

		button, select {
			text-transform: none;
		}

		button, input, optgroup, select, textarea {
			color: inherit;
			font: inherit;
			margin: 0;
		}

		* {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
		}


		select, select[size="0"], select[size="1"] {
			border-radius: 0px;
			border-color: rgb(169, 169, 169);
		}

		select {
			-webkit-appearance: menulist;
			box-sizing: border-box;
			align-items: center;
			white-space: pre;
			color: black;
			background-color: white;
			cursor: default;
			border-width: 1px;
			border-style: solid;
			border-color: initial;
			border-image: initial;
		}

		select {
			border-radius: 5px;
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
			text-align: start;
			margin: 0em;
			font: 13.3333px Arial;
		}


		.media-ob {
			display: inline-block;
			text-decoration: none;
		}

			.media-ob .media.icon {
				margin: 1px 20px 10px 0;
			}

			.media-ob .media {
				position: relative;
				float: left;
				margin: 0 5px 0 0;
			}

		.media:first-child {
			margin-top: 0;
		}

		.icon-fail-cross {
			width: 30px;
			height: 31px;
			background-position: -132px -231px;
		}

		.media-ob .media-bd {
			overflow: hidden;
		}

		.pod-blood-estimate .pod-outdent-border {
			margin-top: 15px;
		}

		.pod-outdent-border:last-child {
			margin-bottom: 0;
		}

		.pod-outdent-border {
			border-top: 1px #e0e0e0 solid;
			margin: 0 -10px 0 -20px;
			padding: 15px 20px;
		}
	</style>

	<section class="section-padding">
	</section>



	<div class="section">
		<div class="container">
			<div class="col-sm-9">
				<h3>Who can donate blood?</h3>
				<br />
				<p>
					Most people can donate blood if they meet the following requirement:
				</p>
				<ul>
					<li>are fit and healthy</li>
					<li>weigh over 7 stone 12 lbs or 50kg</li>
					<li>are aged between 18 and 66 (or 70 if you have given blood before)</li>
					<li>are over 70 and have given blood in the last two years</li>

				</ul>
				<br />
				<h4>How often can I give blood?</h4>
				<p>Men can give blood every 12 weeks and women can give blood every 16 weeks.</p>
				<br />
				<h4>Can women under 20 donate blood?</h4>
				<p>
					If you are a woman under 20 and you weigh under 10st 3lb or 65kg or 
                    are under 5' 6" or 168cm tall you will need to estimate your blood 
                    volume to see if you can give blood. If your weight lies between 
                    two of the values shown, please use the nearest lower weight.
				</p>


				<div class="content-left-offset pod-round-wrap">
					<div class="pod pod-tint pod-blood-estimate">
						<h4>Estimated blood volume for female donors aged 17-20:</h4>
						<div class="pod-blood-estimate-height">
							<div class="pod-blood-estimate-height">
								<label for="height">Your height:</label>
								<div class="styled-select">
									<asp:DropDownList ID="ddlHeight" runat="server">
										<asp:ListItem Value="149">149cm (4’10") or less</asp:ListItem>
										<asp:ListItem Value="150">150cm (4’11")</asp:ListItem>
										<asp:ListItem Value="151">151cm</asp:ListItem>
										<asp:ListItem Value="152">152cm (4’11½")</asp:ListItem>
										<asp:ListItem Value="153">153cm</asp:ListItem>
										<asp:ListItem Value="154">154cm (5’½")</asp:ListItem>
										<asp:ListItem Value="155">155cm</asp:ListItem>
										<asp:ListItem Value="156">156cm (5’1½")</asp:ListItem>
										<asp:ListItem Value="157">157cm</asp:ListItem>
										<asp:ListItem Value="158">158cm (5’2")</asp:ListItem>
										<asp:ListItem Value="159">159cm</asp:ListItem>
										<asp:ListItem Value="160">160cm (5’3")</asp:ListItem>
										<asp:ListItem Value="161">161cm</asp:ListItem>
										<asp:ListItem Value="162">162cm (5’4")</asp:ListItem>
										<asp:ListItem Value="163">163cm</asp:ListItem>
										<asp:ListItem Value="164">164cm (5’4½")</asp:ListItem>
										<asp:ListItem Value="165">165cm</asp:ListItem>
										<asp:ListItem Value="166">166cm (5’5")</asp:ListItem>
										<asp:ListItem Value="167">167cm</asp:ListItem>
										<asp:ListItem Value="168">168cm (5’6") or more</asp:ListItem>
									</asp:DropDownList>
								</div>
							</div>
						</div>
						<div class="pod-blood-estimate-weight">
							<div class="pod-blood-estimate-weight">
								<label for="weight">Your weight:</label><div class="styled-select">
									<asp:DropDownList ID="ddlWeight" runat="server">
										<asp:ListItem Value="49">(49kg) 7st 10 or less</asp:ListItem>
										<asp:ListItem Value="50">(50kg) 7st 12</asp:ListItem>
										<asp:ListItem Value="51">(51kg) 8st</asp:ListItem>
										<asp:ListItem Value="52">(52kg) 8st 3</asp:ListItem>
										<asp:ListItem Value="53">(53kg) 8st 5</asp:ListItem>
										<asp:ListItem Value="54">(54kg) 8st 7</asp:ListItem>
										<asp:ListItem Value="55">(55kg) 8st 9</asp:ListItem>
										<asp:ListItem Value="56">(56kg) 8st 11</asp:ListItem>
										<asp:ListItem Value="57">(57kg) 9st</asp:ListItem>
										<asp:ListItem Value="58">(58kg) 9st 2</asp:ListItem>
										<asp:ListItem Value="59">(59kg) 9st 4</asp:ListItem>
										<asp:ListItem Value="60">(60kg) 9st 6</asp:ListItem>
										<asp:ListItem Value="61">(61kg) 9st 8</asp:ListItem>
										<asp:ListItem Value="62">(62kg) 9st 11</asp:ListItem>
										<asp:ListItem Value="63">(63kg) 9st 13</asp:ListItem>
										<asp:ListItem Value="64">(64kg) 10st 1 or more</asp:ListItem>
									</asp:DropDownList>
								</div>
							</div>
						</div>
						<asp:Button ID="btnEstimate" class="btn-red" runat="server" Text="Estimate" OnClick="btnEstimate_Click1" />
						<div class="positive result media-ob">
							<div class="media-bd">
								<asp:Label ID="lblGNews" runat="server" Text="Good news, your estimated blood volume is more than 3500ml, meaning you are able to give blood." ForeColor="#00CC00"></asp:Label>
								<asp:Label ID="lblBNews" runat="server" Text="Sorry, your estimate blood volume is less than 3500ml, unfortunately you are unable to donate until after your 20th birthday." ForeColor="#FF3300"></asp:Label>

							</div>
						</div>

					</div>
				</div>




				<h4>Blood Safety</h4>
				<p>
					We must make sure it is safe for people to give blood and for patients to 
                        receive donated blood. Blood safety information is below:
				</p>
				<div id="accordion">
					<h4 class="accordion-toggle">You must not give blood or platelets if...<img style="width: 15px;" class="pull-right" src="/img/arrow-down-mobile-pod.png" alt="Reasons why you must not give blood or platelets" title="Click here to expand"></h4>
					<div class="accordion-content default" style="overflow: hidden; display: block;">
						<ul>
							<li><span>You think you need a test for HIV/AIDS, HTLV or hepatitis</span>.</li>
						</ul>
					</div>
					<h4 class="accordion-toggle">You must never give blood or platelets if...<img style="width: 15px;" class="pull-right" src="/img/arrow-down-mobile-pod.png" alt="Reasons why you must never give blood or platelets" title="Click here to expand"></h4>
					<div class="accordion-content" style="overflow: hidden; display: none;">
						<ul>
							<li>You are HIV positive.</li>
							<li>You are a hepatitis B carrier.</li>
							<li>You are a hepatitis C carrier.</li>
							<li>You are HTLV positive</li>
							<li>You have ever had or been treated for syphilis</li>
							<li>You have ever received money or drugs for sex.</li>
							<li>You have ever injected, or been injected with, drugs; even a long time ago or only once. This includes body-building drugs and injectable tanning agents. You may be able to give if a doctor prescribed the drugs. Please check with us to make sure.</li>
						</ul>
					</div>


					<h4 class="accordion-toggle">You must not give blood or platelets for at least 12 months after sex (even if you used a condom or other protective) with...<img style="width: 15px;" class="pull-right" src="/img/arrow-down-mobile-pod.png" alt="Reasons you must not give blood or platelets for at least 12 months after sex with" title="Click here to expand"></h4>
					<div class="accordion-content" style="overflow: hidden; display: none;">
						<ul>
							<li>If you are a man who, in the last 12 months has had oral or anal sex with another man (even if you used a condom or other protective).</li>
							<li>(If you are a woman) a man who has <strong>ever</strong> had oral or anal sex with another man, even if they used a condom or other protective. There are exceptions, so please check.</li>
							<li>A partner who is, or you think may be:
                                    <ul>
										<li>HIV positive</li>
										<li>A hepatitis B carrier</li>
										<li>A hepatitis C carrier</li>
										<li>HTLV positive</li>
										<li>Syphilis positive</li>
									</ul>
							</li>
							<p></p>
							<li>A partner who has <strong>ever</strong> received money or drugs for sex.</li>
							<li>A partner who has <strong>ever</strong> injected, or been injected with, drugs - even a long time ago or only once. This includes body-building drugs and injectable tanning agents. You may be able to give if a doctor prescribed the drugs. Please check with us to make sure.&nbsp;</li>
							<li>A partner who has, or you think may have been, sexually active in parts of the world where HIV/ AIDS is very common. This includes most countries in Africa. There are exceptions, so please check with us to make sure.</li>
						</ul>
					</div>
				</div>
				<p>&nbsp;</p>
				<h3>Who can donate Organ?</h3>
				<br />
				<h4>Q1. Who can donate Organ?</h4>
				<p>
					Virtually anyone can become a donor. 
                    Your<b> medical condition at the time of death</b> will determine what organs and tissues 
                    can be donated can be donated for transplant or scientific research.
				</p>
				<br />
				<h4>Q2. What organs and tissues can I donate?</h4>
				<p>
					One organ donor can save up to eight lives. One eye and tissue donor 
                    can save or improve the lives of up to 50 people. This means an organ, 
                    eye and tissue donor can potentially impact the lives of 58 people!
                    Organs that can be donated for transplantation include kidneys, heart, lungs,
                     liver, small bowel and pancreas.Tissues that can be donated include eyes, 
                    heart valves, bone, skin, veins and tendons.
				</p>

				<object height="450" width="720" >
					<param name="movie" value="body.swf"/>
					<param name="bgcolor" value="4D0000"/>
					<param name="quality" value="best"/>
					<param name="play" value="true"/>
				<embed height="450" src="body.swf" quality="best" play="true" bgcolor="4D0000" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="720" />
				</object>

				<br />
				<br />
				<h4>Q3. What is living donation and can I donate a kidney or other organs while I’m alive?</h4>
				<p>
					It is becoming more common to donate organs and partial organs while living.
                    Kidneys are the most common organs donated by living donors.
                    Other organs that can be donated by a living donor include a lobe of a lung, 
                    partial liver, pancreas or intestine.
				</p>
				<br />
				<h4>Q4. Can I sell my organs?</h4>
				<p>
					No. The buying and selling of organs is illegal as part of the National Organ Transplant Act.
				</p>
				<br />
				<h4>Q5. Is there an age limit for donating organs?</h4>
				<p>
					No set age limit exists for organ donation. At the time of death, the potential donor’s organs are evaluated to determine their suitability for donation.<br />
					Individuals in their 80s and 90s have successfully donated organs including liver and kidneys to save the lives of others.<br />
					You must be 18 years of age to register here to donate organs.<br />
					People of any age wishing to become organ and tissue donors should inform their families that they wish to donate.
				</p>
				<br />
				<h4>Q6. Will organ and tissue donation change the appearance of my body?</h4>
				<p>
					No, donation does not disfigure the body or interfere with funeral arrangements.
                    It is still possible to have an open casket funeral.
				</p>
				<br />
				<br />
				<br />
				<br />



			</div>



			<div class="col-md-9.col-md-3" style="position: absolute; padding-left: 60%; top: 130px">
				<h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To Whom Can I Donate?</h4><br />
				<video autoplay loop width="320" height="320" controls="controls">
					<source src="BloodVideo.MP4" type="video/mp4" />
				</video>
			</div>


		</div>
	</div>



</asp:Content>

