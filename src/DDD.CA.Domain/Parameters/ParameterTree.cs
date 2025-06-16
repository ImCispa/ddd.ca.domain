namespace DDD.CA.Infrastructure.Parameters;

/// <summary>
/// Represents a tree structure designed to manage hierarchical levels of parameters in a domain logic context.
/// </summary>
public abstract class ParameterTree
{
    /// <summary>
    /// Represents a tree structure for organizing and managing parameters in a hierarchical manner.
    /// </summary>
    public ParameterTree(ParameterTree parameterTree, string level)
    {
        Levels = parameterTree.Levels;
        Levels.Add(level);
    }

    /// <summary>
    /// Represents a tree structure for organizing and managing parameters in a hierarchical manner.
    /// </summary>
    public ParameterTree(string level)
    {
        Levels = new List<string>
        {
            level
        };
    }

    /// <summary>
    /// Gets the list of hierarchical levels contained within the parameter tree.
    /// Each level represents a specific hierarchical categorization within the tree structure.
    /// </summary>
    public List<string> Levels { get; }
}
