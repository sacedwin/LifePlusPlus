using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for BplTransactionUserToEstabDB
/// </summary>
public class BplTransactionUserToEstabDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<BplTransactionUserToEstab> getAllbpTransactionUserToEsta()
    {
        List<BplTransactionUserToEstab> matches = new List<BplTransactionUserToEstab>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionUserToEstab");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BplTransactionUserToEstab m = new BplTransactionUserToEstab();
                m.bplUserToEstabTrasactionID = reader["bplUserToEstabTrasactionID"].ToString();
                BPMatchUserToEstab es = BPMatchUserToEstabDB.getBloodRequestsMatchbyID(reader["bpMatchUsrEstID"].ToString());
                m.bpMatchUsrEstID = es;
                m.unit = Convert.ToInt32(reader["unitsPossible"]);
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

	public static List<BplTransactionUserToEstab> getAllbpTransactionUserToEstabyTime(DateTime from,DateTime to)
	{
		List<BplTransactionUserToEstab> matches = new List<BplTransactionUserToEstab>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from BplTransactionUserToEstab WHERE requestDate BETWEEN @fromdate AND @todate");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				BplTransactionUserToEstab m = new BplTransactionUserToEstab();
				m.bplUserToEstabTrasactionID = reader["bplUserToEstabTrasactionID"].ToString();
				BPMatchUserToEstab es = BPMatchUserToEstabDB.getBloodRequestsMatchbyID(reader["bpMatchUsrEstID"].ToString());
				m.bpMatchUsrEstID = es;
				m.unit = Convert.ToInt32(reader["unitsPossible"]);
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

	public static BplTransactionUserToEstab getbpTransactionUserToEstabyID(string bplUserToEstabTrasactionID)
    {
        BplTransactionUserToEstab m = new BplTransactionUserToEstab();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionUserToEstab where bplUserToEstabTrasactionID=@bplUserToEstabTrasactionID");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.bplUserToEstabTrasactionID = reader["bplUserToEstabTrasactionID"].ToString();
                BPMatchUserToEstab es = BPMatchUserToEstabDB.getBloodRequestsMatchbyID(reader["bpMatchUsrEstID"].ToString());
                m.bpMatchUsrEstID = es;
                m.unit = Convert.ToInt32(reader["unitsPossible"]);
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

    public static BplTransactionUserToEstab getbpTransactionUserToEstabymatchID(string bpMatchUsrEstID)
    {
        BplTransactionUserToEstab m = new BplTransactionUserToEstab();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionUserToEstab where bpMatchUsrEstID=@bpMatchUsrEstID");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.bplUserToEstabTrasactionID = reader["bplUserToEstabTrasactionID"].ToString();
                BPMatchUserToEstab es = BPMatchUserToEstabDB.getBloodRequestsMatchbyID(reader["bpMatchUsrEstID"].ToString());
                m.bpMatchUsrEstID = es;
                m.unit = Convert.ToInt32(reader["unitsPossible"]);
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
    public static int insertbptrans(BplTransactionUserToEstab m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BplTransactionUserToEstab values( @bpMatchUsrEstID , @unitsPossible , @status )");
            command.Parameters.AddWithValue("@bpMatchUsrEstID", m.bpMatchUsrEstID.bpMatchUsrEstID);
            command.Parameters.AddWithValue("@unitsPossible", m.unit);
            command.Parameters.AddWithValue("@status", m.status);       
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

    public static int updateBPTranscationUserToEstab(BplTransactionUserToEstab u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update BplTransactionUserToEstab set status=@status where bplUserToEstabTrasactionID=@bplUserToEstabTrasactionID");
            command.Parameters.AddWithValue("@bplUserToEstabTrasactionID", u.bplUserToEstabTrasactionID);
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