package com.lz.mobileshop.ui.menu.profile;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.lz.mobileshop.R;

import java.util.List;

public class ProfileGameAdapter extends RecyclerView.Adapter<ProfileGameAdapter.ViewHolder>
{
    private final LayoutInflater inflater;
    private final List<ProfileGame> games;

    ProfileGameAdapter(Context context, List<ProfileGame> games)
    {
        this.games = games;
        this.inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public ProfileGameAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType)
    {
        View view = inflater.inflate(R.layout.profile_game_list_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(ProfileGameAdapter.ViewHolder holder, int position)
    {
        ProfileGame profileGame = games.get(position);
        holder.image.setImageBitmap(profileGame.getImage());
        holder.title.setText(profileGame.getTitle());
    }

    @Override
    public int getItemCount()
    {
        return games.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        final ImageView image;
        final TextView title;

        ViewHolder(View view)
        {
            super(view);

            image = view.findViewById(R.id.profile_game_list_item_image);
            title = view.findViewById(R.id.profile_game_list_item_title);
        }
    }
}
