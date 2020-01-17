using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EstForum : System.Web.UI.Page
{

	Establishment currente = new Establishment();
	List<ForumUser> flist = new List<ForumUser>();
	List<ForumEstablishment> elist = new List<ForumEstablishment>();
	List<Chat> clist2;
	int cnum = 0, cnumup = 0;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("Login.aspx");
		}
		else
		{

			tbxChat.Text = "";
			List<Chat> clist = ChatDB.getallChat();
			foreach (Chat ch in clist)
			{
				Users s = UsersDB.getUserbyID(ch.by);
				if (s.email == null)
				{
					Establishment es = EstablishmentDB.getEstablishmentByID(ch.by);
					if (ch.status == "allow")
						tbxChat.Text += es.Name + " @ " + ch.time + " : " + ch.message + "\r\n";
				}
				else
				{
					if (ch.status == "allow")
						tbxChat.Text += s.username + " @ " + ch.time + " : " + ch.message + "\r\n";
				}
			}
			cnum = clist.Count;


			currente = (Establishment)(Session["establishment"]);
			lblOutputPost.Text = "";
			List<ForumUser> flist = ForumUserDB.getAllForumUserbyStatus();

			if (flist.Count == 0)
			{
				Panel1.Visible = false;
				lblGVOutput.Text = "There is no forum posted by user right now!";
			}
			else
			{
				Panel1.Visible = true;
				gvUser.DataSource = flist;
				gvUser.DataBind();
				lblGVOutput.Text = "";
			}

			List<ForumEstablishment> elist = ForumEstablishmentDB.getAllForumEstbyStatus();

			if (elist.Count == 0)
			{
				Panel2.Visible = false;
				lblGVEstOutput.Text = "There is no forum posted by establishment right now!";
			}
			else
			{
				lblGVEstOutput.Text = "";
				Panel2.Visible = true;
				gvEst.DataSource = elist;
				gvEst.DataBind();
			}
		}

	}

	protected void btnFpost_Click(object sender, EventArgs e)
	{
		if (tbxFtitle.Text == "")
		{
			lblOutputPost.Text = "Title cannot to blank";
			return;
		}
		else if (tbxFmessage.Text == "")
		{
			lblOutputPost.Text = "Message cannot to blank";
			return;
		}
		else
		{
			Establishment es = (Establishment)Session["establishment"];
			ForumEstablishment fu = new ForumEstablishment(tbxFtitle.Text ,tbxFmessage.Text, DateTime.Now, "allow",es);
			int num = ForumEstablishmentDB.insertForum(fu);
			if (num != 1)
			{
				lblOutputPost.Text = "Cannot Post Forum Right Now!";
				return;
			}
			else
			{
				lblOutputPost.Text = "Successfully Posted!";
				lblGVOutput.Text = "";
				tbxFmessage.Text = "";
				tbxFtitle.Text = "";
				Panel1.Visible = true;
				elist = ForumEstablishmentDB.getAllForumEstbyStatus();
				gvEst.DataSource = elist;
				gvEst.DataBind();
			}
		}

	}

	protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		List<ForumUser> flist = ForumUserDB.getAllForumUserbyStatus();
		gvUser.PageIndex = e.NewPageIndex;
		gvUser.DataSource = flist;
		gvUser.DataBind();

	}
	protected void gvUser_SelectedIndexChanged1(object sender, EventArgs e)
	{
		List<ForumUser> flist = ForumUserDB.getAllForumUserbyStatus();
		ForumUser afa = flist[gvUser.PageSize * gvUser.PageIndex + gvUser.SelectedIndex];
		Session["hyper"] = afa.forumID;
		Session["hyper1"] = "1";
		Server.Transfer("ForumCommentE.aspx");
	}

	protected void gvEst_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		List<ForumEstablishment> elist = ForumEstablishmentDB.getAllForumEstbyStatus();
		gvEst.PageIndex = e.NewPageIndex;
		gvEst.DataSource = elist;
		gvEst.DataBind();
	}
	protected void gvEst_SelectedIndexChanged1(object sender, EventArgs e)
	{
		List<ForumEstablishment> elist = ForumEstablishmentDB.getAllForumEstbyStatus();
		ForumEstablishment afa = elist[gvEst.PageSize * gvEst.PageIndex + gvEst.SelectedIndex];
		Session["hyper1"] = afa.forumID;
		Session["hyper"] = "1";
		Server.Transfer("ForumCommentE.aspx");
	}

	protected void BtnSentMessage_Click(object sender, EventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];
		Chat c = new Chat(tbxMessage.Text, es.ID, System.DateTime.Now, "allow");
		ChatDB.insertChat(c);
		tbxMessage.Text = "";
		Server.Transfer("EstForum.aspx");
	}

	protected void Timer1_Tick1(object sender, EventArgs e)
	{
		UpdatePanel1.Update();
	}

}