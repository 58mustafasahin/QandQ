using QandQ.Application.Repositories.Roles;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.Roles
{
    public class RoleWriteRepository : WriteRepository<Role>, IRoleWriteRepository
    {
        public RoleWriteRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
