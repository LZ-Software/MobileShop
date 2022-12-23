package com.lz.mobileshop.ui.menu.shop;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;

import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentGamePageBinding;
import com.lz.mobileshop.db.Database;

import java.sql.ResultSet;
import java.sql.SQLException;

public class GamePageFragment extends Fragment
{
    private FragmentGamePageBinding binding;

    String title;
    String description;
    String publisher;
    String genres;
    String image;
    float price;

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentGamePageBinding.inflate(inflater, container, false);

        try
        {
            fillGame(getArguments().getString("gameTitle"));
        }
        catch (NullPointerException e)
        {
            Toast.makeText(requireActivity(), R.string.error_cant_get_game, Toast.LENGTH_LONG).show();
        }

        return this.binding.getRoot();
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }

    private void fillGame(String gameTitle)
    {
        Thread game = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_game_by_title(?)", requireActivity(), gameTitle);

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
                            title = resultSet.getString("g_name");
                            publisher = resultSet.getString("p_name");
                            genres = resultSet.getString("genres");
                            description = resultSet.getString("g_description");
                            image = resultSet.getString("image_base64");
                            price = resultSet.getFloat("price");
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

                requireActivity().runOnUiThread(new Runnable()
                {
                    @SuppressLint("StringFormatMatches")
                    public void run()
                    {
                        byte[] decodedString = Base64.decode(image, Base64.DEFAULT);
                        Bitmap decodedByte = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);

                        binding.gamePageTitle.setText(title);
                        binding.gamePageDescription.setText(description);
                        binding.gamePagePublisher.setText(publisher);
                        binding.gamePageGenres.setText(genres);
                        binding.gamePageBuy.setText(String.format(getString(R.string.shop_item_game_buy), price));
                        binding.gamePageImage.setImageBitmap(decodedByte);
                    }
                });

                database.close();
            }
        });

        game.start();

        try
        {
            game.join();
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