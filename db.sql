CREATE TABLE IF NOT EXISTS user_login
(
    id SERIAL PRIMARY KEY NOT NULL,
    username VARCHAR(128) NOT NULL UNIQUE,
    password VARCHAR(256) NOT NULL
);

CREATE TABLE IF NOT EXISTS user_info
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    user_id INTEGER REFERENCES user_login(id) ON DELETE CASCADE NOT NULL UNIQUE,
    first_name VARCHAR(128) NOT NULL,
    last_name VARCHAR(128) NULL,
    country VARCHAR(128) NULL,
    city VARCHAR(128) NULL,
    image bytea NULL
);

-- Admin, Publisher, User
CREATE TABLE IF NOT EXISTS role
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    name VARCHAR(128) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS user_role
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    person_id INTEGER REFERENCES user_login(id) ON DELETE CASCADE NOT NULL UNIQUE,
    role_id INTEGER REFERENCES role(id) ON DELETE RESTRICT NOT NULL
);

CREATE TABLE IF NOT EXISTS publisher
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    name VARCHAR(128) NOT NULL UNIQUE,
    country VARCHAR(128) NOT NULL
);

CREATE TABLE IF NOT EXISTS game
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    name VARCHAR(128) NOT NULL UNIQUE,
    description VARCHAR(2048) NOT NULL,
    price MONEY NOT NULL,
    publisher_id INTEGER REFERENCES publisher(id) ON DELETE CASCADE NOT NULL,
    dt_release TIMESTAMP NOT NULL
);

CREATE TABLE NOT EXISTS game_purchase
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    game_id INTEGER REFERENCES game(id) ON DELETE NO ACTION NOT NULL,
    dt_created TIMESTAMP NOT NULL,
    timestamp TIMESTAMP NULL
);

CREATE TABLE NOT EXISTS user_library
(
    id SERIAL PRIMARY KEY NOT NULL UNIQUE,
    user_id INTEGER REFERENCES user_login(id) ON DELETE CASCADE NOT NULL,
    game_id INTEGER REFERENCES game(id) ON DELETE CASCADE NOT NULL
);

