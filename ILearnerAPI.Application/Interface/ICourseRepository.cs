using ILeanerAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddCourseAsync(Course course); 
        Task UpdateCourseAsync(Course course); 
        Task DeleteCourseAsync(int id); 
        Task<bool> CourseExistsAsync(int id); 
        Task SaveChangesAsync(); 

    }
}
