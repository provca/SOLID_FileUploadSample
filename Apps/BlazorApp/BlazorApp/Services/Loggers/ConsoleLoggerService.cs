using Microsoft.JSInterop;

namespace BlazorApp.Services.Loggers
{
    /// <summary>
    /// Provides a service for logging messages to the browser's console using JavaScript interop.
    /// </summary>
    public class ConsoleLoggerService
    {
        private readonly IJSRuntime _jsRuntime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLoggerService"/> class.
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime used for invoking browser console functions.</param>
        public ConsoleLoggerService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// Logs a message to the browser's console using JavaScript's `console.log` function.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task LogToConsole(string message)
        {
            await _jsRuntime.InvokeVoidAsync("console.log", message);
        }
    }
}
