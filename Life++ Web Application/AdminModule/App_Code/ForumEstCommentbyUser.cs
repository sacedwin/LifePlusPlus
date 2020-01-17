using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumEstCommentbyUser
/// </summary>
public class ForumEstCommentbyUser
{
	public string forumcommentID { get; set; }
    public ForumEstablishments forumID { get; set; }
    public string comments { get; set; }
    public AUser commentby { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }

    public ForumEstCommentbyUser()
    {
       
    }

    public ForumEstCommentbyUser(ForumEstablishments forumID, string comments, AUser commentby, DateTime date, string status)
    {
        this.forumID = forumID;
        this.comments = comments;
        this.commentby = commentby;
        this.date = date;
        this.status = status;
    }
}