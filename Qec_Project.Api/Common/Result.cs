namespace QEC_Project.API.Common
{
  public class Result<T>
  {
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Value { get; private set; }

    private Result(T value, string message, bool success)
    {
      Value = value;
      Success = success;
      Message = message;

    }

    public static Result<T> OK(T value)
    {
      return new Result<T>(value, null, true);
    }

    public static Result<T> Failure(string message)
    {
      return new Result<T>(default, message, false);
    }

  }
}