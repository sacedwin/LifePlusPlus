using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyAccount : System.Web.UI.Page
{
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["email"] == null)
            {
                Server.Transfer("CommonLogin.aspx");
            }
            else
            {
                string nemail = Session["email"].ToString();
                Users nowuser = UsersDB.getUserbyEmail(nemail);
                tbxName.Text = nowuser.name;
                if (nowuser.gender == "Male")
                    RadioMale.Checked = true;
                else
                    RadioFemale.Checked = true;
                tbxDOB.Text = String.Format("{0:yyyy-MM-dd}", nowuser.dob);
                ddlNationality.SelectedValue = nowuser.nationality;
                tbxNRIC.Text = nowuser.nric;
                if (nowuser.rstatus.Trim() == "Single")
                    RadioMSSingle.Checked = true;
                else if (nowuser.rstatus.Trim() == "Married")
                    RadioMSMarried.Checked = true;
                else if (nowuser.rstatus.Trim() == "Divorced")
                    RadioMSDivorced.Checked = true;
                else
                    RadioMSWidowed.Checked = true;
                tbxHeight.Text = nowuser.height.ToString();
                tbxWeight.Text = nowuser.weight.ToString();
                ddlBloodType.SelectedValue = nowuser.bloodtype;
                tbxEmail.Text = nowuser.email;
                tbxUsername.Text = nowuser.username;
                tbxAddress.Text = nowuser.address;
                tbxZipcode.Text = nowuser.zipcode.ToString();
                tbxPhone.Text = nowuser.phone.ToString();
                
                
                if (nowuser.emergencyname != "null")
                {
                    Panel1.Visible = true;
                    LinkButton1.Text = "I want to remove emergency contact person from my account.";
                    tbxEName.Text = nowuser.emergencyname;
                    tbxEPhone.Text = nowuser.emergencyphone.ToString();
                    ddlRelation.SelectedValue = nowuser.emergencyrelationship;
                }
                else
                {
                    Panel1.Visible = false;
                    LinkButton1.Text = "I want to add emergency contact person for me.";

                }
                List<Users> checkprolist = UsersDB.getallUserswithlink();
                for (int n = 0; n < checkprolist.Count; n++)
                {
                    if(nowuser.email==checkprolist[n].email)
                    {
                        i = 1;
                        break;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                if (i==1)
                {
                    Image1.ImageUrl = nowuser.profilepic;
                }
                else
                {
                    Image1.ImageUrl = "~/img/" + nowuser.profilepic;
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string nemail = Session["email"].ToString();
        Users nowuser = UsersDB.getUserbyEmail(nemail);
        string filename = "Default.png";
        if (fldImage.HasFile)
        {
            filename = fldImage.FileName;
            fldImage.SaveAs(Server.MapPath("~/img/" + filename));//store the file in the images folder    
            nowuser.profilepic = filename;
            Image1.ImageUrl = "~/img/" + nowuser.profilepic;
        }
        nowuser.name = tbxName.Text;
        nowuser.dob = Convert.ToDateTime(tbxDOB.Text);
        if (RadioMale.Checked)
            nowuser.gender = "Male";
        else
            nowuser.gender = "Female";
        if (RadioMSSingle.Checked)
            nowuser.rstatus = "Single";
        else if (RadioMSWidowed.Checked)
            nowuser.rstatus = "Widowed";
        else if (RadioMSDivorced.Checked)
            nowuser.rstatus = "Divorced";
        else
            nowuser.rstatus = "Married";
        nowuser.nationality = ddlNationality.SelectedValue;
        nowuser.bloodtype = ddlBloodType.SelectedValue;
        if (tbxHeight.Text == "")
            nowuser.height = 0;
        else
            nowuser.height = Convert.ToInt32(tbxHeight.Text);
        if (tbxWeight.Text == "")
            nowuser.weight = 0;
        else
            nowuser.weight = Convert.ToInt32(tbxWeight.Text);
        nowuser.address = tbxAddress.Text;
        nowuser.zipcode = Convert.ToInt32(tbxZipcode.Text);
        nowuser.phone = Convert.ToInt32(tbxPhone.Text);
        if (Panel1.Visible == true)
        {
            nowuser.emergencyname = tbxEName.Text;
            nowuser.emergencyphone = Convert.ToInt32(tbxEPhone.Text);
            nowuser.emergencyrelationship = ddlRelation.SelectedValue;
        }
        int num = UsersDB.updateUser(nowuser);
        if (num != 1)
            lblOutput.Text = "Cannot Update User!";
        else
            lblOutput.Text = "Update Successful!";

    }
    protected void btnPasswordChange_Click(object sender, EventArgs e)
    {
        Server.Transfer("Change Password.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (LinkButton1.Text == "I want to add emergency contact person for me.")
        {
            Session["username"] = tbxUsername.Text;
            Server.Transfer("AddationalRegister.aspx");
        }
        else
        {
            string nemail = Session["email"].ToString();
            Users nowuser = UsersDB.getUserbyEmail(nemail);
            nowuser.emergencyname = "null";
            nowuser.emergencyphone = 0;
            nowuser.emergencyrelationship = "null";
            int num = UsersDB.updateUser(nowuser);
            if (num != 1)
                lblOutput.Text = "Cannot remove Emergency Contact from your account!";
            else
            {
                lblOutput.Text = "Successfully Remove!";
                Panel1.Visible = false;
                LinkButton1.Text = "I want to add emergency contact person for me.";
            }
        }
    }

	
}