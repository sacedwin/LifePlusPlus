using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for IndividualChatRoomDB
/// </summary>
public class IndividualChatRoomDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<IndividualChatRoom> getAllChat()
	{
		List<IndividualChatRoom> chats = new List<IndividualChatRoom>();
		try
		{
			SqlCommand command = new SqlCommand("select * from [dbo].[IndividualChat] order by time");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				IndividualChatRoom m = new IndividualChatRoom();
				m.Sender = reader["sender"].ToString();
				m.Receiver = reader["receiver"].ToString();
				m.ChatTime = Convert.ToDateTime(reader["time"]);
				m.Messages = reader["message"].ToString();

				chats.Add(m);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return chats;
	}

	public static List<IndividualChatRoom> getAllChatby2ID(string sender,string receiver)
	{
		List<IndividualChatRoom> chats = new List<IndividualChatRoom>();
		try
		{
			SqlCommand command = new SqlCommand("select * from IndividualChat where (sender=@sender or sender=@receiver) and (receiver=@sender  or receiver=@receiver) order by time");
			command.Parameters.AddWithValue("@sender", sender);
			command.Parameters.AddWithValue("@receiver", receiver);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				IndividualChatRoom m = new IndividualChatRoom();
				m.Sender = reader["sender"].ToString();
				m.Receiver = reader["receiver"].ToString();
				m.ChatTime = Convert.ToDateTime(reader["time"]);
				m.Messages = reader["message"].ToString();
				chats.Add(m);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return chats;
	}



	public static int insertIndChat(IndividualChatRoom ld)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("insert into IndividualChat values(@sender, @receiver, @time, @message)");
			command.Parameters.AddWithValue("@sender", ld.Sender);
			command.Parameters.AddWithValue("@receiver", ld.Receiver);
			command.Parameters.AddWithValue("@time", ld.ChatTime);
			command.Parameters.AddWithValue("@message", ld.Messages);
			command.Connection = connection;
			connection.Open();
			if (command.ExecuteNonQuery() > 0)
			{
				num = 1;
			}
		}
		finally
		{
			connection.Close();
		}
		return num;
	}

}