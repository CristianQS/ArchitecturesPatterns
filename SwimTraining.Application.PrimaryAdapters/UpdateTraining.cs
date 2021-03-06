﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.PrimaryAdapters.Response;
using SwimTraining.Application.SecondaryPorts;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters {
    public class UpdateTraining {
        private readonly TrainingRepositoryPort TrainingRepositoryPort;

        public UpdateTraining(TrainingRepositoryPort trainingRepositoryPort) {
            TrainingRepositoryPort = trainingRepositoryPort;
        }

        public async Task<TrainingResponse> Execute(TrainingDto training, int trainingId) {
            var trainingUpdated = await TrainingRepositoryPort.UpdateTraining(new Training(training.name, training.description, training.datetime, training.createdBy), trainingId);
            return new TrainingResponse {
                Id = trainingUpdated.Id,
                Name = trainingUpdated.Name,
                Description = trainingUpdated.Description,
                Date = trainingUpdated.DateTime,
                CreatedBy = trainingUpdated.CreatedBy
            };
        }


    }
}