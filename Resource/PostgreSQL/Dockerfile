FROM python:3.6
RUN pip install psycopg2
COPY "seed.py" "./seed.py"
COPY "PostgreSqlConnection.py" "./PostgreSqlConnection.py"
CMD ["python","./seed.py"]