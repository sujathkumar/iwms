package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Chronometer;
import android.widget.CompoundButton;
import android.widget.Switch;
import android.widget.Toast;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.concurrent.ExecutionException;

public class VerificationCodeActivity extends Activity {

    Switch manualSwitchVC;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_verification_code);

        final Chronometer focus = (Chronometer) findViewById(R.id.vcTimer);
        focus.start();
        Bundle bundle = getIntent().getExtras();
        final String userName = bundle.getString("userName");
        final String mobile = bundle.getString("mobile");
        final String type = bundle.getString("type");
        final String vc = bundle.getString("vc");
        final String genKey = bundle.getString("genKey");
        final String refCode = bundle.getString("refCode");

        manualSwitchVC = (Switch) findViewById(R.id.manualSwitchVC);
        manualSwitchVC.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {

            @Override
            public void onCheckedChanged(CompoundButton buttonView,
                                         boolean isChecked) {
                if (isChecked) {
                    focus.stop();
                    Intent intent = new Intent(VerificationCodeActivity.this, ManualVerificationCodeActivity.class);
                    intent.putExtra("userName", userName);
                    intent.putExtra("mobile", mobile);
                    intent.putExtra("vc", vc);
                    intent.putExtra("genKey", genKey);
                    intent.putExtra("type", "signup");
                    intent.putExtra("refCode", refCode);
                    startActivity(intent);
                }
            }
        });

        Thread timerThread = new Thread(){
            public void run()
            {

        boolean flag = false;

        if(type.contains("signup")) {

            Uri mSmsQueryUri = Uri.parse("content://sms/inbox");
            Cursor cursor = null;

            while (!flag) {
                cursor = getContentResolver().query(mSmsQueryUri, null, null, null, null);
                for (boolean hasData = cursor.moveToFirst(); hasData; hasData = cursor.moveToNext())
                {
                    final String sender = cursor.getString(cursor.getColumnIndexOrThrow("address"));
                    if (sender.toLowerCase().contains("iwmsbl"))
                    {
                        final String body = cursor.getString(cursor.getColumnIndexOrThrow("body"));
                        if(body.contains(vc.replace('"',' ').trim()))
                        {
                            flag = true;
                        }
                    }
                }
                cursor.close();
            }

            if (flag) {

                String confirmSignUpUrl = "http://" + Helper.Server  + "/ManagementService/api/login/csp%7C" + userName +
                        "%7C" + mobile + "%7C" + Helper.CityCode + "%7C" + Helper.MACAddress + "%7C" + Helper.GCMToken + "%7C" + refCode;
                RequestTask task = (RequestTask) new RequestTask().execute(confirmSignUpUrl);
                String key = "";

                try {
                    key = task.get();
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }

                //Write to Cache
                WriteToCache(key);
                Helper.Key = key.replace('"',' ').trim();
                Intent intent = new Intent(VerificationCodeActivity.this, HomeActivity.class);
                startActivity(intent);
            } else {
                PopupMessage("Verification failed...");
            }
        }
        else
        {
            Uri mSmsQueryUri = Uri.parse("content://sms/inbox");
            Cursor cursor = null;

            while (!flag) {
                cursor = getContentResolver().query(mSmsQueryUri, null, null, null, null);
                for (boolean hasData = cursor.moveToFirst(); hasData; hasData = cursor.moveToNext()) {
                    final String sender = cursor.getString(cursor.getColumnIndexOrThrow("address"));
                    if (sender.toLowerCase().contains("iwmsbl")) {
                        final String body = cursor.getString(cursor.getColumnIndexOrThrow("body"));
                        if (body.contains(vc.replace('"', ' ').trim())) {
                            flag = true;
                        }
                    }
                }
                cursor.close();
            }

            if (flag) {
                String registerUrl = "http://" + Helper.Server  + "/ManagementService/api/login/registerkey%7Cmobile=" +
                        mobile + "%7Ckey=" + genKey;

                RequestTask task = (RequestTask) new RequestTask().execute(registerUrl);

                try {
                    String statusCode = task.get();

                    if (statusCode.contains("203")) {
                        WriteToCache(genKey);
                        Helper.Key = genKey.replace('"',' ').trim();
                        Intent intent = new Intent(VerificationCodeActivity.this, HomeActivity.class);
                        startActivity(intent);
                    } else {
                        PopupMessage("Authenication failed...");
                    }
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            } else
            {
                PopupMessage("Verification failed...");
            }
        }
            }
        };
        timerThread.start();
    }

    public void PopupMessage(final String message)
    {
        this.runOnUiThread(new Runnable() {
            public void run() {
                Toast.makeText(getApplicationContext(), message, Toast.LENGTH_SHORT).show();
            }
        });
        finish();
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
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.

        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
