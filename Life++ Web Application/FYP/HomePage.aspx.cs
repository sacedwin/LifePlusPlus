using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["email"] == null)
			Button1.Enabled = true;
		else
			Button1.Enabled = false;
		int num = 0, esnum = 0, btc = 0,numo=0;
		List<Users> userslist = UsersDB.getallUsers();
		num = userslist.Count;
		lblTotalUsers.Text = num.ToString();
		lblOutput.Text = "";
		List<Establishment> estlist = EstablishmentDB.getAllEstablishments();
		esnum = estlist.Count;
		lblTotalAssociates.Text = esnum.ToString();

		List<GReportBloodPlatelet> listEE = GReportBloodPlateletDB.HgetAllBloodEToE();
		List<GReportBloodPlatelet> listEU = GReportBloodPlateletDB.HgetAllBloodEToU();
		List<GReportBloodPlatelet> listUE = GReportBloodPlateletDB.HgetAllBloodUToE();
		List<GReportBloodPlatelet> listUU = GReportBloodPlateletDB.HgetAllBloodUToU();
		btc = listEE.Count + listEU.Count + listUE.Count + listUU.Count;
		lblSuccessfulBloodDonation.Text = btc.ToString();

		List<OrganRecipient> orlist = OrganRecipientDB.getAllRecipients();
		foreach (OrganRecipient o in orlist)
		{
			if (o.Status == "complete")
				numo++;
		}
		lblOrganDonation.Text = numo.ToString();
	}

	protected void btnFeedback_Click(object sender, EventArgs e)
	{
		string fname = tbxFName.Text;
		string femail = tbxFEmail.Text;
		string fsubject = tbxFSubject.Text;
		string fmessage = tbxMessage.Text;
		Feedback newfb = new Feedback(fname, femail, fsubject, fmessage, "null", "unanswered", "null");
		int num = FeedbackDB.insertFeedback(newfb);
		if (num != -1)
		{
			lblOutput.Text = "Message succefully sent!";
			tbxFEmail.Text = "";
			tbxFName.Text = "";
			tbxFSubject.Text = "";
			tbxMessage.Text = "";
		}
		else
		{
			lblOutput.Text = "Fail to sent message";
		}



	}
	protected void Button1_Click(object sender, EventArgs e)
	{

		Server.Transfer("CommonLogin.aspx");
	}
}