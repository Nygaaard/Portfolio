using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class SkillsModel
    {
        [Key]
        public int SkillsId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}