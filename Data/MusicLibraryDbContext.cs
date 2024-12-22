using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MusicLibraryDbContext : DbContext
    {
        public MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
               new Genre { Id = 1, Name = "Rock" },
               new Genre { Id = 2, Name = "Grunge" },
               new Genre { Id = 3, Name = "Metal" }
               );

            builder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Bohemian Rhapsody", ArtistName = "Queen", GenreId = 1, ReleaseDate = new System.DateTime(1975, 10, 31) },
                new Song { Id = 2, Title = "Stairway to Heaven", ArtistName = "Led Zeppelin", GenreId = 1, ReleaseDate = new System.DateTime(1971, 11, 8) },
                new Song { Id = 3, Title = "Hotel California", ArtistName = "Eagles", GenreId = 1, ReleaseDate = new System.DateTime(1977, 12, 8) },
                new Song { Id = 4, Title = "Imagine", ArtistName = "John Lennon", GenreId = 1, ReleaseDate = new System.DateTime(1971, 10, 11) },
                new Song { Id = 5, Title = "Smells Like Teen Spirit", ArtistName = "Nirvana", GenreId = 2, ReleaseDate = new System.DateTime(1991, 9, 10) },
                new Song { Id = 6, Title = "One", ArtistName = "Metallica", GenreId = 3, ReleaseDate = new System.DateTime(1989, 8, 25) }
               );          
        }        
    }
}
