using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SanadService.Jwt
{
    public class JwtService
    {
        private readonly JwtOptions _jwtOptions;

        public JwtService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string CreateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.UtcNow.AddDays(_jwtOptions.LifeTime),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {

                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())

                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
