using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DeceasedDonorDB
/// </summary>
public class DeceasedDonorDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<DeceasedDonor> getAllDeceasedDonors()
	{
		List<DeceasedDonor> DeceasedDonors = new List<DeceasedDonor>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from deceasedDonor");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedDonor o = new DeceasedDonor();
				o.ID = reader["deceasedOrganID"].ToString();
				o.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
				DeceasedDonors.Add(o);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return DeceasedDonors;
	}

	public static int insertDeceasedDonor(DeceasedDonor o)
	{
		try
		{
			SqlCommand command = new SqlCommand("insert into deceasedDonor values (@establishmentID, @bloodGroup, @DOB, @height, @weight, @deathDate, @organType, @comments, @hospitalPatientNumber, @status)");
			command.Parameters.AddWithValue("@establishmentID", o.Establishment.ID);
			command.Parameters.AddWithValue("@bloodGroup", o.Bloodgroup);
			command.Parameters.AddWithValue("@DOB", o.DOB);
			command.Parameters.AddWithValue("@height", o.Donorheight);
			command.Parameters.AddWithValue("@weight", o.Donorweight);
			command.Parameters.AddWithValue("@deathDate", o.Deathdate);
			command.Parameters.AddWithValue("@organType", o.Organtype);
			command.Parameters.AddWithValue("@comments", o.Comments);
			command.Parameters.AddWithValue("@hospitalPatientNumber", o.Refnumber);
			command.Parameters.AddWithValue("@status", o.Status);
			command.Connection = connection;
			connection.Open();
			return command.ExecuteNonQuery();
		}
		finally
		{
			connection.Close();
		}
	}

	public static List<DeceasedDonor> getOrgansByType(string organType)
	{
		List<DeceasedDonor> DeceasedDonors = new List<DeceasedDonor>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from deceasedDonor where organType = @organType");
			command.Parameters.AddWithValue("@organType", organType);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedDonor o = new DeceasedDonor();
				o.ID = reader["deceasedOrganID"].ToString();
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
				DeceasedDonors.Add(o);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return DeceasedDonors;
	}

	public static List<DeceasedDonor> getOrgansByTypeEstab(string organType, Establishment e)
	{
		List<DeceasedDonor> DeceasedDonors = new List<DeceasedDonor>();
		try
		{
			string eID = e.ID;
			SqlCommand command = new SqlCommand("Select * from deceasedDonor where organType = @organType and establishmentID = @eID");
			command.Parameters.AddWithValue("@organType", organType);
			command.Parameters.AddWithValue("@eID", eID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedDonor o = new DeceasedDonor();
				o.ID = reader["deceasedOrganID"].ToString();
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
				DeceasedDonors.Add(o);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return DeceasedDonors;
	}

	public static List<DeceasedDonor> getOrgansByBlood(string bloodType)
	{
		List<DeceasedDonor> DeceasedDonors = new List<DeceasedDonor>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from deceasedDonor where bloodGroup = @bloodType");
			command.Parameters.AddWithValue("@bloodType", bloodType);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedDonor o = new DeceasedDonor();
				o.ID = reader["deceasedOrganID"].ToString();
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
				DeceasedDonors.Add(o);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return DeceasedDonors;
	}

	public static List<DeceasedDonor> getOrgansByBloodEstab(string bloodType, Establishment e)
	{
		List<DeceasedDonor> DeceasedDonors = new List<DeceasedDonor>();
		try
		{
			string eID = e.ID;
			SqlCommand command = new SqlCommand("Select * from deceasedDonor where bloodGroup = @bloodType and establishmentID = @eID");
			command.Parameters.AddWithValue("@bloodType", bloodType);
			command.Parameters.AddWithValue("@eID", eID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DeceasedDonor o = new DeceasedDonor();
				o.ID = reader["deceasedOrganID"].ToString();
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
				DeceasedDonors.Add(o);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return DeceasedDonors;
	}

	public static int updateDeceasedDonor(DeceasedDonor ao)
	{
		int num = -1;
		try
		{
			SqlCommand command = new SqlCommand("update deceasedDonor set status=@status, comments=@comments where deceasedOrganID=@id");
			command.Parameters.AddWithValue("@status", ao.Status);
			command.Parameters.AddWithValue("@comments", ao.Comments);
			command.Parameters.AddWithValue("@id", ao.ID);
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

	public static DeceasedDonor getDonorByID(string id)
	{
		DeceasedDonor o = new DeceasedDonor();
		try
		{
			SqlCommand command = new SqlCommand("Select * from deceasedDonor where deceasedOrganID = @id");
			command.Parameters.AddWithValue("@id", id);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				o.ID = reader["deceasedOrganID"].ToString();
				o.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				o.Bloodgroup = reader["bloodGroup"].ToString();
				o.DOB = Convert.ToDateTime(reader["DOB"]);
				o.Donorheight = Convert.ToInt32(reader["height"]);
				o.Donorweight = Convert.ToInt32(reader["weight"]);
				o.Deathdate = Convert.ToDateTime(reader["deathDate"]);
				o.Organtype = reader["organType"].ToString();
				o.Comments = reader["comments"].ToString();
				o.Refnumber = reader["hospitalPatientNumber"].ToString();
				o.Status = reader["status"].ToString();
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return o;
	}

}