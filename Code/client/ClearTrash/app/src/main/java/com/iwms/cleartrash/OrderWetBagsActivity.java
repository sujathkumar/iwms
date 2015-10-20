package com.iwms.cleartrash;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class OrderWetBagsActivity extends AppCompatActivity {

    TextView schedulePickupTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_wet_bags);

        final Bundle bundle = getIntent().getExtras();
        final String quantity = bundle.getString("quantity");
        final String donateGarbage = bundle.getString("donateGarbage");
        schedulePickupTextView =(TextView) findViewById(R.id.schedulePickupTextView);

        String schedulePickupUrl = "http://" + Helper.Server  + "/ManagementService/api/collector/sp%7C" + Helper.Key + "%7CWET"
                + "%7C" + quantity + "%7C" + donateGarbage;
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
