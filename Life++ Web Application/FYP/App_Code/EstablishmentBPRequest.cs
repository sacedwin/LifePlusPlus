using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EstablishmentBPRequest
/// </summary>
public class EstablishmentBPRequest
{
    public string ID { get; set; }
    public int Units { get; set; }
    public int MatchedUnits { get; set; }
    public string BloodGroup { get; set; }
    public Establishment Establishment { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public DateTime RequestDate { get; set; }

    public EstablishmentBPRequest()
    {
       
    }

    public EstablishmentBPRequest(string id, int units, int matchedunits, string bloodgroup, Establishment establishment, string type, string status, DateTime requestDate)
    {
        ID = id;
        Units = units;
        MatchedUnits = matchedunits;
        BloodGroup = bloodgroup;
        Establishment = establishment;
        Type = type;
        Status = status;
        RequestDate = requestDate;
    }

    public EstablishmentBPRequest(int units, int matchedunits, string bloodgroup, Establishment establishment, string type, string status, DateTime requestDate)
    {
        Units = units;
        MatchedUnits = matchedunits;
        BloodGroup = bloodgroup;
        Establishment = establishment;
        Type = type;
        Status = status;
        RequestDate = requestDate;
    }

   
}