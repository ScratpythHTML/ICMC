using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder ApplyConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GearItem>()
            .HasOne(gi => gi.InspectedByUser)
            .WithMany()
            .HasForeignKey(gi => gi.InspectedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GearItem>()
            .HasOne(gi => gi.LentToUser)
            .WithMany()
            .HasForeignKey(gi => gi.LentToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GearItem>()
            .HasOne(gi => gi.LentByUser)
            .WithMany()
            .HasForeignKey(gi => gi.LentByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Logbook>()
            .HasOne(l => l.InspectedByUser)
            .WithMany()
            .HasForeignKey(l => l.InspectedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Logbook>()
            .HasOne(l => l.LentToUser)
            .WithMany()
            .HasForeignKey(l => l.LentToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Logbook>()
            .HasOne(l => l.LentByUser)
            .WithMany()
            .HasForeignKey(l => l.LentByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        return modelBuilder;
    }
}