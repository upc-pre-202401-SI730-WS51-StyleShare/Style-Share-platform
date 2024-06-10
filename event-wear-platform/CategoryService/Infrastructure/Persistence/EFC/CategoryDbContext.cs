using event_wear_platform.CategoryService.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace event_wear_platform.CategoryService.Infrastructure.Persistence.EFC;

public class CategoryDbContext : DbContext
{
    public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }

    public DbSet<CategoryService.Domain.Model.Aggregates.Category> Categories { get; set; }
    public DbSet<Publication> Publications { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CategoryService.Domain.Model.Aggregates.Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Publication>().HasKey(p => p.Id);
        modelBuilder.Entity<Publication>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Publications)
            .HasForeignKey(p => p.CategoryId);
    }
}