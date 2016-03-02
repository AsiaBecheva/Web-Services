namespace MusicSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistResponseModel
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }
    }
}