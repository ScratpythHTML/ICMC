using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
  public DbSet<GearItem> GearItems { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Logbook> Logbook { get; set; }
}