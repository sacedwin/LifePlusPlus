﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for FeedbackDB
/// </summary>
public class FeedbackDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    //get all feedback list from database
    public static List<Feedback> getallFeedbacks()
    {
        List<Feedback> feedbacks = new List<Feedback>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from feedback");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Feedback f = new Feedback();
                f.feedbackID = reader["feedbackID"].ToString();
                f.name = reader["name"].ToString();
                f.email = reader["Email"].ToString();
                f.subject = reader["subject"].ToString();
                f.question = reader["question"].ToString();
                f.answer = reader["answer"].ToString();
                f.status = reader["status"].ToString();
                f.answerby = reader["answerby"].ToString();
                feedbacks.Add(f);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return feedbacks;
    }


    //get Feedback by Email
    public static Feedback getFeedbackbyEmail(string email)
    {
        Feedback f = new Feedback();
        try
        {
            SqlCommand command = new SqlCommand("Select * from feedback where email = @email");
            command.Parameters.AddWithValue("@email", email);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                f.feedbackID = reader["feedbackID"].ToString();
                f.name = reader["name"].ToString();
                f.email = reader["Email"].ToString();
                f.subject = reader["subject"].ToString();
                f.question = reader["question"].ToString();
                f.answer = reader["answer"].ToString();
                f.status = reader["status"].ToString();
                f.answerby = reader["answerby"].ToString();
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return f;
    }


    //add new feedback to database
    public static int insertFeedback(Feedback u)
    {
        int num = -1;
        try
        {
            SqlCommand command = new SqlCommand("insert into feedback values(@name, @email, @subject,@question,@answer,@status,@answerby)");
            command.Parameters.AddWithValue("@name", u.Name); 
            command.Parameters.AddWithValue("@email", u.Email);
            command.Parameters.AddWithValue("@subject", u.subject);
            command.Parameters.AddWithValue("@question", u.question);
            command.Parameters.AddWithValue("@answer", u.answer);
            command.Parameters.AddWithValue("@status", u.status);
            command.Parameters.AddWithValue("@answerby", u.answerby);
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

    //Update Feedback in the database
    public static int updateFeedback(Feedback u)
    {
        int result;
        try
        {
            SqlCommand command = new SqlCommand("Update feedback set name=@name, subject=@subject,question=@question,answer=@answer,status=@status,answerby=@answerby where email=@email");
            command.Parameters.AddWithValue("@email", u.email);
            command.Parameters.AddWithValue("@name", u.name);
            command.Parameters.AddWithValue("@subject", u.subject);
            command.Parameters.AddWithValue("@question", u.question);
            command.Parameters.AddWithValue("@answer", u.answer);
            command.Parameters.AddWithValue("@status", u.status);
            command.Parameters.AddWithValue("@answerby", u.answerby);
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