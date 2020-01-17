using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LiveDonorDB
/// </summary>
public class LiveDonorDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all LiveDonor list from database
    public static List<LiveDonor> getallLiveDonor()
    {
        List<LiveDonor> lDonors = new List<LiveDonor>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from LiveDonor");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LiveDonor u = new LiveDonor();
                u.ldonorID = reader["ldonorID"].ToString();
                Users us = UsersDB.getUserbyID(reader["userID"].ToString());
                u.userid = us;
                u.comments = reader["comments"].ToString();
                u.status = reader["status"].ToString();
                u.doctorName = reader["doctorName"].ToString();
                u.organType = reader["organType"].ToString();
                u.doctorNumber = Convert.ToInt32(reader["doctorNumber"]);
                u.DoctorAddress = reader["doctorAddress"].ToString();
                u.DoctorEmail = reader["doctorEmail"].ToString();
                lDonors.Add(u);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return lDonors;
    }

    //get LiveDonor by Email
    public static List<LiveDonor> getLiveDonorbyuserID(string userID)
    {
        List<LiveDonor> livelist = new List<LiveDonor>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from LiveDonor where userID = @userID");
            command.Parameters.AddWithValue("@userID", userID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                LiveDonor u = new LiveDonor();
                u.ldonorID = reader["ldonorID"].ToString();
                Users us = UsersDB.getUserbyID(reader["userID"].ToString());
                u.userid = us;
                u.comments = reader["comments"].ToString();
                u.organType = reader["organType"].ToString();
                u.status = reader["status"].ToString();
                u.doctorName = reader["doctorName"].ToString();
                u.doctorNumber = Convert.ToInt32(reader["doctorNumber"]);
                u.DoctorAddress = reader["doctorAddress"].ToString();
                u.DoctorEmail = reader["doctorEmail"].ToString();
                livelist.Add(u);

            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return livelist;
    }

    //get LiveDonor by ID
    public static LiveDonor getLiveDonorbyID(string ID)
    {
        LiveDonor u = new LiveDonor();
        try
        {
            SqlCommand command = new SqlCommand("Select * from LiveDonor where ldonorID = @ldonorID");
            command.Parameters.AddWithValue("@ldonorID", ID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                u.ldonorID = reader["ldonorID"].ToString();
                Users us = UsersDB.getUserbyID(reader["userID"].ToString());
                u.userid = us;
                u.comments = reader["comments"].ToString();
                u.organType = reader["organType"].ToString();
                u.status = reader["status"].ToString();
                u.doctorName = reader["doctorName"].ToString();
                u.doctorNumber = Convert.ToInt32(reader["doctorNumber"]);
                u.DoctorAddress = reader["doctorAddress"].ToString();
                u.DoctorEmail = reader["doctorEmail"].ToString();

            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return u;
    }

    //insert LiveDonor to database
    public static int insertLiveDonor(LiveDonor i)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into LiveDonor values( @userid, @organType, @comments, @status, @doctorName, @doctorNumber,@doctorAddress,@doctorEmail)");
            command.Parameters.AddWithValue("@userid", i.userid.userId);
            command.Parameters.AddWithValue("@organType", i.organType);
            command.Parameters.AddWithValue("@comments", i.comments);
            command.Parameters.AddWithValue("@status", i.status);
            command.Parameters.AddWithValue("@doctorName", i.doctorName);
            command.Parameters.AddWithValue("@doctorNumber", i.doctorNumber);
            command.Parameters.AddWithValue("@doctorAddress", i.doctorAddress);
            command.Parameters.AddWithValue("@doctorEmail", i.doctorEmail);
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

    //Update liveDonation in the database
    public static int updateLiveDonor(LiveDonor u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update LiveDonor set status=@status where lDonorID=@lDonorID");
            command.Parameters.AddWithValue("@lDonorID", u.ldonorID);
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