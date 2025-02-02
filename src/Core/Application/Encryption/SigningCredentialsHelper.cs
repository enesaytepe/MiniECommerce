using Microsoft.IdentityModel.Tokens;

namespace Application.Encryption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
        new(securityKey, SecurityAlgorithms.HmacSha512Signature);
}
