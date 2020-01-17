using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NMyAccount : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			if (Session["establishment"] == null)
			{
				Server.Transfer("Login.aspx");
			}
			else
			{
				Establishment est = (Establishment)Session["establishment"];
				tbxAAddress.Text = est.Address;
				tbxAEmail.Text = est.Email;
				tbxName.Text = est.Name;
				tbxPhone.Text = est.Phone.ToString();
			}
		}
	}


	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		Establishment est = (Establishment)Session["establishment"];
		est.Name = tbxName.Text;
		est.Phone = Convert.ToInt32(tbxPhone.Text);
		est.Address = tbxAAddress.Text;
		int num = EstablishmentDB.updateEstInfo(est);
		if (num != 1)
			lblOutput.Text = "Cannot update info right now!";
		else
		{
			lblOutput.Text = "Successfully Update!";
			string MyAccountUrl = "GMyAccount.aspx";
			Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));
		}

	}
}