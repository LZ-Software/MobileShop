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

CREATE OR REPLACE FUNCTION auth_user_get_id(login_text VARCHAR, password_text VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE
    ret INTEGER;
BEGIN
    SELECT id INTO ret FROM user_login WHERE username = login_text AND password = crypt(password_text, password);
    IF (ret = 0) THEN
    RAISE EXCEPTION 'Неверные данные';
    ELSE
        RETURN ret;
    END IF;
END
$func$;

CREATE OR REPLACE FUNCTION get_cities_by_country(title VARCHAR)
RETURNS TABLE(name_city VARCHAR)
LANGUAGE plpgsql AS
$func$
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT c.name FROM city c
    JOIN country c2 on c2.id = c.country_id WHERE c2.name = %L', title);
END
$func$;
