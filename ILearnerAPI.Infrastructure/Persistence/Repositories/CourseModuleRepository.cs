using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.CourseModule.Dto;
using ILearnerAPI.Application.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Infrastructure.Persistence.Repositories
{
    public class CourseModuleRepository(CoursesDbContext context):ICourseModuleRepository
    {
       

        public async Task<CourseModuleTab> CreateCourseModuleRepoAsync(CourseModuleTab module)
        {
            var entry = await context.CourseModules.AddAsync(module);

            await context.SaveChangesAsync();

            return entry.Entity;

        }

        public async Task DeleteCourseModuleRepoAsync(CourseModuleTab module)
        {
            context.CourseModules.Remove(module);
        }

        public async Task<CourseModuleTab?> GetCourseModuleByIdAsync(int courseId, int moduleId)
        {
            return await context.CourseModules
                                    .FirstOrDefaultAsync(cmt => cmt.CourseId == courseId && cmt.Id == moduleId);
        }

        public async Task<IEnumerable<CourseModuleTab>> GetModuleForACourse(int courseId)
        {
            return await context.CourseModules
                                   .Where(cmt => cmt.CourseId == courseId)
                                   .ToListAsync();
        }

        public async Task UpdateCourseModuleRepoAsync(CourseModuleTab module)
        {
            if (context.Entry(module).State == EntityState.Detached)
            {
                context.CourseModules.Attach(module);
            }
            context.Entry(module).State = EntityState.Modified;
        }
        public async Task<bool> ModuleExistsAsync(int courseId, int moduleId)
        {
            return await context.CourseModules.AnyAsync(cmt => cmt.CourseId == courseId && cmt.Id == moduleId);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
