package com.lz.mobileshop.ui.menu.shop;

import android.annotation.SuppressLint;
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
    public interface OnItemClickListener
    {
        void onItemClick(Game item);
    }

    private List<Game> items;
    private OnItemClickListener listener;

    public GameAdapter(List<Game> items, OnItemClickListener listener)
    {
        this.items = items;
        this.listener = listener;
    }

    @NonNull
    @Override public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType)
    {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.game_list_item, parent, false);
        return new ViewHolder(v);
    }

    @Override public void onBindViewHolder(ViewHolder holder, int position)
    {
        holder.bind(items.get(position), listener);
    }

    @Override public int getItemCount()
    {
        return items.size();
    }

    static class ViewHolder extends RecyclerView.ViewHolder
    {
        private TextView title;
        private TextView genres;
        private TextView publisher;
        private TextView price;
        private ImageView image;

        public ViewHolder(View itemView)
        {
            super(itemView);
            title = (TextView) itemView.findViewById(R.id.shop_item_game_title);
            genres = (TextView) itemView.findViewById(R.id.shop_item_game_genres);
            publisher = (TextView) itemView.findViewById(R.id.shop_item_game_publisher);
            price = (TextView) itemView.findViewById(R.id.shop_item_game_price);
            image = (ImageView) itemView.findViewById(R.id.shop_item_game_image);
        }

        @SuppressLint("DefaultLocale")
        public void bind(final Game game, final OnItemClickListener listener)
        {
            image.setImageBitmap(game.getImage());
            title.setText(game.getTitle());
            genres.setText(game.getGenres());
            publisher.setText(game.getPublisher());
            price.setText(String.format("%.2f ₽", game.getPrice()));

            itemView.setOnClickListener(new View.OnClickListener()
            {
                @Override public void onClick(View v)
                {
                    listener.onItemClick(game);
                }
            });
        }
    }
}
