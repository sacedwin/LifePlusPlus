using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LiveOrganMatchingDB
/// </summary>
public class LiveOrganMatchingDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<LiveOrganMatching> getAllMatches()
    {
        List<LiveOrganMatching> matches = new List<LiveOrganMatching>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from organMatchingLive");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LiveOrganMatching m = new LiveOrganMatching();
                m.ID = reader["liveOrganMatch"].ToString();
                m.LiveDonor = LiveDonorDB.getLiveDonorbyID(reader["ldonorID"].ToString());
                m.Recipient = OrganRecipientDB.getRecipientByID(reader["OrganWlID"].ToString());
                m.MatchScore = Convert.ToInt32(reader["matchScore"]);
                m.Comments = reader["comments"].ToString();
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

    public static int insertMatch(LiveOrganMatching m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into organMatchingLive values(@ldonorID, @OrganWlID, @matchScore, @comments, @status, @distance)");
            command.Parameters.AddWithValue("@ldonorID", m.LiveDonor.ldonorID);
            command.Parameters.AddWithValue("@OrganWlID", m.Recipient.ID);
            command.Parameters.AddWithValue("@matchScore", m.MatchScore);
            command.Parameters.AddWithValue("@comments", m.Comments);
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

    public static LiveOrganMatching getMatchByID(string id)
    {
        LiveOrganMatching m = new LiveOrganMatching();
        try
        {
            SqlCommand command = new SqlCommand("Select * from organMatchingLive where liveOrganMatch = @id");
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.ID = reader["liveOrganMatch"].ToString();
                m.LiveDonor = LiveDonorDB.getLiveDonorbyID(reader["ldonorID"].ToString());
                m.Recipient = OrganRecipientDB.getRecipientByID(reader["OrganWlID"].ToString());
                m.MatchScore = Convert.ToInt32(reader["matchScore"]);
                m.Comments = reader["comments"].ToString();
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

    public static int updateMatch(LiveOrganMatching m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update organMatchingLive set status=@status where liveOrganMatch=@id");
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