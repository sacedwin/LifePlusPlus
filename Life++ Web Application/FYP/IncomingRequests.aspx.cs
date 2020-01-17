using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncomingRequests : System.Web.UI.Page
{
	List<BplTransactionUserToEstab> userTransactions = new List<BplTransactionUserToEstab>();
	List<EstabEstabTransaction> estabTransactions = new List<EstabEstabTransaction>();

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null) {
			Server.Transfer("Login.aspx");
		}
		else
		{
			Establishment currentEstab = (Establishment)Session["establishment"];
			List<EstabEstabMatch> allEstabRequests = EstabEstabMatchDB.getAllMatches();
			List<EstabEstabMatch> estabRequests = new List<EstabEstabMatch>();
			foreach (EstabEstabMatch m in allEstabRequests)
			{
				if (m.Match.ID == currentEstab.ID && m.Status == "pending" && m.Request.MatchedUnits < m.Request.Units)
					estabRequests.Add(m);
			}
			if (estabRequests.Count == 0)
			{
				lblOutput.Text = "There are currently no requests from establishments";
				pnlEstabRequests.Visible = false;
			}
			else
			{
				gvEstabRequests.DataSource = estabRequests;
				gvEstabRequests.DataBind();
			}

			List<BPMatchUserToEstab> allUserRequests = BPMatchUserToEstabDB.getAllbpMatchUserToEsta();
			List<BPMatchUserToEstab> userRequests = new List<BPMatchUserToEstab>();
			foreach (BPMatchUserToEstab m in allUserRequests)
			{
				if (m.matchID.ID == currentEstab.ID && m.status == "pending" && m.bpRequestID.unitMatched < m.bpRequestID.Units)
					userRequests.Add(m);
			}
			if (userRequests.Count == 0)
			{
				lblOutput.Text = "There are currently no requests from users";
				pnlUserRequests.Visible = false;
			}
			else
			{
				gvUserRequests.DataSource = userRequests;
				gvUserRequests.DataBind();
			}

		}

	}

	protected void gvEstabRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<EstabEstabMatch> allEstabRequests = EstabEstabMatchDB.getAllMatches();
		List<EstabEstabMatch> estabRequests = new List<EstabEstabMatch>();
		foreach (EstabEstabMatch m in allEstabRequests)
		{
			if (m.Match.ID == currentEstab.ID && m.Status == "pending" && m.Request.MatchedUnits < m.Request.Units)
				estabRequests.Add(m);
		}
		EstabEstabMatch currentMatch = estabRequests[gvEstabRequests.PageSize * gvEstabRequests.PageIndex + e.RowIndex];
		currentMatch.Status = "declined";
		EstabEstabMatchDB.updateMatch(currentMatch);
		Server.Transfer("IncomingRequests.aspx");
	}

	protected void gvEstabRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<EstabEstabMatch> allEstabRequests = EstabEstabMatchDB.getAllMatches();
		List<EstabEstabMatch> estabRequests = new List<EstabEstabMatch>();
		foreach (EstabEstabMatch m in allEstabRequests)
		{
			if (m.Match.ID == currentEstab.ID && m.Status == "pending" && m.Request.MatchedUnits < m.Request.Units)
				estabRequests.Add(m);
		}
		gvEstabRequests.PageIndex = e.NewPageIndex;
		gvEstabRequests.DataSource = estabRequests;
		gvEstabRequests.DataBind();
	}

	protected void btnEstabSubmit_Click(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<EstabEstabMatch> allEstabRequests = EstabEstabMatchDB.getAllMatches();
		List<EstabEstabMatch> estabRequests = new List<EstabEstabMatch>();
		foreach (EstabEstabMatch m in allEstabRequests)
		{
			if (m.Match.ID == currentEstab.ID && m.Status == "pending" && m.Request.MatchedUnits < m.Request.Units)
				estabRequests.Add(m);
		}
		EstabEstabMatch currentMatch = estabRequests[gvEstabRequests.PageSize * gvEstabRequests.PageIndex + gvEstabRequests.SelectedIndex];
		EstablishmentBPRequest r = currentMatch.Request;
		EstabEstabTransaction newTransaction = new EstabEstabTransaction();
		if (Convert.ToInt32(tbxEstabUnits.Text) > 0 || Convert.ToInt32(tbxUserUnits.Text) > 0)
		{
			int donateUnits = Convert.ToInt32(tbxEstabUnits.Text);
			if (donateUnits > (currentMatch.Request.Units - currentMatch.Request.MatchedUnits))
				lblEstabOutput.Text = "Please enter a valid amount";
			else
			{
				currentMatch.Status = "accepted";
				EstabEstabMatchDB.updateMatch(currentMatch);
				newTransaction.Match = currentMatch;
				newTransaction.Units = donateUnits;
				newTransaction.Status = "accepted";
				EstabEstabTransactionDB.insertTransaction(newTransaction);
				r.MatchedUnits = r.MatchedUnits + donateUnits;
				EstablishmentBPRequestDB.updateEstablishmentRequest(r);
				lblOutput.Text = "Donation successfully accepted!";
				pnlAcceptEstab.Visible = false;
				tbxEstabUnits.Text = "";
				Server.Transfer("IncomingRequests.aspx");

			}
		}
		else
		{
			lblOutput.Text = "The Unit cannot be less than 0 or less";
			return;
		}
	}

	protected void btnUserSubmit_Click(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<BPMatchUserToEstab> allUserRequests = BPMatchUserToEstabDB.getAllbpMatchUserToEsta();
		List<BPMatchUserToEstab> userRequests = new List<BPMatchUserToEstab>();
		foreach (BPMatchUserToEstab m in allUserRequests)
		{
			if (m.matchID.ID == currentEstab.ID && m.status == "pending" && m.bpRequestID.unitMatched < m.bpRequestID.Units)
				userRequests.Add(m);
		}
		BPMatchUserToEstab currentMatch = userRequests[gvUserRequests.PageSize * gvUserRequests.PageIndex + gvUserRequests.SelectedIndex];
		BloodPlateletRequestUser r = currentMatch.bpRequestID;
		BplTransactionUserToEstab newTransaction = new BplTransactionUserToEstab();
		int donateUnits = Convert.ToInt32(tbxUserUnits.Text);
		if (donateUnits > (currentMatch.bpRequestID.Units - currentMatch.bpRequestID.unitMatched))
			lblUserOutput.Text = "Please enter a valid amount";
		else
		{
			currentMatch.status = "accepted";
			BPMatchUserToEstabDB.updateBPMatchUserToEstab(currentMatch);
			newTransaction.bpMatchUsrEstID = currentMatch;
			newTransaction.unit = donateUnits;
			newTransaction.status = "accepted";
			BplTransactionUserToEstabDB.insertbptrans(newTransaction);
			r.unitMatched = r.unitMatched + donateUnits;
			BloodPlateletRequestUserDB.updateBloodPlateles(r);
			lblOutput.Text = "Donation successfully accepted!";
			pnlAcceptUser.Visible = false;
			tbxUserUnits.Text = "";
			Server.Transfer("IncomingRequests.aspx");
		}
	}

	protected void gvEstabRequests_SelectedIndexChanged(object sender, EventArgs e)
	{
		pnlAcceptEstab.Visible = true;
	}

	protected void gvUserRequests_SelectedIndexChanged(object sender, EventArgs e)
	{
		pnlAcceptUser.Visible = true;
	}

	protected void gvUserRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<BPMatchUserToEstab> allUserRequests = BPMatchUserToEstabDB.getAllbpMatchUserToEsta();
		List<BPMatchUserToEstab> userRequests = new List<BPMatchUserToEstab>();
		foreach (BPMatchUserToEstab m in allUserRequests)
		{
			if (m.matchID.ID == currentEstab.ID && m.status == "pending" && m.bpRequestID.unitMatched < m.bpRequestID.Units)
				userRequests.Add(m);
		}
		gvUserRequests.PageIndex = e.NewPageIndex;
		gvUserRequests.DataSource = userRequests;
		gvUserRequests.DataBind();
	}

	protected void gvUserRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<BPMatchUserToEstab> allUserRequests = BPMatchUserToEstabDB.getAllbpMatchUserToEsta();
		List<BPMatchUserToEstab> userRequests = new List<BPMatchUserToEstab>();
		foreach (BPMatchUserToEstab m in allUserRequests)
		{
			if (m.matchID.ID == currentEstab.ID && m.status == "pending" && m.bpRequestID.unitMatched < m.bpRequestID.Units)
				userRequests.Add(m);
		}
		BPMatchUserToEstab currentMatch = userRequests[gvUserRequests.PageSize * gvUserRequests.PageIndex + e.RowIndex];
		currentMatch.status = "declined";
		BPMatchUserToEstabDB.updateBPMatchUserToEstab(currentMatch);
		Server.Transfer("IncomingRequests.aspx");
	}

	protected void lbtnContact_Click(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		List<EstabEstabMatch> allEstabRequests = EstabEstabMatchDB.getAllMatches();
		List<EstabEstabMatch> estabRequests = new List<EstabEstabMatch>();
		foreach (EstabEstabMatch m in allEstabRequests)
		{
			if (m.Match.ID == currentEstab.ID && m.Status == "pending" && m.Request.MatchedUnits < m.Request.Units)
				estabRequests.Add(m);
		}
		EstabEstabMatch currentMatch = estabRequests[i];
		Establishment contactEstab = currentMatch.Request.Establishment;
		Session["ldID"] = null;
		Session["rwEst"] = null;
		Session["echat"] = contactEstab.ID;
		Server.Transfer("IndividualChatE.aspx");
		//store session for individual chat in next page
	}

	protected void lbtnContact1_Click(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		List<BPMatchUserToEstab> allUserRequests = BPMatchUserToEstabDB.getAllbpMatchUserToEsta();
		List<BPMatchUserToEstab> userRequests = new List<BPMatchUserToEstab>();
		foreach (BPMatchUserToEstab m in allUserRequests)
		{
			if (m.matchID.ID == currentEstab.ID && m.status == "pending" && m.bpRequestID.unitMatched < m.bpRequestID.Units)
				userRequests.Add(m);
		}
		BPMatchUserToEstab currentMatch = userRequests[i];
		Users contactUser = currentMatch.bpRequestID.requestorID;
		Session["ldID"] = contactUser.UserId;
		Session["rwEst"] = null;
		Session["echat"] = null;
		Server.Transfer("IndividualChatE.aspx");
		//store session for individual chat in next page

	}
}