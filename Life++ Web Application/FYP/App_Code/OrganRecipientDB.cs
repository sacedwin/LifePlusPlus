using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public class OrganRecipientDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<OrganRecipient> getAllRecipients()
    {
        List<OrganRecipient> organRecipients = new List<OrganRecipient>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from organReceiverWaiting");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                OrganRecipient r = new OrganRecipient();
                r.ID = reader["OrganWlID"].ToString();
                r.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                r.Bloodgroup = reader["bloodGroup"].ToString();
                r.DOB = Convert.ToDateTime(reader["DOB"]);
                r.Height = Convert.ToInt32(reader["height"]);
                r.Weight = Convert.ToInt32(reader["weight"]);
                r.Addedon = Convert.ToDateTime(reader["addedOn"]);
                r.Organrequired = reader["organRequired"].ToString();
                r.Comments = reader["comments"].ToString();
                r.Urgency = Convert.ToInt32(reader["urgency"]);
                r.Refnumber = reader["hospitalPatientNumber"].ToString();
                r.Status = reader["status"].ToString();
                organRecipients.Add(r);
                
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return organRecipients;
    }

    public static int insertOrganRecipient(OrganRecipient r)
    {
        try
        {
            SqlCommand command = new SqlCommand("insert into organReceiverWaiting values (@establishmentID, @bloodGroup, @DOB, @height, @weight, @addedOn, @organRequired, @comments, @urgency, @hospitalPatientNumber, @status)");
            command.Parameters.AddWithValue("@establishmentID", r.Establishment.ID);
            command.Parameters.AddWithValue("@bloodGroup", r.Bloodgroup);
            command.Parameters.AddWithValue("@DOB", r.DOB);
            command.Parameters.AddWithValue("@height", r.Height);
            command.Parameters.AddWithValue("@weight", r.Weight);
            command.Parameters.AddWithValue("@addedOn", r.Addedon);
            command.Parameters.AddWithValue("@organRequired", r.Organrequired);
            command.Parameters.AddWithValue("@comments", r.Comments);
            command.Parameters.AddWithValue("@urgency", r.Urgency);
            command.Parameters.AddWithValue("@hospitalPatientNumber", r.Refnumber);
            command.Parameters.AddWithValue("@status", r.Status);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    public static int updateOrganRecipient(OrganRecipient or)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("update organReceiverWaiting set status=@status, comments=@comments where OrganWlID=@id");
            command.Parameters.AddWithValue("@status", or.Status);
            command.Parameters.AddWithValue("@comments", or.Comments);
            command.Parameters.AddWithValue("@id", or.ID);
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

    public static OrganRecipient getRecipientByID(string id)
    {
        OrganRecipient r = new OrganRecipient();
        try
        {
            SqlCommand command = new SqlCommand("Select * from organReceiverWaiting where OrganWlID = @id");
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                r.ID = reader["OrganWlID"].ToString();
                r.Establishment = EstablishmentDB.getEstablishmentByID(reader["establishmentID"].ToString());
                r.Bloodgroup = reader["bloodGroup"].ToString();
                r.DOB = Convert.ToDateTime(reader["DOB"]);
                r.Height = Convert.ToInt32(reader["height"]);
                r.Weight = Convert.ToInt32(reader["weight"]);
                r.Addedon = Convert.ToDateTime(reader["addedOn"]);
                r.Organrequired = reader["organRequired"].ToString();
                r.Comments = reader["comments"].ToString();
                r.Urgency = Convert.ToInt32(reader["urgency"]);
                r.Refnumber = reader["hospitalPatientNumber"].ToString();
                r.Status = reader["status"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return r;
    }

}