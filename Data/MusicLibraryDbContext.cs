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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Bohemian Rhapsody", ArtistName = "Queen", Genre = "Rock", ReleaseDate = new System.DateTime(1975, 10, 31) },
                new Song { Id = 2, Title = "Stairway to Heaven", ArtistName = "Led Zeppelin", Genre = "Rock", ReleaseDate = new System.DateTime(1971, 11, 8) },
                new Song { Id = 3, Title = "Hotel California", ArtistName = "Eagles", Genre = "Rock", ReleaseDate = new System.DateTime(1977, 12, 8) },
                new Song { Id = 4, Title = "Imagine", ArtistName = "John Lennon", Genre = "Rock", ReleaseDate = new System.DateTime(1971, 10, 11) },
                new Song { Id = 5, Title = "Smells Like Teen Spirit", ArtistName = "Nirvana", Genre = "Grunge", ReleaseDate = new System.DateTime(1991, 9, 10) },
                new Song { Id = 6, Title = "One", ArtistName = "Metallica", Genre = "Metal", ReleaseDate = new System.DateTime(1989, 8, 25) }
               );
        }
    }
}
