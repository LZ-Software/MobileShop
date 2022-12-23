CREATE VIEW get_countries AS
    SELECT name FROM country;

CREATE VIEW get_cities AS
    SELECT name FROM city;

CREATE VIEW get_genres AS
    SELECT name FROM genre;

CREATE VIEW get_publishers AS
    SELECT p.name AS p_name, c.name AS c_name FROM publisher p
    JOIN country c on c.id = p.country_id;

CREATE VIEW get_games AS
    SELECT g.id AS id, g.name AS game, g.description,p.name as publisher, g.price, g.dt_release, string_agg(gn.name, ', ')::VARCHAR AS genres, i.image FROM game g
    JOIN publisher p ON g.publisher_id = p.id
    JOIN game_genre gr ON g.id = gr.game_id
    JOIN genre gn ON gr.genre_id = gn.id
    JOIN images i ON g.image_id = i.id GROUP BY g.id, g.name,g.description, p.name, g.price, i.image;

CREATE VIEW get_user_info AS
    SELECT ul.id as id, ul.username AS username, ui.first_name AS name, ui.last_name AS last_name, c.name AS country, c2.name AS city, i.image AS image FROM user_login ul
    JOIN user_info ui ON ul.id = ui.user_id
    JOIN country c ON ui.country_id = c.id
    JOIN city c2 ON c2.id = ui.city_id
    JOIN images i ON i.id = ui.image_id;
