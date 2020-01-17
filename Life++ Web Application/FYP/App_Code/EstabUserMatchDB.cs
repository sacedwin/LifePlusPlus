using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EstabUserMatchDB
/// </summary>
public class EstabUserMatchDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<EstabUserMatch> getAllUserMatches()
    {
        List<EstabUserMatch> matches = new List<EstabUserMatch>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchEstabToUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EstabUserMatch m = new EstabUserMatch();
                m.ID = reader["bpMatchEstabUserID"].ToString();
                m.Request = EstablishmentBPRequestDB.getRequestByID(reader["bplEstabRequestID"].ToString());
                m.Match = UsersDB.getUserbyID(reader["UserID"].ToString());
                m.Status = reader["status"].ToString();
                m.Distance = Convert.ToInt32(reader["distance"]);
                matches.Add(m);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return matches;
    }

    public static int insertMatch(EstabUserMatch m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BPMatchEstabToUser values(@bplEstabRequestID, @matchID, @status, @distance)");
            command.Parameters.AddWithValue("@bplEstabRequestID", m.Request.ID);
            command.Parameters.AddWithValue("@matchID", m.Match.userId);
            command.Parameters.AddWithValue("@status", m.Status);
            command.Parameters.AddWithValue("@distance", m.Distance);
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

    public static EstabUserMatch getUserMatchByID(string id)
    {
        EstabUserMatch m = new EstabUserMatch();
        try
        {
            SqlCommand command = new SqlCommand("Select * from bpMatchEstabToUser where bpMatchEstabUserID = @id");
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.ID = reader["bpMatchEstabUserID"].ToString();
                m.Request = EstablishmentBPRequestDB.getRequestByID(reader["bplEstabRequestID"].ToString());
                m.Match = UsersDB.getUserbyID(reader["matchID"].ToString());
                m.Status = reader["status"].ToString();
                m.Distance = Convert.ToInt32(reader["distance"]);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    public static int updateMatch(EstabUserMatch m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update BPMatchEstabToUser set status=@status where bpMatchEstabUserID=@id");
            command.Parameters.AddWithValue("@status", m.Status);
            command.Parameters.AddWithValue("@id", m.ID);
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