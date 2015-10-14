package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.gcm.GoogleCloudMessaging;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.concurrent.ExecutionException;

public class ManualVerificationCodeActivity extends Activity {

    TextView vcText;
    Button vcButton;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_manual_verification_code);

        vcText = (TextView) findViewById(R.id.textView);
        vcButton = (Button) findViewById(R.id.button);
        final Bundle bundle = getIntent().getExtras();
        final String type = bundle.getString("type");
        final String refCode = bundle.getString("refCode");

        vcButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (type.contains("signup")) {
                    String userName = bundle.getString("userName");
                    String mobile = bundle.getString("mobile");
                    String vc = bundle.getString("vc");

                    if (vcText.getText().toString().contains(vc.replace('"',' ').trim())) {
                        String confirmSignUpUrl = "http://" + Helper.Server  + "/ManagementService/api/login/csp%7C" + userName +
                                "%7C" + mobile + "%7C" + Helper.CityCode +"%7C" + Helper.MACAddress + "%7C" + Helper.GCMToken + "%7C" + refCode;
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
                        Intent intent = new Intent(ManualVerificationCodeActivity.this, HomeActivity.class);
                        startActivity(intent);
                    }
                    else
                    {
                        Toast.makeText(getApplicationContext(), "Verification failed...", Toast.LENGTH_SHORT).show();
                        finish();
                    }
                } else {
                    String mobile = bundle.getString("mobile");
                    String genKey = bundle.getString("genKey");
                    String vc = bundle.getString("vc");

                    if (vcText.getText().toString().contains(vc.replace('"',' ').trim())) {
                        String registerUrl = "http://" + Helper.Server  + "/ManagementService/api/login/registerkey%7Cmobile=" +
                                mobile + "%7Ckey=" + genKey;

                        RequestTask task = (RequestTask) new RequestTask().execute(registerUrl);

                        try {
                            String statusCode = task.get();

                            if (statusCode.contains("203")) {
                                WriteToCache(genKey);
                                Helper.Key = genKey.replace('"',' ').trim();
                                Intent intent = new Intent(ManualVerificationCodeActivity.this, HomeActivity.class);
                                startActivity(intent);
                            } else {
                                Toast.makeText(getApplicationContext(), "Authentication failed...", Toast.LENGTH_SHORT).show();
                            }
                        } catch (InterruptedException e) {
                            // TODO Auto-generated catch block
                            e.printStackTrace();
                        } catch (ExecutionException e) {
                            // TODO Auto-generated catch block
                            e.printStackTrace();
                        }
                    }
                    else
                    {
                        Toast.makeText(getApplicationContext(), "Verification failed...", Toast.LENGTH_SHORT).show();
                        finish();
                    }
                }
            }
        });
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
}
