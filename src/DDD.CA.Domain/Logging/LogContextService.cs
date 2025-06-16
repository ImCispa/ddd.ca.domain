using DDD.CA.Infrastructure.Processes;
using Serilog.Context;

namespace DDD.CA.Infrastructure.Logging;

/// <summary>
/// Provides methods to manage and interact with the logging context, enabling
/// the addition of properties and initialization for improved log traceability.
/// Implements the <see cref="ILogContextService"/> interface.
/// </summary>
public class LogContextService : ILogContextService
{
    private readonly List<IDisposable> _disposables = new();

    /// <summary>
    /// Initializes the logging context with a specific process instance.
    /// Adds the process information as a property to the logging context, allowing
    /// traceability and correlation of log entries with the associated process.
    /// </summary>
    /// <param name="process">
    /// The process instance whose information is to be added to the logging context.
    /// It includes details such as process keys and cancellation tokens.
    /// </param>
    public void InitializeContext(Process process)
    {
        _disposables.Add(LogContext.PushProperty("Process", @process));
    }

    /// <summary>
    /// Adds a single property to the current logging context.
    /// Pushes a key-value pair into the logging context, where the key represents
    /// the property name and the value represents the associated property value.
    /// </summary>
    /// <param name="name">
    /// The name of the property to be added to the logging context.
    /// </param>
    /// <param name="value">
    /// The value associated with the property to be added to the logging context.
    /// </param>
    public void AddProperty(string name, object value)
    {
        _disposables.Add(LogContext.PushProperty(name, value));
    }

    /// <summary>
    /// Adds multiple properties to the current logging context.
    /// Each property in the provided dictionary is added to the logging context
    /// by pushing a key-value pair, where the key represents the property name
    /// and the value denotes the associated value.
    /// </summary>
    /// <param name="properties">
    /// A dictionary containing key-value pairs representing the properties to be added
    /// to the logging context. The keys represent property names, and the values represent
    /// the associated property values.
    /// </param>
    public void AddProperties(Dictionary<string, object> properties)
    {
        foreach (var prop in properties)
        {
            _disposables.Add(LogContext.PushProperty(prop.Key, prop.Value));
        }
    }

    /// <summary>
    /// Disposes of all resources added to the log context.
    /// It iterates through and disposes each disposable resource previously added,
    /// ensuring proper cleanup of logging context properties.
    /// Clears the internal list of disposables after they have been disposed.
    /// </summary>
    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable?.Dispose();
        }
        _disposables.Clear();
    }
}