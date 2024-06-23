using System.Security.Cryptography.Xml;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Transactions.Domain.Model.Aggregates;

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
        builder.Entity<Transaction>().HasKey(t => t.Id);
        builder.Entity<Transaction>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Transaction>().Property(t => t.Details).IsRequired().HasMaxLength(100);
        builder.Entity<Transaction>().Property(t => t.Amount).IsRequired();
        builder.Entity<Transaction>().Property(t => t.PaymentMethod).IsRequired();
        builder.Entity<Transaction>().Property(t => t.RentIds).IsRequired();
        
        builder.Entity<TransactionHistory>().HasKey(h => h.Id);
        builder.Entity<TransactionHistory>().Property(h => h.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TransactionHistory>().HasMany(h => h.TransactionIdsReference);
        // Add additional configuration for other properties as needed...
        // End BoundedContext Model
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}