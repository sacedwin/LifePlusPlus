using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminModuleMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
                Server.Transfer("LoginPage.aspx");
            else
            {
                string mail = Session["email"].ToString();
                Admins nowadmin = AdminDB.getAdminbyEmail(mail);
                lblMail.Text = nowadmin.email;
                lblPhone.Text = nowadmin.phone.ToString();
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["email"] = null;
        Server.Transfer("LoginPage.aspx");
    }
}
