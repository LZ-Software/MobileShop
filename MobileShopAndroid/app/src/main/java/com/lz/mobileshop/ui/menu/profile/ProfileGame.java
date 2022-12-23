package com.lz.mobileshop.ui.menu.profile;

import android.graphics.Bitmap;

public class ProfileGame
{
    private String title;
    private Bitmap image;

    public ProfileGame(String title, Bitmap image)
    {
        this.title = title;
        this.image = image;
    }

    public String getTitle()
    {
        return title;
    }

    public Bitmap getImage()
    {
        return image;
    }
}
