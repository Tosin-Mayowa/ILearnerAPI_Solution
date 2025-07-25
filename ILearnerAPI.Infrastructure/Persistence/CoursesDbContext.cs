
using ILeanerAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace ILearnerAPI.Infrastructure.Persistence
{
    public class CoursesDbContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseModuleTab> CourseModules { get; set; }
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
       : base(options)
        {
        }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasMany(r => r.CourseModule)
                 .WithOne(cm => cm.Course)
                .HasForeignKey(r => r.CourseId);
        }
    }
}
