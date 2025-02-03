using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category).ToPlural()).HasKey(o => o.Id);
        builder.HasIndex(indexExpression: o => o.Name, name: $"UK_{nameof(Category).ToPlural()}_{nameof(Category.Name)}").IsUnique();
        builder.HasMany(p => p.SubCategories);
        builder.HasMany(p => p.Products);
        builder.HasOne(p => p.ParentCategory);

        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);

        builder.Property(o => o.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);

        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Elektronik", ParentCategoryId = null, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 2, Name = "Bilgisayar", ParentCategoryId = 1, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 3, Name = "Telefon", ParentCategoryId = 1, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 4, Name = "Dizüstü Bilgisayar", ParentCategoryId = 2, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 5, Name = "Masaüstü Bilgisayar", ParentCategoryId = 2, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 6, Name = "Android Telefon", ParentCategoryId = 3, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 7, Name = "iOS Telefon", ParentCategoryId = 3, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 8, Name = "Ev Elektroniği", ParentCategoryId = null, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 9, Name = "Televizyon", ParentCategoryId = 8, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 10, Name = "Beyaz Eşya", ParentCategoryId = 8, CreatedDateTime = DateTime.UtcNow }
        };

        builder.HasData(categories);
    }
}