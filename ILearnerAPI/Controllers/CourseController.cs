using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.Courses;
using ILearnerAPI.Application.Courses.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILearnerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService= courseService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> Get()
        {
          
            var courses = await _courseService.GetCourses();

            if (courses == null || !courses.Any())
            {
                return NotFound("No courses found.");
            }

          
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById([FromRoute] int id)
        {
          
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

          
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CoursesDto>> CreateCourse([FromBody] CreateCourseDto courseDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var newCourseDto = await _courseService.CreateCourseAsync(courseDto);
            
            return CreatedAtAction(nameof(GetById), new { id = newCourseDto.Id }, newCourseDto);
        }

       
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDto courseDto)
        {
          

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _courseService.UpdateCourseAsync(id, courseDto);
            if (!success)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var success = await _courseService.DeleteCourseAsync(id);
            if (!success)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }
    }
}
