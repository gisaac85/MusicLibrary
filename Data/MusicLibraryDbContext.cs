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
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
               new Genre { Id = 1, Name = "Rock" },
               new Genre { Id = 2, Name = "Grunge" },
               new Genre { Id = 3, Name = "Metal" }
               );

            builder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Queen" },
                new Artist { Id = 2, Name = "Led Zeppelin" },
                new Artist { Id = 3, Name = "Eagles" },
                new Artist { Id = 4, Name = "John Lennon" },
                new Artist { Id = 5, Name = "Nirvana" },
                new Artist { Id = 6, Name = "Metallica" },
                new Artist { Id = 7, Name = "BSB" }
                );

            builder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Bohemian Rhapsody", ArtistId = 1, GenreId = 1, ReleaseDate = new System.DateOnly(1975, 10, 31) , FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Queen-BohemianRhapsody.mp3" },
                new Song { Id = 2, Title = "Stairway to Heaven", ArtistId = 2, GenreId = 1, ReleaseDate = new System.DateOnly(1971, 11, 8), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Led-Zeppelin-Stairway-To-Heaven.mp3" },
                new Song { Id = 3, Title = "Hotel California", ArtistId = 1, GenreId = 1, ReleaseDate = new System.DateOnly(1977, 12, 8), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Eagles-Hotel-California.mp3" },
                new Song { Id = 4, Title = "Imagine", ArtistId = 4, GenreId = 1, ReleaseDate = new System.DateOnly(1971, 10, 11), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\John-Lennon-Imagine.mp3" },
                new Song { Id = 5, Title = "Smells Like Teen Spirit", ArtistId = 6, GenreId = 2, ReleaseDate = new System.DateOnly(1991, 9, 10), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Metallica-Smells-Like-Teen-Spiri.mp3" },
                new Song { Id = 6, Title = "One", ArtistId = 3, GenreId = 3, ReleaseDate = new System.DateOnly(1989, 8, 25), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Metallica-One.mp3" },
                new Song { Id = 7, Title = "Everybody", ArtistId = 7, GenreId = 2, ReleaseDate = new DateOnly(1999,1,10), FileName = "C:\\Users\\HP\\source\\repos\\MusicLibrary\\Uploads\\Backstreet Boys - Everybody.mp3" }
               );          
        }        
    }
}
