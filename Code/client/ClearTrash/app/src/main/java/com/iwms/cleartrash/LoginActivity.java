package com.iwms.cleartrash;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.AsyncTask;
import android.os.Bundle;

import android.os.Handler;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.gms.gcm.GcmPubSub;
import com.google.android.gms.gcm.GoogleCloudMessaging;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;

public class LoginActivity extends Activity  {

    Button b1,b2,b3;
    EditText ed1,ed2, refCode;
    Spinner citySpinner;
    ProgressDialog progressBarSignUp;
    private int progressBarStatusSignUp = 0;
    private Handler progressBarHandlerSignUp = new Handler();
    ProgressDialog progressBarSignIn;
    private int progressBarStatusSignIn = 0;
    private Handler progressBarHandlerSignIn = new Handler();
    private InstanceIdHelper mInstanceIdHelper;
    List<String> nameList;
    List<String> codeList;
    List<String> serverList;
    List<String> gcmSenderIdList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        ed1 = (EditText)findViewById(R.id.userNameEditText);
        ed2 = (EditText)findViewById(R.id.mobileNumberEditText);
        b1 = (Button)findViewById(R.id.signupButton);
        b2 = (Button)findViewById(R.id.signinButton);
        citySpinner = (Spinner) findViewById(R.id.citySpinner);
        refCode = (EditText)findViewById(R.id.refferalCodeEditText);

        LoadLocations();

        try {
            Thread.sleep(1000);
        }
        catch (InterruptedException e)
        {
            e.printStackTrace();
        }

        mInstanceIdHelper = new InstanceIdHelper(this);
        mInstanceIdHelper.getTokenInBackground(Helper.GCMSenderId, GoogleCloudMessaging.INSTANCE_ID_SCOPE, null);

        try {
            WifiManager wifiManager = (WifiManager) getSystemService(Context.WIFI_SERVICE);
            WifiInfo wInfo = wifiManager.getConnectionInfo();
            Helper.MACAddress = wInfo.getMacAddress().replace(":", "-").replace(' ','_').trim();
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
    }

