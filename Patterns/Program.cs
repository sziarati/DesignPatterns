using Patterns.Proxy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IVideoDownloader, VideoDownloaderProxy>(
        serviceProvider => new VideoDownloaderProxy(new VideoDownloader())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
//
app.UseAuthorization();

app.MapControllers();

app.Run();
