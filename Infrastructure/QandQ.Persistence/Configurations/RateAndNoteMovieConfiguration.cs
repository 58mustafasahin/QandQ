using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QandQ.Domain.Entities;

namespace QandQ.Persistence.Configurations
{
    public class RateAndNoteMovieConfiguration : IEntityTypeConfiguration<RateAndNoteMovie>
    {
        public void Configure(EntityTypeBuilder<RateAndNoteMovie> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Rate);
            builder.Property(p => p.Note).HasMaxLength(200);
        }
    }
}
