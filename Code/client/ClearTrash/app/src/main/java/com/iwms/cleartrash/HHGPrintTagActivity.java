package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class HHGPrintTagActivity extends Activity {

    TextView garbageIdTextView;
    Button b1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hhg_print_tag);

        b1 = (Button)findViewById(R.id.schedulePickupButton);
        garbageIdTextView = (TextView) findViewById(R.id.garbageIdTextView);

        String generatedTagUrl = "http://" + Helper.Server  + "/ManagementService/api/household/rgt%7C" + Helper.Key;
        RequestTask task = (RequestTask) new RequestTask().execute(generatedTagUrl);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGPrintTagActivity.this, HHGDisplayAddressActivity.class);
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
