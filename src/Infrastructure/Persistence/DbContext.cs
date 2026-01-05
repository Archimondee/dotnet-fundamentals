using DotnetCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetCA.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

        // Global Query Filters (Soft Delete)
        modelBuilder.Entity<User>()
            .HasQueryFilter(u => u.DeletedAt == null);
    }
}
