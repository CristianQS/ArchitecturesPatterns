using SwimTraining.Application.SecondaryPorts;

namespace SwimTraining.Application.PrimaryAdapters {
    public class DeleteTraining {
        public TrainingRepositoryPort TrainingRepositoryPort;

        public DeleteTraining(TrainingRepositoryPort trainingRepositoryPort) {
            TrainingRepositoryPort = trainingRepositoryPort;
        }

        public async Task Execute(int trainingId) {
            await TrainingRepositoryPort.DeleteTraining(trainingId);
        }
    }
}