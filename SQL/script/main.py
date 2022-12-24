import json
import psycopg2

from psycopg2.extras import execute_values

DB_HOST = ''
DB_PORT = ''
DB_NAME = ''
DB_USER = ''
DB_PASSWORD = ''


def process_input(json_in):
    used_countries = []
    used_cities = []
    output = {}
    for country, cities in json_in.items():
        if country not in used_countries:
            out_cities = []
            for city in cities:
                if city not in used_cities:
                    out_cities.append(city)
                    used_cities.append(city)
            output[country] = out_cities
            used_countries.append(country)
    return output


if __name__ == '__main__':
    with open('countries.json', 'r') as file:
        input_data = json.load(file)
    processed_data = process_input(input_data)
    print('Список обработан')
    try:
        conn = psycopg2.connect(f'host={DB_HOST} user={DB_USER} password={DB_PASSWORD} dbname={DB_NAME}')
        conn.autocommit = False
        cur = conn.cursor()
        for country, cities in processed_data.items():
            cur.execute('INSERT INTO country(name) VALUES(%s) RETURNING id', [country])
            country_id = cur.fetchone()[0]
            data = []
            for city in cities:
                data.append((city, country_id))
            execute_values(cur, 'INSERT INTO city(name, country_id) VALUES %s', data, template=None, page_size=100)
        conn.commit()
    except (Exception, psycopg2.DatabaseError) as error:
        print(error)
        conn.rollback()
    finally:
        if conn:
            cur.close()
            conn.close()
