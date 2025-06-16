namespace DDD.CA.Infrastructure.Primitives;

/// <summary>
/// Base class for Value Objects in Domain-Driven Design.
/// Value Objects are immutable objects that have no identity and are considered equal based on their attributes.
/// </summary>
public abstract class ValueObject :  IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the component values that constitute this Value Object
    /// </summary>
    /// <returns>An enumerable of objects representing the Value Object's components</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Determines whether two Value Objects are equal by comparing their components
    /// </summary>
    /// <param name="left">The first Value Object to compare</param>
    /// <param name="right">The second Value Object to compare</param>
    /// <returns>True if both Value Objects have equal components; otherwise, false</returns>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two Value Objects are not equal
    /// </summary>
    /// <param name="left">The first Value Object to compare</param>
    /// <param name="right">The second Value Object to compare</param>
    /// <returns>True if the Value Objects have different components; otherwise, false</returns>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether this Value Object is equal to another Value Object
    /// </summary>
    /// <param name="other">The Value Object to compare with the current Value Object</param>
    /// <returns>True if the Value Objects have equal components; otherwise, false</returns>
    public bool Equals(ValueObject? other)
    {
        return other is not null && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Determines whether this Value Object is equal to another object
    /// </summary>
    /// <param name="obj">The object to compare with the current Value Object</param>
    /// <returns>True if the object is a Value Object and has equal components; otherwise, false</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (GetType() != obj.GetType())
            return false;

        return obj is ValueObject valueObject && Equals(valueObject);
    }

    /// <summary>
    /// Returns a hash code for this Value Object based on its components
    /// </summary>
    /// <returns>A hash code value for this Value Object</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
    }
}