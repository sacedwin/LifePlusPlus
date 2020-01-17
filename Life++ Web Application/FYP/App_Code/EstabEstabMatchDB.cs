using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class EstabEstabMatchDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<EstabEstabMatch> getAllMatches()
    {
        List<EstabEstabMatch> matches = new List<EstabEstabMatch>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchEstabToEstab");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EstabEstabMatch m = new EstabEstabMatch();
                m.ID = reader["bpMatchEstabID"].ToString();
                m.Request = EstablishmentBPRequestDB.getRequestByID(reader["bplEstabRequestID"].ToString());
                m.Match = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
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

    public static int insertMatch(EstabEstabMatch m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BPMatchEstabToEstab values(@bplEstabRequestID, @matchID, @status, @distance)");
            command.Parameters.AddWithValue("@bplEstabRequestID", m.Request.ID);
            command.Parameters.AddWithValue("@matchID", m.Match.ID);
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

    public static EstabEstabMatch getMatchByID(string id)
    {
        EstabEstabMatch m = new EstabEstabMatch();
        try
        {
            SqlCommand command = new SqlCommand("Select * from bpMatchEstabToEstab where bpMatchEstabID = @id");
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.ID = reader["bpMatchEstabID"].ToString();
                m.Request = EstablishmentBPRequestDB.getRequestByID(reader["bplEstabRequestID"].ToString());
                m.Match = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
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

    public static int updateMatch(EstabEstabMatch m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update BPMatchEstabToEstab set status=@status where bpMatchEstabID=@id");
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


