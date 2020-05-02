using System;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SwimTraining.Application.PrimaryAdapters.Test.Builder;
using SwimTraining.Application.SecondaryPorts;

namespace SwimTraining.Application.PrimaryAdapters.Test {
    public class DeleteTrainingShould {
        private DeleteTraining DeleteTraining;
        private TrainingRepositoryPort TrainingRepositoryPort;

        [SetUp]
        public void Setup() {
            TrainingRepositoryPort = Substitute.For<TrainingRepositoryPort>();
            DeleteTraining = new DeleteTraining(TrainingRepositoryPort);
        }

        [Test]
        public async Task delete_a_training_by_id() {
            var ATraining = new TrainingBuilder()
                .withId(1)
                .withName("ATraining")
                .withDescription("ADescription")
                .withDateTime(new DateTime(2020, 1, 1)).withCreatedBy("AnId").Build();

            await DeleteTraining.Execute(1).Received();

        }
    }
}