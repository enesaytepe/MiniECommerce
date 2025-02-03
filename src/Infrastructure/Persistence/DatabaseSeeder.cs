using Application.Hashing;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class DatabaseSeeder
{
    public static void EnsureSeed(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();

        //context.Database.Migrate(); 

        // Sysop kullanıcısının varlığını kontrol et
        if (!context.Users.Any(u => u.UserName == "sysop"))
        {
            byte[] passwordHash,
                passwordSalt;
            HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

            var sysopUser = new User
            {
                UserName = "sysop",
                FirstName = "System",
                LastName = "Operator",
                Email = "sysop@domain.com",
                EmailConfirmed = true,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true,
                CreatedDateTime = DateTime.UtcNow
            };

            context.Users.Add(sysopUser);
            context.SaveChanges();

            // OperationClaim'leri seed'de ekliyorsun. Admin claim ismini seed edilen değerle eşle.
            var adminClaim = context.OperationClaims.FirstOrDefault(c => c.Name == "Admin");
            if (adminClaim != null)
            {
                var userOperationClaim = new UserOperationClaim
                {
                    UserId = sysopUser.Id,
                    OperationClaimId = adminClaim.Id,
                    CreatedDateTime = DateTime.UtcNow
                };
                context.UserOperationClaims.Add(userOperationClaim);
                context.SaveChanges();
            }
        }
    }
}