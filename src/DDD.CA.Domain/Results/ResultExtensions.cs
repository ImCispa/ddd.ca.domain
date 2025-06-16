namespace DDD.CA.Infrastructure.Results;

/// <summary>
/// Provides extension methods for working with instances of <see cref="Result"/> and <see cref="Result{T}"/>.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Executes a specified function if the current result is successful.
    /// </summary>
    /// <param name="result">The current result to evaluate.</param>
    /// <param name="toExecute">The function to execute if the current result is successful.</param>
    /// <returns>The result of the executed function if the current result is successful; otherwise, the original failed result.</returns>
    public static Result IfSucceed(this Result result, Func<Result> toExecute)
    {
        return result.Failed ? result : toExecute.Invoke();
    }

    /// <summary>
    /// Executes the provided function if the result indicates success; otherwise, returns the current result.
    /// </summary>
    /// <param name="result">The result to evaluate for success.</param>
    /// <param name="toExecute">The function to execute if the result indicates success.</param>
    /// <returns>The result of the function execution if the initial result succeeds; otherwise, the current result.</returns>
    public static Result<T> IfSucceed<T>(this Result result, Func<Result<T>> toExecute)
    {
        return result.Failed ? Result<T>.Fail() : toExecute.Invoke();
    }

    /// <summary>
    /// Executes the specified function if the current result is successful.
    /// </summary>
    /// <param name="result">The result that determines whether the function should be executed.</param>
    /// <param name="toExecute">The function to execute if the result is successful.</param>
    /// <returns>The new result returned from the function if the current result is successful; otherwise, the current result.</returns>
    public static Result<T> IfSucceed<T>(this Result<T> result, Func<T, Result> toExecute)
    {
        if (result.Failed || result.Value is null)
        {
            return result;
        }

        var res = toExecute.Invoke(result.Value);
        return res.Succeed ? Result<T>.Success(result.Value) : result;
    }

    /// <summary>
    /// Executes the specified function if the current result is successful.
    /// </summary>
    /// <param name="result">The current result to evaluate.</param>
    /// <param name="toExecute">The function to execute if the current result is successful.</param>
    /// <returns>The result of the executed function if the current result is successful; otherwise, the original failed result.</returns>
    public static Result<T> IfSucceed<T>(this Result<T> result, Action<T> toExecute)
    {
        if (result.Failed || result.Value is null)
        {
            return result;
        }

        toExecute.Invoke(result.Value);
        return result;
    }
    
    /// <summary>
    /// Checks whether all the given results succeed.
    /// </summary>
    /// <param name="items">A collection of results to be checked.</param>
    /// <returns>A valid result if all input results are valid; otherwise, an invalid result.</returns>
    public static Result IfAllSucceeds(this IEnumerable<Result> items)
    {
        return items.All(i => i.Succeed) ? Result.Success() : Result.Fail();
    }
    
    /// <summary>
    /// Executes a specified function if the current result is a failure.
    /// </summary>
    /// <param name="result">The current result to evaluate.</param>
    /// <param name="toExecute">The function to execute if the current result is a failure.</param>
    /// <returns>The result of the executed function if the current result is a failure; otherwise, a successful result.</returns>
    public static Result IfFailed(this Result result, Func<Result> toExecute)
    {
        return result.Succeed ? result : toExecute.Invoke();
    }
}
