package com.example.sachin.lifeplusplus2;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.ProtocolException;
import java.net.URL;
import java.sql.Array;
import java.sql.Connection;
import java.util.Date;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

public class BloodPlateletRequestActivity extends AppCompatActivity {
    Button request,currentRequests;
    Spinner establishment,bloodType,establishment12;
    List<String> spinnerArray =  new ArrayList<String>();
    RadioGroup radioGroup;
    EditText quantity;
    Connection con;
    String db;
    ImageButton home;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_blood_platelet_request);

        home=(ImageButton)findViewById(R.id.btnHome);

        db="jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";
        String z = "Loading complete";
        Boolean isSuccess = false;
        try
        {
            con = connectionclass(db);        // Connect to database
            if (con == null)
            {
                z = "Check Your Internet Access!";
            }
            else
            {
                String query = "select name from [DBO].[establishment] where type in ('Hospital','Blood Bank')";
                Statement stmt = con.createStatement();
                ResultSet rs = stmt.executeQuery(query);
                isSuccess = true;
                while(rs.next())
                {
                    String str = rs.getString("name");
                    spinnerArray.add(str);
                }
                con.close();
            }
        }
        catch (Exception ex)
        {
            isSuccess = false;
            z = ex.getMessage();
        }
        Toast.makeText(BloodPlateletRequestActivity.this, z, Toast.LENGTH_SHORT).show();


        ArrayAdapter<String> adapter = new ArrayAdapter<String>(
                this, android.R.layout.simple_spinner_item, spinnerArray);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        establishment12=(Spinner) findViewById(R.id.spinEstablishment);

        establishment12.setAdapter(adapter);

        radioGroup = (RadioGroup) findViewById(R.id.rgType);
        bloodType=(Spinner) findViewById(R.id.spinBloodType);
        quantity=(EditText) findViewById(R.id.edtQuantity);
        request = (Button) findViewById(R.id.btnRequest);
        currentRequests=(Button)findViewById(R.id.btnCurrentRequest);

        request.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                RequestBlood requestBlood = new RequestBlood();
                requestBlood.execute("");
            }


        });

        home.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToMainActivity = new Intent(BloodPlateletRequestActivity.this, MainActivity.class);
                startActivity(goToMainActivity);
            }
        });

        currentRequests.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToCurrentRequestActivity = new Intent(BloodPlateletRequestActivity.this, BloodPlateletCurrentRequestActivity.class);
                startActivity(goToCurrentRequestActivity);
            }
        });

    }


    public class RequestBlood extends AsyncTask<String,String,String>
    {
        String z = "";
        Boolean isSuccess = false;
        int quantity1 = Integer.parseInt(quantity.getText().toString());
        String bloodOrPlatelet=((RadioButton) findViewById(radioGroup.getCheckedRadioButtonId())).getText().toString();
        String bloodType1=bloodType.getSelectedItem().toString();
        String establishment1=establishment12.getSelectedItem().toString();

        @Override
        protected void onPreExecute()
        {
        }

        @Override
        protected void onPostExecute(String r)
        {
            Toast.makeText(BloodPlateletRequestActivity.this, r, Toast.LENGTH_SHORT).show();
            if(isSuccess)
            {
                Toast.makeText(BloodPlateletRequestActivity.this , "Request successful" , Toast.LENGTH_LONG).show();


                Intent goToCurrentReqActivity=new Intent(BloodPlateletRequestActivity.this,BloodPlateletCurrentRequestActivity.class);
                startActivity(goToCurrentReqActivity);

            }
        }
        @Override
        protected String doInBackground(String... params)
        {
            if(quantity1==0)
                z = "Please enter proper quantity field";
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
                        String query = "select establishmentID from [DBO].[establishment] where name='"+establishment1+"'";
                        Statement stmt = con.createStatement();
                        ResultSet rs = stmt.executeQuery(query);
                        String establishmentID=null,UserID=null;
                        while(rs.next()) {
                            establishmentID=rs.getString("establishmentID");
                        }
                        String query1 = "select UserID from [DBO].[Users] where email='"+SaveSharedPreference.getUserId(BloodPlateletRequestActivity.this)+"'";
                        Statement stmt1 = con.createStatement();
                        ResultSet rs1 = stmt1.executeQuery(query1);
                        while ((rs1.next())) {
                            UserID = rs1.getString("UserID");
                        }
                        String date = new SimpleDateFormat("yyyy/MM/dd").format(new Date());

                        String query2="insert into [DBO].[BloodPlateletRequestUser] values ("+ quantity1+",0,'"+establishmentID+"','"+UserID+"','"+bloodType1+"','"+bloodOrPlatelet+"','pending','"+date+"')";

                        Statement stmt2 = con.createStatement();
                        stmt2.executeUpdate(query2);
                        isSuccess=true;

                        String query3="select bplUserRequestID from [DBO].[BloodPlateletRequestUser] where requestorID ='"+UserID+"'";
                        Statement stmt3 = con.createStatement();
                        ResultSet rs3 = stmt3.executeQuery(query3);
                        int tempID=0;
                        if(rs3.next())
                        tempID=Integer.parseInt(rs3.getString("bplUserRequestID").substring(4,rs3.getString("bplUserRequestID").length()));
                        while (rs3.next())
                        {
                         if(tempID<Integer.parseInt(rs3.getString("bplUserRequestID").substring(4,rs3.getString("bplUserRequestID").length())))
                         {
                             tempID=Integer.parseInt(rs3.getString("bplUserRequestID").substring(4,rs3.getString("bplUserRequestID").length()));
                         }
                        }

                        String query4="select * from [DBO].[Users]";
                        Statement stmt4=con.createStatement();
                        ResultSet rs4=stmt4.executeQuery(query4);
                        int d=0;
                        String origin=null,destination=null;
                        String query5 = "select address from [DBO].[establishment] where name='"+establishment1+"'";
                        Statement stmt5 = con.createStatement();
                        ResultSet rs5 = stmt5.executeQuery(query5);
                        while (rs5.next())
                        {
                            destination=rs5.getString("address");
                        }
                        while (rs4.next())
                        {
                            String tBg=rs4.getString("bloodType");
                            int i=0;
                            if(bloodType1.equals("AB+"))
                                i=1;
                            else if(bloodType1.equals("AB-")&&(tBg.equals("O-")||tBg.equals("B-")||tBg.equals("A-")||tBg.equals("AB-")))
                                i=1;
                            else if(bloodType1.equals("A+")&&(tBg.equals("O-")||tBg.equals("O+")||tBg.equals("A-")||tBg.equals("A+")))
                                i=1;
                            else if(bloodType1.equals("A-")&&(tBg.equals("O-")||tBg.equals("A-")))
                                i=1;
                            else if(bloodType1.equals("B+")&&(tBg.equals("O-")||tBg.equals("O+")||tBg.equals("B-")||tBg.equals("B+")))
                                i=1;
                            else if (bloodType1.equals("B-")&&(tBg.equals("O-")||tBg.equals("B-")))
                                i=1;
                            else if (bloodType1.equals("O+")&&(tBg.equals("O-")||tBg.equals("O+")))
                                i=1;
                            else if (bloodType1.equals("O-")&&(tBg.equals("O-")))
                                i=1;

                            if(i==1&&rs4.getString("medicalStatus").equals("can donate")&&rs4.getString("status").equals("Allow"))
                            {
                                String query10="select * from LastDonationDate";
                                Statement stmt10 = con.createStatement();
                                ResultSet rs10 = stmt10.executeQuery(query10);
                                while (rs10.next())
                                {
                                    if(rs10.getString("userId").equals(rs4.getString("userId")))
                                    {
                                        Date userDate = new SimpleDateFormat("yyyy-MM-dd").parse(rs10.getString("donationDate"));
                                        Date today = new Date();
                                        long diff = today.getTime() - userDate.getTime();

                                        int numOfDays = (int) (diff / (1000 * 60 * 60 * 24));

                                        if ((numOfDays > 90 && rs10.getString("type").equals("blood")) || (numOfDays > 14 && rs10.getString("type").equals("platelet"))&&rs10.getString("status").equals("Not in transaction"))
                                        {
                                            origin = rs4.getString("latitude") + "," + rs4.getString("longitude");
                                            d = getDistance(origin, destination);
                                            if (d < 3600) {
                                                String query6 = "insert into [DBO].[BPMatchUserToUser] values ('bpur" + tempID + "','" + rs4.getString("UserID") + "','pending'," + d + ")";
                                                Statement stmt6 = con.createStatement();
                                                stmt6.executeUpdate(query6);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        String query7 = "select * from [DBO].[establishment]";
                        Statement stmt7 = con.createStatement();
                        ResultSet rs7 = stmt7.executeQuery(query7);
                        d=0;
                        origin=null;
                        while (rs7.next())
                        {
                            origin=rs7.getString("address");

                            d=getDistance(origin,destination);
                            if(d<3600&&d>0)
                            {
                                String query8 = "insert into [DBO].[BPMatchUserToEstab] values ('bpur"+tempID+"','"+rs7.getString("establishmentID")+"','pending',"+d+")";
                                Statement stmt8 = con.createStatement();
                                stmt8.executeUpdate(query8);
                            }
                        }

                        isSuccess=true;


                        con.close();
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

    public int getDistance(String origin, String destination)
    {
        String parsedDistance=null;
        String response;



                try {
                    URL url = new URL("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + "&key=AIzaSyCN-DotpprhnjmZrnqpX1Sa-gZK8freYkc");

                    final HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    InputStream in = new BufferedInputStream(conn.getInputStream());
                    response = org.apache.commons.io.IOUtils.toString(in, "UTF-8");

                    JSONObject jsonObject = new JSONObject(response);
                    JSONArray array = jsonObject.getJSONArray("rows");
                    JSONObject elements = array.getJSONObject(0);
                    JSONArray elements1=elements.getJSONArray("elements");
                    JSONObject duration = elements1.getJSONObject(0);
                    JSONObject value=duration.getJSONObject("duration");
                    parsedDistance=value.get("value").toString();

                } catch (ProtocolException e) {
                    parsedDistance="0";
                    e.printStackTrace();
                } catch (MalformedURLException e) {
                    parsedDistance="0";
                    e.printStackTrace();
                } catch (IOException e) {
                    parsedDistance="0";
                    e.printStackTrace();
                } catch (JSONException e) {
                    parsedDistance="0";
                    e.printStackTrace();
                }
        return Integer.parseInt(parsedDistance);
    }

    @SuppressLint("NewApi")
    public Connection connectionclass(String db)
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
}
