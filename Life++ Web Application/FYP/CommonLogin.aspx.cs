using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;

public partial class CommonLogin : System.Web.UI.Page
{
    bool tf;
    protected void Page_Load(object sender, EventArgs e)
    {
		//if log in and go to log in page again cannot go to that page
		if (Session["email"] != null)
		{
			Server.Transfer("HomePage.aspx");
		}
		else
		{
			if (Session["establishment"] != null)
			{
				Establishment es = (Establishment)Session["establishment"];
				if (es.Type == "NGO")
					Server.Transfer("NHomePage.aspx");
				else if (es.Type == "Government")
					Server.Transfer("GMyAccount.aspx");
				else
					Server.Transfer("HospitalHomePage.aspx");

			}
		}

		lblErrorLogin.Visible = false;
		//log in with facebook
        FaceBookConnect.API_Key = "1330396383674964";
        FaceBookConnect.API_Secret = "fdfe5d2ff200c25b00bb237121a7ab21";
        if (!IsPostBack)
        {
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                return;
            }

            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
				//get info from facebook
                string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email,gender");
                FacebookUser faceBookUser = new JavaScriptSerializer().Deserialize<FacebookUser>(data);
                faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                string femail = faceBookUser.Email;
                List<Users> userslist = UsersDB.getallUsers();
				//check all the condition below and if the user not found go to register page with facebook detail
                foreach (Users u in userslist)
                {

                    if (femail.ToLower() == u.email.ToLower())
                    {
                        tf = true;
                        break;
                    }
                    else
                        tf = false;
                }

                if (tf == true)
                {
                    Users tempUser = UsersDB.getUserbyEmail(femail);
                    if (tempUser.status == "Debar")
                    {
                        lblErrorLogin.Visible = true;
                        tbxEmail.Text = "";
                        tbxPassword.Text = "";
                        lblErrorLogin.Text = "Your account have been blocked. Please contact us.";
                        return;
                    }
                    else
                    {
                        lblErrorLogin.Visible = false;
                        Session["email"] = faceBookUser.Email;
                        Server.Transfer("HomePage.aspx");
                    }

                }
                else
                {
                    Session["name"] = faceBookUser.Name;
                    Session["femail"] = faceBookUser.Email;
                    Session["propic"] = faceBookUser.PictureUrl;
                    Session["gender"] = faceBookUser.Gender;
                    Server.Transfer("FacebookRegister.aspx");
                }
            }
        }
    }
    protected void linkReset_Click(object sender, EventArgs e)
    {
        Server.Transfer("ForgetPassword.aspx");
    }

   

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bool upassword = false;
        bool uemail = false;

        List<Users> userslist = UsersDB.getallUsers();

        foreach (Users u in userslist)
        {

            if (tbxEmail.Text.ToLower() == u.email.ToLower())
            {
                uemail = true;
                break;
            }
            else
                uemail = false;
        }

        foreach (Users u in userslist)
        {
            if (tbxPassword.Text == u.password)
            {
                upassword = true;
                break;
            }
            else
                upassword = false;
        }

        if (uemail == false)
        {
            lblErrorLogin.Visible = true;
            lblErrorLogin.Text = "Email doesn't exists";
        }
        else if (upassword == false)
        {
            lblErrorLogin.Visible = true;
            lblErrorLogin.Text = "Wrong Password";
        }
        else if (upassword == true & uemail == true)
        {//if account is debar cannot log in
            Users tempUser = UsersDB.getUserbyEmail(tbxEmail.Text);
            if (tempUser.status == "Debar")
            {
                lblErrorLogin.Visible = true;
                tbxEmail.Text = "";
                tbxPassword.Text = "";
                lblErrorLogin.Text = "Your account have been blocked. Please contact us.";
            }
            else
            {
                lblErrorLogin.Visible = false;
                Session["email"] = tbxEmail.Text;
                Server.Transfer("HomePage.aspx");
            }
        }

    }
    protected void linkRegister_Click(object sender, EventArgs e)
    {
        Server.Transfer("RegisterForm.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
		//get facebook authorization
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }

    

    
}