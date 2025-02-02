using Application.Extensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;
using System.Reflection;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable(nameof(OperationClaim).ToPlural()).HasKey(o => o.Id);
        builder.HasIndex(indexExpression: o => o.Name, name: $"UK_{nameof(OperationClaim).ToPlural()}_{nameof(OperationClaim.Name)}").IsUnique();

        builder.Property(o => o.CreatedDateTime).HasDefaultValueSql(SqlConstants.CurrentUTCTimeStamp);

        builder.HasData(GetSeeds());
    }

    private HashSet<OperationClaim> GetSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds = new();

        // Assembly'deki tüm OperationClaims sınıflarını bul.
        // Klasörü Constants olduğunda namespace kontrolü yapılır.
        // Class isimleri OperationClaims ile bitmelidir.
        var operationClaimTypes = Assembly.Load("Application")
            .GetTypes()
            .Where(t => t.IsClass && t.Namespace != null && t.Namespace.Contains("Constants") && t.Name.EndsWith("OperationClaims"));

        foreach (var type in operationClaimTypes)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                             .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string));

            foreach (var field in fields)
            {
                string claimName = (string)field.GetRawConstantValue();
                if (!seeds.Any(s => s.Name == claimName))
                {
                    seeds.Add(new OperationClaim { Id = ++id, Name = claimName });
                }
            }
        }

        return seeds;
    }
}