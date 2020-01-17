using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for BloodPlateletRequestUserDB
/// </summary>
public class BloodPlateletRequestUserDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<BloodPlateletRequestUser> getUserBloodRequestsbyUserID(string UserID)
    {
        List<BloodPlateletRequestUser> userrequests = new List<BloodPlateletRequestUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BloodPlateletRequestUser where requestorID=@UserID");
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BloodPlateletRequestUser br = new BloodPlateletRequestUser();
                br.bplUserRequestID = reader["bplUserRequestID"].ToString();
                br.Units = Convert.ToInt32(reader["unitsRequird"]);
                br.unitMatched = Convert.ToInt32(reader["unitsMatched"]);
                Establishment est = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                br.Establishment = est;
                Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
                br.requestorID = u;
                br.Type = reader["bloodGroup"].ToString();
                br.bloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
                br.Status = reader["status"].ToString();
                br.Time = Convert.ToDateTime(reader["requestDate"]);
                userrequests.Add(br);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return userrequests;
    }

    public static BloodPlateletRequestUser getUserBloodRequestsbyID(string bplUserRequestID)
    {
        List<BloodPlateletRequestUser> userrequests = new List<BloodPlateletRequestUser>();
        BloodPlateletRequestUser br = new BloodPlateletRequestUser();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BloodPlateletRequestUser where bplUserRequestID=@bplUserRequestID");
            command.Parameters.AddWithValue("@bplUserRequestID  ", bplUserRequestID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                br.bplUserRequestID = reader["bplUserRequestID"].ToString();
                br.Units = Convert.ToInt32(reader["unitsRequird"]);
                br.unitMatched = Convert.ToInt32(reader["unitsMatched"]);
                Establishment est = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                br.Establishment = est;
                Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
                br.requestorID = u;
                br.Type = reader["bloodGroup"].ToString();
                br.bloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
                br.Status = reader["status"].ToString();
                br.Time = Convert.ToDateTime(reader["requestDate"]);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return br;
    }

    public static List<BloodPlateletRequestUser> getAllUserBloodRequests()
    {
        List<BloodPlateletRequestUser> userrequests = new List<BloodPlateletRequestUser>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BloodPlateletRequestUser");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BloodPlateletRequestUser br = new BloodPlateletRequestUser();
                br.bplUserRequestID = reader["bplUserRequestID"].ToString();
                br.Units = Convert.ToInt32(reader["unitsRequird"]);
                br.unitMatched = Convert.ToInt32(reader["unitsMatched"]);
                Establishment est = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                br.Establishment = est;
                Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
                br.requestorID = u;
                br.Type = reader["bloodGroup"].ToString();
                br.bloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
                br.Status = reader["status"].ToString();
                br.Time = Convert.ToDateTime(reader["requestDate"]);
                userrequests.Add(br);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return userrequests;
    }



    public static int insertBloodRequestByUser(BloodPlateletRequestUser br)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BloodPlateletRequestUser values(@unitsRequird ,@unitMatched, @establishmentID , @requestorID , @bloodGroup , @bloodOrPlatelet , @status , @requestDate)");
            command.Parameters.AddWithValue("@unitsRequird", br.Units);
            command.Parameters.AddWithValue("@unitMatched", br.unitMatched);
            command.Parameters.AddWithValue("@establishmentID", br.Establishment.ID);
            command.Parameters.AddWithValue("@requestorID", br.requestorID.userId);
            command.Parameters.AddWithValue("@bloodGroup", br.Type);
            command.Parameters.AddWithValue("@bloodOrPlatelet", br.bloodOrPlatelet);
            command.Parameters.AddWithValue("@status", br.Status);
            command.Parameters.AddWithValue("@requestDate", br.Time);
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


    public static int updateBloodPlateles(BloodPlateletRequestUser u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update BloodPlateletRequestUser set status=@status where bplUserRequestID=@bplUserRequestID");
            command.Parameters.AddWithValue("@bplUserRequestID", u.bplUserRequestID);
			command.Parameters.AddWithValue("@unitsMatched", u.unitMatched);
			command.Parameters.AddWithValue("@status", u.Status);
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