using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;


public partial class Login : System.Web.UI.Page
{
	bool estFound = false;
	bool estFoundG = false;
	bool estFoundN = false;

	protected void Page_Load(object sender, EventArgs e)
	{

		if (Session["establishment"] != null)
		{
			Establishment es = (Establishment)Session["establishment"];
			if (es.Type == "NGO")
				Server.Transfer("NHomePage.aspx");
			else if (es.Type == "Government")
				Server.Transfer("GMyAccount.aspx");
			else
				Server.Transfer("HospitalHomePage.aspx");

		}
		else
		{
			if (Session["email"] != null)
			{
				Server.Transfer("HomePage.aspx");
			}
		}
	}

	protected void linkReset_Click(object sender, EventArgs e)
	{
		Server.Transfer("ForgetPassword.aspx");
	}

	protected void btnSubmit2_Click(object sender, EventArgs e)
	{
		List<Establishment> establishments = EstablishmentDB.getAllEstablishments();
		Establishment es = new Establishment();
		foreach (Establishment est in establishments)
		{
			if (tbxEmail2.Text.ToLower() == est.Email.ToLower() && (est.Type == "Blood Bank" || est.Type == "Hospital"))
			{
				estFound = true;
				estFoundG = false;
				estFoundN = false;
				es = est;
				break;
			}
			else if (tbxEmail2.Text.ToLower() == est.Email.ToLower() && est.Type == "Government")
			{
				estFoundG = true;
				estFound = false;
				estFoundN = false;
				es = est;
				break;
			}
			else if (tbxEmail2.Text.ToLower() == est.Email.ToLower() && est.Type == "NGO")
			{
				estFoundG = false;
				estFound = false;
				estFoundN = true;
				es = est;
				break;
			}

		}

		if (estFound == true)
		{
			if (tbxPassword2.Text == es.Password)
			{
				if (es.Status == "active")
				{
					Session["establishment"] = es;
					Server.Transfer("HospitalHomePage.aspx");
				}
				else
				{
					lbl2Output.Text = "You cannot access to this email anymore. Please contact admin for more details";
					return;
				}
			}
			else
			{
				lbl2Output.Text = "Incorrect password!";
				return;
			}
		}
		else if (estFoundG == true)
		{
			if (tbxPassword2.Text == es.Password)
			{
				if (es.Status == "active")
				{
					Session["establishment"] = es;
					Server.Transfer("GMyAccount.aspx");
				}
				else
				{
					lbl2Output.Text = "You cannot access to this email anymore. Please contact admin for more details";
					return;
				}
			}
			else
			{
				lbl2Output.Text = "Incorrect password!";
				return;
			}
		}
		else if (estFoundN == true)
		{
			if (tbxPassword2.Text == es.Password)
			{
				if (es.Status == "active")
				{
					Session["establishment"] = es;
					Server.Transfer("NHomePage.aspx");
				}
				else
				{
					lbl2Output.Text = "You cannot access to this email anymore. Please contact admin for more details";
					return;
				}
			}
			else
			{
				lbl2Output.Text = "Incorrect password!";
				return;
			}
		}
		else
		{
			lbl2Output.Text = "Account doesn't exist";
			return;
		}

	}

	protected void linkRegister2_Click(object sender, EventArgs e)
	{
		Server.Transfer("EstablishmentRegister.aspx");
	}

	protected void linkReset2_Click(object sender, EventArgs e)
	{
		Server.Transfer("ForgetPassword2.aspx");
	}
}