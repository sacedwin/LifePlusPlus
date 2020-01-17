using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BPHistorys : System.Web.UI.Page
{
	//get the current establishment blood and platelet and show in gridview
	protected void Page_Load(object sender, EventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];
		List<GReportBloodPlatelet> gplistEE = GReportBloodPlateletDB.getAllBloodEToEWTime(es.ID);
		if (gplistEE.Count == 0)
		{
			lblSorry.Visible = true;
			Panel1.Visible = false;
		}
		else
		{
			lblSorry.Visible = false;
			Panel1.Visible = true;
			GridView1.DataSource = gplistEE;
			GridView1.DataBind();
		}
	}
}