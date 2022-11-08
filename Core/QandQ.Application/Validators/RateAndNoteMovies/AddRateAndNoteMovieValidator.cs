using FluentValidation;
using QandQ.Application.Features.RateAndNoteMovies.Commands.CreateRateAndNoteMovie;

namespace QandQ.Application.Validators.RateAndNoteMovies
{
    public class AddRateAndNoteMovieValidator : AbstractValidator<CreateRateAndNoteMovieCommand>
    {
        public AddRateAndNoteMovieValidator()
        {
            RuleFor(p => p.Rate).NotEmpty().WithMessage("Rate cannot be empty").GreaterThanOrEqualTo(1).LessThanOrEqualTo(10).WithMessage("Rate is outside of specified range");
            RuleFor(p => p.Note).NotEmpty().WithMessage("Note cannot be empty").Length(2, 200).WithMessage("Note is outside of specified range");
        }
    }
}
