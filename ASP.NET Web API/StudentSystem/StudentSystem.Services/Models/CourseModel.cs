using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Services.Models
{
    public class CourseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}