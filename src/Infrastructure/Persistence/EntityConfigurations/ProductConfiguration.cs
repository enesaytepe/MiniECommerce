using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product).ToPlural()).HasKey(o => o.Id);
        builder.HasIndex(indexExpression: o => o.Name, name: $"UK_{nameof(Product).ToPlural()}_{nameof(Product.Name)}").IsUnique();
        builder.HasOne(p => p.Category);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Description).HasMaxLength(500);

        builder.Property(o => o.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);

        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Dell XPS 13",
                Description = "Dell'in popüler dizüstü bilgisayarı",
                StockCount = 10,
                Price = 15000,
                CategoryId = 4,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 2,
                Name = "Apple MacBook Pro",
                Description = "Apple'ın profesyoneller için dizüstü bilgisayarı",
                StockCount = 5,
                Price = 25000,
                CategoryId = 4,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 3,
                Name = "HP Pavilion Masaüstü",
                Description = "Günlük kullanım için ideal masaüstü bilgisayar",
                StockCount = 7,
                Price = 12000,
                CategoryId = 5,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 4,
                Name = "Samsung Galaxy S23",
                Description = "Samsung'ın yeni amiral gemisi akıllı telefonu",
                StockCount = 15,
                Price = 20000,
                CategoryId = 6,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 5,
                Name = "Apple iPhone 14",
                Description = "Apple'ın son model akıllı telefonu",
                StockCount = 20,
                Price = 25000,
                CategoryId = 7,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 6,
                Name = "LG OLED TV",
                Description = "En iyi görüntü kalitesi sunan televizyon",
                StockCount = 5,
                Price = 30000,
                CategoryId = 9,
                CreatedDateTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 7,
                Name = "Bosch Çamaşır Makinesi",
                Description = "Yüksek performanslı beyaz eşya",
                StockCount = 3,
                Price = 18000,
                CategoryId = 10,
                CreatedDateTime = DateTime.UtcNow
            }
        };

        builder.HasData(products);
    }
}