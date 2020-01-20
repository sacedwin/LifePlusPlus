using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddDeceasedDonor : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		//check the medical condition of donor
		DeceasedDonor ao = new DeceasedDonor();
		ao.Bloodgroup = ddlBloodType.SelectedValue;
		ao.DOB = Convert.ToDateTime(tbxDate.Text);
		ao.Establishment = (Establishment)Session["establishment"];
		ao.Donorheight = Convert.ToInt32(tbxHeight.Text);
		ao.Donorweight = Convert.ToInt32(tbxWeight.Text);
		ao.Deathdate = Convert.ToDateTime(tbxDeath.Text);
		ao.Organtype = rbtnlstOrganType.SelectedValue;
		ao.Comments = tbxComments.Text;
		ao.Refnumber = tbxReference.Text;
		ao.Status = "not allotted";
		//if the user is obese he/she cannot donate
		if ((ao.Donorweight * 10000) / (ao.Donorheight * ao.Donorheight) > 30)
		{
			lblOutput.Text = "This donor is incapable of donations";
			return;
		}
		else
		{
			DeceasedDonorDB.insertDeceasedDonor(ao);

			Establishment currentEstab = (Establishment)Session["establishment"];
			string address = currentEstab.Address;
			DeceasedDonor tDonor;
			//donor id from database
			List<DeceasedDonor> allDeadDonors = DeceasedDonorDB.getAllDeceasedDonors();
			String x = allDeadDonors[0].ID;
			int tempId = Convert.ToInt32(x.Substring(5, x.Length - 5));
			foreach (DeceasedDonor dd in allDeadDonors)
			{
				if (tempId < Convert.ToInt32(dd.ID.Substring(5, dd.ID.Length - 5)) && dd.Establishment.ID == currentEstab.ID)
				{
					tempId = Convert.ToInt32(dd.ID.Substring(5, dd.ID.Length - 5));
				}
			}
			tDonor = DeceasedDonorDB.getDonorByID("dcdnr" + Convert.ToString(tempId));
			//end of getting last one

			List<OrganRecipient> allReceivers = OrganRecipientDB.getAllRecipients();
			//List<OrganRecipient> matchedBloodReceivers = new List<OrganRecipient>();
			bool f = false;
			//check the donor blood type and receiver blood type for organ donation
			foreach (OrganRecipient r in allReceivers)
			{
				int y = 0;
				String bt1 = ao.Bloodgroup;
				String bt2 = r.Bloodgroup;
				if ((bt1 == "A+" || bt1 == "A-") && (bt2 == "A+" || bt2 == "A-" || bt2 == "AB+" || bt2 == "AB-"))
					y = 1;
				else if ((bt1 == "B+" || bt1 == "B-") && (bt2 == "B+" || bt2 == "B-" || bt2 == "AB+" || bt2 == "AB-"))
					y = 1;
				else if ((bt1 == "AB+" || bt1 == "AB-") && (bt2 == "AB+" || bt2 == "AB-"))
					y = 1;
				else if ((bt1 == "O+" || bt1 == "O-") && (bt2 == "A+" || bt2 == "A-" || bt2 == "AB+" || bt2 == "AB-" || bt2 == "B+" || bt2 == "B-" || bt2 == "O+" || bt2 == "O-"))
					y = 1;
				if (y == 1 && ao.Organtype == r.Organrequired && r.Status == "waiting")
				{
					string matchAddress = r.Establishment.Address;
					float d = getDistance(address, matchAddress);
					int score = 0;
					int d1 = Convert.ToInt32(d);

					d = d / 3600;
					if ((r.Organrequired == "Kidney" && d < 32) || (r.Organrequired == "Liver" && d < 8))
					{
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

						double days = (DateTime.Today - r.Addedon).TotalDays;

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

						DeceasedOrganMatching match = new DeceasedOrganMatching();
						////donor id from database
						//List<DeceasedDonor> allDeadDonors = DeceasedDonorDB.getAllDeceasedDonors();
						//String x = allDeadDonors[0].ID;
						//int tempId = Convert.ToInt32(x.Substring(5, x.Length - 5));
						//foreach(DeceasedDonor dd in allDeadDonors)
						//{
						//    if (tempId < Convert.ToInt32(dd.ID.Substring(5, dd.ID.Length - 5)) && dd.Establishment == currentEstab)
						//    {
						//        tempId = Convert.ToInt32(dd.ID.Substring(5, dd.ID.Length - 5));
						//    }
						//}
						//tDonor = DeceasedDonorDB.getDonorByID("dcdnr" + Convert.ToString(tempId));
						////end of getting last one

						match.DeceasedDonor = tDonor;
						match.Recipient = r;
						match.MatchScore = score;
						match.Comments = "NIL";
						match.Status = "pending";
						match.Distance = d1;
						DeceasedOrganMatchingDB.insertMatch(match);
						f = true;
					}
				}
			}
			if (f == true)
			{
				List<DeceasedOrganMatching> deadMatches = DeceasedOrganMatchingDB.getAllMatches();
				List<DeceasedOrganMatching> deadMatchCurr = new List<DeceasedOrganMatching>();
				foreach (DeceasedOrganMatching DOM1 in deadMatches)
				{
					if (DOM1.DeceasedDonor.ID == tDonor.ID)
					{
						deadMatchCurr.Add(DOM1);
					}
				}
				DeceasedOrganMatching tempDOM = deadMatchCurr[0];
				foreach (DeceasedOrganMatching DOM in deadMatchCurr)
				{
					if (DOM.MatchScore > tempDOM.MatchScore)
						tempDOM = DOM;
				}
				tempDOM.Status = "current match";
				DeceasedOrganMatchingDB.updateMatch(tempDOM);
				OrganRecipient ort = OrganRecipientDB.getRecipientByID(tempDOM.Recipient.ID);
				ort.Status = "allotted";
				OrganRecipientDB.updateOrganRecipient(ort);
				tempDOM.DeceasedDonor.Status = "allotted";
				DeceasedDonorDB.updateDeceasedDonor(tempDOM.DeceasedDonor);
			}
			else
			{
				tDonor.Status = "cancelled";
				DeceasedDonorDB.updateDeceasedDonor(tDonor);
			}
			lblOutput.Text = "Donor successfully added!";
			tbxComments.Text = "";
			tbxDate.Text = "";
			tbxDeath.Text = "";
			tbxHeight.Text = "";
			tbxReference.Text = "";
			tbxWeight.Text = "";
			ddlBloodType.SelectedIndex = 0;
			string MyAccountUrl = "DeceasedDonors.aspx";
			Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));

		}

	}
	public int getDistance(string origin, string destination)
	{
		System.Threading.Thread.Sleep(1000);
		int distance = 0;
		//string from = origin.Text;
		//string to = destination.Text;

		string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key= /*ENTER THE KEY HERE*/ ";

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
