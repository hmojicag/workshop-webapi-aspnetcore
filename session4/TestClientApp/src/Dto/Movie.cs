using System;
using System.Collections.Generic;

namespace TestClientApp.Dto {
    public class Movie {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Genre { get; set; }
        
        public int Year { get; set; }
        
        public int Duration { get; set; }
        
        public Studio Studio { get; set; }
        
        public List<Actor> Actors { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }

        public override string ToString() {
            return $"Movie [{Id}, {Name}, {Genre}, {Year}, {Duration}]";
        }
    }
}