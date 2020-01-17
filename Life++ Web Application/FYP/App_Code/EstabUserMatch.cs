using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class EstabUserMatch
{
    public string ID { get; set; }
    public EstablishmentBPRequest Request { get; set; }
    public Users Match { get; set; }
    public string Status { get; set; }
    public int Distance { get; set; }

    public EstabUserMatch()
    {       
    }

    public EstabUserMatch(string id, EstablishmentBPRequest request, Users match, string status, int distance)
    {
        ID = id;
        Request = request;
        Match = match;
        Status = status;
        Distance = distance;
    }

    public EstabUserMatch(EstablishmentBPRequest request, Users match, string status, int unitsMatched, int distance)
    {
        Request = request;
        Match = match;
        Status = status;
        Distance = distance;
    }
}