package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.concurrent.ExecutionException;

public class VolunteerEventActivity extends Activity {

    ImageView image;
    TextView eventTextView;
    Button b1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_event);

        eventTextView = (TextView) findViewById(R.id.eventTextView);
        final String eventId = Helper.EventId;
        b1 = (Button)findViewById(R.id.acceptButton);

        String eventUrl = "http://" + Helper.Server  + "/ManagementService/api/spotimage/re%7C" + eventId;
        RequestTask task = (RequestTask) new RequestTask().execute(eventUrl);
        String eventDetails = "";

        try {
            eventDetails = task.get().replace('"',' ').trim();
            eventTextView.setText("Are you willing to participate in the " + eventDetails.substring(0, eventDetails.lastIndexOf("'")) + "'?");
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

        // Loader image - will be shown before loading image
        int loader = R.drawable.loader;
        image = (ImageView) findViewById(R.id.imageView);
        String imagePath = eventDetails.substring(eventDetails.lastIndexOf("'")+1).replace("C:","").replace("inetpub","").replace("wwwroot","").substring(12);
        imagePath = imagePath.replace("\\\\","/");
        // Image url
        String image_url = "http://sujathvm1.cloudapp.net/" + imagePath;

        // ImageLoader class instance
        ImageLoader imgLoader = new ImageLoader(getApplicationContext());

        // whenever you want to load an image from url
        // call DisplayImage function
        // url - image url to load
        // loader - loader image, will be displayed before getting image
        // image - ImageView
        imgLoader.DisplayImage(image_url, loader, image);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String insertEventVolunteerUrl = "http://" + Helper.Server  + "/ManagementService/api/volunteer/ie%7C" + Helper.Key + "%7C" + eventId;
                RequestTask task = (RequestTask) new RequestTask().execute(insertEventVolunteerUrl);
                String code = "";

                try {
                    code = task.get().replace('"',' ').trim();
                    if(code.equals("216")) {
                        Intent intent = new Intent(VolunteerEventActivity.this, ClearTrashHomeActivity.class);
                        startActivity(intent);
                    }
                    else
                    {
                        Toast.makeText(getApplicationContext(), "Error, Please Try Again!", Toast.LENGTH_SHORT).show();
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
