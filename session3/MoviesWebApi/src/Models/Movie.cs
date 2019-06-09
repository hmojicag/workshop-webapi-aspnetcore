using System;
using System.Collections.Generic;

namespace MoviesWebApi.Models {
    public class Movie {

        public Movie() {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
        }
        
        // This field is going to be recognized automatically by
        // EF Core as the Primary Key of the table
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Genre { get; set; }
        
        public int Year { get; set; }
        
        public int Duration { get; set; }
        
        public string StudioId { get; set; }
        
        // These fields are here to know when this record
        // was first created and when it was last updated
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }
        
        
        /**Navigation Properties**/
        public Studio Studio { get; set; }                //One to Many
        public ICollection<MovieActor> MovieActors { get; set; } //Many to Many
    }
}