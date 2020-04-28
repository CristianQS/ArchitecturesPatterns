﻿using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;
using SwimTraining.Infraestructure.SecondaryAdapters;

namespace SwimTraining.Application.PrimaryAdapters {
    public class UpdateTraining {
        private readonly TrainingRepositoryPort TrainingRepositoryPort;

        public UpdateTraining(TrainingRepositoryPort trainingRepositoryPort) {
            TrainingRepositoryPort = trainingRepositoryPort;
        }

        public async Task<Training> Execute(TrainingDto training, int trainingId) {
            await TrainingRepositoryPort.UpdateTraining(new Training(training.name, training.description, training.datetime, null, training.createdBy), trainingId);
            return null;
        }
    }
}