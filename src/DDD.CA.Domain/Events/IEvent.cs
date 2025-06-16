using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Defines the base structure for an event within the domain.
/// </summary>
public interface IEvent
{
    /// <summary>
    /// Gets the date and time when the event instance was created.
    /// </summary>
    /// <remarks>
    /// This property represents the timestamp indicating the precise moment the event instance
    /// was instantiated within the system domain. It is typically used for tracking, logging,
    /// and auditing purposes to maintain temporal context of events.
    /// </remarks>
    DateTime CreateDateTime { get; }

    /// <summary>
    /// Gets the unique identifier of the process associated with the event.
    /// </summary>
    /// <remarks>
    /// This property serves as a reference to the specific process that is linked to the event.
    /// It is used to ensure proper correlation between events and their originating processes
    /// within the domain logic.
    /// </remarks>
    ProcessKey ProcessKey { get; }

    /// <summary>
    /// Validates the state or context of the process associated with the event.
    /// </summary>
    /// <param name="process">The process to validate against the event.</param>
    /// <returns>A <see cref="Result"/> indicating whether the validation was successful or not.</returns>
    Result Validate(Process process);
}