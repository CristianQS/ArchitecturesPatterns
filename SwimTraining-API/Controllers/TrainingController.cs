using Microsoft.AspNetCore.Mvc;

namespace SwimTraining_API.Controllers {
    [Route("training")]

    public class TrainingController : Controller {
        // GET
        [HttpGet]
        public ActionResult GetTrainingByUser(string userId) {
            return View();
        }
    }
}