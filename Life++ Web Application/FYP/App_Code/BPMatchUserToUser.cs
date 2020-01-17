using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BPMatchUserToUser
/// </summary>
public class BPMatchUserToUser
{
	public string bpMatchUsrUsrID  { get; set; }
    public BloodPlateletRequestUser bplUsrRequestID  { get; set; }
    public Users matchID {get;set;}
    public string status { get; set; }
    public int distance {get;set;}

    public BPMatchUserToUser()
    {
       
    }

    public BPMatchUserToUser(BloodPlateletRequestUser bplRequestID, Users matchUID, string st, int dist)
    {
        bplUsrRequestID = bplRequestID;
        matchID = matchUID;
        status = st;
        distance = dist;
    }
}