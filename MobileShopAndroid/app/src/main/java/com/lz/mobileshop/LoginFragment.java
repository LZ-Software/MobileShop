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

public class LoginFragment extends Fragment
{
    private FragmentLoginBinding binding;

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
                    Toast toast = Toast.makeText(getContext(), R.string.error_not_all_fields_are_filled, Toast.LENGTH_LONG);
                    toast.show();
                }
                else
                {
                    Thread auth = new Thread(new Runnable()
                    {
                        public void run()
                        {
                            Database database = new Database();
                            database.executeQuery("", getActivity());
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