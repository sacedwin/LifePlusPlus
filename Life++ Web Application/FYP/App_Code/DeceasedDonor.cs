using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DeceasedDonor
{

	public string ID { get; set; }
	public Establishment Establishment { get; set; }
	public string Bloodgroup { get; set; }
	public DateTime DOB { get; set; }
	public int Donorheight { get; set; }
	public int Donorweight { get; set; }
	public DateTime Deathdate { get; set; }
	public string Organtype { get; set; }
	public string Comments { get; set; }
	public string Refnumber { get; set; }
	public string Status { get; set; }

	public DeceasedDonor()
	{

	}

	public DeceasedDonor(string id, Establishment establishment, string bloodgroup, DateTime dob, int donorheight, int donorweight, DateTime deathdate, string organtype, string comments, string refnumber, string status)
	{
		ID = id;
		Establishment = establishment;
		Bloodgroup = bloodgroup;
		DOB = dob;
		Donorheight = donorheight;
		Donorweight = donorweight;
		Deathdate = deathdate;
		Organtype = organtype;
		Comments = comments;
		Refnumber = refnumber;
		Status = status;

	}

	public DeceasedDonor(Establishment establishment, string bloodgroup, DateTime dob, int donorheight, int donorweight, DateTime deathdate, string organtype, string comments, string refnumber)
	{
		Establishment = establishment;
		Bloodgroup = bloodgroup;
		DOB = dob;
		Donorheight = donorheight;
		Donorweight = donorweight;
		Deathdate = deathdate;
		Organtype = organtype;
		Comments = comments;
		Refnumber = refnumber;

	}

	public DeceasedDonor(string bloodgroup, DateTime dob, int donorheight, int donorweight, DateTime deathdate, string organtype, string comments, string refnumber)
	{
		Bloodgroup = bloodgroup;
		DOB = dob;
		Donorheight = donorheight;
		Donorweight = donorweight;
		Deathdate = deathdate;
		Organtype = organtype;
		Comments = comments;
		Refnumber = refnumber;

	}
}