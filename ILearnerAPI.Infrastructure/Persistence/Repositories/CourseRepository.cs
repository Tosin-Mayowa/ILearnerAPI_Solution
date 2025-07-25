using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Application.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILearnerAPI.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CoursesDbContext _context;

        public CourseRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
           return await _context.Courses.Include(c=>c.CourseModule)
                .ToListAsync();

        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                                   .Include(c => c.CourseModule)
                                   .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            return course; 
        }

        public async Task UpdateCourseAsync(Course course)
        {
          
            _context.Entry(course).State = EntityState.Modified;

        }

        public async Task DeleteCourseAsync(int id)
        {
            var courseToDelete = await _context.Courses.FindAsync(id);
            if (courseToDelete != null)
            {
                _context.Courses.Remove(courseToDelete);
            }
        }

        public async Task<bool> CourseExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
