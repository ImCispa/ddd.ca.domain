namespace DDD.CA.Infrastructure.Primitives;

/// <summary>
/// Represents a base class for entities in a domain model.
/// </summary>
/// <typeparam name="TKey">The type of the entity's unique key, which must inherit from EntityKey.</typeparam>
public abstract class Entity<TKey> : IEquatable<Entity<TKey>> where TKey : EntityKey
{
    /// <summary>
    /// Initializes a new instance of the Entity class with the specified key
    /// </summary>
    /// <param name="key">The unique identifier for this entity</param>
    protected Entity(TKey key)
    {
        Key = key;
    }

    /// <summary>
    /// Gets the unique identifier key for this entity
    /// </summary>
    public TKey Key { get; }

    /// <summary>
    /// Determines whether two entities are equal by comparing their keys
    /// </summary>
    /// <param name="first">The first entity to compare</param>
    /// <param name="second">The second entity to compare</param>
    /// <returns>True if both entities are not null and have equal keys; otherwise, false</returns>
    public static bool operator ==(Entity<TKey>? first, Entity<TKey>? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    /// <summary>
    /// Determines whether two entities are not equal by comparing their keys
    /// </summary>
    /// <param name="first">The first entity to compare</param>
    /// <param name="second">The second entity to compare</param>
    /// <returns>True if the entities are not equal; otherwise, false</returns>
    public static bool operator !=(Entity<TKey>? first, Entity<TKey>? second)
    {
        return !(first == second);
    }

    /// <summary>
    /// Determines whether this entity is equal to another entity of the same type
    /// </summary>
    /// <param name="toCompare">The entity to compare with the current entity</param>
    /// <returns>True if the entities are equal; otherwise, false</returns>
    public bool Equals(Entity<TKey>? toCompare)
    {
        if (toCompare is null)
        {
            return false;
        }

        return toCompare.GetType() == GetType() && toCompare.Key.Equals(Key);
    }

    /// <summary>
    /// Determines whether this entity is equal to another object
    /// </summary>
    /// <param name="toCompare">The object to compare with the current entity</param>
    /// <returns>True if the object is of the same type and has the same key; otherwise, false</returns>
    public override bool Equals(object? toCompare)
    {
        if (toCompare is null)
        {
            return false;
        }

        if (toCompare.GetType() != GetType())
        {
            return false;
        }

        return toCompare is Entity<TKey> converted && converted.Key.Equals(Key);
    }

    /// <summary>
    /// Returns a hash code for this entity based on its key
    /// </summary>
    /// <returns>A hash code value for this entity</returns>
    public override int GetHashCode()
    {
        return Key.GetHashCode();
    }
}