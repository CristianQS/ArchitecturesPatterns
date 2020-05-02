using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwimTraining.Application.PrimaryAdapters.Factories;
using SwimTraining.Application.PrimaryAdapters.Request;
using SwimTraining.Application.PrimaryAdapters.Response;

namespace SwimTraining_API.Controllers {
    [Route("api/training")]

    public class TrainingController : Controller {
        private readonly TrainingFactory TrainingFactory;

        public TrainingController(TrainingFactory trainingFactory) {
            TrainingFactory = trainingFactory;
        }

        [HttpGet]
        public Task<List<TrainingResponse>> GetTrainingsByUser(string userId) {
            var trainingList = TrainingFactory.GetTrainingByUserId().Execute(userId);
            return trainingList;
        } 
        
        [HttpGet]
        public Task<List<TrainingResponse>> GetTrainingsById(int id) {
            var trainingList = TrainingFactory.GetTrainingById().Execute(id);
            return trainingList;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraining([FromBody] TrainingDto training) {
            await TrainingFactory.CreateTraining().Execute(training);
            return NoContent();
        }

        [HttpPut("{trainingId}")]
        public async Task<ActionResult> UpdateTraining([FromBody] TrainingDto training, int trainingId) {
            await TrainingFactory.UpdateTraining().Execute(training, trainingId);
            return Content("");
        }

        [HttpDelete("{trainingId}")]
        public async Task<ActionResult> DeleteTraining(int trainingId) {
            await TrainingFactory.DeleteTraining().Execute(trainingId);
            return Ok();
        }
    }
}