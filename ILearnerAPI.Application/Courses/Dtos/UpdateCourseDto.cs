using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.Courses.Dtos
{
    public class UpdateCourseDto
    {
     
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public string? Category { get; set; }
    }
}
