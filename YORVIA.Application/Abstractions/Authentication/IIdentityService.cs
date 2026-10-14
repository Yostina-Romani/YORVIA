using YORVIA.Application.Features.Authentication.DTOs;

namespace YORVIA.Application.Abstractions.Authentication
{
    public interface IIdentityService
    {
       public Task<IdentityRegistrationResult> RegisterUserAsync(string username, string password, string email);

        public Task<IdentityLoginResult?> LoginUserAsync( string password, string email );

    }
}
