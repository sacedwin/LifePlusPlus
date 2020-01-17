using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
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
                tbxCurrentPsw.TextMode = TextBoxMode.Password;
                tbxnewPass.TextMode = TextBoxMode.Password;
                tbxnewPassRepeat.TextMode = TextBoxMode.Password;

            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string nemail = Session["email"].ToString();
        Admins now = AdminDB.getAdminbyEmail(nemail);
        string np = tbxnewPass.Text;
        string np2 = tbxnewPassRepeat.Text;

        if (now.password != tbxCurrentPsw.Text)
        {
            lblCP.Visible = true;
            return;
        }
        else
        {
            lblCP.Visible = false;
            if (np == np2)
            {
                now.password = np;
                int num = AdminDB.updateAdmin(now);
                if (num != 1)
                    lblOutput.Text = "Cannot Change Password!";
                else
                {
                    lblOutput.Text = "Password Updated!";
					//auto refresh the page
                    string MyAccountUrl = "MyAccount.aspx";
                    Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=1;url={0}> ", MyAccountUrl)));
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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
		//show or hide password by changing text mode
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