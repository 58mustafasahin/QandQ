using QandQ.Domain.Entities.Common;

namespace QandQ.Domain.Entities
{
    public class Movie : BaseEntity
    {
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
        public ICollection<RateAndNoteMovie> RateAndNoteMovies { get; set; } = new List<RateAndNoteMovie>();
    }
}
