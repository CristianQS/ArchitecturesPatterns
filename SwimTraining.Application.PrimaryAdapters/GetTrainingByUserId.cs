using System.Collections.Generic;
using System.Threading.Tasks;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class GetTrainingByUserId {
        private readonly TrainingRepositoryPort TrainingRepository;

        public GetTrainingByUserId(TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public async Task<List<Training>> Execute(string userId) {
            var trainings = await TrainingRepository.GetTrainingByUser(userId);
            return trainings;
        }
    }
}