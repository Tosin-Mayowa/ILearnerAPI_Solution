using AutoMapper;
using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.CourseModule.Dto;
using ILearnerAPI.Application.Courses.Dtos;


namespace ILearnerAPI.Application.Mappers
{
    public class CourseMappingProfile:Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course,CoursesDto>();

            CreateMap<CourseModuleTab, CourseModuleDto>();

            CreateMap<CreateCourseDto, Course>();
            CreateMap<CreateCourseModuleDto, CourseModuleTab>();
        }
    }
}
