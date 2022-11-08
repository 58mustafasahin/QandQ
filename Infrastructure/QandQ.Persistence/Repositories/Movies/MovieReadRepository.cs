using QandQ.Application.Repositories.Movies;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.Movies
{
    public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
    {
        public MovieReadRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
