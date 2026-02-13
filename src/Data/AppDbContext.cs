using Microsoft.EntityFrameworkCore;
using DotnetPgMicroservice.Models;

namespace DotnetPgMicroservice.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();
}
