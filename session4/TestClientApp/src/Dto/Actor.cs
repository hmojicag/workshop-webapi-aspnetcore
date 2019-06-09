using System;

namespace TestClientApp.Dto {
    public class Actor {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdatedDate { get; set; }
    }
}