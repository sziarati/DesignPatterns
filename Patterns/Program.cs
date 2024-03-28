using DesignPatterns.Proxy;
using Patterns.Proxy;
using DesignPatterns.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IVideoDownloader, VideoDownloaderProxy>(
        serviceProvider => new VideoDownloaderProxy(new VideoDownloader()));

builder.Services.AddScoped<IUserProfileBuilder, UserProfileBuilder>();
builder.Services.AddScoped<IUserProfileChainOfResponsibilityBuilder, UserProfileChainOfResponsibilityBuilder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//
//
app.UseAuthorization();

app.MapControllers();

app.Run();
