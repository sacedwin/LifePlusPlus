using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Chat
/// </summary>
public class Chat
{
    public string id { get; set; }
    public string message { get; set; }
    public string by { get; set; }
    public string status { get; set; }
    public DateTime time { get; set; }
	public Chat()
	{
	}
    public Chat(string message,string by,DateTime time,string status)
    {
        this.message = message;
        this.by = by;
        this.time = time;
        this.status = status;
    }
}