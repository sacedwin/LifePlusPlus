using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndividualChatUU : System.Web.UI.Page
{
	string estID, uUsername;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["chat"] == null)
		{
			string eID= Session["echat"].ToString();
			Establishment r = EstablishmentDB.getEstablishmentByID(eID);
			lblName.Text = r.Name;
			Users s = UsersDB.getUserbyEmail(Session["email"].ToString());
			tbxChat.Text = "";
			List<IndividualChatRoom> iuu = IndividualChatRoomDB.getAllChatby2ID(r.ID, s.UserId);
			tbxChat.Style["text-align"] = "left";
			if (iuu.Count > 0)
			{
				foreach (IndividualChatRoom i in iuu)
				{
					if (i.Sender == s.UserId)
					{
						tbxChat.Text += s.username + " : " + i.Messages + "\r\n";

					}
					else
					{
						tbxChat.Text += r.Name + " : " + i.Messages + "\r\n";
					}

				}

			}
			else
			{
				tbxChat.Text = "You can start the chat now";
				tbxChat.Style["text-align"] = "center";
			}
		}

		else
		{
			uUsername = Session["chat"].ToString();
			Users r = UsersDB.getUserbyID(uUsername);
			lblName.Text = r.username;
			Users s = UsersDB.getUserbyEmail(Session["email"].ToString());
			tbxChat.Text = "";
			List<IndividualChatRoom> iuu = IndividualChatRoomDB.getAllChatby2ID(r.UserId, s.UserId);
			tbxChat.Style["text-align"] = "left";
			if (iuu.Count > 0)
			{
				foreach (IndividualChatRoom i in iuu)
				{
					if (i.Sender == s.userId)
					{
						tbxChat.Text += s.username + " : " + i.Messages + "\r\n";
						
					}
					else
					{
						tbxChat.Text += r.username + " : " + i.Messages + "\r\n";
					}

				}

			}
			else
			{
				tbxChat.Text = "You can start the chat now";
				tbxChat.Style["text-align"] = "center";
			}
		}

	}


	protected void Timer1_Tick1(object sender, EventArgs e)
	{
		UpdatePanel1.Update();
	}

	protected void BtnSentMessage_Click1(object sender, EventArgs e)
	{
		if (Session["chat"] != null)
		{
			Users s = UsersDB.getUserbyEmail(Session["email"].ToString());
			Users r = UsersDB.getUserbyUsername(lblName.Text);
			IndividualChatRoom icr = new IndividualChatRoom(s.UserId, r.UserId, System.DateTime.Now, TextBox1.Text);
			IndividualChatRoomDB.insertIndChat(icr);
			
		}
		else
		{
			string eID = Session["echat"].ToString();
			Users s = UsersDB.getUserbyEmail(Session["email"].ToString());
			Establishment r = EstablishmentDB.getEstablishmentByID(eID);
			IndividualChatRoom icr = new IndividualChatRoom(s.UserId, r.ID, System.DateTime.Now, TextBox1.Text);
			IndividualChatRoomDB.insertIndChat(icr);
		}
		TextBox1.Text = "";
		UpdatePanel1.Update();

	}
}