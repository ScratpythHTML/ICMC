using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
  public DbSet<BelayDevice> BelayDevices { get; set; }
  public DbSet<Carabiner> Carabiners { get; set; }
  public DbSet<Crashpad> Crashpads { get; set; }
  public DbSet<Harness> Harnesses { get; set; }
  public DbSet<Helmet> Helmets { get; set; }
  public DbSet<Quickdraw> Quickdraws { get; set; }
  public DbSet<Rope> Ropes { get; set; }
  public DbSet<User> Users { get; set; }

}