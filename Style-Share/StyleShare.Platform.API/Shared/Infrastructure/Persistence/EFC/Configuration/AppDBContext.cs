using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

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
        //builder.Entity<Tutorial>().HasKey(t => t.Id);
        //builder.Entity<Tutorial>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        //builder.Entity<Tutorial>().Property(c => c.Title).IsRequired().HasMaxLength(60);
        //builder.Entity<Tutorial>().Property(c => c.Summary).IsRequired().HasMaxLength(100);
        // End BoundedContext Model
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}