using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonateOrgan : System.Web.UI.Page
{
	int h = 0, w = 0, ec = 0;
	string comment;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			if (Session["email"] == null)
			{
				Server.Transfer("CommonLogin.aspx");
			}
			else
			{
				string email = Session["email"].ToString();
				Users nu = UsersDB.getUserbyEmail(email);
				if (nu.weight == 0)
				{
					PanelUpdate.Visible = true;
					PanelWeight.Visible = true;
					PanelRegisterDonor.Visible = false;
					w = 0;

				}
				else
				{
					w = 1;
				}

				if (nu.height == 0)
				{
					PanelUpdate.Visible = true;
					PanelHeight.Visible = true;
					PanelRegisterDonor.Visible = false;
					h = 0;

				}
				else
				{
					h = 1;
				}

				if (nu.emergencyname == "null")
				{
					PanelUpdate.Visible = true;
					PanelEmergency.Visible = true;
					PanelRegisterDonor.Visible = false;
					ec = 0;

				}
				else
				{
					ec = 1;
				}

				if (ec == 1 && h == 1 && w == 1)
				{
					Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
					List<LiveDonor> ldlist = LiveDonorDB.getallLiveDonor();

					foreach (LiveDonor ld in ldlist)
					{
						if (ld.userid.userId == u.userId &&( ld.status == "not allotted" || ld.status == "allotted"))
						{
							lblHeading.Text = "Donation History";
							PanelRegisterDonor.Visible = false;
							Label1.Visible = true;
							Label1.Text = "Well Done! You are already part of live organ donation. You doesn't need sign up again.";
							break;
						}
						else
						{
							lblHeading.Text = "Please fill this form to register as a organ donor.";
							PanelRegisterDonor.Visible = true;
							Label1.Visible = false;
							if ((u.Weight * 1000) / (u.height * u.height) > 30)
							{

								PanelRegisterDonor.Visible = false;
								lblHeading.Text = "Donate Organ";
								Label1.Visible = true;
								Label1.Text = "Sorry! You're health condition doesn't allow you to donate organ.";
							}
						}
					}

				}


			}



		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		string email = Session["email"].ToString();
		Users nu = UsersDB.getUserbyEmail(email);
		if (PanelWeight.Visible == true)
		{
			if (tbxWeight.Text == "")
			{
				lblWeight.Visible = true;
				lblWeight.Text = "Please enter your weight";
				return;
			}
			else
			{
				nu.weight = Convert.ToInt32(tbxWeight.Text);
				lblWeight.Visible = false;

			}
		}

		if (PanelHeight.Visible == true)
		{
			if (tbxHeight.Text == "")
			{
				lblHeight.Visible = true;
				lblHeight.Text = "Please enter your height";
				return;
			}
			else
			{
				nu.height = Convert.ToInt32(tbxHeight.Text);
				lblHeight.Visible = false;

			}
		}

		if (PanelEmergency.Visible == true)
		{
			if (ddlRelation.SelectedIndex == 0)
			{
				lblRelation.Text = "Please select the relationship";
				return;
			}
			else
			{
				nu.emergencyname = tbxEName.Text;
				nu.emergencyphone = Convert.ToInt32(tbxEPhone.Text);
				nu.emergencyrelationship = ddlRelation.SelectedValue;

			}
		}


		int num = UsersDB.updateUser(nu);
		if (num != 1)
			lblOutput.Text = "Update Fail! Please try again.";
		else
		{
			PanelUpdate.Visible = false;
			PanelRegisterDonor.Visible = true;
			return;
		}



	}



	protected void btnDSubmit_Click(object sender, EventArgs e)
	{
		if (Convert.ToInt32(tbxDPhone.Text) <= 0)
		{
			lblDOutput.Text = "Phone number is in incorrect format";
			return;
		}
		else
		{
			string ogtype;
			string Dname = tbxDoctor.Text;
			int Dphone = Convert.ToInt32(tbxDPhone.Text);
			string Demail = TbxDEmail.Text;
			string Daddress = tbxDAddress.Text;
			if (ddlOrgan.SelectedIndex == 0)
			{
				lblOrgan.Visible = true;
				return;
			}
			else
				ogtype = ddlOrgan.SelectedValue;
			if (tbxComment.Text == "")
				comment = "-";
			else
				comment = tbxComment.Text;
			Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
			//add code for finding match here
			LiveDonor ld = new LiveDonor(u, ogtype, comment, "not allotted", Dname, Dphone, Daddress, Demail);
			int num = LiveDonorDB.insertLiveDonor(ld);
			if (num != -1)
			{
				LiveDonor tLiveDonor;
				List<LiveDonor> tDonorList = LiveDonorDB.getLiveDonorbyuserID(u.userId);
				tLiveDonor = tDonorList[0];
				foreach (LiveDonor tld in tDonorList)
				{
					if (tld.status == "not allotted")
						tLiveDonor = tld;
				}

				List<OrganRecipient> allRecievers = OrganRecipientDB.getAllRecipients();
				bool f = false;
				foreach (OrganRecipient r in allRecievers)
				{
					int y = 0;
					String bt1 = u.bloodtype;
					String bt2 = r.Bloodgroup;
					if ((bt1 == "A+" || bt1 == "A-") && (bt2 == "A+" || bt2 == "A-" || bt2 == "AB+" || bt2 == "AB-"))
						y = 1;
					else if ((bt1 == "B+" || bt1 == "B-") && (bt2 == "B+" || bt2 == "B-" || bt2 == "AB+" || bt2 == "AB-"))
						y = 1;
					else if ((bt1 == "AB+" || bt1 == "AB-") && (bt2 == "AB+" || bt2 == "AB-"))
						y = 1;
					else if ((bt1 == "O+" || bt1 == "O-") && (bt2 == "A+" || bt2 == "A-" || bt2 == "AB+" || bt2 == "AB-" || bt2 == "B+" || bt2 == "B-" || bt2 == "O+" || bt2 == "O-"))
						y = 1;

					if (y == 1 && tLiveDonor.OrganType == r.Organrequired && r.Status == "waiting")
					{
						float d = getDistance(u.address, r.Establishment.Address);
						int score = 0;
						int d1 = Convert.ToInt32(d);
						d = d / 3600;
						int wTimeScore = 0, distanceScore = 0;
						if (d < 5)
							distanceScore = 5;
						else if (d < 15)
							distanceScore = 4;
						else if (d < 25)
							distanceScore = 3;
						else if (d < 35)
							distanceScore = 2;
						else if (d < 45)
							distanceScore = 1;
						else
							distanceScore = 0;

						double days = (DateTime.Today- r.Addedon).TotalDays;

						if (days < 180)
							wTimeScore = 1;
						else if (days < 365)
							wTimeScore = 2;
						else if (days < 1095)
							wTimeScore = 3;
						else if (days < 1825)
							wTimeScore = 4;
						else
							wTimeScore = 5;

						score = r.Urgency * 3 + distanceScore + wTimeScore;

						LiveOrganMatching match = new LiveOrganMatching();
						match.LiveDonor = tLiveDonor;
						match.MatchScore = score;
						match.Recipient = r;
						match.Status = "pending";
						match.Comments = "NIL";
						match.Distance = d1;
						LiveOrganMatchingDB.insertMatch(match);
						f = true;

					}
				}
				if (f == true)
				{
					List<LiveOrganMatching> liveMatches = LiveOrganMatchingDB.getAllMatches();
					List<LiveOrganMatching> liveMatchesCurr = new List<LiveOrganMatching>();
					foreach (LiveOrganMatching LOM1 in liveMatches)
					{
						if (LOM1.LiveDonor.LdonorID == tLiveDonor.LdonorID)
						{
							liveMatchesCurr.Add(LOM1);
						}
					}
					LiveOrganMatching tempLOM = liveMatchesCurr[0];
					foreach (LiveOrganMatching LOM in liveMatchesCurr)
					{
						if (LOM.MatchScore > tempLOM.MatchScore)
							tempLOM = LOM;
					}
					tempLOM.Status = "current match";
					LiveOrganMatchingDB.updateMatch(tempLOM);
					tLiveDonor.status = "allotted";
					LiveDonorDB.updateLiveDonor(tLiveDonor);
					tempLOM.Recipient.Status = "allotted";
					OrganRecipientDB.updateOrganRecipient(tempLOM.Recipient);
				}
				PanelRegisterDonor.Visible = false;
				Server.Transfer("HistoryOrgan.aspx");
			}
			else
			{
				PanelRegisterDonor.Visible = true;
				lblDOutput.Text = "Registration Fail! Please Try Again.";
				return;
			}
		}

	}


	public int getDistance(string origin, string destination)
	{
		System.Threading.Thread.Sleep(1000);
		int distance = 0;
		//string from = origin.Text;
		//string to = destination.Text;

		string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key=AIzaSyCN-DotpprhnjmZrnqpX1Sa-gZK8freYkc";

		string requesturl = url.Replace('#', ' ');
		int content = fileGetContents(requesturl);
		// JsonObject o = JsonObject.Parse(content);
		//RootObject r = JsonConvert.DeserializeObject<RootObject>(o);
		try
		{
			distance = content;
			//JArray array = o.GetValue("rows");
			//distance=r.rows.ElementAt(0).elements.ElementAt(0).duration.value;
			//distance = (int)o["rows.elements.duration.value"];
			// distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
			return distance;
		}
		catch
		{
			return distance;
		}

		//return distance;
		//ResultingDistance.Text = distance;
	}

	public class Distance
	{
		public string text { get; set; }
		public int value { get; set; }
	}

	public class Duration
	{
		public string text { get; set; }
		public int value { get; set; }
	}

	public class Element
	{
		public Distance distance { get; set; }
		public Duration duration { get; set; }
		public string status { get; set; }
	}

	public class Row
	{
		public List<Element> elements { get; set; }
	}

	public class RootObject
	{
		public List<string> destination_addresses { get; set; }
		public List<string> origin_addresses { get; set; }
		public List<Row> rows { get; set; }
		public string status { get; set; }
	}

	protected int fileGetContents(string fileName)
	{
		string sContents = string.Empty;
		string me = string.Empty;
		int distance = 0;
		try
		{
			// if (fileName.ToLower().IndexOf("http:") > -1)
			{
				System.Net.WebClient wc = new System.Net.WebClient();
				byte[] response = wc.DownloadData(fileName);
				sContents = System.Text.Encoding.ASCII.GetString(response);
				RootObject r = JsonConvert.DeserializeObject<RootObject>(sContents);
				distance = r.rows.ElementAt(0).elements.ElementAt(0).duration.value;

			}
			//else
			//{
			//  System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
			//sContents = sr.ReadToEnd();
			//sr.Close();
			//}
		}
		catch { sContents = "unable to connect to server "; }
		return distance;
	}

}