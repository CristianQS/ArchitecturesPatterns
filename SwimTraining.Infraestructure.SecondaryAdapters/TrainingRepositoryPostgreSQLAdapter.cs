using System;
using System.Collections.Generic;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Infraestructure.SecondaryAdapters {
    public class TrainingRepositoryPostgreSQLAdapter : TrainingRepositoryPort {
        public Training Training1 = new Training("Training 1", "ADescription", new DateTime(2020, 1, 1), null, "1234");
        public Training Training2 = new Training("Training 2", "AnotherDescription", new DateTime(2020, 2, 2), null, "1234");
        public List<Training> Trainings = new List<Training>();
        public List<Training> GetTrainingByUser() {
            Trainings.Add(Training1);
            Trainings.Add(Training2);
            return Trainings;
        }
    }
}