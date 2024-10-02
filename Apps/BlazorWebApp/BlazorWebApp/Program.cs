using BlazorWebApp;
using BlazorWebApp.Services;
using BlazorWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Create a WebAssembly host builder with default settings.
// This sets up the necessary services and configuration for the application.
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add the root component of the application, specifying the selector for the HTML element.
// The App component will be rendered inside the element with ID 'app'.
builder.RootComponents.Add<App>("#app");

// Add a second root component for managing the head section of the document.
// This allows for dynamic updates to the <head> tag, such as adding styles or meta tags.
builder.RootComponents.Add<HeadOutlet>("head::after");
// Registers the BlazorFileUploadService as a scoped service in the dependency injection container.
// The service implements the IBlazorFileUploadService interface, and it will be available for dependency injection
// throughout the application for the lifetime of the HTTP request in Blazor WebAssembly.
builder.Services.AddScoped<IBlazorFileUploadService, BlazorFileUploadService>();

// Sets the base address of the HttpClient depending on the environment (development or production).
var baseAddress = builder.HostEnvironment.IsDevelopment()
    // If the app is running in development mode, use the local API address.
    ? "http://localhost:5176"
    // If the app is in production, use the production API address (for example, https://your-production-url.com).
    : "https://localhost:5001";

// Registers HttpClient as a scoped service with the appropriate base address.
// The HttpClient will be used for making HTTP requests throughout the Blazor WebAssembly app.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

// Build the application and run it asynchronously.
// This starts the Blazor WebAssembly app and renders it in the browser.
await builder.Build().RunAsync();
