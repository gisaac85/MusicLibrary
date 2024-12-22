using MusicLibrary.Models;

namespace MusicLibrary.Data.DTO
{
    public class SongDeleteDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        public Genre Genre { get; set; }

        public Artist Artist { get; set; }
    }
}
