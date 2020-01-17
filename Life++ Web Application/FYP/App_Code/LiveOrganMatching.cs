using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LiveOrganMatching
/// </summary>
public class LiveOrganMatching
{
    public string ID { get; set; }
    public LiveDonor LiveDonor { get; set; }
	public OrganRecipient Recipient { get; set; }
	public int MatchScore { get; set; }
	public string Comments { get; set; }
	public string Status { get; set; }
	public int Distance { get; set; }

	public LiveOrganMatching()
    {
       
    }

    public LiveOrganMatching(string id, LiveDonor liveDonor, OrganRecipient recipient, int matchScore, string comments, string status, int distance)
    {
        ID = id;
        LiveDonor = liveDonor;
        Recipient = recipient;
        MatchScore = matchScore;
        Comments = comments;
        Status = status;
        Distance = distance;
    }

    public LiveOrganMatching(LiveDonor liveDonor, OrganRecipient recipient, int matchScore, string comments, string status, int distance)
    {
        LiveDonor = liveDonor;
        Recipient = recipient;
        MatchScore = matchScore;
        Comments = comments;
        Status = status;
        Distance = distance;
    }
}