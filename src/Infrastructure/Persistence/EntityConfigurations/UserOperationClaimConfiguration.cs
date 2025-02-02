using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable(nameof(UserOperationClaim).ToPlural()).HasKey(u => u.Id);

        builder
            .HasIndex(indexExpression: u => new { u.UserId, u.OperationClaimId }, name: $"UK_{nameof(UserOperationClaim).ToPlural()}_{nameof(User)}{nameof(User.Id)}_{nameof(UserOperationClaim.Id)}")
            .IsUnique();
        builder.HasOne(u => u.User);
        builder.HasOne(u => u.OperationClaim);

        builder.Property(u => u.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);
    }
}