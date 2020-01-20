using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestBlood : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		//sending request if the amount is greater than 1
		if (Convert.ToInt32(tbxAmount.Text) > 0)
		{
			Establishment currentEstab = (Establishment)Session["establishment"];
			EstablishmentBPRequest currentRequestBP = new EstablishmentBPRequest();
			currentRequestBP.BloodGroup = ddlBloodType.SelectedValue;
			currentRequestBP.Units = Convert.ToInt32(tbxAmount.Text);
			currentRequestBP.MatchedUnits = 0;
			currentRequestBP.Type = ddlRequestType.SelectedValue;
			currentRequestBP.Establishment = currentEstab;
			currentRequestBP.Status = "pending";
			currentRequestBP.RequestDate = DateTime.Today;
			int num = EstablishmentBPRequestDB.insertEstablishmentRequest(currentRequestBP);
			if (num != 1)
			{
				lblOutput.Text = "Cannot";
			}
			else
			{
				List<EstablishmentBPRequest> establishmentBPRequest = EstablishmentBPRequestDB.getAllEstablishmentRequests();
				//get inserted request
				string x = establishmentBPRequest[0].ID;
				int tempId = Convert.ToInt32(x.Substring(4, x.Length - 4));
				foreach (EstablishmentBPRequest tempReq in establishmentBPRequest)
				{
					int t = Convert.ToInt32(tempReq.ID.Substring(4, tempReq.ID.Length - 4));

					if (tempId <= t && tempReq.Establishment.ID == currentEstab.ID)
					{
						tempId = Convert.ToInt32(tempReq.ID.Substring(4, tempReq.ID.Length - 4));
					}
				}
				EstablishmentBPRequest request = EstablishmentBPRequestDB.getRequestByID("bper" + Convert.ToString(tempId));
				lblOutput.Text = "Your request ID is bper" + tempId;
				List<Establishment> establishments = EstablishmentDB.getAllEstablishments();
				foreach (Establishment est in establishments)
				{
					EstabEstabMatch newMatch = new EstabEstabMatch();
					if ((est.Type == "Hospital" || est.Type == "Blood Bank") && currentEstab.ID != est.ID)
					{
						int d = getDistance(est.Address, currentEstab.Address);
						if (d < 3600)
						{
							newMatch.Request = request;
							newMatch.Match = est;
							newMatch.Distance = d;
							newMatch.Status = "pending";
							EstabEstabMatchDB.insertMatch(newMatch);

						}
					}
				}
				List<Users> users = UsersDB.getallUsers();
				List<LastDonationDate> allDates = LastDonationDateDB.getAllLastDonations();

				foreach (Users tusr in users)
				{
					EstabUserMatch newMatch = new EstabUserMatch();
					string userGroup = tusr.BloodType;
					string requestGroup = request.BloodGroup;
					bool f = false;
					//check blood to match with other user
					if (requestGroup == "AB+")
						f = true;
					else if (requestGroup == "AB-" && (userGroup == "O-" || userGroup == "B-" || userGroup == "A-" || userGroup == "AB-"))
						f = true;
					else if (requestGroup == "A+" && (userGroup == "O-" || userGroup == "O+" || userGroup == "A-" || userGroup == "A+"))
						f = true;
					else if (requestGroup == "A-" && (userGroup == "O-" || userGroup == "A-"))
						f = true;
					else if (requestGroup == "B+" && (userGroup == "O-" || userGroup == "O+" || userGroup == "B-" || userGroup == "B+"))
						f = true;
					else if (requestGroup == "B-" && (userGroup == "O-" || userGroup == "B-"))
						f = true;
					else if (requestGroup == "O+" && (userGroup == "O-" || userGroup == "O+"))
						f = true;
					else if (requestGroup == "O-" && (userGroup == "O-"))
						f = true;

					//if match found check his medical status and status
					if (f == true && tusr.medicalStatus.ToLower() == "can donate" && tusr.Status == "Allow")
					{
						foreach (LastDonationDate d in allDates)
						{
							if (d.User.userId == tusr.userId)
							{
								if ((d.LastDonation < System.DateTime.Now.AddDays(-90) && d.Type == "blood") || (d.LastDonation < System.DateTime.Now.AddDays(-14) && d.Type == "platelet") && d.Status == "Not in transaction")
								{
									int d1 = getDistance(Convert.ToString(tusr.latitude) + "," + Convert.ToString(tusr.longtitude), currentEstab.Address);
									if (d1 < 3600)
									{
										newMatch.Match = tusr;
										newMatch.Request = request;
										newMatch.Status = "pending";
										newMatch.Distance = d1;
										EstabUserMatchDB.insertMatch(newMatch);
									}
								}
							}
						}
					}
				}

				tbxAmount.Text = "";
				ddlBloodType.SelectedIndex = 0;
				ddlRequestType.SelectedIndex = 0;
				string MyAccountUrl = "RequestBlood.aspx";
				Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=4;url={0}> ", MyAccountUrl)));
			}
		}
		else
		{
			lblOutput.Text = "Blood amount cannot be 0 or less than that";
			return;
		}
		
	}

	public int getDistance(string origin, string destination)
	{
		System.Threading.Thread.Sleep(1000);
		int distance = 0;
		//string from = origin.Text;
		//string to = destination.Text;

		string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key= /*ENTER THE KEY HERE*/ ";
		//replact # from address
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
