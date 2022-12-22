package com.lz.mobileshop.ui.main;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentRegisterBinding;
import com.lz.mobileshop.db.Database;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class RegisterFragment extends Fragment
{
    private FragmentRegisterBinding binding;

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        binding = FragmentRegisterBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        fillCountries();

        binding.registerCountrySpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener()
        {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id)
            {
                String newValue = parentView.getItemAtPosition(position).toString();
                fillCities(newValue);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parentView)
            {
                // PASS
            }
        });

        binding.registerSignupButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                if (!areAllInputFilled())
                {
                    Toast toast = Toast.makeText(getContext(), R.string.error_not_all_fields_are_filled, Toast.LENGTH_LONG);
                    toast.show();
                }
                else
                {
                    String username = binding.registerUsernameInput.getText().toString();
                    String password = binding.registerPasswordInput.getText().toString();
                    String firstName = binding.registerFirstNameInput.getText().toString();
                    String lastName = binding.registerLastNameInput.getText().toString();
                    String country = binding.registerCountrySpinner.getSelectedItem().toString();
                    String city = binding.registerCitySpinner.getSelectedItem().toString();

                    Thread auth = new Thread(new Runnable()
                    {
                        public void run()
                        {
                            Database database = new Database("postgres", "keker227");
                            boolean result = database.callStatement("CALL create_user(?, ?, ?, ?, ?, ?)",
                                    getActivity(), username, password, firstName, lastName, country, city);

                            requireActivity().runOnUiThread(new Runnable()
                            {
                                public void run()
                                {
                                    if (!result)
                                    {
                                        Toast.makeText(getContext(), R.string.success_register_user, Toast.LENGTH_LONG).show();
                                        NavHostFragment.findNavController(RegisterFragment.this).navigate(R.id.action_RegisterFragment_to_LoginFragment);
                                    }
                                    else
                                    {
                                        Toast.makeText(getContext(), R.string.error_cant_register_user, Toast.LENGTH_LONG).show();
                                    }
                                }
                            });

                            database.close();
                        }
                    });

                    auth.start();

                    try
                    {
                        auth.join();
                    }
                    catch (InterruptedException e)
                    {
                        Toast toast = Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG);
                        toast.show();
                    }
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

    private void fillCountries()
    {
        Thread countries = new Thread(new Runnable()
        {
            public void run()
            {
                Database database = new Database();
                ResultSet resultSet = database.executeQuery("SELECT * FROM get_countries", getActivity());

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
                binding.registerCountrySpinner.setAdapter(adapter);

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
                ResultSet resultSet = database.executeQuery(String.format("SELECT * FROM get_cities_by_country('%s')", country), getActivity());

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
                        binding.registerCitySpinner.setAdapter(adapter);
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
        return this.binding.registerUsernameInput.getText().toString().length() != 0
                && this.binding.registerPasswordInput.getText().toString().length() != 0
                && this.binding.registerFirstNameInput.getText().toString().length() != 0
                && this.binding.registerLastNameInput.getText().toString().length() != 0
                && this.binding.registerCountrySpinner.getSelectedItem().toString().length() != 0
                && this.binding.registerCitySpinner.getSelectedItem().toString().length() != 0;
    }
}