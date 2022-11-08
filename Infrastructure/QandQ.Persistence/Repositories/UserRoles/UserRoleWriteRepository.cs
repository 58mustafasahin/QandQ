using QandQ.Application.Repositories.UserRoles;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.UserRoles
{
    public class UserRoleWriteRepository : WriteRepository<UserRole>, IUserRoleWriteRepository
    {
        public UserRoleWriteRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
