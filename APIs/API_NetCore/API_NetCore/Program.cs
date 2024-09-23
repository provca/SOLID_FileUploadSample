using LibServices.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration settings from appsettings.json file.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Suppress IL2026 warning for the AddControllers method.
#pragma warning disable IL2026
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // Configure Newtonsoft.Json to ignore null values during serialization.
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });
#pragma warning restore IL2026

// Register UploadFileSettings as a singleton service for dependency injection.
builder.Services.AddSingleton<UploadFileSettings>();

// Add services for API documentation using Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Configure Swagger with API title and version.
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Net Core", Version = "v1" });
});

// Configure CORS policy to allow all origins, methods, and headers.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Set the URLs for the web host to listen on.
builder.WebHost.UseUrls(
    "http://localhost:5176;" +
    "https://localhost:5001");

// Build the application.
var app = builder.Build();

// Configure middleware for development environment.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI for API documentation.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // Show developer exception page for detailed error info.
}

// Enable HTTPS redirection.
app.UseHttpsRedirection();

// Set up routing for the application.
app.UseRouting();

// Enable authorization middleware.
app.UseAuthorization();

// Apply the CORS policy.
app.UseCors("AllowAll");

// Configure the default route to redirect to Swagger UI.
app.MapGet("/", () => Results.Redirect("/swagger/index.html"))
    .ExcludeFromDescription();

// Map controller routes.
app.MapControllers();

// Run the application.
app.Run();
