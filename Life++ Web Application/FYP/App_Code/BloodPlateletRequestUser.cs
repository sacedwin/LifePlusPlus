using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BloodPlateletRequestUser
/// </summary>
public class BloodPlateletRequestUser
{
    public string bplUserRequestID { get; set; }
    public int unitMatched { get; set; }
    public int Units { get; set; }
    public Establishment Establishment { get; set; }
    public Users requestorID { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public string bloodOrPlatelet { get; set; }
    public DateTime Time { get; set; }

    public BloodPlateletRequestUser()
    {
       
    }

    public BloodPlateletRequestUser( int units, int uMatch, Establishment est, Users u, string btype, string st, string blood,DateTime timerequest)
    {
        Units = units;
        unitMatched = uMatch;
        Establishment = est;
        requestorID = u;
        Type = btype;
        Status = st;
        bloodOrPlatelet = blood;
        Time = timerequest;
    }


}