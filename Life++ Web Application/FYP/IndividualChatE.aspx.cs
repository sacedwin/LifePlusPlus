using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndividualChatE : System.Web.UI.Page
{
	string estID, uUsername;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["echat"] != null)
		{
			string eID = Session["echat"].ToString();
			Establishment r = EstablishmentDB.getEstablishmentByID(eID);
			lblName.Text = r.Name;
			Establishment s = (Establishment)Session["establishment"];
			tbxChat.Text = "";
			List<IndividualChatRoom> iuu = IndividualChatRoomDB.getAllChatby2ID(s.ID, r.ID);
			tbxChat.Style["text-align"] = "left";
			if (iuu.Count > 0)
			{
				foreach (IndividualChatRoom i in iuu)
				{
					if (i.Sender == s.ID)
					{
						tbxChat.Text += s.Name + " : " + i.Messages + "\r\n";

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
		else if (Session["rwEst"] != null)
		{
			string eID = Session["rwEst"].ToString();
			Establishment re = EstablishmentDB.getEstablishmentByID(eID);
			lblName.Text = re.Name;
			Establishment s = (Establishment)Session["establishment"];
			tbxChat.Text = "";
			List<IndividualChatRoom> iuu = IndividualChatRoomDB.getAllChatby2ID(s.ID, re.ID);
			tbxChat.Style["text-align"] = "left";
			if (iuu.Count > 0)
			{
				foreach (IndividualChatRoom i in iuu)
				{
					if (i.Sender == s.ID)
					{
						tbxChat.Text += s.Name + " : " + i.Messages + "\r\n";

					}
					else
					{
						tbxChat.Text += re.Name + " : " + i.Messages + "\r\n";
					}

				}

			}
			else
			{
				tbxChat.Text = "You can start the chat now";
				tbxChat.Style["text-align"] = "center";
			}

		}
		else if(Session["ldID"] !=null)
		{

			Users r = UsersDB.getUserbyID(Session["ldID"].ToString());
			lblName.Text = r.Name;
			Establishment s = (Establishment)Session["establishment"];
			tbxChat.Text = "";
			List<IndividualChatRoom> iuu = IndividualChatRoomDB.getAllChatby2ID(s.ID, r.UserId);
			tbxChat.Style["text-align"] = "left";
			if (iuu.Count > 0)
			{
				foreach (IndividualChatRoom i in iuu)
				{
					if (i.Sender == s.ID)
					{
						tbxChat.Text += s.Name + " : " + i.Messages + "\r\n";

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

	}


	protected void Timer1_Tick1(object sender, EventArgs e)
	{
		UpdatePanel1.Update();
	}

	protected void BtnSentMessage_Click1(object sender, EventArgs e)
	{
		if (Session["echat"] != null)
		{
			string eID = Session["echat"].ToString();
			Establishment r = EstablishmentDB.getEstablishmentByID(eID);
			Establishment s = (Establishment)Session["establishment"];
			IndividualChatRoom icr = new IndividualChatRoom(s.ID, r.ID, System.DateTime.Now, TextBox1.Text);
			IndividualChatRoomDB.insertIndChat(icr);
		}
		else if (Session["rwEst"] != null)
		{
			string eID = Session["rwEst"].ToString();
			Establishment r = EstablishmentDB.getEstablishmentByID(eID);
			Establishment s = (Establishment)Session["establishment"];
			IndividualChatRoom icr = new IndividualChatRoom(s.ID, r.ID, System.DateTime.Now, TextBox1.Text);
			IndividualChatRoomDB.insertIndChat(icr);
		}
		else
		{
			Users r = UsersDB.getUserbyID(Session["ldID"].ToString());
			Establishment s = (Establishment)Session["establishment"];
			IndividualChatRoom icr = new IndividualChatRoom(s.ID, r.userId, System.DateTime.Now, TextBox1.Text);
			IndividualChatRoomDB.insertIndChat(icr);
		}
		TextBox1.Text = "";
		UpdatePanel1.Update();

	}
}