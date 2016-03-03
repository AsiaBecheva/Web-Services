namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AlbumResponseModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int Year { get; set; }

        [MaxLength(100)]
        public string Producer { get; set; }
    }
}