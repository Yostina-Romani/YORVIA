using Microsoft.AspNetCore.Identity;

namespace YORVIA.Infrastructure.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string name { get; set; }
    }
}
