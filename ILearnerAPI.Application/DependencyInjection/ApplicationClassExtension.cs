using ILearnerAPI.Application.CourseModule;
using ILearnerAPI.Application.Courses;
using ILearnerAPI.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.ApplicationExtension
{
    public static class ApplicationClassExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           
            services.AddAutoMapper(cfg =>
            {
               
                cfg.AddProfile<CourseMappingProfile>();
               
            });
            services.AddScoped<ICourseService,CourseService>();
            services.AddScoped<ICourseModuleService,CourseModuleService>();
            return services;
        }
    }
}
