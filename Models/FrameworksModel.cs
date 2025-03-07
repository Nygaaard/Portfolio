using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class FrameworksModel
    {
        [Key]
        public int FrameworkId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}