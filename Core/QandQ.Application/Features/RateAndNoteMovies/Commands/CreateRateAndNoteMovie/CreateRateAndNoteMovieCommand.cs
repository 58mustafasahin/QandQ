using Mapster;
using MediatR;
using QandQ.Application.Features.RateAndNoteMovies.Dtos;
using QandQ.Application.Repositories.RateAndNoteMovies;
using QandQ.Domain.Entities;

namespace QandQ.Application.Features.RateAndNoteMovies.Commands.CreateRateAndNoteMovie
{
    public class CreateRateAndNoteMovieCommand : IRequest<CreatedRateAndNoteMovieDto>
    {
        public int Rate { get; set; }
        public string Note { get; set; }
        public int MovieId { get; set; }

        public class CreateRateAndMovieCommandHandler : IRequestHandler<CreateRateAndNoteMovieCommand, CreatedRateAndNoteMovieDto>
        {
            private readonly IRateAndNoteMovieWriteRepository _rateAndNoteMovieWriteRepository;

            public CreateRateAndMovieCommandHandler(IRateAndNoteMovieWriteRepository rateAndNoteMovieWriteRepository)
            {
                _rateAndNoteMovieWriteRepository = rateAndNoteMovieWriteRepository;
            }

            public async Task<CreatedRateAndNoteMovieDto> Handle(CreateRateAndNoteMovieCommand request, CancellationToken cancellationToken)
            {
                var newRateAndNoteMovie = request.Adapt<RateAndNoteMovie>();
                await _rateAndNoteMovieWriteRepository.AddAsync(newRateAndNoteMovie);
                var result = await _rateAndNoteMovieWriteRepository.SaveAsync();
                return result > 0 ? newRateAndNoteMovie.Adapt<CreatedRateAndNoteMovieDto>() : null;
            }
        }
    }
}
