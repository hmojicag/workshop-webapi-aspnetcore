using System;

namespace MoviesWebApi.Models {
    public class MovieActor {
        
        public string MovieId { get; set; }
        
        public string ActorId { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        /**Navigation Properties**/
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}