using EntityFramework;
using Microsoft.EntityFrameworkCore;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseContext")));
    }
}