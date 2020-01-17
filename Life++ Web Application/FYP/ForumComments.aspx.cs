using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForumComments : System.Web.UI.Page
{
    List<tempcomment> tclist = new List<tempcomment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null)
        {
            Server.Transfer("CommonLogin.aspx");
        }
        else
        {
			//hyper1 is from establishment forum and hyper is from user forum
            if (Session["hyper"].ToString() == "1")
            {
                if (Session["hyper1"].ToString() == "1")
                {
                    Server.Transfer("Dashboard.aspx");
                }
                else
                {
                    lblNotFound.Visible = false;
                    ForumEstablishment fe = ForumEstablishmentDB.getForumEstbyID(Session["hyper1"].ToString());
                    lblheading.Text = "ForumID: #" + fe.forumID;
                    List<ForumEstablishment> felist = new List<ForumEstablishment>();
                    felist.Add(fe);

                    lbltitle.Text = fe.Title;
                    lblmessage.Text = fe.message;
                    lblUser.Text = fe.estID.ID;
                    lblDate.Text = string.Format("{0:dd/MM/yyyy}", fe.date);

                    List<ForumEstCommentbyUser> fecu = ForumEstCommentbyUserDB.getoneForumAllCommentbyID(fe.forumID);
                    List<ForumEstCommentbyEst> fece = ForumEstCommentbyEstDB.getoneForumAllCommentbyID(fe.forumID);

                    foreach (ForumEstCommentbyUser f in fecu)
                    {
                        tempcomment tc = new tempcomment();
                        tc.comment = f.comments;
                        tc.commentby = f.commentby.Name.ToString();
                        tc.time = f.date;
                        tc.timeshow = datesub(f.date);
                        if (f.status == "allow")
                            tclist.Add(tc);
                    }

                    foreach (ForumEstCommentbyEst g in fece)
                    {
                        tempcomment tc = new tempcomment();
                        tc.comment = g.comments;
                        tc.commentby = g.commentby.Name.ToString();
                        tc.time = g.date;
                        tc.timeshow = datesub(g.date);
                        if (g.status == "allow")
                        tclist.Add(tc);
                    }

                    if (tclist.Count == 0)
                    {
                        lblNotFound.Visible = true;
                        lblNotFound.Text = "There is no comment";
                        PanelCMT.Visible = false;
                    }
                    else
                    {
                        tclist = tclist.OrderBy(x => x.time).ToList();
                        tclist.Reverse();
                        lblNotFound.Text = "";
                        PanelCMT.Visible = true;
                        GridView1.DataSource = tclist;
                        GridView1.DataBind();
                    }

                }

            }
            else
            {

                ForumUser fu = ForumUserDB.getForumUserbyID(Session["hyper"].ToString());
                lblheading.Text = "ForumID: #" + fu.forumID;
                List<ForumUser> flist = new List<ForumUser>();
                flist.Add(fu);

                lbltitle.Text = fu.Title;
                lblmessage.Text = fu.message;
                lblUser.Text = fu.userID.username;
                lblDate.Text = string.Format("{0:dd/MM/yyyy}", fu.date);

                List<ForumUserCommentbyEst> fuce = ForumUserCommentbyEstDB.getoneForumAllCommentbyID(fu.forumID);
                List<ForumUserCommentbyUser> fucu = ForumUserCommentbyUserDB.getoneForumAllCommentbyID(fu.forumID);

                foreach (ForumUserCommentbyEst f in fuce)
                {
                    tempcomment tc = new tempcomment();
                    tc.comment = f.comments;
                    tc.commentby = f.commentby.Name.ToString();
                    tc.time = f.date;
                    tc.timeshow = datesub(f.date);
                    if (f.status == "allow")
                    tclist.Add(tc);
                }

                foreach (ForumUserCommentbyUser g in fucu)
                {
                    tempcomment tc = new tempcomment();
                    tc.comment = g.comments;
                    tc.commentby = g.commentby.username.ToString();
                    tc.time = g.date;
                    tc.timeshow = datesub(g.date);
                    if (g.status == "allow")
                    tclist.Add(tc);
                }

                if (tclist.Count == 0)
                {
                    lblNotFound.Visible = true;
                    lblNotFound.Text = "There is no comment";
                    PanelCMT.Visible = false;
                }
                else
                {
                    tclist = tclist.OrderBy(x => x.time).ToList();
                    tclist.Reverse();
                    lblNotFound.Text = "";
                    PanelCMT.Visible = true;
                    GridView1.DataSource = tclist;
                    GridView1.DataBind();
                }

            }
        }

    }

    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        if (tbxComment.Text == "")
        {
            lbloutput.Text = "The Comment field cannot be blank.";
            return;
        }
        else
        {
            lbloutput.Text = "";

            if (Session["hyper1"].ToString() == "1")
            {
                ForumUser fu = ForumUserDB.getForumUserbyID(Session["hyper"].ToString());
                Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
                ForumUserCommentbyUser fuc = new ForumUserCommentbyUser(fu, tbxComment.Text, u, System.DateTime.Now, "allow");
                int num = ForumUserCommentbyUserDB.insertForumCommentUser(fuc);
                if (num != 1)
                {
                    lbloutput.Text = "Fail to comment!";
                    return;
                }
                else
                {
                    Response.Redirect("ForumComments.aspx", true);
                }
            }
            else
            {
                ForumEstablishment fe = ForumEstablishmentDB.getForumEstbyID(Session["hyper1"].ToString());
                Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
                ForumEstCommentbyUser fec = new ForumEstCommentbyUser(fe, tbxComment.Text, u, System.DateTime.Now, "allow");
                int num = ForumEstCommentbyUserDB.insertForumCommentUser(fec);
                if (num != 1)
                {
                    lbloutput.Text = "Fail to comment!";
                    return;
                }
                else
                {
                    Response.Redirect("ForumComments.aspx", true);
                }
            }
        }
    }

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


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}

