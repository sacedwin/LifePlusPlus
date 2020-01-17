using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddationalRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOutput.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = Session["username"].ToString();
        Users euser = UsersDB.getUserbyUsername(username);
        euser.emergencyname = tbxEName.Text;
        euser.emergencyphone = Convert.ToInt32(tbxEPhone.Text);
        euser.emergencyrelationship = ddlRelation.SelectedItem.Text;
        int num = UsersDB.updateEmergencyUser(euser);
        if (num != 1)
            lblOutput.Text = "Cannot Register Emergency Contact!";
        else
        {
            lblOutput.Text = "Successful! Emergency contact is added to your account.";
			//auto redirect to the same page in 2 sec
            string MyAccountUrl = "MyAccount.aspx";
            Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=2;url={0}> ", MyAccountUrl)));
        }
    }
}