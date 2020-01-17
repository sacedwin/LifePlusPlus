using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GLiveOrgan : System.Web.UI.Page
{
	List<LiveDonor> ldcurrentLists = new List<LiveDonor>();
	List<LiveDonor> ldpastLists = new List<LiveDonor>();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("Login.aspx");
		}

		else
		{
			List<LiveDonor> ldLists = LiveDonorDB.getallLiveDonor();
			foreach (LiveDonor ld in ldLists)
			{
				if (ld.Status == "complete" || ld.status == "allotted")
				{
					ldpastLists.Add(ld);
				}
				else if (ld.status == "not allotted")
				{
					ldcurrentLists.Add(ld);
				}
			}

			if (ldcurrentLists.Count == 0)
			{
				lblSorry.Visible = true;
				Panel1.Visible = false;
			}
			else
			{
				lblSorry.Visible = false;
				Panel1.Visible = true;
				gvRequest.DataSource = ldcurrentLists;
				gvRequest.DataBind();
			}

			if (ldpastLists.Count == 0)
			{
				lblsorry2.Visible = true;
				Panel2.Visible = false;
			}
			else
			{
				lblsorry2.Visible = false;
				Panel2.Visible = true;
				gvDHistory.DataSource = ldpastLists;
				gvDHistory.DataBind();
			}
		}

	}

	protected void gvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRequest.PageIndex = e.NewPageIndex;
		gvRequest.DataSource = ldcurrentLists;
		gvRequest.DataBind();
	}

	protected void gvDHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvDHistory.PageIndex = e.NewPageIndex;
		gvDHistory.DataSource = ldpastLists;
		gvDHistory.DataBind();
	}
}