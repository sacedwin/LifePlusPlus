<%@ Page Title="" Language="C#" MasterPageFile="~/HospitalMaster.master" AutoEventWireup="true" CodeFile="HospitalHomePage.aspx.cs" EnableEventValidation="false" Inherits="HospitalHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	
     <style>
        .section-breadcrumbs {
            background: #222;
            background: rgba(255, 255, 255, 0.8);
            margin-bottom: 10px;
        }

        body {
            font-family: 'Open Sans', sans-serif;
            line-height: 20px;
            color: #999999;
            font-size: 14px;
        }

        .section-breadcrumbs h1 {
            color: #222;
            font-size: 1.6em;
            margin-bottom: 0;
            text-transform: none;
        }

        .schedule-tab {
            background-color: #8B0000;
            float: left;
        }

        .btn-form, .btn-form:hover, .btn-form:focus {
            background-color: #8B0000;
            color: #fff;
            border-radius: 0px;
            padding: 10px 20px;
        }

        .our-stats {
            background: #fff;
        }

            .our-stats > .container {
                padding: 60px 0px;
            }

        .our-stat-icon .fa {
            font-size: 60px;
            color: #222;
            line-height: 90px;
        }

        .our-stat-info span {
            color: #222;
            font-size: 32px;
            margin: 1em 0;
            line-height: 60px;
        }

        .thumbnail {
            border-radius: 100px;
        }

        .our-stat-info h5 {
            color: #222;
            line-height: 3em;
            text-transform: uppercase;
            letter-spacing: 0.05em;
            margin: 0 0;
        }
    </style>

    <section id="banner" class="banner">
        <div class="bg-color">
            <div class="container">
                <div class="row">
                    <div class="banner-info">
                        <div class="banner-logo text-center">
                            <img src="img/FinalLogo.png" class="img-responsive" width="300" height="200" />
                        </div>
                        <div class="banner-text text-center">
                            <h1 class="white">Saving lives through connections</h1>

                            <asp:Button ID="Button1" runat="server" class="btn btn-appoint" Text="Join Us" OnClick="Button1_Click" />
                        </div>
                        <div class="overlay-detail text-center">
                            <a href="#service"><i class="fa fa-angle-down"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/ banner-->
    <!--service-->
    <section id="service" class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-4">
                    <h2 class="ser-title">Our Service</h2>
                    <hr class="botm-line">
                    <p>We provide a platform that connects hospitals and blood banks with blood, platelet and organ donors. Our system provides a way for patients in need of blood/platelets to instantly connect with donors.</p>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="service-info">
                        <div class="icon">
							<img src="img/logos/Blood-Donation.jpg" width="60px" height="60px"/>
                        </div>
                        <div class="icon-info">
                            <h4>Blood/Platelet Donation</h4>
                            <p>Donors and establishments accept requests to donate blood, minimising unnecessary fatalities due to lack of availability of blood.</p>
                        </div>
                    </div>
                    <div class="service-info">
                        <div class="icon">
                           
                        </div>
                        <div class="icon-info">
                           
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="service-info">
                        <div class="icon">
							<img src="img/logos/92_illustrations_all_41.png" width="60px" height="60px" />
                        </div>
                        <div class="icon-info">
                            <h4>Organ Donation</h4>
                            <p>We have a reliable algorithm that matches transplant patients with potential donors based on urgency, waiting time and distance.</p>
                        </div>
                    </div>
                    <div class="service-info">
                        <div class="icon">
                           
                        </div>
                        <div class="icon-info">
                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/ service-->


    <!-- [CURRENT STATS]
