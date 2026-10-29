
using System.ComponentModel.DataAnnotations;


namespace YORVIA.Application.Features.Courses.DTOs
{
    public class CourseDto
    {
        [Key]
        public int courseId { get; set; }

        [Required]
        public string courseName { get; set; } = string.Empty;

        [Required]
        public string courseDescription { get; set; } = string.Empty;

        

    }
}
