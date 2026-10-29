
using YORVIA.Domain.Entities;
using YORVIA.Application.Features.Courses.Interfaces;
using YORVIA.Application.Features.Courses.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using YORVIA.Application.Common;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace YORVIA.Application.Features.Courses.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository= courseRepository;
        }
        public async Task<Response<CourseDto?>> AddAsync(CreateCourseDto createCourseDto)
        {
            if (createCourseDto == null)
            {
                return new Response<CourseDto?>
                {
                    Message = "the course is null",
                    Success = false,
                    Data = null,
                    ErrorType = Common.ErrorType.Validation

                };
            }
            var course = new Course
            {
                courseName = createCourseDto!.courseName,
                courseDescription = createCourseDto.courseDescription,
              
            };
            await _courseRepository.AddAsync(course);

            var courseDto = new CourseDto
            {
                courseName = course.courseName,
                courseDescription = course.courseDescription,
                courseId = course.courseId
            };
            return new Response<CourseDto?>
            {
                Success = true,
                Message = "course added successfully",
                Data=courseDto
            };

        }

        public async Task<Response<CourseDto?>> GetByIdAsync(int id)
        {
            var result = await _courseRepository.GetByIdAsync(id);

           if(result == null)
            {
                return new Response<CourseDto?>
                {
                    Success = false,
                    Message="the course is null",
                    Data=null,
                    ErrorType=ErrorType.NotFound
                };

            }
            var courseDto = new CourseDto
            {
                courseName = result.courseName,
                courseDescription = result.courseDescription,
                courseId = result.courseId
            };

            return new Response<CourseDto?>
            {
                Success = true,
                Message = "Course retrieved successfully.",
                Data = courseDto

            };
          
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var result = await _courseRepository.GetByIdAsync(id);
            if (result==null)
            {
                return new Response<bool>
                {
                    Success = false,
                    Message = "the course was not found",
                    Data=false,
                    ErrorType=ErrorType.NotFound

                };
            }
            var deleted = await _courseRepository.DeleteAsync(id);
            if (!deleted)
            {
                return new Response<bool>
                {
                    Success = deleted,
                    Message = "failed to delete",
                    Data = deleted,
                    ErrorType=ErrorType.Failure
                };
            }

            return new Response<bool>
            {
                Success = deleted,
                Message = "deleted successfully",
                Data = deleted,
                ErrorType = ErrorType.None

            };
         

        }

        public async Task<Response<CourseDto?>>UpdateAsync(UpdateCourseDto updateCourseDto,int id)
        {
            if (updateCourseDto == null)
            {
                return new Response<CourseDto?>
                {
                    Message = "update course cannot be null",
                    Data = null,
                    Success=false,
                    ErrorType=ErrorType.Validation
                };

            }
            var course = new Course
            {
                courseDescription = updateCourseDto!.courseDescription,
                courseName = updateCourseDto.courseName,
                courseId=id
            };

            var result = await _courseRepository.UpdateAsync(course);

            if (result == null)
            {
                return new Response<CourseDto?>
                {
                    Success = false,
                    Message = "updated failed",
                    Data = null,
                    ErrorType=ErrorType.Failure
                };

            }

            var response = new CourseDto
            {
                courseName = result!.courseName,
                courseDescription = result.courseDescription,
                courseId = result.courseId
            };

            return new Response<CourseDto?>
            {
                Data=response,
                Success=true,
                Message="updated successfully"
            };
        }

        public async Task <Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            if (courses.Count == 0)
            {
                return new Response<List<CourseDto>>
                {
                    Data = new List<CourseDto>(),
                    Success = true,
                    Message = "there not courses yet ."
                };

            }
            var result = new List<CourseDto>();


           foreach(var course in courses)
            {
                var courseDto = new CourseDto
                {
                    courseName = course.courseName,
                    courseDescription = course.courseDescription,
                    courseId = course.courseId
                };
                result.Add(courseDto);
            }
            return new Response<List<CourseDto>>
            {
                Success=true,
                Message="the courses are :",
                Data=result
            };
        }

    }
}
