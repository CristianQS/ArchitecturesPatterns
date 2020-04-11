import psycopg2
conn = psycopg2.connect(
    user='admin',
    password='admin',
    host='resource_db_1'
    )
conn.autocommit = True
print('...........Creating Database.............')
cur = conn.cursor()
cur.execute('DROP DATABASE IF EXISTS python_db')
cur.execute('CREATE DATABASE python_db')
conn.commit()
cur.close()
conn.close()


conn = psycopg2.connect(
    database='python_db',
    user='admin',
    password='admin',
    host='resource_db_1'
    )
conn.autocommit = True
print('...........Creating Tables.............')
cur = conn.cursor()
cur.execute("CREATE TABLE IF NOT EXISTS training (id serial PRIMARY KEY, name varchar, description varchar,datetime date, createdBy varchar);")
cur.execute("INSERT INTO training (name,description,datetime,createdBy) VALUES (%s, %s, %s, %s)", ("training 1", "ADescription",'2017-04-30',"123"))
cur.execute("SELECT * FROM training;")
result = cur.fetchone()
print(result)
conn.commit()
cur.close()
conn.close()
