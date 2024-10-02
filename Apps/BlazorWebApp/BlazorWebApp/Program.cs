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

// Register the HttpClient service with a scoped lifetime.
// This service is used to make HTTP requests. The base address is set to the server's URI.
// Uncomment the line below to use the base address from the host environment instead.
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registers the BlazorFileUploadService as a scoped service in the dependency injection container.
// The service implements the IBlazorFileUploadService interface, and it will be available for dependency injection
// throughout the application for the lifetime of the HTTP request in Blazor WebAssembly.
builder.Services.AddScoped<IBlazorFileUploadService, BlazorFileUploadService>();

// Use a hardcoded base address for the HttpClient, pointing to the API running on localhost.
// This is useful during development to point to the backend service.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

// Build the application and run it asynchronously.
// This starts the Blazor WebAssembly app and renders it in the browser.
await builder.Build().RunAsync();
