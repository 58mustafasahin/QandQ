using MediatR;
using QandQ.Application.Repositories.Movies;
using QandQ.Infrastructure.Mailing;

namespace QandQ.Application.Features.Movies.Commands.SuggestMovie
{
    public class SuggestMovieCommand : IRequest
    {
        public string Email { get; set; }
        public class SuggestMovieCommandHandler : IRequestHandler<SuggestMovieCommand>
        {
            private readonly IMovieReadRepository _movieReadRepository;
            private readonly IEmailService _emailService;

            public SuggestMovieCommandHandler(IMovieReadRepository movieReadRepository, IEmailService emailService)
            {
                _movieReadRepository = movieReadRepository;
                _emailService = emailService;
            }

            public async Task<Unit> Handle(SuggestMovieCommand request, CancellationToken cancellationToken)
            {
                // not the most efficient for larger data sets
                var movie = _movieReadRepository.Table.OrderBy(p => Guid.NewGuid()).First();

                //// another selecting random object
                //var random = new Random();
                //int toSkip = random.Next(0, _movieReadRepository.Table.Count());
                //var movie = _movieReadRepository.Table.Skip(toSkip).Take(1).First();

                var subject = "Suggested Movie";
                var message = $"Today you can watch {movie.original_title} movie. Overview : {movie.overview}";

                _emailService.SendEmail(request.Email, subject, message);

                return Unit.Value;
            }
        }
    }
}
