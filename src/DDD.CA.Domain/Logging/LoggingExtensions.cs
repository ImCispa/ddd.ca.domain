using DDD.CA.Infrastructure.Processes;
using Serilog;

namespace DDD.CA.Infrastructure.Logging;

/// <summary>
/// Provides extension methods for logging operations, enabling additional structured logging capabilities
/// for the ILogger interface by facilitating the integration of detailed log data.
/// </summary>
public static class LoggingExtensions
{
    /// <summary>
    /// Writes a structured log entry using the provided logger, including log level, message, details, and data.
    /// This method ensures that the log message is only written if the specified log level is enabled.
    /// </summary>
    /// <param name="logger">The logger instance which must perform the logging operation.</param>
    /// <param name="log">The log entry containing structured information such as level, message, details, and data.</param>
    public static void Log(this ILogger logger, Log log)
    {
        if (!logger.IsEnabled(log.Level))
        {
            return;
        }
        logger.Write(log.Level,
            "{Message} {Details} {@Dati}",
            log.Message,
            log.Details,
            log.Data
        );
    }
}