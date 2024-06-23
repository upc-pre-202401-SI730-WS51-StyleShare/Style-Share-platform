using System.Security.Cryptography.Xml;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;

namespace StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

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

        // Begin BoundedContext Model
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>().Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Comment>().Property(c => c.Punctuation).IsRequired();
        builder.Entity<Comment>().Property(c => c.Description).IsRequired();
        builder.Entity<Comment>().Property(c => c.PublicationId).IsRequired();

        builder.Entity<Garment>().HasKey(g => g.Id);
        builder.Entity<Garment>().Property(g => g.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Garment>().Property(g => g.Size).IsRequired();
        builder.Entity<Garment>().Property(g => g.Description).IsRequired().HasMaxLength(100);
        builder.Entity<Garment>().Property(g => g.Material).IsRequired().HasMaxLength(100);
        builder.Entity<Garment>().Property(g => g.Brand).IsRequired().HasMaxLength(100);
        builder.Entity<Garment>().Property(g => g.TimesRented).IsRequired();

        builder.Entity<Publication>().HasKey(p => p.Id);
        builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(p => p.Cost).IsRequired();
        builder.Entity<Publication>().Property(p => p.GarmentId).IsRequired();
        builder.Entity<Publication>().Property(p => p.LessorId).IsRequired();
        builder.Entity<Publication>().Property(p => p.Rating).IsRequired();
        builder.Entity<Publication>().HasMany(p => p.Comments);
        
        
        // Add additional configuration for other properties as needed...
        // End BoundedContext Model
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}