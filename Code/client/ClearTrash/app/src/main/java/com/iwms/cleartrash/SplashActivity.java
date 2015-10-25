package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;

public class SplashActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        // TODO Auto-generated method stub
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash);

        Thread timerThread = new Thread(){
                public void run()
                {
                try {
                    sleep(3000);
                    //Read key from Cache
                    String key = ReadFromCache();
                    //Load Locations
                    LoadLocations(key);
                    //Verify key with Server
                    String statusCode = VerifyKey(key);
                    Intent intent = null;
                    if (statusCode.contains("201")) {
                        Helper.Key = key.replace('"',' ').trim();
                        intent = new Intent(SplashActivity.this, HomeActivity.class);
                    } else {
                        intent = new Intent(SplashActivity.this, LoginActivity.class);
                    }
                    startActivity(intent);
                }
                catch (InterruptedException e)
                {
                    e.printStackTrace();
                }
            }
        };
        timerThread.start();
    }

    public void LoadLocations(String key) {

        if(key.trim() != "") {
            List<String> codeList = new ArrayList<String>();
            List<String> serverList = new ArrayList<String>();
            List<String> gcmSenderIdList = new ArrayList<String>();

            String locationsUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/location";
            RequestTask task = (RequestTask) new RequestTask().execute(locationsUrl);
            String locations = "";

            try {
                locations = task.get();
            } catch (InterruptedException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            } catch (ExecutionException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }

            for (int i = 0; i < locations.split(",").length; i++) {
                String loc = locations.split(",")[i];
                if (loc.contains("Code")) {
                    codeList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').replace(']',' ').trim());
                } else if (loc.contains("Server")) {
                    serverList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').trim());
                }
                if (loc.contains("GCMSenderId")) {
                    gcmSenderIdList.add(loc.split(":")[1].replace('"', ' ').replace('}', ' ').replace(']',' ').trim());
                }
            }

            Helper.CityCode = key.substring(0, 2);
            int position = codeList.indexOf(Helper.CityCode);
            Helper.Server = serverList.get(position);
            Helper.GCMSenderId = gcmSenderIdList.get(position).trim();
        }
    }

    public String VerifyKey(String key)
    {
        String authenicateUrl = "http://" + Helper.Server + "/ManagementService/api/login/authenticate%7Ckey=" + key;
        RequestTask task = (RequestTask) new RequestTask().execute(authenicateUrl);
        String statusCode = "";

        try
        {
            statusCode = task.get();
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

        return statusCode;
    }

    public String ReadFromCache()
    {
        try
        {
            String strLine="";
            StringBuilder key = new StringBuilder();

            /** Getting Cache Directory */
            File cDir = getBaseContext().getCacheDir();
            /** Getting a reference to temporary file, if created earlier */
            File tempFile = new File(cDir.getPath() + "/ClearTrash.txt");
            FileReader fReader = new FileReader(tempFile);
            BufferedReader bReader = new BufferedReader(fReader);

            /** Reading the contents of the file , line by line */
            while( (strLine=bReader.readLine()) != null  ) {
                key.append(strLine.replace('"',' ').trim());
            }

            return key.toString();
        }
        catch (IOException e)
        {
            e.printStackTrace();
            return "";
        }
    }

    @Override
    protected void onPause() {
        // TODO Auto-generated method stub
        super.onPause();
        finish();
    }
}
