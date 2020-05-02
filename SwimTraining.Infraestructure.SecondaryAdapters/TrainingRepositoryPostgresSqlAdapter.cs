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
            connectionProvider.Close();
            return trainings.ToList();
        }        
        public async Task<List<Training>> GetTrainingById(int id) {
            await connectionProvider.EstablishConnection();
            var trainings = connectionProvider.Query<Training>("SELECT id,name,description,datetime,createdBy FROM training where id=@id", new {id = id });
            connectionProvider.Close();
            return trainings.ToList();
        }

        public async Task CreateTraining(Training training) {
            await connectionProvider.EstablishConnection();

            connectionProvider.Execute(
                "INSERT INTO training(name, description, datetime, createdBy) VALUES(@name, @description, @datetime, @createdBy)", 
                new {
                    name = training.Name,
                    description = training.Description,
                    datetime = training.DateTime,
                    createdBy = training.CreatedBy
                });
            connectionProvider.Close();
        }

        public async Task<Training> UpdateTraining(Training training, int id) {
            await connectionProvider.EstablishConnection();

            connectionProvider.Execute(
                "Update training Set name=@name, description=@description, datetime=@datetime, createdBy=@createdBy where id=@id",
                new
                {
                    name = training.Name,
                    description = training.Description,
                    datetime = training.DateTime,
                    createdBy = training.CreatedBy,
                    id = id
                });
             connectionProvider.Close();
             return training;
        }

        public async Task DeleteTraining(int id) {
            await connectionProvider.EstablishConnection();

            connectionProvider.Execute(
                "Delete from training where id=@id",
                new
                {
                    id = id
                });
            connectionProvider.Close();
        }
    }

}