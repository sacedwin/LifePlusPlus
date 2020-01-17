using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LastDonationDateDB
/// </summary>
public class LastDonationDateDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<LastDonationDate> getAllLastDonations()
	{
		List<LastDonationDate> lastDonations = new List<LastDonationDate>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from LastDonationDate");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				LastDonationDate ld = new LastDonationDate();
				ld.ID = reader["dID"].ToString();
				ld.User = UsersDB.getUserbyID(reader["userId"].ToString());
				ld.LastDonation = Convert.ToDateTime(reader["donationDate"]);
				ld.Type = reader["type"].ToString();
				ld.Status = reader["status"].ToString();
				lastDonations.Add(ld);

			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return lastDonations;
	}

	public static int insertLastDonation(LastDonationDate ld)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("insert into LastDonationDate values(@userId, @donationDate, @type, @status)");
			command.Parameters.AddWithValue("@userId", ld.User.UserId);
			command.Parameters.AddWithValue("@donationDate", ld.LastDonation);
			command.Parameters.AddWithValue("@type", ld.Type);
			command.Parameters.AddWithValue("@status", ld.Status);
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

	public static int updateLastDonation(LastDonationDate ld)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("update LastDonationDate set donationDate=@lastdonation, status=@status, type=@type where dId=@id");
			command.Parameters.AddWithValue("@lastdonation", ld.LastDonation);
			command.Parameters.AddWithValue("@status", ld.Status);
			command.Parameters.AddWithValue("@type", ld.Type);
			command.Parameters.AddWithValue("@id", ld.ID);
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