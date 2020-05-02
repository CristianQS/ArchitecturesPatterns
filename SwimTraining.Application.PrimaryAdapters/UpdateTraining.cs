using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class UpdateTraining {
        private readonly TrainingRepositoryPort TrainingRepositoryPort;

        public UpdateTraining(TrainingRepositoryPort trainingRepositoryPort) {
            TrainingRepositoryPort = trainingRepositoryPort;
        }

        public async Task<Training> Execute(TrainingDto training, int trainingId) {
            return await TrainingRepositoryPort.UpdateTraining(new Training(training.name, training.description, training.datetime, training.createdBy), trainingId);
        }
    }
}