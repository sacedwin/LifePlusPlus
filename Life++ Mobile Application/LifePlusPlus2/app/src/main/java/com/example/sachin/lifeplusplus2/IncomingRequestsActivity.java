package com.example.sachin.lifeplusplus2;

import android.animation.TypeConverter;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.media.Image;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Layout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.LinkedList;
import java.util.List;
import java.util.regex.Matcher;

import static java.lang.Float.parseFloat;
import static java.lang.Integer.parseInt;

public class IncomingRequestsActivity extends AppCompatActivity {
    String db;
    Connection con;
    ListView lvUser,lvEstab;
    LinearLayout layoutUser,layoutEstab;
    TextView textViewEstab,textViewIndi;
    ProgressBar progressBar;
    ImageButton home;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_incoming_requests);
        db="jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";
        layoutEstab=(LinearLayout) findViewById(R.id.layoutEstabRequest);
        layoutUser=(LinearLayout) findViewById(R.id.layoutUserRequest);
        textViewEstab=(TextView)findViewById(R.id.textViewEstab);
        textViewIndi=(TextView)findViewById(R.id.textViewIndi);
        progressBar=(ProgressBar)findViewById(R.id.progressBarIncoming);
        progressBar.setVisibility(View.VISIBLE);
        home=(ImageButton)findViewById(R.id.btnHome);
        home.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToMainActivity = new Intent(IncomingRequestsActivity.this, MainActivity.class);
                startActivity(goToMainActivity);
            }
        });
        String z = "Loading complete",currID="";
        Boolean isSuccess = false;
        try
        {
            con = connectionclass(db);        // Connect to database
            if (con == null)
            {
                z = "Check Your Internet Access!";
            }
            else {
                String tempStatus="";
                String query2 = "select * from [DBO].[Users] where email='" + SaveSharedPreference.getUserId(IncomingRequestsActivity.this) + "'";
                Statement stmt2 = con.createStatement();
                ResultSet rs2 = stmt2.executeQuery(query2);
                while (rs2.next()) {
                    currID = rs2.getString("UserID");
                    tempStatus=rs2.getString("medicalStatus");
                }

                int i = 0;
                String query20 = "select * from [DBO].[LastDonationDate] where userId='" + currID + "'";
                Statement stmt20 = con.createStatement();
                ResultSet rs20 = stmt20.executeQuery(query20);
                while (rs20.next()) {
                    if (rs20.getString("status").equals("In transaction")) {
                        i = 1;
                    }

                }

                if (i == 1)
                {
                    Intent goToTransactionActivity = new Intent(IncomingRequestsActivity.this, BloodPlateletTransactionActivity.class);
                    startActivity(goToTransactionActivity);

                }
                else if(tempStatus.equals("cannot donate"))
                {
                    Toast.makeText(IncomingRequestsActivity.this, "You cannot perform donations", Toast.LENGTH_SHORT).show();
                    Intent goToMainActivity = new Intent(IncomingRequestsActivity.this, MainActivity.class);
                    startActivity(goToMainActivity);
                }
                else
                {

                    String query = "select * from [DBO].[BPMatchUserToUser]";
                    Statement stmt = con.createStatement();
                    ResultSet rs = stmt.executeQuery(query);

                    String query4 = "select * from [DBO].[BPMatchEstabToUser]";
                    Statement stmt4 = con.createStatement();
                    ResultSet rs4 = stmt4.executeQuery(query4);
                    isSuccess = true;


                    final List<MatchEstab> mMatchEstabList = new LinkedList<MatchEstab>();
                    List<String> estabNameList1 = new LinkedList<String>();
                    while (rs4.next()) {
                        MatchEstab matchEstab = new MatchEstab();
                        matchEstab.mid = rs4.getString("bpMatchEstabUserID");
                        matchEstab.requestID = rs4.getString("bplEstabRequestID");
                        matchEstab.matchID = rs4.getString("matchID");
                        matchEstab.status = rs4.getString("status");
                        matchEstab.distance = rs4.getString("distance");

                        String query6 = "select unitsRequired, unitsMatched, bloodOrPlatelet from [DBO].[BloodPlateletRequestEstab] where bplEstabRequestID='" + matchEstab.requestID + "'";
                        Statement stmt6 = con.createStatement();
                        ResultSet rs6 = stmt6.executeQuery(query6);

                        String tempType = "";
                        int unitsMatched=0,unitsRequested=1;
                        while (rs6.next()) {
                            tempType = rs6.getString("bloodOrPlatelet");
                            unitsMatched=parseInt(rs6.getString("unitsMatched"));
                            unitsRequested=parseInt(rs6.getString("unitsRequired"));
                        }

                        if (matchEstab.matchID.equals(currID) && matchEstab.status.equals("pending")&&unitsMatched<unitsRequested) {
                            mMatchEstabList.add(matchEstab);

                            String query5 = "select E.name from [DBO].[Establishment] E,[DBO].[BloodPlateletRequestEstab] B where E.establishmentID=B.establishmentID AND B.bplEstabRequestID='" + matchEstab.requestID + "'";
                            Statement stmt5 = con.createStatement();
                            ResultSet rs5 = stmt5.executeQuery(query5);



                            String temp = "";
                            while (rs5.next()) {
                                String s = String.format("%.2f", (parseFloat(matchEstab.distance) / 3600));

                                temp = "Place: " + rs5.getString("Name") + "    Travl time: " + s + "hours    Type: " + tempType;
                            }
                            estabNameList1.add(temp);

                        }
                    }


                    final List<MatchUsr> mMatchUsrList = new LinkedList<MatchUsr>();
                    List<String> estabNameList = new LinkedList<String>();
                    while (rs.next()) {
                        MatchUsr matchUsr = new MatchUsr();
                        matchUsr.mid = rs.getString("bpMatchUsrUsr");
                        matchUsr.requestID = rs.getString("bplUserRequestID");
                        matchUsr.matchID = rs.getString("matchID");
                        matchUsr.status = rs.getString("status");
                        matchUsr.distance = rs.getString("distance");

                        String query7 = "select unitsRequird, unitsMatched, bloodOrPlatelet from [DBO].[BloodPlateletRequestUser] where bplUserRequestID='" + matchUsr.requestID + "'";
                        Statement stmt7 = con.createStatement();
                        ResultSet rs7 = stmt7.executeQuery(query7);

                        String tempType = "";
                        int unitsMatched=0,unitsRequested=1;
                        while (rs7.next())
                        {
                            tempType = rs7.getString("bloodOrPlatelet");
                            unitsMatched=parseInt(rs7.getString("unitsMatched"));
                            unitsRequested=parseInt(rs7.getString("unitsRequird"));

                        }
                        if (matchUsr.matchID.toString().equals(currID.toString()) && matchUsr.status.equals("pending")&&unitsMatched<unitsRequested) {
                            mMatchUsrList.add(matchUsr);

                            String query3 = "select E.Name from [DBO].[Establishment] E, [DBO].[BloodPlateletRequestUser] B where E.establishmentID=B.establishmentID AND B.bplUserRequestID='" + matchUsr.requestID + "'";
                            Statement stmt3 = con.createStatement();
                            ResultSet rs3 = stmt3.executeQuery(query3);


                            String temp = "";
                            while (rs3.next())
                            {
                                String s = String.format("%.2f", (parseFloat(matchUsr.distance) / 3600));
                                temp = "Place: " + rs3.getString("Name") + "    Travl time: " + s + "hours    Type: " + tempType;
                            }

                            estabNameList.add(temp);
                        }
                    }
                    //con.close();
                    if(estabNameList.size()==0)
                    {
                        estabNameList.add("No items to display");
                    }
                    if(estabNameList1.size()==0)
                    {
                        estabNameList1.add("No items to display");
                    }

                    lvEstab = (ListView) findViewById(R.id.listViewEstab);
                    ArrayAdapter<String> itemsAdapter1 =
                            new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, estabNameList1);
                    lvEstab.setAdapter(itemsAdapter1);

                    lvUser = (ListView) findViewById(R.id.listViewUser);

                    ArrayAdapter<String> itemsAdapter =
                            new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, estabNameList);


                    lvUser.setAdapter(itemsAdapter);
                    progressBar.setVisibility(View.INVISIBLE);

                    //Setting up of list view ends here next is click event

                    final String finalCurrID = currID;
                    lvEstab.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                        @Override
                        public void onItemClick(AdapterView<?> parent, View view,
                                                final int position, long id) {
                            progressBar.setVisibility(View.VISIBLE);

                            lvEstab.setVisibility(View.INVISIBLE);
                            lvUser.setVisibility(View.INVISIBLE);
                            textViewEstab.setVisibility(View.INVISIBLE);
                            textViewIndi.setVisibility(View.INVISIBLE);

                            layoutEstab.setVisibility(View.VISIBLE);
                            TextView txvDonateAt, txvType, txvRequestDate, txvTravelTime;
                            txvDonateAt = (TextView) findViewById(R.id.txvDonateAtE);
                            txvType = (TextView) findViewById(R.id.txvTypeE);
                            txvRequestDate = (TextView) findViewById(R.id.txvRequestDateE);
                            txvTravelTime = (TextView) findViewById(R.id.txvTravelTimeE);
                            Button accept, deny, back;
                            accept = (Button) findViewById(R.id.btnAcceptE);
                            deny = (Button) findViewById(R.id.btnDenyE);
                            back = (Button) findViewById(R.id.btnBackIncReqE);

                            String tempName = "";
                            String tempType = "";
                            String tempDate = "";


                            try {
                                String query5 = "select E.name from [DBO].[Establishment] E,[DBO].[BloodPlateletRequestEstab] B where E.establishmentID=B.establishmentID AND B.bplEstabRequestID='" + mMatchEstabList.get(position).requestID + "'";
                                Statement stmt5 = con.createStatement();
                                ResultSet rs5 = stmt5.executeQuery(query5);

                                while (rs5.next()) {
                                    tempName = rs5.getString("Name");
                                }

                                String query6 = "select bloodOrPlatelet from [DBO].[BloodPlateletRequestEstab] where bplEstabRequestID='" + mMatchEstabList.get(position).requestID + "'";
                                Statement stmt6 = con.createStatement();
                                ResultSet rs6 = stmt6.executeQuery(query6);

                                while (rs6.next()) {
                                    tempType = rs6.getString("bloodOrPlatelet");
                                }

                                String query7 = "select requestDate from [DBO].[BloodPlateletRequestEstab] where bplEstabRequestID='" + mMatchEstabList.get(position).requestID + "'";
                                Statement stmt7 = con.createStatement();
                                ResultSet rs7 = stmt7.executeQuery(query7);

                                while (rs7.next()) {
                                    tempDate = rs7.getString("requestDate");
                                }


                            } catch (SQLException e) {
                                e.printStackTrace();
                            }

                            Float d = parseFloat(mMatchEstabList.get(position).distance);
                            d = d / 3600;
                            String s = String.format("%.2f", d);



                            txvDonateAt.setText("Donate At: " + tempName);
                            txvType.setText("Type required: " + tempType);
                            txvRequestDate.setText("Date of Request: " + tempDate);
                            txvTravelTime.setText("Travel Time: " + s + " hours");
                            progressBar.setVisibility(View.INVISIBLE);

                            accept.setOnClickListener(new View.OnClickListener()
                            {
                                @Override
                                public void onClick(View v) {
                                    progressBar.setVisibility(View.VISIBLE);

                                    try {
                                        String query9 = "insert into [DBO].[BplTransactionEstabToUser] values ('" + mMatchEstabList.get(position).mid + "',1,'accepted')";
                                        Statement stmt9 = con.createStatement();
                                        stmt9.executeUpdate(query9);

                                        String query91 = "update [DBO].[BPMatchEstabToUser] set status='accepted' where bpMatchEstabUserID='" + mMatchEstabList.get(position).mid + "'";
                                        Statement stmt91 = con.createStatement();
                                        stmt91.executeUpdate(query91);

                                        String query93 = "select unitsRequired, unitsMatched from [DBO].[BloodPlateletRequestEstab] where bplEstabRequestID='" + mMatchEstabList.get(position).requestID + "'";
                                        Statement stmt93 = con.createStatement();
                                        ResultSet rs93 = stmt93.executeQuery(query93);

                                        while (rs93.next())
                                        {
                                            int x = parseInt(rs93.getString("unitsMatched"));
                                            x = x + 1;


                                                String query92 = "update [DBO].[BloodPlateletRequestEstab] set unitsMatched=" + x + " where bplEstabRequestID=('" + mMatchEstabList.get(position).requestID + "')";
                                                Statement stmt92 = con.createStatement();
                                                stmt92.executeUpdate(query92);

                                        }
                                        String query94 = "update [DBO].[LastDonationDate] set status='In transaction' where userId='" + finalCurrID + "'";
                                        Statement stmt94 = con.createStatement();
                                        stmt94.executeUpdate(query94);

                                        Intent goToTransactionActivity = new Intent(IncomingRequestsActivity.this, BloodPlateletTransactionActivity.class);
                                        startActivity(goToTransactionActivity);

                                    } catch (SQLException e) {
                                        e.printStackTrace();
                                    }

                                    progressBar.setVisibility(View.INVISIBLE);

                                }
                            });

                            deny.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    progressBar.setVisibility(View.VISIBLE);

                                    String query91 = "update [DBO].[BPMatchEstabToUser] set status='declined' where bpMatchEstabUserID='" + mMatchEstabList.get(position).matchID + "'";
                                    Statement stmt91 = null;
                                    try {
                                        stmt91 = con.createStatement();
                                        stmt91.executeUpdate(query91);

                                    } catch (SQLException e) {
                                        e.printStackTrace();
                                    }
                                    progressBar.setVisibility(View.INVISIBLE);
                                    finish();
                                    startActivity(getIntent());


                                }

                            });

                            back.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    lvEstab.setVisibility(View.VISIBLE);
                                    lvUser.setVisibility(View.VISIBLE);
                                    textViewEstab.setVisibility(View.VISIBLE);
                                    textViewIndi.setVisibility(View.VISIBLE);

                                    layoutEstab.setVisibility(View.INVISIBLE);

                                }

                            });
                        }

                    });


                    //from user list view here


                    lvUser.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                        @Override
                        public void onItemClick(AdapterView<?> parent, View view,
                                                final int position, long id) {

                            progressBar.setVisibility(View.VISIBLE);

                            lvEstab.setVisibility(View.INVISIBLE);
                            lvUser.setVisibility(View.INVISIBLE);
                            textViewEstab.setVisibility(View.INVISIBLE);
                            textViewIndi.setVisibility(View.INVISIBLE);

                            layoutUser.setVisibility(View.VISIBLE);
                            TextView txvDonateAt, txvType, txvRequestDate, txvTravelTime, txvRequestBy;
                            txvDonateAt = (TextView) findViewById(R.id.txvDonateAtU);
                            txvType = (TextView) findViewById(R.id.txvTypeU);
                            txvRequestDate = (TextView) findViewById(R.id.txvRequestDateU);
                            txvTravelTime = (TextView) findViewById(R.id.txvTravelTimeU);
                            txvRequestBy = (TextView) findViewById(R.id.txvRequestByU);
                            Button accept, deny, back;
                            accept = (Button) findViewById(R.id.btnAcceptU);
                            deny = (Button) findViewById(R.id.btnDenyU);
                            back = (Button) findViewById(R.id.btnBackIncReqU);

                            //mMatchEstabList.get(position).requestID;
                            String tempName = "";
                            String tempRequester = "";
                            String tempType = "";
                            String tempDate = "";


                            try {
                                String query5 = "select E.name from [DBO].[Establishment] E,[DBO].[BloodPlateletRequestUser] B where E.establishmentID=B.establishmentID AND B.bplUserRequestID='" + mMatchUsrList.get(position).requestID + "'";
                                Statement stmt5 = con.createStatement();
                                ResultSet rs5 = stmt5.executeQuery(query5);

                                while (rs5.next()) {
                                    tempName = rs5.getString("Name");
                                }

                                String query6 = "select bloodOrPlatelet from [DBO].[BloodPlateletRequestUser] where bplUserRequestID='" + mMatchUsrList.get(position).requestID + "'";
                                Statement stmt6 = con.createStatement();
                                ResultSet rs6 = stmt6.executeQuery(query6);

                                while (rs6.next()) {
                                    tempType = rs6.getString("bloodOrPlatelet");
                                }

                                String query7 = "select requestDate,requestorID from [DBO].[BloodPlateletRequestUser] where bplUserRequestID='" + mMatchUsrList.get(position).requestID + "'";
                                Statement stmt7 = con.createStatement();
                                ResultSet rs7 = stmt7.executeQuery(query7);

                                while (rs7.next()) {
                                    tempDate = rs7.getString("requestDate");
                                    tempRequester = rs7.getString("requestorID");
                                }

                            } catch (SQLException e) {
                                e.printStackTrace();
                            }

                            Float d = parseFloat(mMatchUsrList.get(position).distance);
                            d = d / 3600;
                            String s = String.format("%.2f", d);
                            txvDonateAt.setText("Donate At: " + tempName);
                            txvRequestBy.setText("Request By: " + tempRequester);
                            txvType.setText("Type required: " + tempType);
                            txvRequestDate.setText("Date of Request: " + tempDate);
                            txvTravelTime.setText("Travel Time: " + s + " hours");
                            progressBar.setVisibility(View.INVISIBLE);

                            accept.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    progressBar.setVisibility(View.VISIBLE);

                                    try {
                                        String query9 = "insert into [DBO].[BplTransactionUserToUser] values ('" + mMatchUsrList.get(position).mid + "','accepted')";
                                        Statement stmt9 = con.createStatement();
                                        stmt9.executeUpdate(query9);

                                        String query94 = "update [DBO].[LastDonationDate] set status ='In transaction' where userID='"+mMatchUsrList.get(position).matchID+"'";
                                        Statement stmt94 = con.createStatement();
                                        stmt94.executeUpdate(query94);

                                        String query91 = "update [DBO].[BPMatchUserToUser] set status='accepted' where bpMatchUsrUsr='" + mMatchUsrList.get(position).mid + "'";
                                        Statement stmt91 = con.createStatement();
                                        stmt91.executeUpdate(query91);

                                        String query93 = "select unitsRequird, unitsMatched from [DBO].[BloodPlateletRequestUser] where bplUserRequestID='" + mMatchUsrList.get(position).requestID + "'";
                                        Statement stmt93 = con.createStatement();
                                        ResultSet rs93 = stmt93.executeQuery(query93);

                                        while (rs93.next()) {
                                            int x = parseInt(rs93.getString("unitsMatched"));
                                            x = x + 1;

                                                String query92 = "update [DBO].[BloodPlateletRequestUser] set unitsMatched=" + x + " where bplUserRequestID=('" + mMatchUsrList.get(position).requestID + "')";
                                                Statement stmt92 = con.createStatement();
                                                stmt92.executeUpdate(query92);


                                        }

                                        String query95 = "update [DBO].[LastDonationDate] set status='In transaction' where userId='" + finalCurrID + "'";
                                        Statement stmt95 = con.createStatement();
                                        stmt95.executeUpdate(query95);
                                        Intent goToTransactionActivity = new Intent(IncomingRequestsActivity.this, BloodPlateletTransactionActivity.class);
                                        startActivity(goToTransactionActivity);
                                        progressBar.setVisibility(View.INVISIBLE);


                                    } catch (SQLException e) {
                                        e.printStackTrace();
                                    }

                                }
                            });

                            deny.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    progressBar.setVisibility(View.VISIBLE);

                                    String query91 = "update [DBO].[BPMatchUserToUser] set status='declined' where bpMatchUsrUsr='" + mMatchUsrList.get(position).mid + "'";
                                    Statement stmt91 = null;
                                    try {
                                        stmt91 = con.createStatement();
                                        stmt91.executeUpdate(query91);

                                    } catch (SQLException e) {
                                        e.printStackTrace();
                                    }
                                    progressBar.setVisibility(View.INVISIBLE);
                                    finish();
                                    startActivity(getIntent());


                                }

                            });

                            back.setOnClickListener(new View.OnClickListener() {
                                @Override
                                public void onClick(View v) {
                                    lvEstab.setVisibility(View.VISIBLE);
                                    lvUser.setVisibility(View.VISIBLE);
                                    textViewEstab.setVisibility(View.VISIBLE);
                                    textViewIndi.setVisibility(View.VISIBLE);
                                    layoutUser.setVisibility(View.INVISIBLE);

                                }

                            });


                        }

                    });


                }
            }
        }
        catch (Exception ex)
        {
            isSuccess = false;
            z = ex.getMessage();
        }
        Toast.makeText(IncomingRequestsActivity.this, z, Toast.LENGTH_SHORT).show();

        progressBar.setVisibility(View.INVISIBLE);

    }

public class MatchUsr{
    public String mid;
    public String requestID;
    public String matchID;
    public String status;
    public String distance;
}

public class MatchEstab{
    public String mid;
    public String requestID;
    public String matchID;
    public String status;
    public String distance;
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

    @Override
    public void onBackPressed() {
        //disabling back button
    }
}

