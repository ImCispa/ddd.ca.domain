namespace DDD.CA.Infrastructure.Results;

/// <summary>
/// Represents the result of an operation, indicating whether it was successful or failed.
/// </summary>
public class Result<T> : Result
{
    /// <summary>
    /// Represents the result of an operation, indicating whether it was successful or failed.
    /// Provides static methods for creating success or failure results.
    /// </summary>
    protected internal Result(T? value, bool isSucceed) : base(isSucceed)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the value associated with the current result.
    /// This property holds the result's underlying data if the operation was successful or failed with a value.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Creates a successful result for an operation, with the option to include a value.
    /// </summary>
    /// <param name="value">The value associated with the successful operation. Defaults to the default value of the specified type if not provided.</param>
    /// <returns>A result representing a successful operation, optionally containing the specified value.</returns>
    public static Result<T> Success(T? value = default)
    {
        return new Result<T>(value, true);
    }


    /// <summary>
    /// Creates a failed result of an operation for the specified type.
    /// </summary>
    /// <param name="value">The optional value to associate with the failed result.</param>
    /// <returns>A failed result containing the specified value.</returns>
    public static Result<T> Fail(T? value = default)
    {
        return new Result<T>(value, false);
    }
}
