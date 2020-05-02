using System;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Infraestructure.SecondaryAdapters;

namespace SwimTraining.Application.PrimaryAdapters.Test {
    public class CreateTrainingShould {
        private TrainingRepositoryPort TrainingRepositoryPort;
        private CreateTraining CreateTraining;

        [SetUp]
        public void Setup() {
            TrainingRepositoryPort = Substitute.For<TrainingRepositoryPostgresSqlAdapter>(); 
            CreateTraining = new CreateTraining(TrainingRepositoryPort);
        }

        [Test]
        public async Task create_a_training() {
            var trainingDto = new TrainingDto {
                createdBy = "1234",
                datetime = new DateTime(2020,1,1),
                description = "ADescription",
                name = "AName"
            };
            await CreateTraining.Execute(trainingDto).Received();

        }
    }
}