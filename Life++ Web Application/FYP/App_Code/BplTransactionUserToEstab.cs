using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BplTransactionUserToEstab
/// </summary>
public class BplTransactionUserToEstab
{
    public string bplUserToEstabTrasactionID { get; set; }
    public BPMatchUserToEstab bpMatchUsrEstID { get; set; }
    public int unit { get; set; }
    public string status { get; set; }

    public BplTransactionUserToEstab()
    {
       
    }

    public BplTransactionUserToEstab(BPMatchUserToEstab MatchUsrEstID, int un, string st)
    {
        bpMatchUsrEstID = MatchUsrEstID;
        unit = un;
        status = st;
    }
}