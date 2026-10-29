
using System.ComponentModel.DataAnnotations;


namespace YORVIA.Application.Features.Courses.DTOs
{
    public class UpdateCourseDto
    {

        

        [Required]
        [MaxLength(200)]
        public string courseName { get; set; } = string.Empty;

        [Required]
        [MaxLength(2000)]
        public string courseDescription { get; set; } = string.Empty;

       
    }
}
