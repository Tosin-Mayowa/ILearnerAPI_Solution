using ILearnerAPI.Application.CourseModule.Dto;


namespace ILearnerAPI.Application.Courses.Dtos
{
    public class CoursesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public List<CourseModuleDto> CourseModule { get; set; } = new();
    }
}
