using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Infraestructure.Database;
using NUnit.Framework;
using SwimTraining.Domain;

namespace SwimTraining.Infraestructure.SecondaryAdapters.Test
{
    public class TrainingRepositoryPostgresSqlAdapterShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public async Task get_a_training_to_a_PostresSql_database() {
            var connectionProvider = new ConnectionProvider("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgresSqlAdapter(connectionProvider);
            var AName = "training 1";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2017, 4, 30);
            var createdBy = "123";
            var ATraining = new Training(AName, ADescription, ADateTime, createdBy);
            var trainings = await trainingRepositoryPostgreSql.GetTrainingByUser(createdBy);

            trainings.Should().BeEquivalentTo(new List<Training> { ATraining });
        }          
        [Test]
        public async Task get_a_training_by_id_to_a_PostresSql_database() {
            var connectionProvider = new ConnectionProvider("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgresSqlAdapter(connectionProvider);
            var AName = "training 1";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2017, 4, 30);
            var createdBy = "123";
            var ATraining = new Training(1,AName, ADescription, ADateTime, createdBy);
            var trainings = await trainingRepositoryPostgreSql.GetTrainingById(1);

            trainings.Should().BeEquivalentTo(new List<Training> { ATraining });
        }        
        [Test]
        public async Task create_a_training_to_a_PostresSql_database() {
            var connectionProvider = new ConnectionProvider("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgresSqlAdapter(connectionProvider);
            var AName = "training 1";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2018, 1, 1);
            var createdBy = "1234";
            var ATraining = new Training(AName, ADescription, ADateTime, createdBy);
            await trainingRepositoryPostgreSql.CreateTraining(ATraining);

            var trainings = await trainingRepositoryPostgreSql.GetTrainingByUser(createdBy);
            trainings.Should().BeEquivalentTo(new List<Training> { ATraining });
        }

        [Test]
        public async Task update_a_training_to_a_PostresSql_database() {
            var connectionProvider = new ConnectionProvider("Host=localhost;Port=5432;Username=admin;Password=admin;Database=python_db");
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgresSqlAdapter(connectionProvider);
            var AName = "training 1";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2018, 1, 1);
            var createdBy = "1234";
            var ATraining = new Training(1,AName, ADescription, ADateTime, createdBy);
            var training = await trainingRepositoryPostgreSql.UpdateTraining(ATraining,1);

            training.Should().BeEquivalentTo(ATraining);
        }

    }
}