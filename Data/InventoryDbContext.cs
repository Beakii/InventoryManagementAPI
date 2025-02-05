using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>().OwnsOne(s => s.ContactInfo);
    }
}