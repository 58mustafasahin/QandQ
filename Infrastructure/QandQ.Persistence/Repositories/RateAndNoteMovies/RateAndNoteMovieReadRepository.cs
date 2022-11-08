using QandQ.Application.Repositories.RateAndNoteMovies;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.RateAndNoteMovies
{
    public class RateAndNoteMovieReadRepository : ReadRepository<RateAndNoteMovie>, IRateAndNoteMovieReadRepository
    {
        public RateAndNoteMovieReadRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
