package com.lz.mobileshop.ui.menu.shop;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class ShopViewModel extends ViewModel
{

    private final MutableLiveData<String> mText;

    public ShopViewModel()
    {
        mText = new MutableLiveData<>();
        mText.setValue("This is home fragment");
    }

    public LiveData<String> getText()
    {
        return mText;
    }
}