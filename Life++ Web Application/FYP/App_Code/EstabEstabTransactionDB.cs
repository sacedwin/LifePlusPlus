using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EstabEstabTransactionDB
/// </summary>
public class EstabEstabTransactionDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<EstabEstabTransaction> getAllTransactions()
    {
        List<EstabEstabTransaction> transactions = new List<EstabEstabTransaction>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BplTransactionEstabToEstab");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EstabEstabTransaction t = new EstabEstabTransaction();
                t.ID = reader["bplEstabTrasactionID"].ToString();
                t.Match = EstabEstabMatchDB.getMatchByID(reader["bpMatchEstabID"].ToString());
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

    public static int insertTransaction(EstabEstabTransaction t)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into bplTransactionEstabToEstab values(@bpMatchEstabID, @unitsPossible, @status)");
            command.Parameters.AddWithValue("@bpMatchEstabID", t.Match.ID);
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

    public static int updateTransaction(EstabEstabTransaction t)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update bplTransactionEstabToEstab set status=@status where bplEstabTrasactionID=@id");           
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