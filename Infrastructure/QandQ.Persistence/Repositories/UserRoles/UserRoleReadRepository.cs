using QandQ.Application.Repositories.UserRoles;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.UserRoles
{
    public class UserRoleReadRepository : ReadRepository<UserRole>, IUserRoleReadRepository
    {
        public UserRoleReadRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
