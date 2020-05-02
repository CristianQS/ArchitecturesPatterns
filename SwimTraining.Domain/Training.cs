using System;

namespace SwimTraining.Domain {
    public class Training {
        public int id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime DateTime { get; }
        public string CreatedBy { get; }

        public Training(string name, string description, DateTime dateTime, string createdBy) {
            Name = name;
            Description = description;
            DateTime = dateTime;
            CreatedBy = createdBy;
        }

        public Training(int id, string name, string description, DateTime dateTime, string createdBy) {
            this.id = id;
            Name = name;
            Description = description;
            DateTime = dateTime;
            CreatedBy = createdBy;
        }
    }
}