package com.lz.mobileshop.ui.menu.shop;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.RecyclerView;

import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentShopBinding;
import com.lz.mobileshop.db.Database;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class ShopFragment extends Fragment
{
    private FragmentShopBinding binding;
    private ArrayList<Game> games = new ArrayList<Game>();

    private volatile String title;
    private volatile String publisher;
    private volatile String genres;
    private volatile String image;
    private volatile float price;

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentShopBinding.inflate(inflater, container, false);

        return this.binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        fillTableList();

        RecyclerView recyclerView = binding.shopTable;
        GameAdapter adapter = new GameAdapter(requireActivity(), games);
        recyclerView.setAdapter(null);
        recyclerView.setAdapter(adapter);
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }

    private void fillTableList()
    {
        games.clear();

        Thread table = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_games", requireActivity());

                if (resultSet == null)
                {
                    requireActivity().runOnUiThread(new Runnable()
                    {
                        public void run()
                        {
                            Toast.makeText(requireActivity(), R.string.error_cant_get_games, Toast.LENGTH_LONG).show();
                        }
                    });

                    return;
                }

                while (true)
                {
                    try
                    {
                        if (resultSet.next())
                        {
                            title = resultSet.getString("game");
                            publisher = resultSet.getString("publisher");
                            genres = resultSet.getString("genres");
                            image = resultSet.getString("image");
                            price = resultSet.getFloat("price");

                            byte[] decodedString = Base64.decode(image, Base64.DEFAULT);
                            Bitmap decodedByte = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);

                            games.add(new Game(title, publisher, genres, price, decodedByte));
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SQLException e)
                    {
                        requireActivity().runOnUiThread(new Runnable()
                        {
                            public void run()
                            {
                                Toast.makeText(requireActivity(), e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });

                        break;
                    }
                }

                database.close();
            }
        });

        table.start();

        try
        {
            table.join();
        }
        catch (InterruptedException e)
        {
            requireActivity().runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(requireActivity(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }
    }
}