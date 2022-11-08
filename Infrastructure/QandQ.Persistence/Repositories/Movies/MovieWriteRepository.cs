using QandQ.Application.Repositories.Movies;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.Movies
{
    public class MovieWriteRepository : WriteRepository<Movie>, IMovieWriteRepository
    {
        public MovieWriteRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
