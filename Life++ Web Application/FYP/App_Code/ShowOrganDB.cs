using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ShowOrganDB
/// </summary>
public class ShowOrganDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<ShowOrgan> getAllDOrganListByDonor(string donor)
	{
		List<ShowOrgan> organlist = new List<ShowOrgan>();
		try
		{
			SqlCommand command = new SqlCommand("select omd.deceasedOrganMatch,dd.establishmentID,dd.organType,rw.establishmentID,dd.hospitalPatientNumber from organMatchingDeceased omd, deceasedDonor dd, organReceiverWaiting rw where omd.deceasedOrganID = dd.deceasedOrganID and omd.OrganWlID = rw.OrganWlID and omd.status = 'complete' and dd.establishmentID = @donor");
			command.Parameters.AddWithValue("@donor", donor);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ShowOrgan r = new ShowOrgan();
				r.DOID = reader["deceasedOrganMatch"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["dd.establishmentID"].ToString());
				r.Donor = es.Name;
				r.OrganType = reader["organType"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["rw.establishmentID"].ToString());
				r.Receiver = es2.Name;
				r.hospitalRefNum = reader["hospitalPatientNumber"].ToString();
				organlist.Add(r);

			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return organlist;

	}


	public static List<ShowOrgan> getAllDOrganListByReceiver(string donor)
	{
		List<ShowOrgan> organlist = new List<ShowOrgan>();
		try
		{
			SqlCommand command = new SqlCommand("select omd.deceasedOrganMatch,dd.establishmentID,dd.organType,rw.establishmentID,dd.hospitalPatientNumber from organMatchingDeceased omd, deceasedDonor dd, organReceiverWaiting rw where omd.deceasedOrganID = dd.deceasedOrganID and omd.OrganWlID = rw.OrganWlID and omd.status = 'complete' and rw.establishmentID = @donor");
			command.Parameters.AddWithValue("@donor", donor);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ShowOrgan r = new ShowOrgan();
				r.DOID = reader["deceasedOrganMatch"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["dd.establishmentID"].ToString());
				r.Donor = es.Name;
				r.OrganType = reader["organType"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["rw.establishmentID"].ToString());
				r.Receiver = es2.Name;
				r.hospitalRefNum = reader["hospitalPatientNumber"].ToString();
				organlist.Add(r);

			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return organlist;

	}

	public static List<ShowOrgan> getAllLOrganListByReceiver(string donor)
	{
		List<ShowOrgan> organlist = new List<ShowOrgan>();
		try
		{
			SqlCommand command = new SqlCommand("select ld.ldonorID,ld.userID,ld.organType,rw.establishmentID,rw.hospitalPatientNumber from liveDonor ld, organMatchingLive ml, organReceiverWaiting rw where ld.ldonorID = ml.ldonorID and ml.OrganWlID = rw.OrganWlID and rw.status = 'complete' and rw.establishmentID = @donor");
			command.Parameters.AddWithValue("@donor", donor);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				ShowOrgan r = new ShowOrgan();
				r.DOID = reader["ldonorID"].ToString();
				Users es = UsersDB.getUserbyID(reader["ld.userID"].ToString());
				r.Donor = es.name;
				r.OrganType = reader["organType"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["rw.establishmentID"].ToString());
				r.Receiver = es2.Name;
				r.hospitalRefNum = reader["hospitalPatientNumber"].ToString();
				organlist.Add(r);

			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return organlist;

	}
}