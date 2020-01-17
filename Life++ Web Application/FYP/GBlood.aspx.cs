using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GBlood : System.Web.UI.Page
{
	List<BloodPlateletRequestUser> bplist, currentbplist, expirebplist;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("Login.aspx");
		}
		else
		{
			bplist = new List<BloodPlateletRequestUser>();
			currentbplist = new List<BloodPlateletRequestUser>();
			expirebplist = new List<BloodPlateletRequestUser>();
			bplist = BloodPlateletRequestUserDB.getAllUserBloodRequests();
			foreach (BloodPlateletRequestUser bp in bplist)
			{
				if (bp.Status == "pending")
				{
					currentbplist.Add(bp);
				}
				else
				{
					expirebplist.Add(bp);
				}
			}

			if (currentbplist.Count == 0)
			{
				Panel1.Visible = false;
				lblSorry.Visible = true;
			}
			else
			{
				Panel1.Visible = true;
				lblSorry.Visible = false;
				gvRequest.DataSource = currentbplist;
				gvRequest.DataBind();
			}

			if (expirebplist.Count == 0)
			{
				Panel2.Visible = false;
				lblsorry2.Visible = true;
			}
			else
			{
				Panel2.Visible = true;
				lblsorry2.Visible = false;
				GridView1.DataSource = expirebplist;
				GridView1.DataBind();
			}

		}

	}

	protected void gvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRequest.PageIndex = e.NewPageIndex;
		gvRequest.DataSource = bplist;
		gvRequest.DataBind();
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.DataSource = expirebplist;
		GridView1.DataBind();
	}



	
}