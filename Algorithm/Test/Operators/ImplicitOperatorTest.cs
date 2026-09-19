namespace Test.Operators;

public enum ErrorType
{
    NotFound
}

public record Error(string Id, ErrorType Type, string Description);

public static class Errors
{
    public static Error DictionaryNotFound { get; } = new ("Dictionary.NotFound", ErrorType.NotFound, "Dictionary is not found.");
}

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    protected Result()
    {
        IsSuccess = true;
        Error = null;
    }
    
    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static Result Success() => new();

    public static implicit operator Result(Error error) => new(error);

    public override string ToString() => $"{IsSuccess}, {Error?.Description}";
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T value)
    {
        Value = value;
    }
    
    private Result(Error error) : base(error) { }
    
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(error);
    
    public override string ToString() => $"{IsSuccess}, {Value}, {Error?.Description}";
}

public class ImplicitOperatorTest
{
    public static void Main()
    {
        Result result = Result.Success();
        Console.WriteLine(result);
        
        Result result2 = Errors.DictionaryNotFound;
        Console.WriteLine(result2);
        
        Result<int> resultOfInt = 5;
        Console.WriteLine(resultOfInt);
        
        Result<int> resultOfInt2 = Errors.DictionaryNotFound;
        Console.WriteLine(resultOfInt2);
    }
}