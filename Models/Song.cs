using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MusicLibrary.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a release date")]
        public DateOnly ReleaseDate { get; set; }

        public byte[]? File { get; set; }

        public string? FileName { get; set; }

        [Required(ErrorMessage = "Please enter a genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Please enter an artist")]
        public int ArtistId { get; set; }

        public virtual Genre? Genre { get; set; }

        public virtual Artist? Artist { get; set; }
    }
}
