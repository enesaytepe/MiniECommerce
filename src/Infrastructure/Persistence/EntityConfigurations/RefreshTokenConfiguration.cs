using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable(nameof(RefreshToken).ToPlural()).HasKey(r => r.Id);
        builder.HasOne(r => r.User);

        builder.Property(r => r.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);
    }
}