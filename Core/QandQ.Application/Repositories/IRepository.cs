using Microsoft.EntityFrameworkCore;
using QandQ.Domain.Entities.Common;

namespace QandQ.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
