using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VehicleTask.Application.DTOs;
using VehicleTask.Application.Intefaces.Services;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token CreateToken(User user)
    {
        var tokenExpiration = DateTime.Now.AddMinutes(20);

        var securityKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecurityKey").Value));

        var signingCredentials =
            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var jwt = new JwtSecurityToken(expires: tokenExpiration, signingCredentials: signingCredentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new Token() { AccessToken = token, Expiration = tokenExpiration };
    }
}