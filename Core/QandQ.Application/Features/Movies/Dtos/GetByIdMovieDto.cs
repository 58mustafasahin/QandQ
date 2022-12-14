using QandQ.Application.Features.RateAndNoteMovies.Dtos;

namespace QandQ.Application.Features.Movies.Dtos
{
    public class GetByIdMovieDto
    {
        public int Id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public List<GetRateAndNoteMovieDto> RateAndNoteMovies { get; set; } 
        public double AverageRate { get; set; }
    }
}
