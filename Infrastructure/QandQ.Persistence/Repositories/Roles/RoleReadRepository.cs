using QandQ.Application.Repositories.Roles;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.Roles
{
    public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
    {
        public RoleReadRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
