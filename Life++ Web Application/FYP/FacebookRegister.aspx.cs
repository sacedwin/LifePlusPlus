using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FacebookRegister : System.Web.UI.Page
{
    string tgender;
    int theight;
    int tweight;
    string Rstatus;
    string profile;

    protected void Page_Load(object sender, EventArgs e)
    {
        cbTermVali.Visible = false;
        lblDOB.Visible = false;
        lblUsername.Visible = false;
        lblEmail.Visible = false;
        lblNRIC.Visible = false;

        tbxName.Text = Session["name"].ToString();
        tbxEmail.Text = Session["femail"].ToString();
        if (Session["gender"].ToString() == "male")
        {
            RadioMale.Checked = true;
            RadioFemale.Enabled = false;
        }
        else
        {
            RadioFemale.Checked = true;
            RadioMale.Enabled = false;
        }

        profile = Session["propic"].ToString();  

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

            Users newuser = new Users(tbxEmail.Text, tbxName.Text, Convert.ToDateTime(tbxDOB.Text), tgender, Rstatus, theight, tweight, ddlBloodType.SelectedValue, tbxUsername.Text, tbxPassword.Text, Convert.ToInt32(tbxPhone.Text), tbxNRIC.Text, "null", 0, "null", "Allow", tbxAddress.Text, Convert.ToInt32(tbxZipcode.Text), ddlNationality.SelectedValue, profile, "null","Can Donate","null","null","null");
            int num = UsersDB.insertUser(newuser);
            if (num != -1)
            {
                if (checkEmergencyContact.Checked)
                {
                    Session["Username"] = tbxUsername.Text;
                    Server.Transfer("AddationalRegister.aspx");
                }
                else
                {
                    lblOutput.Visible = true;
                    lblOutput.Text = "Registeration Successful!";
                    Session["email"] = tbxEmail.Text;
                    Session["img"] = "1";
                    string HomePageUrl = "HomePage.aspx";
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
}