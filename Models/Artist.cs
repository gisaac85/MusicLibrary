using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
