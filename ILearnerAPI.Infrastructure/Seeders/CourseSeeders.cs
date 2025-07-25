using ILeanerAPI.Domain.Entity;
using ILearnerAPI.Infrastructure.Persistence;


namespace ILearnerAPI.Infrastructure.Seeders
{
    internal class CourseSeeders(CoursesDbContext dbContext) : ICourseSeeders
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Courses.Any())
                {
                    var courses = GetCourses();
                    dbContext.Courses.AddRange(courses);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Course> GetCourses()
        {
            List<Course> courses = [
                new(){Name="Frontedd Development",Description="This is the frontend development department",
                    Category="Web Development",
                CourseModule=[
                    new(){
                        Name="React",
                        Topics=new(){
                            "What is React", "Creating your first React-project"
                        },
                        Description="React is Javascript Frame work",
                        ModulePrice=200.00M,

                    }, new(){
                        Name="Javascript",
                        Topics=new(){
                            "What is Javascript", "Creating your first Javascript-project"
                        },
                        Description="Javascript is a script language",
                        ModulePrice=100.00M,

                    },
                    ]
                },

                 new(){Name="Backend Development",Description="This is the Backend development department",
                    Category="Web Development",
                CourseModule=[
                    new(){
                        Name="Node.js",
                        Topics=new(){
                            "What is Node", "Creating your first React-project"
                        },
                        Description="React is Javascript Frame work",
                        ModulePrice=200.00M,

                    }, new(){
                        Name="Express",
                        Topics=new(){
                            "What is Express", "Creating your first Express-project"
                        },
                        Description="Express is a Node project",
                        ModulePrice=100.00M,

                    },
                    ]
                }
                ];
            return courses;
        }
    }
}