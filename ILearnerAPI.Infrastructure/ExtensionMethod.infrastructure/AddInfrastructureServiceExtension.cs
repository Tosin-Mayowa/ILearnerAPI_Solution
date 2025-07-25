using ILearnerAPI.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ILearnerAPI.Infrastructure.Seeders;
using ILearnerAPI.Application.Interface;
using ILearnerAPI.Infrastructure.Persistence.Repositories;

namespace ILearnerAPI.Infrastructure.ExtensionMethod.infrastructure
{
    public static class AddInfrastructureServiceExtension
    {

        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,string connStr)
        {
            services.AddScoped<ICourseRepository,CourseRepository>();

            services.AddDbContext<CoursesDbContext>(options =>
            {
                options.UseSqlServer(connStr, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("ILearnerAPI.Infrastructure");
                });
            });
            services.AddScoped<ICourseSeeders, CourseSeeders>();
            return services;
        }

      
    }
}
