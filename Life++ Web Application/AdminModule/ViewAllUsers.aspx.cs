using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class ViewAllUsers : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["email"] == null)
		{
			Server.Transfer("LoginPage.aspx");
		}
		else
		{
			if (!IsPostBack)
			{

				Session["etemp"] = null;
				Session["atemp"] = null;
				Session["esttemp"] = null;
			}

		}
	}



	protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblUpdateShow.Text = "";
		Panel1.Visible = true;
		if (Session["etemp"] != null)
		{
			AUser nu = AUserDB.getUserbyEmail(tbxSearch.Text);
			tbxUserID.Text = nu.userId;
			tbxAddress.Text = nu.address;
			tbxDOB.Text = String.Format("{0:yyyy-MM-dd}", nu.dob);
			tbxEmail.Text = nu.email;
			tbxHeight.Text = nu.height.ToString();
			tbxName.Text = nu.name;
			tbxNRIC.Text = nu.nric;
			tbxPassword.Text = nu.password;
			tbxPhone.Text = nu.phone.ToString();
			tbxUsername.Text = nu.username;
			tbxWeight.Text = nu.weight.ToString();
			tbxZipcode.Text = nu.zipcode.ToString();
			if (nu.gender == "Male")
			{
				RadioMale.Checked = true;
				RadioFemale.Enabled = false;
			}
			else
			{
				RadioFemale.Checked = true;
				RadioMale.Enabled = false;
			}

			ddlNationality.SelectedValue = nu.nationality;

			if (nu.Rstatus.Trim() == "Single")
			{
				RadioMSSingle.Checked = true;
				RadioMSDivorced.Enabled = false;
				RadioMSMarried.Enabled = false;
				RadioMSWidowed.Enabled = false;
			}
			else if (nu.rstatus.Trim() == "Married")
			{
				RadioMSMarried.Checked = true;
				RadioMSSingle.Enabled = false;
				RadioMSDivorced.Enabled = false;
				RadioMSWidowed.Enabled = false;
			}
			else if (nu.rstatus.Trim() == "Divorced")
			{
				RadioMSDivorced.Checked = true;
				RadioMSSingle.Enabled = false;
				RadioMSWidowed.Enabled = false;
				RadioMSMarried.Enabled = false;
			}
			else
			{
				RadioMSWidowed.Checked = true;
				RadioMSDivorced.Enabled = false;
				RadioMSMarried.Enabled = false;
				RadioMSSingle.Enabled = false;
			}

			ddlstatus.SelectedValue = nu.status;
			ddlBloodType.SelectedValue = nu.bloodtype;
			if (nu.emergencyname == "null")
			{
				Panel2.Visible = false;
			}
			else
			{
				Panel2.Visible = true;
				tbxEName.Text = nu.emergencyname;
				tbxEPhone.Text = nu.emergencyphone.ToString();
				ddlRelation.SelectedValue = nu.emergencyrelationship;
			}
		}

		else
		{
			List<AUser> userlists = AUserDB.getallUsers();
			AUser u = userlists[gvUser.PageSize * gvUser.PageIndex + gvUser.SelectedIndex];
			tbxUserID.Text = u.userId;
			tbxAddress.Text = u.address;
			tbxDOB.Text = String.Format("{0:yyyy-MM-dd}", u.dob);
			tbxEmail.Text = u.email;
			tbxHeight.Text = u.height.ToString();
			tbxName.Text = u.name;
			tbxNRIC.Text = u.nric;
			tbxPassword.Text = u.password;
			tbxPhone.Text = u.phone.ToString();
			tbxUsername.Text = u.username;
			tbxWeight.Text = u.weight.ToString();
			tbxZipcode.Text = u.zipcode.ToString();
			if (u.gender == "Male")
			{
				RadioMale.Checked = true;
				RadioFemale.Enabled = false;
			}
			else
			{
				RadioFemale.Checked = true;
				RadioMale.Enabled = false;
			}

			ddlNationality.SelectedValue = u.nationality;

			if (u.Rstatus.Trim() == "Single")
			{
				RadioMSSingle.Checked = true;
				RadioMSDivorced.Enabled = false;
				RadioMSMarried.Enabled = false;
				RadioMSWidowed.Enabled = false;
			}
			else if (u.rstatus.Trim() == "Married")
			{
				RadioMSMarried.Checked = true;
				RadioMSSingle.Enabled = false;
				RadioMSDivorced.Enabled = false;
				RadioMSWidowed.Enabled = false;
			}
			else if (u.rstatus.Trim() == "Divorced")
			{
				RadioMSDivorced.Checked = true;
				RadioMSSingle.Enabled = false;
				RadioMSWidowed.Enabled = false;
				RadioMSMarried.Enabled = false;
			}
			else
			{
				RadioMSWidowed.Checked = true;
				RadioMSDivorced.Enabled = false;
				RadioMSMarried.Enabled = false;
				RadioMSSingle.Enabled = false;
			}

			ddlstatus.SelectedValue = u.status;
			ddlBloodType.SelectedValue = u.bloodtype;
			if (u.emergencyname == "null")
			{
				Panel2.Visible = false;
			}
			else
			{
				Panel2.Visible = true;
				tbxEName.Text = u.emergencyname;
				tbxEPhone.Text = u.emergencyphone.ToString();
				ddlRelation.SelectedValue = u.emergencyrelationship;
			}
		}

	}

	protected void gvAdmin_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblUpdateShow.Text = "";
		pAdminDetail.Visible = true;
		if (Session["atemp"] == null)
		{
			List<Admins> adminlists = AdminDB.getallAdmins();
			Admins m = adminlists[gvAdmin.PageSize * gvAdmin.PageIndex + gvAdmin.SelectedIndex];
			tbxAdminId.Text = m.adminId;
			tbxAEmail.Text = m.email;
			tbxAName.Text = m.name;
			tbxAAddress.Text = m.Address;
			tbxAdminPhone.Text = m.phone.ToString();
			ddlAStatus.SelectedValue = m.status;
		}
		else
		{
			Admins a = AdminDB.getAdminbyEmail(tbxSearch.Text);
			tbxAdminId.Text = a.adminId;
			tbxAEmail.Text = a.email;
			tbxAName.Text = a.name;
			tbxAAddress.Text = a.Address;
			tbxAdminPhone.Text = a.phone.ToString();
			ddlAStatus.SelectedValue = a.status;

		}


	}

	protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		lblUpdateShow.Text = "";
		gvUser.PageIndex = e.NewPageIndex;
		bindUser();
	}

	protected void gvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		lblUpdateShow.Text = "";
		gvAdmin.PageIndex = e.NewPageIndex;
		bindAdmin();
	}

	protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblUpdateShow.Text = "";
		if (DropDownList2.SelectedIndex == 0)
		{
			PanelUserAll.Visible = false;
			PanelAllAdmins.Visible = false;
			Panel1.Visible = false;
			pAdminDetail.Visible = false;
			PanelAllEstablishment.Visible = false;
			PanelEst.Visible = false;
			lblError.Text = "";
			lblAOutput.Text = "";
			lblOutput.Text = "";
			lblCError.Text = "";

		}

		else if (DropDownList2.SelectedIndex == 1)
		{
			List<AUser> allUsers = AUserDB.getallUsers();
			if (allUsers.Count == 0)
			{
				lblCError.Text = "Sorry! There is no user found!";
				return;
			}
			else
			{
				PanelUserAll.Visible = true;
				Panel1.Visible = false;
				PanelAllAdmins.Visible = false;
				pAdminDetail.Visible = false;
				PanelAllEstablishment.Visible = false;
				PanelEst.Visible = false;
				bindUser();
				gvUser.SelectedIndex = -1;
				lblCError.Text = "";
				lblError.Text = "";
				tbxSearch.Text = "";
				Session["etemp"] = null;
				Session["esttemp"] = null;
			}


		}

		else if (DropDownList2.SelectedIndex == 2)
		{
			List<Admins> alladmins = AdminDB.getallAdmins();
			if (alladmins.Count == 0)
			{
				lblCError.Text = "Sorry! There is no user found!";
				return;
			}
			else
			{
				PanelUserAll.Visible = false;
				Panel1.Visible = false;
				pAdminDetail.Visible = false;
				PanelAllEstablishment.Visible = false;
				PanelEst.Visible = false;
				PanelAllAdmins.Visible = true;
				gvAdmin.SelectedIndex = -1;
				bindAdmin();
				lblCError.Text = "";
				lblError.Text = "";
				tbxSearch.Text = "";
				Session["atemp"] = null;
				Session["esttemp"] = null;
			}

		}
		else if (DropDownList2.SelectedIndex == 3)
		{
			List<Establishment> allest = EstablishmentDB.getAllEstablishments();
			if (allest.Count == 0)
			{
				lblCError.Text = "Sorry! There is no user found!";
				return;
			}
			else
			{
				PanelUserAll.Visible = false;
				Panel1.Visible = false;
				pAdminDetail.Visible = false;
				PanelAllAdmins.Visible = false;
				PanelAllEstablishment.Visible = true;
				PanelEst.Visible = false;
				gvEstablishment.DataSource = allest;
				gvEstablishment.DataBind();
				lblCError.Text = "";
				gvEstablishment.SelectedIndex = -1;
				lblError.Text = "";
				tbxSearch.Text = "";
				Session["atemp"] = null;
				Session["etemp"] = null;
			}

		}
	}

	void bindAdmin()
	{
		gvAdmin.DataSource = AdminDB.getallAdmins();
		gvAdmin.DataBind();
	}

	void bindUser()
	{
		gvUser.DataSource = AUserDB.getallUsers();
		gvUser.DataBind();
	}




	protected void btnsearch_Click(object sender, EventArgs e)
	{
		lblUpdateShow.Text = "";
		Panel1.Visible = false;
		bool temail = false;

		if (tbxSearch.Text == "")
		{
			lblError.Visible = true;
			lblError.Text = "Please enter the email address to search";
			return;
		}
		else
		{
			if (DropDownList2.SelectedIndex == 0)
			{
				lblError.Visible = true;
				lblError.Text = "Please select category to search the individual";
				Panel1.Visible = false;
				Panel2.Visible = false;
				return;
			}

			else if (DropDownList2.SelectedIndex == 1)
			{
				List<AUser> userslist = AUserDB.getallUsers();

				foreach (AUser u in userslist)
				{
					if (tbxSearch.Text.ToLower() == u.email.ToLower())
					{
						temail = true;
						break;
					}
					else
						temail = false;
				}

				if (temail == true)
				{
					PanelUserAll.Visible = true;
					AUser suser = AUserDB.getUserbyEmail(tbxSearch.Text);
					List<AUser> tempuserlist = new List<AUser>();
					tempuserlist.Add(suser);
					gvUser.DataSource = tempuserlist;
					gvUser.DataBind();
					Session["etemp"] = tbxSearch.Text;
					Panel1.Visible = false;
					Panel2.Visible = false;
					lblError.Text = "";
				}
				else
				{
					PanelUserAll.Visible = false;
					lblError.Visible = true;
					lblError.Text = "The email address not found in the system for User";
					Panel1.Visible = false;
					Panel2.Visible = false;
					Session["etemp"] = null;
				}



			}

			else if (DropDownList2.SelectedIndex == 2)
			{
				List<Admins> adminslist = AdminDB.getallAdmins();

				foreach (Admins m in adminslist)
				{
					if (tbxSearch.Text.ToLower() == m.email.ToLower())
					{
						temail = true;
						break;
					}
					else
						temail = false;
				}

				if (temail == true)
				{
					PanelAllAdmins.Visible = true;
					Admins sadmin = AdminDB.getAdminbyEmail(tbxSearch.Text);
					List<Admins> tempadminlist = new List<Admins>();
					tempadminlist.Add(sadmin);
					gvAdmin.DataSource = tempadminlist;
					gvAdmin.DataBind();
					Session["atemp"] = tbxSearch.Text;
					pAdminDetail.Visible = false;
					lblError.Text = "";

				}
				else
				{
					PanelAllAdmins.Visible = false;
					pAdminDetail.Visible = false;
					lblError.Visible = true;
					lblError.Text = "The email address not found in the system for Admin";
					Session["atemp"] = null;
				}
			}


			else if (DropDownList2.SelectedIndex == 3)
			{
				List<Establishment> estlist = EstablishmentDB.getAllEstablishments();

				foreach (Establishment es in estlist)
				{
					if (tbxSearch.Text.ToLower() == es.Email.ToLower())
					{
						temail = true;
						break;
					}
					else
						temail = false;
				}

				if (temail == true)
				{
					PanelAllEstablishment.Visible = true;
					Establishment estab = EstablishmentDB.getEstablishmentByEmail(tbxSearch.Text);
					List<Establishment> tempestlist = new List<Establishment>();
					tempestlist.Add(estab);
					gvEstablishment.DataSource = tempestlist;
					gvEstablishment.DataBind();
					Session["esttemp"] = tbxSearch.Text;
					PanelEst.Visible = false;
					lblError.Text = "";

				}
				else
				{
					PanelAllEstablishment.Visible = false;
					PanelEst.Visible = false;
					lblError.Visible = true;
					lblError.Text = "The email address not found in the system for Establishment";
					Session["esttemp"] = null;
				}
			}
		}




	}
	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		string tempemail = tbxEmail.Text;
		AUser tmpUser = AUserDB.getUserbyEmail(tempemail);
		tmpUser.status = ddlstatus.SelectedValue;
		Admins a = AdminDB.getAdminbyEmail(Session["email"].ToString());
		tmpUser.doneby = a.adminId;
		int num = AUserDB.updateUserstatus(tmpUser);
		if (num != 1)
			lblOutput.Text = "Cannot Update User!";
		else
		{
			lblUpdateShow.Text = "Update Successful!";
			bindUser();
			Panel1.Visible = false;
			gvUser.SelectedIndex = -1;

		}

	}
	protected void btnAUpdate_Click(object sender, EventArgs e)
	{
		string tempemail = tbxAEmail.Text;
		if (tempemail == Session["email"].ToString())
		{
			lblAOutput.Text = "Admin cannot update his/her own status ";
			return;
		}
		else
		{
			Admins tmpAdmin = AdminDB.getAdminbyEmail(tempemail);
			tmpAdmin.status = ddlAStatus.SelectedValue;
			int num = AdminDB.updateAdmin(tmpAdmin);
			if (num != 1)
				lblAOutput.Text = "Cannot Update Admin!";
			else
			{
				lblUpdateShow.Text = "Update Successful!";
				bindAdmin();
				pAdminDetail.Visible = false;
				gvAdmin.SelectedIndex = -1;
			}
		}


	}

	protected void gvEstablishment_SelectedIndexChanged(object sender, EventArgs e)
	{
		lblUpdateShow.Text = "";
		PanelEst.Visible = true;
		if (Session["esttemp"] == null)
		{
			List<Establishment> estlist = EstablishmentDB.getAllEstablishments();
			Establishment es = estlist[gvEstablishment.PageSize * gvEstablishment.PageIndex + gvEstablishment.SelectedIndex];
			tbxEstID.Text = es.ID;
			tbxEstADdress.Text = es.Address;
			tbxEstEmail.Text = es.Email;
			tbxEstName.Text = es.Name;
			tbxEstPhone.Text = es.Phone.ToString();
			tbxEstType.Text = es.Type;
			ddlestatus.SelectedValue = es.Status;
		}
		else
		{
			Establishment es2 = EstablishmentDB.getEstablishmentByEmail(tbxSearch.Text);
			tbxEstID.Text = es2.ID;
			tbxEstADdress.Text = es2.Address;
			tbxEstEmail.Text = es2.Email;
			tbxEstName.Text = es2.Name;
			tbxEstPhone.Text = es2.Phone.ToString();
			tbxEstType.Text = es2.Type;
			ddlestatus.SelectedValue = es2.Status;
		}
	}

	protected void gvEstablishment_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		lblUpdateShow.Text = "";
		gvEstablishment.PageIndex = e.NewPageIndex;
		gvEstablishment.DataSource = EstablishmentDB.getAllEstablishments();
		gvEstablishment.DataBind();
	}

	protected void btnEUpdate_Click(object sender, EventArgs e)
	{
		string tempemail = tbxEstEmail.Text;
		Establishment tempest = EstablishmentDB.getEstablishmentByEmail(tempemail);
		tempest.Status = ddlestatus.SelectedValue;
		Admins a = AdminDB.getAdminbyEmail(Session["email"].ToString());
		tempest.Admin = a;
		int num = EstablishmentDB.updateestStatus(tempest);
		if (num != 1)
			lblOutput.Text = "Cannot Update Establishment!";
		else
		{
			lblUpdateShow.Text = "Update Successful!";
			PanelEst.Visible = false;
			gvEstablishment.DataSource = EstablishmentDB.getAllEstablishments();
			gvEstablishment.DataBind();
			gvEstablishment.SelectedIndex = -1;
		}
	}
}