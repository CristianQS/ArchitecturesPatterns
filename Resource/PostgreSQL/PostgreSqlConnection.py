import psycopg2

class PostgreSqlConnection:

    def __init__(self,database, user, password, host):
    	    self.connection = psycopg2.connect(
            database=database,
            user=user,
            password=password,
            host=host
        )
    def CloseConnection(self):
        self.connection.close()
	
    def CreateDatabase(self,databaseName):
        self.connection.autocommit = True
        print('...........Creating Database.............')
        cursor = self.connection.cursor()
        cursor.execute(f'DROP DATABASE IF EXISTS {databaseName}')
        cursor.execute(f'CREATE DATABASE {databaseName}')
        self.connection.commit()
        print('...........Creation Done.............')
        cursor.close()

    def CreateTrainingTable(self):
        self.connection.autocommit = True
        print('...........Creating Tables.............')
        cur = self.connection.cursor()
        cur.execute("CREATE TABLE IF NOT EXISTS training (id serial PRIMARY KEY, name varchar, description varchar,datetime date, createdBy varchar);")
        self.connection.commit()
        print('...........Creation Done.............')
        cur.close()

    def InsertATraining(self,name, description,datetime,createdBy):
        cur = self.connection.cursor()
        cur.execute("INSERT INTO training (name,description,datetime,createdBy) VALUES (%s, %s, %s, %s)", (name, description,datetime,createdBy))
        cur.execute("SELECT * FROM training;")
        result = cur.fetchone()
