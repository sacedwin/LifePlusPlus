package com.example.sachin.lifeplusplus2;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Handler;

import static java.lang.Float.parseFloat;

public class BloodPlateletCurrentRequestActivity extends AppCompatActivity {

    ListView lvSendRequests,lvMatchEstab,lvMatchUser,lvchat;
    String db;
    Connection con;
    LinearLayout layoutSendCurrRequests,layoutChatReq;
    ImageButton home;
    TextView txvUnitsRequired,txvUnitsMatched,txvDonateLocation,txvBloodGroup,txvType,txvRequestDate,txvChatWith;
    Button btnBackToOutgoingReq,btnSendMessage,btnBacktoRequestForm;
    EditText edtxChatMessage;
    ImageView imgCurrentRequests;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_blood_platelet_current_request);
        home=(ImageButton)findViewById(R.id.btnHome);
        btnSendMessage=(Button)findViewById(R.id.btnSendMessage);
        btnBacktoRequestForm=(Button)findViewById(R.id.btnBackToBPReqForm);
        lvchat=(ListView)findViewById(R.id.ListViewChat);
        edtxChatMessage=(EditText)findViewById(R.id.edtxChatMessage);
        txvChatWith = (TextView) findViewById(R.id.txtChatWith);
        imgCurrentRequests=(ImageView)findViewById(R.id.imgCurrentRequests);

        layoutSendCurrRequests=(LinearLayout)findViewById(R.id.layoutSendRequestCurr);
        layoutChatReq=(LinearLayout)findViewById(R.id.layoutChatReq);
        lvSendRequests=(ListView)findViewById(R.id.ListViewSendOutRequests);

        home.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToMainActivity = new Intent(BloodPlateletCurrentRequestActivity.this, MainActivity.class);
                startActivity(goToMainActivity);
            }
        });
        btnBacktoRequestForm.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToRequestForm = new Intent(BloodPlateletCurrentRequestActivity.this, BloodPlateletRequestActivity.class);
                startActivity(goToRequestForm);
            }
        });
        db="jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";
        String z = "Loading complete",currID="";
        Boolean isSuccess = false;
        try {
            con = connectionclass(db);        // Connect to database
            if (con == null)
            {
                z = "Check Your Internet Access!";
            }
            else {
                String query2 = "select * from [DBO].[Users] where email='" + SaveSharedPreference.getUserId(BloodPlateletCurrentRequestActivity.this) + "'";
                Statement stmt2 = con.createStatement();
                ResultSet rs2 = stmt2.executeQuery(query2);
                while (rs2.next()) {
                    currID = rs2.getString("UserID");
                }

                String query1 = "select * from [DBO].[BloodPlateletRequestUser] where requestorID='" + currID + "' and status='pending'";
                Statement stmt1 = con.createStatement();
                ResultSet rs1 = stmt1.executeQuery(query1);
                final List<BloodPlateletRequestUserClass> userRequestList = new LinkedList<BloodPlateletRequestUserClass>();
                List<String> reqListAdapter = new LinkedList<String>();
                while (rs1.next()) {
                    BloodPlateletRequestUserClass tempRequest = new BloodPlateletRequestUserClass();
                    tempRequest.bplUserRequestID = rs1.getString("bplUserRequestID");
                    tempRequest.unitsRequired = rs1.getString("unitsRequird");
                    tempRequest.unitsMatched = rs1.getString("unitsMatched");
                    tempRequest.establishmentID = rs1.getString("establishmentID");
                    tempRequest.requestorID = rs1.getString("requestorID");
                    tempRequest.bloodGroup = rs1.getString("bloodGroup");
                    tempRequest.bloodOrPlatelet = rs1.getString("bloodOrPlatelet");
                    tempRequest.status = rs1.getString("status");
                    tempRequest.requestDate = rs1.getString("requestDate");
                    userRequestList.add(tempRequest);
                    String temp = "Request ID: " + tempRequest.bplUserRequestID + " | Donate At: " + tempRequest.establishmentID + " | Broup: " + tempRequest.bloodGroup + " | Type: " + tempRequest.bloodOrPlatelet + " | Date: " + tempRequest.requestDate;
                    reqListAdapter.add(temp);
                }
                if (reqListAdapter.size() == 0) {
                    reqListAdapter.add("NO ITEMS TO DISPLAY");
                }
                ArrayAdapter<String> itemsAdapter1 =
                        new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, reqListAdapter);
                lvSendRequests.setAdapter(itemsAdapter1);
                final String finalCurrID = currID;

                lvSendRequests.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                    @Override
                    public void onItemClick(AdapterView<?> parent, View view,
                                            final int position, long id) {
                        lvSendRequests.setVisibility(View.INVISIBLE);
                        imgCurrentRequests.setVisibility(View.INVISIBLE);
                        layoutSendCurrRequests.setVisibility(View.VISIBLE);
                        txvDonateLocation = (TextView) findViewById(R.id.txvDonateLocation);
                        txvBloodGroup = (TextView) findViewById(R.id.txvBloodGroup);
                        txvRequestDate = (TextView) findViewById(R.id.txvRequestDate);
                        txvType = (TextView) findViewById(R.id.txvType);
                        txvUnitsMatched = (TextView) findViewById(R.id.txvUnitsMatched);
                        txvUnitsRequired = (TextView) findViewById(R.id.txvUnitsRequired);
                        lvMatchEstab = (ListView) findViewById(R.id.ListViewMatchEstab);
                        lvMatchUser = (ListView) findViewById(R.id.ListViewMatchUsers);
                        btnBackToOutgoingReq = (Button) findViewById(R.id.btnBackToRequests);


                        txvDonateLocation.setText("Donate At: " + userRequestList.get(position).establishmentID);
                        txvType.setText("Request Type: " + userRequestList.get(position).bloodOrPlatelet);
                        txvBloodGroup.setText("Blood Group: " + userRequestList.get(position).bloodGroup);
                        txvUnitsRequired.setText("Units Required: " + userRequestList.get(position).unitsRequired);
                        txvUnitsMatched.setText("Units Matched: " + userRequestList.get(position).unitsMatched);
                        txvRequestDate.setText("Requested Date: " + userRequestList.get(position).requestDate);


                        try {
                            String query3 = "select M.bplUserRequestID,M.bpMatchUsrUsr,M.matchID,M.distance,T.status from [DBO].[BPMatchUserToUser] M,[DBO].[BplTransactionUserToUser] T where T.bpMatchUsrUsr=M.bpMatchUsrUsr and M.bplUserRequestID='" + userRequestList.get(position).bplUserRequestID + "'";
                            Statement stmt3 = con.createStatement();
                            ResultSet rs3 = stmt3.executeQuery(query3);
                            final List<UserMatchClass> userMatchList = new LinkedList<UserMatchClass>();
                            final List<String> UserMatchListAdapter = new LinkedList<String>();
                            while (rs3.next()) {
                                UserMatchClass tempUMatch = new UserMatchClass();
                                tempUMatch.bplUserRequestID = rs3.getString("bplUserRequestID");
                                tempUMatch.bpMatchUsrUsr = rs3.getString("bpMatchUsrUsr");
                                tempUMatch.matchID = rs3.getString("matchID");
                                tempUMatch.distance = rs3.getString("distance");
                                String s = String.format("%.2f", (parseFloat(tempUMatch.distance)) / 60);
                                tempUMatch.status = rs3.getString("status");
                                userMatchList.add(tempUMatch);
                                String temp = "Request ID: " + tempUMatch.bplUserRequestID + " | Donation By: " + tempUMatch.matchID + " | Travel Time: " + s + "mins | Status: " + tempUMatch.status;
                                UserMatchListAdapter.add(temp);
                            }
                            if (UserMatchListAdapter.size() == 0) {
                                UserMatchListAdapter.add("NO ITEMS TO DISPLAY");
                            }
                            ArrayAdapter<String> itemsAdapter2 =
                                    new ArrayAdapter<String>(BloodPlateletCurrentRequestActivity.this, android.R.layout.simple_list_item_1, UserMatchListAdapter);
                            lvMatchUser.setAdapter(itemsAdapter2);

                            lvMatchUser.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                                @Override
                                public void onItemClick(AdapterView<?> parent, View view,
                                                        final int position, long id) {
                                    layoutSendCurrRequests.setVisibility(View.INVISIBLE);
                                    layoutChatReq.setVisibility(View.VISIBLE);
                                    final String t1 = userMatchList.get(position).matchID;
                                    txvChatWith.setText("Chat with " + t1);
                                    String query22 = "select * from [DBO].[IndividualChat] where (sender='" + finalCurrID + "' AND receiver='" + t1 + "') OR (sender='" + t1 + "' AND receiver='" + finalCurrID + " order by time')";
                                    chat chatTask = new chat();// this is the Asynctask, which is used to process in background to reduce load on app process
                                    chatTask.execute(query22);
                                    btnSendMessage.setOnClickListener(new View.OnClickListener() {
                                        @Override
                                        public void onClick(View v) {
                                            String currentDateandTime = new SimpleDateFormat("MM/dd/yyy HH:mm:ss").format(new Date());
                                            String query22 = "insert into [DBO].[IndividualChat] values ('" + finalCurrID + "','" + t1 + "','" + currentDateandTime + "','" + edtxChatMessage.getText().toString() + "')";
                                            Statement stmt22 = null;
                                            try {
                                                stmt22 = con.createStatement();
                                                stmt22.executeUpdate(query22);
                                                layoutSendCurrRequests.setVisibility(View.VISIBLE);
                                                edtxChatMessage.setText("");
                                                layoutChatReq.setVisibility(View.GONE);

                                            } catch (SQLException e) {
                                                e.printStackTrace();
                                            }
                                        }
                                    });
                                }
                            });


                            String query4 = "select M.bplUserRequestID,M.bpMatchUsrEstID,M.matchID,M.distance,T.status,T.unitsPossible from [DBO].[BPMatchUserToEstab] M,[DBO].[BplTransactionUserToEstab] T where T.bpMatchUsrEstID=M.bpMatchUsrEstID and M.bplUserRequestID='" + userRequestList.get(position).bplUserRequestID + "'";
                            Statement stmt4 = con.createStatement();
                            ResultSet rs4 = stmt4.executeQuery(query4);
                            final List<EstabMatchClass> EstabMatchList = new LinkedList<EstabMatchClass>();
                            List<String> EstabMatchListAdapter = new LinkedList<String>();
                            while (rs4.next()) {
                                EstabMatchClass tempUMatch = new EstabMatchClass();
                                tempUMatch.bplUserRequestID = rs4.getString("bplUserRequestID");
                                tempUMatch.bpMatchUsrEstID = rs4.getString("bpMatchUsrEstID");
                                tempUMatch.matchID = rs4.getString("matchID");
                                tempUMatch.distance = rs4.getString("distance");
                                String s = String.format("%.2f", (parseFloat(tempUMatch.distance)) / 60);

                                tempUMatch.status = rs4.getString("status");
                                tempUMatch.unitsPossible = rs4.getString("unitsPossible");
                                EstabMatchList.add(tempUMatch);
                                String temp = "Request ID: " + tempUMatch.bplUserRequestID + " | Donation By: " + tempUMatch.matchID + " | Units Possible: " + tempUMatch.unitsPossible + " | Travel Time: " + s + "mins | Status: " + tempUMatch.status;
                                EstabMatchListAdapter.add(temp);
                            }
                            if (EstabMatchListAdapter.size() == 0) {
                                EstabMatchListAdapter.add("NO ITEMS TO DISPLAY");
                            }
                            ArrayAdapter<String> itemsAdapter3 =
                                    new ArrayAdapter<String>(BloodPlateletCurrentRequestActivity.this, android.R.layout.simple_list_item_1, EstabMatchListAdapter);
                            lvMatchEstab.setAdapter(itemsAdapter3);

                            lvMatchEstab.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                                @Override
                                public void onItemClick(AdapterView<?> parent, View view,
                                                        final int position, long id) {
                                    layoutSendCurrRequests.setVisibility(View.INVISIBLE);
                                    layoutChatReq.setVisibility(View.VISIBLE);

                                    txvChatWith.setText("Chat with " + EstabMatchList.get(position).matchID);
                                    String query22 = "select * from [DBO].[IndividualChat] where (sender='" + finalCurrID + "' AND receiver='" + EstabMatchList.get(position).matchID + "') OR (sender='" + EstabMatchList.get(position).matchID + "' AND receiver='" + finalCurrID + "') order by time";
                                    chat chatTask = new chat();// this is the Asynctask, which is used to process in background to reduce load on app process
                                    chatTask.execute(query22);
                                    btnSendMessage.setOnClickListener(new View.OnClickListener() {
                                        @Override
                                        public void onClick(View v) {
                                            String currentDateandTime = new SimpleDateFormat("MM/dd/yyy HH:mm:ss").format(new Date());
                                            String query22 = "insert into [DBO].[IndividualChat] values ('" + finalCurrID + "','" + EstabMatchList.get(position).matchID + "','" + currentDateandTime + "','" + edtxChatMessage.getText().toString() + "')";
                                            Statement stmt22 = null;
                                            try {
                                                stmt22 = con.createStatement();
                                                stmt22.executeUpdate(query22);
                                                layoutSendCurrRequests.setVisibility(View.VISIBLE);
                                                edtxChatMessage.setText("");
                                                layoutChatReq.setVisibility(View.INVISIBLE);

                                            } catch (SQLException e) {
                                                e.printStackTrace();
                                            }
                                        }
                                    });
                                }
                            });
                        } catch (SQLException e) {
                            e.printStackTrace();
                        }

                        btnBackToOutgoingReq.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                lvSendRequests.setVisibility(View.VISIBLE);
                                imgCurrentRequests.setVisibility(View.VISIBLE);
                                layoutSendCurrRequests.setVisibility(View.INVISIBLE);
                            }
                        });
                    }
                });
            }
        }

        catch (Exception ex) {
            isSuccess = false;
            z = ex.getMessage();
        }
        Toast.makeText(BloodPlateletCurrentRequestActivity.this, z, Toast.LENGTH_SHORT).show();

    }

    private class chat extends AsyncTask<String, Void, List<String>>
    {
        @Override
        protected void onPostExecute(List<String> r)
        {
            lvchat=(ListView)findViewById(R.id.ListViewChat);
            ArrayAdapter<String> itemsAdapter4 =
                    new ArrayAdapter<String>(BloodPlateletCurrentRequestActivity.this, android.R.layout.simple_list_item_1, r);
            lvchat.setAdapter(itemsAdapter4);
        }

        @Override
        protected List<String> doInBackground(String... params)
        {
            String query22=params[0];
            List<String> chatList = new LinkedList<String>();

            try {
                Statement stmt22 = con.createStatement();
                ResultSet rs22 = stmt22.executeQuery(query22);
                while (rs22.next()) {
                    String temp = rs22.getString("sender") + " @" + rs22.getString("time") + ": " + rs22.getString("message");
                    chatList.add(temp);
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
            return chatList;
        }
    }

    public class BloodPlateletRequestUserClass{
        public String bplUserRequestID;
        public String unitsRequired;
        public String unitsMatched;
        public String establishmentID;
        public String requestorID;
        public String bloodGroup;
        public String bloodOrPlatelet;
        public String status;
        public String requestDate;
    }

    public class UserMatchClass{
        public String bpMatchUsrUsr;
        public String bplUserRequestID;
        public String matchID;
        public String distance;
        public String status;
    }
    public class EstabMatchClass{
        public String bpMatchUsrEstID;
        public String bplUserRequestID;
        public String matchID;
        public String distance;
        public String status;
        public String unitsPossible;
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
