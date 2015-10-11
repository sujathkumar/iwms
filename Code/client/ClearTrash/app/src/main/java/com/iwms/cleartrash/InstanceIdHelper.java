/*
Copyright 2015 Google Inc. All Rights Reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */
package com.iwms.cleartrash;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;

import com.google.android.gms.gcm.GoogleCloudMessaging;
import com.google.android.gms.iid.InstanceID;

import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

public class InstanceIdHelper {

    private final Context mContext;

    public InstanceIdHelper(Context context) {
        mContext = context;
    }

    /**
     * Get a Instance ID authorization Token
     */
    public void getTokenInBackground(final String authorizedEntity, final String scope,
                                        final Bundle extras) {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void... params) {
                try {
                     String token = InstanceID.getInstance(mContext)
                            .getToken(authorizedEntity, scope, extras);
                    Helper.GCMToken = token.replace(":","c_olon");
                }
                catch (final IOException e) {
                }
                return null;
            }
        }.execute();
    }

    /**
     * Unregister by deleting the token
     */
    public void deleteTokenInBackground(final String authorizedEntity, final String scope) {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void... params) {
                try
                {
                    InstanceID.getInstance(mContext).deleteToken(authorizedEntity, scope);
                }
                catch (final IOException e)
                {
                }
                return null;
            }
        }.execute();
    }

    public String getInstanceId() {
        return InstanceID.getInstance(mContext).getId();
    }

    public long getCreationTime() {
        return InstanceID.getInstance(mContext).getCreationTime();
    }

    public void deleteInstanceIdInBackground() {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void... params) {
                try
                {
                    InstanceID.getInstance(mContext).deleteInstanceID();
                }
                catch (final IOException e)
                {
                }
                return null;
            }
        }.execute();
    }
}
