using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumUser
/// </summary>
public class ForumUser
{
	public string forumID;
    public string title;
    public string message;
    public string status;
    public DateTime date;
    public Users userID;
    

    public ForumUser() { }
    public ForumUser(string title, string message,DateTime date,string status, Users userID)
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

    public Users UserID
    {
        get { return userID; }
        set { userID = value; }
    }

}