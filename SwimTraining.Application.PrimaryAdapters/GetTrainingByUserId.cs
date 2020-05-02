using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Response;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class GetTrainingByUserId {
        private readonly TrainingRepositoryPort TrainingRepository;

        public GetTrainingByUserId(TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public async Task<List<TrainingResponse>> Execute(string userId) {
            var trainings = await TrainingRepository.GetTrainingByUser(userId);
            return MapListToTrainingResponse(trainings);
        }

        private static List<TrainingResponse> MapListToTrainingResponse(List<Training> trainings) {
            var result = new List<TrainingResponse>();
            trainings.ForEach(training => {
                result.Add(new TrainingResponse {
                    Name = training.Name,
                    Description = training.Description,
                    Date = training.Date,
                    ExerciseList = training.ExerciseList,
                    CreatedBy = training.CreatedBy
                });
            });
            return result;
        }
    }
}