package com.iwms.cleartrash;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;
import java.util.LinkedList;
import java.util.List;

public class ComplaintActivity extends AppCompatActivity {

    private Button b1;
    private EditText ed1, ed2;
    ProgressDialog progressBar;
    private int progressBarStatus = 0;
    private Handler progressBarHandler = new Handler();
    String subject;
    String description;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_complaint);

        b1 = (Button)findViewById(R.id.btnSuggest);
        ed1 = (EditText)findViewById(R.id.editTextSubject);
        ed2 = (EditText)findViewById(R.id.editTextDescription);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // prepare for a progress bar dialog
                progressBar = new ProgressDialog(v.getContext());
                progressBar.setCancelable(true);
                progressBar.setMessage("Please wait while we process your data!");
                progressBar.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBar.setProgress(0);
                progressBar.setMax(100);
                progressBar.show();

                //reset progress bar status
                progressBarStatus = 10;
                subject = ed1.getText().toString();
                description = ed2.getText().toString();

                new Thread(new Runnable() {
                    public void run() {
                        while (progressBarStatus < 100) {
                            upload();
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
                }).start();        }
        });
    }

    private void upload() {
        // Upload image to server
        new uploadToServer().execute();
    }

    public class uploadToServer extends AsyncTask<Void, Void, String> {

        @Override
        protected String doInBackground(Void... params) {
            try {
                String postPartUrl = "http://" + Helper.Server + "/ManagementService/api/suggestion";
                HttpClient httpclient = new DefaultHttpClient();
                HttpPost httpPost = new HttpPost(postPartUrl);

                List<NameValuePair> nameValuePairs = new LinkedList<NameValuePair>();
                nameValuePairs.add(new BasicNameValuePair("SuggestionType","0"));
                nameValuePairs.add(new BasicNameValuePair("Key", Helper.Key));
                nameValuePairs.add(new BasicNameValuePair("Subject",subject));
                nameValuePairs.add(new BasicNameValuePair("Description", description));
                httpPost.setHeader("Content-Type", "application/x-www-form-urlencoded");
                httpPost.setHeader("Accept", "application/json");
                HttpEntity entity = new UrlEncodedFormEntity(nameValuePairs, "UTF-8");
                httpPost.setEntity(entity);

                HttpResponse response = httpclient.execute(httpPost);
                InputStream inputStream = response.getEntity().getContent();

                if(inputStream != null)
                {
                    ByteArrayOutputStream baos = new ByteArrayOutputStream();
                    byte[] data;
                    int reads = inputStream.read();

                    while(reads != -1)
                    {
                        baos.write(reads);
                        reads = inputStream.read();
                    }

                    data = baos.toByteArray();
                    String content = new String(data, "UTF-8");
                    content = content.replace('"',' ').trim();

                    PopupMessage("Complaint registered successfully...Your ref No is " + content);
                }
            }
            catch (UnsupportedEncodingException e)
            {
                e.printStackTrace();
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }

            return "success";
        }
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
}
