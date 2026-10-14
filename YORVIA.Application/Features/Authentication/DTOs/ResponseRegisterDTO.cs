namespace YORVIA.Application.Features.Authentication.DTOs
{
    public class ResponseRegisterDTO
    {

        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string? Email { get; set; }

        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
