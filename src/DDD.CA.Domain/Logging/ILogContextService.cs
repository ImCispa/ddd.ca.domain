using DDD.CA.Infrastructure.Processes;

namespace DDD.CA.Infrastructure.Logging;

/// <summary>
/// Defines the service responsible for managing the logging context within the domain.
/// Enables integration of process-specific properties and additional custom properties
/// into a shared logging context.
/// </summary>
public interface ILogContextService : IDisposable
{
    /// <summary>
    /// Initializes the logging context for a specified process, allowing the inclusion of
    /// process-specific properties within the logging context.
    /// </summary>
    /// <param name="process">
    /// The process instance containing details to be incorporated into the logging context.
    /// </param>
    void InitializeContext(Process process);

    /// <summary>
    /// Adds a custom property to the current logging context to enrich log output with additional contextual information.
    /// </summary>
    /// <param name="name">
    /// The name of the custom property to be added to the logging context.
    /// </param>
    /// <param name="value">
    /// The value associated with the custom property in the logging context.
    /// </param>
    void AddProperty(string name, object value);

    /// <summary>
    /// Adds a collection of custom properties to the current logging context, allowing for
    /// the enrichment of log output with multiple contextual properties simultaneously.
    /// </summary>
    /// <param name="properties">
    /// A dictionary containing the names and values of the custom properties to be
    /// incorporated into the logging context.
    /// </param>
    void AddProperties(Dictionary<string, object> properties);
}