using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GReportBloodPlatelet
/// </summary>
public class GReportBloodPlatelet
{
	public string ID { get; set; }
	public string Requestor { get; set; }
	public string BloodGroup { get; set; }
	public string BloodOrPlatelet { get; set; }
	public string UnitRequire { get; set; }
	public string Giver { get; set; }
	public string GivenUnit { get; set; }
	public DateTime Date { get; set; }
	public string Status { get; set; }

	public GReportBloodPlatelet()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}