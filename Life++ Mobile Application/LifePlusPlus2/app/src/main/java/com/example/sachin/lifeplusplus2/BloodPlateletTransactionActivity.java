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

import static java.lang.Float.parseFloat;
import static java.lang.Integer.parseInt;

public class BloodPlateletTransactionActivity extends AppCompatActivity
{
    String db;
    Connection con;
    TextView txvDonateAt, txvRequestBy, txvRequestDate, txvRequestType, txvTravelTime,txvChatWith;
    Button btnCancel, btnMessage,btnSendMessage;
    ImageButton home;
    ListView lvchat;
    EditText edtxChatMessage;
    LinearLayout layoutChatReq;

    @Override
    protected void onCreate(Bundle savedInstanceState) {


        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_blood_platelet_transaction);
        db = "jdbc:jtds:sqlserver://lifeplusplus.database.windows.net:1433;databaseName=fyp1;user=lifeplusplus;password=ITMajorProject1;encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;";//loginTimeout=30;";

        txvDonateAt = (TextView) findViewById(R.id.txvDonateAt);
        txvRequestBy = (TextView) findViewById(R.id.txvRequestBy);
        txvRequestDate = (TextView) findViewById(R.id.txvRequestDate);
        txvRequestType = (TextView) findViewById(R.id.txvRequestType);
        txvTravelTime = (TextView) findViewById(R.id.txvTravelTime);
        btnCancel = (Button) findViewById(R.id.btnCancel);
        btnMessage = (Button) findViewById(R.id.btnMessage);
        btnSendMessage=(Button)findViewById(R.id.btnSendMessage);
        home=(ImageButton)findViewById(R.id.btnHome);
        //lvchat=(ListView)findViewById(R.id.ListViewChat);
        edtxChatMessage=(EditText)findViewById(R.id.edtxChatMessage);
        txvChatWith = (TextView) findViewById(R.id.txtChatWith);
        layoutChatReq=(LinearLayout)findViewById(R.id.layoutChatReq);


