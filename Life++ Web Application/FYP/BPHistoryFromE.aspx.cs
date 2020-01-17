using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BPHistoryFromE : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		//get the current establishment blood and platelet and show in gridview
		Establishment es = (Establishment)Session["establishment"];
		List<GReportBloodPlatelet> gplistEE = GReportBloodPlateletDB.getAllBloodEToEWTimeFromE(es.ID);
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