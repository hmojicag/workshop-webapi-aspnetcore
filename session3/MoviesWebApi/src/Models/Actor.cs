using System;
using System.Collections.Generic;

namespace MoviesWebApi.Models {
    public class Actor {
        public Actor() {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
        }
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }
        
        /**Navigation Properties**/
        public ICollection<MovieActor> MovieActors { get; set; } //Many to Many
    }
}