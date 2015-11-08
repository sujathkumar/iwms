package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import org.w3c.dom.Text;

public class OrderWasteBagsActivity extends AppCompatActivity {

    TextView schedulePickupTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_waste_bags);

        final Bundle bundle = getIntent().getExtras();
        final String quantity = bundle.getString("quantity");
        final String donateGarbage = bundle.getString("donateGarbage");
        final String scheduledDateTime = bundle.getString("scheduledDateTime");
        schedulePickupTextView =(TextView) findViewById(R.id.textView5);

        String schedulePickupUrl = "http://" + Helper.Server  + "/ManagementService/api/collector/sp%7C" + Helper.Key + "%7CE-Waste"
                + "%7C" + quantity + "%7C" + donateGarbage + "%7C" + scheduledDateTime;
        RequestTask task = (RequestTask) new RequestTask().execute(schedulePickupUrl);

        String pickupTime = "";

        try {
            pickupTime = task.get();
            schedulePickupTextView.setText(schedulePickupTextView.getText().toString() + pickupTime.toString());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
