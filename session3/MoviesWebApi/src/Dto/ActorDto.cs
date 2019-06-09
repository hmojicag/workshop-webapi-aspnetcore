using System;

namespace MoviesWebApi.Dto {
    public class ActorDto {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }

    }
}