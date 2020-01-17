using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterForm : System.Web.UI.Page
{
	string tgender;
	int theight;
	int tweight;
	string Rstatus;
	DateTime lstDonate;
	string bloodgroup;

	protected void Page_Load(object sender, EventArgs e)
	{
		cbTermVali.Visible = false;
		lblDOB.Visible = false;
		lblUsername.Visible = false;
		lblEmail.Visible = false;
		lblNRIC.Visible = false;

	}


	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		List<Users> Userlist = UsersDB.getallUsers();

		if (!CheckTerm.Checked)
		{
			cbTermVali.Visible = true;
			return;
		}
		else
		{
			cbTermVali.Visible = false;

			DateTime check = DateTime.Now.AddYears(-18);
			if (Convert.ToDateTime(tbxDOB.Text) > check)
			{
				lblDOB.Visible = true;
				return;
			}

			foreach (Users u in Userlist)
			{
				if (tbxNRIC.Text == u.nric)
				{
					lblNRIC.Visible = true;
					return;
				}
				else
				{
					lblNRIC.Visible = false;
				}
			}

			foreach (Users u in Userlist)
			{
				if (tbxEmail.Text == u.email)
				{
					lblEmail.Visible = true;
					return;
				}
				else
				{
					lblEmail.Visible = false;
				}
			}

			foreach (Users u in Userlist)
			{
				if (tbxUsername.Text == u.password)
				{
					lblUsername.Visible = true;
					return;
				}
				else
				{
					lblUsername.Visible = false;
				}
			}



			if (tbxHeight.Text == "")
				theight = 0;
			else
				theight = Convert.ToInt32(tbxHeight.Text);


			if (tbxWeight.Text == "")
				tweight = 0;
			else
				tweight = Convert.ToInt32(tbxWeight.Text);


			if (RadioMale.Checked)
				tgender = "Male";
			else
				tgender = "Female";
			if (RadioMSSingle.Checked)
				Rstatus = "Single";
			else if (RadioMSWidowed.Checked)
				Rstatus = "Widowed";
			else if (RadioMSDivorced.Checked)
				Rstatus = "Divorced";
			else
				Rstatus = "Married";

			if (ddllastDAsk.SelectedIndex == 0)
			{
				lblldAsk.Visible = true;
				Panel1.Visible = false;
				return;
			}
			else if (ddllastDAsk.SelectedIndex == 1)
			{

				if (Convert.ToDateTime(tbxlastDonate.Text) > System.DateTime.Now)
				{
					lbllastDonate.Visible = true;
					return;
				}
				else
				{
					lbllastDonate.Visible = false;
					lstDonate = Convert.ToDateTime(tbxlastDonate.Text);
					if (RadioBlood.Checked)
						bloodgroup = "blood";
					else
						bloodgroup = "platelet";
				}

			}
			else
			{
				lstDonate = System.DateTime.Now.AddYears(-10);
				bloodgroup = "blood";
			}




			Users newuser = new Users(tbxEmail.Text, tbxName.Text, Convert.ToDateTime(tbxDOB.Text), tgender, Rstatus, theight, tweight, ddlBloodType.SelectedValue, tbxUsername.Text, tbxPassword.Text, Convert.ToInt32(tbxPhone.Text), tbxNRIC.Text, "null", 0, "null", "Allow", tbxAddress.Text, Convert.ToInt32(tbxZipcode.Text), ddlNationality.SelectedValue, "Default.png", "null", "Can Donate", "null", "null", "null");
			int num = UsersDB.insertUser(newuser);
			if (num != -1)
			{
				Users newu = UsersDB.getUserbyEmail(tbxEmail.Text);
				LastDonationDate ldd = new LastDonationDate(newu, lstDonate, bloodgroup, "Not in transaction");
				LastDonationDateDB.insertLastDonation(ldd);
				if (checkEmergencyContact.Checked)
				{
					Session["Username"] = tbxUsername.Text;
					Server.Transfer("AddationalRegister.aspx");
				}
				else
				{
					lblOutput.Visible = true;
					lblOutput.Text = "Registeration Successful!";
					string HomePageUrl = "Login.aspx";
					Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=3;url={0}> ", HomePageUrl)));
				}
			}
			else
			{
				lblOutput.Visible = true;
				lblOutput.Text = "User Cannot Register!";
				return;
			}


		}
	}

	protected void ddllastDAsk_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ddllastDAsk.SelectedIndex == 1)
		{
			lblldAsk.Visible = false;
			Panel1.Visible = true;
		}
		else if (ddllastDAsk.SelectedIndex == 2)
		{
			lblldAsk.Visible = false;
			Panel1.Visible = false;
		}
	}
}