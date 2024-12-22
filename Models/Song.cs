using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MusicLibrary.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter an artist name")]
        public string? ArtistName { get; set; }     

        [Required(ErrorMessage = "Please enter a release date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter a genre")]
        public int GenreId { get; set; }
    }
}
