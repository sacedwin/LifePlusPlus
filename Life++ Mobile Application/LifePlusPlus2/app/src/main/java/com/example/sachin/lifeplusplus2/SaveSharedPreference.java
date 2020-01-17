package com.example.sachin.lifeplusplus2;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;

/**
 * Created by sachin on 6/7/17.
 */

public class SaveSharedPreference {
    static final String PREF_USER_EMAIL= "";

    static SharedPreferences getSharedPreferences(Context ctx) {
        return PreferenceManager.getDefaultSharedPreferences(ctx);
    }

    public static void setUserId(Context ctx, String userId)
    {
        SharedPreferences.Editor editor = getSharedPreferences(ctx).edit();        //storing new value
        editor.putString(PREF_USER_EMAIL, userId);
        editor.commit();
    }

    public static String getUserId(Context ctx)
    {
        return getSharedPreferences(ctx).getString(PREF_USER_EMAIL, "");        //returning the stored value
    }

    public static void clearUserId(Context ctx)
    {
        SharedPreferences.Editor editor = getSharedPreferences(ctx).edit();
        editor.clear();                                                         //clear all stored data
        editor.commit();
    }
}
