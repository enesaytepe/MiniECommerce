using System.Security.Claims;

namespace Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType) => claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal?.Claims(ClaimTypes.Role);
    public static long? GetUserId(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.Select(long.Parse).FirstOrDefault();
}