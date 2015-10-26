package com.iwms.cleartrash;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.PendingIntent;
import android.content.DialogInterface;
import android.content.Intent;
import android.location.LocationManager;
import android.os.Bundle;
import android.app.Activity;
import android.provider.Settings;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ScrollView;
import android.widget.Toast;

import java.util.concurrent.ExecutionException;

public class HomeActivity extends Activity {

    ImageButton hhGarbageButton, spotGarbageButton, registerVolunteerButton, checkmyPointsButton;
    ScrollView scrollView;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        turnGPSOn();

        hhGarbageButton = (ImageButton)findViewById(R.id.hhGarbageButton);
        spotGarbageButton = (ImageButton)findViewById(R.id.spotGarbageButton);
        registerVolunteerButton = (ImageButton)findViewById(R.id.registerVolunteerButton);
        checkmyPointsButton = (ImageButton)findViewById(R.id.checkmyPointsButton);

        hhGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String signInUrl = "http://" + Helper.Server  + "/ManagementService/api/household/authenticate%7C" + Helper.Key;
                RequestTask task = (RequestTask) new RequestTask().execute(signInUrl);
                String statusCode = "";

                try {
                    statusCode = task.get();
                    if (statusCode.contains("205") || statusCode.contains("206")) {
                        InsertAddress();
                    }
                    else if (statusCode.contains("207") || statusCode.contains("208"))
                    {
                        Intent intent = new Intent(HomeActivity.this, HHGDisplayAddressActivity.class);
                        startActivity(intent);
                    }
                    else
                    {
                        Toast.makeText(getApplicationContext(), "Error, Please Try Again!", Toast.LENGTH_SHORT).show();
                    }
                }
                catch (InterruptedException e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
                catch (ExecutionException e)
                {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        });

        spotGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, SpotImageActivity.class);
                startActivity(intent);
            }
        });

        registerVolunteerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, VolunteerConfirmationActivity.class);
                startActivity(intent);
            }
        });

        checkmyPointsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, PointActivity.class);
                startActivity(intent);
            }
        });
    }

    public void InsertAddress()
    {
        // Build the alert dialog
        AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.THEME_HOLO_DARK);
        builder.setTitle("Household Garbage Service");
        builder.setMessage("Please enter your Home Address");
        builder.setNegativeButton("Use Current Location", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogInterface, int i) {
                // Show location settings when the user acknowledges the alert dialog
                // Show location settings when the user acknowledges the alert dialog
                Intent intent = new Intent(HomeActivity.this, HHGCurrentLocationActivity.class);
                startActivity(intent);
            }
        });
        builder.setPositiveButton("Enter Manually", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogInterface, int i) {
                // Show location settings when the user acknowledges the alert dialog
                Intent intent = new Intent(HomeActivity.this, HHGManualLocationActivity.class);
                startActivity(intent);
            }
        });
        Dialog alertDialog = builder.create();
        alertDialog.setCanceledOnTouchOutside(false);
        alertDialog.show();
    }

    public void turnGPSOn()
    {
        // Get Location Manager and check for GPS & Network location services
        LocationManager locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        if(!locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER))
        {
            // Build the alert dialog
            AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.THEME_HOLO_DARK);
            builder.setTitle("Location Services Not Active");
            builder.setMessage("Please enable Location Services and GPS");
            builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogInterface, int i) {
                    // Show location settings when the user acknowledges the alert dialog
                    Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                    startActivity(intent);
                }
            });
            builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogInterface, int i) {
                    // Show location settings when the user acknowledges the alert dialog
                    finish();
                }
            });
            Dialog alertDialog = builder.create();
            alertDialog.setCanceledOnTouchOutside(false);
            alertDialog.show();
        }
    }

    public void turnGPSOff()
    {
        // Get Location Manager and check for GPS & Network location services
        LocationManager locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        if(locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
            Intent intent = new Intent(this, HomeActivity.class);
            PendingIntent pi = PendingIntent.getService(this, 0, intent,
                    PendingIntent.FLAG_UPDATE_CURRENT);
            if (pi != null) {
                locationManager.removeUpdates(pi);
            }
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up buttonhhgarbage, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onBackPressed() {
        moveTaskToBack(true);
    }
}
