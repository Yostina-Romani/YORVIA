
using YORVIA.Application.Abstractions.Authentication;
using YORVIA.Application.Features.Authentication.DTOs;
using YORVIA.Application.Features.Authentication.Interfaces;

namespace YORVIA.Application.Features.Authentication.Services
{
    public class LoginService: ILoginServise
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public LoginService(IIdentityService identityService,ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await _identityService.LoginUserAsync(loginRequestDTO.password, loginRequestDTO.email);

            if (result==null)
            {
                return new LoginResponseDTO
                {
                    message = "login failed .",
                    success = false

                };
            }

            var token = _tokenService.GenerateToken(result.UserId,result.Email,result.Roles);
            return new LoginResponseDTO
            {
                success = true,
                message = "login successfully",
                token=token
                
            };

        }
    }
}
