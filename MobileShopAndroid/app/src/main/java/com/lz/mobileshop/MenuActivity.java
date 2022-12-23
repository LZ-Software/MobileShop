package com.lz.mobileshop;

import android.app.Activity;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.util.Base64;
import android.view.Menu;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.navigation.NavigationView;

import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.appcompat.app.AppCompatActivity;

import com.lz.mobileshop.databinding.ActivityMenuBinding;
import com.lz.mobileshop.db.Database;

import java.sql.ResultSet;
import java.sql.SQLException;

public class MenuActivity extends AppCompatActivity
{
    private AppBarConfiguration mAppBarConfiguration;
    private ActivityMenuBinding binding;

    private volatile String username;
    private volatile String firstName;
    private volatile String lastName;
    private volatile String image;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        binding = ActivityMenuBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        setSupportActionBar(binding.appBarMenu.toolbar);

        DrawerLayout drawer = binding.drawerLayout;
        NavigationView navigationView = binding.navView;

        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        mAppBarConfiguration = new AppBarConfiguration.Builder(
                R.id.nav_profile, R.id.nav_shop)
                .setOpenableLayout(drawer)
                .build();

        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_menu);
        NavigationUI.setupActionBarWithNavController(this, navController, mAppBarConfiguration);
        NavigationUI.setupWithNavController(navigationView, navController);

        fillUserInfo();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    @Override
    public boolean onSupportNavigateUp()
    {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_menu);
        return NavigationUI.navigateUp(navController, mAppBarConfiguration) || super.onSupportNavigateUp();
    }

    private void fillUserInfo()
    {
        Activity activity = this;

        SharedPreferences shared = getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
        int userId = shared.getInt(getString(R.string.user_id_value_name), 0);

        Thread profile = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_user_info_by_id(?)", activity, userId);

                if (resultSet == null)
                {
                    runOnUiThread(new Runnable()
                    {
                        public void run()
                        {
                            Toast.makeText(activity, R.string.error_cant_get_cities, Toast.LENGTH_LONG).show();
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
                            username = resultSet.getString("username_text");
                            firstName = resultSet.getString("name_text");
                            lastName = resultSet.getString("last_name_text");
                            image = resultSet.getString("image_base64");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SQLException e)
                    {
                        runOnUiThread(new Runnable()
                        {
                            public void run()
                            {
                                Toast.makeText(activity, e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });

                        break;
                    }
                }

                runOnUiThread(new Runnable()
                {
                    public void run()
                    {
                        View header = binding.navView.getHeaderView(0);
                        TextView usernameTextView = (TextView) header.findViewById(R.id.nav_username);
                        TextView nameTextView = (TextView) header.findViewById(R.id.nav_name);
                        ImageView imageView = (ImageView) header.findViewById(R.id.nav_image);
                        usernameTextView.setText(username);
                        nameTextView.setText(String.format("%s %s", firstName, lastName));
                        byte[] decodedString = Base64.decode(image, Base64.DEFAULT);
                        Bitmap decodedByte = BitmapFactory.decodeByteArray(decodedString, 0, decodedString.length);
                        imageView.setImageBitmap(decodedByte);
                    }
                });

                database.close();
            }
        });

        profile.start();

        try
        {
            profile.join();
        }
        catch (InterruptedException e)
        {
            runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(activity, e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }
    }
}