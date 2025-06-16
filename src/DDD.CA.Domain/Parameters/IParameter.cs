using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Parameters;

/// <summary>
/// Represents an interface for handling parameter-related operations within a process.
/// </summary>
public interface IParameter
{
    /// <summary>
    /// Reads the specified parameter for the given process and returns the result.
    /// </summary>
    /// <typeparam name="T">The type of the parameter value.</typeparam>
    /// <param name="parameter">The parameter to be read.</param>
    /// <param name="process">The process context in which the parameter is being read.</param>
    /// <returns>A result object containing the value of the parameter if successful, or an error state if the operation failed.</returns>
    Result<T> Read<T>(Parameter<T> parameter, Process process);
}
