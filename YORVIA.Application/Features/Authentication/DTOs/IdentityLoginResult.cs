namespace YORVIA.Application.Features.Authentication.DTOs
{
    public class IdentityLoginResult
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

       public IList<string> Roles { get; set; } = new List<string>(); 
    }

}
