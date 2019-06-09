using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Services;

namespace MoviesWebApi.Controllers {
    
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase {

        private IMoviesService moviesService;
        
        public MoviesController(IMoviesService moviesService) {
            this.moviesService = moviesService;
        }

        [HttpGet]
        //GET api/movies
        public ActionResult<IEnumerable<MovieDto>> GetAllMovies() {
            return moviesService.GetAllMovies();
        }

        [HttpGet("{id}")]
        //GET api/movies/{id}
        public ActionResult<MovieDto> GetMovie(string id) {
            var movie = moviesService.GetMovie(id);

            if (movie == null) {
                return NotFound();
            }
            
            return movie;
        }

        [HttpPost]
        //POST api/movies
        //Payload: A Json representing the Movie object
        public ActionResult<MovieDto> CreateMovie(Movie movie) {
            return moviesService.CreateMovie(movie);
        }
        
        [HttpPut("{id}")]
        //PUT api/movies/{id}
        //Payload: A Json representing the Movie object
        public ActionResult<MovieDto> UpdateMovie(string id, Movie movie) {
            var updatedMovie = moviesService.UpdateMovie(id, movie);

            if (updatedMovie == null) {
                return NotFound();
            }
            
            return updatedMovie;
        }

        [HttpDelete("{id}")]
        //DELETE api/movies/{id}
        public ActionResult DeleteMovie(string id) {
            moviesService.DeleteMovie(id);
            return NoContent();
        }

        [HttpPut("{movieId}/actors")]
        //PUT api/movies/{movieId}/actors
        //Payload: A Json array of actors ids
        public ActionResult<MovieDto> updateActors(string movieId, List<string> actorsIds) {
            var updatedMovie = moviesService.UpdateActors(movieId, actorsIds);

            if (updatedMovie == null) {
                return NotFound();
            }
            
            return updatedMovie;
        }
        
    }
}