using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ForumUserDB
/// </summary>
public class ForumUserDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<ForumUser> getAllForumUser()
    {
        List<ForumUser> forumlists = new List<ForumUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumUser fu = new ForumUser();
                fu.ForumID = reader["forumID"].ToString();
                fu.title = reader["title"].ToString();
                fu.message = reader["message"].ToString();
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                Users u = UsersDB.getUserbyID(reader["UserID"].ToString());
                fu.userID = u;
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

    public static List<ForumUser> getAllForumUserbyStatus()
    {
        List<ForumUser> forumlists = new List<ForumUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUser where status='allow'");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumUser fu = new ForumUser();
                fu.ForumID = reader["forumID"].ToString();
                fu.title = reader["title"].ToString();
                fu.message = reader["message"].ToString();
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                Users u = UsersDB.getUserbyID(reader["UserID"].ToString());
                fu.userID = u;
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

    public static ForumUser getForumUserbyID(string id)
    {
        ForumUser fu = new ForumUser();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUser where forumID=@forumID");
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
                Users u = UsersDB.getUserbyID(reader["UserID"].ToString());
                fu.userID = u;
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return fu;
    }

    //add new forum to database
    public static int insertForum(ForumUser u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into ForumUser values(@title, @message, @date,@status,@UserID)");
            command.Parameters.AddWithValue("@title", u.title);
            command.Parameters.AddWithValue("@message", u.message);
            command.Parameters.AddWithValue("@date", u.date);
            command.Parameters.AddWithValue("@status", u.status);
            command.Parameters.AddWithValue("@UserID", u.userID.userId);
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