var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Configuration
    .AddJsonFile("appsettings.local.json", optional: true);

builder.Services
    .AddIcmcApiServices()
    .AddDatabaseAccess(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

app.UseRouting();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();