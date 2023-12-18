namespace App.Wiz.Common.GenericServiceResponse;

public class ServiceResponse
{
    private ServiceResponse(bool isSuccessful,
                            string message,
                            object? response)
    {
        IsSuccess = isSuccessful;
        Message = message;
        Data = response;
    }

    private ServiceResponse(bool isSuccessful,
                            string message)
    {
        IsSuccess = isSuccessful;
        Message = message;
    }
    public static ServiceResponse Success(string message)
    {
        return new(true, message);
    }

    public static ServiceResponse Success(string message, object data)
    {
        return new(true, message, data);
    }

    public static ServiceResponse Failure(string message)
    {
        return new(false, message);
    }

    public static ServiceResponse Failure(string message, object data)
    {
        return new(false, message, data);
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }
}
