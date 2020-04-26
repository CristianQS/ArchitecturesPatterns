using System.Collections.Generic;
using System.Threading.Tasks;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class TrainingServices {
        private readonly TrainingRepositoryPort TrainingRepository;

        public TrainingServices(TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public async Task<List<Training>> GetTrainingBy(string userId) {
            var trainings = await TrainingRepository.GetTrainingByUser(userId);
            return trainings;
        }
    }
}