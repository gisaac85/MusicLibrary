using MusicLibrary.Models;

namespace MusicLibrary.Data.DTO
{
    public class SongCreateDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public byte[]? File { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        public Genre Genre { get; set; }

        public Artist Artist { get; set; }
    }
}
