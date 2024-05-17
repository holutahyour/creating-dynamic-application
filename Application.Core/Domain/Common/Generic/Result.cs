namespace Application.Core.Domain;

public class Result<T>
{
    public T Content { get; set; }
    public bool HasError => ErrorMessage != "";
    public string ErrorMessage { get; set; } = "";
    public string Message { get; set; } = "";
    public string RequestId { get; set; } = "";
    public bool IsSuccess { get; set; } = true;
    public DateTime RequestTime { get; set; } = DateTime.UtcNow;
    public DateTime ResponseTime { get; set; } = DateTime.UtcNow;

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public void SetError(string errorMessage, string messsage)
    {
        ErrorMessage = errorMessage;
        Message = messsage;
        IsSuccess = false;
    }

    public void SetSuccess(T content, string messsage)
    {
        Content = content;
        IsSuccess = true;
        Message = messsage;
    }
}
