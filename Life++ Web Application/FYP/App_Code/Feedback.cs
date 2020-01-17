using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    public string feedbackID;
    public string name;
    public string email;
    public string subject;
    public string question;
    public string answer;
    public string status;
    public string answerby;

    public Feedback() { }
    public Feedback(string name, string email, string subject, string question, string answer, string status,string answerby)
    {
        this.name = name;
        this.email = email;
        this.subject = subject;
        this.question = question;
        this.answer = answer;
        this.status = status;
        this.answerby = answerby;
    }

    public string FeedbackID
    {
        get { return feedbackID; }
        set { feedbackID = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public string Question
    {
        get { return question; }
        set { question = value; }
    }

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public string Answerby
    {
        get { return answerby; }
        set { answerby = value; }
    }
}