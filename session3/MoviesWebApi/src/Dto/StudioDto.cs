using System;

namespace MoviesWebApi.Dto {
    public class StudioDto {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}