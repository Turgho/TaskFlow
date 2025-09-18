using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Auth;

public class JwtServices(IOptions<JwtSettings> settings) : IJwtServices
{
    private readonly JwtSettings _settings = settings.Value;

    public JwtToken GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.Jti, Guid.CreateVersion7().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiresAt = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: creds
        );

        return new JwtToken(
            Token: new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresAt: expiresAt
        );
    }
}