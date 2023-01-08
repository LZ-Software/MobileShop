DROP ROLE IF EXISTS admin;
DROP ROLE IF EXISTS publisher;
DROP ROLE IF EXISTS "user";
DROP ROLE IF EXISTS reg_master;

CREATE ROLE admin WITH CREATEROLE ;
CREATE ROLE publisher;
CREATE ROLE "user";
CREATE ROLE reg_master WITH CREATEROLE LOGIN PASSWORD 'tbhrbjevkerpo112vervcwqcwce';

GRANT USAGE ON SCHEMA public to admin;
GRANT ALL ON ALL TABLES IN SCHEMA public TO admin;
GRANT ALL ON ALL FUNCTIONS IN SCHEMA public TO admin;
GRANT ALL ON ALL PROCEDURES IN SCHEMA public TO admin;
GRANT ALL ON ALL SEQUENCES IN SCHEMA public to admin;

GRANT SELECT ON get_games TO "user";
GRANT SELECT ON get_user_info TO "user";
GRANT SELECT ON get_countries TO "user";
GRANT SELECT ON get_cities TO "user";
GRANT USAGE ON SEQUENCE game_purchase_id_seq TO "user";
GRANT USAGE ON SEQUENCE user_library_id_seq TO "user";
GRANT USAGE ON SEQUENCE images_id_seq TO "user";
GRANT INSERT ON images TO "user",publisher;
GRANT SELECT ON user_login TO "user";
GRANT UPDATE ON user_login TO "user";
GRANT SELECT ON user_info TO "user";
GRANT UPDATE ON user_info TO "user";
GRANT SELECT ON user_library TO "user";
GRANT SELECT ON role TO "user";
GRANT SELECT ON images TO "user";
GRANT UPDATE ON images TO "user";
GRANT SELECT ON game TO "user";
GRANT SELECT ON publisher TO "user";
GRANT SELECT ON genre TO "user";
GRANT SELECT ON game_genre TO "user";
GRANT SELECT ON country TO "user";
GRANT SELECT ON city TO "user";
GRANT INSERT ON user_library TO "user";
GRANT SELECT ON game_purchase TO "user";
GRANT INSERT ON game_purchase TO "user";

GRANT USAGE ON SEQUENCE user_login_id_seq TO reg_master;
GRANT USAGE ON SEQUENCE user_info_id_seq TO reg_master;
GRANT usage ON SEQUENCE  user_role_id_seq TO reg_master;
GRANT SELECT ON get_countries TO reg_master;
GRANT SELECT ON user_login TO reg_master;
GRANT INSERT ON user_login TO reg_master;
GRANT SELECT ON user_info TO reg_master;
GRANT INSERT ON user_info TO reg_master;
GRANT SELECT ON user_role TO reg_master;
GRANT INSERT ON user_role TO reg_master;
GRANT SELECT ON role TO reg_master;
GRANT SELECT ON country TO reg_master;
GRANT SELECT ON city TO reg_master;

GRANT SELECT ON get_games TO publisher;
GRANT SELECT ON get_user_info TO publisher;
GRANT SELECT ON get_countries TO publisher;
GRANT SELECT ON get_cities TO publisher;
GRANT SELECT ON get_publishers TO publisher;
GRANT USAGE ON SEQUENCE game_purchase_id_seq TO publisher;
GRANT USAGE ON SEQUENCE user_library_id_seq TO publisher;
GRANT SELECT ON user_login TO publisher;
GRANT UPDATE ON user_login TO publisher;
GRANT SELECT ON user_info TO publisher;
GRANT UPDATE ON user_info TO publisher;
GRANT SELECT ON user_library TO publisher;
GRANT SELECT ON user_role TO publisher;
GRANT UPDATE ON publisher TO publisher;
GRANT SELECT ON role TO publisher;
GRANT SELECT ON images TO publisher;
GRANT UPDATE ON images TO publisher;
GRANT SELECT ON game TO publisher;
GRANT SELECT ON publisher TO publisher;
GRANT SELECT ON genre TO publisher;
GRANT SELECT ON game_genre TO publisher;
GRANT SELECT ON country TO publisher;
GRANT SELECT ON city TO publisher;
GRANT SELECT ON user_library TO publisher;
GRANT INSERT ON user_library TO publisher;
GRANT SELECT ON game_purchase TO publisher;
GRANT INSERT ON game_purchase TO publisher;

