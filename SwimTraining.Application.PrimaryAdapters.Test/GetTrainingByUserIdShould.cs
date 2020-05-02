using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;
using FluentAssertions;
using SwimTraining.Application.PrimaryAdapters.Response;

namespace SwimTraining.Application.PrimaryAdapters.Test
{
    public class GetTrainingByUserIdShould
    {
        private GetTrainingByUserId GetTrainingByUserId;
        private TrainingRepositoryPort TrainingRepositoryPort;

        [SetUp]
        public void Setup() {
            TrainingRepositoryPort = Substitute.For<TrainingRepositoryPort>();
            GetTrainingByUserId = new GetTrainingByUserId(TrainingRepositoryPort);
        }

        [Test]
        public async Task get_training_by_id() {
            var AName = "ATraining";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2020,1,1);
            var exercises = new List<Exercise>();
            var createdBy = "AnId";
            var ATraining = new Training(AName,ADescription,ADateTime,createdBy);
            TrainingRepositoryPort.GetTrainingByUser(createdBy).Returns(new List<Training>{ ATraining });

            var result = await GetTrainingByUserId.Execute(createdBy);

            result.Should().BeEquivalentTo(new List<TrainingResponse> { new TrainingResponse {
                Name = ATraining.Name,
                Description = ATraining.Description,
                Date = ATraining.DateTime,
                ExerciseList = ATraining.ExerciseList,
                CreatedBy = ATraining.CreatedBy
            } } );
        }
    }
}