using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EstabEstabTransaction
/// </summary>
public class EstabEstabTransaction

{
    public string ID { get; set; }
    public EstabEstabMatch Match { get; set; }
    public int Units { get; set; }
    public string Status { get; set; }

    public EstabEstabTransaction()
    {
        
    }

    public EstabEstabTransaction(string id, EstabEstabMatch match, int units, string status)
    {
        ID = id;
        Match = match;
        Units = units;
        Status = status;
    }

    public EstabEstabTransaction(EstabEstabMatch match, int units, string status)
    {
        Match = match;
        Units = units;
    }
}