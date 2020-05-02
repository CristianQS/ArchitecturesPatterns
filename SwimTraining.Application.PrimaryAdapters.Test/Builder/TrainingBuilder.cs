using System;
using SwimTraining.Domain;

namespace SwimTraining.Application.PrimaryAdapters.Test.Builder {
    public class TrainingBuilder {
        private int Id;
        private string Name;
        private string Description;
        private DateTime DateTime;
        private string CreatedBy;

        public TrainingBuilder withId(int id) {
            Id = id;
            return this;
        }        
        public TrainingBuilder withName(string name) {
            Name = name;
            return this;
        }        
        public TrainingBuilder withDescription(string description) {
            Description = description;
            return this;
        }        
        public TrainingBuilder withDateTime (DateTime dateTime) {
            DateTime = dateTime;
            return this;
        }        
        public TrainingBuilder withCreatedBy(string createdBy) {
            CreatedBy = createdBy;
            return this;
        }

        public Training Build() {
            return new Training(Id,Name,Description,DateTime,CreatedBy);
        }
    }
}