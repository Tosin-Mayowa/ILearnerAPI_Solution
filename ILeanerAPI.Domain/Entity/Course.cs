

namespace ILeanerAPI.Domain.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; }=String.Empty;
        public string Category {  get; set; } = String.Empty;

        public List<CourseModuleTab> CourseModule { get; set; } = new();

    }
}
