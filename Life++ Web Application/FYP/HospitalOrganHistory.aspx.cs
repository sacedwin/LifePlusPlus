using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HospitalOrganHistory : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];


		List<ShowOrgan> solist = ShowOrganDB.getAllDOrganListByDonor(es.ID);
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

		List<ShowOrgan> solist2 = ShowOrganDB.getAllDOrganListByReceiver(es.ID);
		if (solist2.Count == 0)
		{
			panelfrom.Visible = false;
			lblsorry2.Visible = true;
		}
		else
		{
			lblsorry2.Visible = false;
			panelfrom.Visible = true;
			GridView1.DataSource = solist2;
			GridView1.DataBind();
		}
	}

	protected void gvDonor_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];
		List<ShowOrgan> solist = ShowOrganDB.getAllDOrganListByDonor(es.ID);
		gvDonor.PageIndex = e.NewPageIndex;
		gvDonor.DataSource = solist;
		gvDonor.DataBind();
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		Establishment es = (Establishment)Session["establishment"];
		List<ShowOrgan> solist2 = ShowOrganDB.getAllDOrganListByReceiver(es.ID);
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.DataSource = solist2;
		GridView1.DataBind();
	}
}