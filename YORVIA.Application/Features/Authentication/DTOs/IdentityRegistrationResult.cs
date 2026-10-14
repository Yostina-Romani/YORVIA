namespace YORVIA.Application.Features.Authentication.DTOs
{
    public class IdentityRegistrationResult
    {
        public bool succeeded { get; set; }

        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
