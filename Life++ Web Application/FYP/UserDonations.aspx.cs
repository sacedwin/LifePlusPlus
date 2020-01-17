using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserDonations : System.Web.UI.Page
{
	List<BloodPlateletRequestUser> userRequests = new List<BloodPlateletRequestUser>();
	List<BplTransactionUserToEstab> estabsAccepted = new List<BplTransactionUserToEstab>();
	List<BplTransactionUserToUser> usersAccepted = new List<BplTransactionUserToUser>();

	protected void Page_Load(object sender, EventArgs e)
	{
		//show all pending of users
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<BloodPlateletRequestUser> allRequests = BloodPlateletRequestUserDB.getAllUserBloodRequests();
		foreach (BloodPlateletRequestUser r in allRequests)
		{
			if (r.Establishment.ID == currentEstab.ID && r.Status == "pending")
				userRequests.Add(r);
		}


		pnlRequestInfo.Visible = true;
		gvRequestInfo.DataSource = userRequests;
		gvRequestInfo.DataBind();

	}

	protected void gvRequestInfo_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblOutput.Text = "";
		BloodPlateletRequestUser selectedRequest = userRequests[gvRequestInfo.PageSize * gvRequestInfo.PageIndex + gvRequestInfo.SelectedIndex];
		List<BplTransactionUserToEstab> allEstabTransactions = BplTransactionUserToEstabDB.getAllbpTransactionUserToEsta();
		List<BplTransactionUserToUser> allUserTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		int flag = 0;
		foreach (BplTransactionUserToEstab m in allEstabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == selectedRequest.bplUserRequestID && m.status == "accepted")
			{
				estabsAccepted.Add(m);
				flag = 1;
			}
		}
		foreach (BplTransactionUserToUser m in allUserTransactions)
		{
			if (m.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == selectedRequest.bplUserRequestID && m.status == "accepted")
			{
				usersAccepted.Add(m);
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
			gvAcceptedEstabRequests.DataSource = estabsAccepted;
			gvAcceptedEstabRequests.DataBind();
			gvAcceptedUserRequests.DataSource = usersAccepted;
			gvAcceptedUserRequests.DataBind();
		}
	}

	protected void gvRequestInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRequestInfo.PageIndex = e.NewPageIndex;
		gvRequestInfo.DataSource = userRequests;
		gvRequestInfo.DataBind();
	}

	protected void gvAcceptedUserRequests_SelectedIndexChanged(object sender, EventArgs e)
	{
		BloodPlateletRequestUser selectedRequest = userRequests[gvRequestInfo.PageSize * gvRequestInfo.PageIndex + gvRequestInfo.SelectedIndex];
		List<BplTransactionUserToUser> allUserTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		foreach (BplTransactionUserToUser m in allUserTransactions)
		{
			if (m.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == selectedRequest.bplUserRequestID && m.status == "accepted")
			{
				usersAccepted.Add(m);
			}
		}

		BplTransactionUserToUser selectedTransaction = usersAccepted[gvAcceptedUserRequests.PageSize * gvAcceptedUserRequests.PageIndex + gvAcceptedUserRequests.SelectedIndex];
		selectedTransaction.status = "complete";
		BplTransactionUserToUserDB.updateBPTranscationUserToUser(selectedTransaction);
		gvAcceptedUserRequests.DataBind();

		BPMatchUserToUser currentMatch = selectedTransaction.bpMatchUsrUsr;
		currentMatch.status = "declined";
		BPMatchUserToUserDB.updateMatchUserToUser(currentMatch);

		Users currentUser = currentMatch.matchID;
		List<LastDonationDate> allLastDates = LastDonationDateDB.getAllLastDonations();
		foreach (LastDonationDate ld in allLastDates)
		{
			if (ld.User.UserId == currentUser.UserId)
			{
				ld.LastDonation = DateTime.Today;
				ld.Type = currentMatch.bplUsrRequestID.bloodOrPlatelet;
				ld.Status = "Not in transaction";
				LastDonationDateDB.updateLastDonation(ld);
			}
		}

		if (selectedRequest.Units == selectedRequest.unitMatched)
		{
			selectedRequest.Status = "complete";
			BloodPlateletRequestUserDB.updateBloodPlateles(selectedRequest);
			gvRequestInfo.DataBind();
		}


	}

	protected void gvAcceptedEstabRequests_SelectedIndexChanged(object sender, EventArgs e)
	{
		BloodPlateletRequestUser selectedRequest = userRequests[gvRequestInfo.PageSize * gvRequestInfo.PageIndex + gvRequestInfo.SelectedIndex];
		List<BplTransactionUserToEstab> allEstabTransactions = BplTransactionUserToEstabDB.getAllbpTransactionUserToEsta();
		foreach (BplTransactionUserToEstab m in allEstabTransactions)
		{
			if (m.bpMatchUsrEstID.bpRequestID.bplUserRequestID == selectedRequest.bplUserRequestID && m.status == "accepted")
			{
				estabsAccepted.Add(m);

			}
		}

		BplTransactionUserToEstab selectedTransaction = estabsAccepted[gvAcceptedEstabRequests.PageSize * gvAcceptedEstabRequests.PageIndex + gvAcceptedEstabRequests.SelectedIndex];
		selectedTransaction.status = "complete";
		BplTransactionUserToEstabDB.updateBPTranscationUserToEstab(selectedTransaction);
		gvAcceptedEstabRequests.DataBind();

		BPMatchUserToEstab currentMatch = selectedTransaction.bpMatchUsrEstID;
		currentMatch.status = "declined";
		BPMatchUserToEstabDB.updateBPMatchUserToEstab(currentMatch);

		if (selectedRequest.Units == selectedRequest.unitMatched)
		{
			selectedRequest.Status = "complete";
			BloodPlateletRequestUserDB.updateBloodPlateles(selectedRequest);
			gvRequestInfo.DataBind();
		}
	}

	protected void gvAcceptedUserRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvAcceptedUserRequests.PageIndex = e.NewPageIndex;
		gvAcceptedUserRequests.DataSource = usersAccepted;
		gvAcceptedUserRequests.DataBind();
	}

	protected void gvAcceptedEstabRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvAcceptedEstabRequests.PageIndex = e.NewPageIndex;
		gvAcceptedEstabRequests.DataSource = estabsAccepted;
		gvAcceptedEstabRequests.DataBind();
	}

	protected void lbtnReport_Click(object sender, EventArgs e)
	{
		LinkButton lbtn = (LinkButton)sender;
		GridViewRow gvr = (GridViewRow)lbtn.NamingContainer;
		int i = Convert.ToInt32(gvr.RowIndex);
		BloodPlateletRequestUser selectedRequest = userRequests[gvRequestInfo.PageSize * gvRequestInfo.PageIndex + gvRequestInfo.SelectedIndex];
		List<BplTransactionUserToUser> allUserTransactions = BplTransactionUserToUserDB.getAllbpTransUserToUser();
		foreach (BplTransactionUserToUser m in allUserTransactions)
		{
			if (m.bpMatchUsrUsr.bplUsrRequestID.bplUserRequestID == selectedRequest.bplUserRequestID && m.status == "accepted")
			{
				usersAccepted.Add(m);

			}
		}
		BplTransactionUserToUser selectedTransaction = usersAccepted[i];
		Users reportedUser = selectedTransaction.bpMatchUsrUsr.matchID;
		reportedUser.MedicalStatus = "cannot donate";
		reportedUser.MedicalStatusUpdateBy = ((Establishment)Session["establishment"]).ID;
		UsersDB.updateUser(reportedUser);
		List<LastDonationDate> allLastDates = LastDonationDateDB.getAllLastDonations();
		foreach (LastDonationDate ld in allLastDates)
		{
			if (ld.User.UserId == reportedUser.userId)
			{
				ld.LastDonation = DateTime.Today;
				ld.Type = selectedRequest.bloodOrPlatelet;
				ld.Status = "Not in transaction";
				LastDonationDateDB.updateLastDonation(ld);
			}
		}

		selectedTransaction.status = "cancelled";
		BplTransactionUserToUserDB.updateBPTranscationUserToUser(selectedTransaction);

		selectedTransaction.bpMatchUsrUsr.status = "declined";
		BPMatchUserToUserDB.updateMatchUserToUser(selectedTransaction.bpMatchUsrUsr);

		selectedRequest.unitMatched = selectedRequest.unitMatched - selectedTransaction.unitsPossible;
		BloodPlateletRequestUserDB.updateBloodPlateles(selectedRequest);
		Server.Transfer("UserDonations.aspx");

	}
}