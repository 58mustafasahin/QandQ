using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QandQ.Application.Features.Movies.Dtos;
using QandQ.Application.Repositories.Movies;

namespace QandQ.Application.Features.Movies.Queries.GetByIdMovie
{
    public class GetByIdMovieQuery : IRequest<GetByIdMovieDto>
    {
        public int Id { get; set; }
        public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieDto>
        {
            private readonly IMovieReadRepository _movieReadRepository;

            public GetByIdMovieQueryHandler(IMovieReadRepository movieReadRepository)
            {
                _movieReadRepository = movieReadRepository;
            }

            public async Task<GetByIdMovieDto> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
            {
                var movie = await _movieReadRepository.GetWhere(p => p.Id == request.Id).Include(p => p.RateAndNoteMovies).FirstOrDefaultAsync();
                var avgRate = movie.RateAndNoteMovies.Average(p => p.Rate);
                var result = movie.Adapt<GetByIdMovieDto>();
                result.AverageRate = Math.Round(avgRate, 2);
                return result;
            }
        }
    }
}
