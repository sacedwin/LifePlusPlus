using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			if ( Session["establishment"] == null)
			{
				Server.Transfer("Login.aspx");
			}
			else
			{
				tbxCurrentPsw.Text = "";
				tbxnewPass.Text = "";
				tbxnewPassRepeat.Text = "";
				lblOutput.Text = "";
				lblCP.Visible = false;
				//default mode of password will be *
				tbxCurrentPsw.TextMode = TextBoxMode.Password;
				tbxnewPass.TextMode = TextBoxMode.Password;
				tbxnewPassRepeat.TextMode = TextBoxMode.Password;

			}
		}
	}
	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		Establishment es = (Establishment)Session["establishment"];
		string np = tbxnewPass.Text;
		string np2 = tbxnewPassRepeat.Text;
		if (es.Password != tbxCurrentPsw.Text)
		{
			lblCP.Visible = true;
			return;
		}
		else
		{
			lblCP.Visible = false;
			if (np == np2)
			{
				es.Password = np;
				int num = EstablishmentDB.updateEstPassowrd(es);
				if (num != 1)
					lblOutput.Text = "Cannot Change Password!";
				else
				{
					lblOutput.Text = "Password Updated!";
					//auto refresh the page
					string MyAccountUrl = "EMyAccount.aspx";
					Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));
				}

			}
			else
			{
				lblOutput.Text = "New password and repeat password is not matching!";
				tbxnewPassRepeat.Text = "";
				tbxnewPass.Text = "";
			}
		}

	}

	//change the textmode and show his password or can hide again
	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			tbxCurrentPsw.TextMode = TextBoxMode.SingleLine;
			tbxnewPass.TextMode = TextBoxMode.SingleLine;
			tbxnewPassRepeat.TextMode = TextBoxMode.SingleLine;
		}
		else
		{
			tbxCurrentPsw.TextMode = TextBoxMode.Password;
			tbxnewPass.TextMode = TextBoxMode.Password;
			tbxnewPassRepeat.TextMode = TextBoxMode.Password;
		}

		tbxCurrentPsw.Attributes.Add("value", tbxCurrentPsw.Text);
		tbxnewPass.Attributes.Add("value", tbxnewPass.Text);
		tbxnewPassRepeat.Attributes.Add("value", tbxnewPassRepeat.Text);
	}
}