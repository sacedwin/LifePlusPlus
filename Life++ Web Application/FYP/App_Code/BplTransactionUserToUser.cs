using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BplTransactionUserToUser
/// </summary>
public class BplTransactionUserToUser
{
    public string bplUserTrasactionID { get; set; }
    public BPMatchUserToUser bpMatchUsrUsr { get; set; }
    public int unitsPossible { get; set; }
    public string status { get; set; }

    public BplTransactionUserToUser()
    {
       
    }

    public BplTransactionUserToUser(BPMatchUserToUser bpMatchUsrUsr, string status)
    {
		this.bpMatchUsrUsr = bpMatchUsrUsr;
        this.status = status;
    }
}