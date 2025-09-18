using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Common;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthServices authServices) : Controller
{
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginDto dto)
    {
        try
        {
            var result = await authServices.LoginAsync(dto);

            if (result is null)
            {
                return BadRequest(new ApiResponse<LoginResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "E-mail ou senha inválidos.",
                    Errors = ["E-mail ou senha inválidos."]
                });
            }

            return Ok(new ApiResponse<LoginResponseDto>
            {
                Data = result,
                Success = true,
                Message = "Login realizado com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<LoginResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao realizar login.",
                Errors = [ex.Message]
            });
        }
    }
}