namespace MusicSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }
        
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
