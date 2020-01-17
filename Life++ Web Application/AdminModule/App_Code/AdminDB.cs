using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for AdminDB
/// </summary>
public class AdminDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all admins list from database
    public static List<Admins> getallAdmins()
    {
        List<Admins> admins = new List<Admins>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from administrator");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Admins m = new Admins();
                m.adminId = reader["adminID"].ToString();
                m.email = reader["email"].ToString();
                m.name = reader["name"].ToString();
                m.password = reader["password"].ToString();
                m.address = reader["address"].ToString();
                m.phone = Convert.ToInt32(reader["phone"]);
                m.status = reader["status"].ToString();
                admins.Add(m);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return admins;
    }

    //add new admin to database
    public static int insertAdmin(Admins m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into administrator values( @email, @name, @password,@address,@phone, @status)");
            command.Parameters.AddWithValue("@email", m.Email);
            command.Parameters.AddWithValue("@name", m.Name);
            command.Parameters.AddWithValue("@password", m.Password);
            command.Parameters.AddWithValue("@address", m.Address);
            command.Parameters.AddWithValue("@phone", m.Phone);
            command.Parameters.AddWithValue("@status", m.Status);

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

    //get Admin by Email
    public static Admins getAdminbyEmail(string email)
    {
        Admins m = new Admins();
        try
        {
            SqlCommand command = new SqlCommand("Select * from administrator where email = @email");
            command.Parameters.AddWithValue("@email", email);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                m.adminId = reader["adminID"].ToString();
                m.email = reader["email"].ToString();
                m.name = reader["name"].ToString();
                m.password = reader["password"].ToString();
                m.address = reader["address"].ToString();
                m.phone = Convert.ToInt32(reader["phone"]);
                m.status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    //Update Admin in the database
    public static int updateAdmin(Admins m)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update administrator set name=@name, password=@password,address=@address,phone=@phone,status=@status where email=@email");
            command.Parameters.AddWithValue("@email", m.Email);
            command.Parameters.AddWithValue("@name", m.Name);
            command.Parameters.AddWithValue("@password", m.Password);
            command.Parameters.AddWithValue("@address", m.Address);
            command.Parameters.AddWithValue("@phone", m.Phone);
            command.Parameters.AddWithValue("@status", m.Status);
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


	//get Admin by ID
	public static Admins getAdminbyID(string ID)
	{
		Admins m = new Admins();
		try
		{
			SqlCommand command = new SqlCommand("Select * from administrator where adminID = @adminID");
			command.Parameters.AddWithValue("@adminID", ID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				m.adminId = reader["adminID"].ToString();
				m.email = reader["email"].ToString();
				m.name = reader["name"].ToString();
				m.password = reader["password"].ToString();
				m.address = reader["address"].ToString();
				m.phone = Convert.ToInt32(reader["phone"]);
				m.status = reader["status"].ToString();
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return m;
	}

}