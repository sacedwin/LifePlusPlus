using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ForumEstablishment
/// </summary>
public class ForumEstablishment
{
	public string forumID;
    public string title;
    public string message;
    public DateTime date;
    public string status;
    public Establishment estID;
    

    public ForumEstablishment() { }
    public ForumEstablishment(string title, string message, DateTime date,string status, Establishment estID)
    {
        this.title = title;
        this.message = message;
        this.date = date;
        this.status = status;
        this.estID = estID;
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

    public Establishment EstID
    {
        get { return estID; }
        set { estID = value; }
    }
}