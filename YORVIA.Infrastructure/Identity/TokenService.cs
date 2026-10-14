using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YORVIA.Application.Abstractions.Authentication;
using Microsoft.Extensions.Configuration;
namespace YORVIA.Infrastructure.Identity
{
    public class TokenService:ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration= configuration; 

        }
     public   string GenerateToken(string userid,string email,IEnumerable<string>roles)
        {
            var secretkey = _configuration["Authentication:Jwt:SecretKey"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,userid),
                new Claim(JwtRegisteredClaimNames.Email,email),
                
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Jwt:Issuer"],
                audience: _configuration["Authentication:Jwt:Audience"],
                expires: DateTime.UtcNow.AddMinutes(30),
                claims:claims,
                signingCredentials:credentials

                );

             var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
            
        
        }
    }
}
