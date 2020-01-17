using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ForumEstablishmentDB
/// </summary>
public class ForumEstablishmentDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<ForumEstablishment> getAllForumEstablishment()
    {
        List<ForumEstablishment> forumlists = new List<ForumEstablishment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstablishment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumEstablishment fu = new ForumEstablishment();
                fu.ForumID = reader["forumID"].ToString();
                fu.title = reader["title"].ToString();
                fu.message = reader["message"].ToString();
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                fu.estID = es;
                forumlists.Add(fu);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return forumlists;
    }

    //add new forum to database
    public static int insertForum(ForumEstablishment u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into ForumEstablishment values(@title, @message, @date,@status,@establishmentID)");
            command.Parameters.AddWithValue("@title", u.title);
            command.Parameters.AddWithValue("@message", u.message);
            command.Parameters.AddWithValue("@date", u.date);
            command.Parameters.AddWithValue("@status", u.status);
            command.Parameters.AddWithValue("@establishmentID", u.estID.ID);
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

    public static ForumEstablishment getForumEstbyID(string id)
    {
        ForumEstablishment fu = new ForumEstablishment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstablishment where forumID=@forumID");
            command.Parameters.AddWithValue("@forumID", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fu.ForumID = reader["forumID"].ToString();
                fu.title = reader["title"].ToString();
                fu.message = reader["message"].ToString();
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                fu.estID = es;
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return fu;
    }


    public static List<ForumEstablishment> getAllForumEstbyStatus()
    {
        List<ForumEstablishment> forumlists = new List<ForumEstablishment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstablishment where status='allow'");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumEstablishment fu = new ForumEstablishment();
                fu.ForumID = reader["forumID"].ToString();
                fu.title = reader["title"].ToString();
                fu.message = reader["message"].ToString();
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                fu.estID = es;
                forumlists.Add(fu);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return forumlists;
    }
}