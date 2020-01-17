using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TranscationHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["email"] == null)
            {
                Server.Transfer("CommonLogin.aspx");
            }
            else
            {
                Users u = UsersDB.getUserbyEmail(Session["email"].ToString());
                List<LiveDonor> ldLists = LiveDonorDB.getLiveDonorbyuserID(u.userId);
                List<LiveDonor> cancellist = new List<LiveDonor>();
                foreach (LiveDonor l in ldLists)
                {
                    if (l.status == "cancelled" || l.status == "allotted")
                    {
                        cancellist.Add(l);
                    }
                }
                if (cancellist.Count == 0)
                {
                    Label1.Text="Sorry! You don't have any transcation yet!";
                    return;
                }
                else
                {
                    Label1.Text = "We found " + cancellist.Count + " Donation History!";
					cancellist.Reverse();
                    gvDHistory.DataSource = cancellist;
                    gvDHistory.DataBind();

                }

            }
        }
    }
    protected void gvDHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvDHistory.PageIndex = e.NewPageIndex;
        gvDHistory.DataBind();
    }
}