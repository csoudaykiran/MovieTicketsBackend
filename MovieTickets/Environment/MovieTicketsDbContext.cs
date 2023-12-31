
using MovieTickets.Models.Bookings;
using MovieTickets.Models.Cinema;
using MovieTickets.Models.Movie;
using MovieTickets.Models.Show;
using MovieTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Environment
{
    public class MovieTicketsDbContext : DbContext
    {
        //Ebiograf Db Constructor. Base options Connection string will be set in Statup Class.
        public MovieTicketsDbContext(DbContextOptions<MovieTicketsDbContext> options) : base(options) { }

        //  Migrating Database Table Users into SqlDatabase.
        // USER DATABASES
        public DbSet<User> Users { get; set; }
        // MOVIE DATABASES
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowSeat> ShowSeats { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<CinemaSeat> CinemaSeats { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }


        // Relationship Configuring via the Fluent API for EF Core to be able to map it successfully.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Shows and ShowSeats with cascade behavior
            modelBuilder.Entity<ShowSeat>()
                .HasOne(ss => ss.Show)
                .WithMany(s => s.ShowSeats)
                .HasForeignKey(ss => ss.ShowID)
                .OnDelete(DeleteBehavior.Restrict);
        }


            /*protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Movie Model Building
                modelBuilder.Entity<Movie>().HasMany(x => x.Genres)
                    .WithMany(x => x.Movies)
                    .UsingEntity<GenreMovie>(
                        x => x.HasOne(x => x.Genre)
                        .WithMany().HasForeignKey(x => x.GenresGenreID),
                        x => x.HasOne(x => x.Movie)
                       .WithMany().HasForeignKey(x => x.MoviesMovieID));

            }*/

        }
}