=============================================================================================================================-->
    <section class="our-stats" id="stats">
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="our-stats-box text-center">
                        <div class="our-stat-icon">
                            <img height="100" width="100" src="img/user1600.png" />
                        </div>
                        <div class="our-stat-info">
                            <asp:Label ID="lblTotalUsers" runat="server" Text="0"></asp:Label>
                            <h5>Total Users</h5>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="our-stats-box text-center">
                        <div class="our-stat-icon">
                            <img height="100" width="100" src="img/Icons8-Windows-8-City-Hospital.ico" />
                        </div>
                        <div class="our-stat-info">
                            <asp:Label ID="lblTotalAssociates" runat="server" Text="0"></asp:Label>

                            <h5>Total Associates</h5>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="our-stats-box text-center">
                        <div class="our-stat-icon">
                            <img height="100" width="100" src="img/5359-200.png" />
                        </div>
                        <div class="our-stat-info">
                            <asp:Label ID="lblSuccessfulBloodDonation" runat="server" Text="0"></asp:Label>

                            <h5>Successful Blood Donations</h5>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-6">
                    <div class="our-stats-box text-center">
                        <div class="our-stat-icon">
                            <img height="100" width="100" src="img/organ-donation-36c38d7b6b8b3174-512x512.png" />
                        </div>
                        <div class="our-stat-info">
                            <asp:Label ID="lblOrganDonation" runat="server" Text="0"></asp:Label>

                            <h5>Successful Organ Donations</h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- [CURRENT STATS]
=============================================================================================================================-->

    
    <!--our asscoiates-->
    <section id="doctor-team" class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="ser-title">Our Associates!</h2>
                    <hr class="botm-line" />
                </div>

                <div class="col-md-3 col-sm-3 col-xs-6">
                    <div class="thumbnail">
                        <a href="#">
                            <img src="img/logos/coming-soon_0.jpg" width="100"  /></a>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-6">
                    <div class="thumbnail">
                        <a href="#">
                            <img src="img/logos/coming-soon_0.jpg" width="100"  /></a>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-6">
                    <div class="thumbnail">
                        <a href="#">
                            <img src="img/logos/coming-soon_0.jpg" width="100"  /></a>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-6">
                    <div class="thumbnail">
                        <a href="#">
                            <img src="img/logos/coming-soon_0.jpg" width="100" /></a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/ our asscoiates-->

    <!--contact-->
    <section id="contact" class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h2 class="ser-title">Contact us</h2>
                    <hr class="botm-line" />
                </div>
                <div class="col-md-4 col-sm-4">
                    <h3>Contact Info</h3>
                    <div class="space"></div>
                    <p><i class="fa fa-map-marker fa-fw pull-left fa-2x"></i>355 Jalan Bukit Ho Swee, 169567</p>
                    <div class="space"></div>
                    <p><i class="fa fa-envelope-o fa-fw pull-left fa-2x"></i>wolfpack@gmail.com</p>
                    <div class="space"></div>
                    <p><i class="fa fa-phone fa-fw pull-left fa-2x"></i>+65 0000 0000</p>
                    <div class="space"></div>
                    <p>
                        <iframe src="https://maps.google.com/maps?q=PSB Academy Delta Campus Singapore, &t=&z=14&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
                    </p>

                </div>

                <div class="col-md-8 col-sm-8 marb20">
                    <div class="contact-info">
                        <h3 class="cnt-ttl">If you have any enquiry or feedback, message us!</h3>
                        <div class="space"></div>
                        <form action="" method="post" role="form" class="contactForm">
                            <div class="form-group">
                                <asp:TextBox ID="tbxFName" class="form-control br-radius-zero" placeholder="Your Name" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="tbxFEmail" class="form-control br-radius-zero" placeholder="Your Email" runat="server" TextMode="Email"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="tbxFSubject" class="form-control br-radius-zero" placeholder="Subject" runat="server"></asp:TextBox>
                                <div class="validation"></div>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="tbxMessage" placeholder="Message" class="form-control br-radius-zero" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            </div>

                            <div class="form-action">
                                <asp:Button ID="btnFeedback" class="btn btn-form" runat="server" Text="Send Message" OnClick="btnFeedback_Click" />
                            </div>
                            <div class="form-action">
                                <asp:Label ID="lblOutput" runat="server" Text="" ForeColor="Black"></asp:Label>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

