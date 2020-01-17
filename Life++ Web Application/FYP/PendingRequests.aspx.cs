using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingRequests : System.Web.UI.Page
{
	List<EstablishmentBPRequest> pendingRequests = new List<EstablishmentBPRequest>();
	List<EstabEstabTransaction> estabTransactions = new List<EstabEstabTransaction>();
	List<EstabUserTransaction> userTransactions = new List<EstabUserTransaction>();

	protected void Page_Load(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<EstablishmentBPRequest> allRequests = EstablishmentBPRequestDB.getAllEstablishmentRequests();
		bool requestFound = false;
		foreach (EstablishmentBPRequest r in allRequests)
		{
			if (r.Status == "pending" && r.Establishment.ID == currentEstab.ID)
			{
				pendingRequests.Add(r);
				requestFound = true;
			}
		}
		if (requestFound == true)
		{
			gvRequests.DataSource = pendingRequests;
			gvRequests.DataBind();
		}
		else
		{
			lblOutput.Text = "Your establishment currently has no pending blood/platelet requests";


		}



	}

	protected void gvRequests_SelectedIndexChanged(object sender, EventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];
		List<EstabEstabTransaction> allEstabTransactions = EstabEstabTransactionDB.getAllTransactions();
		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		int flag = 0;
		foreach (EstabEstabTransaction m in allEstabTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				estabTransactions.Add(m);
				flag = 1;
			}

		}
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				userTransactions.Add(m);
				flag = 2;
			}

		}
		if (flag == 0)
		{
			lblOutput.Text = "Sorry no matches found yet!";
			panelMatches.Visible = false;
		}
		else
		{
			panelMatches.Visible = true;
			gvEstabMatches.DataSource = estabTransactions;
			gvEstabMatches.DataBind();
			gvUserMatches.DataSource = userTransactions;
			gvUserMatches.DataBind();
		}







	}

	protected void gvRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRequests.PageIndex = e.NewPageIndex;
		gvRequests.DataSource = pendingRequests;
		gvRequests.DataBind();
	}



	protected void gvRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + e.RowIndex];
		int noTransactions = 0;
		List<EstabEstabTransaction> allEstabTransactions = EstabEstabTransactionDB.getAllTransactions();
		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		foreach (EstabEstabTransaction m in allEstabTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "complete")
				noTransactions = 1;
		}
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "complete")
				noTransactions = 2;
		}
		if (noTransactions == 1 || noTransactions == 2)
			lblOutput.Text = "Sorry this request cannot be cancelled!";
		else
		{



			foreach (EstabEstabTransaction m in allEstabTransactions)
			{
				if (m.Match.Request.ID == selectedRequest.ID)
				{
					m.Status = "cancelled";
					EstabEstabTransactionDB.updateTransaction(m);
					m.Match.Status = "declined";
					EstabEstabMatchDB.updateMatch(m.Match);
				}


			}
			foreach (EstabUserTransaction m in allUserTransactions)
			{
				if (m.Match.Request.ID == selectedRequest.ID)
				{
					m.Status = "cancelled";
					EstabUserTransactionDB.updateTransaction(m);
					m.Match.Status = "declined";
					EstabUserMatchDB.updateMatch(m.Match);
				}


			}

			selectedRequest.Status = "cancelled";
			EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
			Server.Transfer("PendingRequests.aspx");



		}


	}

	protected void gvEstabMatches_SelectedIndexChanged(object sender, EventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];

		List<EstabEstabTransaction> allEstabTransactions = EstabEstabTransactionDB.getAllTransactions();
		foreach (EstabEstabTransaction m in allEstabTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				estabTransactions.Add(m);

			}

		}
		EstabEstabTransaction selectedTransaction = estabTransactions[gvEstabMatches.SelectedIndex];
		selectedTransaction.Status = "complete";
		EstabEstabTransactionDB.updateTransaction(selectedTransaction);

		EstabEstabMatch currentMatch = selectedTransaction.Match;
		currentMatch.Status = "complete";
		EstabEstabMatchDB.updateMatch(currentMatch);



		if (selectedRequest.MatchedUnits == selectedRequest.Units)
		{
			selectedRequest.Status = "complete";
			EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
			foreach (EstabEstabTransaction et in allEstabTransactions)
			{
				if (et.Match.Request.ID == selectedRequest.ID)
				{
					et.Status = "complete";
					EstabEstabTransactionDB.updateTransaction(et);
					et.Match.Status = "complete";
					EstabEstabMatchDB.updateMatch(et.Match);
				}
			}


		}
		Server.Transfer("PendingRequests.aspx");

	}

	protected void gvUserMatches_SelectedIndexChanged(object sender, EventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];
		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				userTransactions.Add(m);

			}

		}
		EstabUserTransaction selectedTransaction = userTransactions[gvUserMatches.SelectedIndex];
		selectedTransaction.Status = "complete";
		EstabUserTransactionDB.updateTransaction(selectedTransaction);


		EstabUserMatch currentMatch = selectedTransaction.Match;
		currentMatch.Status = "complete";
		EstabUserMatchDB.updateMatch(currentMatch);

		Users currentUser = currentMatch.Match;
		List<LastDonationDate> allLastDates = LastDonationDateDB.getAllLastDonations();
		foreach (LastDonationDate ld in allLastDates)
		{
			if (ld.User.UserId == currentUser.UserId)
			{
				ld.LastDonation = DateTime.Today;
				ld.Type = currentMatch.Request.Type;
				ld.Status = "Not in transaction";
				LastDonationDateDB.updateLastDonation(ld);
			}
		}



		if (selectedRequest.MatchedUnits == selectedRequest.Units)
		{
			selectedRequest.Status = "complete";
			EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
			foreach (EstabUserTransaction ut in allUserTransactions)
			{
				if (ut.Match.Request.ID == selectedRequest.ID)
				{
					ut.Status = "complete";
					EstabUserTransactionDB.updateTransaction(ut);
					ut.Match.Status = "complete";
					EstabUserMatchDB.updateMatch(ut.Match);
				}
			}


		}

		Server.Transfer("PendingRequests.aspx");


	}

	protected void gvUserMatches_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];
		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				userTransactions.Add(m);

			}

		}
		EstabUserTransaction selectedTransaction = userTransactions[e.RowIndex];
		selectedTransaction.Status = "cancelled";
		EstabUserTransactionDB.updateTransaction(selectedTransaction);


		selectedTransaction.Match.Status = "declined";
		EstabUserMatchDB.updateMatch(selectedTransaction.Match);

		selectedRequest.MatchedUnits = selectedRequest.MatchedUnits - selectedTransaction.Units;
		EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
		Server.Transfer("PendingRequests.aspx");


	}

	protected void gvEstabMatches_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];
		List<EstabEstabTransaction> allEstabTransactions = EstabEstabTransactionDB.getAllTransactions();
		foreach (EstabEstabTransaction m in allEstabTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				estabTransactions.Add(m);

			}

		}

		EstabEstabTransaction selectedTransaction = estabTransactions[e.RowIndex];
		selectedTransaction.Status = "cancelled";
		EstabEstabTransactionDB.updateTransaction(selectedTransaction);


		selectedTransaction.Match.Status = "declined";
		EstabEstabMatchDB.updateMatch(selectedTransaction.Match);

		selectedRequest.MatchedUnits = selectedRequest.MatchedUnits - selectedTransaction.Units;
		EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
		Server.Transfer("PendingRequests.aspx");

	}

	//protected void gvUserMatches_PageIndexChanging(object sender, GridViewPageEventArgs e)
	//{
	//    gvUserMatches.PageIndex = e.NewPageIndex;
	//    gvUserMatches.DataSource = userTransactions;
	//    gvUserMatches.DataBind();
	//}

	//protected void gvEstabMatches_PageIndexChanging(object sender, GridViewPageEventArgs e)
	//{
	//    gvEstabMatches.PageIndex = e.NewPageIndex;
	//    gvEstabMatches.DataSource = estabTransactions;
	//    gvEstabMatches.DataBind();
	//}



	protected void lbtnReport_Click(object sender, EventArgs e)
	{
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];

		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				userTransactions.Add(m);

			}

		}

		EstabUserTransaction selectedTransaction = userTransactions[i];
		Users reportedUser = selectedTransaction.Match.Match;
		reportedUser.MedicalStatus = "cannot donate";
		reportedUser.MedicalStatusUpdateBy = ((Establishment)Session["establishment"]).ID;
		UsersDB.updateUser(reportedUser);
		List<LastDonationDate> allLastDates = LastDonationDateDB.getAllLastDonations();
		foreach (LastDonationDate ld in allLastDates)
		{
			if (ld.User.UserId == reportedUser.userId)
			{
				ld.LastDonation = DateTime.Today;
				ld.Type = selectedRequest.Type;
				ld.Status = "Not in transaction";
				LastDonationDateDB.updateLastDonation(ld);
			}
		}

		selectedTransaction.Status = "cancelled";
		EstabUserTransactionDB.updateTransaction(selectedTransaction);

		selectedTransaction.Match.Status = "declined";
		EstabUserMatchDB.updateMatch(selectedTransaction.Match);

		selectedRequest.MatchedUnits = selectedRequest.MatchedUnits - selectedTransaction.Units;
		EstablishmentBPRequestDB.updateEstablishmentRequest(selectedRequest);
		Server.Transfer("PendingRequests.aspx");


	}

	protected void lbtnContact_Click(object sender, EventArgs e)
	{
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];

		List<EstabUserTransaction> allUserTransactions = EstabUserTransactionDB.getAllTransactions();
		foreach (EstabUserTransaction m in allUserTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				userTransactions.Add(m);

			}

		}

		EstabUserTransaction selectedTransaction = userTransactions[i];
		Users contactUser = selectedTransaction.Match.Match;
		Session["ldID"] = contactUser.UserId;
		Session["rwEst"] = null;
		Session["echat"] = null;
		Server.Transfer("IndividualChatE.aspx");

	}

	protected void lbtnContact_Click1(object sender, EventArgs e)
	{
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		EstablishmentBPRequest selectedRequest = pendingRequests[gvRequests.PageSize * gvRequests.PageIndex + gvRequests.SelectedIndex];
		List<EstabEstabTransaction> allEstabTransactions = EstabEstabTransactionDB.getAllTransactions();
		foreach (EstabEstabTransaction m in allEstabTransactions)
		{
			if (m.Match.Request.ID == selectedRequest.ID && m.Status == "accepted")
			{
				estabTransactions.Add(m);

			}

		}
		EstabEstabTransaction selectedTransaction = estabTransactions[i];
		Establishment contactEstab = selectedTransaction.Match.Match;
		Session["ldID"] = null;
		Session["rwEst"] = null;
		Session["echat"] = contactEstab.ID;
		Server.Transfer("IndividualChatE.aspx");
	}
}