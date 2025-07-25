using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.Courses.Dtos;

namespace ILearnerAPI.Application.Courses
{
    public interface ICourseService
    {
        Task<IEnumerable<CoursesDto>> GetCourses();
        Task<CoursesDto> GetCourseByIdAsync(int id);
        Task<CoursesDto> CreateCourseAsync(CreateCourseDto request); 
        Task<bool> UpdateCourseAsync(int id, UpdateCourseDto request); 
        Task<bool> DeleteCourseAsync(int id);
    }
}