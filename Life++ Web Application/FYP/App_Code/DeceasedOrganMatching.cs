using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeceasedOrganMatching
/// </summary>
public class DeceasedOrganMatching
{
	public string ID;
	public DeceasedDonor DeceasedDonor;
	public OrganRecipient Recipient;
	public int MatchScore;
	public string Comments;
	public string Status;
	public int Distance;

	public DeceasedOrganMatching()
	{

	}

	public DeceasedOrganMatching(string id, DeceasedDonor deceasedDonor, OrganRecipient recipient, int matchScore, string comments, string status, int distance)
	{
		ID = id;
		DeceasedDonor = deceasedDonor;
		Recipient = recipient;
		MatchScore = matchScore;
		Comments = comments;
		Status = status;
		Distance = distance;
	}

	public DeceasedOrganMatching(DeceasedDonor deceasedDonor, OrganRecipient recipient, int matchScore, string comments, string status, int distance)
	{
		DeceasedDonor = deceasedDonor;
		Recipient = recipient;
		MatchScore = matchScore;
		Comments = comments;
		Status = status;
		Distance = distance;
	}
}