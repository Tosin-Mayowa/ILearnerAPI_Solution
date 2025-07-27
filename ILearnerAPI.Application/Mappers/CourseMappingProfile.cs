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
           
            CreateMap<UpdateCourseDto,Course>()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<UpdateCourseModuleDto,CourseModuleTab>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
