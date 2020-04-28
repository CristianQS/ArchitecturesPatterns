using System;

namespace SwimTraining.Application.PrimaryAdapters.Request {
    public class TrainingDto {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime datetime { get; set; }
        public string createdBy { get; set; }
    }
}