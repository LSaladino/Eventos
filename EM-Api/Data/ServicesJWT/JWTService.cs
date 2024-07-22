using Core.Domain.Model.User;
using Manager.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Data.ServicesJWT
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string TokenGenerate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var mykey = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            //claims.AddRange(user.Roles.Select(p => new Claim(ClaimTypes.Role, p.Description)));

            //generate token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _configuration.GetSection("JWT:Audience").Value,
                Issuer = _configuration.GetSection("JWT:Issuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JWT:MinutesExpire").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(mykey), SecurityAlgorithms.HmacSha512Signature)
            };

            var apiToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(apiToken);
        }

    }
}
