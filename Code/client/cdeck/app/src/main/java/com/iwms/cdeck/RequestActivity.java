package com.iwms.cdeck;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import java.util.concurrent.ExecutionException;

public class RequestActivity extends AppCompatActivity {

    TextView requestText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request);

        final Bundle bundle = getIntent().getExtras();
        final String requestNumber = bundle.getString("requestNumber");

        requestText = (TextView) findViewById(R.id.requestText);

        String[] request = null;
        String collectorRequestUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/collector/rr%7C"  + requestNumber;
        RequestTask task = (RequestTask) new RequestTask().execute(collectorRequestUrl);

        try
        {
            request = task.get().replace('"',' ').trim().split("s_pace");
        }
        catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        StringBuilder sb = new StringBuilder();
        for(int i=0; i< request.length; i++)
        {
            sb.append(request[i].toString());
            sb.append("\n");
            sb.append("\n");
        }

        requestText.setText(sb.toString());
    }
}
