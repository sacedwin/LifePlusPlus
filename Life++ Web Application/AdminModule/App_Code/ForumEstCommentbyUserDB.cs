using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for ForumEstCommentbyUserDB
/// </summary>
public class ForumEstCommentbyUserDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<ForumEstCommentbyUser> getalloneForumAllComment()
    {
        List<ForumEstCommentbyUser> fulists = new List<ForumEstCommentbyUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstCommentbyUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumEstCommentbyUser fu = new ForumEstCommentbyUser();

                fu.forumcommentID = reader["forumcommentID"].ToString();
                ForumEstablishments onef = ForumEstablishmentsDB.getForumEstbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                AUser u = AUserDB.getUserbyID(reader["commentby"].ToString());
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

    public static List<ForumEstCommentbyUser> getoneForumAllCommentbyID(string forumID)
    {
        List<ForumEstCommentbyUser> fulists = new List<ForumEstCommentbyUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstCommentbyUser where forumID=@forumID");
            command.Parameters.AddWithValue("@forumID", forumID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ForumEstCommentbyUser fu = new ForumEstCommentbyUser();

                fu.forumcommentID = reader["forumcommentID"].ToString();
                ForumEstablishments onef = ForumEstablishmentsDB.getForumEstbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                AUser u = AUserDB.getUserbyID(reader["commentby"].ToString());
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

    public static ForumEstCommentbyUser getoneForumCommentbyID(string forumcommentID)
    {
        ForumEstCommentbyUser fu = new ForumEstCommentbyUser();
        try
        {
            SqlCommand command = new SqlCommand("Select * from ForumEstCommentbyUser where forumcommentID=@forumcommentID");
            command.Parameters.AddWithValue("@forumcommentID", forumcommentID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fu.forumcommentID = reader["forumcommentID"].ToString();
                ForumEstablishments onef = ForumEstablishmentsDB.getForumEstbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                AUser u = AUserDB.getUserbyID(reader["commentby"].ToString());
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
    public static int insertForumCommentUser(ForumEstCommentbyUser u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into ForumEstCommentbyUser values(@forumID, @comments, @commentby,@date,@status)");
            command.Parameters.AddWithValue("@forumID", u.forumID.forumID);
            command.Parameters.AddWithValue("@comments", u.comments);
            command.Parameters.AddWithValue("@commentby", u.commentby.userId);
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

    public static int updateComment(ForumEstCommentbyUser u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update ForumEstCommentbyUser set status=@status where forumcommentID=@forumcommentID");
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