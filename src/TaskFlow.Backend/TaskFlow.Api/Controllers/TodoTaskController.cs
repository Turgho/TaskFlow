using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Common;
using TaskFlow.Application.DTOs.TodoTasks;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoTaskController(ITodoTaskServices todoTaskServices) : AuthenticatedController
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TodoTaskResponseDto>>>> GetAll()
    {
        try
        {
            var userId = GetUserId();
            var tasks = await todoTaskServices.GetAllAsync(userId);
            return Ok(new ApiResponse<IEnumerable<TodoTaskResponseDto>>
            {
                Data = tasks,
                Success = true,
                Message = "Tasks obtidas com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<IEnumerable<TodoTaskResponseDto>>
            {
                Data = null,
                Success = false,
                Message = "Erro ao obter tasks.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<TodoTaskResponseDto>>> GetById(Guid id)
    {
        try
        {
            var task = await todoTaskServices.GetByIdAsync(id);
            if (task == null)
                return NotFound(new ApiResponse<TodoTaskResponseDto>
                {
                    Data = null,
                    Success = false,
                    Message = "Task não encontrada.",
                    Errors = []
                });

            return Ok(new ApiResponse<TodoTaskResponseDto>
            {
                Data = task,
                Success = true,
                Message = "Task obtida com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TodoTaskResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao obter task.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<TodoTaskResponseDto>>> Create([FromBody] CreateTodoTaskDto dto)
    {
        try
        {
            var userId = GetUserId();
            var task = await todoTaskServices.CreateAsync(userId, dto);

            return Ok(new ApiResponse<TodoTaskResponseDto>
            {
                Data = task,
                Success = true,
                Message = "Task criada com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TodoTaskResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao criar task.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ApiResponse<TodoTaskResponseDto>>> Update(Guid id, [FromBody] UpdateTodoTaskDto dto)
    {
        try
        {
            var task = await todoTaskServices.UpdateAsync(id, dto);
            return Ok(new ApiResponse<TodoTaskResponseDto>
            {
                Data = task,
                Success = true,
                Message = "Task atualizada com sucesso.",
                Errors = []
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<TodoTaskResponseDto>
            {
                Data = null,
                Success = false,
                Message = "Erro ao atualizar task.",
                Errors = [ex.Message]
            });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        try
        {
            var deleted = await todoTaskServices.DeleteAsync(id);

            return deleted
                ? Ok(new ApiResponse<bool> { Data = true, Success = true, Message = "Task deletada com sucesso.", Errors = [] })
                : NotFound(new ApiResponse<bool> { Data = false, Success = false, Message = "Task não encontrada.", Errors = [] });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Erro ao deletar task.",
                Errors = [ex.Message]
            });
        }
    }
}
