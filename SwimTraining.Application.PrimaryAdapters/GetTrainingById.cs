using System.Collections.Generic;
using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Response;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class GetTrainingById {
        private readonly TrainingRepositoryPort TrainingRepository;

        public GetTrainingById (TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public async Task<List<TrainingResponse>> Execute(int id) {
            var trainings = await TrainingRepository.GetTrainingById(id);
            return MapListToTrainingResponse(trainings);
        }

        private static List<TrainingResponse> MapListToTrainingResponse(List<Training> trainings) {
            var result = new List<TrainingResponse>();
            trainings.ForEach(training => {
                result.Add(new TrainingResponse
                {
                    Name = training.Name,
                    Description = training.Description,
                    Date = training.DateTime,
                    CreatedBy = training.CreatedBy
                });
            });
            return result;
        }

    }
}