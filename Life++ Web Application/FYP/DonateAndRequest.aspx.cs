using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonateAndRequest : System.Web.UI.Page
{
	List<BloodPlateletRequestUser> bplist = new List<BloodPlateletRequestUser>();
	List<BloodPlateletRequestUser> pendinglist;
	List<BplTransactionUserToEstab> estabTransactions;
	List<BplTransactionUserToUser> userTransactions;
	List<BplTransactionUserToEstab> allestabTransactions;
	List<BplTransactionUserToUser> alluserTransactions;

	Users u = new Users();

	protected void Page_Load(object sender, EventArgs e)
	{

		if (Session["email"] == null)
		{
			Server.Transfer("CommonLogin.aspx");
		}
		else
		{
			List<Establishment> elist = EstablishmentDB.getAllEstablishments();
			foreach (Establishment es in elist)
			{
				if (es.Type == "Hospital" || es.Type == "Blood Bank")
				{
					ddlEstablish.Items.Add(es.Name);
				}
			}

			ddlEstablish.Items.Insert(0, "--Select--");
			lblAmount.Visible = false;
			u = UsersDB.getUserbyEmail(Session["email"].ToString());
			pendinglist = new List<BloodPlateletRequestUser>();
			bplist = BloodPlateletRequestUserDB.getUserBloodRequestsbyUserID(u.userId);
			foreach (BloodPlateletRequestUser b in bplist)
			{
				if (b.Status == "pending")
				{
					pendinglist.Add(b);
				}

			}

			if (pendinglist.Count == 0)
			{
				lblSorry.Visible = true;
				Panel1.Visible = false;
				Panel2.Visible = false;
			}
			else
			{
				lblSorry.Visible = false;
				Panel1.Visible = true;
				gvUser.DataSource = pendinglist;
				gvUser.DataBind();
				Panel2.Visible = false;
			}
			lblee.Visible = false;
			lbleeh.Visible = false;
			lbleu.Visible = false;
			lbleuh.Visible = false;
		}

	}

	protected void btnRequest_Click(object sender, EventArgs e)
	{
		string groups, estname, type;
		int unit;
		if (RadioBlood.Checked)
			groups = "blood";
		else
			groups = "platelet";
		if (tbxAmount.Text == "")
		{
			lblAmount.Visible = true;
			return;
		}
		else
		{
			lblAmount.Visible = false;
			unit = Convert.ToInt32(tbxAmount.Text);
		}
		estname = ddlEstablish.SelectedItem.Text;
		Establishment es = EstablishmentDB.getEstablishmentByName(estname);
		Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
		type = ddlBloodType.SelectedValue;
			BloodPlateletRequestUser b = new BloodPlateletRequestUser(unit, 0, es, u, type, "pending", groups, DateTime.Now);
			int num = BloodPlateletRequestUserDB.insertBloodRequestByUser(b);
			if (num != 1)
			{
				lblOutput.Text = "Cannot Request Blood!";
				return;
			}
			else
			{
				lblOutput.Text = "Request Successful!";


				List<BloodPlateletRequestUser> bloodPlateletRequestUser = BloodPlateletRequestUserDB.getAllUserBloodRequests();

				string x = bloodPlateletRequestUser[0].bplUserRequestID;
				int tempID = Convert.ToInt32(x.Substring(4, x.Length - 4));
				foreach (BloodPlateletRequestUser bpr in bloodPlateletRequestUser)
				{
					if (tempID < Convert.ToInt32(bpr.bplUserRequestID.Substring(4, bpr.bplUserRequestID.Length - 4)) && bpr.requestorID.UserId == u.UserId)
					{
						tempID = Convert.ToInt32(bpr.bplUserRequestID.Substring(4, bpr.bplUserRequestID.Length - 4));
					}
				}

				BloodPlateletRequestUser request = BloodPlateletRequestUserDB.getUserBloodRequestsbyID("bpur" + Convert.ToString(tempID));
				List<Establishment> establishments = EstablishmentDB.getAllEstablishments();
				foreach (Establishment est in establishments)
				{
					BPMatchUserToEstab newMatch = new BPMatchUserToEstab();
					if ((est.Type == "Hospital" || est.Type == "Blood Bank") && request.Establishment.ID != est.ID)
					{
						int d = getDistance(est.Address, request.Establishment.Address);
						if (d < 3600 && d > 0)
						{
							newMatch.bpRequestID = request;
							newMatch.matchID = est;
							newMatch.distance = d;
							newMatch.status = "pending";
							int nums = BPMatchUserToEstabDB.insertbp(newMatch);
							if (nums != 1)
							{
								lblOutput.Text = "Cannot Request Blood!";
								return;
							}
							else
							{
								lblOutput.Text = "Request Successful!";
							}
						}
					}

				}
				List<Users> users = UsersDB.getallUsers();
				List<LastDonationDate> lastDate = LastDonationDateDB.getAllLastDonations();
				foreach (Users usr in users)
				{
					BPMatchUserToUser newMatchU = new BPMatchUserToUser();

					string userGroup = usr.BloodType;
					string requestGroup = request.Type;
					bool f = false;
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
					if ((request.requestorID.UserId != usr.UserId) && (f == true) && (usr.MedicalStatus.ToLower() == "can donate") && (usr.status == "Allow"))
					{
						foreach (LastDonationDate lddate in lastDate)
						{
							if ((lddate.User.UserId == usr.UserId))
							{
								if ((lddate.LastDonation < System.DateTime.Now.AddDays(-90) && lddate.Type == "blood") || (lddate.LastDonation < System.DateTime.Now.AddDays(-14) && lddate.Type == "platelet") && lddate.Status == "Not in transaction")
								{
									string origin = usr.Latitude + "," + usr.Longtitude;
									int d = getDistance(origin, request.Establishment.Address);
									if (d < 3600)
									{
										newMatchU.bplUsrRequestID = request;
										newMatchU.matchID = usr;
										newMatchU.distance = d;
										newMatchU.status = "pending";
										BPMatchUserToUserDB.insertbpusertoUser(newMatchU);
									}
								}
							}
						}
					}
				}
				string DRUrl = "DonateAndRequest.aspx";
				Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=3;url={0}> ", DRUrl)));
			}
		//}
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

	protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
	{
		Panel2.Visible = true;
		Panelusertrans.Visible = true;
		lblee.Visible = false;
		pendinglist = new List<BloodPlateletRequestUser>();
		u = UsersDB.getUserbyEmail(Session["email"].ToString());
		bplist = BloodPlateletRequestUserDB.getUserBloodRequestsbyUserID(u.userId);
		foreach (BloodPlateletRequestUser b in bplist)
		{
			if (b.Status == "pending")
			{
				pendinglist.Add(b);
			}

		}
		int num = pendinglist.Count;
		lbleu.Visible = false;
		BloodPlateletRequestUser bpr = pendinglist[gvUser.PageSize * gvUser.PageIndex + gvUser.SelectedIndex];
		lblAmountshow.Text = bpr.Units.ToString();
		lblBT.Text = bpr.Type;
		lblEst.Text = bpr.Establishment.Name;
		DateTime dt = System.DateTime.Parse(bpr.Time.ToString());
		lblRD.Text = string.Format("{0:dd/MM/yyyy}", dt);
		lblRID.Text = bpr.bplUserRequestID;
		lblDT.Text = bpr.bloodOrPlatelet;
		List<BplTransactionUserToEstab> allestabTransactions = new List<BplTransactionUserToEstab>();
		List<BplTransactionUserToUser> alluserTransactions = new List<BplTransactionUserToUser>();
		estabTransactions = BplTransactionUserToEstabDB.getAllbpTransactionUserToEsta();
		userTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		int notrans = 0;
		//check the current user transaction which are accept
		foreach (BplTransactionUserToUser btu in userTransactions)
		{
			if (btu.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == bpr.bplUserRequestID && btu.status == "accepted")
			{
				alluserTransactions.Add(btu);
			}

		}
		foreach (BplTransactionUserToUser btu in userTransactions)
		{
			if (btu.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == bpr.bplUserRequestID && btu.status == "Complete")
			{
				notrans = 1;
				break;
			}
		}

		foreach (BplTransactionUserToEstab m in estabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == bpr.bplUserRequestID && m.status == "accepted")
			{
				allestabTransactions.Add(m);
			}

		}
		foreach (BplTransactionUserToEstab m in estabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == bpr.bplUserRequestID && m.status == "Complete")
			{
				notrans = 2;
				break;
			}
		}
		if (notrans == 1 || notrans == 2)
		{
			btnCancel.Visible = false;
		}
		else
		{
			btnCancel.Visible = true;
		}
		if (alluserTransactions.Count == 0)
		{
			lbleu.Visible = true;
			Panelusertrans.Visible = false;
			lbleu.Visible = true;
			lbleuh.Visible = true;
		}
		else
		{
			Panelusertrans.Visible = true;
			lbleu.Visible = false;
			lbleuh.Visible = true;
			GridView1.DataSource = alluserTransactions;
			GridView1.DataBind();
		}
		if (allestabTransactions.Count == 0)
		{
			lblee.Visible = true;
			lbleeh.Visible = true;
			Panelesttrans.Visible = false;
		}
		else
		{
			Panelesttrans.Visible = true;
			lblee.Visible = false;
			lbleeh.Visible = true;
			GridView2.DataSource = allestabTransactions;
			GridView2.DataBind();
		}



	}

	protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvUser.PageIndex = e.NewPageIndex;
		gvUser.DataSource = pendinglist;
		gvUser.DataBind();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		BloodPlateletRequestUser bpru = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(lblRID.Text);
		bpru.Status = "cancelled";
		int num = BloodPlateletRequestUserDB.updateBloodPlateles(bpru);
		if (num != 1)
		{
			lblOutput.Text = "Cannot Cancel Request Right Now!";
			return;
		}
		else
		{
			lblOutput.Text = "Cancel Successful! u can check history in the following table";
			//if donation cancel change the status of matching also
			List<BPMatchUserToUser> bpmuulist = BPMatchUserToUserDB.getAllUserBloodRequestsbyUserID(bpru.bplUserRequestID);
			foreach (BPMatchUserToUser b in bpmuulist)
			{
				b.status = "declined";
				BPMatchUserToUserDB.updateMatchUserToUser(b);
			}
			List<BPMatchUserToEstab> bpmuelist = BPMatchUserToEstabDB.getAllBloodRequestsMatchbyUserID(bpru.bplUserRequestID);
			foreach (BPMatchUserToEstab be in bpmuelist)
			{
				be.status = "declined";
				BPMatchUserToEstabDB.updateBPMatchUserToEstab(be);
			}
		}
	}

	//cancel the current donation which are not yet accept by any individual
	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		BloodPlateletRequestUser bpr = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(lblRID.Text);
		userTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		List<BplTransactionUserToUser> alluserTransactions = new List<BplTransactionUserToUser>();
		foreach (BplTransactionUserToUser btu in userTransactions)
		{
			if (btu.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == bpr.bplUserRequestID && btu.status == "accepted")
			{
				alluserTransactions.Add(btu);
			}
		}
		BplTransactionUserToUser selectedTransaction = alluserTransactions[GridView1.PageSize * GridView1.PageIndex + e.RowIndex];
		selectedTransaction.status = "cancelled";
		BplTransactionUserToUserDB.updateBPTranscationUserToUser(selectedTransaction);

		BloodPlateletRequestUser selectedRequest = bpr;
		selectedRequest.unitMatched = selectedRequest.unitMatched - selectedTransaction.unitsPossible;
		BloodPlateletRequestUserDB.updateBloodPlateles(selectedRequest);
		Server.Transfer("DonateAndRequest.aspx");

	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		BloodPlateletRequestUser bpr = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(lblRID.Text);
		estabTransactions = BplTransactionUserToEstabDB.getAllbpTransactionUserToEsta();
		List<BplTransactionUserToEstab> allestabTransactions = new List<BplTransactionUserToEstab>();
		foreach (BplTransactionUserToEstab m in estabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == bpr.bplUserRequestID && m.status == "accepted")
			{
				allestabTransactions.Add(m);
			}
		}
		BplTransactionUserToEstab selectedTransaction = allestabTransactions[GridView2.PageSize * GridView2.PageIndex + e.RowIndex];
		selectedTransaction.status = "cancelled";
		BplTransactionUserToEstabDB.updateBPTranscationUserToEstab(selectedTransaction);

		BloodPlateletRequestUser selectedRequest = bpr;
		selectedRequest.unitMatched = selectedRequest.unitMatched - selectedTransaction.unit;
		BloodPlateletRequestUserDB.updateBloodPlateles(selectedRequest);
		Server.Transfer("DonateAndRequest.aspx");
	}


	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		BloodPlateletRequestUser bpr = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(lblRID.Text);
		userTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		List<BplTransactionUserToUser> alluserTransactions = new List<BplTransactionUserToUser>();
		foreach (BplTransactionUserToUser btu in userTransactions)
		{
			if (btu.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == bpr.bplUserRequestID && btu.status == "accepted")
			{
				alluserTransactions.Add(btu);
			}
		}
		BplTransactionUserToUser selectedTransaction = alluserTransactions[GridView1.PageSize * GridView1.PageIndex + GridView1.SelectedIndex];
		//take the session for individual chatting 
		Session["chat"] = selectedTransaction.bpMatchUsrUsr.matchID.userId;
		Session["echat"] = null;
		Server.Transfer("IndividualChatUU.aspx");
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
		BloodPlateletRequestUser bpr = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(lblRID.Text);
		List<BplTransactionUserToEstab> allestabTransactions = new List<BplTransactionUserToEstab>();
		estabTransactions = BplTransactionUserToEstabDB.getAllbpTransactionUserToEsta();

		foreach (BplTransactionUserToEstab m in estabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == bpr.bplUserRequestID && m.status == "accepted")
			{
				allestabTransactions.Add(m);
			}

		}
		//take the session for individual chatting 
		BplTransactionUserToEstab selectedTransaction = allestabTransactions[GridView2.PageSize * GridView2.PageIndex + GridView2.SelectedIndex];
		Session["echat"] = selectedTransaction.bpMatchUsrEstID.matchID.ID;
		Session["chat"] = null;
		Server.Transfer("IndividualChatUU.aspx");
	}
}
