namespace QandQ.Application.Features.Movies.Dtos
{
    public class GetAllMovieDto
    {
        public int page { get; set; }
        public List<GetMovieDto> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
