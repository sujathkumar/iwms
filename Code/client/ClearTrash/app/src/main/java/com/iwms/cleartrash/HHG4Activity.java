package com.iwms.cleartrash;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import org.w3c.dom.Text;

public class HHG4Activity extends AppCompatActivity {

    TextView garbageIdTextView;
    Button b1,b2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hhg4);

        b1 = (Button)findViewById(R.id.knowSegregationButton);
        b2 = (Button)findViewById(R.id.requestGarbagePickupButton);
        garbageIdTextView = (TextView) findViewById(R.id.garbageIdTextView);

        String generatedTagUrl = "http://" + Helper.Server  + "/ManagementService/api/household/rgt%7C" + Helper.Key;
        RequestTask task = (RequestTask) new RequestTask().execute(generatedTagUrl);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            }
        });

        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHG4Activity.this, HHG6Activity.class);
                startActivity(intent);
            }
        });

        String generatedTagNumber = "";

        try {
            generatedTagNumber = task.get();
            garbageIdTextView.setText(generatedTagNumber);

        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
