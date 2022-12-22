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
        EXECUTE format('CREATE USER %I WITH PASSWORD %L', LOWER(login), password_text::VARCHAR);
        EXECUTE format('GRANT "user" to %I', LOWER(login));
        COMMIT;
        IF (id_info IS NULL OR id_login IS NULL OR id_role IS NULL) THEN
            RAISE EXCEPTION 'Что-то пошло не так, попробуйте снова';
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;

CREATE OR REPLACE PROCEDURE create_publisher(title VARCHAR(128), country TEXT)
AS $$
DECLARE
    id_publisher INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM publisher WHERE name = title) THEN
        RAISE EXCEPTION 'Такой издатель уже существует';
    ELSE
        INSERT INTO publisher(name, country_id) VALUES (title, get_county_id(country)) RETURNING id INTO id_publisher;
        COMMIT;
        IF (id_publisher IS NULL) THEN
            RAISE EXCEPTION 'Что-то пошло не так, попробуйте снова';
        END IF;
    END IF;
END
$$LANGUAGE plpgsql;
