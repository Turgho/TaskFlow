using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskFlow.Api.Controllers;

[Authorize]
public class AuthenticatedController : ControllerBase
{
    protected Guid GetUserId()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        return userIdClaim is null
            ? throw new UnauthorizedAccessException("Token inválido ou expirado.")
            : Guid.Parse(userIdClaim.Value);
    }
}