<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FacebookRegister.aspx.cs" Inherits="FacebookRegister" %>

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

            



        </style>




    <br/>
    <br/>
    <br/>

    <section id="cta-1" class="section-padding">
        <div class="section section-breadcrumbs">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1>Register Form</h1>
                        <h4>Please fill in the following to complete your registration.</h4>
                    </div>
                </div>
            </div>
        </div>

        <div class="basic-login">
            <div class="section">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- start id-form -->
                            <table border="0" cellpadding="0" cellspacing="0" border="0" id="id-form">
                                
                                <tr>
                                    <th>Name:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxName" class="form-control" Width="200" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbxName" ErrorMessage="Name cannot be blank"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Gender:*</th>
                                    <td class="auto-style1">
                                        <asp:RadioButton ID="RadioMale" GroupName="RadioGender" runat="server" Text="&nbsp;Male" Checked="True" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:RadioButton ID="RadioFemale" GroupName="RadioGender"  runat="server" Text="&nbsp;Female" />
                                    </td>

                                </tr>
                                <tr>
                                    <th>Date of Birth:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxDOB" class="form-control" Width="180" runat="server" type="date" ReadOnly="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDOB" runat="server" Text="You must be above 18 to register" Visible="False"></asp:Label>
                                        <asp:RequiredFieldValidator ID="DOBVali" runat="server" ErrorMessage="Please enter the your date of birth" ControlToValidate="tbxDOB" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Nationality:*</th>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlNationality" class="form-control" Width="180" runat="server">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>

                                            <asp:ListItem Value="AF">Afghanistan</asp:ListItem>

                                            <asp:ListItem Value="AL">Albania</asp:ListItem>

                                            <asp:ListItem Value="DZ">Algeria</asp:ListItem>

                                            <asp:ListItem Value="AS">American Samoa</asp:ListItem>

                                            <asp:ListItem Value="AD">Andorra</asp:ListItem>

                                            <asp:ListItem Value="AO">Angola</asp:ListItem>

                                            <asp:ListItem Value="AI">Anguilla</asp:ListItem>

                                            <asp:ListItem Value="AQ">Antarctica</asp:ListItem>

                                            <asp:ListItem Value="AG">Antigua And Barbuda</asp:ListItem>

                                            <asp:ListItem Value="AR">Argentina</asp:ListItem>

                                            <asp:ListItem Value="AM">Armenia</asp:ListItem>

                                            <asp:ListItem Value="AW">Aruba</asp:ListItem>

                                            <asp:ListItem Value="AU">Australia</asp:ListItem>

                                            <asp:ListItem Value="AT">Austria</asp:ListItem>

                                            <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>

                                            <asp:ListItem Value="BS">Bahamas</asp:ListItem>

                                            <asp:ListItem Value="BH">Bahrain</asp:ListItem>

                                            <asp:ListItem Value="BD">Bangladesh</asp:ListItem>

                                            <asp:ListItem Value="BB">Barbados</asp:ListItem>

                                            <asp:ListItem Value="BY">Belarus</asp:ListItem>

                                            <asp:ListItem Value="BE">Belgium</asp:ListItem>

                                            <asp:ListItem Value="BZ">Belize</asp:ListItem>

                                            <asp:ListItem Value="BJ">Benin</asp:ListItem>

                                            <asp:ListItem Value="BM">Bermuda</asp:ListItem>

                                            <asp:ListItem Value="BT">Bhutan</asp:ListItem>

                                            <asp:ListItem Value="BO">Bolivia</asp:ListItem>

                                            <asp:ListItem Value="BA">Bosnia And Herzegowina</asp:ListItem>

                                            <asp:ListItem Value="BW">Botswana</asp:ListItem>

                                            <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>

                                            <asp:ListItem Value="BR">Brazil</asp:ListItem>

                                            <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>

                                            <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>

                                            <asp:ListItem Value="BG">Bulgaria</asp:ListItem>

                                            <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>

                                            <asp:ListItem Value="BI">Burundi</asp:ListItem>

                                            <asp:ListItem Value="KH">Cambodia</asp:ListItem>

                                            <asp:ListItem Value="CM">Cameroon</asp:ListItem>

                                            <asp:ListItem Value="CA">Canada</asp:ListItem>

                                            <asp:ListItem Value="CV">Cape Verde</asp:ListItem>

                                            <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>

                                            <asp:ListItem Value="CF">Central African Republic</asp:ListItem>

                                            <asp:ListItem Value="TD">Chad</asp:ListItem>

                                            <asp:ListItem Value="CL">Chile</asp:ListItem>

                                            <asp:ListItem Value="CN">China</asp:ListItem>

                                            <asp:ListItem Value="CX">Christmas Island</asp:ListItem>

                                            <asp:ListItem Value="CC">Cocos (Keeling) Islands</asp:ListItem>

                                            <asp:ListItem Value="CO">Colombia</asp:ListItem>

                                            <asp:ListItem Value="KM">Comoros</asp:ListItem>

                                            <asp:ListItem Value="CG">Congo</asp:ListItem>

                                            <asp:ListItem Value="CK">Cook Islands</asp:ListItem>

                                            <asp:ListItem Value="CR">Costa Rica</asp:ListItem>

                                            <asp:ListItem Value="CI">Cote D'Ivoire</asp:ListItem>

                                            <asp:ListItem Value="HR">Croatia (Local Name: Hrvatska)</asp:ListItem>

                                            <asp:ListItem Value="CU">Cuba</asp:ListItem>

                                            <asp:ListItem Value="CY">Cyprus</asp:ListItem>

                                            <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>

                                            <asp:ListItem Value="DK">Denmark</asp:ListItem>

                                            <asp:ListItem Value="DJ">Djibouti</asp:ListItem>

                                            <asp:ListItem Value="DM">Dominica</asp:ListItem>

                                            <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>

                                            <asp:ListItem Value="TP">East Timor</asp:ListItem>

                                            <asp:ListItem Value="EC">Ecuador</asp:ListItem>

                                            <asp:ListItem Value="EG">Egypt</asp:ListItem>

                                            <asp:ListItem Value="SV">El Salvador</asp:ListItem>

                                            <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>

                                            <asp:ListItem Value="ER">Eritrea</asp:ListItem>

                                            <asp:ListItem Value="EE">Estonia</asp:ListItem>

                                            <asp:ListItem Value="ET">Ethiopia</asp:ListItem>

                                            <asp:ListItem Value="FK">Falkland Islands (Malvinas)</asp:ListItem>

                                            <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>

                                            <asp:ListItem Value="FJ">Fiji</asp:ListItem>

                                            <asp:ListItem Value="FI">Finland</asp:ListItem>

                                            <asp:ListItem Value="FR">France</asp:ListItem>

                                            <asp:ListItem Value="GF">French Guiana</asp:ListItem>

                                            <asp:ListItem Value="PF">French Polynesia</asp:ListItem>

                                            <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>

                                            <asp:ListItem Value="GA">Gabon</asp:ListItem>

                                            <asp:ListItem Value="GM">Gambia</asp:ListItem>

                                            <asp:ListItem Value="GE">Georgia</asp:ListItem>

                                            <asp:ListItem Value="DE">Germany</asp:ListItem>

                                            <asp:ListItem Value="GH">Ghana</asp:ListItem>

                                            <asp:ListItem Value="GI">Gibraltar</asp:ListItem>

                                            <asp:ListItem Value="GR">Greece</asp:ListItem>

                                            <asp:ListItem Value="GL">Greenland</asp:ListItem>

                                            <asp:ListItem Value="GD">Grenada</asp:ListItem>

                                            <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>

                                            <asp:ListItem Value="GU">Guam</asp:ListItem>

                                            <asp:ListItem Value="GT">Guatemala</asp:ListItem>

                                            <asp:ListItem Value="GN">Guinea</asp:ListItem>

                                            <asp:ListItem Value="GW">Guinea-Bissau</asp:ListItem>

                                            <asp:ListItem Value="GY">Guyana</asp:ListItem>

                                            <asp:ListItem Value="HT">Haiti</asp:ListItem>

                                            <asp:ListItem Value="HM">Heard And Mc Donald Islands</asp:ListItem>

                                            <asp:ListItem Value="VA">Holy See (Vatican City State)</asp:ListItem>

                                            <asp:ListItem Value="HN">Honduras</asp:ListItem>

                                            <asp:ListItem Value="HK">Hong Kong</asp:ListItem>

                                            <asp:ListItem Value="HU">Hungary</asp:ListItem>

                                            <asp:ListItem Value="IS">Icel And</asp:ListItem>

                                            <asp:ListItem Value="IN">India</asp:ListItem>

                                            <asp:ListItem Value="ID">Indonesia</asp:ListItem>

                                            <asp:ListItem Value="IR">Iran (Islamic Republic Of)</asp:ListItem>

                                            <asp:ListItem Value="IQ">Iraq</asp:ListItem>

                                            <asp:ListItem Value="IE">Ireland</asp:ListItem>

                                            <asp:ListItem Value="IL">Israel</asp:ListItem>

                                            <asp:ListItem Value="IT">Italy</asp:ListItem>

                                            <asp:ListItem Value="JM">Jamaica</asp:ListItem>

                                            <asp:ListItem Value="JP">Japan</asp:ListItem>

                                            <asp:ListItem Value="JO">Jordan</asp:ListItem>

                                            <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>

                                            <asp:ListItem Value="KE">Kenya</asp:ListItem>

                                            <asp:ListItem Value="KI">Kiribati</asp:ListItem>

                                            <asp:ListItem Value="KP">Korea, Dem People'S Republic</asp:ListItem>

                                            <asp:ListItem Value="KR">Korea, Republic Of</asp:ListItem>

                                            <asp:ListItem Value="KW">Kuwait</asp:ListItem>

                                            <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>

                                            <asp:ListItem Value="LA">Lao People'S Dem Republic</asp:ListItem>

                                            <asp:ListItem Value="LV">Latvia</asp:ListItem>

                                            <asp:ListItem Value="LB">Lebanon</asp:ListItem>

                                            <asp:ListItem Value="LS">Lesotho</asp:ListItem>

                                            <asp:ListItem Value="LR">Liberia</asp:ListItem>

                                            <asp:ListItem Value="LY">Libyan Arab Jamahiriya</asp:ListItem>

                                            <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>

                                            <asp:ListItem Value="LT">Lithuania</asp:ListItem>

                                            <asp:ListItem Value="LU">Luxembourg</asp:ListItem>

                                            <asp:ListItem Value="MO">Macau</asp:ListItem>

                                            <asp:ListItem Value="MK">Macedonia</asp:ListItem>

                                            <asp:ListItem Value="MG">Madagascar</asp:ListItem>

                                            <asp:ListItem Value="MW">Malawi</asp:ListItem>

                                            <asp:ListItem Value="MY">Malaysia</asp:ListItem>

                                            <asp:ListItem Value="MV">Maldives</asp:ListItem>

                                            <asp:ListItem Value="ML">Mali</asp:ListItem>

                                            <asp:ListItem Value="MT">Malta</asp:ListItem>

                                            <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>

                                            <asp:ListItem Value="MQ">Martinique</asp:ListItem>

                                            <asp:ListItem Value="MR">Mauritania</asp:ListItem>

                                            <asp:ListItem Value="MU">Mauritius</asp:ListItem>

                                            <asp:ListItem Value="YT">Mayotte</asp:ListItem>

                                            <asp:ListItem Value="MX">Mexico</asp:ListItem>

                                            <asp:ListItem Value="FM">Micronesia, Federated States</asp:ListItem>

                                            <asp:ListItem Value="MD">Moldova, Republic Of</asp:ListItem>

                                            <asp:ListItem Value="MC">Monaco</asp:ListItem>

                                            <asp:ListItem Value="MN">Mongolia</asp:ListItem>

                                            <asp:ListItem Value="MS">Montserrat</asp:ListItem>

                                            <asp:ListItem Value="MA">Morocco</asp:ListItem>

                                            <asp:ListItem Value="MZ">Mozambique</asp:ListItem>

                                            <asp:ListItem Value="MM">Myanmar</asp:ListItem>

                                            <asp:ListItem Value="NA">Namibia</asp:ListItem>

                                            <asp:ListItem Value="NR">Nauru</asp:ListItem>

                                            <asp:ListItem Value="NP">Nepal</asp:ListItem>

                                            <asp:ListItem Value="NL">Netherlands</asp:ListItem>

                                            <asp:ListItem Value="AN">Netherlands Ant Illes</asp:ListItem>

                                            <asp:ListItem Value="NC">New Caledonia</asp:ListItem>

                                            <asp:ListItem Value="NZ">New Zealand</asp:ListItem>

                                            <asp:ListItem Value="NI">Nicaragua</asp:ListItem>

                                            <asp:ListItem Value="NE">Niger</asp:ListItem>

                                            <asp:ListItem Value="NG">Nigeria</asp:ListItem>

                                            <asp:ListItem Value="NU">Niue</asp:ListItem>

                                            <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>

                                            <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>

                                            <asp:ListItem Value="NO">Norway</asp:ListItem>

                                            <asp:ListItem Value="OM">Oman</asp:ListItem>

                                            <asp:ListItem Value="PK">Pakistan</asp:ListItem>

                                            <asp:ListItem Value="PW">Palau</asp:ListItem>

                                            <asp:ListItem Value="PA">Panama</asp:ListItem>

                                            <asp:ListItem Value="PG">Papua New Guinea</asp:ListItem>

                                            <asp:ListItem Value="PY">Paraguay</asp:ListItem>

                                            <asp:ListItem Value="PE">Peru</asp:ListItem>

                                            <asp:ListItem Value="PH">Philippines</asp:ListItem>

                                            <asp:ListItem Value="PN">Pitcairn</asp:ListItem>

                                            <asp:ListItem Value="PL">Poland</asp:ListItem>

                                            <asp:ListItem Value="PT">Portugal</asp:ListItem>

                                            <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>

                                            <asp:ListItem Value="QA">Qatar</asp:ListItem>

                                            <asp:ListItem Value="RE">Reunion</asp:ListItem>

                                            <asp:ListItem Value="RO">Romania</asp:ListItem>

                                            <asp:ListItem Value="RU">Russian Federation</asp:ListItem>

                                            <asp:ListItem Value="RW">Rwanda</asp:ListItem>

                                            <asp:ListItem Value="KN">Saint K Itts And Nevis</asp:ListItem>

                                            <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>

                                            <asp:ListItem Value="VC">Saint Vincent, The Grenadines</asp:ListItem>

                                            <asp:ListItem Value="WS">Samoa</asp:ListItem>

                                            <asp:ListItem Value="SM">San Marino</asp:ListItem>

                                            <asp:ListItem Value="ST">Sao Tome And Principe</asp:ListItem>

                                            <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>

                                            <asp:ListItem Value="SN">Senegal</asp:ListItem>

                                            <asp:ListItem Value="SC">Seychelles</asp:ListItem>

                                            <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>

                                            <asp:ListItem Value="SG">Singapore</asp:ListItem>

                                            <asp:ListItem Value="SK">Slovakia (Slovak Republic)</asp:ListItem>

                                            <asp:ListItem Value="SI">Slovenia</asp:ListItem>

                                            <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>

                                            <asp:ListItem Value="SO">Somalia</asp:ListItem>

                                            <asp:ListItem Value="ZA">South Africa</asp:ListItem>

                                            <asp:ListItem Value="GS">South Georgia , S Sandwich Is.</asp:ListItem>

                                            <asp:ListItem Value="ES">Spain</asp:ListItem>

                                            <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>

                                            <asp:ListItem Value="SH">St. Helena</asp:ListItem>

                                            <asp:ListItem Value="PM">St. Pierre And Miquelon</asp:ListItem>

                                            <asp:ListItem Value="SD">Sudan</asp:ListItem>

                                            <asp:ListItem Value="SR">Suriname</asp:ListItem>

                                            <asp:ListItem Value="SJ">Svalbard, Jan Mayen Islands</asp:ListItem>

                                            <asp:ListItem Value="SZ">Sw Aziland</asp:ListItem>

                                            <asp:ListItem Value="SE">Sweden</asp:ListItem>

                                            <asp:ListItem Value="CH">Switzerland</asp:ListItem>

                                            <asp:ListItem Value="SY">Syrian Arab Republic</asp:ListItem>

                                            <asp:ListItem Value="TW">Taiwan</asp:ListItem>

                                            <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>

                                            <asp:ListItem Value="TZ">Tanzania, United Republic Of</asp:ListItem>

                                            <asp:ListItem Value="TH">Thailand</asp:ListItem>

                                            <asp:ListItem Value="TG">Togo</asp:ListItem>

                                            <asp:ListItem Value="TK">Tokelau</asp:ListItem>

                                            <asp:ListItem Value="TO">Tonga</asp:ListItem>

                                            <asp:ListItem Value="TT">Trinidad And Tobago</asp:ListItem>

                                            <asp:ListItem Value="TN">Tunisia</asp:ListItem>

                                            <asp:ListItem Value="TR">Turkey</asp:ListItem>

                                            <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>

                                            <asp:ListItem Value="TC">Turks And Caicos Islands</asp:ListItem>

                                            <asp:ListItem Value="TV">Tuvalu</asp:ListItem>

                                            <asp:ListItem Value="UG">Uganda</asp:ListItem>

                                            <asp:ListItem Value="UA">Ukraine</asp:ListItem>

                                            <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>

                                            <asp:ListItem Value="GB">United Kingdom</asp:ListItem>

                                            <asp:ListItem Value="US">United States</asp:ListItem>

                                            <asp:ListItem Value="UM">United States Minor Is.</asp:ListItem>

                                            <asp:ListItem Value="UY">Uruguay</asp:ListItem>

                                            <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>

                                            <asp:ListItem Value="VU">Vanuatu</asp:ListItem>

                                            <asp:ListItem Value="VE">Venezuela</asp:ListItem>

                                            <asp:ListItem Value="VN">Viet Nam</asp:ListItem>

                                            <asp:ListItem Value="VG">Virgin Islands (British)</asp:ListItem>

                                            <asp:ListItem Value="VI">Virgin Islands (U.S.)</asp:ListItem>

                                            <asp:ListItem Value="WF">Wallis And Futuna Islands</asp:ListItem>

                                            <asp:ListItem Value="EH">Western Sahara</asp:ListItem>

                                            <asp:ListItem Value="YE">Yemen</asp:ListItem>

                                            <asp:ListItem Value="YU">Yugoslavia</asp:ListItem>

                                            <asp:ListItem Value="ZR">Zaire</asp:ListItem>

                                            <asp:ListItem Value="ZM">Zambia</asp:ListItem>

                                            <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="NationalityVali" runat="server" ErrorMessage="Please select Your Nationality" ControlToValidate="ddlNationality" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Passport/NRIC No:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxNRIC" class="form-control" Width="200" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNRIC" runat="server" Text="Password/NRIC No. already exist!" Display="Dynamic" Visible="false"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbxNRIC" ErrorMessage="Passport/NRIC No cannot be blank"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Marital Status:*</th>
                                    <td class="auto-style1">
                                        <asp:RadioButton ID="RadioMSSingle" GroupName="RadioMarital" runat="server" Text="&nbsp;Single" Checked="True" />
                                        &nbsp;&nbsp;
                                         <asp:RadioButton ID="RadioMSMarried" GroupName="RadioMarital" runat="server" Text="&nbsp;Married" />&nbsp;&nbsp;
                                        <asp:RadioButton ID="RadioMSWidowed" GroupName="RadioMarital" runat="server" Text="&nbsp;Widowed" />&nbsp;&nbsp;
                                        <asp:RadioButton ID="RadioMSDivorced" GroupName="RadioMarital" runat="server" Text="&nbsp;Divorced" />
                                    </td>

                                </tr>
                                <tr>
                                    <th>Height:</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxHeight" class="form-control" placeholder="height in cm" Width="200" TextMode="Number" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>Weight:</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxWeight" class="form-control" placeholder="weight in kg" Width="200" TextMode="Number" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>Blood Type:*</th>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlBloodType" class="form-control" Width="130" runat="server">
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
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="BloodTypeVali" runat="server" ErrorMessage="Please select your blood type" ControlToValidate="ddlBloodType" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Email:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxEmail" class="form-control" Width="250" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text="Email address already exist!" Display="Dynamic"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your Email" ControlToValidate="tbxEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Username:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxUsername" class="form-control" Width="250" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                         <asp:Label ID="lblUsername" runat="server" Text="Username address already exist!" Display="Dynamic"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your Username" ControlToValidate="tbxUsername" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Password:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxPassword" class="form-control" Width="150" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter your Password" ControlToValidate="tbxPassword" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Address:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxAddress" class="form-control" Width="250" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter your Address" ControlToValidate="tbxAddress" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th>ZipCode:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxZipcode" class="form-control" Width="180" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter your Zipcode" ControlToValidate="tbxZipcode" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Phone Number:*</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="tbxPhone" class="form-control" Width="180" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your Phone number" ControlToValidate="tbxPhone" ></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:CheckBox ID="checkEmergencyContact" runat="server" Text="&nbsp;Yes, I want to add additional emergency contact person for me."/>   
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:CheckBox ID="CheckTerm" runat="server" Text="&nbsp;I agree to the" />   <asp:LinkButton ID="linkTerm" runat="server">Terms & Conditions</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Label ID="cbTermVali" runat="server" Text="Please accept our Terms and Conditions " Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>&nbsp;</th>
                                    <td class="auto-style1">
                                        <asp:Label ID="lblOutput" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                            <!-- end id-form  -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

