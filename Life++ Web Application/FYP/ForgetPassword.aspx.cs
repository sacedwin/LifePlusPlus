using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class ForgetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        lblError.Text = "";
    }
    protected void linkLoginPage_Click(object sender, EventArgs e)
    {
        Server.Transfer("CommonLogin.aspx");
    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        List<Users> userslist = UsersDB.getallUsers();
        int found = 0;
        try
        {

            foreach (Users u in userslist)
            {
                if (tbxFgEmail.Text == u.email)
                {
                    found = 1;
                    break;
                }
            }


            if (found == 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Email Address not found! Please Try Again.";
                return;
            }

            else
            {
                Users fgmail = UsersDB.getUserbyEmail(tbxFgEmail.Text);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("inft3050@gmail.com", "inft.3050");
                MailMessage msg = new MailMessage("inft3050@gmail.com", tbxFgEmail.Text);
                msg.Subject = "Your Current Password";
                msg.Body = "Your password is: " + fgmail.password ;
                client.Send(msg);

                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Reset password sent to " + tbxFgEmail.Text;
            }
        }
        catch (Exception)
        {
            lblError.Visible = true;
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Unable to sent email! Try Again";
        }
    }
}