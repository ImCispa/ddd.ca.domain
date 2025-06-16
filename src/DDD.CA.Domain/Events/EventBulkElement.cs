using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Represents an abstract base class for elements that are part of a bulk event.
/// </summary>
public abstract class EventBulkElement : IEventBulkElement
{
    /// <summary>
    /// Validates the current event bulk element against the provided process.
    /// </summary>
    /// <param name="process">
    /// The process instance against which the validation will be performed.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> object indicating the success or failure of the validation.
    /// </returns>
    public abstract Result Validate(Process process);
}
