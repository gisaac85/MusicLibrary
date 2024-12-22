using MusicLibrary.Models;

namespace MusicLibrary.Data.DTO
{
    public class SongDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? ArtistName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
