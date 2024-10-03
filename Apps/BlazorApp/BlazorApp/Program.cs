using BlazorApp.Services;
using BlazorApp.Services.Interfaces;
using BlazorApp.Services.Loggers;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register the ConsoleLoggerService for dependency injection.
builder.Services.AddScoped<ConsoleLoggerService>();

// Register the BlazorFileUploadService, passing in the IJSRuntime instance.
builder.Services.AddScoped<IBlazorFileUploadService>(sp =>
{
    var jsRuntime = sp.GetRequiredService<IJSRuntime>();
    return new BlazorFileUploadService(jsRuntime);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

