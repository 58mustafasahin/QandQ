using QandQ.Application.Repositories.RateAndNoteMovies;
using QandQ.Domain.Entities;
using QandQ.Persistence.Contexts;

namespace QandQ.Persistence.Repositories.RateAndNoteMovies
{
    public class RateAndNoteMovieWriteRepository : WriteRepository<RateAndNoteMovie>, IRateAndNoteMovieWriteRepository
    {
        public RateAndNoteMovieWriteRepository(QandQDbContext context) : base(context)
        {
        }
    }
}
