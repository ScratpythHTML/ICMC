using Domain.Entities;
using EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    public DbSet<GearItem> GearItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Logbook> Logbook { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurations();

    }
}