namespace MusicSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongResponseModel
    {
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Genre { get; set; }
    }
}