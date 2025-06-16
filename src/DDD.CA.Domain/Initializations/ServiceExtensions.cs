using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DDD.CA.Infrastructure.Initializations;

/// <summary>
/// Provides a set of extension methods for configuring and registering services
/// to the dependency injection container.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Configures and registers services required for the application, including
    /// configuration settings and logging, to the dependency injection container.
    /// </summary>
    /// <param name="services">The IServiceCollection to which services are added.</param>
    public static void Add(this IServiceCollection services)
    {
        var env = Environment.GetEnvironmentVariable("ENVIRONMENT");
        
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddJsonFile(Path.Combine("secrets", "appsettings.secrets.json"), optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        services.AddSingleton(configuration);
        
        ILogger logger = 
            new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
        services.AddSingleton(logger);
    }
}
