using Mapster;
using MediatR;
using Newtonsoft.Json;
using QandQ.Application.Features.Movies.Dtos;
using QandQ.Application.Repositories.Movies;
using QandQ.Domain.Entities;

namespace QandQ.Application.Features.Movies.Commands.TransferMovie
{
    public class TransferMovieCommand : IRequest
    {
        public class TransferMovieCommandHandler : IRequestHandler<TransferMovieCommand, Unit>
        {
            private readonly IMovieWriteRepository _movieWriteRepository;

            public TransferMovieCommandHandler(IMovieWriteRepository movieWriteRepository)
            {
                _movieWriteRepository = movieWriteRepository;
            }

            public async Task TranferData()
            {
                var movieList = new GetAllMovieDto();
                using (var httpClient = new HttpClient())
                {
                    for (int i = 1; i < 4; i++)
                    {
                        using (var response = await httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key=eaeb94365c785f6d38b24373651b7206&language=en-US&page={i}"))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            movieList = JsonConvert.DeserializeObject<GetAllMovieDto>(apiResponse);
                            if (movieList.results.Count() > 0)
                            {
                                var newMovies = movieList.results.Adapt<List<Movie>>();
                                await _movieWriteRepository.AddRangeAsync(newMovies);
                                await _movieWriteRepository.SaveAsync();
                            }
                        }
                    }
                }
            }

            public async Task<Unit> Handle(TransferMovieCommand request, CancellationToken cancellationToken)
            {       
                return Unit.Value;
            }
        }
    }
}
