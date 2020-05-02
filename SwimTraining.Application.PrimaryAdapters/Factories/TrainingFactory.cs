using SwimTraining.Application.SecondaryPorts;

namespace SwimTraining.Application.PrimaryAdapters.Factories {
    public class TrainingFactory {
        private readonly TrainingRepositoryPort TrainingRepository;

        public TrainingFactory(TrainingRepositoryPort trainingRepository) {
            TrainingRepository = trainingRepository;
        }

        public GetTrainingByUserId GetTrainingByUserId() {
            return new GetTrainingByUserId(TrainingRepository);
        }        
        public CreateTraining CreateTraining() {
            return new CreateTraining(TrainingRepository);
        }        
        public UpdateTraining UpdateTraining() {
            return new UpdateTraining(TrainingRepository);
        }        
        public DeleteTraining DeleteTraining() {
            return new DeleteTraining(TrainingRepository);
        }
    }
}