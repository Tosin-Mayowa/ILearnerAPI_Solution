using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.CourseModule.Dto
{
    public class UpdateCourseModuleDto
    {
        public string? Name { get; set; }

        public List<string>? Topics { get; set; } = new();

        public int CourseId { get; set; }

        public decimal? ModulePrice { get; set; }
        public string? Description { get; set; }
    }
}
