CREATE VIEW get_countries AS
    SELECT name FROM country;

CREATE VIEW get_cities AS
    SELECT name FROM city;

CREATE VIEW get_genres AS
    SELECT name FROM genre;

CREATE VIEW get_publishers AS
    SELECT name FROM publisher;

CREATE VIEW get_publisher_with_country AS
    SELECT p.name AS publisher, c.name AS country FROM publisher p
    JOIN country c on c.id = p.country_id;

CREATE VIEW get_games AS
    SELECT g.id AS id, g.name AS game, g.description,p.name as publisher, g.price, string_agg(gn.name, ', ')::VARCHAR AS genres, i.image FROM game g
    JOIN publisher p ON g.publisher_id = p.id
    JOIN game_genre gr ON g.id = gr.game_id
    JOIN genre gn ON gr.genre_id = gn.id
    JOIN images i ON g.image_id = i.id GROUP BY g.id, g.name,g.description, p.name, g.price, i.image;