package com.iwms.cleartrash;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

public class OrderActivity extends AppCompatActivity {

    Button orderButton;
    TextView wetBagsTextView, dryBagsTextView, pointsTextView;
    EditText redeemEditText;
    Bundle bundle = null;
    String wetOrder = "";
    String dryOrder = "";
    String points = "";
    RequestTask task = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order);

        bundle = getIntent().getExtras();
        wetOrder = bundle.getString("WetOrder");
        dryOrder = bundle.getString("DryOrder");

        orderButton = (Button)findViewById(R.id.btnOrder);
        wetBagsTextView = (TextView)findViewById(R.id.wetBagsTextView);
        dryBagsTextView = (TextView) findViewById(R.id.dryBagsTextView);
        pointsTextView = (TextView) findViewById(R.id.pointsTextView);
        redeemEditText = (EditText) findViewById(R.id.redeemEditText);

        String pointUrl = "http://" + Helper.Server  + "/ManagementService/api/point/rp%7C" + Helper.Key;
        task = (RequestTask) new RequestTask().execute(pointUrl);

        try {
            points = task.get().replace('"',' ').trim();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        wetBagsTextView.setText(wetOrder);
        dryBagsTextView.setText(dryOrder);
        pointsTextView.setText(points + " Points");
        String maxPoints = String.valueOf(Integer.valueOf(wetOrder) * 10 + Integer.valueOf(dryOrder) * 10);

        if(Integer.valueOf(points.replace('"',' ').trim()) < Integer.valueOf(maxPoints))
        {
            if(Integer.valueOf(points.replace('"',' ').trim()).equals("0")) {
                maxPoints = "0";
            }
            else
            {
                maxPoints = points.replace('"',' ').trim();
            }
        }

        redeemEditText.setText(maxPoints);

        orderButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String newOrderUrl = "http://" + Helper.Server + "/ManagementService/api/household/io%7C" + Helper.Key + "%7C" +
                        wetOrder + "%7C" + dryOrder + "%7C" + redeemEditText.getText().toString().replace('"',' ').trim();
                task = (RequestTask) new RequestTask().execute(newOrderUrl);
                String code = "";

                try {
                    code = task.get().replace('"', ' ').trim();
                } catch (Exception e) {
                    e.printStackTrace();
                }

                if (code.equals("219")) {
                    Toast.makeText(getApplicationContext(), "Ordered Successfully...", Toast.LENGTH_SHORT);
                    Intent intent = new Intent(OrderActivity.this, HomeActivity.class);
                    startActivity(intent);
                }
            }
        });
    }
}