        String z = "Loading complete",currID="",otherID="";
        try {
            con = connectionclass(db);        // Connect to database
            if (con == null) {
                z = "Check Your Internet Access!";
            }
            else {

                String query2 = "select UserID from [DBO].[Users] where email='" + SaveSharedPreference.getUserId(BloodPlateletTransactionActivity.this) + "'";
                Statement stmt2 = con.createStatement();
                ResultSet rs2 = stmt2.executeQuery(query2);
                while (rs2.next()) {
                    currID = rs2.getString("UserID");
                }

                String query = "select * from [DBO].[BplTransactionEstabToUser] T,[DBO].[BPMatchEstabToUser] M,[DBO].[BloodPlateletRequestEstab] R where M.matchID='" + currID+ "' and T.status='accepted' and T.bpMatchEstabUserID= M.bpMatchEstabUserID and M.bplEstabRequestID=R.bplEstabRequestID";
                Statement stmt = con.createStatement();
                final ResultSet rs = stmt.executeQuery(query);
                if (rs.next()) {
                    txvRequestDate.setVisibility(View.VISIBLE);
                    txvTravelTime.setVisibility(View.VISIBLE);
                    txvRequestType.setVisibility(View.VISIBLE);
                    txvDonateAt.setVisibility(View.VISIBLE);
                    btnCancel.setVisibility(View.VISIBLE);
                    float td = (parseFloat(rs.getString("distance")) / 3600);
                    String s = String.format("%.2f", td);
                    txvTravelTime.setText("Travel time: " + s);
                    txvRequestDate.setText("Requested Date: " + rs.getString("requestDate"));
                    txvRequestType.setText("Request Type: " + rs.getString("bloodOrPlatelet"));
                    otherID = rs.getString("establishmentID");

                    String query11 = "select name from [DBO].[establishment] where establishmentID='" + otherID + "'";
                    Statement stmt11 = con.createStatement();
                    ResultSet rs11 = stmt11.executeQuery(query11);
                    if (rs11.next()) {
                        txvDonateAt.setText("Donate At: " + rs11.getString("name"));
                    }

                    final String finalCurrID = currID;
                    btnCancel.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            try {
                                String query91 = "update [DBO].[BplTransactionEstabToUser] set status='cancelled' where bplEstabTrasactionID='" + rs.getString("bplEstabTrasactionID") + "'";
                                Statement stmt91 = con.createStatement();
                                stmt91.executeUpdate(query91);

                                String query92 = "update [DBO].[BPMatchEstabToUser] set status='declined' where bpMatchEstabUserID='" + rs.getString("bpMatchEstabUserID") + "'";
                                Statement stmt92 = con.createStatement();
                                stmt92.executeUpdate(query92);

                                int um = parseInt(rs.getString("unitsMatched"));

                                String query93 = "update [DBO].[BloodPlateletRequestEstab] set unitsMatched=" + (um - 1) + " where bplEstabRequestID='" + rs.getString("bplEstabRequestID") + "'";
                                Statement stmt93 = con.createStatement();
                                stmt93.executeUpdate(query93);

                                String query94 = "update [DBO].[LastDonationDate] set status='Not in transaction' where userId='" + finalCurrID + "'";
                                Statement stmt94 = con.createStatement();
                                stmt94.executeUpdate(query94);


                            } catch (SQLException e) {
                                e.printStackTrace();
                            }
                            Intent goToMainActivity = new Intent(BloodPlateletTransactionActivity.this, MainActivity.class);
                            startActivity(goToMainActivity);
                        }
                    });


                }

                String query3 = "select * from [DBO].[BplTransactionUserToUser] T,[DBO].[BPMatchUserToUser] M,[DBO].[BloodPlateletRequestUser] R where M.matchID='" + currID+ "' and T.status='accepted' and T.bpMatchUsrUsr= M.bpMatchUsrUsr and M.bplUserRequestID=R.bplUserRequestID";
                Statement stmt3 = con.createStatement();
                final ResultSet rs3 = stmt3.executeQuery(query3);
                if (rs3.next())
                {
                    txvRequestDate.setVisibility(View.VISIBLE);
                    txvTravelTime.setVisibility(View.VISIBLE);
                    txvRequestType.setVisibility(View.VISIBLE);
                    txvDonateAt.setVisibility(View.VISIBLE);
                    txvRequestBy.setVisibility(View.VISIBLE);
                    btnCancel.setVisibility(View.VISIBLE);
                    btnMessage.setVisibility(View.VISIBLE);
                    float td=(parseFloat(rs3.getString("distance"))/3600);
                    String s = String.format("%.2f", td);

                    txvTravelTime.setText("Travel time: "+s);
                    txvRequestDate.setText("Requested Date: "+rs3.getString("requestDate"));
                    txvRequestType.setText("Request Type: "+rs3.getString("bloodOrPlatelet"));
                    otherID=rs3.getString("establishmentID");
                    String query11 = "select name from [DBO].[establishment] where establishmentID='"+otherID+"'";
                    Statement stmt11 = con.createStatement();
                    ResultSet rs11 = stmt11.executeQuery(query11);
                    if(rs11.next())
                    {
                        txvDonateAt.setText("Donate At: "+rs11.getString("name"));
                    }

                    String query12 = "select name from [DBO].[users] where UserID='"+rs3.getString("requestorID")+"'";
                    Statement stmt12 = con.createStatement();
                    ResultSet rs12 = stmt12.executeQuery(query12);
                    if(rs12.next())
                    {
                        txvRequestBy.setText("Requested By: "+rs12.getString("name"));
                    }

                    final String finalCurrID1 = currID;
                    btnCancel.setOnClickListener(new View.OnClickListener()
                    {
                        @Override
                        public void onClick(View v)
                        {
                            try {
                                String query91 = "update [DBO].[BplTransactionUserToUser] set status='cancelled' where bplUserTrasactionID='" + rs3.getString("bplUserTrasactionID") + "'";
                                Statement stmt91 = con.createStatement();
                                stmt91.executeUpdate(query91);

                                String query92 = "update [DBO].[BPMatchUserToUser] set status='declined' where bpMatchUsrUsr='" + rs3.getString("bpMatchUsrUsr") + "'";
                                Statement stmt92 = con.createStatement();
                                stmt92.executeUpdate(query92);

                                int um=parseInt(rs3.getString("unitsMatched"));
                                String query93 = "update [DBO].[BloodPlateletRequestUser] set unitsMatched="+(um-1)+" where bplUserRequestID='" + rs3.getString("bplUserRequestID") + "'";
                                Statement stmt93 = con.createStatement();
                                stmt93.executeUpdate(query93);
                                String query94 = "update [DBO].[LastDonationDate] set status='Not in transaction' where userId='" + finalCurrID1 + "'";
                                Statement stmt94 = con.createStatement();
                                stmt94.executeUpdate(query94);

                            } catch (SQLException e) {
                                e.printStackTrace();
                            }
                            Intent goToMainActivity = new Intent(BloodPlateletTransactionActivity.this, MainActivity.class);
                            startActivity(goToMainActivity);
                        }
                    });

                }
                final String finalCurrID2 = currID;
                final String finalOtherID1 = otherID;
                btnMessage.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        layoutChatReq.setVisibility(View.VISIBLE);
                        String query22 = "select * from [DBO].[IndividualChat] where (sender='" + finalCurrID2 + "' AND receiver='"+ finalOtherID1 +"') OR (sender='"+finalOtherID1+"' AND receiver='"+finalCurrID2+"') order by time";
                        chat chatTask = new chat();// this is the Asynctask, which is used to process in background to reduce load on app process
                        chatTask.execute(query22);

                        btnSendMessage.setOnClickListener(new View.OnClickListener()
                        {
                            @Override
                            public void onClick (View v)
                            {
                                String currentDateandTime = new SimpleDateFormat("MM/dd/yyy HH:mm:ss").format(new Date());
                                String query22 = "insert into [DBO].[IndividualChat] values ('" + finalCurrID2 + "','"+finalOtherID1+"','"+currentDateandTime+"','"+ edtxChatMessage.getText().toString()+"')";
                                Statement stmt22 = null;
                                try {
                                    stmt22 = con.createStatement();
                                    stmt22.executeUpdate(query22);
                                    edtxChatMessage.setText("");
                                    layoutChatReq.setVisibility(View.GONE);

                                } catch (SQLException e) {
                                    e.printStackTrace();
                                }
                            }
                        });

                    }
                });


            }


        } catch (Exception ex) {

            z = ex.getMessage();
        }
        Toast.makeText(BloodPlateletTransactionActivity.this, z, Toast.LENGTH_SHORT).show();

        home.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick (View v)
            {
                Intent goToMainActivity = new Intent(BloodPlateletTransactionActivity.this, MainActivity.class);
                startActivity(goToMainActivity);
            }
        });
    }

    private class chat extends AsyncTask<String, Void, List<String>>
    {
        @Override
        protected void onPostExecute(List<String> r)
        {
            lvchat=(ListView)findViewById(R.id.ListViewChat);
            ArrayAdapter<String> itemsAdapter4 =
                    new ArrayAdapter<String>(BloodPlateletTransactionActivity.this, android.R.layout.simple_list_item_1, r);
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
