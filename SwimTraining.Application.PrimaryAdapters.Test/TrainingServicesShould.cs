using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;
using FluentAssertions;

namespace SwimTraining.Application.PrimaryAdapters.Test
{
    public class TrainingServicesShould
    {
        private TrainingServices TrainingServices;
        private TrainingRepositoryPort TrainingRepositoryPort;

        [SetUp]
        public void Setup() {
            TrainingRepositoryPort = Substitute.For<TrainingRepositoryPort>();
            TrainingServices = new TrainingServices(TrainingRepositoryPort);
        }

        [Test]
        public void get_training_by_id() {
            var AName = "ATraining";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2020,1,1);
            var exercises = new List<Exercise>();
            var createdBy = "AnId";
            var ATraining = new Training(AName,ADescription,ADateTime,exercises,createdBy);
            TrainingServices.GetTrainingBy(createdBy).Returns(new List<Training>{ ATraining });

            var result = TrainingServices.GetTrainingBy(createdBy);

            result.Should().Contain(ATraining);
        }
    }
}