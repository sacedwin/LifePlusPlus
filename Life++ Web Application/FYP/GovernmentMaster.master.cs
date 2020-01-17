using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GovernmentMaster : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			if (Session["establishment"] == null)
			{
				btnLogin.Text = "Login";
				btnMyAccount.Visible = false;
			}
			else
			{
				btnLogin.Text = "Logout";
				btnMyAccount.Visible = true;
			}
		}
	}

	protected void btnLogin_Click(object sender, EventArgs e)
	{
		if (btnLogin.Text == "Login")
		{
			Server.Transfer("Login.aspx");
		}

		else
		{
			Session["establishment"] = null;
			btnMyAccount.Visible = false;
			btnLogin.Text = "Login";
			Server.Transfer("Login.aspx");
		}
	}

	protected void btnMyAccount_Click1(object sender, EventArgs e)
	{
		Server.Transfer("GMyAccount.aspx");
	}

}
