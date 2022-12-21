CREATE OR REPLACE PROCEDURE create_user(login VARCHAR(128), password_text VARCHAR(256), first_name_text VARCHAR(128), last_name_text VARCHAR(128), country TEXT, city TEXT, image_base64 TEXT)
AS $$
DECLARE
    img_id INTEGER;
BEGIN
    IF (SELECT COUNT(*) FROM user_login WHERE username = login) THEN
        RAISE EXCEPTION 'Такой пользователь уже существует';
    ELSE
        INSERT INTO user_login(username, password) VALUES (login, crypt(password_text, gen_salt('md5')));
        INSERT INTO images(image) VALUES (image_base64) RETURNING id INTO img_id;
        INSERT INTO user_info(user_id, first_name, last_name, country_id, city_id, image_id)
        VALUES (get_user_id_by_login(login), first_name_text, last_name_text, get_county_id(country), get_city_id(city), img_id);
        COMMIT;
    END IF;
END
$$LANGUAGE plpgsql;
