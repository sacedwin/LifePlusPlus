using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EstabUserTransaction
/// </summary>
public class EstabUserTransaction
{
    public string ID { get; set; }
    public EstabUserMatch Match { get; set; }
    public int Units { get; set; }
    public string Status { get; set; }

    public EstabUserTransaction()
    {
       
    }

    public EstabUserTransaction (string id, EstabUserMatch match, int units, string status)
    {
        ID = id;
        Match = match;
        Units = units;
        Status = status;
    }

    public EstabUserTransaction(EstabUserMatch match, int units, string status)
    {
        Match = match;
        Units = units;
        Status = status;
    }
}