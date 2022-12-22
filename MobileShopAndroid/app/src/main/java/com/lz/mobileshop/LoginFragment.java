package com.lz.mobileshop;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.lz.mobileshop.databinding.FragmentLoginBinding;

import java.sql.ResultSet;
import java.sql.SQLException;

public class LoginFragment extends Fragment
{
    private FragmentLoginBinding binding;
    volatile int userId = 0;

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentLoginBinding.inflate(inflater, container, false);
        return this.binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);

        this.binding.authSigninButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                if (!areAllInputFilled())
                {
                    Toast.makeText(getContext(), R.string.error_not_all_fields_are_filled, Toast.LENGTH_LONG).show();
                }
                else
                {
                    String login = binding.authLoginInput.getText().toString();
                    String password = binding.authPasswordInput.getText().toString();

                    Thread auth = new Thread(new Runnable()
                    {
                        public void run()
                        {
                            Database database = new Database();
                            ResultSet resultSet = database.executeQuery("SELECT * FROM auth_user_get_id(?, ?)", getActivity(), login, password);

                            while (true)
                            {
                                try
                                {
                                    if (resultSet.next())
                                    {
                                        userId = resultSet.getInt("auth_user_get_id");
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

                            database.close();
                        }
                    });

                    auth.start();

                    try
                    {
                        auth.join();

                        if (userId == 0)
                        {
                            Toast.makeText(getContext(), R.string.error_cant_auth, Toast.LENGTH_LONG).show();
                        }
                        else
                        {
                            // TODO: Success
                        }
                    }
                    catch (InterruptedException e)
                    {
                        Toast.makeText(getContext(), e.getMessage(), Toast.LENGTH_LONG).show();
                    }
                }
            }
        });

        this.binding.authSignupButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                NavHostFragment.findNavController(LoginFragment.this)
                        .navigate(R.id.action_LoginFragment_to_RegisterFragment);
            }
        });
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        this.binding = null;
    }

    private boolean areAllInputFilled()
    {
        return this.binding.authLoginInput.getText().toString().length() != 0
                && this.binding.authPasswordInput.getText().toString().length() != 0;
    }
}