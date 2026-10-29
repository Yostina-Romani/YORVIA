using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YORVIA.Domain.Entities
{
    public class Course
    {
        [Key]
        public int  courseId{ get; set; }

        [Required]
        public string courseName { get; set; } = string.Empty;

        [Required]
        public string courseDescription { get; set; } = string.Empty;

        public string userId { get; set; } = string.Empty;

        
    }
}
