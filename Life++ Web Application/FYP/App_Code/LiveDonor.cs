using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LiveDonor
/// </summary>
public class LiveDonor
{
    public string ldonorID;
    public Users userid;
    public string organType;
    public string comments;
    public string status;
    public string doctorName;
    public int doctorNumber;
    public string doctorAddress;
    public string doctorEmail;

    public LiveDonor() { }

    public LiveDonor(Users userid, string organType, string comments, string status, string doctorName, int doctorNumber, string doctorAddress, string doctorEmail)
    {
        this.userid = userid;
        this.organType = organType;
        this.comments = comments;
        this.status = status;
        this.doctorName = doctorName;
        this.doctorNumber = doctorNumber;
        this.doctorAddress = doctorAddress;
        this.doctorEmail = doctorEmail;
    }

    public string LdonorID
    {
        get { return ldonorID; }
        set { ldonorID = value; }
    }

    public Users Userid
    {
        get { return userid; }
        set { userid = value; }
    }

    public string OrganType
    {
        get { return organType; }
        set { organType = value; }
    }

    public string Comments
    {
        get { return comments; }
        set { comments = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public string DoctorName
    {
        get { return doctorName; }
        set { doctorName = value; }
    }

    public int DoctorNumber
    {
        get { return doctorNumber; }
        set { doctorNumber = value; }
    }

    public string DoctorAddress
    {
        get { return doctorAddress; }
        set { doctorAddress = value; }
    }

    public string DoctorEmail
    {
        get { return doctorEmail; }
        set { doctorEmail = value; }
    }
}