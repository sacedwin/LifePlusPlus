using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for EstablishmentDB
/// </summary>
public class EstablishmentDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<Establishment> getAllEstablishments()
    {
        List<Establishment> establishments = new List<Establishment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from establishment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Establishment e = new Establishment();
                e.ID = reader["establishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
                establishments.Add(e);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return establishments;
    }


    public static List<Establishment> getAllTempEstablishments()
    {
        List<Establishment> establishments = new List<Establishment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from tempEstablishment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Establishment e = new Establishment();
                e.ID = reader["tempEstablishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
                establishments.Add(e);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return establishments;
    }

    public static List<Establishment> getAllTempEstablishmentsbyStatus(string status)
    {
        List<Establishment> establishments = new List<Establishment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from tempEstablishment where status=@status");
            command.Parameters.AddWithValue("@status", status);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Establishment e = new Establishment();
                e.ID = reader["tempEstablishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
                establishments.Add(e);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return establishments;
    }

    public static int insertTempEstablishment(Establishment e)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into tempEstablishment values(@email, @name, @password, @type, @phone, @address, @status)");
            command.Parameters.AddWithValue("@email", e.Email);
            command.Parameters.AddWithValue("@name", e.Name);
            command.Parameters.AddWithValue("@password", e.Password);
            command.Parameters.AddWithValue("@type", e.Type);
            command.Parameters.AddWithValue("@phone", e.Phone);
            command.Parameters.AddWithValue("@address", e.Address);
            command.Parameters.AddWithValue("@status", "pending");
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

    public static int insertEstablishment(Establishment e)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into establishment values(@email, @name, @password, @type, @phone, @address,@adminID,@tempEstablishmentID, @status)");
            command.Parameters.AddWithValue("@email", e.Email);
            command.Parameters.AddWithValue("@name", e.Name);
            command.Parameters.AddWithValue("@password", e.Password);
            command.Parameters.AddWithValue("@type", e.Type);
            command.Parameters.AddWithValue("@phone", e.Phone);
            command.Parameters.AddWithValue("@address", e.Address);
            command.Parameters.AddWithValue("@adminID", e.Admin.adminId);
            command.Parameters.AddWithValue("@tempEstablishmentID", e.ID);
            command.Parameters.AddWithValue("@status", "active");
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



    public static Establishment getEstablishmentByEmail(string email)
    {
        Establishment e = new Establishment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from establishment where email = @email");
            command.Parameters.AddWithValue("@email", email);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                e.ID = reader["tempEstablishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return e;
    }

    public static Establishment getTempEstablishmentByEmail(string email)
    {
        Establishment e = new Establishment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from tempEstablishment where email = @email");
            command.Parameters.AddWithValue("@email", email);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                e.ID = reader["tempEstablishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return e;

    }

    public static Establishment getEstablishmentByID(string establishmentID)
    {
        Establishment e = new Establishment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from establishment where establishmentID = @establishmentID");
            command.Parameters.AddWithValue("@establishmentID", establishmentID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                e.ID = reader["establishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return e;
    }

    public static Establishment getEstablishmentByName(string name)
    {
        Establishment e = new Establishment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from establishment where name = @name");
            command.Parameters.AddWithValue("@name", name);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                e.ID = reader["establishmentID"].ToString();
                e.Email = reader["email"].ToString();
                e.Name = reader["name"].ToString();
                e.Password = reader["password"].ToString();
                e.Type = reader["type"].ToString();
                e.Phone = Convert.ToInt32(reader["phone"]);
                e.Address = reader["address"].ToString();
                e.Status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return e;
    }


    //Update tempestablishment in the database
    public static int updatetempStatus(Establishment u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update tempEstablishment set status=@status where tempEstablishmentID=@id");
            command.Parameters.AddWithValue("@id", u.ID);
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

	//Update establishment in the database
	public static int updateEstPassowrd(Establishment u)
	{
		int result;
		try
		{
			SqlCommand command = new SqlCommand("Update establishment set password=@password where establishmentID=@id");
			command.Parameters.AddWithValue("@id", u.ID);
			command.Parameters.AddWithValue("@password", u.Password);
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

	//Update establishment in the database
	public static int updateEstInfo(Establishment u)
	{
		int result;
		try
		{
			SqlCommand command = new SqlCommand("Update establishment set name=@name,phone=@phone,address=@address where establishmentID=@id");
			command.Parameters.AddWithValue("@id", u.ID);
			command.Parameters.AddWithValue("@name", u.Name);
			command.Parameters.AddWithValue("@phone", u.Phone);
			command.Parameters.AddWithValue("@address", u.Address);
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