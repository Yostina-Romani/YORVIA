using YORVIA.Application.Features.Authentication.DTOs;

namespace YORVIA.Application.Features.Authentication.Interfaces
{
    public interface ILoginServise
    {
       public Task<LoginResponseDTO>Login(LoginRequestDTO model);
    }
}
