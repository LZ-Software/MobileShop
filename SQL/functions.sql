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

CREATE OR REPLACE FUNCTION get_role_by_login(title VARCHAR)
RETURNS VARCHAR
LANGUAGE plpgsql AS
$func$
DECLARE ret VARCHAR;
BEGIN
    SELECT r.name INTO ret FROM user_login ul
    JOIN user_role ur ON ul.id = ur.person_id
    JOIN role r ON r.id = ur.role_id
    WHERE ul.username = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_user_info_by_id(user_id INTEGER)
RETURNS TABLE(username_text VARCHAR, name_text VARCHAR, last_name_text VARCHAR, image_base64 TEXT)
LANGUAGE plpgsql AS
$func$
DECLARE
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT ul.username, ui.first_name, ui.last_name, i.image FROM user_login ul
    JOIN user_info ui on ul.id = ui.user_id
    JOIN images i on i.id = ui.image_id
    WHERE ul.id = %L', user_id);
END
$func$;

CREATE OR REPLACE FUNCTION get_game_by_title(title VARCHAR)
RETURNS TABLE(g_id INTEGER, g_name VARCHAR, g_description VARCHAR, p_name VARCHAR, price FLOAT, release_date TIMESTAMP, genres VARCHAR, image_base64 TEXT)
LANGUAGE plpgsql AS
$func$
DECLARE
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT * FROM get_games WHERE game = %L', title);
END
$func$;

CREATE OR REPLACE FUNCTION check_game_in_user_library(user_login_id INTEGER, game_in_library_id INTEGER)
RETURNS BOOLEAN
LANGUAGE plpgsql AS
$$
DECLARE
    ret BOOLEAN;
BEGIN
    IF(SELECT COUNT(*) FROM user_library WHERE user_id = user_login_id AND game_id= game_in_library_id) THEN
        ret = true;
    ELSE
        ret = false;
    END IF;
    RETURN ret;
END
$$;

CREATE OR REPLACE FUNCTION get_publisher_by_title(title VARCHAR)
RETURNS TABLE(p_name VARCHAR, c_name VARCHAR)
LANGUAGE plpgsql AS
$func$
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT * FROM get_publishers WHERE p_name = %L', title);
END
$func$;

CREATE OR REPLACE FUNCTION get_publisher_user_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT ul.id INTO ret FROM user_login ul
    JOIN publisher p on ul.id = p.user_id
    WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_country_by_id(c_id INTEGER)
RETURNS VARCHAR
LANGUAGE plpgsql AS
$func$
DECLARE ret VARCHAR;
BEGIN
    SELECT name INTO ret FROM country WHERE id= c_id;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_city_by_id(c_id INTEGER)
RETURNS VARCHAR
LANGUAGE plpgsql AS
$func$
DECLARE ret VARCHAR;
BEGIN
    SELECT name INTO ret FROM city WHERE id= c_id;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_games_by_user_id(u_id INTEGER)
RETURNS TABLE(g_id INTEGER, g_name VARCHAR, g_description VARCHAR, p_name VARCHAR, price FLOAT, genres VARCHAR, image_base64 TEXT)
LANGUAGE plpgsql AS
$func$
DECLARE
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT ul.id, g.name, g.description, p.name, g.price, string_agg(g2.name, '', '')::VARCHAR, i.image FROM user_library ul
                                JOIN game g on g.id = ul.game_id
                                JOIN publisher p on g.publisher_id = p.id
                                JOIN game_genre gg on g.id = gg.game_id
                                JOIN genre g2 on gg.genre_id = g2.id
                                JOIN images i on g.image_id = i.id WHERE ul.user_id = %L GROUP BY ul.id, g.name, g.description, p.name, g.price, i.image;', u_id);
END
$func$;

CREATE OR REPLACE FUNCTION get_user_info_by_user_id(u_id INTEGER)
RETURNS TABLE(ul_id INTEGER,username VARCHAR, first_name VARCHAR, last_name VARCHAR, country VARCHAR, city VARCHAR, image TEXT)
LANGUAGE plpgsql AS
$func$
BEGIN
    RETURN QUERY EXECUTE FORMAT('SELECT * FROM get_user_info WHERE id = %L', u_id);
END
$func$;
