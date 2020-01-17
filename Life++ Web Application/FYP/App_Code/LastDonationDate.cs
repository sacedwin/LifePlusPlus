using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LastDonationDate
/// </summary>
public class LastDonationDate
{
	public string ID { get; set; }
	public Users User { get; set; }
	public DateTime LastDonation { get; set; }
	public string Type { get; set; }
	public string Status { get; set; }

	public LastDonationDate()
	{

	}

	public LastDonationDate(string id, Users user, DateTime lastDonation, string type, string status)
	{
		ID = id;
		User = user;
		LastDonation = lastDonation;
		Type = type;
		Status = status;
	}

	public LastDonationDate(Users user, DateTime lastDonation, string type, string status)
	{
		User = user;
		LastDonation = lastDonation;
		Type = type;
		Status = status;
	}
}