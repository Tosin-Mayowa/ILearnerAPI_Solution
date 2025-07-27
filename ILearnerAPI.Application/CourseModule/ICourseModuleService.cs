using ILearnerAPI.Application.CourseModule.Dto;



namespace ILearnerAPI.Application.CourseModule
{
    public interface ICourseModuleService
    {
        Task<IEnumerable<CourseModuleDto>> GetModuleForCourse(int courseId);
        Task<CourseModuleDto> GetModuleByIdAsync(int courseId,int moduleId);
        Task<CourseModuleDto> CreateModuleAsync(int courseId,CreateCourseModuleDto request);
        Task<bool> UpdateModuleAsync(int courseId,int moduleId ,UpdateCourseModuleDto request);
        Task<bool> DeleteModuleAsync(int courseId,int moduleId);
    }
}
