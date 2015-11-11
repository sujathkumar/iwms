package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.renderscript.Int2;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class PromotionsActivity extends AppCompatActivity {

    Button b1, b2, orderButton;
    EditText wetEditText, dryEditText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_promotions);

        b1 = (Button) findViewById(R.id.wetRedeemButton);
        b2 = (Button) findViewById(R.id.dryRedeemButton);
        orderButton = (Button) findViewById(R.id.orderButton);
        wetEditText = (EditText) findViewById((R.id.wetEditText));
        dryEditText = (EditText) findViewById((R.id.dryEditText));

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int count = 1;
                String wetCount = wetEditText.getText().toString();

                if(!wetCount.equals(""))
                {
                    wetEditText.setText(String.valueOf(Integer.valueOf(wetCount) + count));
                }
                else
                {
                    wetEditText.setText(String.valueOf(count));
                }
            }
        });

        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int count = 1;
                String dryCount = dryEditText.getText().toString();

                if(!dryCount.equals(""))
                {
                    dryEditText.setText(String.valueOf(Integer.valueOf(dryCount) + count));
                }
                else
                {
                    dryEditText.setText(String.valueOf(count));
                }
            }
        });

        orderButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String wetOrder = wetEditText.getText().toString();
                String dryOrder = dryEditText.getText().toString();
                Intent intent = new Intent(PromotionsActivity.this, OrderActivity.class);
                intent.putExtra("WetOrder", wetOrder);
                intent.putExtra("DryOrder", dryOrder);
                startActivity(intent);
            }
        });
    }
}
