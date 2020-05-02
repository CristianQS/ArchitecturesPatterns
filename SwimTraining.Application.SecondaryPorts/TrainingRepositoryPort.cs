using System.Collections.Generic;
using System.Threading.Tasks;
using SwimTraining.Domain;

namespace SwimTraining.Application.SecondaryPorts {
    public interface TrainingRepositoryPort { 
        Task<List<Training>> GetTrainingByUser(string userId);

        Task<List<Training>> GetTrainingById(int id);
        Task CreateTraining(Training training);
        Task<Training> UpdateTraining(Training training, int trainingId);
        Task DeleteTraining(int trainingId);
    }
}