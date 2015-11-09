package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.RadioButton;
import android.widget.TextView;

public class HHGDisplayAddressActivity extends AppCompatActivity {

    TextView houseAddressEditText, garbageTagTextView;
    ImageButton editButton;
    RadioButton currentButton, manualButton, wetGarbageButton, dryGarbageButton, wasteGarbageButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hhg_display_address);

        houseAddressEditText = (TextView) findViewById(R.id.houseAddressEditText);
        editButton = (ImageButton)findViewById(R.id.editButton);
        currentButton = (RadioButton)findViewById(R.id.currentButton);
        manualButton = (RadioButton)findViewById(R.id.manualButton);
        garbageTagTextView = (TextView) findViewById(R.id.garbageTagTextView);
        wetGarbageButton = (RadioButton) findViewById(R.id.wetGarbageButton);
        dryGarbageButton = (RadioButton) findViewById(R.id.dryGarbageButton);
        wasteGarbageButton = (RadioButton) findViewById(R.id.wasteGarbageButton);

        currentButton.setChecked(false);
        manualButton.setChecked(false);
        wetGarbageButton.setChecked(false);
        dryGarbageButton.setChecked(false);
        wasteGarbageButton.setChecked(false);

        editButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentButton.setEnabled(true);
                manualButton.setEnabled(true);
            }
        });

        String retrieveAddressUrl = "http://" + Helper.Server  + "/ManagementService/api/household/raddress%7C" + Helper.Key;
        RequestTask task = (RequestTask) new RequestTask().execute(retrieveAddressUrl);
        String address = "";

        try {
            address = task.get();
            StringBuilder sb = new StringBuilder();
            for(int i =0; i< address.split("s_lash").length; i++)
            {
                if(!address.split("s_lash")[i].equals("NA")) {
                    sb.append(address.split("s_lash")[i]);
                    sb.append("\n");
                }
            }

            houseAddressEditText.setText(sb.toString());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        String generatedTagUrl = "http://" + Helper.Server  + "/ManagementService/api/household/rgt%7C" + Helper.Key;
        task = (RequestTask) new RequestTask().execute(generatedTagUrl);

        String generatedTagNumber = "";

        try {
            generatedTagNumber = task.get();
            garbageTagTextView.setText(garbageTagTextView.getText().toString() + generatedTagNumber);

        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        currentButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGDisplayAddressActivity.this, HHGCurrentLocationActivity.class);
                startActivity(intent);
                manualButton.setChecked(false);
            }
        });

        manualButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGDisplayAddressActivity.this, HHGManualLocationActivity.class);;
                startActivity(intent);
                currentButton.setChecked(false);
            }
        });

        wetGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGDisplayAddressActivity.this, WetGarbageActivity.class);
                startActivity(intent);
                dryGarbageButton.setChecked(false);
                wasteGarbageButton.setChecked(false);
            }
        });

        dryGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGDisplayAddressActivity.this, DryGarbageActivity.class);
                startActivity(intent);
                wetGarbageButton.setChecked(false);
                wasteGarbageButton.setChecked(false);
            }
        });

        wasteGarbageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HHGDisplayAddressActivity.this, WasteGarbageActivity.class);
                startActivity(intent);
                wetGarbageButton.setChecked(false);
                dryGarbageButton.setChecked(false);
            }
        });
    }
}
