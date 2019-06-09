using System.Collections.Generic;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;

namespace MoviesWebApi.Services {
    public interface IMoviesService {
        List<MovieDto> GetAllMovies();
        MovieDto GetMovie(string id);
        MovieDto CreateMovie(Movie movie);
        MovieDto UpdateMovie(string id, Movie movie);
        void DeleteMovie(string id);
        MovieDto UpdateActors(string movieId, List<string> actorsIds);
    }
}