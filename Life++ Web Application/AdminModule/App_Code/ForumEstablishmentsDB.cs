using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ForumEstablishmentsDB
/// </summary>
public class ForumEstablishmentsDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<ForumEstablishments> getAllForumEstablishment()
    {
        List<ForumEstablishments> forumlists = new List<ForumEstablishments>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstablishment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumEstablishments fu = new ForumEstablishments();
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
    public static int insertForum(ForumEstablishments u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into ForumUser values(@title, @message, @date,@status,@establishmentID)");
            command.Parameters.AddWithValue("@title", u.title);
            command.Parameters.AddWithValue("@message", u.message);
            command.Parameters.AddWithValue("@date", u.date);
            command.Parameters.AddWithValue("@status", u.date);
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

    public static ForumEstablishments getForumEstbyID(string id)
    {
        ForumEstablishments fu = new ForumEstablishments();
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

    public static int updateEstForum(ForumEstablishments u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update ForumEstablishment set status=@status where title=@title");
            command.Parameters.AddWithValue("@title", u.title);
            command.Parameters.AddWithValue("@status", u.status);
            command.Connection = connection;
            connection.Open();
            result = command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
        return result;
    }
}