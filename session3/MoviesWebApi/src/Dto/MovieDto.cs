using System;
using System.Collections.Generic;

namespace MoviesWebApi.Dto {
    public class MovieDto {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Genre { get; set; }
        
        public int Year { get; set; }
        
        public int Duration { get; set; }
        
        public StudioDto Studio { get; set; }
        
        public List<ActorDto> Actors { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }
    }
}