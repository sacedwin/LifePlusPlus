using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GReport : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("Login.aspx");
		}
	}


	protected void btnSearch_Click(object sender, EventArgs e)
	{
		DateTime from = new DateTime(), to = new DateTime();
		if (tbxFrom.Text == "")
		{
			lblOutput.Text="Please choose the date";
			return;
		}
		else
		{
			from = Convert.ToDateTime(tbxFrom.Text);
		}
		if (tbxTo.Text == "")
		{
			lblOutput.Text = "Please choose the date";
			return;
		}
		else
		{
			to = Convert.ToDateTime(tbxTo.Text);
		}
		List<GReportBloodPlatelet> gplistUU = GReportBloodPlateletDB.getAllBloodUToU(from, to);
		List<GReportBloodPlatelet> gplistUE=  GReportBloodPlateletDB.getAllBloodUToE(from, to);
		List<GReportBloodPlatelet> gplistEU = GReportBloodPlateletDB.getAllBloodEToU(from, to);
		List<GReportBloodPlatelet> gplistEE = GReportBloodPlateletDB.getAllBloodEToE(from, to);


		int num = gplistUU.Count + gplistUE.Count + gplistEU.Count + gplistEE.Count;
		if (num == 0)
		{
			lblheading.Visible = false;
			Panel1.Visible = false;
			lblHeading2.Visible = false;
			Panel2.Visible = false;
			lblHeading3.Visible = false;
			Panel3.Visible = false;
			lblHeading4.Visible = false;
			Panel4.Visible = false;
			lblSorry1.Visible = false;
			lblSorry2.Visible = false;
			lblSorry3.Visible = false;
			lblSorry4.Visible = false;
			lblResult.Visible = true;
			lblResult.Text = "There is no donation found during that time.";
		}
		else
		{
			lblResult.Visible = true;
			lblResult.Text = "There are "+ num +" result(s) found from: "+ from.ToShortDateString() +" To: "+ to.ToShortDateString();


			if (gplistUU.Count == 0)
			{
				lblheading.Visible = true;
				lblSorry1.Visible = true;
				Panel1.Visible = false;
			}
			else
			{
				lblheading.Visible = true;
				Panel1.Visible = true;
				lblSorry1.Visible = false;
				GridView1.DataSource = gplistUU;
				GridView1.DataBind();
			}

			if (gplistUE.Count == 0)
			{
				lblHeading2.Visible = true;
				Panel2.Visible = false;
				lblSorry2.Visible = true;
			}
			else
			{
				lblHeading2.Visible = true;
				Panel2.Visible = true;
				lblSorry2.Visible = false;
				GridView2.DataSource = gplistUE;
				GridView2.DataBind();
			}

			if (gplistEE.Count == 0)
			{
				lblHeading3.Visible = true;
				Panel3.Visible = false;
				lblSorry3.Visible = true;
			}
			else
			{
				lblHeading3.Visible = true;
				Panel3.Visible = true;
				lblSorry3.Visible = false;
				GridView3.DataSource = gplistEE;
				GridView3.DataBind();
			}

			if (gplistEU.Count == 0)
			{
				lblHeading4.Visible = true;
				Panel4.Visible = false;
				lblSorry4.Visible = true;
			}
			else
			{
				lblHeading4.Visible = true;
				Panel4.Visible = true;
				lblSorry4.Visible = false;
				GridView4.DataSource = gplistEU;
				GridView4.DataBind();
			}
		}

	}
}