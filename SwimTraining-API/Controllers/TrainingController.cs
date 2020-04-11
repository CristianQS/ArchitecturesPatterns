using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SwimTraining.Application.PrimaryAdapters;
using SwimTraining.Domain;

namespace SwimTraining_API.Controllers {
    [Route("api/training")]

    public class TrainingController : Controller {
        // GET
        [HttpGet]
        public List<Training> GetTrainingByUser(string userId) {
            var trainingList = new TrainingServices().GetTrainingBy(userId);
            return trainingList;
        }
    }
}