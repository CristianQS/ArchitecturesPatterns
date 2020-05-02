using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Database;
using Npgsql;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Infraestructure.SecondaryAdapters {
    public class TrainingRepositoryPostgresSqlAdapter : TrainingRepositoryPort {
        private readonly ConnectionProvider connectionProvider;

        public TrainingRepositoryPostgresSqlAdapter(ConnectionProvider connectionProvider) {
            this.connectionProvider = connectionProvider;
        }

        public async Task<List<Training>> GetTrainingByUser(string createdBy) {
            await connectionProvider.EstablishConnection();
            var trainings = connectionProvider.Query<Training>("SELECT name,description,datetime,createdBy FROM training where createdBy=@createdBy", new {@createdBy = createdBy });
            //connectionProvider.Close();
            return trainings.ToList();
        }

        public async Task CreateTraining(Training training)
        {
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            await connection.OpenAsync();

            var command = new NpgsqlCommand("INSERT INTO training(name, description, datetime, createdBy) VALUES(@name, @description, @datetime, @createdBy)", connection);
            command.Parameters.AddWithValue("name", training.Name);
            command.Parameters.AddWithValue("description", training.Description);
            command.Parameters.AddWithValue("datetime", training.DateTime);
            command.Parameters.AddWithValue("createdBy", training.CreatedBy);
            command.Prepare();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<Training> UpdateTraining(Training training, int trainingId)
        {
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            await connection.OpenAsync();

            var command = new NpgsqlCommand("Update training Set name=@name, description=@description, datetime=@datetime, createdBy=@createdBy where id=@trainingId", connection);
            command.Parameters.AddWithValue("name", training.Name);
            command.Parameters.AddWithValue("description", training.Description);
            command.Parameters.AddWithValue("datetime", training.DateTime);
            command.Parameters.AddWithValue("createdBy", training.CreatedBy);
            command.Parameters.AddWithValue("trainingId", trainingId);
            command.Prepare();
            await command.ExecuteNonQueryAsync();
            return null;
        }

        public async Task DeleteTraining(int trainingId)
        {
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            await connection.OpenAsync();

            var command = new NpgsqlCommand("Delete from training where id=@trainingId", connection);
            command.Parameters.AddWithValue("trainingId", trainingId);
            command.Prepare();
            await command.ExecuteNonQueryAsync();
        }
    }

}