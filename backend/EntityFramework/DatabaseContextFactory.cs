using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Creates <see cref="DatabaseContext"/> instances for design-time tooling.
/// </summary>
public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api"))
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.local.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DatabaseContext");
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>().UseNpgsql(connectionString);
        return new DatabaseContext(optionsBuilder.Options);
    }
}