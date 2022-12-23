package com.lz.mobileshop.ui.menu.profile;

import static android.content.Context.MODE_PRIVATE;

import android.content.SharedPreferences;
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
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentProfileBinding;
import com.lz.mobileshop.db.Database;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class ProfileFragment extends Fragment
{
    private FragmentProfileBinding binding;

    private ArrayList<ProfileGame> games = new ArrayList<ProfileGame>();

    private volatile String username;
    private volatile String firstName;
    private volatile String lastName;
    private volatile String userImage;

    private volatile String title;
    private volatile String gameImage;

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentProfileBinding.inflate(inflater, container, false);
        return this.binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        fillUserInfo();
        fillTableList();

        RecyclerView recyclerView = binding.profileGames;
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(requireActivity());
        linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);
        recyclerView.setLayoutManager(linearLayoutManager);
        ProfileGameAdapter adapter = new ProfileGameAdapter(requireActivity(), games);
        recyclerView.setAdapter(null);
        recyclerView.setAdapter(adapter);
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }

    private void fillUserInfo()
    {
        SharedPreferences shared = requireActivity().getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
        int userId = shared.getInt(getString(R.string.user_id_value_name), 0);

        Thread user = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_user_info_by_user_id(?)", requireActivity(), userId);

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
                            username = resultSet.getString("username");
                            firstName = resultSet.getString("first_name");
                            lastName = resultSet.getString("last_name");
                            userImage = resultSet.getString("image");
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

        user.start();

        try
        {
            user.join();

            byte[] decodedString = Base64.decode(userImage, Base64.DEFAULT);
            Bitmap decodedByte = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);

            binding.profileUsername.setText(username);
            binding.profileFullName.setText(String.format(getString(R.string.profile_full_name), firstName, lastName));
            binding.profileImage.setImageBitmap(decodedByte);
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

    private void fillTableList()
    {
        games.clear();

        SharedPreferences shared = requireActivity().getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
        int userId = shared.getInt(getString(R.string.user_id_value_name), 0);

        Thread table = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_games_by_user_id(?)", requireActivity(), userId);

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
                            gameImage = resultSet.getString("image_base64");

                            byte[] decodedString = Base64.decode(gameImage, Base64.DEFAULT);
                            Bitmap decodedByte = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);

                            games.add(new ProfileGame(title, decodedByte));
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