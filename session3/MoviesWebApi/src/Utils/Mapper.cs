using System.Collections.Generic;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;

namespace MoviesWebApi.Utils {
    public static class Mapper {

        public static ActorDto MapActor(Actor actor) {
            var actorDto = new ActorDto();
            actorDto.Id = actor.Id;
            actorDto.Name = actor.Name;
            actorDto.LastUpdatedDate = actor.LastUpdatedDate;
            actorDto.CreatedDate = actor.CreatedDate;
            return actorDto;
        }

        public static StudioDto MapStudio(Studio studio) {
            var studioDto = new StudioDto() {
                Id = studio.Id,
                Name = studio.Name,
                LastUpdatedDate = studio.LastUpdatedDate,
                CreatedDate = studio.CreatedDate
            };
            return studioDto;
        }

        public static MovieDto MapMovie(Movie movie) {
            var movieDto = new MovieDto() {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                Year = movie.Year,
                Duration = movie.Duration,
                LastUpdatedDate = movie.LastUpdatedDate,
                CreatedDate = movie.CreatedDate
            };

            if (movie.Studio != null) {
                movieDto.Studio = MapStudio(movie.Studio);
            }

            if (movie.MovieActors != null && movie.MovieActors.Count > 0) {
                movieDto.Actors = new List<ActorDto>();
                foreach (var movieActor in movie.MovieActors) {
                    movieDto.Actors.Add(MapActor(movieActor.Actor));
                }
            }

            return movieDto;
        }
    }
}