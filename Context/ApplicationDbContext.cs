using DeviceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Device> Devices { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>()
            .HasOne(d => d.Category)
            .WithMany(c => c.Devices)
            .HasForeignKey(d => d.CategoryId);
        
        modelBuilder.Entity<Device>()
            .Property(d => d.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<Category>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        
        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
    }
};
