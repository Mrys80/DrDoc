using Microsoft.IdentityModel.Tokens;

namespace DrDoc.Common.Utilities.Security.Encryption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}