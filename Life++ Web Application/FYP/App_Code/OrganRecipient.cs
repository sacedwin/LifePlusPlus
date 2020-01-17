using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class OrganRecipient
{
    public string ID { get; set; }
    public Establishment Establishment { get; set; }
    public string Bloodgroup { get; set; }
    public DateTime DOB { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public DateTime Addedon { get; set; }
    public string Organrequired { get; set; }
    public string Comments { get; set; }
    public int Urgency { get; set; }
    public string Refnumber { get; set; }
    public string Status { get; set; }

    public OrganRecipient()
    {
       
    }

    public OrganRecipient(string id, Establishment establishment, string bloodgroup, DateTime dob, int height, int weight, DateTime addedon, string organrequired, string comments, int urgency, string refnumber, string status)
    {
        ID = id;
        Establishment = establishment;
        Bloodgroup = bloodgroup;
        DOB = dob;
        Height = height;
        Weight = weight;
        Addedon = addedon;
        Organrequired = organrequired;
        Comments = comments;
        Urgency = urgency;
        Refnumber = refnumber;
        Status = status;
    }

    public OrganRecipient(Establishment establishment, string bloodgroup, DateTime dob, int height, int weight, DateTime addedon, string organrequired, string comments, int urgency, string refnumber)
    {
        Establishment = establishment;
        Bloodgroup = bloodgroup;
        DOB = dob;
        Height = height;
        Weight = weight;
        Addedon = addedon;
        Organrequired = organrequired;
        Comments = comments;
        Urgency = urgency;
        Refnumber = refnumber;
    }


}