package com.iwms.cleartrash;

import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

import java.util.concurrent.ExecutionException;

public class UserDetailsActivity extends AppCompatActivity {

    TextView userTextView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_details);

        userTextView = (TextView) findViewById(R.id.userListTextView);
        final String userId = Helper.UserId;

        String userUrl = "http://" + Helper.Server  + "/ManagementService/api/household/ru%7C" + userId;
        RequestTask task = (RequestTask) new RequestTask().execute(userUrl);
        String userDetails = "";

        try {
            userDetails = task.get();

            StringBuilder sb = new StringBuilder();
            for(int i =0; i< userDetails.split("s_lash").length; i++)
            {
                if(!userDetails.split("s_lash")[i].equals("NA")) {
                    sb.append(userDetails.split("s_lash")[i]);
                    sb.append("\n");
                }
            }

            userTextView.setText(sb.toString());
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
}
