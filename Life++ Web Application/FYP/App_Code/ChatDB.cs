using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for ChatDB
/// </summary>
public class ChatDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all chat list from database
    public static List<Chat> getallChat()
    {
        List<Chat> clist = new List<Chat>();
        try
        {
            SqlCommand command = new SqlCommand("select * from Chat Order By id asc");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Chat m = new Chat();
                m.id = reader["id"].ToString();
                m.message = reader["message"].ToString();
                m.by = reader["sentby"].ToString();
                m.time = Convert.ToDateTime(reader["time"]);
                m.status = reader["status"].ToString();
                clist.Add(m);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return clist;
    }

    public static int insertChat(Chat m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into chat values( @message, @sentby, @time,@status)");
            command.Parameters.AddWithValue("@message", m.message);
            command.Parameters.AddWithValue("@sentby", m.by);
            command.Parameters.AddWithValue("@time", m.time);
            command.Parameters.AddWithValue("@status", m.status);
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