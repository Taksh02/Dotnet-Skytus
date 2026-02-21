using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// 1️⃣ Configure Logging
// ======================================================
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// ======================================================
// 2️⃣ Add Services
// ======================================================

// Add Controllers + Global Exception Filter
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

// Add Memory Cache
builder.Services.AddMemoryCache();

// Swagger (for testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ======================================================
// 3️⃣ Log Application Startup
// ======================================================
app.Logger.LogInformation("Application started at {Time}", DateTime.UtcNow);

// ======================================================
// 4️⃣ Middleware Pipeline
// ======================================================

// Custom Exception Middleware
app.UseMiddleware<CustomExceptionMiddleware>();

// Enable Static Files (Required for File Upload/Download)
app.UseStaticFiles();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
