CREATE OR REPLACE FUNCTION bytea_import(p_path TEXT, p_result OUT BYTEA)
LANGUAGE plpgsql AS
$$
DECLARE
  l_oid oid;
BEGIN
  SELECT lo_import(p_path) into l_oid;
  SELECT lo_get(l_oid) INTO p_result;
  PERFORM lo_unlink(l_oid);
END;
$$;

CREATE OR REPLACE FUNCTION get_county_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM country WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_city_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM city WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_user_id_by_login(login VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM user_login WHERE username = login;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_role_id(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM role WHERE name = title;
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_publisher_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM publisher WHERE LOWER(name) = LOWER(title);
    RETURN ret;
END
$func$;

CREATE OR REPLACE FUNCTION get_game_id_by_title(title VARCHAR)
RETURNS INTEGER
LANGUAGE plpgsql AS
$func$
DECLARE ret INTEGER;
BEGIN
    SELECT id into ret FROM game WHERE LOWER(name) = LOWER(title);
    RETURN ret;
END
$func$;