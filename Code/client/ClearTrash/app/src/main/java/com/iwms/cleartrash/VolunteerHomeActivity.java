package com.iwms.cleartrash;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;

public class VolunteerHomeActivity extends Activity {

    ListView listViewEvent, listviewNCUser;
    List<String> eventIds = null;
    List<String> events = null;
    List<String> userIds = null;
    List<String> users = null;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_volunteer_home);

        // Get ListView object from xml
        listViewEvent = (ListView) findViewById(R.id.listviewEvent);
        listviewNCUser = (ListView) findViewById(R.id.listviewNCUser);

        RequestTask task = null;
        String volunteerEventRequestUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/volunteer/rve%7C" +
                Helper.Key;
        task = (RequestTask) new RequestTask().execute(volunteerEventRequestUrl);

        try {
            String[] evs = task.get().replace('"',' ').trim().split(",");
            eventIds = new ArrayList<String>();
            events = new ArrayList<String>();

            for(int i=0;i<evs.length;i++)
            {
                eventIds.add(evs[i].substring(0, evs[i].indexOf('_')));
                events.add(evs[i].substring(evs[i].indexOf('_') + 1));
            }
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        ArrayAdapter<String> adapterEvents = new ArrayAdapter<String>(this,
                android.R.layout.simple_list_item_1, android.R.id.text1, events);

        // Assign adapter to ListView
        listViewEvent.setAdapter(adapterEvents);

        // ListView Item Click Listener
        listViewEvent.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                int itemPosition = position;
                Helper.EventId = eventIds.get(position);
                Intent intent = new Intent(VolunteerHomeActivity.this, EventDetailsActivity.class);
                startActivity(intent);
            }
        });

        String volunteerNCUsersRequestUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/volunteer/rvu%7C" +
                Helper.Key;
        task = (RequestTask) new RequestTask().execute(volunteerNCUsersRequestUrl);

        try {
            String[] uss = task.get().replace('"',' ').trim().split(",");
            userIds = new ArrayList<String>();
            users = new ArrayList<String>();

            for(int i=0;i<uss.length;i++)
            {
                userIds.add(uss[i].substring(0, uss[i].indexOf('_')));
                users.add(uss[i].substring(uss[i].indexOf('_') + 1));
            }
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        ArrayAdapter<String> adapterNCUsers = new ArrayAdapter<String>(this,
                android.R.layout.simple_list_item_1, android.R.id.text1, users);

        // Assign adapter to ListView
        listviewNCUser.setAdapter(adapterNCUsers);

        // ListView Item Click Listener
        listviewNCUser.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
            {
                int itemPosition = position;
                Helper.UserId = userIds.get(position);
                Intent intent = new Intent(VolunteerHomeActivity.this, UserDetailsActivity.class);
                startActivity(intent);
            }
        });
    }

}
