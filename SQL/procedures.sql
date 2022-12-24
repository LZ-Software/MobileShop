CREATE OR REPLACE PROCEDURE create_user(login VARCHAR(128), password_text VARCHAR(256), first_name_text VARCHAR(128), last_name_text VARCHAR(128), country TEXT, city TEXT)
AS $$
DECLARE
    id_login INTEGER;
    id_info INTEGER;
    id_role INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM user_login WHERE username = login) THEN
        RAISE EXCEPTION 'Такой пользователь уже существует';
    ELSE
        INSERT INTO user_login(username, password) VALUES (login, crypt(password_text, gen_salt('md5'))) RETURNING id INTO id_login;
        INSERT INTO user_info(user_id, first_name, last_name, country_id, city_id, image_id)
        VALUES (get_user_id_by_login(login), first_name_text, last_name_text, get_county_id(country), get_city_id(city), 1) RETURNING id INTO id_info;
        INSERT INTO user_role(person_id, role_id) VALUES (get_user_id_by_login(login), get_role_id('user')) RETURNING id INTO id_role;
        EXECUTE format('CREATE USER %I WITH ENCRYPTED PASSWORD %L', LOWER(login), password_text::VARCHAR);
        EXECUTE format('GRANT "user" to %I', LOWER(login));
        IF (id_info IS NULL OR id_login IS NULL OR id_role IS NULL) THEN
            RAISE EXCEPTION 'Что-то пошло не так, попробуйте снова';
        ELSE
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE create_publisher(title VARCHAR(128), country TEXT, login VARCHAR(128), password_text VARCHAR(256), first_name_text VARCHAR(128), last_name_text VARCHAR(128), city TEXT)
AS $$
DECLARE
    id_publisher INTEGER;
    id_login INTEGER;
    id_info INTEGER;
    id_role INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM publisher WHERE name = title) THEN
        RAISE EXCEPTION 'Такой издатель уже существует';
    ELSE
        INSERT INTO user_login(username, password) VALUES (login, crypt(password_text, gen_salt('md5'))) RETURNING id INTO id_login;
        INSERT INTO user_info(user_id, first_name, last_name, country_id, city_id, image_id)
        VALUES (get_user_id_by_login(login), first_name_text, last_name_text, get_county_id(country), get_city_id(city), 1) RETURNING id INTO id_info;
        INSERT INTO user_role(person_id, role_id) VALUES (get_user_id_by_login(login), get_role_id('publisher')) RETURNING id INTO id_role;
        INSERT INTO publisher(name, country_id, user_id) VALUES (title, get_county_id(country), id_login) RETURNING id INTO id_publisher;
        EXECUTE format('CREATE USER %I WITH PASSWORD %L', LOWER(login), password_text::VARCHAR);
        EXECUTE format('GRANT publisher to %I', LOWER(login));
        IF (id_publisher IS NULL OR id_login IS NULL OR id_info IS NULL OR id_role IS NULL) THEN
            RAISE EXCEPTION 'Что-то пошло не так, попробуйте снова';
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE create_game(name_text VARCHAR(128), description_text VARCHAR(2048), price_text FLOAT, publisher_text VARCHAR(128), date_release TIMESTAMP, image_base64 TEXT)
AS $$
DECLARE
    image_id_ret INTEGER;
    game_id_ret INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM game WHERE name = name_text) THEN
        RAISE EXCEPTION 'Такая игра уже существует';
    ELSE
        INSERT INTO images(image) VALUES (image_base64) RETURNING id INTO image_id_ret;
        INSERT INTO game(name, description, price, publisher_id, dt_release, image_id) VALUES (name_text, description_text, price_text, get_publisher_id_by_title(publisher_text), date_release, image_id_ret) RETURNING id into game_id_ret;
        IF (image_id_ret IS NULL OR game_id_ret IS NULL) THEN
            RAISE EXCEPTION 'Что-то пошло не так, попробуйте снова';
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE create_genre(title VARCHAR(128))
AS $$
DECLARE
    genre_id_ret INTEGER;
BEGIN
    INSERT INTO genre(name) VALUES (title) RETURNING id INTO genre_id_ret;
    IF(genre_id_ret IS NULL) THEN
        RAISE EXCEPTION 'Что-то пошло не так';
    END IF;

END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE game_purchase_procedure(u_id INTEGER, g_id INTEGER)
AS $$
DECLARE
    id_p INTEGER;
BEGIN
    INSERT INTO game_purchase(game_id, user_id, timestamp) VALUES (g_id, u_id, now()) RETURNING id INTO id_p;
    IF (id_p IS NULL) THEN
        RAISE EXCEPTION 'Покупка не прошла';
    ELSE
        INSERT INTO user_library(user_id, game_id) VALUES (u_id, g_id);
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE update_publisher(p_name VARCHAR, c_name VARCHAR, p_name_original VARCHAR)
AS $$
DECLARE
    count INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM publisher WHERE name = p_name) THEN
        RAISE EXCEPTION 'Такой издатель уже существует';
    ELSE
        UPDATE publisher
        SET name = p_name,
            country_id = get_county_id(c_name)
        WHERE name = p_name_original;
        GET DIAGNOSTICS count = row_count;
        IF(count = 0) THEN
            RAISE EXCEPTION 'Что-то пошло не так';
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE update_user(u_id INTEGER, first_name_text VARCHAR, last_name_text VARCHAR, country_text VARCHAR, city_text VARCHAR)
AS $$
DECLARE
    count INTEGER;
BEGIN
    UPDATE user_info
    SET first_name = first_name_text,
        last_name = last_name_text,
        country_id = get_county_id(country_text),
        city_id = get_city_id(city_text)
    WHERE user_id = u_id;
    GET DIAGNOSTICS count = row_count;
    IF(count = 0) THEN
        RAISE EXCEPTION 'Что-то пошло не так';
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE update_image(user_id_in INTEGER, image_base64 TEXT)
AS $$
DECLARE
    new_id INTEGER;
    count INTEGER;
BEGIN
    INSERT INTO images(image)
    VALUES (image_base64) RETURNING id INTO new_id;
    UPDATE user_info
    SET image_id = new_id
    WHERE id = (SELECT ui.id FROM user_login ul JOIN user_info ui ON ul.id = ui.user_id WHERE ul.id = user_id_in);
    GET DIAGNOSTICS count = row_count;
    IF (count = 0) THEN
        RAISE EXCEPTION 'Что-то пошло не так';
    END IF;
END
$$LANGUAGE plpgsql;
