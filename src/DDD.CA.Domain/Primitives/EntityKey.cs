namespace DDD.CA.Infrastructure.Primitives;

/// <summary>
/// Represents an abstract base class for entity keys.
/// </summary>
/// <remarks>
/// The EntityKey class provides a base for defining unique entity identifiers
/// in the domain-driven design implementation. It enforces equality operations
/// to ensure correct comparison and distinction of entity keys in the domain.
/// </remarks>
public abstract class EntityKey : IEquatable<EntityKey>
{
    /// <summary>
    /// Gets a value indicating whether the entity key represents a new entity that has not been persisted yet.
    /// </summary>
    /// <remarks>
    /// The property is typically used to determine if an entity is in a transient state (not yet stored in a repository or database).
    /// </remarks>
    public abstract bool IsNew { get; }

    /// <summary>
    /// Determines whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="toCompare">The object to compare with the current object.</param>
    /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
    public abstract bool Equals(EntityKey? toCompare);

    /// <summary>
    /// Determines whether the current object is equal to another object.
    /// </summary>
    /// <param name="toCompare">The object to compare with the current object.</param>
    /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
    public abstract override bool Equals(object? toCompare);

    /// <summary>
    /// Serves as the default hash function for the entity key.
    /// </summary>
    /// <returns>An integer that represents the hash code for the current object.</returns>
    public abstract override int GetHashCode();

    /// <summary>
    /// Determines whether two <see cref="EntityKey"/> instances are considered equal.
    /// </summary>
    /// <param name="first">The first <see cref="EntityKey"/> to compare.</param>
    /// <param name="second">The second <see cref="EntityKey"/> to compare.</param>
    /// <returns>True if the two <see cref="EntityKey"/> instances are equal; otherwise, false.</returns>
    public static bool operator ==(EntityKey? first, EntityKey? second)
    {
        if (first is null && second is null)
        {
            return true;
        }
        return first is not null && second is not null && first.Equals(second);
    }

    /// <summary>
    /// Determines whether two <see cref="EntityKey"/> instances are not equal.
    /// </summary>
    /// <param name="first">The first <see cref="EntityKey"/> to compare.</param>
    /// <param name="second">The second <see cref="EntityKey"/> to compare.</param>
    /// <returns>True if the two <see cref="EntityKey"/> instances are not equal; otherwise, false.</returns>
    public static bool operator !=(EntityKey? first, EntityKey? second)
    {
        return !(first == second);
    }
}
