using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Server.Transfer("LoginPage.aspx");
            }
            else
            {
                string nemail = Session["email"].ToString();
                Admins nowadmin = AdminDB.getAdminbyEmail(nemail);
                tbxAdminId.Text = nowadmin.adminId;
                tbxName.Text = nowadmin.name;
                tbxEmail.Text = nowadmin.email;
                tbxPassword.Text = nowadmin.password;
                tbxAddress.Text = nowadmin.address;
                tbxAdminPhone.Text = nowadmin.phone.ToString();
            }

        }

    }

    protected void btnPasswordChange_Click(object sender, EventArgs e)
    {
        Server.Transfer("ChangePassword.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string nemail = Session["email"].ToString();
        Admins nadmin = AdminDB.getAdminbyEmail(nemail);
        nadmin.address = tbxAddress.Text;
        nadmin.Name = tbxName.Text;
        nadmin.phone = Convert.ToInt32(tbxAdminPhone.Text);
        int num = AdminDB.updateAdmin(nadmin);
        if (num != 1)
            lblOutput.Text = "Cannot Update Admin!";
        else
            lblOutput.Text = "Update Successful!";
    }
}