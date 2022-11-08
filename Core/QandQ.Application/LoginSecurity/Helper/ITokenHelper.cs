using QandQ.Application.LoginSecurity.Entity;
using QandQ.Domain.Entities;

namespace QandQ.Application.LoginSecurity.Helper
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<Role> userRoles);
    }
}
