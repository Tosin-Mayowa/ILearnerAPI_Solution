using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.CourseModule.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.Interface
{
    public interface ICourseModuleRepository
    {
        Task<IEnumerable<CourseModuleTab>> GetModuleForACourse(int courseId);
        Task<CourseModuleTab> GetCourseModuleByIdAsync(int courseId, int moduleId);
        Task<CourseModuleTab> CreateCourseModuleRepoAsync(CourseModuleTab request);
        Task UpdateCourseModuleRepoAsync(CourseModuleTab module);
        Task DeleteCourseModuleRepoAsync(CourseModuleTab module);
        Task<bool> ModuleExistsAsync(int courseId, int moduleId);
        Task SaveChangesAsync(); 
    }
}
