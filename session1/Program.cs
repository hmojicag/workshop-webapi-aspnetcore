using System;
using System.Collections.Generic;

namespace HelloWorldNetCore {
    class Program {
        static void Main(string[] args) {

//            string movie = "Toy Story 4";
//            int duracion = 123;
//            int Duracion = 154;
//            
//            Console.WriteLine("Hello World!");
//            Console.WriteLine("Hello John Wick 3!!");
//            Console.WriteLine(movie);
//            movie = "Aladino";
//            Console.WriteLine(movie);
//            Console.WriteLine(duracion);
//            Console.WriteLine(movie + " with Will Smith");
//            Console.WriteLine( $"{movie} with Will Smith");
//
//            var movieWithSpaces = "     Pikachu    ";
//            Console.WriteLine(movieWithSpaces.Trim());
//            Console.WriteLine(movieWithSpaces.TrimEnd());
//            Console.WriteLine(movieWithSpaces.TrimStart());
//
//            movieWithSpaces.Contains("Pika");
//            
//            int max = int.MaxValue;
//            int min = int.MinValue;
//            Console.WriteLine($"The range of integers is {min} to {max}");
//            Console.WriteLine(max + 1);
//            
//            List<string> fruits = new List<string>();
//            fruits.Add("apple");
//            fruits.Add("orange");
//            fruits.Add("pear");
//            Console.WriteLine(fruits[0]);
//            foreach(string fruit in fruits) {
//                Console.WriteLine(fruit);
//            }
//
//            for (int i = 0; i < fruits.Count; i++) {
//                string fruit = fruits[i];
//                Console.WriteLine(fruit);
//            }
            
            Movie mrBrooks = new Movie() {
                Title = "Mr Broooks",
                Duration = 112
            };
            
            var lotr = new Movie("Lord of the rings", 250, "B");
            
            //Console.WriteLine(avengers.Play());
            //Console.WriteLine(avengers.Play("Scarlett"));
            //Console.WriteLine(lotr.Play());
            //Console.WriteLine(lotr.Play("Frodo"));
            
            var animation = new ShortFilm();
            animation.Title = "Animations";
            animation.Classification = "A";
            animation.Director = "Brian Cohen";
            //Console.WriteLine(animation.Play());
            
            List<IFilm> movies = new List<IFilm>();
            //movies.Add(avengers);
            movies.Add(mrBrooks);
            movies.Add(lotr);
            movies.Add(animation);

            foreach (var film in movies) {
                Console.WriteLine(film);
                var serial = (Serializable) film;
                Console.WriteLine(serial.Serialize());
            }
            
            Movie avengers = new Movie();
            avengers.Title = "Avengers Endgame";
            avengers.Duration = 130;
            avengers.Classification = "PG-13";

            Movie avengers2 = new Movie();
            avengers.Title = "Avengers Endgame";
            avengers.Duration = 130;
            avengers.Classification = "PG-13";

            Movie avengers3 = avengers;

            int a = 32;
            int b = 50;
            int dummy = 0;
            
            if (a == b) {
                Console.WriteLine("true");
            }
            

            if (avengers == avengers2) {
                Console.WriteLine("true");
            }
            
            if (avengers == avengers3) {
                Console.WriteLine("true");
            }
            
        }
    }
}