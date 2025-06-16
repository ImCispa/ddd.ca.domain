namespace DDD.CA.Infrastructure.Processes;

/// <summary>
/// Represents a unique identifier for a process within the domain logic.
/// </summary>
/// <remarks>
/// This record encapsulates a GUID value used to identify and track a specific process.
/// It is a key component in the domain logic to ensure operations and events are properly linked
/// to their respective processes.
/// </remarks>
/// <param name="Key">
/// The globally unique identifier (GUID) that serves as the unique key for the process.
/// </param>
public record ProcessKey(Guid Key);
