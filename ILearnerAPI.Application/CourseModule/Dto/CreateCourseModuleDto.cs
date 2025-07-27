using ILeanerAPI.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace ILearnerAPI.Application.CourseModule.Dto
{
    public class CreateCourseModuleDto
    {

        public string Name { get; set; } = default!;

        public List<string>? Topics { get; set; } = new();

        public int CourseId { get; set; }

        public decimal ModulePrice { get; set; }
        public string Description { get; set; } = default!;
        
    }
}
