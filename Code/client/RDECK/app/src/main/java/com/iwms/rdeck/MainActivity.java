package com.iwms.rdeck;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.concurrent.ExecutionException;

public class MainActivity extends Activity {

    static final String ACTION_SCAN = "com.google.zxing.client.android.SCAN";
    String data;
    ListView listViewGarbage;
    Button uploadButton;
    ProgressDialog progressBar;
    private int progressBarStatus = 0;
    private Handler progressBarHandler = new Handler();

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //set the main content layout of the Activity
        setContentView(R.layout.activity_main);

        // Get ListView object from xml
        listViewGarbage = (ListView) findViewById(R.id.listviewGarbage);
        uploadButton = (Button) findViewById(R.id.up);

        uploadButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // prepare for a progress bar dialog
                progressBar = new ProgressDialog(v.getContext());
                progressBar.setCancelable(true);
                progressBar.setMessage("Uploading...");
                progressBar.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBar.setProgress(0);
                progressBar.setMax(100);
                progressBar.show();

                new Thread(new Runnable() {
                    public void run() {
                        while (progressBarStatus < 100) {
                String recyclerScanUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/recycler/si%7C" +
                        Helper.Key + "%7C" + data.replace("null","");
                RequestTask task = (RequestTask) new RequestTask().execute(recyclerScanUrl);

                try {
                    task.get();
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }

                progressBarStatus = 100;

                // Update the progress bar
                progressBarHandler.post(new Runnable() {
                                public void run() {
                                    progressBar.setProgress(progressBarStatus);
                                }
                            });
                }

                if (progressBarStatus >= 100) {
                    progressBar.dismiss();
                }
                    }
                }).start();

                Toast.makeText(getApplicationContext(), "Uploaded successfully...", Toast.LENGTH_SHORT).show();
            }
        });

        ReadQRCode();
    }

    private void ReadQRCode()
    {
        try
        {
            //start the scanning activity from the com.google.zxing.client.android.SCAN intent
            Intent intent = new Intent(ACTION_SCAN);
            intent.putExtra("SCAN_MODE", "QR_CODE_MODE");
            startActivityForResult(intent, 0);
        } catch (ActivityNotFoundException anfe) {
            //on catch, show the download dialog
            showDialog(MainActivity.this, "No Scanner Found", "Download a scanner code activity?", "Yes", "No").show();
        }
    }

    //alert dialog for downloadDialog
    private static AlertDialog showDialog(final Activity act, CharSequence title, CharSequence message, CharSequence buttonYes, CharSequence buttonNo) {
        AlertDialog.Builder downloadDialog = new AlertDialog.Builder(act);
        downloadDialog.setTitle(title);
        downloadDialog.setMessage(message);
        downloadDialog.setPositiveButton(buttonYes, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogInterface, int i) {
                Uri uri = Uri.parse("market://search?q=pname:" + "com.google.zxing.client.android");
                Intent intent = new Intent(Intent.ACTION_VIEW, uri);
                try {
                    act.startActivity(intent);
                } catch (ActivityNotFoundException anfe) {

                }
            }
        });
        downloadDialog.setNegativeButton(buttonNo, new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialogInterface, int i) {
            }
        });
        return downloadDialog.show();
    }

    //on ActivityResult method
    public void onActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == 0) {
            if (resultCode == RESULT_OK)
            {
                //get the extras that are returned from the intent
                data = data + intent.getStringExtra("SCAN_RESULT") + ",";
                String[] garbages = data.replace("null","").split(",");

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
                        android.R.layout.simple_list_item_1, android.R.id.text1, garbages);

                // Assign adapter to ListView
                listViewGarbage.setAdapter(adapter);

                Thread timerThread = new Thread(){
                    public void run()
                    {
                        ReadQRCode();
                    }
                };
                timerThread.start();
            }
        }
    }
}