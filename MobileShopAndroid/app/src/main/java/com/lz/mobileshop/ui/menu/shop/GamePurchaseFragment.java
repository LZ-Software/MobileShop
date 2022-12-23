package com.lz.mobileshop.ui.menu.shop;

import static android.content.Context.MODE_PRIVATE;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.lz.mobileshop.Environment;
import com.lz.mobileshop.R;
import com.lz.mobileshop.databinding.FragmentGamePurchaseBinding;
import com.lz.mobileshop.db.Database;

import java.util.Random;

public class GamePurchaseFragment extends Fragment
{
    private FragmentGamePurchaseBinding binding;

    private int gameId;
    private int userId;
    private String gameTitle;
    private float gamePrice;

    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        this.binding = FragmentGamePurchaseBinding.inflate(inflater, container, false);

        try
        {
            Bundle bundle = getArguments();
            gameId = bundle.getInt("gameId");
            gameTitle = bundle.getString("gameTitle");
            gamePrice = bundle.getFloat("gamePrice");

            SharedPreferences shared = requireActivity().getSharedPreferences(getString(R.string.shared_preferences_name), MODE_PRIVATE);
            userId = shared.getInt(getString(R.string.user_id_value_name), 0);

            binding.gamePurchaseGameName.setText(gameTitle);
            binding.gamePurchaseButton.setText(String.format(getString(R.string.game_purchase_button), gamePrice));
        }
        catch (NullPointerException e)
        {
            Toast.makeText(requireActivity(), e.getMessage(), Toast.LENGTH_LONG).show();
            NavHostFragment.findNavController(GamePurchaseFragment.this).navigate(R.id.action_gamePurchaseFragment_to_gamePageFragment);
        }

        binding.gamePurchaseButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                Random random = new Random();

                if (random.nextBoolean())
                {
                    if (!checkInput())
                    {
                        Toast.makeText(requireActivity(), R.string.error_not_all_fields_are_filled, Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        Thread purchase = new Thread(new Runnable()
                        {
                            public void run()
                            {
                                Database database = new Database();

                                boolean result = database.callStatement("CALL game_purchase_procedure(?, ?)", requireActivity(), userId, gameId);

                                requireActivity().runOnUiThread(new Runnable()
                                {
                                    public void run()
                                    {
                                        if (!result)
                                        {
                                            Toast.makeText(getContext(), R.string.success_purchased, Toast.LENGTH_LONG).show();
                                            NavHostFragment.findNavController(GamePurchaseFragment.this).navigate(R.id.action_gamePurchaseFragment_to_nav_shop);
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

                        purchase.start();

                        try
                        {
                            purchase.join();
                        }
                        catch (InterruptedException e)
                        {
                            Toast.makeText(requireActivity(), e.getMessage(), Toast.LENGTH_LONG).show();
                        }
                    }
                }
                else
                {
                    Toast.makeText(requireActivity(), R.string.error_purchase_fail, Toast.LENGTH_LONG).show();
                }
            }
        });

        return this.binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState)
    {
        super.onViewCreated(view, savedInstanceState);
    }

    @Override
    public void onDestroyView()
    {
        super.onDestroyView();
        binding = null;
    }

    private boolean checkInput()
    {
        return this.binding.gamePurchaseCardInput.getText().toString().trim().length() != 0
                && this.binding.gamePurchaseDateInput.getText().toString().trim().length() != 0
                && this.binding.gamePurchaseCvvInput.getText().toString().trim().length() != 0;
    }
}