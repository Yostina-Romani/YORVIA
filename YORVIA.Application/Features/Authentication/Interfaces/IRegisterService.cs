using YORVIA.Application.Features.Authentication.DTOs;


namespace YORVIA.Application.Features.Authentication.Interfaces
{
    public interface IRegisterService
    {
        Task<ResponseRegisterDTO> Register(RegisterRequestDTO model);
    }
}
