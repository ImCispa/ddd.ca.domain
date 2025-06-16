namespace DDD.CA.Infrastructure.Primitives;

/// <summary>
/// Represents a marker interface used to identify aggregate keys within the domain model.
/// Objects implementing this interface serve as unique identifiers for aggregates,
/// facilitating domain-driven design operations such as repository handling or aggregate management.
/// </summary>
public interface IAggregateKey
{
}
