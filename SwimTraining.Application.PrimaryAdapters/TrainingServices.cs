using System.Collections.Generic;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class TrainingServices {
        private readonly TrainingRepositoryPort TrainingRepository;

        public TrainingServices(TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public List<Training> GetTrainingBy(string userId) {
            var trainings = TrainingRepository.GetTrainingByUser();
            return trainings;
        }
    }
}