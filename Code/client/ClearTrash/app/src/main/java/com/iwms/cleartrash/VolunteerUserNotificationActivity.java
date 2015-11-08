package com.iwms.cleartrash;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;
import java.util.concurrent.ExecutionException;

public class VolunteerUserNotificationActivity extends Activity {

    private Button btnAccept;
    private Spinner spinnerUsersCount;
    ProgressDialog progressBar;
    private int progressBarStatus = 0;
    private Handler progressBarHandler = new Handler();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_volunteer_user_notification);

        spinnerUsersCount = (Spinner) findViewById(R.id.spinnerUsersCount);
        String[] users = {"1","2","3","4","5"};
        btnAccept = (Button)findViewById(R.id.btnAccept);

        ArrayAdapter<String> adapterDate = new ArrayAdapter<String>
                (this,android.R.layout.select_dialog_item,users);
        adapterDate.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerUsersCount.setAdapter(adapterDate);

        btnAccept.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                // prepare for a progress bar dialog
                progressBar = new ProgressDialog(v.getContext());
                progressBar.setCancelable(true);
                progressBar.setMessage("Please wait while we process the data...");
                progressBar.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBar.setProgress(0);
                progressBar.setMax(100);
                progressBar.show();

                //reset progress bar status
                progressBarStatus = 10;

                new Thread(new Runnable() {
                    public void run() {
                        while (progressBarStatus < 100) {
                            RequestTask task = null;
                            String userCount = spinnerUsersCount.getSelectedItem().toString();
                            String usersCountUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/recycler/su%7C" + Helper.Key +
                                    "%7C" + userCount;
                            task = (RequestTask) new RequestTask().execute(usersCountUrl);
                            String code = "";

                            try {
                                code = task.get().replace('"', ' ').trim();

                                if (code.equals("218")) {
                                    Intent intent = new Intent(VolunteerUserNotificationActivity.this, VolunteerHomeActivity.class);
                                    startActivity(intent);
                                }
                            } catch (InterruptedException e) {
                                // TODO Auto-generated catch block
                                e.printStackTrace();
                            } catch (ExecutionException e) {
                                // TODO Auto-generated catch block
                                e.printStackTrace();
                            }
                            progressBarStatus = 100;

                            progressBarHandler.post(new Runnable() {
                                public void run() {
                                    progressBar.setProgress(progressBarStatus);
                                }
                            });
                        }

                        // ok, file is downloaded,
                        if (progressBarStatus >= 100) {
                            // close the progress bar dialog
                            progressBar.dismiss();
                        }
                    }
                }).start();
            }
        });
    }
}
