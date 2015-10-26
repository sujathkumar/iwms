package com.iwms.cleartrash;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.provider.Settings;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.gms.gcm.GcmPubSub;
import com.google.android.gms.iid.InstanceID;

import java.io.IOException;
import java.util.concurrent.ExecutionException;

public class VolunteerWardSelectionActivity extends Activity {

    Button acceptButton;
    Spinner zoneSpinner, wardSpinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_volunteer_ward_selection);

        zoneSpinner = (Spinner) findViewById(R.id.zoneSpinner);
        wardSpinner = (Spinner) findViewById(R.id.wardSpinner);
        acceptButton = (Button)findViewById(R.id.acceptButton);

        String zoneUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/ward/zones";
        RequestTask task = (RequestTask) new RequestTask().execute(zoneUrl);
        String[] zones = null;

        try {
            zones = task.get().replace('"', ' ').trim().split(",");
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        ArrayAdapter<String> zoneAdapter = new ArrayAdapter<String>(this,
                R.layout.spinner_item, zones);
        zoneAdapter.setDropDownViewResource(R.layout.spinner_item);
        zoneSpinner.setAdapter(zoneAdapter);

        zoneSpinner.setOnItemSelectedListener(
                new AdapterView.OnItemSelectedListener() {

                    @Override
                    public void onItemSelected(AdapterView<?> arg0, View arg1,
                                               int arg2, long arg3) {
                        String wardUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/ward/wards%7C" + zoneSpinner.getSelectedItem().toString().replace('"', ' ').trim();
                        RequestTask task = (RequestTask) new RequestTask().execute(wardUrl);
                        String[] wards = null;

                        try {
                            wards = task.get().replace('"', ' ').trim().split(",");
                        } catch (InterruptedException e) {
                            // TODO Auto-generated catch block
                            e.printStackTrace();
                        } catch (ExecutionException e) {
                            // TODO Auto-generated catch block
                            e.printStackTrace();
                        }

                        ArrayAdapter<String> wardAdapter = new ArrayAdapter<String>(getApplicationContext(),
                                R.layout.spinner_item, wards);
                        wardAdapter.setDropDownViewResource(R.layout.spinner_item);
                        wardSpinner.setAdapter(wardAdapter);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> arg0) {
                    }
                }
        );

        acceptButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RegisterVolunteer();
            }
        });
    }

    private void RegisterVolunteer()
    {
        String volunteerUrl = "http://" + Helper.Server  + "/ManagementService/api/volunteer/iv%7C" + Helper.Key + "%7C" +
                wardSpinner.getSelectedItem().toString().replace('"', ' ').trim();
        RequestTask task = (RequestTask) new RequestTask().execute(volunteerUrl);

        String code = "";
        try {
            code = task.get().replace('"', ' ').trim();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        AlertDialog.Builder builder = new AlertDialog.Builder(this, AlertDialog.THEME_HOLO_LIGHT);

        if(code.equals("215")) {
            // Build the alert dialog

            builder.setMessage("Registered Succesfully!");
            builder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogInterface, int i) {

                    try {

                        String volunteerRGCMTokenUrl = "http://" + Helper.Server  + "/ManagementService/api/volunteer/rgcmtoken%7C" + Helper.Key;
                        RequestTask task = (RequestTask) new RequestTask().execute(volunteerRGCMTokenUrl);

                        try {
                            Helper.GCMToken = task.get().replace('"', ' ').trim();
                        }
                        catch (Exception e)
                        {
                            e.printStackTrace();
                        }

                        String topic = zoneSpinner.getSelectedItem().toString().replace('"', ' ').trim() + "-" + wardSpinner.getSelectedItem().toString().replace('"', ' ').trim();
                        subscribeTopics(Helper.GCMToken, topic);
                    }
                    catch (IOException e)
                    {
                        e.printStackTrace();
                    }

                    // Show location settings when the user acknowledges the alert dialog
                    Intent intent = new Intent(VolunteerWardSelectionActivity.this, HomeActivity.class);
                    startActivity(intent);
                }
            });
        }
        else
        {
            // Build the alert dialog
            builder.setMessage("User already registered!");
            builder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                public void onClick(DialogInterface dialogInterface, int i) {
                    // Show location settings when the user acknowledges the alert dialog
                }
            });
        }

        Dialog alertDialog = builder.create();
        alertDialog.setCanceledOnTouchOutside(false);
        alertDialog.show();
    }

    public void subscribeTopics(final String token, final String topic) throws IOException
    {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void... params)
            {
                try
                {
                    GcmPubSub pubSub = GcmPubSub.getInstance(getApplicationContext());
                    pubSub.subscribe(token, "/topics/ClearTrashVolunteers", null);
                    pubSub.subscribe(token, "/topics/" + topic, null);
                }
                catch (final IOException e)
                {
                }

                return null;
            }
        }.execute();
    }
}
