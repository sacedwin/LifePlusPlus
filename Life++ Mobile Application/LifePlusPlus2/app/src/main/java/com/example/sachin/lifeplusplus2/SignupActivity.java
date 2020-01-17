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
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.ScrollView;
import android.widget.Spinner;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SignupActivity extends AppCompatActivity {

    Button proceed,signup;
    EditText email,username,password,name,DOB,height,weight,phone,NRICNo,emergencyName,emergencyPhone,address,zipCode,nationality;
    ProgressBar progressBar;
    RadioGroup radioGroup;
    Spinner rStatus,bloodType,emergencyRelation;
    ScrollView scrollView;
    Connection con;
    String db;
    ImageView imView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_signup);
        proceed = (Button) findViewById(R.id.btnEmailCheck);
        email = (EditText) findViewById(R.id.edtEmail);
        username = (EditText) findViewById(R.id.edtUsername);
        password = (EditText) findViewById(R.id.edtPassword);
        name = (EditText) findViewById(R.id.edtName);
        DOB = (EditText) findViewById(R.id.edtDOB);
        radioGroup = (RadioGroup) findViewById(R.id.rgGender);
        rStatus=(Spinner) findViewById(R.id.spinRstatus);
        bloodType=(Spinner) findViewById(R.id.spinBloodType);
        emergencyRelation=(Spinner) findViewById(R.id.spinEmergencyRelation);
        height = (EditText) findViewById(R.id.edtHeight);
        weight = (EditText) findViewById(R.id.edtWeight);
        phone = (EditText) findViewById(R.id.edtPhone);
        NRICNo = (EditText) findViewById(R.id.edtNRIC);
        emergencyName = (EditText) findViewById(R.id.edtEmergencyName);
        emergencyPhone = (EditText) findViewById(R.id.edtEmergencyNumber);
        address = (EditText) findViewById(R.id.edtAddress);
        zipCode = (EditText) findViewById(R.id.edtZipcode);
        nationality = (EditText) findViewById(R.id.edtNationality);
        progressBar = (ProgressBar) findViewById(R.id.progressBar);
        signup = (Button) findViewById(R.id.btnJoin);
        imView=(ImageView) findViewById(R.id.imgViewSignup);
        scrollView=(ScrollView) findViewById(R.id.scrlViewSignup);    //finding and assigning the ui elements
        db="jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";
        //database connection string
        progressBar.setVisibility(View.GONE);

        proceed.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                CheckEmail checkEmail = new CheckEmail();// this is the Asynctask, which is used to process in background to reduce load on app process
                checkEmail.execute("");
            }
        });

        signup.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                SignupToDatabase signupToDatabase = new SignupToDatabase();
                signupToDatabase.execute("");
            }
        });     //signs the user up and uploads all the values to db
    }

    public class SignupToDatabase extends AsyncTask<String,String,String>      //signing the user up
    {
        String z = "";
        Boolean isSuccess = false;
        String email1 = email.getText().toString();
        String name1=name.getText().toString();
        String DOB1=DOB.getText().toString();
        String gender1=((RadioButton) findViewById(radioGroup.getCheckedRadioButtonId())).getText().toString();
        String rStatus1=rStatus.getSelectedItem().toString();
        int height1=Integer.parseInt(height.getText().toString());
        int weight1=Integer.parseInt(weight.getText().toString());
        String bloodType1=bloodType.getSelectedItem().toString();
        String username1 = username.getText().toString();
        String password1 = password.getText().toString();
        int phone1=Integer.parseInt(phone.getText().toString());
        String NRICNo1=NRICNo.getText().toString();
        String emergencyName1=emergencyName.getText().toString();
        int emergencyPhone1=Integer.parseInt(emergencyPhone.getText().toString());
        String emergencyRelation1=emergencyRelation.getSelectedItem().toString();
        String address1=address.getText().toString();
        int zipCode1=Integer.parseInt(zipCode.getText().toString());
        String nationality1=nationality.getText().toString();

        @Override
        protected void onPreExecute()
        {
            progressBar.setVisibility(View.VISIBLE);            //executed before the background
        }

        @Override
        protected void onPostExecute(String r)
        {
            progressBar.setVisibility(View.GONE);
            Toast.makeText(SignupActivity.this, r, Toast.LENGTH_SHORT).show();
            if(isSuccess)
            {
                Toast.makeText(SignupActivity.this , "Sign up successful" , Toast.LENGTH_LONG).show();
                SaveSharedPreference.setUserId(SignupActivity.this,email1);
                Intent intent = new Intent(SignupActivity.this, LocationUpdaterService.class);        //location services are called
                startService(intent);
                Intent goToMainActivity=new Intent(SignupActivity.this,MainActivity.class);
                startActivity(goToMainActivity);
            }
        }

        @Override
        protected String doInBackground(String... params)
        {
            if(name1.trim().equals("")|| DOB1.trim().equals("")||NRICNo1.trim().equals("")||address1.trim().equals("")||nationality1.trim().equals(""))  //checking if all fields entered
            {
                z = "Please enter all required fields";
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
                        String query = "insert into [DBO].[Users] values('"+ email1+"','"+name1+"','"+DOB1+"','"+gender1+"','"+rStatus1+"',"+height1+","+weight1+",'"+bloodType1+"','"+username1+"','"+password1+"',"+phone1+",'"+NRICNo1+"','"+emergencyName1+"',"+emergencyPhone1+",'"+emergencyRelation1+"','Allow','"+address1+"',"+zipCode1+",'"+nationality1+"','null','null','can donate','null','null','null')";
                        Statement stmt = con.createStatement();
                        stmt.executeUpdate(query);
                        String query2="select userID from [DBO].[Users] where email='"+email1+"'";
                        Statement stmt2 =con.createStatement();
                        ResultSet rs2=stmt2.executeQuery(query2);
                        if(rs2.next())
                        {
                            String query1 = "insert into [DBO].[LastDonationDate] values('" +rs2.getString("UserID")+"','07/27/2017','blood','Not in transaction')";
                            Statement stmt3=con.createStatement();
                            stmt3.executeUpdate(query1);
                            isSuccess = true;
                            con.close();
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


    public class CheckEmail extends AsyncTask<String,String,String>     //checking if email and username already present in the database
    {
        String z = "";
        Boolean isSuccess = false;
        String email1 = email.getText().toString();
        String username1 = username.getText().toString();
        String password1 = password.getText().toString();

        @Override
        protected void onPreExecute()
        {
            progressBar.setVisibility(View.VISIBLE);
        }

        @Override
        protected void onPostExecute(String r)
        {
            progressBar.setVisibility(View.GONE);
            Toast.makeText(SignupActivity.this, r, Toast.LENGTH_SHORT).show();
            if(isSuccess)
            {
                email.setVisibility(View.INVISIBLE);
                username.setVisibility(View.INVISIBLE);
                password.setVisibility(View.INVISIBLE);
                proceed.setVisibility(View.GONE);
                imView.setVisibility(View.INVISIBLE);
                scrollView.setVisibility(View.VISIBLE);
            }
        }

        @Override
        protected String doInBackground(String... params)
        {
            if(email1.trim().equals("")|| username1.trim().equals("")||password1.trim().equals(""))
            {
                z = "Please enter Email, Username and Password";
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
                        String query = "select * from [DBO].[Users] where email= '" + email1+"'";
                        String query1="select * from [DBO].[Users] where username= '"+ username1+"'";
                        Statement stmt = con.createStatement();
                        Statement stmt1=con.createStatement();
                        ResultSet rs = stmt.executeQuery(query);
                        ResultSet rs1=stmt1.executeQuery(query1);
                        if(rs.next())               //check for duplication
                        {
                            z = "Email already exists!";
                            isSuccess=false;
                        }
                        else if(rs1.next())
                        {
                            z = "Username already exists!";
                            isSuccess = false;
                        }
                        else
                        {
                            z="Please enter the following details";
                            isSuccess=true;
                            con.close();
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
    public Connection connectionclass(String db)         //connecting to database
    {
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection connection = null;
        String ConnectionURL = null;
        try
        {
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            ConnectionURL = db;                         //the url for connecting
            connection = DriverManager.getConnection(ConnectionURL);            //connection being made
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
}
