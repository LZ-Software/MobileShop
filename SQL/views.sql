CREATE VIEW get_countries AS
    SELECT name FROM country;

CREATE VIEW get_cities AS
    SELECT ct.name AS City, ctr.name AS Country FROM city ct
    JOIN country ctr on ct.country_id = ctr.id;

CREATE VIEW get_publisher AS
    SELECT p.name AS Publisher, c.name AS Country FROM publisher p
    JOIN country c on c.id = p.country_id;

CREATE VIEW get_games As
    SELECT g.name AS Title, g.description, g.price, p.name AS Publisher, g.dt_release, img.image FROM game g
    JOIN publisher p on g.publisher_id = p.id
    JOIN images img on img.id = g.image_id;