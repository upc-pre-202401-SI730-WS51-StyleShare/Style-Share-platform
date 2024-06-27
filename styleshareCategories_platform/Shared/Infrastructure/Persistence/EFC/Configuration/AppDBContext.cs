using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using styleshareCategories_platform.CategoryService.Domain.Model.Entities;
using styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace styleshareCategories_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category Relationships
        // Define relationships and constraints if necessary
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);
            
        modelBuilder.Entity<Category>()
            .Property(c => c.Price_range)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Category_type)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Category_name)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Image2)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Rate)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<Category>()
            .Property(c => c.Isfavorite)
            .IsRequired();
        
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}