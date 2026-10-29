using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YORVIA.Application.Features.Courses.DTOs;
using YORVIA.Application.Features.Courses.Interfaces;
using YORVIA.API.Extensions;

namespace YORVIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourseSync(CreateCourseDto createCourseDto)
        {
            var result = await _courseService.AddAsync(createCourseDto);
            

            return this.ToActionResult(result);
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _courseService.GetByIdAsync(id);

            return this.ToActionResult(result);

        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteAsync(id);

            
            return this.ToActionResult(result);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult>UpdateCourse(UpdateCourseDto updateCourseDto,int id)
        {
           
            var result = await _courseService.UpdateAsync(updateCourseDto,id);
           
            return this.ToActionResult(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _courseService.GetAllAsync();
            

            return this.ToActionResult(result);
        }

    } 
}

