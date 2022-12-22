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

ALTER TABLE user_login ENABLE ROW LEVEL SECURITY;

CREATE POLICY adminAll ON user_login FOR All TO admin
USING (true);

CREATE POLICY select_id ON user_login FOR SELECT TO "user"
USING
(
  LOWER(username) = current_user
);

