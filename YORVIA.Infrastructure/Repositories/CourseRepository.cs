using Microsoft.EntityFrameworkCore;
using YORVIA.Application.Features.Courses.Interfaces;
using YORVIA.Domain.Entities;
using YORVIA.Infrastructure.Persistence;

namespace YORVIA.Infrastructure.Repositories
{
    
    public class CourseRepository:ICourseRepository
    {
        private readonly YORVIADbContext _yORVIADbContext;
        public CourseRepository(YORVIADbContext yORVIADbContext)
        {
            _yORVIADbContext = yORVIADbContext;

        }
        public async Task AddAsync(Course course)
        {
            await _yORVIADbContext.courses.AddAsync(course);
            await _yORVIADbContext.SaveChangesAsync();

        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var course = await _yORVIADbContext.courses.FindAsync(id) ;
            if (course == null)
            {
                return null;
            }

            return course;

        }
        public async Task<Course?> UpdateAsync( Course model)
        {
            var course = await _yORVIADbContext.courses.FindAsync(model.courseId);
            if (course == null)
            {
                return null;
            }
            course.courseDescription = model.courseDescription;
            course.courseName = model.courseName;
            await _yORVIADbContext.SaveChangesAsync();

            return course;

        }

        public async Task<List<Course>>GetAllAsync()
        {
            var courses = await _yORVIADbContext.courses.ToListAsync();
            

            return courses;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course =await _yORVIADbContext.courses.FirstOrDefaultAsync(c => c.courseId== id);
            if (course == null)
            {
                return false;
            }
             _yORVIADbContext.courses.Remove(course);

            await _yORVIADbContext.SaveChangesAsync();

            return true;

        }
    }
}
