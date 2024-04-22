using DesignPatterns.Proxy;
using Patterns.Proxy;
using DesignPatterns.Builder;
using Common;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IVideoDownloader, VideoDownloaderProxy>(
        serviceProvider => new VideoDownloaderProxy(new VideoDownloader()));

builder.Services.AddScoped<IUserProfileBuilder, UserProfileBuilder>();
builder.Services.AddScoped<IUserProfileChainOfResponsibilityBuilder, UserProfileChainOfResponsibilityBuilder>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//
//
app.UseAuthorization();

app.MapControllers();

app.Run();
