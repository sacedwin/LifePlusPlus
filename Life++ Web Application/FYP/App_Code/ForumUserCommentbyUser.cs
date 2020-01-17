using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumUserCommentbyUser
/// </summary>
public class ForumUserCommentbyUser
{
    public string forumcommentID { get; set; }
    public ForumUser forumID { get; set; }
    public string comments { get; set; }
    public Users commentby { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }

    public ForumUserCommentbyUser()
    {
       
    }

    public ForumUserCommentbyUser(ForumUser forumID, string comments, Users commentby,DateTime date,string status)
    {
        this.forumID = forumID;
        this.comments = comments;
        this.commentby = commentby;
        this.date = date;
        this.status = status;
    }

}