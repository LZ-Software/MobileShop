package com.lz.mobileshop;

import android.content.Context;
import android.content.res.Resources;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public final class Environment
{
    public static String getValue(Context context, String name)
    {
        Resources resources = context.getResources();

        try
        {
            InputStream rawResource = resources.openRawResource(R.raw.config);
            Properties properties = new Properties();
            properties.load(rawResource);
            return properties.getProperty(name);
        }
        catch (Resources.NotFoundException | IOException ignored) {}

        return null;
    }
}
