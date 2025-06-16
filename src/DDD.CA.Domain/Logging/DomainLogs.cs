using Serilog.Events;

namespace DDD.CA.Infrastructure.Logging;

/// <summary>
/// Provides predefined log entries related to domain-level processes.
/// This class serves as a repository for reusable log templates, specifying
/// log levels and their associated messages.
/// </summary>
public static class DomainLogs
{
    /// <summary>
    /// Represents a log entry that captures the creation of a child process.
    /// </summary>
    public static readonly Log ProcessCreateChild = new Log(LogEventLevel.Information, "Process: child process created");
}