package com.lz.mobileshop.ui.menu.shop;

import android.graphics.Bitmap;

public class Game
{
    private String title;
    private String publisher;
    private String genres;
    private float price;
    private Bitmap image;

    public Game(String title, String publisher, String genres, float price, Bitmap image)
    {
        this.title = title;
        this.publisher = publisher;
        this.genres = genres;
        this.price = price;
        this.image = image;
    }

    public String getTitle()
    {
        return title;
    }

    public String getPublisher()
    {
        return publisher;
    }

    public String getGenres()
    {
        return genres;
    }

    public float getPrice()
    {
        return price;
    }

    public Bitmap getImage()
    {
        return image;
    }
}
