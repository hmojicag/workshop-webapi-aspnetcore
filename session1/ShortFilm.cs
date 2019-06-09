namespace HelloWorldNetCore {
    public class ShortFilm : Film {
        public string Director { get; set; }

        public override string Play() {
            return $"Movie: {Title}, {Classification}, {Director}";
        }
    }
}