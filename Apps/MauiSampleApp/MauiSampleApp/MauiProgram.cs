using MauiSampleApp.Services;
using MauiSampleApp.Services.Interfaces;
using MauiSampleApp.Pages;
using Microsoft.Extensions.Logging;

namespace MauiSampleApp
{
    /// <summary>
    /// Provides the entry point for configuring and creating the Maui app.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Configures and builds the Maui app, adding services and fonts, and setting up logging for debugging.
        /// </summary>
        /// <returns>Returns the configured <see cref="MauiApp"/> instance.</returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Specifies the main application class and configures fonts.
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Adds logging support for debugging.
            builder.Logging.AddDebug();
#endif

            // Registers services and pages with the dependency injection container.
            builder.Services.AddSingleton<IFileUploadService, FileUploadService>();
            builder.Services.AddSingleton<UploadFilePage>();

            // Builds and returns the configured Maui app.
            return builder.Build();
        }
    }
}

