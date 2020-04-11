using System;
using System.Collections.Generic;

namespace SwimTraining.Domain {
    public class Training {
        public string Name { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public List<Exercise> ExerciseList { get; }
        public string CreatedBy { get; }

        public Training(string name, string description, DateTime date, List<Exercise> exerciseList, string createdBy) {
            Name = name;
            Description = description;
            Date = date;
            ExerciseList = exerciseList;
            CreatedBy = createdBy;
        }
    }
}