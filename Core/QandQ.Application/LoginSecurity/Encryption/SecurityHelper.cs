using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace QandQ.Application.LoginSecurity.Encryption
{
    public static class SecurityHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}

