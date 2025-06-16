using DDD.CA.Infrastructure.Events;
using DDD.CA.Infrastructure.Logging;
using Serilog;
using Log = DDD.CA.Infrastructure.Logging.Log;

namespace DDD.CA.Infrastructure.Processes;

/// <summary>
/// Represents a sealed class that enables the management of processes,
/// facilitating context handling, signaling, cancellation tokens, and various
/// operations related to domain-driven process logic.
/// </summary>
public sealed class Process : IEquatable<Process>
{
    private Process(CancellationToken cancellationToken, ProcessKey? key = null, ProcessKey? parentKey = null)
    {
        Key = key ?? new ProcessKey(Guid.NewGuid());
        CancellationToken = cancellationToken;
        ParentKey = parentKey;
    }

    /// <summary>
    /// Gets the unique key associated with the process.
    /// </summary>
    /// <remarks>
    /// This property provides access to the <see cref="ProcessKey"/> instance that uniquely
    /// identifies the process. It plays a crucial role in tracing processes and ensuring
    /// that operations or events are correctly mapped to their associated domain logic.
    /// </remarks>
    public ProcessKey Key { get; }

    /// <summary>
    /// Gets the <see cref="CancellationToken"/> associated with the process.
    /// </summary>
    /// <remarks>
    /// This property provides a mechanism for cooperative cancellation between threads.
    /// It allows external subscribers to signal the intent to cancel ongoing activities related to the process.
    /// The token is critical in managing resource cleanup and ensuring that operations respect cancellation requests.
    /// </remarks>
    public CancellationToken CancellationToken { get; }

    /// <summary>
    /// Gets the key of the parent process associated with the current process.
    /// </summary>
    /// <remarks>
    /// This property provides access to the <see cref="ProcessKey"/> that identifies the immediate parent
    /// of the current process, enabling hierarchical process tracking and inheritance. It is useful for
    /// managing process relationships within the domain and ensuring proper contextual alignment.
    /// </remarks>
    public ProcessKey? ParentKey { get; }

    /// <summary>
    /// Creates and initializes a new instance of the <see cref="Process"/> class
    /// using the provided cancellation token.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> used to manage process cancellation.</param>
    /// <returns>A new instance of the <see cref="Process"/> class.</returns>
    public static Process Start(CancellationToken cancellationToken)
    {
        return new Process(cancellationToken);
    }

    /// <summary>
    /// Creates and initializes a new instance of the <see cref="Process"/> class
    /// using the provided event and cancellation token.
    /// </summary>
    /// <param name="event">The event containing necessary information for process creation.</param>
    /// <param name="tokenCancellazione">A <see cref="CancellationToken"/> used to manage process cancellation.</param>
    /// <returns>A new instance of the <see cref="Process"/> class.</returns>
    public static Process Inherit(Event @event, CancellationToken tokenCancellazione)
    {
        return new Process(tokenCancellazione, @event.ProcessKey);
    }

    /// <summary>
    /// Creates a new child process instance associated with the specified logger
    /// and logs the creation event with the child's process key.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> instance used for logging process creation details.</param>
    /// <returns>A new instance of the <see cref="Process"/> class representing the child process.</returns>
    public Process CreateChild(ILogger logger)
    {
        var child = new Process(CancellationToken.None, parentKey: Key);
        logger.Log(DomainLogs.ProcessCreateChild.AddData(new { child = child.Key }));
        return child;
    }

    /// <summary>
    /// Determines whether two instances of <see cref="Process"/> are considered equal.
    /// </summary>
    /// <param name="first">The first <see cref="Process"/> instance to compare.</param>
    /// <param name="second">The second <see cref="Process"/> instance to compare.</param>
    /// <returns>
    /// True if the two instances of <see cref="Process"/> are considered equal;
    /// otherwise, false.
    /// </returns>
    public static bool operator ==(Process? first, Process? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    /// <summary>
    /// Determines whether two instances of <see cref="Process"/> are not equal.
    /// </summary>
    /// <param name="first">The first <see cref="Process"/> instance to compare.</param>
    /// <param name="second">The second <see cref="Process"/> instance to compare.</param>
    /// <returns>
    /// True if the two instances of <see cref="Process"/> are not equal;
    /// otherwise, false.
    /// </returns>
    public static bool operator !=(Process? first, Process? second)
    {
        return !(first == second);
    }

    /// <summary>
    /// Determines whether the current <see cref="Process"/> instance is equal to another specified <see cref="Process"/> instance.
    /// </summary>
    /// <param name="toCompare">The <see cref="Process"/> instance to compare with the current instance.</param>
    /// <returns>
    /// True if the current instance is equal to the specified <see cref="Process"/> instance; otherwise, false.
    /// </returns>
    public bool Equals(Process? toCompare)
    {
        if (toCompare is null)
        {
            return false;
        }

        // sealed class, type equality check is not necessary

        return toCompare.Key == Key;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="Process"/> instance.
    /// </summary>
    /// <param name="toCompare">The object to compare with the current <see cref="Process"/> instance.</param>
    /// <returns>
    /// True if the specified object is equal to the current <see cref="Process"/> instance; otherwise, false.
    /// </returns>
    public override bool Equals(object? toCompare)
    {
        // sealed class, type equality check is not necessary

        if (toCompare is not Process converted)
        {
            return false;
        }

        return converted.Key == Key;
    }

    /// <summary>
    /// Serves as the default hash function for the <see cref="Process"/> class.
    /// Generates a hash code for the current instance based on its unique key.
    /// </summary>
    /// <returns>An integer that represents the hash code for the current <see cref="Process"/> instance.</returns>
    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }
}
