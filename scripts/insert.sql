INSERT INTO images(id, image)
VALUES (1, '013d7d16d7ad4fefb61bd95b765c8ceb');

INSERT INTO role(name)
VALUES ('admin'),
       ('publisher'),
       ('user');

INSERT INTO country(name)
VALUES ('Russia'),
       ('USA');

INSERT INTO city(name, country_id)
VALUES ('Moscow', get_county_id('USA'));

INSERT INTO user_login(username, password)
VALUES ('Xboct', crypt('frevrvrvtbtbe', gen_salt('md5')));

INSERT INTO user_info(user_id, first_name, last_name, location_id, image_id)
VALUES (get_user_id_by_login('Xboct'), 'Sasha', 'Dashkevich', get_city_id('Moscow'), 1);

INSERT INTO user_role(person_id, role_id)
VALUES (get_user_id_by_login('Xboct'), get_role_id('user'));

INSERT INTO publisher(name, country_id)
VALUES ('Valve', get_county_id('USA'));

INSERT INTO game(name, description, price, publisher_id, dt_release, image_id)
VALUES('Dota 2', 'Cool game', 1000, get_publisher_id_by_title('valve'), '12.05.2015', 1);

INSERT INTO user_library(user_id, game_id)
VALUES (get_user_id_by_login('Xboct'), get_game_id_by_title('dota 2'));

