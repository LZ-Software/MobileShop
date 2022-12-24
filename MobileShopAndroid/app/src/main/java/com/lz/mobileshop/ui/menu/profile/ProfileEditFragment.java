package com.lz.mobileshop.ui.menu.profile;

import static android.content.Context.MODE_PRIVATE;

import static java.util.Base64.getEncoder;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentProfileEditBinding;
import com.lz.mobileshop.db.Database;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class ProfileEditFragment extends Fragment
{
    private FragmentProfileEditBinding binding;

    private volatile String encoded;

    ActivityResultLauncher<Intent> someActivityResultLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>()
            {
                @Override
                @SuppressLint("Recycle")
                public void onActivityResult(ActivityResult result)
                {
                    InputStream inputStream;

                    SharedPreferences shared = requireActivity().getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
                    int userId = shared.getInt(getString(R.string.user_id_value_name), 0);

                    if (result.getResultCode() == Activity.RESULT_OK)
                    {
                        Intent data = result.getData();
                        if (data == null)
                        {
                            Toast.makeText(getContext(), R.string.error_cant_load_profile_image, Toast.LENGTH_LONG).show();
                            return;
                        }
                        try
                        {
                            inputStream = requireActivity().getContentResolver().openInputStream(data.getData());
                            byte[] bytes = getBytes(inputStream);
                            encoded = Base64.encodeToString(bytes, Base64.DEFAULT);
                        }
                        catch (IOException e)
                        {
                            Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                        }

                        Thread image = new Thread(new Runnable()
                        {
                            public void run()
                            {
                                Database database = new Database();
                                boolean result = database.callStatement("CALL update_image(?, ?)", getActivity(), userId, encoded);

                                if (result)
                                {
                                    requireActivity().runOnUiThread(new Runnable()
                                    {
                                        public void run()
                                        {
                                            Toast.makeText(getContext(), R.string.error_cant_save_profile_image, Toast.LENGTH_LONG).show();
                                        }
                                    });
                                }
                                else
                                {
                                    requireActivity().runOnUiThread(new Runnable()
                                    {
                                        public void run()
                                        {
                                            Toast.makeText(getContext(), R.string.profile_image_updated, Toast.LENGTH_LONG).show();
                                        }
                                    });
                                }

                                database.close();
                            }
                        });

                        image.start();

                        try
                        {
                            image.join();
                        }
                        catch (InterruptedException e)
                        {
                            requireActivity().runOnUiThread(new Runnable()
                            {
                                public void run()
                                {
                                    Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                                }
                            });
                        }
                    }
                }
            });

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentProfileEditBinding.inflate(inflater, container, false);
        return this.binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        fillCountries();

        binding.editProfileCountry.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
        {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l)
            {
                String newValue = adapterView.getItemAtPosition(i).toString();
                fillCities(newValue);
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView)
            {
                // PASS
            }
        });

        binding.editProfileImage.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                pickImage();
            }
        });

        binding.editProfileSave.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                if (areAllInputFilled())
                {
                    SharedPreferences shared = requireActivity().getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
                    int userId = shared.getInt(getString(R.string.user_id_value_name), 0);

                    String firstName = binding.editProfileFirstName.getText().toString().trim();
                    String lastName = binding.editProfileLastName.getText().toString().trim();
                    String country = binding.editProfileCountry.getSelectedItem().toString().trim();
                    String city = binding.editProfileCity.getSelectedItem().toString().trim();

                    Thread profile = new Thread(new Runnable()
                    {
                        public void run()
                        {
                            Database database = new Database();
                            boolean result = database.callStatement("CALL update_user(?, ?, ?, ?, ?)", getActivity(),
                                    userId, firstName, lastName, country, city);

                            if (result)
                            {
                                requireActivity().runOnUiThread(new Runnable()
                                {
                                    public void run()
                                    {
                                        Toast.makeText(getContext(), R.string.error_cant_update_profile, Toast.LENGTH_LONG).show();
                                    }
                                });
                            }
                            else
                            {
                                requireActivity().runOnUiThread(new Runnable()
                                {
                                    public void run()
                                    {
                                        Toast.makeText(getContext(), R.string.profile_updated, Toast.LENGTH_LONG).show();
                                        NavHostFragment.findNavController(ProfileEditFragment.this).navigate(R.id.action_profileEditFragment_to_nav_profile2);
                                    }
                                });
                            }

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
                        requireActivity().runOnUiThread(new Runnable()
                        {
                            public void run()
                            {
                                Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });
                    }
                }
                else
                {
                    Toast.makeText(getContext(), R.string.error_not_all_fields_are_filled, Toast.LENGTH_LONG).show();
                }
            }
        });
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }

    private void pickImage()
    {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("image/*");
        someActivityResultLauncher.launch(intent);
    }

    public byte[] getBytes(InputStream inputStream) throws IOException
    {
        ByteArrayOutputStream byteBuffer = new ByteArrayOutputStream();

        int bufferSize = 1024;
        byte[] buffer = new byte[bufferSize];
        int len = 0;

        while ((len = inputStream.read(buffer)) != -1)
        {
            byteBuffer.write(buffer, 0, len);
        }

        return byteBuffer.toByteArray();
    }

    private void fillCountries()
    {
        Thread countries = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_countries", getActivity()); // todo

                if (resultSet == null)
                {
                    requireActivity().runOnUiThread(new Runnable()
                    {
                        public void run()
                        {
                            Toast.makeText(getContext(), R.string.error_cant_get_countries, Toast.LENGTH_LONG).show();
                        }
                    });

                    return;
                }

                ArrayList<String> countries = new ArrayList<>();

                while (true)
                {
                    try
                    {
                        if (resultSet.next())
                        {
                            countries.add(resultSet.getString("name"));
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
                                Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });

                        break;
                    }
                }

                ArrayAdapter<String> adapter = new ArrayAdapter<>(getActivity(), android.R.layout.simple_spinner_item, countries);
                adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                binding.editProfileCountry.setAdapter(adapter);

                database.close();
            }
        });

        countries.start();

        try
        {
            countries.join();
        }
        catch (InterruptedException e)
        {
            requireActivity().runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }
    }

    private void fillCities(String country)
    {
        Thread cities = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_cities_by_country(?)", getActivity(), country); // todo

                if (resultSet == null)
                {
                    requireActivity().runOnUiThread(new Runnable()
                    {
                        public void run()
                        {
                            Toast.makeText(getContext(), R.string.error_cant_get_cities, Toast.LENGTH_LONG).show();
                        }
                    });

                    return;
                }

                ArrayList<String> cities = new ArrayList<>();

                while (true)
                {
                    try
                    {
                        if (resultSet.next())
                        {
                            cities.add(resultSet.getString("name_city"));
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
                                Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                            }
                        });

                        break;
                    }
                }

                requireActivity().runOnUiThread(new Runnable()
                {
                    public void run()
                    {
                        ArrayAdapter<String> adapter = new ArrayAdapter<>(getActivity(), android.R.layout.simple_spinner_item, cities);
                        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                        binding.editProfileCity.setAdapter(adapter);
                    }
                });

                database.close();
            }
        });

        cities.start();

        try
        {
            cities.join();
        }
        catch (InterruptedException e)
        {
            requireActivity().runOnUiThread(new Runnable()
            {
                public void run()
                {
                    Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                }
            });
        }
    }

    private boolean areAllInputFilled()
    {
        return this.binding.editProfileFirstName.getText().toString().trim().length() != 0
                && this.binding.editProfileLastName.getText().toString().trim().length() != 0
                && this.binding.editProfileCountry.getSelectedItem().toString().trim().length() != 0
                && this.binding.editProfileCity.getSelectedItem().toString().trim().length() != 0;
    }
}