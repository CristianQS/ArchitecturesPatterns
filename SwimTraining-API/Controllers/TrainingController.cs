using Microsoft.AspNetCore.Mvc;
using SwimTraining.Application.PrimaryAdapters;

namespace SwimTraining_API.Controllers {
    [Route("training")]

    public class TrainingController : Controller {
        // GET
        [HttpGet]
        public ActionResult GetTrainingByUser(string userId) {
            var trainingList = new TrainingServices().GetTrainingBy(userId);
            return trainingList;
        }
    }
}