using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Models;
using MoviesWebApi.Services;

namespace MoviesWebApi.Controllers {
    [Route("api/studios")]
    [ApiController]
    public class StudiosController : ControllerBase {
        private IStudiosService studiosService;
        
        public StudiosController(IStudiosService studiosService) {
            this.studiosService = studiosService;
        }

        [HttpPost]
        //POST api/studios
        //Payload: A Json representing the Studio object
        public Studio CreateStudio(Studio studio) {
            return studiosService.CreateStudio(studio);
        }
    }
}