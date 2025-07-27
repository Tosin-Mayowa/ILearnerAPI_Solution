using ILearnerAPI.Application.CourseModule;
using ILearnerAPI.Application.CourseModule.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILearnerAPI.Controllers
{
    [Route("api/courses/{courseId}/modules")]
    [ApiController]
    public class CourseModuleController(ICourseModuleService _moduleService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModuleDto>>> GetModulesForCourse(int courseId)
        {
            var modules = await _moduleService.GetModuleForCourse(courseId);
            if (modules == null || !modules.Any())
            {
                return NotFound($"No modules found for course ID {courseId}.");
            }
            return Ok(modules);
        }

       
        [HttpGet("{moduleId}")]
        public async Task<ActionResult<CourseModuleDto>> GetModuleById(int courseId, int moduleId)
        {
            var module = await _moduleService.GetModuleByIdAsync(courseId, moduleId);
            if (module == null)
            {
                return NotFound($"Module with ID {moduleId} not found for course ID {courseId}.");
            }
            return Ok(module);
        }

        // POST api/courses/{courseId}/modules
        [HttpPost]
        public async Task<ActionResult<CourseModuleDto>> CreateModule(int courseId, [FromBody] CreateCourseModuleDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newModuleDto = await _moduleService.CreateModuleAsync(courseId, request);
                return CreatedAtAction(nameof(GetModuleById), new { courseId = newModuleDto.CourseId, moduleId = newModuleDto.Id }, newModuleDto);
            }
            catch (InvalidOperationException ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPatch("{moduleId}")]
        public async Task<IActionResult> UpdateModule(int courseId, int moduleId, [FromBody] UpdateCourseModuleDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _moduleService.UpdateModuleAsync(courseId, moduleId, request);
            if (!success)
            {
                return NotFound($"Module with ID {moduleId} not found for course ID {courseId}.");
            }

            return NoContent(); 
        }

        
        [HttpDelete("{moduleId}")]
        public async Task<IActionResult> DeleteModule(int courseId, int moduleId)
        {
            var success = await _moduleService.DeleteModuleAsync(courseId, moduleId);
            if (!success)
            {
                return NotFound($"Module with ID {moduleId} not found for course ID {courseId}.");
            }

            return NoContent();
        }
    }
}
