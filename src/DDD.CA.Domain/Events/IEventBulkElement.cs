using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Represents an element in a bulk event, providing validation functionality
/// to ensure the element's integrity and usability within the domain context.
/// </summary>
public interface IEventBulkElement
{
    /// <summary>
    /// Validates the current event bulk element to ensure it is appropriately configured and usable.
    /// </summary>
    /// <param name="process">The process instance providing context, signaling, and cancellation handling during the validation.</param>
    /// <returns>A <see cref="Result"/> indicating the success or failure of the validation operation.</returns>
    Result Validate(Process process);
}