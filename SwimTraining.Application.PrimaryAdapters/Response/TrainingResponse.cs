using System;

namespace SwimTraining.Application.PrimaryAdapters.Response {
    public class TrainingResponse {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }

    }

}