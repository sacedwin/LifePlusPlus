using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for ForumUserCommentbyEstDB
/// </summary>
public class ForumUserCommentbyEstDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<ForumUserCommentbyEst> getAlloneForumAllComment()
    {
        List<ForumUserCommentbyEst> fulists = new List<ForumUserCommentbyEst>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUserCommentbyEst");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumUserCommentbyEst fu = new ForumUserCommentbyEst();

                fu.forumcommentID = reader["forumcommentID"].ToString();
                AForumUser onef = AForumUserDB.getForumUserbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                Establishment u = EstablishmentDB.getEstablishmentByID(reader["commentby"].ToString());
                fu.commentby = u;
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                fulists.Add(fu);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return fulists;
    }

    public static List<ForumUserCommentbyEst> getoneForumAllCommentbyID(string forumID)
    {
        List<ForumUserCommentbyEst> fulists = new List<ForumUserCommentbyEst>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUserCommentbyEst where forumID=@forumID");
            command.Parameters.AddWithValue("@forumID", forumID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumUserCommentbyEst fu = new ForumUserCommentbyEst();

                fu.forumcommentID = reader["forumcommentID"].ToString();
                AForumUser onef = AForumUserDB.getForumUserbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                Establishment u = EstablishmentDB.getEstablishmentByID(reader["commentby"].ToString());
                fu.commentby = u;
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
                fulists.Add(fu);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return fulists;
    }

    public static ForumUserCommentbyEst getoneForumCommentbyID(string forumcommentID)
    {
        ForumUserCommentbyEst fu = new ForumUserCommentbyEst();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumUserCommentbyEst where forumcommentID=@forumcommentID");
            command.Parameters.AddWithValue("@forumcommentID", forumcommentID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fu.forumcommentID = reader["forumcommentID"].ToString();
                AForumUser onef = AForumUserDB.getForumUserbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                Establishment u = EstablishmentDB.getEstablishmentByID(reader["commentby"].ToString());
                fu.commentby = u;
                fu.date = Convert.ToDateTime(reader["date"]);
                fu.status = reader["status"].ToString();
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
    public static int insertForumCommentUser(ForumUserCommentbyEst u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into ForumUserCommentbyUser values(@forumID, @comments, @commentby,@date,@status)");
            command.Parameters.AddWithValue("@forumID", u.forumID.forumID);
            command.Parameters.AddWithValue("@comments", u.comments);
            command.Parameters.AddWithValue("@commentby", u.commentby.ID);
            command.Parameters.AddWithValue("@date", u.date);
            command.Parameters.AddWithValue("@status", u.status);  
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

    public static int updateComment(ForumUserCommentbyEst u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update ForumUserCommentbyEst set status=@status where forumcommentID=@forumcommentID");
            command.Parameters.AddWithValue("@forumcommentID", u.forumcommentID);
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