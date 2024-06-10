using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace event_wear_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*
        // Begin BoundedContext Model
        // Publishing Context
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(c => c.Title).IsRequired().HasMaxLength(60);
        builder.Entity<Tutorial>().Property(c => c.Summary).IsRequired().HasMaxLength(100);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<Asset>("asset_image")
            .HasValue<Asset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUrl).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUrl).IsRequired();
        builder.Entity<Tutorial>().HasMany(t => t.Assets);
        
        //Category Relationships
        builder.Entity<Category>()
            .HasMany(c => c.Tutorials)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        // End BoundedContext Model
        */
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}