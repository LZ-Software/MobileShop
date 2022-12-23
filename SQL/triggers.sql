CREATE TRIGGER check_for_duplicates
    BEFORE INSERT OR UPDATE on genre
    FOR EACH ROW EXECUTE FUNCTION check_for_duplicates();

CREATE OR REPLACE FUNCTION check_for_duplicates() RETURNS TRIGGER AS
$$BEGIN
    IF(0 = (SELECT COUNT(*) FROM genre WHERE name = NEW.name)) THEN
        RETURN NEW;
    ELSE RAISE EXCEPTION 'Такой жанр уже есть в базе данных';
    END IF;
END
$$ LANGUAGE plpgsql;