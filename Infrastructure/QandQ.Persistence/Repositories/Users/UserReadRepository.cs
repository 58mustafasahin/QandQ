using QandQ.Application.Repositories.Users;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.Users
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
