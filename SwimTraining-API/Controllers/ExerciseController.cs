using Microsoft.AspNetCore.Mvc;

namespace SwimTraining_API.Controllers {
    public class ExerciseController : Controller {
        // GET
        [HttpGet]
        public IActionResult getExercisesByTraining() {
            return View();
        }
    }
}