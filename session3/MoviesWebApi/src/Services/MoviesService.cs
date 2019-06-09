using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MoviesWebApi.Data;
using MoviesWebApi.Dto;
using MoviesWebApi.MemoryCache;
using MoviesWebApi.Models;
using MoviesWebApi.Utils;

namespace MoviesWebApi.Services {
    public class MoviesService : IMoviesService {
        
        private AppDbContext db;
        private IMemoryCache memoryCache;

        public MoviesService(AppDbContext db, IMemoryCache memoryCache) {
            this.db = db;
            this.memoryCache = memoryCache;
        }
        
        //Now we will get all movies from the InMemoryCache which are stored under the key "MOVIES_ALL"
        //If the entry in the cache does not exists (first time, cache was expired or evicted)
        //then it will call the lambda function which receives an ICacheEntry as parameter and returns
        //the values for that entry.
        public List<MovieDto> GetAllMovies() {
            return memoryCache.GetOrCreate(
                MemoryCacheKey.MOVIES_ALL.ToString(), cacheEntry => {
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                    return db.Movies
                        .Include(movie => movie.Studio)
                        .Include(movie => movie.MovieActors)
                        .ThenInclude(movieActor => movieActor.Actor)
                        .ToList()
                        .ConvertAll(Mapper.MapMovie);
                });
        }

        
        public MovieDto GetMovie(string id) {
            var movie = memoryCache.GetOrCreate(
                MemoryCacheKeyGenerator.Generate(MemoryCacheKey.MOVIE_BY_ID, id),
                cacheEntry => GetMovieFromDb(cacheEntry, id));
            return Mapper.MapMovie(movie);
        }

        //Instead of creating an anonymous method, call this one for fetching data from db
        private Movie GetMovieFromDb(ICacheEntry cacheEntry, string id) {
            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return db.Movies
                .Include(movie => movie.Studio)
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor)
                .First(movie => movie.Id.Equals(id));
        }

        public MovieDto CreateMovie(Movie movie) {
            db.Movies.Add(movie);
            db.SaveChanges();
            //Evict cache with all movies
            memoryCache.Remove(MemoryCacheKey.MOVIES_ALL.ToString());
            return Mapper.MapMovie(movie);
        }

        public MovieDto UpdateMovie(string id, Movie movie) {
            Movie movieFromDb = db.Movies.Find(id);

            if (movieFromDb == null) {
                return null;
            }
            
            //Copy all modifiable fields
            movieFromDb.Name = movie.Name;
            movieFromDb.Year = movie.Year;
            movieFromDb.Genre = movie.Genre;
            movieFromDb.Duration = movie.Duration;
            movieFromDb.StudioId = movie.StudioId;
            movieFromDb.LastUpdatedDate = DateTime.Now;

            db.Movies.Update(movieFromDb);
            db.SaveChanges();
            
            //Evict this entry from cache
            memoryCache.Remove(MemoryCacheKeyGenerator.Generate(MemoryCacheKey.MOVIE_BY_ID, id));
            memoryCache.Remove(MemoryCacheKey.MOVIES_ALL.ToString());
            
            //Return a refreshed instance of Movie
            return GetMovie(id);
        }

        public void DeleteMovie(string id) {
            Movie movieFromDb = db.Movies.Find(id);

            if (movieFromDb == null) {
                return;
            }

            db.Movies.Remove(movieFromDb);
            db.SaveChanges();
            
            //Evict movies from cache
            memoryCache.Remove(MemoryCacheKeyGenerator.Generate(MemoryCacheKey.MOVIE_BY_ID, id));
            memoryCache.Remove(MemoryCacheKey.MOVIES_ALL.ToString());
        }

        public MovieDto UpdateActors(string movieId, List<string> actorsIds) {
            var movieFromDb = db.Movies.Find(movieId);
            //Check if movie Id exists
            if (movieFromDb == null) {
                return null;
            }

            //Verify if all actors exists and build the actors to insert
            var movieActorsToInsert = new List<MovieActor>();
            foreach (var actorId in actorsIds) {
                var actor = db.Actors.Find(actorId);
                if (actor == null) {
                    //If an actor does not exist, return
                    return null;
                }
                var movieActor = new MovieActor() {
                    MovieId = movieFromDb.Id,
                    ActorId = actor.Id
                };
                movieActorsToInsert.Add(movieActor);
            }
            
            //Delete all records in MovieActors for this movieId
            var movieActorsToRemove = db.MovieActors.Where(movieActor => movieActor.MovieId == movieId).ToList();
            db.MovieActors.RemoveRange(movieActorsToRemove);
            db.SaveChanges();
            
            //Save the new relationships
            db.MovieActors.AddRange(movieActorsToInsert);
            db.SaveChanges();
            
            //Evict this entry from cache
            memoryCache.Remove(MemoryCacheKeyGenerator.Generate(MemoryCacheKey.MOVIE_BY_ID, movieId));
            
            //Return a refreshed instance of Movie
            return GetMovie(movieId);
        }
    }
}