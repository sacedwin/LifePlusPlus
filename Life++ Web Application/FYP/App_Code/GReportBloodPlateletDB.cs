using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GReportBloodPlateletDB
/// </summary>
public class GReportBloodPlateletDB
{
	public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);


	public static List<GReportBloodPlatelet> getAllBloodUToE(DateTime from, DateTime to)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,ue.matchID,tue.unitsPossible,bpr.requestDate,tue.status from BloodPlateletRequestUser bpr, BPMatchUserToEstab ue, BplTransactionUserToEstab tue where bpr.bplUserRequestID = ue.bplUserRequestID and ue.bpMatchUsrEstID = tue.bpMatchUsrEstID and requestDate between @from AND @to");
			command.Parameters.AddWithValue("@from", from);
			command.Parameters.AddWithValue("@to", to);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> HgetAllBloodUToE()
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,ue.matchID,tue.unitsPossible,bpr.requestDate,tue.status from BloodPlateletRequestUser bpr, BPMatchUserToEstab ue, BplTransactionUserToEstab tue where bpr.bplUserRequestID = ue.bplUserRequestID and ue.bpMatchUsrEstID = tue.bpMatchUsrEstID and tue.status='complete'");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> getAllBloodUToEWTime(string matchID)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,ue.matchID,tue.unitsPossible,bpr.requestDate,tue.status from BloodPlateletRequestUser bpr, BPMatchUserToEstab ue, BplTransactionUserToEstab tue where bpr.bplUserRequestID = ue.bplUserRequestID and ue.bpMatchUsrEstID = tue.bpMatchUsrEstID and ue.matchID=@matchID and tue.status='complete' ");
			command.Parameters.AddWithValue("@matchID", matchID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}


	public static List<GReportBloodPlatelet> getAllBloodUToU(DateTime from, DateTime to)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,uu.matchID,bpr.requestDate,tuu.status from BloodPlateletRequestUser bpr, BPMatchUserToUser uu, BplTransactionUserToUser tuu where bpr.bplUserRequestID = uu.bplUserRequestID and uu.bpMatchUsrUsr = tuu.bpMatchUsrUsr and requestDate between @from AND @to");
			command.Parameters.AddWithValue("@from", from);
			command.Parameters.AddWithValue("@to", to);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = "1";
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> HgetAllBloodUToU()
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,uu.matchID,bpr.requestDate,tuu.status from BloodPlateletRequestUser bpr, BPMatchUserToUser uu, BplTransactionUserToUser tuu where bpr.bplUserRequestID = uu.bplUserRequestID and uu.bpMatchUsrUsr = tuu.bpMatchUsrUsr and tuu.status='complete'");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = "1";
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}


	public static List<GReportBloodPlatelet> getAllBloodUToUWTime(string ID)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,uu.matchID,bpr.requestDate,bpr.establishmentID, tuu.status from BloodPlateletRequestUser bpr, BPMatchUserToUser uu, BplTransactionUserToUser tuu where bpr.bplUserRequestID = uu.bplUserRequestID and uu.bpMatchUsrUsr = tuu.bpMatchUsrUsr and bpr.establishmentID=@ID and tuu.status='complete'");
			command.Parameters.AddWithValue("@ID", ID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = "1";
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Status = es.Name;
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}



	public static List<GReportBloodPlatelet> getAllBloodUToUWTime()
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplUserRequestID , bpr.requestorID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequird,uu.matchID,bpr.requestDate,tuu.status from BloodPlateletRequestUser bpr, BPMatchUserToUser uu, BplTransactionUserToUser tuu where bpr.bplUserRequestID = uu.bplUserRequestID and uu.bpMatchUsrUsr = tuu.bpMatchUsrUsr  and tuu.status='complete' ");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplUserRequestID"].ToString();
				Users u = UsersDB.getUserbyID(reader["requestorID"].ToString());
				fu.Requestor = u.name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequird"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = "1";
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}



	public static List<GReportBloodPlatelet> getAllBloodEToU(DateTime from, DateTime to)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToUser uu, BplTransactionEstabToUser tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabUserID = tuu.bpMatchEstabUserID and requestDate between @from AND @to");
			command.Parameters.AddWithValue("@from", from);
			command.Parameters.AddWithValue("@to", to);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> HgetAllBloodEToU()
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToUser uu, BplTransactionEstabToUser tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabUserID = tuu.bpMatchEstabUserID and tuu.status='complete'");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> getAllBloodEToUWTime(string matchID)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToUser uu, BplTransactionEstabToUser tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabUserID = tuu.bpMatchEstabUserID and tuu.status='complete' and bpr.establishmentID=@matchID ");
			command.Parameters.AddWithValue("@matchID", matchID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Users u2 = UsersDB.getUserbyID(reader["matchID"].ToString());
				fu.Giver = u2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> getAllBloodEToE(DateTime from, DateTime to)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToEstab uu, BplTransactionEstabToEstab tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabID = tuu.bpMatchEstabID and requestDate between @from AND @to");
			command.Parameters.AddWithValue("@from", from);
			command.Parameters.AddWithValue("@to", to);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> HgetAllBloodEToE()
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToEstab uu, BplTransactionEstabToEstab tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabID = tuu.bpMatchEstabID and tuu.status='complete'");
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}


	public static List<GReportBloodPlatelet> getAllBloodEToEWTime(string matchID)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToEstab uu, BplTransactionEstabToEstab tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabID = tuu.bpMatchEstabID and tuu.status='complete' and uu.matchID=@matchID ");
			command.Parameters.AddWithValue("@matchID", matchID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}

	public static List<GReportBloodPlatelet> getAllBloodEToEWTimeFromE(string matchID)
	{
		List<GReportBloodPlatelet> utoelists = new List<GReportBloodPlatelet>();
		try
		{
			SqlCommand command = new SqlCommand("select bpr.bplEstabRequestID , bpr.establishmentID,bpr.bloodGroup,bpr.bloodOrPlatelet, bpr.unitsRequired,uu.matchID,tuu.unitsPossible,bpr.requestDate,tuu.status from BloodPlateletRequestEstab bpr, BPMatchEstabToEstab uu, BplTransactionEstabToEstab tuu where bpr.bplEstabRequestID = uu.bplEstabRequestID and uu.bpMatchEstabID = tuu.bpMatchEstabID and tuu.status='complete' and bpr.establishmentID=@matchID ");
			command.Parameters.AddWithValue("@matchID", matchID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				GReportBloodPlatelet fu = new GReportBloodPlatelet();

				fu.ID = reader["bplEstabRequestID"].ToString();
				Establishment es = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
				fu.Requestor = es.Name;
				fu.BloodGroup = reader["bloodGroup"].ToString();
				fu.BloodOrPlatelet = reader["bloodOrPlatelet"].ToString();
				fu.UnitRequire = reader["unitsRequired"].ToString();
				Establishment es2 = EstablishmentDB.getEstablishmentByID(reader["matchID"].ToString());
				fu.Giver = es2.Name;
				fu.GivenUnit = reader["unitsPossible"].ToString();
				fu.Date = Convert.ToDateTime(reader["requestDate"]);
				fu.Status = reader["status"].ToString();
				utoelists.Add(fu);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return utoelists;
	}
}