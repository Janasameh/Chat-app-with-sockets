using MyFirstApi.Hubs; // <-- must match the namespace in ChatHub.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin(); // for testing only
    });
});

var app = builder.Build();

app.UseCors();

app.MapHub<ChatHub>("/chathub");

// Optional: serve static files (like your index.html) from wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
