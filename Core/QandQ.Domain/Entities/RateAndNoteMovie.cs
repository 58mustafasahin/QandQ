using QandQ.Domain.Entities.Common;

namespace QandQ.Domain.Entities
{
    public class RateAndNoteMovie : BaseEntity
    {
        public int Rate { get; set; }
        public string Note { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
