using System;
using YORVIA.Application.Features.Courses.DTOs;

namespace YORVIA.Application.Features.Courses.Interfaces
{
    public interface ICourseService
    {

        Task<Response<CourseDto?>> AddAsync(CreateCourseDto createCourseDto);
        Task<Response<CourseDto?>> GetByIdAsync(int id);

        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CourseDto?>> UpdateAsync(UpdateCourseDto updateCourseDto,int id);
        Task<Response<List<CourseDto>>> GetAllAsync();
    }
}
