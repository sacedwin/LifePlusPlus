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
                ForumEstablishment onef = ForumEstablishmentDB.getForumEstbyID(reader["forumID"].ToString());
                fu.forumID = onef;
                fu.comments = reader["comments"].ToString();
                Users u = UsersDB.getUserbyID(reader["commentby"].ToString());
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
}