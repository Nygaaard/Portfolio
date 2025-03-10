namespace Portfolio.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SkillsModel>? Skills { get; set; }
        public IEnumerable<FrameworksModel>? Frameworks { get; set; }
        public IEnumerable<CoursesModel>? Courses { get; set; }
    }
}