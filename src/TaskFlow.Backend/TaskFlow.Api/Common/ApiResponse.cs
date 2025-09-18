namespace TaskFlow.Api.Common;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];

    public static ApiResponse<T> Ok(T data, string message = "Operação realizada com sucesso")
        => new() { Data = data, Message = message, Success = true };

    public static ApiResponse<T> Fail(string error, string message = "Erro na operação")
        => new() { Errors = [error], Message = message, Success = false };
}