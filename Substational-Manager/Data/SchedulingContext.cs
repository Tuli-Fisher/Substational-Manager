using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Substational_Manager.Data.Models;
public class SchedulingContext : DbContext
{
    public SchedulingContext(DbContextOptions<SchedulingContext> options) : base(options) { }

    public DbSet<Substitute> Substitutes => Set<Substitute>();
    public DbSet<School> Schools => Set<School>();
    public DbSet<Job> Jobs => Set<Job>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        // Simple indexes/constraints
        b.Entity<Substitute>().HasIndex(s => s.Email);

        // Relationships
        b.Entity<Job>()
            .HasOne(j => j.School)
            .WithMany()
            .HasForeignKey(j => j.SchoolId)
            .OnDelete(DeleteBehavior.Restrict); // prevent cascade-delete schools by accident

        b.Entity<Job>()
            .HasOne(j => j.Substitute)
            .WithMany()
            .HasForeignKey(j => j.SubstituteId)
            .OnDelete(DeleteBehavior.SetNull);

        // Map DateOnly/TimeOnly (EF Core 8+ does this automatically for SQLite)
    }
}

