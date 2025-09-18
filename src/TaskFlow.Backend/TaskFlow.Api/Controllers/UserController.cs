using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Common;
using TaskFlow.Application.DTOs.Users;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserServices userServices) : Controller
{
    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> Register([FromBody] CreateUserDto dto)
    {
        try
        {
            var user = await userServices.CreateAsync(dto);

            var response = new ApiResponse<UserResponseDto>
            {
                Data = user,
                Success = true,
                Message = "Usuário criado com sucesso.",
                Errors = []
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            var response = new ApiResponse<UserResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao criar usuário.",
                Errors = [ex.Message]
            };

            return BadRequest(response);
        }
    }
}