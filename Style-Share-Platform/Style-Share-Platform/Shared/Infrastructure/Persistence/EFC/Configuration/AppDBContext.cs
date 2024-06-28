using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Style_Share_Platform.CategoryService.Domain.Model.Entities;
using Style_Share_Platform.Publications.Domain.Model.Aggregates;
using Style_Share_Platform.Rent.Domain.Model.Entities;
using Style_Share_Platform.Rent.Domain.Model.ValueObjects;
using Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Comment = Style_Share_Platform.Publications.Domain.Model.Entities.Comment;
using Garment = Style_Share_Platform.Publications.Domain.Model.Entities.Garment;

namespace Style_Share_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    public DbSet<Category> Categories { get; set; }     
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Begin BoundedContext Model
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().HasKey(r => r.Id);
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().Property(j => j.Id).IsRequired().ValueGeneratedOnAdd();
   
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().Property(r => r.RentalDate).HasConversion(
            dateRent => dateRent.rental_date,
            rental_date => new DateRent(rental_date)
        );
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().Property(r => r.ShippingId).HasConversion(
            ShippingId => ShippingId.IdShipping,
            IdShipping => new ShippingId(IdShipping)
        );
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().Property(r => r.UserId).HasConversion(
            UserId => UserId.userId,
            userId => new UserId(userId)
            );
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>().Property(r => r.state).HasConversion(
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
        
        builder.Entity<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>()
            .HasOne(r => r.Cart)
            .WithOne(c => c.Rent)
            .HasForeignKey<Style_Share_Platform.Rent.Domain.Model.Aggregates.Rent>(r => r.CartId);


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
        
        //Begin BoundedContext Model
        // Category Relationships
        // Define relationships and constraints if necessary
        builder.Entity<Category>()
            .HasKey(c => c.Id);
        builder.Entity<Category>()
            .Property(c => c.Price_range)
            .IsRequired()
            .HasMaxLength(100);
        builder.Entity<Category>()
            .Property(c => c.Category_type)
            .IsRequired()
            .HasMaxLength(100);
        builder.Entity<Category>()
            .Property(c => c.Category_name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Entity<Category>()
            .Property(c => c.Image2)
            .IsRequired()
            .HasMaxLength(300);
        builder.Entity<Category>()
            .Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder.Entity<Category>()
            .Property(c => c.Rate)
            .IsRequired()
            .HasMaxLength(100);
        builder.Entity<Category>()
            .Property(c => c.Isfavorite)
            .IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}
