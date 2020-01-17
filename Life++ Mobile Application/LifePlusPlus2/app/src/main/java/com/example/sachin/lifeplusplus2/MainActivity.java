package com.example.sachin.lifeplusplus2;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    Button logout,requestBlood,incomingRequests;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        TextView userEmail=(TextView)findViewById(R.id.txvEmail);
        if(SaveSharedPreference.getUserId(MainActivity.this).length() == 0)
        {
            // call Login Activity
            Intent goToLoginActivity=new Intent(MainActivity.this,LogInActivity.class);
            startActivity(goToLoginActivity);
        }
        else {
            // Stay at the current activity.
            userEmail.setText(SaveSharedPreference.getUserId(MainActivity.this));
            Intent intent = new Intent(MainActivity.this, LocationUpdaterService.class);        //location services are called
            startService(intent);
        }
        logout = (Button) findViewById(R.id.btnLogout);
        requestBlood=(Button) findViewById(R.id.btnRequestBloodPlatelet);
        incomingRequests=(Button)findViewById(R.id.btnIncomingRequests);
        logout.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                SaveSharedPreference.clearUserId(MainActivity.this);
                Intent intent = new Intent(MainActivity.this, LocationUpdaterService.class);
                stopService(intent);
                Intent goToLoginActivity=new Intent(MainActivity.this,LogInActivity.class);        //redirects to the login activity
                startActivity(goToLoginActivity);
            }
        });   //signing out of the app and clearing the saved share preference
        requestBlood.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Intent goToBloodRequestActivity=new Intent(MainActivity.this,BloodPlateletRequestActivity.class);
                startActivity(goToBloodRequestActivity);            //go to activity
            }
        });         //proceed to the activity where requests from user side happen

        incomingRequests.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Intent goToIncomingRequestActivity=new Intent(MainActivity.this,IncomingRequestsActivity.class);
                startActivity(goToIncomingRequestActivity);     //got to activity
            }
        });        //all incoming requests start in this activity
    }
}
