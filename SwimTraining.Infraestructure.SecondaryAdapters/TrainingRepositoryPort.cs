using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;
using Npgsql;

namespace SwimTraining.Infraestructure.SecondaryAdapters {
    public class TrainingRepositoryPostgresSqlAdapter : TrainingRepositoryPort {
        public Training Training1 = new Training("Training 1", "ADescription", new DateTime(2020, 1, 1), null, "1234");
        public Training Training2 = new Training("Training 2", "AnotherDescription", new DateTime(2020, 2, 2), null, "1234");
        public List<Training> Trainings = new List<Training>();

        public TrainingRepositoryPostgresSqlAdapter() {
        }

        public async Task<List<Training>> GetTrainingByUser(string userId) {
            Trainings.Add(Training1);
            Trainings.Add(Training2);
            //TODO Create Extension Method with Dapper
            //var connection =  new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            //await connection.OpenAsync();

            //var command = new NpgsqlCommand("SELECT name,description FROM training where createdBy=@userId", connection);
            //.Parameters.AddWithValue("userId", userId);
            //command.Prepare();

            //var reader =  await command.ExecuteReaderAsync();
            //var trainings = reader.Cast<dynamic>().ToList();

            //list.CreateObjRef(typeof(Training));
            return Trainings;
        }

        public async Task CreateTraining(Training training) {
            var connection =  new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            await connection.OpenAsync();

            var command = new NpgsqlCommand("INSERT INTO training(name, description, datetime, createdBy) VALUES(@name, @description, @datetime, @createdBy)", connection);
            command.Parameters.AddWithValue("name", training.Name);
            command.Parameters.AddWithValue("description", training.Description);
            command.Parameters.AddWithValue("datetime", training.Date);
            command.Parameters.AddWithValue("createdBy", training.CreatedBy);
            command.Prepare();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<Training> UpdateTraining(Training training, int trainingId) {
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            await connection.OpenAsync();

            var command = new NpgsqlCommand("Update training Set name=@name, description=@description, datetime=@datetime, createdBy=@createdBy where id=@trainingId", connection);
            command.Parameters.AddWithValue("name", training.Name);
            command.Parameters.AddWithValue("description", training.Description);
            command.Parameters.AddWithValue("datetime", training.Date);
            command.Parameters.AddWithValue("createdBy", training.CreatedBy);
            command.Parameters.AddWithValue("trainingId", trainingId);
            command.Prepare();
            await command.ExecuteNonQueryAsync();
            return null;
        }
    }
}