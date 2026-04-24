using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace EntityFramework;

public class DatabaseContext : DbContext
{

  public DbSet<BelayDevice> BelayDevices { get; set; }
  public DbSet<Carabiner> Carabiners { get; set; }
  public DbSet<Crashpad> Crashpads { get; set; }
  public DbSet<Harness> Harnesses { get; set; }
  public DbSet<Helmet> Helmets { get; set; }
  public DbSet<Quickdraw> Quickdraws { get; set; }
  public DbSet<Rope> Ropes { get; set; }
  public DbSet<User> Users { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    var connectionString = Environment.GetEnvironmentVariable($"ConnectionStrings__{nameof(DatabaseContext)}");
    options.UseNpgsql(connectionString);
  }
}