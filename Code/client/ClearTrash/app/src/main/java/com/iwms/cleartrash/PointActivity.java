package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

public class PointActivity extends Activity {

    Button redeemButton;
    TextView totalPointTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_point);

        redeemButton = (Button)findViewById(R.id.redeemButton);
        totalPointTextView = (TextView) findViewById(R.id.totalPointTextView);

        String pointUrl = "http://" + Helper.Server  + "/ManagementService/api/point/rp%7C" + Helper.Key;
        RequestTask task = (RequestTask) new RequestTask().execute(pointUrl);

        String points = "";

        try {
            points = task.get();
            totalPointTextView.setText(points.replace('"',' ').trim() + " Points");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        redeemButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(PointActivity.this, PromotionsActivity.class);
                startActivity(intent);
            }
        });
    }
}