ALTER TABLE user_login ENABLE ROW LEVEL SECURITY;
ALTER TABLE user_info ENABLE ROW LEVEL SECURITY;
ALTER TABLE user_role ENABLE ROW LEVEL SECURITY;
ALTER TABLE role ENABLE ROW LEVEL SECURITY;
ALTER TABLE images ENABLE ROW LEVEL SECURITY;
ALTER TABLE game ENABLE ROW LEVEL SECURITY;
ALTER TABLE publisher ENABLE ROW LEVEL SECURITY;
ALTER TABLE genre ENABLE ROW LEVEL SECURITY;
ALTER TABLE game_genre ENABLE ROW LEVEL SECURITY;
ALTER TABLE user_library ENABLE ROW LEVEL SECURITY;
ALTER TABLE country ENABLE ROW LEVEL SECURITY;
ALTER TABLE city ENABLE ROW LEVEL SECURITY;
ALTER TABLE game_purchase ENABLE ROW LEVEL SECURITY;

CREATE POLICY adminAll ON user_login FOR All TO admin
USING (true);

CREATE POLICY adminAll ON user_info FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON user_role FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON user_library FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON role FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON images FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON game FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON publisher FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON genre FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON game_genre FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON country FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON city FOR ALL TO admin
USING (true);

CREATE POLICY adminAll ON game_purchase FOR ALL TO admin
USING (true);

CREATE POLICY select_id ON user_login FOR SELECT TO "user"
USING
(
    LOWER(username) = current_user
);

CREATE POLICY update_user_login ON user_login FOR UPDATE TO "user", publisher
USING
(
    LOWER(username) = current_user
)WITH CHECK (true);

CREATE POLICY select_user_info ON user_info FOR SELECT TO "user", publisher
USING
(true);

CREATE POLICY update_user_info ON user_info FOR UPDATE TO "user", publisher
USING
(true)WITH CHECK (true);

CREATE POLICY select_user_library ON user_library FOR SELECT TO "user", publisher
USING
(
    (SELECT LOWER(username) FROM user_login WHERE user_login.id = user_library.user_id) = current_user
);

CREATE POLICY select_role ON role FOR SELECT TO "user"
USING
(
  name = 'user'
);

CREATE POLICY select_role_publisher ON role FOR SELECT TO publisher
USING(true);

CREATE POLICY select_user_role ON user_role FOR SELECT TO publisher
USING (true);

CREATE POLICY insert_user_role ON user_role FOR INSERT TO reg_master
WITH CHECK (true);


CREATE POLICY select_image ON images FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY update_image ON images FOR UPDATE TO "user",publisher
USING (true);

CREATE POLICY select_game ON game FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY select_publisher ON publisher FOR SELECT TO "user"
USING (true);

CREATE POLICY select_genre ON genre FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY select_game_genre ON game_genre FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY select_country ON country FOR SELECT TO "user", reg_master,publisher
USING (true);

CREATE POLICY select_city ON city FOR SELECT TO "user", reg_master,publisher
USING (true);

CREATE POLICY select_user_library_user ON user_library FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY insert_user_library_user ON user_library FOR INSERT TO "user",publisher
WITH CHECK (true);

CREATE POLICY select_game_purchase_user ON game_purchase FOR SELECT TO "user",publisher
USING (true);

CREATE POLICY insert_game_purchase_user ON game_purchase FOR INSERT TO "user",publisher
WITH CHECK (true);

CREATE POLICY select_user_login ON user_login FOR SELECT TO reg_master
USING (true);

CREATE POLICY insert_user_login ON user_login FOR INSERT TO reg_master
WITH CHECK (true);

CREATE POLICY insert_user_info ON user_info FOR INSERT TO reg_master
WITH CHECK (true);

CREATE POLICY select_role_reg_master ON role FOR SELECT TO reg_master
USING
(
  name = 'user'
);

CREATE POLICY select_user_info_reg_master ON user_info FOR SELECT TO reg_master
USING (true);

CREATE POLICY select_user_role_reg_master ON user_role FOR SELECT TO reg_master
USING (true);

CREATE POLICY select_user_login_publisher ON user_login FOR SELECT TO publisher
USING
(
  LOWER(username) = current_user
);

CREATE POLICY select_on_publishers ON publisher FOR SELECT  TO  publisher
USING
(true);

CREATE POLICY update_on_publishers ON publisher FOR UPDATE  TO  publisher
WITH CHECK (true);

CREATE POLICY insert_image ON images FOR INSERT TO "user", publisher
WITH CHECK (true);
