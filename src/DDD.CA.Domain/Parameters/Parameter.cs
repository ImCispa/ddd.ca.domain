namespace DDD.CA.Infrastructure.Parameters;

/// <summary>
/// Represents an abstract parameter with a generic type to support hierarchical structure management,
/// description assignment, and default value specification.
/// </summary>
/// <typeparam name="T">The type of the parameter's stored value.</typeparam>
public abstract class Parameter<T>
{
    /// <summary>
    /// Represents an abstract parameter class with a generic type that includes hierarchical tree structure management,
    /// a description, and a default value.
    /// </summary>
    public Parameter(ParameterTree parameterTree, string description, T @default)
    {
        Tree = parameterTree.Levels.ToArray();
        Description = description;
        Default = @default;
    }

    /// <summary>
    /// Gets the hierarchical structure of levels representing the parameter tree.
    /// </summary>
    public string[] Tree { get; }

    /// <summary>
    /// Gets the text describing the parameter for documentation, context, or user instruction purposes.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the default value assigned to the parameter.
    /// </summary>
    public T Default { get; }
}
