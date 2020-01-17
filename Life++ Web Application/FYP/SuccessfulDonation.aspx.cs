using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuccessfulDonation : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			if (Session["establishment"] != null)
			{
				Establishment es = (Establishment)Session["establishment"];
				if (es.Type == "NGO")
				{
					string HomePageUrl = "NHomePage.aspx";
					Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", HomePageUrl)));
				}
			}
			else
			{
				string HomePageUrl = "HomePage.aspx";
				Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", HomePageUrl)));
			}


		}

	}
}