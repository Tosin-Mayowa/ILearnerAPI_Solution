﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.Courses.Dtos
{
    public class CreateCourseDto
    {
          public string Name { get; set; } = String.Empty;
        public string Description { get; set; }=String.Empty;
        public string Category {  get; set; } = String.Empty;
    }
}
