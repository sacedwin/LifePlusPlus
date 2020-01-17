using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HospitalMaster : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
			Server.Transfer("Login.aspx");
		else
		{
			List<Establishment> establishments = EstablishmentDB.getAllEstablishments();
			Establishment es = (Establishment)Session["establishment"];
			if (es.Type == "Blood Bank")
			{
				linkOrgans1.Visible = false;
				linkOrgans2.Visible = false;
			}
		}

	}

	protected void btnLogout_Click(object sender, EventArgs e)
	{
		Session["establishment"] = null;
		Server.Transfer("Login.aspx");
	}

	protected void linkOrgans2_Click(object sender, EventArgs e)
	{
		Server.Transfer("HospitalOrganHistory.aspx");
	}

	protected void btnMyAccount_Click1(object sender, EventArgs e)
	{
		Server.Transfer("EMyAccount.aspx");
	}
}
