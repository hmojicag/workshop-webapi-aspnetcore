namespace HelloWorldNetCore {
    public class Movie : Film {
        public int Duration {
            get { return duration; }
            set { duration = value; }
        }
        private int duration;

        public Movie() {
            //Not used anymore
        }

        public Movie(string title, int duration, string classification) {
            Title = title;
            Duration = duration;
            Classification = classification;
        }

        public string Play(string actors) {
            return $"Movie: {Title}, {Duration}, {Classification}, {actors}";
        }
        

    }
}