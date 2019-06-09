namespace MoviesWebApi.MemoryCache {
    public enum MemoryCacheKey {
        MOVIES_ALL,
        MOVIE_BY_ID
    }

    public static class MemoryCacheKeyGenerator {
        public static string Generate(MemoryCacheKey key, string identifier = "") {
            if (string.IsNullOrEmpty(identifier)) {
                return key.ToString();
            }
            return $"{key.ToString()}_{identifier}";
        }
    }
}