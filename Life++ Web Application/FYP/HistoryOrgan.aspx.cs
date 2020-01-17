using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HistoryOrgan : System.Web.UI.Page
{
	string tempid, id;
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
				Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
				List<LiveDonor> ldlist = LiveDonorDB.getLiveDonorbyuserID(u.userId);
				if (ldlist.Count == 0)
				{
					Label1.Text = "Sorry! You doesn't have any current organ donation!";
					PanelFinishRegister.Visible = false;
				}
				else
				{
					foreach (LiveDonor l in ldlist)
					{
						if (l.status == "not allotted" || l.status == "allotted")
						{
							tempid = l.ldonorID;
							PanelFinishRegister.Visible = true;
							break;
						}
						else
						{
							tempid = "0";
						}

					}
					if (tempid == "0")
					{
						Label1.Text = "Sorry! You doesn't have any current organ donation!";
						PanelFinishRegister.Visible = false;
					}
					else
					{
						LiveDonor ld = LiveDonorDB.getLiveDonorbyID(tempid);

						PanelFinishRegister.Visible = true;
						lblComment.Text = ld.comments;
						lblDAddress.Text = ld.doctorAddress;
						lblDEmail.Text = ld.doctorEmail;
						lblDoctor.Text = ld.doctorName;
						lblDPhone.Text = Convert.ToString(ld.doctorNumber);
						lblOrgan.Text = ld.organType;
						lblstatus.Text = ld.status;
					}

				}

				List<LiveOrganMatching> lom = LiveOrganMatchingDB.getAllMatches();
				List<LiveOrganMatching> lomshow = new List<LiveOrganMatching>();
				if (lom.Count == 0)
				{
					lblmatchingF.Text = "Sorry! We haven't found any matching for you right now.";
					gvMatch.Visible = false;
				}
				else
				{
					foreach (LiveOrganMatching l in lom)
					{
						if (l.LiveDonor.userid.UserId == u.UserId && l.Status == "current match")
						{
							l.Distance = l.Distance / 60;
							lomshow.Add(l);
						}
					}

					if (lomshow.Count == 0)
					{
						lblmatchingF.Text = "Sorry! We haven't found any matching for you right now.";
						panelmatching.Visible = false;
					}
					else
					{
						panelmatching.Visible = true;
						gvMatch.DataSource = lomshow;
						gvMatch.DataBind();
					}
				}
			}
		}
	}


	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
		List<LiveDonor> ldlist = LiveDonorDB.getLiveDonorbyuserID(u.userId);
		foreach (LiveDonor l in ldlist)
		{
			if (l.status == "not allotted")
			{
				id = l.ldonorID;
				break;
			}

		}
		if (id != null)
		{
			LiveDonor nowld = LiveDonorDB.getLiveDonorbyID(id);

			nowld.status = "cancelled";
			int num = LiveDonorDB.updateLiveDonor(nowld);
			if (num != 1)
				lblDOutput.Text = "Sorry cancel Failed!";
			else
			{
				lblDOutput.Text = "Your organ donation is now cancelled!";
				string DonateOrganUrl = "DonateOrgan.aspx";
				Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", DonateOrganUrl)));
			}
		}
		else
			lblDOutput.Text = "Sorry cancel Failed!";

	}


	protected void gvMatch_SelectedIndexChanged(object sender, EventArgs e)
	{
		List<LiveOrganMatching> lom = LiveOrganMatchingDB.getAllMatches();
		List<LiveOrganMatching> lomshow = new List<LiveOrganMatching>();
		Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
		foreach (LiveOrganMatching l in lom)
		{
			if (l.LiveDonor.userid.UserId == u.UserId && l.Status == "current match")
			{
				l.Distance = l.Distance / 60;
				lomshow.Add(l);
			}
		}

		if (lomshow.Count == 0)
		{
			lblmatchingF.Text = "Sorry! We haven't found any matching for you right now.";
			panelmatching.Visible = false;
		}
		else
		{
			panelmatching.Visible = true;
			LiveOrganMatching lo = lomshow[gvMatch.PageSize * gvMatch.PageIndex + gvMatch.SelectedIndex];
			Session["chat"] = null;
			Session["echat"] = lo.Recipient.Establishment.ID;
			Server.Transfer("IndividualChatUU.aspx");
		}

	}
}