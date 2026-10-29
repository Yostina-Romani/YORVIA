using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using YORVIA.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace YORVIA.Infrastructure.Identity
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string name { get; set; } = string.Empty;

        public ICollection<Course> courses { get; set; } = new Collection<Course>();
    }
}