    public void LoadLocations()
    {
        nameList = new ArrayList<String>();
        codeList = new ArrayList<String>();
        serverList = new ArrayList<String>();
        gcmSenderIdList = new ArrayList<String>();

        String locationsUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/location";
        RequestTask task = (RequestTask) new RequestTask().execute(locationsUrl);
        String locations = "";

        try
        {
            locations = task.get();
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

        for (int i = 0; i < locations.split(",").length; i++)
        {
            String loc = locations.split(",")[i];
            if(loc.contains("Name"))            {
                nameList.add(loc.split(":")[1].replace('"',' ').replace('}', ' ').replace(']', ' ').trim());
            }else if (loc.contains("Code")) {
                codeList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').replace(']',' ').trim());
            } else if (loc.contains("Server")) {
                serverList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').replace(']',' ').trim());
            }
            else if (loc.contains("GCMSenderId")) {
                gcmSenderIdList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').replace(']',' ').trim());
            }
        }

        Helper.GCMSenderId = gcmSenderIdList.get(0).trim();

        ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this,
                android.R.layout.simple_spinner_item, nameList);
        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        citySpinner.setAdapter(dataAdapter);

        citySpinner.setOnItemSelectedListener(
                new AdapterView.OnItemSelectedListener() {

                    @Override
                    public void onItemSelected(AdapterView<?> arg0, View arg1,
                                               int arg2, long arg3) {

                        int position = citySpinner.getSelectedItemPosition();
                        Helper.CityCode = codeList.get(position);
                        Helper.Server = serverList.get(position);
                        Helper.GCMSenderId = gcmSenderIdList.get(position).trim();
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> arg0) {
                    }
                }
        );

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                // prepare for a progress bar dialog
                progressBarSignUp = new ProgressDialog(v.getContext());
                progressBarSignUp.setCancelable(true);
                progressBarSignUp.setMessage("Signing up...");
                progressBarSignUp.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBarSignUp.setProgress(0);
                progressBarSignUp.setMax(100);
                progressBarSignUp.show();

                //reset progress bar status
                progressBarStatusSignUp = 10;

                new Thread(new Runnable() {
                    public void run() {
                        while (progressBarStatusSignUp < 100) {

                            // process some tasks
                            SignUpUser();
                            progressBarStatusSignUp = 100;

                            // Update the progress bar
                            progressBarHandlerSignUp.post(new Runnable() {
                                public void run() {
                                    progressBarSignUp.setProgress(progressBarStatusSignUp);
                                }
                            });
                        }

                        // ok, file is downloaded,
                        if (progressBarStatusSignUp >= 100) {
                            // close the progress bar dialog
                            progressBarSignUp.dismiss();
                        }
                    }
                }).start();
            }
        });

        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // prepare for a progress bar dialog
                progressBarSignIn = new ProgressDialog(v.getContext());
                progressBarSignIn.setCancelable(true);
                progressBarSignIn.setMessage("Signing in...");
                progressBarSignIn.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBarSignIn.setProgress(0);
                progressBarSignIn.setMax(100);
                progressBarSignIn.show();

                //reset progress bar status
                progressBarStatusSignIn = 10;

                new Thread(new Runnable() {
                    public void run() {
                        while (progressBarStatusSignIn < 100) {

                            // process some tasks
                            SignInUser();
                            progressBarStatusSignIn = 100;

                            // Update the progress bar
                            progressBarHandlerSignIn.post(new Runnable() {
                                public void run() {
                                    progressBarSignIn.setProgress(progressBarStatusSignIn);
                                }
                            });
                        }

                        // ok, file is downloaded,
                        if (progressBarStatusSignIn >= 100) {
                            // close the progress bar dialog
                            progressBarSignIn.dismiss();
                        }
                    }
                }).start();
            }
        });
    }

    public void SignUpUser()
    {
        String userName = ed1.getText().toString();
        String mobile = ed2.getText().toString();
        String referralCode = refCode.getText().toString();
        String signUnUrl = "http://" + Helper.Server  + "/ManagementService/api/login/signup%7Cname=" + userName + "%7Cmobile=" + mobile + "%7Ccitycode=" + Helper.CityCode;
        RequestTask task = (RequestTask) new RequestTask().execute(signUnUrl);
        String vc = "";

        try
        {
            vc = task.get();

            if(vc.replace('"',' ').trim().length() == 3)
            {
                if(vc.contains("102"))
                {
                    this.runOnUiThread(new Runnable() {
                        public void run() {
                            Toast.makeText(getApplicationContext(), "User already registered, Please Signin!", Toast.LENGTH_SHORT).show();
                        }
                    });
                    return;
                }
            }
            else
            {
                Intent intent = new Intent(LoginActivity.this, VerificationCodeActivity.class);
                intent.putExtra("userName", userName);
                intent.putExtra("mobile", mobile);
                intent.putExtra("vc", vc);
                intent.putExtra("genKey","");
                intent.putExtra("type", "signup");
                intent.putExtra("refCode", referralCode);
                startActivity(intent);
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

    public void SignInUser()
    {
        String userName = ed1.getText().toString();
        String mobile = ed2.getText().toString();
        String signInUrl = "http://" + Helper.Server  + "/ManagementService/api/login/si%7C" + userName + "%7C" + mobile + "%7C" + Helper.CityCode + "%7C" + Helper.GCMToken;
        RequestTask task = (RequestTask) new RequestTask().execute(signInUrl);
        String statusCode = "";

        try
        {
            statusCode = task.get();
             if(statusCode.contains("202"))
             {
                 String genKey =  Helper.CityCode + userName + mobile + Helper.MACAddress;
                 String volunteerSubsciptionUrl = "http://" + Helper.Server  + "/ManagementService/api/volunteer/rvs%7C" + genKey;
                 task = (RequestTask) new RequestTask().execute(volunteerSubsciptionUrl);
                 String topic = "";

                 try
                 {
                     topic = task.get();

                     try {
                         if(!topic.equals("")) {
                             subscribeTopics(Helper.GCMToken, topic);
                         }
                     }
                     catch (IOException e)
                     {
                         e.printStackTrace();
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

                 String confirmSignIpUrl = "http://" + Helper.Server  + "/ManagementService/api/login/confirmsignin%7Cmobile=" + mobile + "%7Ckey=" + genKey;
                 task = (RequestTask) new RequestTask().execute(confirmSignIpUrl);

                 String vc = "";
                 boolean flag = false;

                 try
                 {
                     vc = task.get();
                     if(vc.replace('"',' ').trim().length() == 3)
                     {
                         if(vc.contains("201"))
                         {
                             WriteToCache(genKey);
                             Helper.Key = genKey.replace('"',' ').trim();
                             Intent intent = new Intent(LoginActivity.this, HomeActivity.class);
                             startActivity(intent);
                         }
                     }
                     else
                     {
                         Intent intent = new Intent(LoginActivity.this, VerificationCodeActivity.class);
                         intent.putExtra("userName", userName);
                         intent.putExtra("mobile", mobile);
                         intent.putExtra("vc", vc);
                         intent.putExtra("genKey", genKey);
                         intent.putExtra("type", "signin");
                         startActivity(intent);
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
             else if(statusCode.contains("103"))
             {
                 this.runOnUiThread(new Runnable() {
                     public void run() {
                         Toast.makeText(getApplicationContext(), "User not registered, Please Signup!", Toast.LENGTH_SHORT).show();
                     }
                 });
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

    public void WriteToCache(String key)
    {
        try
        {
            /** Getting Cache Directory */
            File cDir = getBaseContext().getCacheDir();
            /** Getting a reference to temporary file, if created earlier */
            File tempFile = new File(cDir.getPath() + "/ClearTrash.txt");
            FileWriter writer = new FileWriter(tempFile);
            /** Saving the contents to the file*/
            writer.write(key);
            /** Closing the writer object */
            writer.close();
        }
        catch (IOException e)
        {
            e.printStackTrace();
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
}