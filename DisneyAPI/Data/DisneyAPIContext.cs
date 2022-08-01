using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DisneyAPI.Models;

namespace DisneyAPI.Data
{
    public class DisneyAPIContext : DbContext
    {
        public DisneyAPIContext (DbContextOptions<DisneyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<CharacterMovie> CharacterMovies { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<CharacterMovie>().ToTable("CharacterMovie");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");
            modelBuilder.Entity<Genre>().ToTable("Genre");
        }
        
    }
}
