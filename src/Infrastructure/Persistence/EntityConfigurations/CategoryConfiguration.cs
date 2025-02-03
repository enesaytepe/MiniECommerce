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

        builder.Property(o => o.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);

        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", ParentCategoryId = null, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 2, Name = "Category 1-1", ParentCategoryId = 1, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 3, Name = "Category 1-1-1", ParentCategoryId = 2, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 4, Name = "Category 1-1-2", ParentCategoryId = 2, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 5, Name = "Category 1-2", ParentCategoryId = 1, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 6, Name = "Category 2", ParentCategoryId = null, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 7, Name = "Category 3", ParentCategoryId = null, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 8, Name = "Category 3-1", ParentCategoryId = 7, CreatedDateTime = DateTime.UtcNow },
            new Category { Id = 9, Name = "Category 3-1-1", ParentCategoryId = 8, CreatedDateTime = DateTime.UtcNow }
        };

        builder.HasData(categories);
    }
}