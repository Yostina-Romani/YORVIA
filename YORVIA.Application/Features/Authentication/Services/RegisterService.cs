
using Microsoft.AspNetCore.Identity;
using YORVIA.Application.Features.Authentication.DTOs;
using YORVIA.Application.Features.Authentication.Interfaces;

using YORVIA.Application.Abstractions.Authentication;

namespace YORVIA.Application.Features.Authentication.Services
{
    public class RegisterService: IRegisterService
    {
        private readonly IIdentityService _identityService;
       public RegisterService(IIdentityService identityService)
        {
            _identityService=identityService;
        }
        public async Task<ResponseRegisterDTO> Register(RegisterRequestDTO model)
        {

            var result = await _identityService.RegisterUserAsync(model.UserName, model.Password, model.Email);
            if (!result.succeeded)
            {
                return new ResponseRegisterDTO
                {
                    Message = "Registration failed.",
                    Success = false,
                    Errors=result.Errors

                };
            }

  

            return new ResponseRegisterDTO
            {
                Email = model.Email,
                Message = "Registration successful.",
                Success = true

            };


        }
    }
}
