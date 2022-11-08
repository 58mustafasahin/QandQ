using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QandQ.Application.LoginSecurity.Encryption;
using QandQ.Application.LoginSecurity.Entity;
using QandQ.Application.LoginSecurity.Extension;
using QandQ.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QandQ.Application.LoginSecurity.Helper
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateToken(User user, IEnumerable<Role> userRoles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, userRoles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, IEnumerable<Role> roles)
        {
            return new JwtSecurityToken
                (
                tokenOptions.Issuer,
                tokenOptions.Audience,
                SetJwtClaims(user, roles),
                DateTime.Now,
                _accessTokenExpiration,
                signingCredentials
                );
        }

        private static IEnumerable<Claim> SetJwtClaims(User user, IEnumerable<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddUserIdentifier(user.Id);
            claims.AddFullName($"{user.Name} {user.Surname}");
            claims.AddUserName(user.UserName);
            claims.AddRole(roles.Select(p => p.Name).AsEnumerable());
            return claims;
        }
    }
}
