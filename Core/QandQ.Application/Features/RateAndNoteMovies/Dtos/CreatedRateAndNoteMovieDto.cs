namespace QandQ.Application.Features.RateAndNoteMovies.Dtos
{
    public class CreatedRateAndNoteMovieDto
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Note { get; set; }
        public int MovieId { get; set; }
    }
}
