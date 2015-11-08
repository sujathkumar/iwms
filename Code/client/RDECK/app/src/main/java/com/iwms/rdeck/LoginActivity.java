package com.iwms.rdeck;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.concurrent.ExecutionException;

public class LoginActivity extends Activity  {
    Button b1,b2;
    EditText ed1,ed2;
    ProgressDialog progressBarSignIn;
    private int progressBarStatusSignIn = 0;
    private Handler progressBarHandlerSignIn = new Handler();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        new Thread(new Runnable() {
            public void run() {
                b1 = (Button) findViewById(R.id.btnLogin);
                b2 = (Button) findViewById(R.id.btnCancel);
                ed1 = (EditText) findViewById(R.id.editText);
                ed2 = (EditText) findViewById(R.id.editText2);

                Helper.Key = ReadFromCache();
                if (!Helper.Key.equals("")) {
                    Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                    startActivity(intent);
                } else {
                    b1.setOnClickListener(new View.OnClickListener() {
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

                            new Thread(new Runnable() {
                                public void run() {
                                    while (progressBarStatusSignIn < 100) {
                                        String authUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/recycler/authenticate%7C" +
                                                ed1.getText().toString() + "%7C" + ed2.getText().toString();
                                        RequestTask task = (RequestTask) new RequestTask().execute(authUrl);

                                        try {
                                            Helper.Key = task.get().replace('"', ' ').trim();
                                            WriteToCache(Helper.Key);
                                        } catch (InterruptedException e) {
                                            // TODO Auto-generated catch block
                                            e.printStackTrace();
                                        } catch (ExecutionException e) {
                                            // TODO Auto-generated catch block
                                            e.printStackTrace();
                                        }

                                        if (!Helper.Key.equals("")) {
                                            Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                                            startActivity(intent);
                                        } else {
                                            Toast.makeText(getApplicationContext(), "Wrong Credentials", Toast.LENGTH_SHORT).show();
                                        }

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

                    b2.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            finish();
                        }
                    });
                }
            }
        }).start();
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
            File tempFile = new File(cDir.getPath() + "/RDECK.txt");
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

    public void WriteToCache(String key)
    {
        try
        {
            /** Getting Cache Directory */
            File cDir = getBaseContext().getCacheDir();
            /** Getting a reference to temporary file, if created earlier */
            File tempFile = new File(cDir.getPath() + "/RDECK.txt");
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

