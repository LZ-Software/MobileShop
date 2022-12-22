package com.lz.mobileshop.ui.menu.shop;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import com.lz.mobileshop.databinding.FragmentShopBinding;

public class ShopFragment extends Fragment
{
    private FragmentShopBinding binding;

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentShopBinding.inflate(inflater, container, false);
        return this.binding.getRoot();
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }
}