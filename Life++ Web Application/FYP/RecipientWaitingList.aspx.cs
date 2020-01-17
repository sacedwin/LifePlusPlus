using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecipientWaitingList : System.Web.UI.Page
{

	// String tempCurrentMatch = "";
	//int matchFound = 0;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("Login.aspx");
		}
		else
		{
			Establishment currentEstab = (Establishment)Session["establishment"];
			List<OrganRecipient> ourRecipients = new List<OrganRecipient>();
			List<OrganRecipient> allRecipients = OrganRecipientDB.getAllRecipients();
			Label1.Text = "";
			lblOutput.Text = "";
			bool recipientFound = false;
			//check recipitent register with the current establishment
			foreach (OrganRecipient r in allRecipients)
			{
				if (r.Establishment.ID == currentEstab.ID && (r.Status == "waiting" || r.Status == "allotted"))
				{
					ourRecipients.Add(r);
					recipientFound = true;
				}
			}

			if (recipientFound == true)
			{
				gvRecipients.DataSource = ourRecipients;
				gvRecipients.DataBind();
			}
			else
				lblOutput.Text = "There are currently no waiting recipients registered to your establishment";
		}
	}

	protected void btnAddOrgan_Click(object sender, EventArgs e)
	{
		Server.Transfer("AddOrganRecipient.aspx");
	}



	protected void gvRecipients_SelectedIndexChanged(object sender, EventArgs e)
	{
		List<OrganRecipient> ourRecipients = new List<OrganRecipient>();
		List<OrganRecipient> allRecipients = OrganRecipientDB.getAllRecipients();
		Establishment currentEstab = (Establishment)Session["establishment"];
		foreach (OrganRecipient r in allRecipients)
		{
			if (r.Establishment.ID == currentEstab.ID && (r.Status == "waiting" || r.Status == "allotted"))
			{
				ourRecipients.Add(r);
			}
		}
		OrganRecipient currentRecipient = ourRecipients[gvRecipients.PageSize * gvRecipients.PageIndex + gvRecipients.SelectedIndex];
		DeceasedOrganMatching deadOrgan = new DeceasedOrganMatching();
		LiveOrganMatching liveOrgan = new LiveOrganMatching();
		int matchFound = 0;
		List<DeceasedOrganMatching> allDeadMatches = DeceasedOrganMatchingDB.getAllMatches();
		List<LiveOrganMatching> allLiveMatches = LiveOrganMatchingDB.getAllMatches();
		foreach (DeceasedOrganMatching d in allDeadMatches)
		{
			if (d.Recipient.ID == currentRecipient.ID && d.Status == "current match")
			{
				matchFound = 1;
				deadOrgan = d;
			}
		}
		foreach (LiveOrganMatching l in allLiveMatches)
		{
			if (l.Recipient.ID == currentRecipient.ID && l.Status == "current match")
			{
				matchFound = 2;
				liveOrgan = l;
			}
		}
		if (matchFound == 0)
		{
			lblOutput.Text = "Sorry no matches yet!";
			pnlMatch.Visible = false;
		}
		else if (matchFound == 1)
		{
			lblOutput.Text = "";
			try
			{
				pnlMatch.Visible = true;

				lblMedical.Text = deadOrgan.DeceasedDonor.Establishment.Name;
				Session["rwEst"] = deadOrgan.DeceasedDonor.Establishment.ID;
				Session["ldID"] = null;
				Session["echat"] = null;
				lblContact.Text = deadOrgan.DeceasedDonor.Establishment.Phone + " / " + deadOrgan.DeceasedDonor.Establishment.Email;
				lblBloodType.Text = deadOrgan.DeceasedDonor.Bloodgroup;
				lblHeightWeight.Text = deadOrgan.DeceasedDonor.Donorheight + " / " + deadOrgan.DeceasedDonor.Donorweight;
				lblComments.Text = deadOrgan.DeceasedDonor.Comments;
				lblMatchScore.Text = Convert.ToString(deadOrgan.MatchScore);
				tbxMatchComments.Text = deadOrgan.Comments;
				lblDistance.Text = Convert.ToString(deadOrgan.Distance);
			}
			catch { lblOutput.Text = "Please Check The Entered Values"; }

		}
		else if (matchFound == 2)
		{
			lblOutput.Text = "";
			try
			{
				pnlMatch.Visible = true;

				lblMedical.Text = liveOrgan.LiveDonor.doctorName;
				Session["rwEst"] = null;
				Session["ldID"] = liveOrgan.LiveDonor.Userid.userId;
				Session["echat"] = null;
				lblContact.Text = liveOrgan.LiveDonor.DoctorNumber + " / " + liveOrgan.LiveDonor.DoctorEmail;
				lblBloodType.Text = liveOrgan.LiveDonor.Userid.BloodType;
				lblHeightWeight.Text = liveOrgan.LiveDonor.userid.Height + " / " + liveOrgan.LiveDonor.Userid.Weight;
				lblComments.Text = liveOrgan.LiveDonor.comments;
				lblMatchScore.Text = Convert.ToString(liveOrgan.MatchScore);
				tbxMatchComments.Text = liveOrgan.Comments;
				lblDistance.Text = Convert.ToString(liveOrgan.Distance);
			}
			catch { lblOutput.Text = "Please Check The Entered Values"; }
		}
	}

	protected void gvRecipients_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
			List<OrganRecipient> ourRecipients = new List<OrganRecipient>();
		List<OrganRecipient> allRecipients = OrganRecipientDB.getAllRecipients();
		Establishment currentEstab = (Establishment)Session["establishment"];
		foreach (OrganRecipient r in allRecipients)
		{
			if (r.Establishment.ID == currentEstab.ID && (r.Status == "waiting" || r.Status == "allotted"))
			{
				ourRecipients.Add(r);
			}
		}
		gvRecipients.PageIndex = e.NewPageIndex;
		gvRecipients.DataSource = ourRecipients;
		gvRecipients.DataBind();
	}

	protected void btnAccept_Click(object sender, EventArgs e)
	{
		List<OrganRecipient> ourRecipients = new List<OrganRecipient>();
		List<OrganRecipient> allRecipients = OrganRecipientDB.getAllRecipients();
		Establishment currentEstab = (Establishment)Session["establishment"];
		foreach (OrganRecipient r in allRecipients)
		{
			if (r.Establishment.ID == currentEstab.ID && (r.Status == "waiting" || r.Status == "allotted"))
			{
				ourRecipients.Add(r);
			}
		}
		OrganRecipient currentRecipient = ourRecipients[gvRecipients.PageSize * gvRecipients.PageIndex + gvRecipients.SelectedIndex];
		DeceasedOrganMatching deadOrgan = new DeceasedOrganMatching();
		LiveOrganMatching liveOrgan = new LiveOrganMatching();
		int matchFound = 0;
		List<DeceasedOrganMatching> allDeadMatches = DeceasedOrganMatchingDB.getAllMatches();
		List<LiveOrganMatching> allLiveMatches = LiveOrganMatchingDB.getAllMatches();
		foreach (DeceasedOrganMatching d in allDeadMatches)
		{
			if (d.Recipient.ID == currentRecipient.ID && d.Status == "current match")
			{
				matchFound = 1;
				deadOrgan = d;
			}
		}
		foreach (LiveOrganMatching l in allLiveMatches)
		{
			if (l.Recipient.ID == currentRecipient.ID && l.Status == "current match")
			{
				matchFound = 2;
				liveOrgan = l;
			}
		}
		pnlMatch.Visible = true;
		if (matchFound == 0)
		{
			lblOutput.Text = "Sorry no matches yet!";

		}
		else if (matchFound == 1)
		{
			currentRecipient.Status = "complete";
			OrganRecipientDB.updateOrganRecipient(currentRecipient);
			deadOrgan.DeceasedDonor.Status = "complete";
			DeceasedDonorDB.updateDeceasedDonor(deadOrgan.DeceasedDonor);
			deadOrgan.Status = "complete";
			DeceasedOrganMatchingDB.updateMatch(deadOrgan);



			foreach (DeceasedOrganMatching d2 in allDeadMatches)
			{
				if (d2.DeceasedDonor.ID == deadOrgan.DeceasedDonor.ID && d2.Status != "complete")
				{
					d2.Status = "not possible";
					DeceasedOrganMatchingDB.updateMatch(d2);
				}
			}

			foreach (DeceasedOrganMatching dd in allDeadMatches)
			{
				if (dd.Recipient.ID == currentRecipient.ID && dd.Status != "complete")
				{
					dd.Status = "not possible";
					DeceasedOrganMatchingDB.updateMatch(dd);
				}
			}

			foreach (LiveOrganMatching ll in allLiveMatches)
			{
				if (ll.Recipient.ID == currentRecipient.ID && ll.Status != "complete")
				{
					ll.Status = "not possible";
					LiveOrganMatchingDB.updateMatch(ll);
				}
			}
			Label1.Text = "Successfully completed";
			string MyAccountUrl = "RecipientWaitingList.aspx";
			Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));
		}
		else if (matchFound == 2)
		{
			currentRecipient.Status = "complete";
			OrganRecipientDB.updateOrganRecipient(currentRecipient);
			liveOrgan.LiveDonor.Status = "complete";
			LiveDonorDB.updateLiveDonor(liveOrgan.LiveDonor);
			liveOrgan.Status = "complete";
			LiveOrganMatchingDB.updateMatch(liveOrgan);



			foreach (LiveOrganMatching l2 in allLiveMatches)
			{
				if (l2.LiveDonor.LdonorID == liveOrgan.LiveDonor.LdonorID && l2.Status != "complete")
				{
					l2.Status = "not possible";
					LiveOrganMatchingDB.updateMatch(l2);
				}
			}

			foreach (DeceasedOrganMatching dd in allDeadMatches)
			{
				if (dd.Recipient.ID == currentRecipient.ID && dd.Status != "complete")
				{
					dd.Status = "not possible";
					DeceasedOrganMatchingDB.updateMatch(dd);
				}
			}
			foreach (LiveOrganMatching ll in allLiveMatches)
			{
				if (ll.Recipient.ID == currentRecipient.ID && ll.Status != "complete")
				{
					ll.Status = "not possible";
					LiveOrganMatchingDB.updateMatch(ll);
				}
			}
			Label1.Text = "Successfully completed";
			string MyAccountUrl = "RecipientWaitingList.aspx";
			Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));
		}

	}

	protected void btnDecline_Click(object sender, EventArgs e)
	{
		List<OrganRecipient> ourRecipients = new List<OrganRecipient>();
		List<OrganRecipient> allRecipients = OrganRecipientDB.getAllRecipients();
		Establishment currentEstab = (Establishment)Session["establishment"];
		foreach (OrganRecipient r in allRecipients)
		{
			if (r.Establishment.ID == currentEstab.ID && (r.Status == "waiting" || r.Status == "allotted"))
			{
				ourRecipients.Add(r);
			}
		}
		OrganRecipient currentRecipient = ourRecipients[gvRecipients.PageSize * gvRecipients.PageIndex + gvRecipients.SelectedIndex];
		DeceasedOrganMatching deadOrgan = new DeceasedOrganMatching();
		LiveOrganMatching liveOrgan = new LiveOrganMatching();
		int matchFound = 0;
		List<DeceasedOrganMatching> allDeadMatches = DeceasedOrganMatchingDB.getAllMatches();
		List<LiveOrganMatching> allLiveMatches = LiveOrganMatchingDB.getAllMatches();
		List<DeceasedOrganMatching> allDeadMatchesCurr = new List<DeceasedOrganMatching>();
		List<LiveOrganMatching> allLiveMatchesCurr = new List<LiveOrganMatching>();
		bool checkMatchD = false;
		bool checkMatchL = false;
		foreach (DeceasedOrganMatching d in allDeadMatches)
		{
			if (d.Recipient.ID == currentRecipient.ID && d.Status == "current match")
			{
				matchFound = 1;
				deadOrgan = d;
			}
			else if (d.Recipient.ID == currentRecipient.ID && d.Status == "pending" && d.DeceasedDonor.Status == "not allotted")
			{
				allDeadMatchesCurr.Add(d);
				checkMatchD = true;
			}

		}
		foreach (LiveOrganMatching l in allLiveMatches)
		{
			if (l.Recipient.ID == currentRecipient.ID && l.Status == "current match")
			{
				matchFound = 2;
				liveOrgan = l;
			}
			else if (l.Recipient.ID == currentRecipient.ID && l.Status == "pending" && l.LiveDonor.status == "not allotted")
			{
				allLiveMatchesCurr.Add(l);
				checkMatchL = true;
			}
		}
		if (matchFound == 0)
		{
			lblOutput.Text = "Sorry no matches yet!";
		}
		else if (matchFound == 2)
		{
			// tempCurrentMatch = deadOrgan.ID;
			liveOrgan.Status = "not possible";
			LiveOrganMatchingDB.updateMatch(liveOrgan);

		}
		else if (matchFound == 1)
		{
			// tempCurrentMatch = liveOrgan.ID;
			deadOrgan.Status = "not possible";
			DeceasedOrganMatchingDB.updateMatch(deadOrgan);
		}
		LiveOrganMatching tempLDM = new LiveOrganMatching();
		if (checkMatchL == true)
		{
			tempLDM = allLiveMatchesCurr[0];
			foreach (LiveOrganMatching ldm in allLiveMatchesCurr)
			{
				if (ldm.MatchScore > tempLDM.MatchScore)
					tempLDM = ldm;
			}
		}
		DeceasedOrganMatching tempDOM = new DeceasedOrganMatching();
		if (checkMatchD == true)
		{
			tempDOM = allDeadMatchesCurr[0];
			foreach (DeceasedOrganMatching dom in allDeadMatchesCurr)
			{
				if (dom.MatchScore > tempDOM.MatchScore)
					tempDOM = dom;
			}
		}
		if (checkMatchD == true && checkMatchL == true)
		{
			if (tempDOM.MatchScore < tempLDM.MatchScore)
			{
				tempLDM.Status = "current match";
				LiveOrganMatchingDB.updateMatch(tempLDM);
				LiveDonor tempItem = LiveDonorDB.getLiveDonorbyID(tempLDM.LiveDonor.LdonorID);
				tempItem.status = "allotted";
				LiveDonorDB.updateLiveDonor(tempItem);
			}
			else
			{
				tempDOM.Status = "current match";
				DeceasedOrganMatchingDB.updateMatch(tempDOM);
				DeceasedDonor tempItem = DeceasedDonorDB.getDonorByID(tempDOM.DeceasedDonor.ID);
				tempItem.Status = "allotted";
				DeceasedDonorDB.updateDeceasedDonor(tempItem);
			}
		}
		else if (checkMatchD == true && checkMatchL == false)
		{
			tempDOM.Status = "current match";
			DeceasedOrganMatchingDB.updateMatch(tempDOM);
			DeceasedDonor tempItem = DeceasedDonorDB.getDonorByID(tempDOM.DeceasedDonor.ID);
			tempItem.Status = "allotted";
			DeceasedDonorDB.updateDeceasedDonor(tempItem);
		}
		else if (checkMatchL == true && checkMatchD == false)
		{
			tempLDM.Status = "current match";
			LiveOrganMatchingDB.updateMatch(tempLDM);
			LiveDonor tempItem = LiveDonorDB.getLiveDonorbyID(tempLDM.LiveDonor.LdonorID);
			tempItem.status = "allotted";
			LiveDonorDB.updateLiveDonor(tempItem);
		}
		else
		{
			currentRecipient.Status = "waiting";
			OrganRecipientDB.updateOrganRecipient(currentRecipient);
		}
		Label1.Text = "Successfully completed";
		string MyAccountUrl = "RecipientWaitingList.aspx";
		Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));


	}

	protected void btnContact_Click(object sender, EventArgs e)
	{
		Server.Transfer("IndividualChatE.aspx");

	}
}