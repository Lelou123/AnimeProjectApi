namespace InitProject.Model.Dto;

public class BaseResponseDto<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }

    public BaseResponseDto(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Result = data;
    }
}
