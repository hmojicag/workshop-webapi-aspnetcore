using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Data;
using MoviesWebApi.Models;
using MoviesWebApi.Services;

namespace MoviesWebApi.Controllers {
    
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase {

        private IActorsService actorsService;

        public ActorsController(IActorsService actorsService) {
            this.actorsService = actorsService;
        }
        
        [HttpPost]
        //POST api/actors
        //Payload: A Json representing the Actor object
        public ActionResult<Actor> CreateActor(Actor actor) {
            return actorsService.CreateActor(actor);
        }
        
    }
}