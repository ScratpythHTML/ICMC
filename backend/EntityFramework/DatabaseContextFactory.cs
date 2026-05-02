using System.Text.Json;

using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

/// <summary>
/// Creates <see cref="DatabaseContext"/> instances for design-time tooling.
/// </summary>
public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var path = "./appsettings.Local.json";
        var stream = File.OpenRead(path);
        var document = JsonDocument.Parse(stream);
        var connectionStrings = document.RootElement.GetProperty("ConnectionStrings");
        var databaseConnectionString = connectionStrings.GetProperty("DatabaseContext").GetString();
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>().UseNpgsql(databaseConnectionString);
        return new DatabaseContext(optionsBuilder.Options);
    }
}