using DDD.CA.Infrastructure.Primitives;
using System.Text.Json.Serialization;
using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Represents the base class for events within the domain logic.
/// </summary>
/// <remarks>
/// This abstract class is intended to define a structure for events associated with domain processes.
/// It provides the necessary properties to track event creation information and to associate the event
/// with a specific process. Additionally, it enforces validation requirements through the abstract
/// `Validate` method, which must be implemented by subclasses.
/// </remarks>
public abstract class Event : IEvent
{
    /// <summary>
    /// Represents the base class for defining events within the domain logic.
    /// </summary>
    /// <remarks>
    /// This abstract class provides essential information and structure for the creation of events.
    /// It ensures that all events are associated with a specific process and tracks the creation timestamp.
    /// It also requires implementing a validation mechanism tailored to the associated process.
    /// ❗ **IMPORTANT**: This class should be extended to define specific event types.
    /// </remarks>
    public Event(Process process)
    {
        CreateDateTime = DateTime.Now;
        ProcessKey = process.Key;
    }

    /// <summary>
    /// Represents the base class for defining events within the domain logic.
    /// </summary>
    /// <remarks>
    /// ⚠️ **WARNING: FOR JSON SERIALIZATION ONLY** ⚠️
    /// 
    /// This class provides the necessary properties and methods to define and validate events.
    /// It ensures that each event is associated with a specific process and has a timestamp indicating its creation.
    /// 
    /// ❗ **IMPORTANT**: This constructor/method should ONLY be used by JSON serializers and converters.
    /// DO NOT use this during regular code development or business logic implementation.
    /// For programmatic creation, use the appropriate constructors with required parameters.
    /// </remarks>
    [JsonConstructor]
    public Event(DateTime createDateTime, ProcessKey processKey)
    {
        CreateDateTime = createDateTime;
        ProcessKey = processKey;
    }


    /// <summary>
    /// Gets the date and time when the event was created.
    /// </summary>
    /// <remarks>
    /// This property indicates the timestamp of the specific event's creation
    /// and helps in tracking the chronology of events within the system.
    /// It is immutable and set during the event initialization.
    /// </remarks>
    public DateTime CreateDateTime { get; }

    /// <summary>
    /// Gets the unique identifier associated with the process related to the event.
    /// </summary>
    /// <remarks>
    /// This property represents the `ProcessKey` that links the event to a specific process.
    /// It ensures traceability and correctness by associating the event with its corresponding
    /// process context.
    /// </remarks>
    public ProcessKey ProcessKey { get; }

    /// <summary>
    /// Validates the specified process to ensure it adheres to the required business rules or conditions.
    /// </summary>
    /// <param name="process">The process to validate.</param>
    /// <returns>A <see cref="Result"/> indicating whether the validation succeeded or failed.</returns>
    public abstract Result Validate(Process process);
}