using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User).ToPlural()).HasKey(u => u.Id);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.PasswordSalt).IsRequired();
        builder.Property(u => u.Status).HasDefaultValue(true);

        builder.HasIndex(indexExpression: u => u.UserName, name: $"UK_{nameof(User).ToPlural()}_{nameof(User.UserName)}").IsUnique();
        builder.HasIndex(indexExpression: u => u.Email, name: $"UK_{nameof(User).ToPlural()}_{nameof(User.Email)}").IsUnique();

        builder.Property(u => u.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);
    }
}