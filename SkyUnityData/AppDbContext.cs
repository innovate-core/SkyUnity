using Microsoft.EntityFrameworkCore;
using SkyUnityCore.Entities;

namespace SkyUnityCore;

public class AppDbContext : DbContext
{
    DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users")
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Name)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
