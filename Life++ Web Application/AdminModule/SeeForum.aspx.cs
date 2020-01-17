using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminModule_SeeForum : System.Web.UI.Page
{
	List<AForumUser> allflist = new List<AForumUser>();
	List<ForumEstablishments> allelist = new List<ForumEstablishments>();
	List<tempcomment> tclist = new List<tempcomment>();
	bool efound, ufound;

	protected void Page_Load(object sender, EventArgs e)
	{


	}

	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddlFBChoose.SelectedIndex == 0)
		{
			panelEst.Visible = false;
			panelUser.Visible = false;
			Panel1.Visible = false;
			lblSelectError.Text = "";

		}

		else if (ddlFBChoose.SelectedIndex == 1)
		{
			allflist = AForumUserDB.getAllForumUser();

			if (allflist.Count == 0)
			{
				lblSelectError.Text = "Sorry there is no forum by User found in the moment!";
				panelUser.Visible = false;
				panelEst.Visible = false;
			}
			else
			{
				panelUser.Visible = true;
				panelEst.Visible = false;
				Panel1.Visible = false;
				gvUser.DataSource = allflist;
				gvUser.DataBind();
				lblSelectError.Text = "The are " + allflist.Count + " Forum posted by Users found!";
				Session["u"] = "user";
				Session["e"] = null;
			}
		}
		else
		{
			allelist = ForumEstablishmentsDB.getAllForumEstablishment();

			if (allelist.Count == 0)
			{
				lblSelectError.Text = "Sorry there is no forum by Establishment found in the moment!";
				panelUser.Visible = false;
				panelEst.Visible = false;
			}
			else
			{
				panelUser.Visible = false;
				panelEst.Visible = true;
				Panel1.Visible = false;
				gvEst.DataSource = allelist;
				gvEst.DataBind();
				lblSelectError.Text = "The are " + allelist.Count + " Forum posted by Establishment found!";
				Session["u"] = null;
				Session["e"] = "est";
			}
		}
	}

	protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		allflist = AForumUserDB.getAllForumUser();
		AForumUser af = allflist[gvUser.PageSize * gvUser.PageIndex + e.RowIndex];
		if (af.status == "allow")
			af.status = "ban";
		else
			af.status = "allow";
		AForumUserDB.updateUserForum(af);
		allflist = AForumUserDB.getAllForumUser();
		gvUser.DataSource = allflist;
		gvUser.DataBind();
	}

	protected void gvUser_SelectedIndexChanged1(object sender, EventArgs e)
	{
		List<tempcomment> tclist = new List<tempcomment>();
		Panel1.Visible = true;
		allflist = AForumUserDB.getAllForumUser();
		AForumUser fu = allflist[gvUser.PageSize * gvUser.PageIndex + gvUser.SelectedIndex];
		Session["forumID"] = fu.forumID;
		gvUser.SelectedIndex = -1;
		lbltitle.Text = fu.Title;
		lblmessage.Text = fu.message;
		lblUser.Text = fu.userID.username;
		lblDate.Text = string.Format("{0:dd/MM/yyyy}", fu.date);

		List<ForumUserCommentbyEst> fuce = ForumUserCommentbyEstDB.getoneForumAllCommentbyID(fu.forumID);
		List<ForumUserCommentbyUser> fucu = ForumUserCommentbyUserDB.getoneForumAllCommentbyID(fu.forumID);

		foreach (ForumUserCommentbyEst f in fuce)
		{
			tempcomment tc = new tempcomment();
			tc.comentID = f.forumcommentID;
			tc.comment = f.comments;
			tc.commentby = f.commentby.Name.ToString();
			tc.time = f.date;
			tc.status = f.status;
			tc.timeshow = datesub(f.date);
			tclist.Add(tc);
		}

		foreach (ForumUserCommentbyUser g in fucu)
		{
			tempcomment tc = new tempcomment();
			tc.comentID = g.forumcommentID;
			tc.comment = g.comments;
			tc.commentby = g.commentby.username.ToString();
			tc.time = g.date;
			tc.status = g.status;
			tc.timeshow = datesub(g.date);
			tclist.Add(tc);
		}

		if (tclist.Count == 0)
		{
			lblNotFound.Visible = true;

		}
		else
		{
			tclist = tclist.OrderBy(x => x.time).ToList();
			tclist.Reverse();
			lblNotFound.Visible = false;
			GridView1.DataSource = tclist;
			GridView1.DataBind();
		}
	}

	protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		allflist = AForumUserDB.getAllForumUser();
		gvUser.PageIndex = e.NewPageIndex;
		gvUser.DataSource = allflist;
		gvUser.DataBind();
	}

	protected void gvEst_SelectedIndexChanged1(object sender, EventArgs e)
	{
		List<tempcomment> tclist = new List<tempcomment>();
		Panel1.Visible = true;
		allelist = ForumEstablishmentsDB.getAllForumEstablishment();
		ForumEstablishments fe = allelist[gvEst.PageSize * gvEst.PageIndex + gvEst.SelectedIndex];
		gvEst.SelectedIndex = -1;
		Session["forumID"] = fe.forumID;
		lbltitle.Text = fe.Title;
		lblmessage.Text = fe.message;
		lblUser.Text = fe.estID.ID;
		lblDate.Text = string.Format("{0:dd/MM/yyyy}", fe.date);

		List<ForumEstCommentbyUser> fecu = ForumEstCommentbyUserDB.getoneForumAllCommentbyID(fe.forumID);
		List<ForumEstCommentbyEst> fece = ForumEstCommentbyEstDB.getoneForumAllCommentbyID(fe.forumID);

		foreach (ForumEstCommentbyUser f in fecu)
		{
			tempcomment tc = new tempcomment();
			tc.comentID = f.forumcommentID;
			tc.comment = f.comments;
			tc.commentby = f.commentby.name.ToString();
			tc.time = f.date;
			tc.status = f.status;
			tc.timeshow = datesub(f.date);
			tclist.Add(tc);
		}

		foreach (ForumEstCommentbyEst g in fece)
		{
			tempcomment tc = new tempcomment();
			tc.comentID = g.forumcommentID;
			tc.comment = g.comments;
			tc.commentby = g.commentby.Name.ToString();
			tc.time = g.date;
			tc.status = g.status;
			tc.timeshow = datesub(g.date);
			tclist.Add(tc);
		}

		if (tclist.Count == 0)
		{
			lblNotFound.Visible = true;

		}
		else
		{
			tclist = tclist.OrderBy(x => x.time).ToList();
			tclist.Reverse();
			lblNotFound.Visible = false;
			GridView1.DataSource = tclist;
			GridView1.DataBind();
		}

	}
	protected void gvEst_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		allelist = ForumEstablishmentsDB.getAllForumEstablishment();
		gvEst.PageIndex = e.NewPageIndex;
		gvEst.DataSource = allelist;
		gvEst.DataBind();
	}


	protected void gvEst_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		allelist = ForumEstablishmentsDB.getAllForumEstablishment();
		ForumEstablishments fe = allelist[gvEst.PageSize * gvEst.PageIndex + e.RowIndex];
		if (fe.status == "allow")
			fe.status = "ban";
		else
			fe.status = "allow";
		ForumEstablishmentsDB.updateEstForum(fe);
		allelist = ForumEstablishmentsDB.getAllForumEstablishment();
		gvEst.DataSource = allelist;
		gvEst.DataBind();
	}


	//check the date system date time insert and convert it to show like 1 hr ago or just now string.
	public string datesub(DateTime date)
	{
		TimeSpan timeSince = System.DateTime.Now.Subtract(date);

		if (timeSince.TotalMilliseconds < 1)
			return "not yet";
		if (timeSince.TotalMinutes < 1)
			return "just now";
		if (timeSince.TotalMinutes < 2)
			return "1 minute ago";
		if (timeSince.TotalMinutes < 60)
			return string.Format("{0} minutes ago", timeSince.Minutes);
		if (timeSince.TotalMinutes < 120)
			return "1 hour ago";
		if (timeSince.TotalHours < 24)
			return string.Format("{0} hours ago", timeSince.Hours);
		if (timeSince.TotalDays == 1)
			return "yesterday";
		if (timeSince.TotalDays < 7)
			return string.Format("{0} days ago", timeSince.Days);
		if (timeSince.TotalDays < 14)
			return "last week";
		if (timeSince.TotalDays < 21)
			return "2 weeks ago";
		if (timeSince.TotalDays < 28)
			return "3 weeks ago";
		if (timeSince.TotalDays < 60)
			return "last month";
		if (timeSince.TotalDays < 365)
			return string.Format("{0} months ago", Math.Round(timeSince.TotalDays / 30));
		if (timeSince.TotalDays < 730)
			return "last year";
		return string.Format("{0} years ago", Math.Round(timeSince.TotalDays / 365));
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string id = GridView1.SelectedRow.Cells[0].Text;
		int enumber = 0, unumber = 0;
		if (ddlFBChoose.SelectedIndex == 1)
		{
			List<ForumUserCommentbyEst> uelist = ForumUserCommentbyEstDB.getAlloneForumAllComment();
			List<ForumUserCommentbyUser> uulist = ForumUserCommentbyUserDB.getalloneForumAllComment();
			foreach (ForumUserCommentbyEst ue in uelist)
			{
				if (ue.forumcommentID == id)
				{
					ufound = true;
					unumber = 1;
					break;
				}
				else
					efound = false;
			}

			if (efound == false)
			{
				foreach (ForumUserCommentbyUser uu in uulist)
				{
					if (uu.forumcommentID == id)
					{
						efound = true;
						unumber = 2;
						break;
					}
					else
						efound = false;
				}
			}

			if (unumber == 1)
			{
				ForumUserCommentbyEst uecomment = ForumUserCommentbyEstDB.getoneForumCommentbyID(id);
				if (uecomment.status == "allow")
					uecomment.status = "ban";
				else
					uecomment.status = "allow";
				ForumUserCommentbyEstDB.updateComment(uecomment);
			}
			else
			{
				ForumUserCommentbyUser uucomment = ForumUserCommentbyUserDB.getoneForumCommentbyID(id);
				if (uucomment.status == "allow")
					uucomment.status = "ban";
				else
					uucomment.status = "allow";
				ForumUserCommentbyUserDB.updateComment(uucomment);
			}

		}
		else
		{
			List<ForumEstCommentbyEst> eelist = ForumEstCommentbyEstDB.getalloneForumAllComment();
			List<ForumEstCommentbyUser> eulist = ForumEstCommentbyUserDB.getalloneForumAllComment();
			foreach (ForumEstCommentbyEst ee in eelist)
			{
				if (ee.forumcommentID == id)
				{
					efound = true;
					enumber = 1;
					break;
				}
				else
					efound = false;
			}

			if (efound == false)
			{
				foreach (ForumEstCommentbyUser eu in eulist)
				{
					if (eu.forumcommentID == id)
					{
						efound = true;
						enumber = 2;
						break;
					}
					else
						efound = false;
				}
			}

			if (enumber == 1)
			{
				ForumEstCommentbyEst eecomment = ForumEstCommentbyEstDB.getoneForumCommentbyID(id);
				if (eecomment.status == "allow")
					eecomment.status = "ban";
				else
					eecomment.status = "allow";
				ForumEstCommentbyEstDB.updateComment(eecomment);
			}
			else
			{
				ForumEstCommentbyUser eucomment = ForumEstCommentbyUserDB.getoneForumCommentbyID(id);
				if (eucomment.status == "allow")
					eucomment.status = "ban";
				else
					eucomment.status = "allow";
				ForumEstCommentbyUserDB.updateComment(eucomment);
			}

		}

		//delete the individual comment on each forum
		if (Session["u"] != null)
		{
			List<tempcomment> tclist = new List<tempcomment>();
			List<ForumUserCommentbyEst> fuce = ForumUserCommentbyEstDB.getoneForumAllCommentbyID(Session["forumID"].ToString());
			List<ForumUserCommentbyUser> fucu = ForumUserCommentbyUserDB.getoneForumAllCommentbyID(Session["forumID"].ToString());

			foreach (ForumUserCommentbyEst f in fuce)
			{
				tempcomment tc = new tempcomment();
				tc.comentID = f.forumcommentID;
				tc.comment = f.comments;
				tc.commentby = f.commentby.Name.ToString();
				tc.time = f.date;
				tc.status = f.status;
				tc.timeshow = datesub(f.date);
				tclist.Add(tc);
			}

			foreach (ForumUserCommentbyUser g in fucu)
			{
				tempcomment tc = new tempcomment();
				tc.comentID = g.forumcommentID;
				tc.comment = g.comments;
				tc.commentby = g.commentby.username.ToString();
				tc.time = g.date;
				tc.status = g.status;
				tc.timeshow = datesub(g.date);
				tclist.Add(tc);
			}

			if (tclist.Count == 0)
			{
				lblNotFound.Visible = true;

			}
			else
			{
				tclist = tclist.OrderBy(x => x.time).ToList();
				tclist.Reverse();
				lblNotFound.Visible = false;
				GridView1.DataSource = tclist;
				GridView1.DataBind();
			}
		}
		else
		{
			List<ForumEstCommentbyUser> fecu = ForumEstCommentbyUserDB.getoneForumAllCommentbyID(Session["forumID"].ToString());
			List<ForumEstCommentbyEst> fece = ForumEstCommentbyEstDB.getoneForumAllCommentbyID(Session["forumID"].ToString());

			foreach (ForumEstCommentbyUser f in fecu)
			{
				tempcomment tc = new tempcomment();
				tc.comentID = f.forumcommentID;
				tc.comment = f.comments;
				tc.commentby = f.commentby.name.ToString();
				tc.time = f.date;
				tc.status = f.status;
				tc.timeshow = datesub(f.date);
				tclist.Add(tc);
			}

			foreach (ForumEstCommentbyEst g in fece)
			{
				tempcomment tc = new tempcomment();
				tc.comentID = g.forumcommentID;
				tc.comment = g.comments;
				tc.commentby = g.commentby.Name.ToString();
				tc.time = g.date;
				tc.status = g.status;
				tc.timeshow = datesub(g.date);
				tclist.Add(tc);
			}

			if (tclist.Count == 0)
			{
				lblNotFound.Visible = true;

			}
			else
			{
				tclist = tclist.OrderBy(x => x.time).ToList();
				tclist.Reverse();
				lblNotFound.Visible = false;
				GridView1.DataSource = tclist;
				GridView1.DataBind();
			}
		}

	}
}