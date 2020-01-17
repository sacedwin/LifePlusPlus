using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeceasedDonors : System.Web.UI.Page
{
	List<DeceasedDonor> ourDonors = new List<DeceasedDonor>();

	protected void Page_Load(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<DeceasedDonor> allDonors = DeceasedDonorDB.getAllDeceasedDonors();
		bool donorFound = false;
		foreach (DeceasedDonor d in allDonors)
		{
			if (d.Establishment.ID == currentEstab.ID && (d.Status == "allotted" || d.Status == "not allotted"))
			{
				ourDonors.Add(d);
				donorFound = true;
			}
		}
		if (donorFound == true)
		{
			gvDeceased.DataSource = ourDonors;
			gvDeceased.DataBind();
		}
		else
			lblOutput.Text = "There are currently no organs available from deceased donors";
	}

	protected void btnAddOrgan_Click(object sender, EventArgs e)
	{
		Server.Transfer("AddDeceasedDonor.aspx");
	}

	protected void gvDeceased_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<DeceasedDonor> allDonors = DeceasedDonorDB.getAllDeceasedDonors();
		foreach (DeceasedDonor d in allDonors)
		{
			if (d.Establishment.ID == currentEstab.ID && (d.Status == "allotted" || d.Status == "not allotted"))
			{
				ourDonors.Add(d);
			}
		}
		gvDeceased.PageIndex = e.NewPageIndex;
		gvDeceased.DataSource = ourDonors;
		gvDeceased.DataBind();
	}



	protected void gvDeceased_SelectedIndexChanged(object sender, EventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<DeceasedDonor> allDonors = DeceasedDonorDB.getAllDeceasedDonors();
		foreach (DeceasedDonor d in allDonors)
		{
			if (d.Establishment.ID == currentEstab.ID && (d.Status == "allotted" || d.Status == "not allotted"))
			{
				ourDonors.Add(d);
			}
		}
		DeceasedDonor currentDonor = ourDonors[gvDeceased.PageSize * gvDeceased.PageIndex + gvDeceased.SelectedIndex];
		DeceasedOrganMatching currentMatch = new DeceasedOrganMatching();
		bool matchFound = false;
		List<DeceasedOrganMatching> allMatches = DeceasedOrganMatchingDB.getAllMatches();
		foreach (DeceasedOrganMatching d in allMatches)
		{
			if ((d.DeceasedDonor.ID == currentDonor.ID) && d.Status == "current match")
			{
				matchFound = true;
				currentMatch = d;
			}
		}
		if (matchFound == false)
		{
			lblOutput.Text = "Sorry no match found!";
			pnlMatch.Visible = false;
		}
		else
		{
			try
			{
				pnlMatch.Visible = true;
				lblEstab.Text = currentMatch.Recipient.Establishment.Name;
				Session["est"] = currentMatch.Recipient.Establishment.ID;
				lblBloodType.Text = currentMatch.Recipient.Bloodgroup;
				lblAge.Text = Convert.ToString(currentMatch.Recipient.DOB);
				lblHeightWeight.Text = currentMatch.Recipient.Height + " / " + currentMatch.Recipient.Weight;
				lblWaiting.Text = Convert.ToString((DateTime.Today - currentMatch.Recipient.Addedon).TotalDays);
				lblComments.Text = currentMatch.Recipient.Comments;
				lblUrgency.Text = Convert.ToString(currentMatch.Recipient.Urgency);
				lblMatchScore.Text = Convert.ToString(currentMatch.MatchScore);
				tbxMatchComments.Text = currentMatch.Comments;
				lblDistance.Text = Convert.ToString(currentMatch.Distance);
			}
			catch
			{ lblOutput.Text = "Please Check The Entered Values"; }
		}

	}


	protected void Button2_Click(object sender, EventArgs e)
	{
		Establishment es = EstablishmentDB.getEstablishmentByID(Session["est"].ToString());
		Session["echat"] = es.ID;
		Session["rwEst"] = null;
		Session["ldID"] = null;
		Server.Transfer("IndividualChatE.aspx");
	}



	protected void gvDeceased_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		Establishment currentEstab = (Establishment)Session["establishment"];
		List<DeceasedDonor> allDonors = DeceasedDonorDB.getAllDeceasedDonors();
		foreach (DeceasedDonor d in allDonors)
		{
			if (d.Establishment.ID == currentEstab.ID && (d.Status == "allotted" || d.Status == "not allotted"))
			{
				ourDonors.Add(d);
			}
		}
		DeceasedDonor currentDonor = ourDonors[gvDeceased.PageSize * gvDeceased.PageIndex + e.RowIndex];
		if (currentDonor.Status != "alotted")
		{
			currentDonor.Status = "invalid";
			DeceasedDonorDB.updateDeceasedDonor(currentDonor);
			Server.Transfer("DeceasedDonors.aspx");
		}
		else
			lblOutput.Text = "This donor cannot be deleted!";
	}
}