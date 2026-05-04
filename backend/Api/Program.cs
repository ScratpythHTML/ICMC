var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Configuration
    .AddJsonFile("appsettings.local.json");

builder.Services
    .AddIcmcApiServices()
    .AddDatabaseAccess(builder.Configuration);

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();