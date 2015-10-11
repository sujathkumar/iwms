package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import android.content.Context;
import android.location.Address;
import android.location.Geocoder;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.concurrent.ExecutionException;

public class HHG1Activity extends Activity {

    LocationManager locationManager;
    double longitude;
    double latitude;
    String ward;
    EditText wardText, houseNoText, houseNameText, aptNameText, streetText, localityText, cityText, pincodeText;
    Button saveButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_hhg1);

        wardText = (EditText)findViewById(R.id.wardEditText);

        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        Location location = locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);
        latitude = location.getLatitude();
        longitude = location.getLongitude();

        String latStr = String.valueOf(latitude).replace('.','_').substring(0,8);
        final String longStr = String.valueOf(longitude).replace('.','_').substring(0,8);

        GetAddressFromLocation(latitude, longitude, getApplicationContext(), new GeocoderHandler());

        String wardUrl = "http://" + Helper.Server  + "/ManagementService/api/ward/" + latStr + "/" + longStr;
        RequestTask task = (RequestTask) new RequestTask().execute(wardUrl);

        saveButton = (Button)findViewById(R.id.saveButton);

        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                houseNoText = (EditText) findViewById(R.id.houseNoEditText);
                houseNameText = (EditText) findViewById(R.id.houseNameEditText);
                aptNameText = (EditText) findViewById(R.id.aptNameEditText);
                streetText = (EditText) findViewById(R.id.streetEditText);
                localityText = (EditText) findViewById(R.id.localityEditText);
                cityText = (EditText) findViewById(R.id.cityEditText);
                pincodeText = (EditText) findViewById(R.id.pincodeEditText);

                String hn = houseNameText.getText().toString();
                if (hn.equals("")) {
                    hn = "NA";
                }

                String an = aptNameText.getText().toString();
                if (an.equals("")) {
                    an = "NA";
                }

                String address = houseNoText.getText().toString() + "___" +
                        hn + "___" +
                        an + "___" +
                        streetText.getText().toString() + "___" +
                        localityText.getText().toString() + "___" +
                        wardText.getText().toString() + "___" +
                        "true___" +
                        pincodeText.getText().toString();

                address = address.replace(" ", "s_pace").replace(",","c_omma");

                String saveAddressUrl = "http://" + Helper.Server + "/ManagementService/api/household/ia%7C" + Helper.Key + "%7C" + address;
                RequestTask taskSave = (RequestTask) new RequestTask().execute(saveAddressUrl);

                try {
                    String statusCode = taskSave.get();
                    if (statusCode.contains("209")) {

                        Toast.makeText(getApplicationContext(), "Address updated successfully...", Toast.LENGTH_SHORT).show();

                        Intent intent = new Intent(HHG1Activity.this, HHG3Activity.class);
                        startActivity(intent);
                    }
                    else
                    {
                        Toast.makeText(getApplicationContext(), "Error while saving...", Toast.LENGTH_SHORT).show();
                    }
                } catch (InterruptedException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                } catch (ExecutionException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        });

        try
        {
            ward = task.get();
            wardText.setText(ward.replace('"',' ').trim());
        }
        catch (InterruptedException e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        catch (ExecutionException e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public static void GetAddressFromLocation(final double latitude, final double longitude, final Context context, final Handler handler) {
        Thread thread = new Thread() {
            @Override
            public void run() {
                Geocoder geocoder = new Geocoder(context, Locale.getDefault());
                String result = null;
                try {
                    List<Address> addressList = geocoder.getFromLocation(latitude, longitude, 1);
                    if (addressList != null && addressList.size() > 0) {
                        Address address = addressList.get(0);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < address.getMaxAddressLineIndex(); i++) {
                            sb.append(address.getAddressLine(i)).append("\n");
                        }
                        sb.append(address.getLocality()).append("\n");
                        sb.append(address.getPostalCode()).append("\n");
                        sb.append(address.getCountryName());
                        result = sb.toString();
                    }
                }
                catch (IOException e)
                {

                } finally
                {
                    Message message = Message.obtain();
                    message.setTarget(handler);
                    if (result != null) {
                        message.what = 1;
                        Bundle bundle = new Bundle();
                        result = result;
                        bundle.putString("address", result);
                        message.setData(bundle);
                    } else {
                        message.what = 1;
                        Bundle bundle = new Bundle();
                        result = "";
                        bundle.putString("address", result);
                        message.setData(bundle);
                    }
                    message.sendToTarget();
                }
            }
        };
        thread.start();
    }

    private class GeocoderHandler extends Handler {
        @Override
        public void handleMessage(Message message)
        {
            houseNoText = (EditText)findViewById(R.id.houseNoEditText);
            houseNameText = (EditText)findViewById(R.id.houseNameEditText);
            aptNameText = (EditText)findViewById(R.id.aptNameEditText);
            streetText = (EditText)findViewById(R.id.streetEditText);
            localityText = (EditText)findViewById(R.id.localityEditText);
            cityText = (EditText)findViewById(R.id.cityEditText);
            pincodeText = (EditText)findViewById(R.id.pincodeEditText);

            String locationAddress;
            switch (message.what) {
                case 1:
                    Bundle bundle = message.getData();
                    locationAddress = bundle.getString("address");
                    break;
                default:
                    locationAddress = null;
            }

            for (int i = 0; i < locationAddress.split("\n").length; i++)
            {
                try {
                    streetText.setText(locationAddress.split("\n")[0]);
                }
                catch (Exception ex)
                {
                    ex.printStackTrace();
                }

                try {
                localityText.setText(locationAddress.split("\n")[1]);
                }
                catch (Exception ex)
                {
                    ex.printStackTrace();
                }

                try {
                cityText.setText(locationAddress.split("\n")[3]);
                    }
                    catch (Exception ex)
                    {
                        ex.printStackTrace();
                    }

                        try {
                pincodeText.setText(locationAddress.split("\n")[4]);
                        }
                        catch (Exception ex)
                        {
                            ex.printStackTrace();
                        }
            }
        }
    }
}