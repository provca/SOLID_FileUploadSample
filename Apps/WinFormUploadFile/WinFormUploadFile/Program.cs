using SwitchLoggers.Enums;
using System.Runtime.InteropServices;
using WinFormUploadFile.ServiceProviders;

namespace WinFormUploadFile
{
    internal static class Program
    {
        [STAThread]

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Open the console.
            AllocConsole();

            // Initialize Windows Forms App.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize SwitchLogger.
            // Options:
            // 1. nameof(LoggerType.Serilog)
            // 2. nameof(LoggerType.NLog)
            // 3. nameof(LoggerType.TraceLog) by default.
            var serviceProvider = SwitchLoggersServiceProvider.ConfigureLogger(nameof(LoggerType.Serilog), false, string.Empty, string.Empty);

            // Run UploadFileForm.cs
            Application.Run(new UploadFileForm());
        }

        // Declare AllocConsole from API Windows.
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    }
}