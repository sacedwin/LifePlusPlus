package com.example.sachin.lifeplusplus2;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class LogInActivity extends AppCompatActivity {

    Button login,signup;
    EditText email,password;
    ProgressBar progressBar;
    Connection con;
    String db;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log_in);
        // Getting values from button, texts and progress bar
        login = (Button) findViewById(R.id.btnLogin);
        email = (EditText) findViewById(R.id.edtEmail);
        password = (EditText) findViewById(R.id.edtPassword);
        progressBar = (ProgressBar) findViewById(R.id.progressBar);
        signup = (Button) findViewById(R.id.btnSignup);
        // End Getting values from button, texts and progress bar
        db="jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";
        //this is the database connection string
        progressBar.setVisibility(View.GONE);

        login.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                CheckLogin checkLogin = new CheckLogin();// this is the Asynctask, which is used to process in background to reduce load on app process
                checkLogin.execute("");
            }
        });
        //End Setting up the function when button login is clicked

        signup.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Intent goToSignupActivity=new Intent(LogInActivity.this,SignupActivity.class);
                startActivity(goToSignupActivity);
            }
        });
        //button which redirects to the signup form
    }

    public class CheckLogin extends AsyncTask<String,String,String>         //the asyncTask which checks credentials and logs a person in
    {
        String z = "Loading complete";
        Boolean isSuccess = false;
        String email1 = email.getText().toString();
        String password1 = password.getText().toString();

        @Override
        protected void onPreExecute()
        {
            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(String r)      //this run after the background activity
        {
            progressBar.setVisibility(View.GONE);
            Toast.makeText(LogInActivity.this, r, Toast.LENGTH_SHORT).show();
            if(isSuccess)
            {
                SaveSharedPreference.setUserId(LogInActivity.this,email1);
                Intent intent = new Intent(LogInActivity.this, LocationUpdaterService.class);
                startService(intent);
                Intent goToMainActivity=new Intent(LogInActivity.this,MainActivity.class);
                startActivity(goToMainActivity);
            }
        }
        @Override
        protected String doInBackground(String... params)
        {
            if(email1.trim().equals("")|| password1.trim().equals(""))
            {
                z = "Please enter Username and Password";
            }
            else
            {
                try
                {
                    con = connectionclass(db);        // Connect to database
                    if (con == null)
                    {
                        z = "Check Your Internet Access!";
                    }
                    else
                    {
                        String query = "select * from [DBO].[Users] where email= '" + email1 + "' and password = '"+ password1 +"'";
                        Statement stmt = con.createStatement();
                        ResultSet rs = stmt.executeQuery(query);
                        if(rs.next())
                        {
                            if(rs.getString("status").equals("Allow"))
                            {
                                z = "Login successful";
                                isSuccess = true;
                                con.close();
                            }
                            else
                            {
                                z="You have been blocked";
                                isSuccess=false;
                            }
                        }
                        else
                        {
                            z = "Invalid Credentials!";
                            isSuccess = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    isSuccess = false;
                    z = ex.getMessage();
                }
            }
            return z;
        }
    }

    @SuppressLint("NewApi")
    public Connection connectionclass(String db)            //connecting to the database
    {
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection connection = null;
        String ConnectionURL = null;
        try
        {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            ConnectionURL = db;
            connection = DriverManager.getConnection(ConnectionURL);
        }
        catch (SQLException se)
        {
            Log.e("error here 1 : ", se.getMessage());
        }
        catch (ClassNotFoundException e)
        {
            Log.e("error here 2 : ", e.getMessage());
        }
        catch (Exception e)
        {
            Log.e("error here 3 : ", e.getMessage());
        }
        return connection;
    }

    @Override
    public void onBackPressed() {
        //disabling back button
    }
}

