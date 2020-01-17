using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for BPMatchUserToEstabDB
/// </summary>
public class BPMatchUserToEstabDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all blood and platelet match list from database
    public static List<BPMatchUserToEstab> getAllbpMatchUserToEsta()
    {
        List<BPMatchUserToEstab> matches = new List<BPMatchUserToEstab>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchUserToEstab");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BPMatchUserToEstab m = new BPMatchUserToEstab();
                m.bpMatchUsrEstID = reader["bpMatchUsrEstID"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
                m.matchID = es;
                BloodPlateletRequestUser u = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(reader["bplUserRequestID"].ToString());
                m.bpRequestID = u;
                m.distance = Convert.ToInt32(reader["distance"]);
                m.status = reader["status"].ToString();
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

    public static List<BPMatchUserToEstab> getAllBloodRequestsMatchbyUserID(string bplUserRequestID)
    {
        List<BPMatchUserToEstab> matches = new List<BPMatchUserToEstab>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchUserToEstab where bplUserRequestID=@bplUserRequestID");
            command.Parameters.AddWithValue("@bplUserRequestID", bplUserRequestID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BPMatchUserToEstab m = new BPMatchUserToEstab();
                m.bpMatchUsrEstID = reader["bpMatchUsrEstID"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
                m.matchID = es;
                BloodPlateletRequestUser u = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(reader["bplUserRequestID"].ToString());
                m.bpRequestID = u;
                m.distance = Convert.ToInt32(reader["distance"]);
                m.status = reader["status"].ToString();
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

    public static BPMatchUserToEstab getBloodRequestsMatchbyID(string ID)
    {
        BPMatchUserToEstab m = new BPMatchUserToEstab();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchUserToEstab where bpMatchUsrEstID=@UserID");
            command.Parameters.AddWithValue("@UserID", ID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.bpMatchUsrEstID = reader["bpMatchUsrEstID"].ToString();
                Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
                m.matchID = es;
                BloodPlateletRequestUser u = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(reader["bplUserRequestID"].ToString());
                m.bpRequestID = u;
                m.distance = Convert.ToInt32(reader["distance"]);
                m.status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    //add new blood and plateles matches to database
    public static int insertbp(BPMatchUserToEstab m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BPMatchUserToEstab values( @bplUserRequestID , @matchID , @status ,@distance)");
            command.Parameters.AddWithValue("@bplUserRequestID", m.bpRequestID.bplUserRequestID);
            command.Parameters.AddWithValue("@matchID", m.matchID.ID);
            command.Parameters.AddWithValue("@status", m.status);
            command.Parameters.AddWithValue("@distance", m.distance);
            
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

    public static int updateBPMatchUserToEstab(BPMatchUserToEstab u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update BPMatchUserToEstab set status=@status where bpMatchUsrEstID=@bpMatchUsrEstID");
            command.Parameters.AddWithValue("@bpMatchUsrEstID", u.bpMatchUsrEstID);
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