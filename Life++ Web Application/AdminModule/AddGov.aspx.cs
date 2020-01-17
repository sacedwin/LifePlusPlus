using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddGov : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{

		if (tbxAEmail.Text == "")
		{
			lblEmail.Visible = true;
			return;
		}
		else
			lblEmail.Visible = false;

		if (tbxName.Text == "")
		{
			lblName.Visible = true;
			return;
		}
		else
			lblName.Visible = false;


		if (tbxPassword.Text == "")
		{
			lblPassword.Visible = true;
			return;
		}
		else
			lblPassword.Visible = false;


		if (tbxPhone.Text == "")
		{
			lblPhone.Visible = true;
			return;
		}
		else
			lblPhone.Visible = false;


		if (tbxAAddress.Text == "")
		{
			lblAddress.Visible = true;
			return;
		}
		else
			lblAddress.Visible = false;

		//check the existing email from the database
		List<Establishment> alltempesb = EstablishmentDB.getAllTempEstablishments();
		foreach (Establishment est in alltempesb)
		{
			if (est.Email == tbxAEmail.Text)
			{
				lblOutput.Text = "Email already existed! Please change your email or you are already regiestered!";
				return;
			}
		}

		Establishment es = new Establishment(tbxAEmail.Text, tbxName.Text, tbxPassword.Text, "Government", Convert.ToInt32(tbxPhone.Text), tbxAAddress.Text);
		int num = EstablishmentDB.insertTempEstablishment(es);
		if (num != 1)
			lblOutput.Text = "Fail to put to the government tempestablishment account!";
		else
		{
			Admins a = AdminDB.getAdminbyEmail(Session["email"].ToString());
			Establishment te = EstablishmentDB.getTempEstablishmentByEmail(tbxAEmail.Text);
			Establishment newG = new Establishment(tbxAEmail.Text, tbxName.Text, tbxPassword.Text, "Government", Convert.ToInt32(tbxPhone.Text), tbxAAddress.Text, te.ID, a);
			int num2 = EstablishmentDB.insertEstablishment(newG);
			if (num2 != 1)
				lblOutput.Text = "Fail to put to the government establishment account!";
			else
			{
				lblOutput.Text = "Government account successfully inserted!";
				tbxAAddress.Text = "";
				tbxAEmail.Text = "";
				tbxName.Text = "";
				tbxPassword.Text = "";
				tbxPhone.Text = "";
			}
		}
	}
}