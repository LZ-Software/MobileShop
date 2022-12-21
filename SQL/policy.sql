DROP ROLE IF EXISTS admin;
DROP ROLE IF EXISTS publisher;
DROP ROLE IF EXISTS "user";
DROP ROLE IF EXISTS auth;

CREATE ROLE admin;
CREATE ROLE publisher;
CREATE ROLE "user";
CREATE ROLE auth WITH CREATEROLE;

GRANT USAGE ON SCHEMA public to admin;
GRANT ALL ON ALL TABLES IN SCHEMA public TO admin;
GRANT ALL ON ALL FUNCTIONS IN SCHEMA public TO admin;
GRANT ALL ON ALL PROCEDURES IN SCHEMA public TO admin;
GRANT ALL ON ALL SEQUENCES IN SCHEMA public to admin;