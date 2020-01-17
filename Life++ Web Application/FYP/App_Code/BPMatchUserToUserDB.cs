using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for BPMatchUserToUserDB
/// </summary>
public class BPMatchUserToUserDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

	public static List<BPMatchUserToUser> getAllUserBloodRequestsbyUserID(string bplUserRequestID)
	{
		List<BPMatchUserToUser> brlist = new List<BPMatchUserToUser>();
		try
		{
			SqlCommand command = new SqlCommand("Select * from BPMatchUserToUser where bplUserRequestID = @bplUserRequestID");
			command.Parameters.AddWithValue("@bplUserRequestID ", bplUserRequestID);
			command.Connection = connection;
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				BPMatchUserToUser br = new BPMatchUserToUser();
				br.bpMatchUsrUsrID = reader["bpMatchUsrUsr"].ToString();
				BloodPlateletRequestUser bp = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(reader["bplUserRequestID"].ToString());
				br.bplUsrRequestID = bp;
				Users u = UsersDB.getUserbyID(reader["matchID"].ToString());
				br.matchID = u;
				br.status = reader["status"].ToString();
				br.distance = Convert.ToInt32(reader["distance"]);
				brlist.Add(br);
			}
			reader.Close();
		}
		finally
		{
			connection.Close();
		}
		return brlist;
	}

	public static BPMatchUserToUser getUserBloodRequestsbyMatchID(string bpMatchUsrUsr)
    {
        BPMatchUserToUser br = new BPMatchUserToUser();
        try
        {
            SqlCommand command = new SqlCommand("Select * from BPMatchUserToUser where bpMatchUsrUsr = @bpMatchUsrUsr");
            command.Parameters.AddWithValue("@bpMatchUsrUsr ", bpMatchUsrUsr);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
				br.bpMatchUsrUsrID = reader["bpMatchUsrUsr"].ToString();
				BloodPlateletRequestUser bp = BloodPlateletRequestUserDB.getUserBloodRequestsbyID(reader["bplUserRequestID"].ToString());
				br.bplUsrRequestID = bp;
				Users u = UsersDB.getUserbyID(reader["matchID"].ToString());
				br.matchID = u;
				br.status = reader["status"].ToString();
				br.distance = Convert.ToInt32(reader["distance"]);
			}
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return br;
    }

    public static int insertbpusertoUser(BPMatchUserToUser m)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into BPMatchUserToUser values( @bplUserRequestID , @matchID , @status ,@distance )");
            command.Parameters.AddWithValue("@bplUserRequestID", m.bplUsrRequestID.bplUserRequestID);
            command.Parameters.AddWithValue("@matchID", m.matchID.userId);
            command.Parameters.AddWithValue("@status", m.status);
            command.Parameters.AddWithValue("@distance", m.distance);
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

    public static int updateMatchUserToUser(BPMatchUserToUser u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update BPMatchUserToUser set status=@status where bpMatchUsrUsr=@bpMatchUsrUsr");
            command.Parameters.AddWithValue("@bpMatchUsrUsr", u.bpMatchUsrUsrID);
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