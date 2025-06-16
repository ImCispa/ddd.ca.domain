using System.Text.Json.Serialization;
using DDD.CA.Infrastructure.Processes;
using DDD.CA.Infrastructure.Results;

namespace DDD.CA.Infrastructure.Events;

/// <summary>
/// Represents a bulk event that encapsulates a collection of related elements.
/// </summary>
/// <typeparam name="TElement">The type of the elements contained in the event. Must inherit from <see cref="EventBulkElement"/>.</typeparam>
public abstract class EventBulk<TElement> : Event, IEventBulk<TElement> where TElement : EventBulkElement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EventBulk{TElement}"/> class with a specified process and collection of elements.
    /// </summary>
    /// <param name="process">The process associated with this bulk event.</param>
    /// <param name="elements">List of elements to be included in the bulk event. Each element must inherit from <see cref="EventBulkElement"/>.</param>
    public EventBulk(Process process, List<TElement> elements) : base(process)
    {
        Elements = elements;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EventBulk{TElement}"/> class for JSON deserialization.
    /// </summary>
    /// <param name="elements">The collection of elements to be included in the bulk event.</param>
    /// <param name="createDateTime">The date and time when the event was created.</param>
    /// <param name="processKey">The unique key identifying the process associated with this event.</param>
    /// <remarks>
    /// ⚠️ **WARNING: CONSTRUCTOR FOR JSON SERIALIZATION ONLY** ⚠️
    /// 
    /// ❗ **IMPORTANT**: This constructor should ONLY be used by JSON serializers and converters.
    /// DO NOT use this constructor during regular code development or business logic implementation.
    /// For programmatic creation, use the appropriate constructors with required parameters.
    /// </remarks>
    [JsonConstructor]
    public EventBulk(List<TElement> elements, DateTime createDateTime, ProcessKey processKey) : base(createDateTime, processKey)
    {
        Elements = elements;
    }

    /// <summary>
    /// Represents a collection of elements associated with the bulk event.
    /// </summary>
    public List<TElement> Elements { get; protected set; }

    /// <summary>
    /// Validates the elements in the current event bulk against a given process.
    /// </summary>
    /// <param name="process">The process to validate the elements against.</param>
    /// <returns>A <see cref="Result"/> indicating whether the elements are valid. If any element fails validation, the result will indicate failure.</returns>
    public Result ValidateElements(Process process)
    {
        if (Elements.Count == 0 || Elements.Select(item => item.Validate(process)).Any(r => r.Failed))
        {
            return Result.Fail();
        }

        return Result.Success();
    }
}