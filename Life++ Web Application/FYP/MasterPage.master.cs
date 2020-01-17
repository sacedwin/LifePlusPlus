using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                btnLogin.Text = "Login";
                btnMyAccount.Visible = false;
            }
            else
            {
                btnLogin.Text = "Logout";
                btnMyAccount.Visible = true;
            }
        }
        
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (btnLogin.Text == "Login")
        {
            Server.Transfer("CommonLogin.aspx");
        }

        else
        {
            Session["email"] = null;
            Session["username"] = null;
            btnMyAccount.Visible = false;
            btnLogin.Text = "Login";
            Server.Transfer("CommonLogin.aspx");
        }
    }
    
    protected void btnMyAccount_Click1(object sender, EventArgs e)
    {
        Server.Transfer("MyAccount.aspx");
    }
}
