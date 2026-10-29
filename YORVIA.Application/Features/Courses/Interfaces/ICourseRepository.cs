using YORVIA.Domain.Entities;


namespace YORVIA.Application.Features.Courses.Interfaces
{
    public interface ICourseRepository
    {

        Task AddAsync(Course course );
        Task<Course ?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);
        Task<Course?> UpdateAsync(Course course);
        Task<List<Course>> GetAllAsync();

    }
}
