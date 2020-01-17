using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for BplTransactionUserToUserDB
/// </summary>
public class BplTransactionUserToUserDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all blood and platelet transaction list from database
    public static List<BplTransactionUserToUser> getAllbpTransUserToUser()
    {
        List<BplTransactionUserToUser> matches = new List<BplTransactionUserToUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionUserToUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BplTransactionUserToUser m = new BplTransactionUserToUser();
                m.bplUserTrasactionID = reader["bplUserTrasactionID"].ToString();
                BPMatchUserToUser es = BPMatchUserToUserDB.getUserBloodRequestsbyMatchID(reader["bpMatchUsrUsr"].ToString());
                m.bpMatchUsrUsr = es;
                m.unitsPossible = 1;
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


    //add new blood and plateles matches to database
    public static int insertbpTrans(BplTransactionUserToUser m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BplTransactionUserToUser values( @bpMatchUsrUsr, @status)");
            command.Parameters.AddWithValue("@bpMatchUsrUsr", m.bpMatchUsrUsr.bpMatchUsrUsrID);
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


    public static int updateBPTranscationUserToUser(BplTransactionUserToUser u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update BplTransactionUserToUser set status=@status where bplUserTrasactionID=@bplUserTrasactionID");
            command.Parameters.AddWithValue("@bplUserTrasactionID", u.bplUserTrasactionID);
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