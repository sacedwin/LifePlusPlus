using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IndividualChatRoom
/// </summary>
public class IndividualChatRoom
{
	public string Sender { get; set; }
	public string Receiver { get; set; }
	public DateTime ChatTime { get; set; }
	public string Messages { get; set; }


	public IndividualChatRoom() { }
	public IndividualChatRoom(string Sender, string Receiver, DateTime ChatTime, string Messages)
	{
		this.Sender = Sender;
		this.Receiver = Receiver;
		this.ChatTime = ChatTime;
		this.Messages = Messages;
	}
}