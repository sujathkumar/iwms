package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.media.Image;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;

public class WetGarbageActivity extends Activity {

    Button b1;
    EditText quantityText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_wet_garbage);

        b1 = (Button)findViewById(R.id.schedulePickupButton);

        quantityText = (EditText) findViewById(R.id.quantityText);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String quantity = quantityText.getText().toString();
                String donateGarbage = "false";
                Intent intent = new Intent(WetGarbageActivity.this, OrderWetBagsActivity.class);
                intent.putExtra("quantity", quantity);
                intent.putExtra("donateGarbage", donateGarbage);
                startActivity(intent);
            }
        });
    }
}
