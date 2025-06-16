namespace DDD.CA.Infrastructure.Results;

/// <summary>
/// Represents the result of an operation, indicating whether it was successful or failed.
/// </summary>
public class Result
{
    /// <summary>
    /// Represents the result of an operation, indicating whether it was successful or failed.
    /// </summary>
    protected internal Result(bool isSucceed)
    {
        Succeed = isSucceed;
    }

    /// <summary>
    /// Gets a value indicating whether the operation completed successfully.
    /// This property can be used to determine if the operation produced the desired outcome.
    /// </summary>
    public bool Succeed { get; }

    /// <summary>
    /// Gets a value indicating whether the operation has failed.
    /// This property returns the inverse of the <c>Successed</c> property,
    /// providing a convenient way to verify if the operation was unsuccessful.
    /// </summary>
    public bool Failed => !Succeed;

    /// <summary>
    /// Creates a successful result instance, indicating that the operation was successful.
    /// </summary>
    /// <returns>
    /// A <see cref="Result"/> instance representing success.
    /// </returns>
    public static Result Success()
    {
        return new Result(true);
    }

    /// <summary>
    /// Creates a failed result instance, indicating that the operation was unsuccessful.
    /// </summary>
    /// <returns>
    /// A <see cref="Result"/> instance representing failure.
    /// </returns>
    public static Result Fail()
    {
        return new Result(false);
    }
}
