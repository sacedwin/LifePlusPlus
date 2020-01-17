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
    public ForumEstablishment forumID { get; set; }
    public string comments { get; set; }
    public Users commentby { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }

    public ForumEstCommentbyUser()
    {
       
    }

    public ForumEstCommentbyUser(ForumEstablishment forumID, string comments, Users commentby, DateTime date, string status)
    {
        this.forumID = forumID;
        this.comments = comments;
        this.commentby = commentby;
        this.date = date;
        this.status = status;
    }
}