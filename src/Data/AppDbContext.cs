using Microsoft.EntityFrameworkCore;
using DotnetPgMicroservice.Models;

namespace DotnetPgMicroservice.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Widget", Description = "A standard widget in db", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Item { Id = 2, Name = "Gadget", Description = "A fancy gadget", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Item { Id = 3, Name = "Doohickey", Description = "A useful doohickey", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
