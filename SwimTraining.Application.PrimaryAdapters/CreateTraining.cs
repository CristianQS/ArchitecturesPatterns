using System;
using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class CreateTraining {
        private readonly TrainingRepositoryPort TrainingRepositoryPort;

        public CreateTraining(TrainingRepositoryPort trainingRepositoryPort) {
            TrainingRepositoryPort = trainingRepositoryPort;
        }

        public async Task Execute(TrainingDto training) {
            await TrainingRepositoryPort.CreateTraining(
                new Training(
                    training.name,
                    training.description, 
                    training.datetime,
                    training.createdBy)
                );
        }
    }
}