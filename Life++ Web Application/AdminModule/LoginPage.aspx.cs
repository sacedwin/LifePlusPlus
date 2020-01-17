using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            lblOutput.Text = "";
            lblOutput2.Text = "";
            tbxemail.Text = "";
            tbxpassword.Text = "";
        }
        

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblOutput.Text = "";
        string tge= tbxemail.Text;
        string tpw = tbxpassword.Text;
        bool tpass = false;
        bool temail = false;
        List<Admins> adminslist = AdminDB.getallAdmins();

        foreach (Admins m in adminslist)
        {
            if (tbxemail.Text.ToLower() == m.email.ToLower())
            {
                temail = true;
                break;
            }
            else
                temail = false;
        }

        foreach (Admins m in adminslist)
        {
            if (tbxpassword.Text == m.password)
            {
                tpass = true;
                break;
            }
            else
                tpass = false;
        }

        if (temail == false)
        {
            lblOutput.ForeColor = System.Drawing.Color.Red;
            lblOutput.Text = "Email doesn't exists";
        }
        else if (tpass == false)
        {
            lblOutput.ForeColor = System.Drawing.Color.Red;
            lblOutput.Text = "Wrong Password";
        }
        else if (tpass == true & temail == true)
        {
            Admins tempAdmin = AdminDB.getAdminbyEmail(tbxemail.Text);
			//can log in if the status is active otherwise cannot log in
            if (tempAdmin.status == "Active")
            {
                lblOutput.Text = "";
                Session["email"] = tbxemail.Text;
                Server.Transfer("MyAccount.aspx");
            }
            else
            {
                tbxemail.Text = "";
                tbxpassword.Text = "";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "<br/>Sorry you can no longer access to this account.";
            }
        }
    }

    protected void linkFGPassword_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        tbxFgEmail.Text = "";
        lblOutput2.Text = "";
    }

    protected void linkBack_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        lblOutput.Text = "";
        tbxemail.Text = "";
        tbxpassword.Text = "";
    }

    protected void btnFgSubmit_Click(object sender, EventArgs e)
    {
        List<Admins> adminslist = AdminDB.getallAdmins();
        int found = 0;
        try
        {
			//check email is existing in database
            foreach (Admins m in adminslist)
            {
                if (tbxFgEmail.Text == m.email)
                {
                    found = 1;
                    break;
                }
            }

            if (found == 0)
            {
                lblOutput2.Text = "Email Address not found! Please Try Again.";
                lblOutput2.ForeColor = System.Drawing.Color.Red;
                return;
            }

            else
            {
				//if email forget sent password to the email of the textbox
                Admins fgmail = AdminDB.getAdminbyEmail(tbxFgEmail.Text);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("inft3050@gmail.com", "inft.3050");
                MailMessage msg = new MailMessage("inft3050@gmail.com", tbxFgEmail.Text);
                msg.Subject = "Your Current Password";
                msg.Body = "Your password is: " + fgmail.password;
                client.Send(msg);
                lblOutput2.ForeColor = System.Drawing.Color.Green;
                lblOutput2.Text = "Reset password sent to " + tbxFgEmail.Text;
            }
        }
        catch (Exception)
        {
			//if cannot sent the text color will change to red
            lblOutput2.ForeColor = System.Drawing.Color.Red;
            lblOutput2.Text = "Unable to sent email! Try Again";
        }
    }
}