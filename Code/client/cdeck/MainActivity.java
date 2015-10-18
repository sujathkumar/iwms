package com.iwms.cdeck;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import java.util.concurrent.ExecutionException;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String authUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/collector/" +
                Helper.Key + "/" + Helper.Mobile;
        RequestTask task = (RequestTask) new RequestTask().execute(authUrl);
        String requests = "";

        try {
            requests = task.get();
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }
}
