using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AForumUser
/// </summary>
public class AForumUser
{
	public string forumID;
    public string title;
    public string message;
    public string status;
    public DateTime date;
    public AUser userID;
    

    public AForumUser() { }
    public AForumUser(string title, string message, DateTime date, string status, AUser userID)
    {
        this.title = title;
        this.message = message;
        this.userID = userID;
        this.status = status;
        this.date = date;
    }

    public string ForumID
    {
        get { return forumID; }
        set { forumID = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public AUser UserID
    {
        get { return userID; }
        set { userID = value; }
    }

}