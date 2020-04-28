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
            var trainingList = new GetTrainingByUserId(new TrainingRepositoryPostgreSQLAdapter()).Execute(userId);
            return trainingList;
        }
    }
}