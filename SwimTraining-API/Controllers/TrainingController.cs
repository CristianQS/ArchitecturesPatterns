using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTraining.Application.PrimaryAdapters;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Domain;
using SwimTraining.Infraestructure.SecondaryAdapters;

namespace SwimTraining_API.Controllers {
    [Route("api/training")]

    public class TrainingController : Controller {
        // GET
        [HttpGet]
        public Task<List<Training>> GetTrainingsByUser(string userId) {
            var trainingList = new GetTrainingByUserId(new TrainingRepositoryPostgresSqlAdapter()).Execute(userId);
            return trainingList;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraining([FromBody] TrainingDto training) {
            await new CreateTraining(new TrainingRepositoryPostgresSqlAdapter()).Execute(training);
            return NoContent();
        }

        [HttpPut("{trainingId}")]
        public async Task<ActionResult> UpdateTraining([FromBody] TrainingDto training, int trainingId) {
            await new UpdateTraining(new TrainingRepositoryPostgresSqlAdapter()).Execute(training, trainingId);
            return Content("");
        }

        [HttpDelete("{trainingId}")]
        public async Task<ActionResult> DeleteTraining(int trainingId) {
            await new DeleteTraining(new TrainingRepositoryPostgresSqlAdapter()).Execute(trainingId);
            return Ok();
        }
    }
}