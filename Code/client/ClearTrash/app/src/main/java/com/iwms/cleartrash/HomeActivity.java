package com.iwms.cleartrash;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.PendingIntent;
import android.content.DialogInterface;
import android.content.Intent;
import android.location.LocationManager;
import android.os.Bundle;
import android.provider.Settings;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.Toast;

import java.util.concurrent.ExecutionException;

public class HomeActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    LinearLayout hhGarbageButton, spotGarbageButton, registerVolunteerButton, checkmyPointsButton,
            knowSegregationButton, registerComplaintButton, suggestionsButton,bulkGarbageButton,
            donateUsedItemsButton, referFriendButton;
    LinearLayout linearLayout1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        turnGPSOn();

        hhGarbageButton = (LinearLayout)findViewById(R.id.linearLayout1);
        bulkGarbageButton = (LinearLayout)findViewById(R.id.linearLayout2);
        spotGarbageButton = (LinearLayout)findViewById(R.id.linearLayout3);
        registerVolunteerButton = (LinearLayout)findViewById(R.id.linearLayout4);
        knowSegregationButton = (LinearLayout) findViewById(R.id.linearLayout5);
        checkmyPointsButton = (LinearLayout)findViewById(R.id.linearLayout6);
        registerComplaintButton = (LinearLayout) findViewById(R.id.linearLayout7);
        donateUsedItemsButton = (LinearLayout)findViewById(R.id.linearLayout9);
        referFriendButton = (LinearLayout)findViewById(R.id.linearLayout11);
        suggestionsButton = (LinearLayout) findViewById(R.id.linearLayout12);

        hhGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                HouseHoldGarbage();
            }
        });

        spotGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SpotGarbage();
            }
        });

        registerVolunteerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Thread(new Runnable() {
                    public void run() {
                RegisterVolunteer();
                    }
                }).start();
            }
        });

        checkmyPointsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Thread(new Runnable() {
                    public void run() {
                        CheckMyPoints();
                    }
                    }).start();
            }
        });

        knowSegregationButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Thread(new Runnable() {
                    public void run() {
                        KnowWasteSegregation();
                    }
                }).start();
            }
        });
        registerComplaintButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Thread(new Runnable() {
                    public void run() {
                        Complain();
                    }
                }).start();
            }
        });
        suggestionsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Thread(new Runnable() {
                    public void run() {
                        Suggest();
                    }
                }).start();
            }
        });
        bulkGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getApplicationContext(), "This feature is not available!", Toast.LENGTH_SHORT).show();
            }
        });
        donateUsedItemsButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getApplicationContext(), "This feature is not available!", Toast.LENGTH_SHORT).show();
            }
        });
        referFriendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ReferFriend();
            }
        });
    }

    public void HouseHoldGarbage()
    {
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

    public void SpotGarbage()
    {
        Intent intent = new Intent(HomeActivity.this, SpotImageActivity.class);
        startActivity(intent);
    }

    public void RegisterVolunteer()
    {
        RequestTask task = null;
        String volunteerSubsciptionUrl = "http://" + Helper.Server + "/ManagementService/api/volunteer/rvs%7C" + Helper.Key;
        task = (RequestTask) new RequestTask().execute(volunteerSubsciptionUrl);
        String topic = "";

        try {
            topic = task.get().replace('"', ' ').trim();

            if (!topic.equals("")) {
                Intent intent = new Intent(HomeActivity.this, VolunteerHomeActivity.class);
                startActivity(intent);
            } else {
                Intent intent = new Intent(HomeActivity.this, VolunteerConfirmationActivity.class);
                startActivity(intent);
            }
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void CheckMyPoints()
    {
        Intent intent = new Intent(HomeActivity.this, PointActivity.class);
        startActivity(intent);
    }

    public void KnowWasteSegregation()
    {
        Intent intent = new Intent(HomeActivity.this, KWSActivity.class);
        startActivity(intent);
    }

    public void Complain()
    {
        Intent intent = new Intent(HomeActivity.this, ComplaintActivity.class);
        startActivity(intent);
    }

    public void Suggest()
    {
        Intent intent = new Intent(HomeActivity.this, SuggestionActivity.class);
        startActivity(intent);
    }

    public void ReferFriend()
    {
        RequestTask task = null;
        String referFriendUrl = "http://" + Helper.Server  + "/ManagementService/api/login/rr%7C" + Helper.Key;
        task = (RequestTask) new RequestTask().execute(referFriendUrl);

        String referCode = "";

        try {
            referCode = task.get();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        Intent sendIntent = new Intent();
        sendIntent.setAction(Intent.ACTION_SEND);
        sendIntent.putExtra(Intent.EXTRA_TEXT, "Download ClearTrash and use my Refer Code " + referCode.toString() + " to earn more Liquids!");
        sendIntent.setType("text/plain");
        startActivity(sendIntent);
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
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.home, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.signout) {
            this.finish();
            android.os.Process.killProcess(android.os.Process.myPid());
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.nav_hhg)
        {
            new Thread(new Runnable() {
                public void run() {
            HouseHoldGarbage();
                }
            }).start();
        }
        else if (id == R.id.nav_sg)
        {
            new Thread(new Runnable() {
                public void run() {
                    SpotGarbage();
                }
            }).start();
        }
        else if (id == R.id.nav_vp)
        {
            new Thread(new Runnable() {
                public void run() {
                    RegisterVolunteer();
                }
            }).start();
        }
        else if (id == R.id.nav_kms) {
            new Thread(new Runnable() {
                public void run() {
                    KnowWasteSegregation();
                }
            }).start();
        } else if (id == R.id.nav_mp) {
            new Thread(new Runnable() {
                public void run() {
            CheckMyPoints();
                }
            }).start();
        } else if (id == R.id.nav_pws) {

        }
        else if (id == R.id.nav_rf) {
            ReferFriend();
        }
        else if (id == R.id.nav_signout) {
            this.finish();
            android.os.Process.killProcess(android.os.Process.myPid());
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }
}
