using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for UsersDB
/// </summary>
public class UsersDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all user list from database
    public static List<Users> getallUsers()
    {
        List<Users> users = new List<Users>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Users");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Users u = new Users();
                u.userId = reader["UserId"].ToString();
                u.email = reader["Email"].ToString();
                u.name = reader["Name"].ToString();
                u.dob = Convert.ToDateTime(reader["DOB"]);
                u.gender = reader["Gender"].ToString();
                u.rstatus = reader["Rstatus"].ToString();
                u.height = Convert.ToInt32(reader["Height"]);
                u.weight = Convert.ToInt32(reader["Weight"]);
                u.bloodtype = reader["BloodType"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.phone = Convert.ToInt32(reader["Phone"]);
                u.nric = reader["NRICNo"].ToString();
                u.emergencyname = reader["EmergencyName"].ToString();
                u.emergencyphone = Convert.ToInt32(reader["EmergencyPhone"]);
                u.emergencyrelationship = reader["EmergencyRelationship"].ToString();
                u.status = reader["Status"].ToString();
                u.address = reader["Address"].ToString();
                u.zipcode = Convert.ToInt32(reader["Zipcode"]);
                u.nationality = reader["Nationality"].ToString();
                u.profilepic = reader["Profile"].ToString();
                u.doneby = reader["Doneby"].ToString();
                u.medicalStatus = reader["medicalStatus"].ToString();
                u.medicalStatusUpdateBy = reader["mediStatusUpdateBy"].ToString();
                u.longtitude = reader["longitude"].ToString();
                u.latitude = reader["latitude"].ToString();
                users.Add(u);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return users;
    }

    //get all user list from database where the photo is from external side
    public static List<Users> getallUserswithlink()
    {
        List<Users> users = new List<Users>();
        try
        {
            SqlCommand command = new SqlCommand("select * from Users where profile like '%http%'");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Users u = new Users();
                u.userId = reader["UserId"].ToString();
                u.email = reader["Email"].ToString();
                u.name = reader["Name"].ToString();
                u.dob = Convert.ToDateTime(reader["DOB"]);
                u.gender = reader["Gender"].ToString();
                u.rstatus = reader["Rstatus"].ToString();
                u.height = Convert.ToInt32(reader["Height"]);
                u.weight = Convert.ToInt32(reader["Weight"]);
                u.bloodtype = reader["BloodType"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.phone = Convert.ToInt32(reader["Phone"]);
                u.nric = reader["NRICNo"].ToString();
                u.emergencyname = reader["EmergencyName"].ToString();
                u.emergencyphone = Convert.ToInt32(reader["EmergencyPhone"]);
                u.emergencyrelationship = reader["EmergencyRelationship"].ToString();
                u.status = reader["Status"].ToString();
                u.address = reader["Address"].ToString();
                u.zipcode = Convert.ToInt32(reader["Zipcode"]);
                u.nationality = reader["Nationality"].ToString();
                u.profilepic = reader["Profile"].ToString();
                u.doneby = reader["Doneby"].ToString();
                u.medicalStatus = reader["medicalStatus"].ToString();
                u.medicalStatusUpdateBy = reader["mediStatusUpdateBy"].ToString();
                u.longtitude = reader["longitude"].ToString();
                u.latitude = reader["latitude"].ToString();
                users.Add(u);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return users;
    }


    //add new user to database
    public static int insertUser(Users u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into Users values( @email, @name, @dob, @gender,@rstatus, @height, @weight, @bloodtype,@username,@password,@phone, @nric,@emergencyname,@emergencyphone,@emergencyrelationship, @status,@address,@zipcode,@nationality,@profile,@doneby,@medicalStatus,@mediStatusUpdateBy,@latitude,@longitude)");
            command.Parameters.AddWithValue("@email", u.Email);
            command.Parameters.AddWithValue("@name", u.Name);
            command.Parameters.AddWithValue("@dob", u.DOB);
            command.Parameters.AddWithValue("@gender", u.Gender);
            command.Parameters.AddWithValue("@rstatus", u.Rstatus);
            command.Parameters.AddWithValue("@height", u.Height);
            command.Parameters.AddWithValue("@weight", u.Weight);
            command.Parameters.AddWithValue("@bloodtype", u.BloodType);
            command.Parameters.AddWithValue("@username", u.Username);
            command.Parameters.AddWithValue("@password", u.Password);
            command.Parameters.AddWithValue("@phone", u.Phone);
            command.Parameters.AddWithValue("@nric", u.Nric);
            command.Parameters.AddWithValue("@emergencyname", u.Emergencyname);
            command.Parameters.AddWithValue("@emergencyphone", u.Emergencyphone);
            command.Parameters.AddWithValue("@emergencyrelationship", u.Emergencyrelationship);
            command.Parameters.AddWithValue("@status", u.Status);
            command.Parameters.AddWithValue("@address", u.Address);
            command.Parameters.AddWithValue("@zipcode", u.ZipCode);
            command.Parameters.AddWithValue("@nationality", u.Nationality);
            command.Parameters.AddWithValue("@profile", u.Profilepic);
            command.Parameters.AddWithValue("@doneby", u.doneby);
            command.Parameters.AddWithValue("@medicalStatus", u.medicalStatus);
            command.Parameters.AddWithValue("@mediStatusUpdateBy", u.medicalStatusUpdateBy);
            command.Parameters.AddWithValue("@latitude", u.latitude);
            command.Parameters.AddWithValue("@longitude", u.longtitude);

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


    //get User by Email
    public static Users getUserbyEmail(string email)
    {
        Users u = new Users();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Users where email = @email");
            command.Parameters.AddWithValue("@email", email);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u.userId = reader["UserId"].ToString();
                u.email = reader["Email"].ToString();
                u.name = reader["Name"].ToString();
                u.dob = Convert.ToDateTime(reader["DOB"]);
                u.gender = reader["Gender"].ToString();
                u.rstatus = reader["Rstatus"].ToString();
                u.height = Convert.ToInt32(reader["Height"]);
                u.weight = Convert.ToInt32(reader["Weight"]);
                u.bloodtype = reader["BloodType"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.phone = Convert.ToInt32(reader["Phone"]);
                u.nric = reader["NRICNo"].ToString();
                u.emergencyname = reader["EmergencyName"].ToString();
                u.emergencyphone = Convert.ToInt32(reader["EmergencyPhone"]);
                u.emergencyrelationship = reader["EmergencyRelationship"].ToString();
                u.status = reader["Status"].ToString();
                u.address = reader["Address"].ToString();
                u.zipcode = Convert.ToInt32(reader["Zipcode"]);
                u.nationality = reader["Nationality"].ToString();
                u.profilepic = reader["Profile"].ToString();
                u.doneby = reader["Doneby"].ToString();
                u.medicalStatus = reader["medicalStatus"].ToString();
                u.medicalStatusUpdateBy = reader["mediStatusUpdateBy"].ToString();
                u.longtitude = reader["longitude"].ToString();
                u.latitude = reader["latitude"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return u;
    }

    //get User by Username
    public static Users getUserbyUsername(string username)
    {
        Users u = new Users();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Users where username = @username");
            command.Parameters.AddWithValue("@username", username);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u.userId = reader["UserId"].ToString();
                u.email = reader["Email"].ToString();
                u.name = reader["Name"].ToString();
                u.dob = Convert.ToDateTime(reader["DOB"]);
                u.gender = reader["Gender"].ToString();
                u.rstatus = reader["Rstatus"].ToString();
                u.height = Convert.ToInt32(reader["Height"]);
                u.weight = Convert.ToInt32(reader["Weight"]);
                u.bloodtype = reader["BloodType"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.phone = Convert.ToInt32(reader["Phone"]);
                u.nric = reader["NRICNo"].ToString();
                u.emergencyname = reader["EmergencyName"].ToString();
                u.emergencyphone = Convert.ToInt32(reader["EmergencyPhone"]);
                u.emergencyrelationship = reader["EmergencyRelationship"].ToString();
                u.status = reader["Status"].ToString();
                u.address = reader["Address"].ToString();
                u.zipcode = Convert.ToInt32(reader["Zipcode"]);
                u.nationality = reader["Nationality"].ToString();
                u.profilepic = reader["Profile"].ToString();
                u.doneby = reader["Doneby"].ToString();
                u.medicalStatus = reader["medicalStatus"].ToString();
                u.medicalStatusUpdateBy = reader["mediStatusUpdateBy"].ToString();
                u.longtitude = reader["longitude"].ToString();
                u.latitude = reader["latitude"].ToString();

            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return u;
    }

    //get User by ID
    public static Users getUserbyID(string UserId)
    {
        Users u = new Users();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Users where UserId = @UserId");
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u.userId = reader["UserId"].ToString();
                u.email = reader["Email"].ToString();
                u.name = reader["Name"].ToString();
                u.dob = Convert.ToDateTime(reader["DOB"]);
                u.gender = reader["Gender"].ToString();
                u.rstatus = reader["Rstatus"].ToString();
                u.height = Convert.ToInt32(reader["Height"]);
                u.weight = Convert.ToInt32(reader["Weight"]);
                u.bloodtype = reader["BloodType"].ToString();
                u.username = reader["Username"].ToString();
                u.password = reader["Password"].ToString();
                u.phone = Convert.ToInt32(reader["Phone"]);
                u.nric = reader["NRICNo"].ToString();
                u.emergencyname = reader["EmergencyName"].ToString();
                u.emergencyphone = Convert.ToInt32(reader["EmergencyPhone"]);
                u.emergencyrelationship = reader["EmergencyRelationship"].ToString();
                u.status = reader["Status"].ToString();
                u.address = reader["Address"].ToString();
                u.zipcode = Convert.ToInt32(reader["Zipcode"]);
                u.nationality = reader["Nationality"].ToString();
                u.profilepic = reader["Profile"].ToString();
                u.doneby = reader["Doneby"].ToString();
                u.medicalStatus = reader["medicalStatus"].ToString();
                u.medicalStatusUpdateBy = reader["mediStatusUpdateBy"].ToString();
                u.longtitude = reader["longitude"].ToString();
                u.latitude = reader["latitude"].ToString();

            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return u;
    }

    //Update User in the database
    public static int updateEmergencyUser(Users u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update Users set EmergencyName=@EmergencyName, EmergencyPhone=@EmergencyPhone,EmergencyRelationship=@EmergencyRelationship where username=@username");
            command.Parameters.AddWithValue("@username", u.username);
            command.Parameters.AddWithValue("@EmergencyName", u.Emergencyname);
            command.Parameters.AddWithValue("@EmergencyPhone", u.Emergencyphone);
            command.Parameters.AddWithValue("@EmergencyRelationship", u.Emergencyrelationship);
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

    //Update User in the database
    public static int updateUser(Users u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update Users set status=@status,doneby=@doneby, latitude=@latitude, longitude=@longitude, mediStatusUpdateBy=@mediStatusUpdateBy,medicalStatus=@medicalStatus,password=@password,name=@name,gender=@gender,dob=@dob,nationality=@nationality,rstatus=@rstatus,height=@height,weight=@weight,bloodtype=@bloodtype,address=@address,zipcode=@zipcode,phone=@phone,profile=@profile,EmergencyName=@EmergencyName, EmergencyPhone=@EmergencyPhone,EmergencyRelationship=@EmergencyRelationship where username=@username");

            command.Parameters.AddWithValue("@status", u.Status);
            command.Parameters.AddWithValue("@doneby", u.doneby);
            command.Parameters.AddWithValue("@username", u.username);
            command.Parameters.AddWithValue("@name", u.name);
            command.Parameters.AddWithValue("@gender", u.gender);
            command.Parameters.AddWithValue("@dob", u.dob);
            command.Parameters.AddWithValue("@password", u.password);
            command.Parameters.AddWithValue("@nationality", u.nationality);
            command.Parameters.AddWithValue("@rstatus", u.rstatus);
            command.Parameters.AddWithValue("@height", u.height);
            command.Parameters.AddWithValue("@weight", u.weight);
            command.Parameters.AddWithValue("@bloodtype", u.bloodtype);
            command.Parameters.AddWithValue("@address", u.address);
            command.Parameters.AddWithValue("@zipcode", u.zipcode);
            command.Parameters.AddWithValue("@phone", u.phone);
            command.Parameters.AddWithValue("@profile", u.profilepic);
            command.Parameters.AddWithValue("@EmergencyName", u.Emergencyname);
            command.Parameters.AddWithValue("@EmergencyPhone", u.Emergencyphone);
            command.Parameters.AddWithValue("@EmergencyRelationship", u.Emergencyrelationship);
            command.Parameters.AddWithValue("@medicalStatus", u.medicalStatus);
            command.Parameters.AddWithValue("@mediStatusUpdateBy", u.medicalStatusUpdateBy);
            command.Parameters.AddWithValue("@latitude", u.latitude);
            command.Parameters.AddWithValue("@longitude", u.longtitude);
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