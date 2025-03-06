using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class CoursesModel
    {
        public int CourseId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Url]
        public string? Syllabus { get; set; }
        [Required]
        public int Points { get; set; }
    }
}