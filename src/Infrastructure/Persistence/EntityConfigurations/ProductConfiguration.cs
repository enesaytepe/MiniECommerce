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

        builder.Property(o => o.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);
    }
}