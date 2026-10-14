using Microsoft.AspNetCore.Mvc;
using YORVIA.Application.Features.Authentication.DTOs;
using YORVIA.Application.Features.Authentication.Interfaces;

namespace YORVIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly IRegisterService _registerService;
        private readonly ILoginServise _loginServise;
        public AuthController(IRegisterService registerService,ILoginServise loginServise)
        {
            _registerService = registerService;
            _loginServise = loginServise;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO model)
        {
            var result =await _registerService.Register(model);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
            
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginRequestDTO model)
        {
            var result =await _loginServise.Login(model);

            if (!result.success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
