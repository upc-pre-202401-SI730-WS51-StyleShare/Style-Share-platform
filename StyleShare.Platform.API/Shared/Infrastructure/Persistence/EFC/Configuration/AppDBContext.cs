using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;
using StyleShare.Platform.API.Transactions.Domain.Model.Entities;

namespace StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
//265
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
        
        // Begin BoundedContext Model
        builder.Entity<Rent>().HasKey(r => r.Id);
        builder.Entity<Rent>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Rent>().Property(r => r.amount).IsRequired();
        
        builder.Entity<Transaction>().HasKey(t => t.Id);
        builder.Entity<Transaction>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Transaction>().Property(t => t.Details).IsRequired().HasMaxLength(150);
        builder.Entity<Transaction>().Property(t => t.Amount).IsRequired();
        builder.Entity<Transaction>().Property(t => t.PaymentMethod).IsRequired();
        builder.Entity<Transaction>().HasMany(t => t.RentIdsReference);
        
        builder.Entity<TransactionHistory>().HasKey(t => t.Id);
        builder.Entity<TransactionHistory>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        //builder.Entity<TransactionHistory>().Property(t => t.TransactionIds).IsRequired();
        builder.Entity<TransactionHistory>().HasMany(t => t.TransactionIdsReference);
        // End BoundedContext Model
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}