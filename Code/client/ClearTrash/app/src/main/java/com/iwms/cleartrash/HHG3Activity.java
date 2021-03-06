package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class HHG3Activity extends Activity {

    Button b1,b2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hhg3);

        b1 = (Button)findViewById(R.id.acceptButton);
        b2 = (Button)findViewById(R.id.rejectButton);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String acceptBinUrl = "http://" + Helper.Server  + "/ManagementService/api/household/ib%7C" + Helper.Key + "%7C1";
                RequestTask task = (RequestTask) new RequestTask().execute(acceptBinUrl);

                String statusCode = "";

                try {
                    statusCode = task.get();
                    if (statusCode.contains("210")) {
                        Intent intent = new Intent(HHG3Activity.this, HHG4Activity.class);
                        startActivity(intent);
                    }
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
            }
        });

        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String rejectBinUrl = "http://" + Helper.Server  + "/ManagementService/api/household/ib%7C" + Helper.Key + "%7C2";
                RequestTask task = (RequestTask) new RequestTask().execute(rejectBinUrl);

                String statusCode = "";

                try {
                    statusCode = task.get();
                    if (statusCode.contains("210")) {
                        Intent intent = new Intent(HHG3Activity.this, HomeActivity.class);
                        startActivity(intent);
                    }
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                }
            }
        });
    }
}
