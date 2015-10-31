package com.iwms.cleartrash;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.location.Location;
import android.location.LocationManager;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.provider.MediaStore;
import android.support.v7.app.ActionBarActivity;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.NameValuePair;
import org.apache.http.StatusLine;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicHeader;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.protocol.HTTP;
import org.apache.http.util.EntityUtils;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.ExecutionException;

public class SpotImageActivity extends Activity {

    String ba1;
    String mCurrentPhotoPath;
    LocationManager locationManager;
    double longitude;
    double latitude;
    Button btnup;
    ImageView mImageView;
    ProgressDialog progressBar;
    private int progressBarStatus = 0;
    private Handler progressBarHandler = new Handler();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_spot_image);

        mImageView = (ImageView) findViewById(R.id.Imageprev);
        locationManager = (LocationManager) getSystemService(LOCATION_SERVICE);
        Location location = getLastKnownLocation();
        latitude = location.getLatitude();
        longitude = location.getLongitude();

        captureImage();

        btnup = (Button) findViewById(R.id.up);
        btnup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // prepare for a progress bar dialog
                progressBar = new ProgressDialog(view.getContext());
                progressBar.setCancelable(true);
                progressBar.setMessage("Uploading Image...You will be awarded liquids post verification!");
                progressBar.setProgressStyle(ProgressDialog.STYLE_SPINNER);
                progressBar.setProgress(0);
                progressBar.setMax(100);
                progressBar.show();

                //reset progress bar status
                progressBarStatus = 10;

                new Thread(new Runnable() {
                    public void run() {
                while (progressBarStatus < 100) {
                    Helper.ImagePath = "";
                    upload();

                    while(Helper.ImagePath.equals(""))
                    {

                    }

                    InsertSpotImage();

                progressBarStatus = 100;

                Intent intent = new Intent(SpotImageActivity.this, HomeActivity.class);
                startActivity(intent);

                progressBarHandler.post(new Runnable() {
                        public void run() {
                            progressBar.setProgress(progressBarStatus);
                        }
                    });
                }

                // ok, file is downloaded,
                if (progressBarStatus >= 100) {
                    // close the progress bar dialog
                    progressBar.dismiss();
                }
                    }
                }).start();
            }
        });
    }

    private Location getLastKnownLocation() {
        locationManager = (LocationManager)getApplicationContext().getSystemService(LOCATION_SERVICE);
        List<String> providers = locationManager.getProviders(true);
        Location bestLocation = null;
        for (String provider : providers) {
            Location location = locationManager.getLastKnownLocation(LocationManager.GPS_PROVIDER);

            if (location != null) {
                return location;
            }

            location = locationManager.getLastKnownLocation(provider);

            if (location == null) {
                continue;
            }

            if (bestLocation == null || location.getAccuracy() < bestLocation.getAccuracy()) {
                // Found best last known location: %s", l);
                bestLocation = location;
            }
        }
        return bestLocation;
    }

    private void upload() {
        Bitmap bm = BitmapFactory.decodeFile(mCurrentPhotoPath);
        ByteArrayOutputStream bao = new ByteArrayOutputStream();
        bm.compress(Bitmap.CompressFormat.JPEG, 50, bao);
        byte[] ba = bao.toByteArray();
        ba1 = Base64.encodeToString(ba, Base64.DEFAULT);

        // Upload image to server
        new uploadToServer().execute();
    }

    private void captureImage() {
        Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        // Ensure that there's a camera activity to handle the intent
        if (takePictureIntent.resolveActivity(getPackageManager()) != null) {
            // Create the File where the photo should go
            File photoFile = null;
            try {
                photoFile = createImageFile();
            } catch (IOException ex) {
                // Error occurred while creating the File
                ex.printStackTrace();
            }
            // Continue only if the File was successfully created
            if (photoFile != null) {
                takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT,
                        Uri.fromFile(photoFile));
                startActivityForResult(takePictureIntent, 100);
            }
        }
    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == 100 && resultCode == RESULT_OK) {
            setPic();
            //upload();
        }
    }

    public class uploadToServer extends AsyncTask<Void, Void, String> {

        @Override
        protected String doInBackground(Void... params) {
            try {
                String image = String.valueOf(System.currentTimeMillis()) + ".jpg";
                String postPartUrl = "http://" + Helper.Server + "/ManagementService/api/spotimage";
                HttpClient httpclient = new DefaultHttpClient();
                HttpPost httpPost = new HttpPost(postPartUrl);

                List<NameValuePair> nameValuePairs = new LinkedList<NameValuePair>();
                nameValuePairs.add(new BasicNameValuePair("ImagePath",String.valueOf(image)));
                nameValuePairs.add(new BasicNameValuePair("ImageData", ba1));
                httpPost.setHeader("Content-Type", "application/x-www-form-urlencoded");
                httpPost.setHeader("Accept", "application/json");
                HttpEntity entity = new UrlEncodedFormEntity(nameValuePairs, "UTF-8");
                httpPost.setEntity(entity);

                HttpResponse response = httpclient.execute(httpPost);
                InputStream inputStream = response.getEntity().getContent();

                if(inputStream != null)
                {
                    Helper.ImagePath = convertInputStreamToString(inputStream).replace('"',' ').trim();
                }
            }
            catch (UnsupportedEncodingException e)
            {
                e.printStackTrace();
            }
            catch (IOException e)
            {
                e.printStackTrace();
            }

            return "success";
        }

        private String convertInputStreamToString(InputStream inputStream) throws IOException{
            BufferedReader bufferedReader = new BufferedReader( new InputStreamReader(inputStream));
            String line = "";
            String result = "";
            while((line = bufferedReader.readLine()) != null)
                result += line;

            inputStream.close();
            return result;
        }
    }

    private void InsertSpotImage()
    {
        String latStr = String.valueOf(latitude).replace('.','_').substring(0,8);
        String longStr = String.valueOf(longitude).replace('.','_').substring(0,8);

        String spotImageUrl = "http://sujathvm1.cloudapp.net/ManagementService/api/spotimage/is%7C" + Helper.Key +
                "%7C" + latStr + "%7C" + longStr + "%7C" + Helper.ImagePath.replace(":","c_olon").replace("\\","s_la").replace('.','_');
        RequestTask task = (RequestTask) new RequestTask().execute(spotImageUrl);

        try {
            task.get();
        } catch (InterruptedException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (ExecutionException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    private void setPic() {
        // Get the dimensions of the View
        int targetW = 1200;
        int targetH = 1600;

        // Get the dimensions of the bitmap
        BitmapFactory.Options bmOptions = new BitmapFactory.Options();
        bmOptions.inJustDecodeBounds = true;
        BitmapFactory.decodeFile(mCurrentPhotoPath, bmOptions);
        int photoW = bmOptions.outWidth;
        int photoH = bmOptions.outHeight;

        // Determine how much to scale down the image
        int scaleFactor = Math.min(photoW / targetW, photoH / targetH);

        // Decode the image file into a Bitmap sized to fill the View
        bmOptions.inJustDecodeBounds = false;
        bmOptions.inSampleSize = scaleFactor;
        bmOptions.inPurgeable = true;

        Bitmap bitmap = BitmapFactory.decodeFile(mCurrentPhotoPath, bmOptions);
        mImageView.setImageBitmap(bitmap);
    }

    private File createImageFile() throws IOException {
        // Create an image file name
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        String imageFileName = "JPEG_" + timeStamp + "_";
        File storageDir = Environment.getExternalStoragePublicDirectory(
                Environment.DIRECTORY_PICTURES);

        File image = File.createTempFile(
                imageFileName,  /* prefix */
                ".jpg",         /* suffix */
                storageDir      /* directory */
        );

        // Save a file: path for use with ACTION_VIEW intents
        mCurrentPhotoPath = image.getAbsolutePath();
        return image;
    }

}
