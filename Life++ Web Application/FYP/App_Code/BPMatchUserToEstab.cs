using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BPMatchUserToEstab
/// </summary>
public class BPMatchUserToEstab
{
	public string bpMatchUsrEstID  { get; set; }
    public Establishment matchID  { get; set; }
    public BloodPlateletRequestUser bpRequestID  { get; set; }
    public string status { get; set; }
    public int distance {get;set;}

    public BPMatchUserToEstab()
    {
       
    }

    public BPMatchUserToEstab(BloodPlateletRequestUser UserRequestID,  Establishment eID, string st, int dist)
    {
        matchID = eID;
        bpRequestID = UserRequestID;
        status = st;
        distance = dist;
    }
}