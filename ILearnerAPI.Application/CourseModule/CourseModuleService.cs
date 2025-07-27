using AutoMapper;
using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.CourseModule.Dto;
using ILearnerAPI.Application.Courses;
using ILearnerAPI.Application.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Application.CourseModule
{
    public class CourseModuleService(ICourseModuleRepository _moduleRepository,ICourseRepository _courseRepository ,ILogger<CourseService> logger, IMapper _mapper) : ICourseModuleService
    {
        public async Task<CourseModuleDto> CreateModuleAsync(int courseId,CreateCourseModuleDto request)
        {
            if (!await _courseRepository.CourseExistsAsync(courseId))
            {
                
                throw new InvalidOperationException($"Course with ID {courseId} not found.");
            }

            var module = _mapper.Map<CourseModuleTab>(request);
            module.CourseId = courseId;
            var addedModule = await _moduleRepository.CreateCourseModuleRepoAsync(module);
            await _moduleRepository.SaveChangesAsync();
            return _mapper.Map<CourseModuleDto>(addedModule);
        }

        public async Task<bool> DeleteModuleAsync(int courseId, int moduleId)
        {
            var moduleToDelete = await _moduleRepository.GetCourseModuleByIdAsync(courseId, moduleId);
            if (moduleToDelete == null)
            {
                return false; 
            }

            await _moduleRepository.DeleteCourseModuleRepoAsync(moduleToDelete);
            await _moduleRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CourseModuleDto> GetModuleByIdAsync(int courseId, int moduleId)
        {
            var module = await _moduleRepository.GetCourseModuleByIdAsync(courseId, moduleId);
            return _mapper.Map<CourseModuleDto>(module);
        }

        public async Task<IEnumerable<CourseModuleDto>> GetModuleForCourse(int courseId)
        {
            var modules = await _moduleRepository.GetModuleForACourse(courseId);
            return _mapper.Map<IEnumerable<CourseModuleDto>>(modules);
        }

        public async Task<bool> UpdateModuleAsync(int courseId, int moduleId, UpdateCourseModuleDto request)
        {
            var moduleToUpdate = await _moduleRepository.GetCourseModuleByIdAsync(courseId, moduleId);
            if (moduleToUpdate == null)
            {
                return false;
            }

            _mapper.Map(request, moduleToUpdate);
            await _moduleRepository.UpdateCourseModuleRepoAsync(moduleToUpdate);
            await _moduleRepository.SaveChangesAsync();
            return true;
        }
    }
}
