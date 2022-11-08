using Microsoft.IdentityModel.Tokens;

namespace QandQ.Application.LoginSecurity.Encryption
{
    public static class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }
    }
}
