using Moq;
using YORVIA.Application.Features.Courses.DTOs;
using YORVIA.Application.Features.Courses.Interfaces;
using YORVIA.Application.Features.Courses.Services;
using YORVIA.Application.Common;
using YORVIA.Domain.Entities;
using System.Security.AccessControl;

namespace YORVIA.Tests
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> repomock;
        public CourseServiceTests()
        {
             repomock = new Mock<ICourseRepository>();
        }




        [Fact]

        public  async Task AddAsync_WhenDtoIsValid_ReturnsSuccess()
        {
            var service = new CourseService(repomock.Object);

            var cousrseDto = new CreateCourseDto
            {
                courseDescription = "c# basics",
                courseName = "c#"
            };

            var result=await service.AddAsync(cousrseDto);

            Assert.True(result.Success);

            Assert.Equal("c#", result.Data!.courseName);
            Assert.Equal("c# basics", result.Data.courseDescription);
            repomock.Verify(r => r.AddAsync(It.IsAny<Course>()), Times.Once);

        }

        [Fact]
        public async Task AddAsync_WhenDtoIsNull_ReturnsFailure()
        {
            var service = new CourseService(repomock.Object);
            var result = await service.AddAsync(null!);

            Assert.False(result.Success);
            Assert.Null( result.Data);
            Assert.Equal(ErrorType.Validation, result.ErrorType);
            repomock.Verify(r => r.AddAsync(It.IsAny<Course>()), Times.Never);
        }


        [Fact]
        public async Task GetByIdAsync_WhenIdIsValid_ReturnsSuccessWithCourseDto()
        {
            var id = 1;
            var course = new Course
            {
                courseId = 1,
                courseName = "oop",
                courseDescription = "oop basics"
            };

            repomock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(course);


            var service = new CourseService(repomock.Object);
            
            var result = await service.GetByIdAsync(id);
            Assert.True(result.Success);
            Assert.Equal("oop",result.Data!.courseName);
            Assert.Equal("oop basics", result.Data.courseDescription);
            
            repomock
        }
    }
}
