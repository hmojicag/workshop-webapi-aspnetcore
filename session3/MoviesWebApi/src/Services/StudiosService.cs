using MoviesWebApi.Data;
using MoviesWebApi.Models;

namespace MoviesWebApi.Services {
    public class StudiosService : IStudiosService {
        private AppDbContext db;

        public StudiosService(AppDbContext db) {
            this.db = db;
        }
        
        public Studio CreateStudio(Studio studio) {
            db.Studios.Add(studio);
            db.SaveChanges();
            return studio;
        }
    }
}