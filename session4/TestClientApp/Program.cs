using System;
using System.Net.Http;
using System.Net.Http.Headers;
//Remember to add Nuget: https://www.nuget.org/packages/Flurl.Http/
using Flurl;
using Flurl.Http;
using TestClientApp.Dto;

namespace TestClientApp {
    class Program {
        private static readonly string hostname = "http://localhost:5000/api";
        
        static void Main(string[] args) {
            
            var instructions = "To get all the movies: dotnet run -- -all\n";
            instructions += "To get one movie: dotnet run -- -movie <id>\n";
            instructions += "To create a movie:  dotnet run -- -create-movie <Name> <Genre> <Year> <Duration>";
            
            if (args.Length < 1) {

                Console.WriteLine(instructions);
                return;
            }

            var command = args[0];

            switch (command) {
                case "-all" :
                    getAllMovies();
                    break;
                
                case "-movie":
                    if (args.Length < 2) {
                        Console.WriteLine("Invalid Id");
                        Console.WriteLine(instructions);
                    }

                    var id = args[1];
                    getAMovie(id);
                    break;
                
                case "-create-movie":
                    if (args.Length < 5) {
                        Console.WriteLine("Invalid number of fields of the movie");
                        Console.WriteLine(instructions);
                    }

                    var name = args[1];
                    var genre = args[2];
                    var year = args[3];
                    var duration = args[4];
                    createMovie(name, genre, year, duration);
                    break;
            }
        }

        private static void getAllMovies() {
            var movies = hostname    
                .AppendPathSegment("movies")
                .GetStringAsync()
                .Result;
            Console.WriteLine(movies);
        }

        private static void getAMovie(string id) {
            var movie = hostname    
                .AppendPathSegment("movies")
                .AppendPathSegment(id)
                .GetJsonAsync<Movie>()
                .Result;
            Console.WriteLine(movie);
        }

        private static void createMovie(string name, string genre, string year, string duration) {
            var newMovie = new Movie() {
                Name = name,
                Genre = genre,
                Year = Convert.ToInt32(year),
                Duration = Convert.ToInt32(duration) 
            };
            var movieResponse = hostname    
                .AppendPathSegment("movies")
                .PostJsonAsync(newMovie)
                .Result;
            Console.WriteLine(movieResponse);
        }
        
    }
}