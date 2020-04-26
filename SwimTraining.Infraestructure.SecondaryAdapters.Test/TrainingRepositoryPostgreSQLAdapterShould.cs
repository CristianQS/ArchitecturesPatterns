using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SwimTraining.Domain;

namespace SwimTraining.Infraestructure.SecondaryAdapters.Test
{
    public class TrainingRepositoryPostgreSQLAdapterShould {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public async Task get_a_training_to_a_PostresSql_database() {
            var AUserid = "AUserId";
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgreSQLAdapter();
            var AName = "ATraining";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2020, 1, 1);
            var exercises = new List<Exercise>();
            var createdBy = "123";
            var ATraining = new Training(AName, ADescription, ADateTime, exercises, createdBy);

            var trainings = await trainingRepositoryPostgreSql.GetTrainingByUser(AUserid);

            trainings.Should().Contain(ATraining);
            Assert.Pass();
        }
    }
}