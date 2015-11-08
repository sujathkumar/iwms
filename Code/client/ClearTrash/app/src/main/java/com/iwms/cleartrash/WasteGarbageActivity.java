package com.iwms.cleartrash;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.test.ActivityUnitTestCase;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

public class WasteGarbageActivity extends AppCompatActivity {

    private Button b1;
    private Calendar calendar;
    private Spinner dateView;
    private Spinner timeView;
    EditText quantityText;
    CheckBox donateGarbageCheckBox;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_waste_garbage);

        b1 = (Button)findViewById(R.id.schedulePickupButton);
        dateView = (Spinner) findViewById(R.id.dateEditText);
        timeView = (Spinner) findViewById(R.id.timeEditText);
        quantityText = (EditText) findViewById(R.id.quantityText);
        donateGarbageCheckBox = (CheckBox) findViewById(R.id.donateCheckBox);

        String collectorDatesUrl = "http://" + Helper.Server  + "/ManagementService/api/collector/rcd%7C" + Helper.Key;
        RequestTask task = (RequestTask) new RequestTask().execute(collectorDatesUrl);

        String collectorDates = "";
        String[] Dates = null;

        try {
            collectorDates = task.get();
            Dates = collectorDates.replace('"',' ').trim().split(",");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        String collectorTimesUrl = "http://" + Helper.Server  + "/ManagementService/api/collector/rct%7C" + Helper.Key;
        task = (RequestTask) new RequestTask().execute(collectorTimesUrl);

        String collectorTimes = "";
        String[] Times = null;

        try {
            collectorTimes = task.get();
            Times = collectorTimes.replace('"',' ').trim().split(",");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        ArrayAdapter<String> adapterDate = new ArrayAdapter<String>
                (this,android.R.layout.select_dialog_item,Dates);
        adapterDate.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        dateView.setAdapter(adapterDate);


        ArrayAdapter<String> adapterTime = new ArrayAdapter<String>
                (this,android.R.layout.select_dialog_item,Times);
        adapterTime.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        timeView.setAdapter(adapterTime);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                try {
                    String quantity = quantityText.getText().toString();
                    String donateGarbage = "false";

                    if (donateGarbageCheckBox.isChecked()) {
                        donateGarbage = "true";
                    }

                    String scheduledDate = "";
                    DateFormat format = new SimpleDateFormat("dd-MMM-yyyy", Locale.ENGLISH);
                    Date date = format.parse(dateView.getSelectedItem().toString());
                    Calendar cal = Calendar.getInstance();
                    cal.setTime(date);
                    int year = cal.get(Calendar.YEAR);
                    int month = cal.get(Calendar.MONTH) + 1;
                    int day = cal.get(Calendar.DAY_OF_MONTH);

                    scheduledDate = String.valueOf(year) + "_" +
                            String.valueOf(month) + "_" +
                            String.valueOf(day);

                    String scheduledTime = timeView.getSelectedItem().toString() + "_0";

                    String scheduledDateTime = scheduledDate + "_" + scheduledTime;

                    Intent intent = new Intent(WasteGarbageActivity.this, OrderWasteBagsActivity.class);
                    intent.putExtra("quantity", quantity);
                    intent.putExtra("donateGarbage", donateGarbage);
                    intent.putExtra("scheduledDateTime",scheduledDateTime);
                    startActivity(intent);
                }
                catch (ParseException e)
                {
                    e.printStackTrace();
                }
            }
        });
    }
}
