using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GChatRoom : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["establishment"] == null)
		{
			Server.Transfer("CommonLogin.aspx");
		}
		else
		{
			List<Chat> clist = ChatDB.getallChat();
			foreach (Chat ch in clist)
			{
				Users s = UsersDB.getUserbyID(ch.by);
				if (s.email == null)
				{
					Establishment es = EstablishmentDB.getEstablishmentByID(ch.by);
					if (ch.status == "allow")
						tbxChat.Text += es.Name + " @ " + ch.time + " : " + ch.message + "\r\n";
				}
				else
				{
					if (ch.status == "allow")
						tbxChat.Text += s.username + " @ " + ch.time + " : " + ch.message + "\r\n";
				}
			}
		}

	}

	protected void Timer1_Tick1(object sender, EventArgs e)
	{
		UpdatePanel1.Update();
	}
}