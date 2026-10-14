namespace YORVIA.Application.Features.Authentication.DTOs
{
    public class LoginResponseDTO
    {
        public bool success { get; set; }

        public string message { get; set; }

        public string ?token { get; set; }
    }
}
