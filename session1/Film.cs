using System;

namespace HelloWorldNetCore {
    public class Film : IFilm, Serializable {
        public string Title { get; set; }
        public string Classification { get; set; }
        
        public virtual string Play() {
            return $"Movie: {Title}, {Classification}";
        }

        public string Serialize() {
            return $"{Title}, {Classification}";
        }

        public override string ToString() {
            return Play();
        }
    }
}