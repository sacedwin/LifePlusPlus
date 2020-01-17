using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumUserCommentbyEst
/// </summary>
public class ForumUserCommentbyEst
{
	public string forumcommentID { get; set; }
    public ForumUser forumID { get; set; }
    public string comments { get; set; }
    public Establishment commentby { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }

    public ForumUserCommentbyEst()
    {
       
    }

    public ForumUserCommentbyEst(ForumUser forumID, string comments, Establishment commentby, DateTime date,string status)
    {
        this.forumID = forumID;
        this.comments = comments;
        this.commentby = commentby;
        this.date = date;
        this.status = status;
    }
}