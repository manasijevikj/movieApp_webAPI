
using Manasijevikj.MovieApp.Domain.Enums;
using Manasijevikj.MovieApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Manasijevikj.MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //MOVIE
            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);
            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            //Relation
            modelBuilder.Entity<Movie>()
                .HasOne(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId);



            //DIRECTOR
            modelBuilder.Entity<Director>()
                .Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Director>()
                .Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Director>()
                .Property(x => x.Country)
                .HasMaxLength(100);


            //USER
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasMaxLength(18)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .IsRequired();         



            //SEED
            modelBuilder.Entity<Movie>()
               .HasData(
               new Movie
               {
                   Id = 1,
                   Title = "Interstellar",
                   Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                   Genre = MovieGenre.Sci_Fi,
                   Year = 2014,
                   DirectorId = 1
               },
               new Movie
               {
                   Id = 2,
                   Title = "Full Metal Jacket",
                   Description = "A pragmatic U.S. Marine observes the dehumanizing effects the Vietnam War has on his fellow recruits from their brutal boot camp training to the bloody street fighting in Hue.",
                   Genre = MovieGenre.Drama,
                   Year = 1987,
                   DirectorId = 3
               },
               new Movie
               {
                   Id = 3,
                   Title = "Pulp Fiction",
                   Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                   Genre = MovieGenre.Crime,
                   Year = 1994,
                   DirectorId = 2
               });

            modelBuilder.Entity<Director>()
                .HasData(
                new Director
                {
                    Id = 1,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Country = "England"
                },
                new Director
                {
                    Id = 2,
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Country = "USA"
                },
                new Director
                {
                    Id = 3,
                    FirstName = "Stanley",
                    LastName = "Kubrick",
                    Country = "USA"
                });

        }


    }
}
