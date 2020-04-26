from PostgreSqlConnection import PostgreSqlConnection

conn = PostgreSqlConnection('','admin','admin','resource_db_1')
conn.CreateDatabase('python_db')
conn.CloseConnection()

conn = PostgreSqlConnection('python_db','admin','admin','resource_db_1')
conn.CreateTrainingTable()
conn.InsertATraining("training 1", "ADescription",'2017-04-30',"123")
conn.CloseConnection()


