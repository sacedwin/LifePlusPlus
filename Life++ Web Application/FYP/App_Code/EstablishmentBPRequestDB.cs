using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EstablishmentBPRequestDB
/// </summary>
public class EstablishmentBPRequestDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<EstablishmentBPRequest> getAllEstablishmentRequests()
    {
        List<EstablishmentBPRequest> establishmentRequests = new List<EstablishmentBPRequest>();
        try
        {         
            SqlCommand command = new SqlCommand("Select * from BloodPlateletRequestEstab");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EstablishmentBPRequest r = new EstablishmentBPRequest();
                r.ID = reader["bplEstabRequestID"].ToString();
                r.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                r.Units = Convert.ToInt32(reader["unitsRequired"]);
                r.MatchedUnits = Convert.ToInt32(reader["unitsMatched"]);
                r.BloodGroup = reader["bloodGroup"].ToString();
                r.Type = reader["bloodOrPlatelet"].ToString();
                r.Status = reader["status"].ToString();
                r.RequestDate = Convert.ToDateTime(reader["requestDate"]);
                establishmentRequests.Add(r);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return establishmentRequests;
    }

    public static int insertEstablishmentRequest(EstablishmentBPRequest r)
    {
        try
        {
            SqlCommand command = new SqlCommand("insert into BloodPlateletRequestEstab values (@unitsRequired, @unitsMatched, @establishmentID, @bloodGroup, @bloodOrPlatelet, @status, @requestDate)");
            command.Parameters.AddWithValue("@unitsRequired", r.Units);
            command.Parameters.AddWithValue("@unitsMatched", r.MatchedUnits);
            command.Parameters.AddWithValue("@establishmentID", r.Establishment.ID);
            command.Parameters.AddWithValue("@bloodGroup", r.BloodGroup);
            command.Parameters.AddWithValue("@bloodOrPlatelet", r.Type);            
            command.Parameters.AddWithValue("@status", r.Status);
            command.Parameters.AddWithValue("@requestDate", r.RequestDate);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    public static int updateEstablishmentRequest(EstablishmentBPRequest r)
    {
        try
        {
            SqlCommand command = new SqlCommand("update bloodPlateletRequestEstab set unitsRequired = @unitsRequired, unitsMatched = @unitsMatched, status = @status where bplEstabRequestID = @id");
            command.Parameters.AddWithValue("@unitsRequired", r.Units);
            command.Parameters.AddWithValue("@unitsMatched", r.MatchedUnits);
            command.Parameters.AddWithValue("@status", r.Status);
            command.Parameters.AddWithValue("@id", r.ID);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }


    public static EstablishmentBPRequest getRequestByID(string id)
    {
        EstablishmentBPRequest r = new EstablishmentBPRequest();
        try
        {
            SqlCommand command = new SqlCommand("Select * from bloodPlateletRequestEstab where bplEstabRequestID = @id");
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                r.ID = reader["bplEstabRequestID"].ToString();
                r.Units = Convert.ToInt32(reader["unitsRequired"]);
                r.MatchedUnits = Convert.ToInt32(reader["unitsMatched"]);
                r.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                r.BloodGroup = reader["bloodGroup"].ToString();
                r.Type = reader["bloodOrPlatelet"].ToString();
                r.Status = reader["status"].ToString();
                r.RequestDate = Convert.ToDateTime(reader["requestDate"]);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return r;
    }
}