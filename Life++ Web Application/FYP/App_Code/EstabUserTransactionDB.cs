using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EstabUserTransactionDB
/// </summary>
public class EstabUserTransactionDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<EstabUserTransaction> getAllTransactions()
    {
        List<EstabUserTransaction> transactions = new List<EstabUserTransaction>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionEstabToUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EstabUserTransaction t = new EstabUserTransaction();
                t.ID = reader["bplEstabTrasactionID"].ToString();
                t.Match = EstabUserMatchDB.getUserMatchByID(reader["bpMatchEstabUserID"].ToString());
                t.Units = Convert.ToInt32(reader["unitsPossible"]);
                t.Status = reader["status"].ToString();
                transactions.Add(t);

            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return transactions;
    }

    public static int insertTransaction(EstabUserTransaction t)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into bplTransactionEstabToUser values(@bpMatchEstabUserID, @unitsPossible, @status)");
            command.Parameters.AddWithValue("@bpMatchEstabUserID", t.Match.ID);
            command.Parameters.AddWithValue("@unitsPossible", t.Units);
            command.Parameters.AddWithValue("@status", t.Status);
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

    public static int updateTransaction(EstabUserTransaction t)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update bplTransactionEstabToUser set status=@status where bplEstabTrasactionID=@id");
            command.Parameters.AddWithValue("@status", t.Status);
            command.Parameters.AddWithValue("@id", t.ID);
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