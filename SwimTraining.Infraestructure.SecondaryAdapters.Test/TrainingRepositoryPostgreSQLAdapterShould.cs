using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
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
            var AUserid = "1234";
            var trainingRepositoryPostgreSql = new TrainingRepositoryPostgreSQLAdapter();
            var AName = "Training 1";
            var ADescription = "ADescription";
            var ADateTime = new DateTime(2020, 1, 1);
            var createdBy = "1234";
            var ATraining = new Training(AName, ADescription, ADateTime, null, createdBy);
            var Training2 = new Training("Training 2", "AnotherDescription", new DateTime(2020, 2, 2), null, "1234");
            var trainings = await trainingRepositoryPostgreSql.GetTrainingByUser(AUserid);

            trainings.Should().BeEquivalentTo(new List<Training> { ATraining,Training2 });
        }
    }
}