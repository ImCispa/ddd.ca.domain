using Serilog.Events;

namespace DDD.CA.Infrastructure.Logging;

/// <summary>
/// Represents a log entry, encapsulating log level and message details,
/// along with optional additional details and data.
/// </summary>
public sealed class Log : IEquatable<Log>
{
    /// <summary>
    /// Represents an empty log instance with a default verbose log level
    /// and an empty message. This serves as a placeholder or default value
    /// to indicate the absence of a meaningful log entry.
    /// </summary>
    public static readonly Log Empty = new Log(LogEventLevel.Verbose, string.Empty);


    /// <summary>
    /// Represents a log entry containing a log level and a descriptive message.
    /// Provides functionality to manage and enhance the log entry with additional
    /// details or associated data.
    /// </summary>
    public Log(LogEventLevel level, string message)
    {
        Level = level;
        Message = message;
    }

    /// <summary>
    /// Gets the log level associated with the log entry, indicating the severity or
    /// importance of the logged event (e.g., Verbose, Information, Warning, Error).
    /// This helps categorize and filter log entries based on their significance.
    /// </summary>
    public LogEventLevel Level { get; }

    /// <summary>
    /// Represents the textual content of a log entry, providing the main description
    /// or message conveying details about the specific log event.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Represents additional details associated with the log entry, providing
    /// supplementary information that can offer more context or clarity
    /// about the log message. This property is optional and can be null.
    /// </summary>
    public string? Details { get; private set; }

    /// <summary>
    /// Represents additional data or contextual information associated with a log entry.
    /// This property is an optional field and can contain any user-defined object
    /// relevant to the specific log entry.
    /// </summary>
    public object? Data { get; private set; }


    /// <summary>
    /// Updates the log entry with additional details to provide more context or clarification.
    /// </summary>
    /// <param name="details">The additional textual details to associate with the log entry.</param>
    /// <returns>The updated log entry instance including the provided details.</returns>
    public Log AddDetails(string details)
    {
        Details = details;
        return this;
    }

    /// <summary>
    /// Enriches the log instance by associating additional data for context or detail.
    /// Typically used to provide more structured information about the log entry.
    /// </summary>
    /// <param name="data">The additional data to associate with the log entry.</param>
    /// <returns>The updated log entry instance including the provided data.</returns>
    public Log AddData(object data)
    {
        Data = data;
        return this;
    }

    /// <summary>
    /// Defines an equality operator for the Log class, allowing comparison
    /// of two Log instances for equality based on their content.
    /// </summary>
    /// <param name="first">The first Log instance to compare.</param>
    /// <param name="second">The second Log instance to compare.</param>
    /// <returns>True if the two Log instances are considered equal; otherwise, false.</returns>
    public static bool operator ==(Log? first, Log? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    /// <summary>
    /// Defines an inequality operator for the Log class, allowing comparison
    /// of two Log instances for inequality based on their content.
    /// </summary>
    /// <param name="first">The first Log instance to compare.</param>
    /// <param name="second">The second Log instance to compare.</param>
    /// <returns>True if the two Log instances are not considered equal; otherwise, false.</returns>
    public static bool operator !=(Log? first, Log? second)
    {
        return !(first == second);
    }

    /// <summary>
    /// Determines whether the current Log instance is equal to another Log instance
    /// by comparing their message and level properties.
    /// </summary>
    /// <param name="toCompare">The Log instance to compare with the current instance.</param>
    /// <returns>True if the specified Log instance is equal to the current instance; otherwise, false.</returns>
    public bool Equals(Log? toCompare)
    {
        if (toCompare is null)
        {
            return false;
        }

        // sealed class, type equality check is not necessary

        return toCompare.Message == Message && toCompare.Level == Level;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current Log instance.
    /// Compares the log level and message for equality.
    /// </summary>
    /// <param name="toCompare">The object to compare with the current Log instance.</param>
    /// <returns>True if the specified object is a Log instance with the same log level and message as the current instance; otherwise, false.</returns>
    public override bool Equals(object? toCompare)
    {
        if (toCompare is null)
        {
            return false;
        }

        // sealed class, type equality check is not necessary

        if (toCompare is not Log converted)
        {
            return false;
        }

        return converted.Message == Message && converted.Level == Level;
    }

    /// <summary>
    /// Generates a hash code for the current Log instance based on its content.
    /// This provides a consistent and unique identifier for use in hash-based collections
    /// or comparisons.
    /// </summary>
    /// <returns>An integer that serves as the hash code for the Log instance.</returns>
    public override int GetHashCode()
    {
        return Message.GetHashCode();
    }
}