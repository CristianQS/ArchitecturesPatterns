using System;
using System.Collections.Generic;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters.Response {
    public class TrainingResponse {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> ExerciseList { get; set; }
        public string CreatedBy { get; set; }

    }

}