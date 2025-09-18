using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Common;
using TaskFlow.Application.DTOs.Users;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IUserServices userServices) : AuthenticatedController
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> Register([FromBody] CreateUserDto dto)
    {
        try
        {
            var user = await userServices.CreateAsync(dto);
            return Ok(new ApiResponse<UserResponseDto>
            {
                Data = user,
                Success = true,
                Message = "Usuário criado com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UserResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao criar usuário.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserResponseDto>>>> GetAll()
    {
        try
        {
            var users = await userServices.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<UserResponseDto>>
            {
                Data = users,
                Success = true,
                Message = "Usuários obtidos com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<UserResponseDto>>
            {
                Data = null,
                Success = false,
                Message = "Erro ao obter usuários.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetById(Guid id)
    {
        try
        {
            var userId = GetUserId();
            if (userId != id)
                return Unauthorized(new ApiResponse<UserResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Ação não autorizada.",
                    Errors = ["Você só pode atualizar sua própria conta."]
                });
            
            var user = await userServices.GetByIdAsync(id);
            if (user == null)
                return NotFound(new ApiResponse<UserResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Usuário não encontrado.",
                    Errors = []
                });

            return Ok(new ApiResponse<UserResponseDto>
            {
                Data = user,
                Success = true,
                Message = "Usuário obtido com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UserResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao obter usuário.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApiResponse<UserResponseDto>>> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        try
        {
            var userId = GetUserId();
            if (userId != id)
                return Unauthorized(new ApiResponse<UserResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Ação não autorizada.",
                    Errors = ["Você só pode atualizar sua própria conta."]
                });

            var user = await userServices.UpdateAsync(id, dto);

            return Ok(new ApiResponse<UserResponseDto>
            {
                Data = user,
                Success = true,
                Message = "Usuário atualizado com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<UserResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao atualizar usuário.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            var userId = GetUserId();
            if (userId != id)
                return Unauthorized(new ApiResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Ação não autorizada.",
                    Errors = ["Você só pode deletar sua própria conta."]
                });

            var deleted = await userServices.DeleteAsync(id);

            return deleted 
                ? Ok(new ApiResponse<bool> { Data = true, Success = true, Message = "Usuário deletado com sucesso.", Errors = [] })
                : NotFound(new ApiResponse<bool> { Data = false, Success = false, Message = "Usuário não encontrado.", Errors = [] });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Erro ao deletar usuário.",
                Errors = [ex.Message]
            });
        }
    }
}