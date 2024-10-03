using Microsoft.Extensions.DependencyInjection;
using SwitchLoggers.Loggers.Interfaces;
using SwitchLoggers.Loggers;
using SwitchLoggers.Settings;

namespace WinFormUploadFile.ServiceProviders
{
    /// <summary>
    /// Take a look to this link:
    /// How to use: <see href="https://github.com/provca/SwitchLoggers?tab=readme-ov-file#serviceprovider-usage-optional" />
    /// </summary>
    public class SwitchLoggersServiceProvider
    {
        public static IServiceProvider ConfigureLogger(string loggerName, bool enableFileLogging, string filePath, string fileName)
        {
            try
            {
                // Create the service collection and add singleton services.
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IFactory_Loggers, Factory_Loggers>()
                    .AddSingleton<ILoggers>(provider =>
                    {
                        // Configure the logger here using IFactory_Loggers.
                        var factoryLoggers = provider.GetService<IFactory_Loggers>();
                        return factoryLoggers?.CreateLogger(loggerName, enableFileLogging, filePath, fileName) ?? throw new InvalidOperationException("Logger cannot be null");
                    })
                    .BuildServiceProvider();

                // Get the logger instance from the service provider.
                var logger = serviceProvider.GetService<ILoggers>();

                // Set the logger in SwitchLoggersConfiguration if it is not null.
                if (logger != null)
                {
                    // Set custom values
                    SwitchLoggersSettings.EnableFileLogging = enableFileLogging;
                    SwitchLoggersSettings.FilePath = filePath;
                    SwitchLoggersSettings.FileName = fileName;
                    SwitchLoggersSettings.Logger = logger;
                    logger.LogInformation("Logger initialized successfully.");
                }

                return serviceProvider;
            }
            catch (Exception ex)
            {
                // Handle and rethrow the exception with additional information.
                throw new Exception(ex.ToString());
            }
        }
    }
}
