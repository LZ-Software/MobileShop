CREATE VIEW get_countries AS
    SELECT name FROM country;

CREATE VIEW get_genres AS
    SELECT name FROM genre;

CREATE VIEW get_publishers AS
    SELECT name FROM publisher;

CREATE VIEW get_games AS
    SELECT g.name, g.price, i.image FROM game g
    JOIN images i on g.image_id = i.id;
