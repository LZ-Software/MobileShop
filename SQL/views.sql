CREATE VIEW get_countries AS
    SELECT name FROM country;

CREATE VIEW get_cities AS
    SELECT name FROM city;

CREATE VIEW get_genres AS
    SELECT name FROM genre;

CREATE VIEW get_publishers AS
    SELECT name FROM publisher;

CREATE VIEW get_games AS
    SELECT g.name AS game, p.name as publisher, g.price, string_agg(gn.name, ', ') AS genres, i.image FROM game g
    JOIN publisher p ON g.publisher_id = p.id
    JOIN game_genre gr ON g.id = gr.game_id
    JOIN genre gn ON gr.genre_id = gn.id
    JOIN images i ON g.image_id = i.id GROUP BY g.name, p.name, g.price, i.image;