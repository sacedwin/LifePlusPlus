using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HospitalOrganHistory2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];


		List<ShowOrgan> solist = ShowOrganDB.getAllLOrganListByReceiver(es.ID);
		if (solist.Count == 0)
		{
			panelother.Visible = false;
			lblSorry.Visible = true;
		}
		else
		{
			lblSorry.Visible = false;
			panelother.Visible = true;
			gvDonor.DataSource = solist;
			gvDonor.DataBind();
		}
		
	}

	protected void gvDonor_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];
		List<ShowOrgan> solist = ShowOrganDB.getAllLOrganListByReceiver(es.ID);
		gvDonor.PageIndex = e.NewPageIndex;
		gvDonor.DataSource = solist;
		gvDonor.DataBind();
	}

}