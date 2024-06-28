using System.Security.Cryptography.Xml;
using StyleShare.Platform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using StyleShare.Platform.API.Publications.Domain.Model.Aggregates;
using StyleShare.Platform.API.Publications.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.Entities;
using StyleShare.Platform.API.Rent.Domain.Model.ValueObjects;

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
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().HasKey(r => r.Id);
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().Property(j => j.Id).IsRequired().ValueGeneratedOnAdd();
   
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().Property(r => r.RentalDate).HasConversion(
            dateRent => dateRent.rental_date,
            rental_date => new DateRent(rental_date)
        );
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().Property(r => r.ShippingId).HasConversion(
            ShippingId => ShippingId.IdShipping,
            IdShipping => new ShippingId(IdShipping)
        );
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().Property(r => r.UserId).HasConversion(
            UserId => UserId.userId,
            userId => new UserId(userId)
            );
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>().Property(r => r.state).HasConversion(
            state => state.ToString(),
            state => (State) Enum.Parse(typeof(State), state)
        );

        // Add additional configuration for other properties as needed...

        builder.Entity<Cart>().HasKey(t => t.Id);
        builder.Entity<Cart>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Cart>()
            .HasMany(c => c.ProductCarts)
            .WithOne()
            .HasForeignKey(pc => pc.CartId);

        builder.Entity<ProductCart>().HasKey(o => o.Id );
        builder.Entity<ProductCart>().Property(j => j.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Rent.Domain.Model.Aggregates.Rent>()
            .HasOne(r => r.Cart)
            .WithOne(c => c.Rent)
            .HasForeignKey<Rent.Domain.Model.Aggregates.Rent>(r => r.CartId);


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
