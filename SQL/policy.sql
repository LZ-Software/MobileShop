DROP ROLE IF EXISTS admin;
DROP ROLE IF EXISTS publisher;
DROP ROLE IF EXISTS "user";
DROP ROLE IF EXISTS auth;

CREATE ROLE admin;
CREATE ROLE publisher;
CREATE ROLE "user";

GRANT USAGE ON SCHEMA public to admin;
GRANT ALL ON ALL TABLES IN SCHEMA public TO admin;
GRANT ALL ON ALL FUNCTIONS IN SCHEMA public TO admin;
GRANT ALL ON ALL PROCEDURES IN SCHEMA public TO admin;
GRANT ALL ON ALL SEQUENCES IN SCHEMA public to admin;


GRANT SELECT ON user_login TO "user";
GRANT SELECT ON user_info TO "user";
GRANT UPDATE ON user_info TO "user";
GRANT SELECT ON images TO "user";
GRANT UPDATE ON images TO "user";
GRANT SELECT ON game TO "user";

ALTER TABLE user_login ENABLE ROW LEVEL SECURITY;
ALTER TABLE user_info ENABLE ROW LEVEL SECURITY;
ALTER TABLE images ENABLE ROW LEVEL SECURITY;
ALTER TABLE game ENABLE ROW LEVEL SECURITY;

CREATE POLICY adminAll ON user_login FOR All TO admin
USING (true);

CREATE POLICY adminAll ON user_info FOR ALL TO admin
USING (true);

CREATE POLICY select_id ON user_login FOR SELECT TO "user"
USING
(
  LOWER(username) = current_user
);

CREATE POLICY select_user_info ON user_info FOR SELECT TO "user"
USING
(
  (SELECT LOWER(username) FROM user_login  WHERE  user_login.id = user_info.user_id) = current_user
);

CREATE POLICY update_user_info ON user_info FOR UPDATE TO "user"
USING
(
    (SELECT LOWER(username) FROM user_login  WHERE  user_login.id = user_info.user_id) = current_user
);

CREATE POLICY select_image ON images FOR SELECT TO "user"
USING (true);

CREATE POLICY update_image ON images FOR UPDATE TO "user"
USING (true);

CREATE POLICY select_game ON game FOR SELECT TO "user"
USING (true);
