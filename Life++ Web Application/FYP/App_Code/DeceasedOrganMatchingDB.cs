using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DeceasedOrganMatchingDB
/// </summary>
public class DeceasedOrganMatchingDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<DeceasedOrganMatching> getAllMatches()
	{
		List<DeceasedOrganMatching> matches = new List<DeceasedOrganMatching>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from organMatchingDeceased");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedOrganMatching m = new DeceasedOrganMatching();
				m.ID = reader["deceasedOrganMatch"].ToString();
				m.DeceasedDonor = DeceasedDonorDB.getDonorByID(reader["deceasedOrganID"].ToString());
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

	public static int insertMatch(DeceasedOrganMatching m)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("insert into organMatchingDeceased values(@deceasedOrganID, @OrganWlID, @matchScore, @comments, @status, @distance)");
			command.Parameters.AddWithValue("@deceasedOrganID", m.DeceasedDonor.ID);
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

	public static DeceasedOrganMatching getMatchByID(string id)
	{
		DeceasedOrganMatching m = new DeceasedOrganMatching();
		try
		{
			SqlCommand command = new SqlCommand("Select * from organMatchingDeceased where deceasedOrganMatch = @id");
			command.Parameters.AddWithValue("@id", id);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				m.ID = reader["deceasedOrganMatch"].ToString();
				m.DeceasedDonor = DeceasedDonorDB.getDonorByID(reader["deceasedOrganID"].ToString());
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

	public static int updateMatch(DeceasedOrganMatching m)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("update organMatchingDeceased set status=@status, comments=@comments where deceasedOrganMatch=@id");
			command.Parameters.AddWithValue("@status", m.Status);
			command.Parameters.AddWithValue("@comments", m.Comments);
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