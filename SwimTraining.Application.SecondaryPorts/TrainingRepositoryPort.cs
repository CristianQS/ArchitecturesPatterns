using System.Collections.Generic;
using SwimTraining.Domain;

namespace SwimTraining.Application.SecondaryPorts {
    public interface TrainingRepositoryPort {
        List<Training> GetTrainingByUser();
    }
}