using System;
using System.Collections.Generic;

namespace MoviesWebApi.Models {
    public class Studio {
        public Studio() {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        /**Navigation Properties**/
        public ICollection<Movie> Movies { get; set; } //One to Many
    }
}