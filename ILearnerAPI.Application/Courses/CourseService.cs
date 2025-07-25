using AutoMapper;
using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.Courses.Dtos;
using ILearnerAPI.Application.Interface;
using Microsoft.Extensions.Logging;


namespace ILearnerAPI.Application.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseService> _logger;
        public CourseService(ICourseRepository courseRepository, ILogger<CourseService> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }


     

        public async Task<IEnumerable<CoursesDto>> GetCourses()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CoursesDto>>(courses); // Use AutoMapper for mapping
        }

        public async Task<CoursesDto?> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            return _mapper.Map<CoursesDto>(course); 
        }

        public async Task<CoursesDto> CreateCourseAsync(CreateCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto); 
            var addedCourse = await _courseRepository.AddCourseAsync(course);
            await _courseRepository.SaveChangesAsync(); 
            return _mapper.Map<CoursesDto>(addedCourse); 
        }

        public async Task<bool> UpdateCourseAsync(int id, UpdateCourseDto courseDto)
        {
            var courseToUpdate = await _courseRepository.GetByIdAsync(id);
            if (courseToUpdate == null)
            {
                return false; 
            }

            _mapper.Map(courseDto, courseToUpdate); 
            await _courseRepository.UpdateCourseAsync(courseToUpdate);
            await _courseRepository.SaveChangesAsync(); 
            return true;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            if (!await _courseRepository.CourseExistsAsync(id))
            {
                return false; 
            }

            await _courseRepository.DeleteCourseAsync(id);
            await _courseRepository.SaveChangesAsync(); 
            return true;
        }
    }
}
