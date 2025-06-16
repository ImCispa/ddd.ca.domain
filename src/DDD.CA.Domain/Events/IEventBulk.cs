using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Represents a bulk event that contains a collection of elements, providing functionality
/// for event validation and processing in the context of a domain.
/// </summary>
/// <typeparam name="TElement">
/// The type of the elements contained within the bulk event. Must implement the IEventBulkElement interface.
/// </typeparam>
public interface IEventBulk<TElement> : IEvent where TElement : IEventBulkElement
{
    /// <summary>
    /// Gets the collection of elements contained within the bulk event.
    /// </summary>
    /// <remarks>
    /// Each element in the collection represents a domain-specific unit of data or behavior
    /// that is part of the bulk event. The type of elements must implement the IEventBulkElement
    /// interface to ensure conformity to the domain requirements.
    /// </remarks>
    List<TElement> Elements { get; }

    /// <summary>
    /// Validates the elements in the bulk event against the provided process.
    /// </summary>
    /// <param name="process">
    /// The <see cref="Process"/> instance to be used for validation.
    /// </param>
    /// <returns>
    /// Returns a <see cref="Result"/> indicating whether the validation was successful or not.
    /// </returns>
    Result ValidateElements(Process process);
}
