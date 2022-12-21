CREATE OR REPLACE FUNCTION get_county_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM country WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_city_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM city WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_user_id_by_login(login VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM user_login WHERE username = login;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_role_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM role WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_publisher_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM publisher WHERE LOWER(name) = LOWER(title);
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_game_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM game WHERE LOWER(name) = LOWER(title);
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_genre_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id INTO ret FROM genre WHERE LOWER(name) = LOWER(title);
    RETURN ret;
END
$func$;
