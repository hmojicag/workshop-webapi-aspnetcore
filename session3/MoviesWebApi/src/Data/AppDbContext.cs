using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;

namespace MoviesWebApi.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {
        }
        
        //This is our table Movies
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //We are going to put here all the Model characteristics
            //Like relationships between tables, Indexes, Primary Keys...

            //Configure the navigation property, this is, the relationships
            //The next statement can be read like this:
            //"A movie as many Actors and an Actor has many movies
            modelBuilder.Entity<Movie>()//Many to Many relationship trough MovieActors table
                .HasMany(movie => movie.MovieActors)
                .WithOne(movieActor => movieActor.Movie)
                .HasForeignKey(movieActor => movieActor.MovieId);
            
            modelBuilder.Entity<Actor>() //Many to Many relationship trough MovieActors table
                .HasMany(actor => actor.MovieActors)
                .WithOne(movieActor => movieActor.Actor)
                .HasForeignKey(movieActor => movieActor.ActorId);

            modelBuilder.Entity<Movie>()//Movie <-> Studio. One to Many
                .HasOne(movie => movie.Studio)
                .WithMany(studio => studio.Movies)
                .HasForeignKey(movie => movie.StudioId);

            modelBuilder.Entity<Studio>() //Movie <-> Studio. One to Many
                .HasMany(studio => studio.Movies)
                .WithOne(movie => movie.Studio)
                .HasForeignKey(movie => movie.StudioId);

            modelBuilder.Entity<MovieActor>()//MovieActors. Configure Primary Key
                .HasKey(movieActor => new {movieActor.ActorId, movieActor.MovieId});

        }
    }
}