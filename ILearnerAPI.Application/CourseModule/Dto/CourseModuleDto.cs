using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.CourseModule.Dto
{
    public class CourseModuleDto
    {
       

        public string Name { get; set; } = String.Empty;

        public List<string>? Topics { get; set; } = new();

        public int CourseId { get; set; }

       
        public decimal ModulePrice { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
