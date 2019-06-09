using MoviesWebApi.Data;
using MoviesWebApi.Models;

namespace MoviesWebApi.Services {
    public class ActorsService : IActorsService {
        private AppDbContext db;

        public ActorsService(AppDbContext db) {
            this.db = db;
        }
        
        public Actor CreateActor(Actor actor) {
            db.Actors.Add(actor);
            db.SaveChanges();
            return actor;
        }
    }
}