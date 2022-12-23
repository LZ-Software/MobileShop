package com.lz.mobileshop.ui.menu.shop;

import android.annotation.SuppressLint;
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

public class GameAdapter extends RecyclerView.Adapter<GameAdapter.ViewHolder>
{
    private final LayoutInflater inflater;
    private final List<Game> games;

    GameAdapter(Context context, List<Game> games)
    {
        this.games = games;
        this.inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public GameAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType)
    {
        View view = inflater.inflate(R.layout.game_list_item, parent, false);
        return new ViewHolder(view);
    }

    @SuppressLint("DefaultLocale")
    @Override
    public void onBindViewHolder(GameAdapter.ViewHolder holder, int position)
    {
        Game game = games.get(position);
        holder.imageView.setImageBitmap(game.getImage());
        holder.titleView.setText(game.getTitle());
        holder.genresView.setText(game.getGenres());
        holder.publisherView.setText(game.getPublisher());
        holder.priceView.setText(String.format("%.2f ₽", game.getPrice()));
    }

    @Override
    public int getItemCount()
    {
        return games.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder
    {
        final ImageView imageView;
        final TextView titleView, genresView, priceView, publisherView;

        ViewHolder(View view)
        {
            super(view);

            imageView = view.findViewById(R.id.shop_item_game_image);
            titleView = view.findViewById(R.id.shop_item_game_title);
            genresView = view.findViewById(R.id.shop_item_game_genres);
            priceView = view.findViewById(R.id.shop_item_game_price);
            publisherView = view.findViewById(R.id.shop_item_game_publisher);
        }
    }
}
