using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EstabEstabMatch
/// </summary>
public class EstabEstabMatch
{
    public string ID { get; set; }
    public EstablishmentBPRequest Request { get; set; }
    public Establishment Match { get; set; }
    public string Status { get; set; }
    public int Distance { get; set; }


    public EstabEstabMatch()
    {

    }

    public EstabEstabMatch(string id, EstablishmentBPRequest request, Establishment match, string status, int distance)
    {
        ID = id;
        Request = request;
        Match = match;
        Status = status;
        Distance = distance;
    }

    public EstabEstabMatch(EstablishmentBPRequest request, Establishment match, string status, int distance)
    {
        Request = request;
        Match = match;
        Status = status;
        Distance = distance;
    }



}
