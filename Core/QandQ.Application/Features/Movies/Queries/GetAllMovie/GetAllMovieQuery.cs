using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QandQ.Application.Features.Movies.Dtos;
using QandQ.Application.Repositories.Movies;
using QandQ.Application.RequestParameters;

namespace QandQ.Application.Features.Movies.Queries.GetAllMovie
{
    public class GetAllMovieQuery : IRequest<List<GetMovieDto>>
    {
        public PaginationEntity PaginationEntity { get; set; }
        public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, List<GetMovieDto>>
        {
            private readonly IMovieReadRepository _movieReadRepository;

            public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository)
            {
                _movieReadRepository = movieReadRepository;
            }

            public async Task<List<GetMovieDto>> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
            {
                var movieList = await _movieReadRepository.GetAll().Skip((request.PaginationEntity.PageNumber - 1) * request.PaginationEntity.PageSize).Take(request.PaginationEntity.PageSize).ToListAsync();
                return movieList.Adapt<List<GetMovieDto>>();
            }
        }
    }
}
