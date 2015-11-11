package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class OrderDryBagsActivity extends AppCompatActivity {

    Button b1;
    TextView schedulePickupTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_dry_bags);

        final Bundle bundle = getIntent().getExtras();
        final String quantity = bundle.getString("quantity");
        final String donateGarbage = bundle.getString("donateGarbage");
        final String scheduledDateTime = bundle.getString("scheduledDateTime");
        b1 = (Button) findViewById(R.id.acceptButton);
        schedulePickupTextView =(TextView) findViewById(R.id.textView5);

        String schedulePickupUrl = "http://" + Helper.Server  + "/ManagementService/api/collector/sp%7C" + Helper.Key + "%7CDRY"
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

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(OrderDryBagsActivity.this, PromotionsActivity.class);
                startActivity(intent);
            }
        });
    }
}
