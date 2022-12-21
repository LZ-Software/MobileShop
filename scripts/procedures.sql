CREATE OR REPLACE PROCEDURE create_user(login VARCHAR(128), password_text VARCHAR(256), name VARCHAR(128), last_name_text VARCHAR(128), location TEXT, image TEXT)
AS $$
DECLARE
BEGIN
    IF(SELECT COUNT(*) FROM user_login WHERE username = login) THEN
        RAISE EXCEPTION 'Такой пользователь уже существует';
    ELSE
        INSERT INTO user_login(username, password) VALUES (login, crypt(password_text, gen_salt('md5')));
        INSERT INTO images(image) VALUES (bytea_import(image));
        INSERT INTO user_info(user_id, first_name, last_name, location_id, image_id)
        VALUES (get_user_id_by_login(login), name, last_name_text, get_city_id(location), 1);
        COMMIT;
    END IF;
END
$$LANGUAGE plpgsql;