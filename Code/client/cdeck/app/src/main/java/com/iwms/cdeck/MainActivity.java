package com.iwms.cdeck;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.concurrent.ExecutionException;

public class MainActivity extends Activity {

    ListView listView ;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Get ListView object from xml
        listView = (ListView) findViewById(R.id.listview);

        String[] requests = null;
        String collectorRequestUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/collector/" +
                Helper.Key + "/" + Helper.Mobile;
        RequestTask task = (RequestTask) new RequestTask().execute(collectorRequestUrl);

        try {
            requests = task.get().replace("[","").replace("]","").replace('"',' ').trim().split(",");
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
                android.R.layout.simple_list_item_1, android.R.id.text1, requests);

        // Assign adapter to ListView
        listView.setAdapter(adapter);

        // ListView Item Click Listener
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                int itemPosition = position;
                String requestNumber = (String) listView.getItemAtPosition(position);
                Intent intent = new Intent(MainActivity.this, RequestActivity.class);
                intent.putExtra("requestNumber", requestNumber.trim().substring(0,1));
                startActivity(intent);
            }
        });
    }
}